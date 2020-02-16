using System;
using System.Collections.Immutable;
using System.Linq;

using static System.Threading.LazyThreadSafetyMode;

namespace SwitchFunc
{
    /// <summary>
    /// Switch class is a functional wrapper of regular switch operator
    /// with other-following operators such as 'case', 'when', 'default';
    /// </summary>
    /// <typeparam name="V"></typeparam> 
    /// <remarks>
    /// Starting with C# 7.0, the match expression can be any non-null expression.
    /// </remarks>
    public sealed partial class SwitchCaseDefault<V> : SwitchFactory<V>, ISwitch<V>, ICase<V>, IDefault<V>
    {
        private static readonly ImmutableList<V>.Builder argsBuilder = ImmutableList.CreateBuilder<V>();
        private static readonly SwitchCaseDefault<V> EMPTY = new SwitchCaseDefault<V>(default);

        private static SwitchCaseDefault<V> instance = default;
        private static Predicate<V> whenDefault = default;
        private static bool breakerTrigger = default;

        private SwitchCaseDefault() { }
        private SwitchCaseDefault(in V inputValue) => switchValue = inputValue;

        private V switchValue = default;
        private V caseValue = default;

        private V switchValueGhost = default;
        private V caseValueGhost = default;

        private bool IsSwitchValueNull => switchValue == null;

        private bool IsCaseValueNull => caseValue == null;

        private bool IsValueType => (typeof(V) ?? default).IsValueType;

        private Action ResetArgumentList => () => argsBuilder?.Clear();

        public static SwitchCaseDefault<V> Of(V arg) =>
            new Lazy<SwitchCaseDefault<V>>(() => new SwitchCaseDefault<V>(arg), PublicationOnly).Value;

        public static SwitchCaseDefault<V> OfNullable(V arg) => arg != null ? Of(arg) : EMPTY;
        public static SwitchCaseDefault<V> OfNullable(Func<V> outputValue) => outputValue != null ? Of(outputValue()) : EMPTY;

        public ICase<V> CaseOf(V cValue, Predicate<V> when = default)
        {
            if (!cValue.Equals(default))
            {
                caseValue = cValue;
                argsBuilder?.Add(cValue);

                if (when != default)
                {
                    whenDefault = when;
                }
            }

            return this;
        }

        ICase<V> ICase<V>.Accomplish(Action action, bool enableBreak) => CaseAccomplish(v => action(), enableBreak);
        ICase<V> ICase<V>.Accomplish(Action<V> action, bool enableBreak) => CaseAccomplish(action, enableBreak);

        IDefault<V> ICase<V>.ChangeOverToDefault => this;

        IDefault<V> IDefault<V>.Accomplish(Action action, bool enableBreak) => DefaultAccomplish(v => action(), enableBreak);
        IDefault<V> IDefault<V>.Accomplish(Action<V> action, bool enableBreak) => DefaultAccomplish(action, enableBreak);

        V IDefault<V>.AccomplishToGet(Func<V> supplier, bool enableBreak) =>
            caseValue.Equals(switchValue)
                ? default
                : enableBreak
                    ? supplier.Equals(default)
                        ? default
                        : (!IsSwitchValueNull)
                            ? supplier()
                            : default
                    : default;

        public SwitchCaseDefault<V> ResetFullEntities()
        {
            if (!IsSwitchValueNull)
            {
                Breaker();
            }

            if (argsBuilder?.Count > 0)
            {
                ResetArgumentList();
            }

            return this;
        }

        //It goes after switch start-point
        public ICase<V> Peek(in Action<V> action)
        {
            if (!IsSwitchValueNull)
            {
                action?.Invoke(switchValue);
            }

            return this;
        }

        //It goes after case middle-point(s)
        ICase<V> ICase<V>.Peek(in Action<V> action) => Peek(action) as ICase<V> ?? default;

        //It goes after default end-point
        IDefault<V> IDefault<V>.Peek(in Action<V> action) => Peek(action) as IDefault<V> ?? default;

        public V GetSwitch() => switchValue.Equals(default(V)) || switchValue == null ? switchValueGhost : switchValue;
        public V GetCase() => caseValue.Equals(default(V)) || caseValue == null ? caseValueGhost : caseValue;

        public V GetSwitchCustomized(in Func<V, V> funcCustom) => !IsSwitchValueNull ? funcCustom(GetSwitch()) : default;
        public U GetSwitchCustomized<U>(in Func<V, U> funcCustom) => !IsSwitchValueNull ? funcCustom(GetSwitch()) : default;

        public V GetCaseCustomized(in Func<V, V> funcCustom) => !IsCaseValueNull ? funcCustom(GetCase()) : default;
        public U GetCaseCustomized<U>(in Func<V, U> funcCustom) => !IsCaseValueNull ? funcCustom(GetCase()) : default;

        public ImmutableHashSet<V> GetCaseValuesAsImmutableSet() => argsBuilder.ToImmutableHashSet() ?? default;
        public ImmutableSortedSet<V> GetCaseValuesAsImmutableSortedSet() => argsBuilder.ToImmutableSortedSet() ?? default;
        public ImmutableList<V> GetCaseValuesAsImmutableList() => argsBuilder.ToImmutable() ?? default;

        public static implicit operator SwitchCaseDefault<V>(V value) => OfNullable(value);
        public static implicit operator SwitchCaseDefault<V>(Func<V> value) => OfNullable(value());
    }

    public sealed partial class SwitchCaseDefault<V>
    {
        private protected sealed override void Breaker()
        {
            if (IsValueType)
            {
                (switchValueGhost, caseValueGhost) = (switchValue, caseValue);
                (switchValue, caseValue) = (default, default);
                breakerTrigger = true;
            }
            else return;
        }

        private protected sealed override void ExecutionByCaseValue(Action<V> actionByCaseValue)
        {
            if (!IsCaseValueNull)
                actionByCaseValue?.Invoke(caseValue);
        }

        private protected sealed override void ExecutionBySwitchValue(Action<V> actionBySwitchValue)
        {
            if (!IsSwitchValueNull)
                actionBySwitchValue?.Invoke(switchValue);
        }

        private ICase<V> CaseAccomplish(Action<V> action, bool enableBreak)
        {
            if (whenDefault == default)
            {
                if (caseValue.Equals(switchValue))
                {
                    return fulfillMain();
                }
                else return this;
            }
            else if (caseValue.Equals(switchValue) && whenDefault.Invoke(caseValue))
            {
                return fulfillMain();
            }
            else
            {
                whenDefault = default;
                return this;
            }

            SwitchCaseDefault<V> fulfillMain()
            {
                if (enableBreak)
                {
                    ExecutionByCaseValue(action ?? default);
                    Breaker();
                    return this;
                }
                else
                {
                    ExecutionByCaseValue(action ?? default);
                    return this;
                }
            }
        }

        private IDefault<V> DefaultAccomplish(Action<V> action, bool enableBreak)
        {
            var refFiltered = argsBuilder.ToImmutable()
                .Where(v => v.Equals(switchValue) && !v.GetType().IsValueType)
                .FirstOrDefault();

            if (IsValueType)
            {
                if (!switchValue.Equals(default(V)))
                {
                    fulfillMain();
                }
                else
                {
                    if (!breakerTrigger)
                    {
                        fulfillMain();
                    }
                }
            }

            if (!IsValueType && refFiltered == null)
            {
                fulfillMain();
            }

            void fulfillMain()
            {
                if (enableBreak)
                {
                    ExecutionBySwitchValue(action ?? default);
                }
            }

            return this;
        }
    }
}

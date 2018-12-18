using System;
using System.Collections.Immutable;
using System.Linq;

namespace SwitchFunc
{
    /// <summary>
    /// Switch class is a functional wrapper of the regular switch operator
    /// with other-following operators such as 'case', 'when', 'default';
    /// </summary>
    /// <typeparam name="V"></typeparam> 
    /// <remarks>
    /// Starting with C# 7.0, the match expression can be any non-null expression.
    /// </remarks>
    public sealed partial class SwitchCaseDefault<V> : SwitchFactory<V>, ISwitch<V>, ICase<V>, IDefault<V>
    {
        private static readonly object synchronized = new object();
        private static readonly ImmutableList<V>.Builder argsBuilder = ImmutableList.CreateBuilder<V>();

        private static SwitchCaseDefault<V> instance = default;
        private static Predicate<V> whenDefault = default;
        private static bool breakerTrigger = default;

        private SwitchCaseDefault() { }
        private SwitchCaseDefault(in V inputValue) => SwitchValue = inputValue;

        public V SwitchValue { get; set; } = default;
        public V CaseValue { get; set; } = default;

        private bool IsSwitchValueNull => SwitchValue == null;
        private bool IsSwitchValueDefault => SwitchValue == default;

        private bool IsValueType => (typeof(V) ?? default).IsValueType;

        private Action ResetArgumentList => () => argsBuilder?.Clear();

        public static SwitchCaseDefault<V> Empty => new SwitchCaseDefault<V>(default);

        public static SwitchCaseDefault<V> Of(V arg)
        {
            if (instance == default)
            {
                lock(synchronized)
                {
                    instance = instance ?? new SwitchCaseDefault<V>(arg);
                }
            }
            return instance;
        }

        public static SwitchCaseDefault<V> OfNullable(V arg) => arg != null ? Of(arg) : Empty;
        public static SwitchCaseDefault<V> OfNullable(Func<V> outputValue) => outputValue != null ? Of(outputValue()) : Empty;
        
        public ICase<V> CaseOf(V cValue, Predicate<V> when = default)
        {            
            if (!cValue.Equals(default))
            {
                CaseValue = cValue;
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
            CaseValue.Equals(SwitchValue)
                ? default
                : enableBreak
                    ? supplier.Equals(default)
                        ? default
                        : (!IsSwitchValueNull || !IsSwitchValueDefault)
                            ? supplier()
                            : default
                    : default;

        public SwitchCaseDefault<V> ResetFullEntities()
        {
            if (!IsSwitchValueNull && !IsSwitchValueDefault)
            {
                Breaker();
            }

            if (argsBuilder?.Count > 0)
            {
                ResetArgumentList();
            }

            return this;
        }        

        public ICase<V> Peek(Action<V> action) => Overwatch(action);
        ICase<V> ICase<V>.Peek(Action<V> action) => Overwatch(action); //todo implement logic for the case values
        IDefault<V> IDefault<V>.Peek(Action<V> action) => Overwatch(action); //todo implement logic for the default value only

        public V GetCustomized(Func<V, V> funcCustom) => !IsSwitchValueNull || !IsSwitchValueDefault ? funcCustom(SwitchValue) : default;
        public U GetCustomized<U>(Func<V, U> funcCustom) => !IsSwitchValueNull || !IsSwitchValueDefault ? funcCustom(SwitchValue) : default;

        public ImmutableHashSet<V> GetCaseValuesAsImmutableSet() => argsBuilder.ToImmutableHashSet() ?? default;
        public ImmutableSortedSet<V> GetCaseValuesAsImmutableSortedSet() => argsBuilder.ToImmutableSortedSet() ?? default;
        public ImmutableList<V> GetCaseValuesAsImmutableList() => argsBuilder.ToImmutable() ?? default;
                
        public static implicit operator SwitchCaseDefault<V>(V value) => OfNullable(value);
        public static implicit operator SwitchCaseDefault<V>(Func<V> value) => OfNullable(value());
        //public static implicit operator SwitchCaseDefault<V>(Func<V, V> value) => OfNullable(value(FunctionInput));

        //public static explicit operator SwitchCaseDefault<V>(Func<V, V> value) => OfNullable(value(FunctionInput));
    }

    public sealed partial class SwitchCaseDefault<V>
    {
        protected sealed override void Breaker() => new Action(() => {
            if (IsValueType)
            {
                (SwitchValue, CaseValue) = (default, default);
                breakerTrigger = true;
            }
            else return;
        })?.Invoke();

        protected sealed override void ExecutionByCaseValue(Action<V> actionByCaseValue) => new Action(() => {
            if (!IsSwitchValueNull || !IsSwitchValueDefault)
                actionByCaseValue?.Invoke(CaseValue);
        })?.Invoke();

        protected sealed override void ExecutionBySwitchValue(Action<V> actionBySwitchValue) => new Action(() => {
            if (!IsSwitchValueNull || !IsSwitchValueDefault)
                actionBySwitchValue?.Invoke(SwitchValue);
        })?.Invoke();

        private ICase<V> CaseAccomplish(Action<V> action, bool enableBreak)
        {
            if (whenDefault == default)
            {
                if (CaseValue.Equals(SwitchValue))
                {
                    return fulfillMain();
                }
                else return this;
            }
            else if (CaseValue.Equals(SwitchValue) && whenDefault.Invoke(CaseValue))
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
                .Where(v => v.Equals(SwitchValue))
                .Where(v => !v.GetType().IsValueType)
                .FirstOrDefault();

            if (IsValueType)
            {
                if (!SwitchValue.Equals(default(V)))
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

            if (!IsValueType && refFiltered == default)
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

        private dynamic Overwatch(in Action<V> action)
        {
            if (!IsSwitchValueNull || !IsSwitchValueDefault)
            {
                action?.Invoke(SwitchValue);
            }

            return this;
        }
    }
}

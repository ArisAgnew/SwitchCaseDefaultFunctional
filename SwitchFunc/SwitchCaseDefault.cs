using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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
    public sealed class SwitchCaseDefault<V> : SwitchFactory<V>, ISwitch<V>, ICase<V>, IDefault<V>
    {        
        private readonly ImmutableList<V>.Builder argsBuilder = ImmutableList.CreateBuilder<V>();

        private SwitchCaseDefault() { }
        private SwitchCaseDefault(in V inputValue) => SwitchValue = inputValue;

        public V SwitchValue { get; set; } = default;
        public V CaseValue { get; set; } = default;

        private bool IsSwitchValueNull => SwitchValue == null;
        private bool IsSwitchValueDefault => SwitchValue == default;

        private bool IsValueType => (typeof(V) ?? default).IsValueType;

        private Action ResetArgumentList => () => argsBuilder?.Clear();

        public static SwitchCaseDefault<V> Empty { get; } = new SwitchCaseDefault<V>(default);

        public static SwitchCaseDefault<V> Of(V arg) => new SwitchCaseDefault<V>(arg);
        public static SwitchCaseDefault<V> OfNullable(V arg) => arg != null ? Of(arg) : Empty;
        public static SwitchCaseDefault<V> OfNullable(Func<V> outputValue) => outputValue != null ? Of(outputValue()) : Empty;

        protected sealed override void Breaker() => new Action(() => {
            if (IsValueType)
            {
                (SwitchValue, CaseValue) = (default, default);
            }
            else return;
        })?.Invoke();

        protected sealed override void ExecutionByCaseValue(Action<V> actionByCaseValue) => new Action(() => {
            if (!IsSwitchValueNull || !IsSwitchValueDefault)
                actionByCaseValue?.Invoke(SwitchValue);
        })?.Invoke();

        protected sealed override void ExecutionBySwitchValue(Action<V> actionBySwitchValue) => new Action(() => {
            if (!IsSwitchValueNull || !IsSwitchValueDefault)
                actionBySwitchValue?.Invoke(SwitchValue);
        })?.Invoke();

        private V Execution(Func<V> supplier) =>
            supplier.Equals(default)
                ? default
                : (!IsSwitchValueNull || !IsSwitchValueDefault)
                    ? supplier()
                    : default;

        ICase<V> ICase<V>.CaseOf(V cValue)
        {
            if (!cValue.Equals(default))
            {
                CaseValue = cValue;
                argsBuilder?.Add(cValue);
            }

            return this;
        }

        private ICase<V> CaseAccomplish(Action<V> action, bool enableBreak)
        {
            if (CaseValue.Equals(SwitchValue))
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
            else return this;
        }

        private IDefault<V> DefaultAccomplish(Action<V> action, bool enableBreak)
        {
            if (!CaseValue.Equals(SwitchValue))
            {
                if (enableBreak)
                {
                    ExecutionBySwitchValue(action ?? default);
                }
            }

            return this;
        }

        ICase<V> ICase<V>.Accomplish(Action action, bool enableBreak) => CaseAccomplish(v => action?.Invoke(), enableBreak);
        ICase<V> ICase<V>.Accomplish(Action<V> action, bool enableBreak) => CaseAccomplish(action, enableBreak);

        IDefault<V> ICase<V>.ChangeOverToDefault => this ?? default;

        IDefault<V> IDefault<V>.Accomplish(Action action, bool enableBreak) => DefaultAccomplish(v => action?.Invoke(), enableBreak);
        IDefault<V> IDefault<V>.Accomplish(Action<V> action, bool enableBreak) => DefaultAccomplish(action, enableBreak);
        
        V IDefault<V>.Accomplish(Func<V> supplier, bool enableBreak) =>
            CaseValue.Equals(SwitchValue)
                ? default
                : enableBreak
                    ? Execution(supplier)
                    : default;

        public SwitchCaseDefault<V> FullEntitiesReset()
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

        ISwitch<V> ISwitch<V>.Peek(Action<V> action)
        {
            if (!IsSwitchValueNull || !IsSwitchValueDefault)
            {
                action?.Invoke(SwitchValue);
            }

            return this;
        }

        public V GetCustomized(Func<V, V> funcCustom) => !IsSwitchValueNull || !IsSwitchValueDefault ? funcCustom(SwitchValue) : default;
        public U GetCustomized<U>(Func<V, U> funcCustom) => !IsSwitchValueNull || !IsSwitchValueDefault ? funcCustom(SwitchValue) : default;

        public ImmutableHashSet<V> GetCaseValuesAsImmutableSet() => argsBuilder.ToImmutableHashSet() ?? default;
        public ImmutableList<V> GetCaseValuesAsImmutableList() => argsBuilder.ToImmutable() ?? default;
        public ImmutableSortedSet<V> GetCaseValuesAsImmutableSortedSet() => argsBuilder.ToImmutableSortedSet() ?? default;

        public static implicit operator SwitchCaseDefault<V>(V value) => OfNullable(value);
    }
}

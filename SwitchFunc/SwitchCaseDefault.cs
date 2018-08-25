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
    public sealed partial class SwitchCaseDefault<V> : SwitchFactory<V>, ISwitch<V>, ICase<V>, IDefault<V>
    {
        V ISwitch<V>.SwitchValue { get => default; set => value = default; }
        V ICase<V>.CaseValue { get => default; set => value = default; }

        IDefault<V> ICase<V>.ChangeOverToDefault => throw new NotImplementedException();

        private protected override void Breaker()
        {
            throw new NotImplementedException();
        }

        private protected override void ExecutionByCaseValue(Action<V> action)
        {
            throw new NotImplementedException();
        }

        private protected override void ExecutionBySwitchValue(Action<V> action)
        {
            throw new NotImplementedException();
        }

        ICase<V> ICase<V>.Accomplish(Action action, bool enableBreak)
        {
            throw new NotImplementedException();
        }

        ICase<V> ICase<V>.Accomplish(Action<V> action, bool enableBreak)
        {
            throw new NotImplementedException();
        }

        IDefault<V> IDefault<V>.Accomplish(Action action, bool enableBreak)
        {
            throw new NotImplementedException();
        }

        IDefault<V> IDefault<V>.Accomplish(Action<V> action, bool enableBreak)
        {
            throw new NotImplementedException();
        }

        V IDefault<V>.Accomplish(Func<V> supplier, bool enableBreak)
        {
            throw new NotImplementedException();
        }

        ICase<V> ICase<V>.CaseOf(V v)
        {
            throw new NotImplementedException();
        }

        ISwitch<V> ISwitch<V>.Peek(Action<V> action)
        {
            throw new NotImplementedException();
        }
    }
}

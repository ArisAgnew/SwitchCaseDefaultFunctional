using System;

namespace SwitchFunc
{
    public interface IDefault<V>
    {
        IDefault<V> Accomplish(Action action = default, bool enableBreak = !default(bool));

        IDefault<V> Accomplish(Action<V> action = default, bool enableBreak = !default(bool));

        V AccomplishToGet(Func<V> supplier = default, bool enableBreak = !default(bool));

        IDefault<V> Peek(Action<V> action);
    }
}

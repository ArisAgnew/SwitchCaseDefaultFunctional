using System;

namespace SwitchFunc
{
    public interface ISwitch<V>
    {
        ICase<V> Peek(Action<V> action);
    }
}

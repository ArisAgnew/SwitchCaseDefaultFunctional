using System;

namespace SwitchFunc
{
    public interface ISwitch<V>
    {
        ICase<V> Peek(in Action<V> action);
    }
}

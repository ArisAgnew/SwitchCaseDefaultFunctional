using System;

namespace SwitchFunc
{
    public interface ISwitch<V>
    {
        V SwitchValue { get; set; }

        ICase<V> Peek(Action<V> action);
    }
}

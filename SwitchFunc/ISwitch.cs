using System;

namespace SwitchFunc
{
    public interface ISwitch<V>
    {
        /// <summary>
        /// 
        /// </summary>
        V SwitchValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        ICase<V> Peek(Action<V> action);
    }
}

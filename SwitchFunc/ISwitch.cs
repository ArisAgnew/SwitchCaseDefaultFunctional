using System;
using System.Collections.Generic;
using System.Text;

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
        ISwitch<V> Peek(Action<V> action);
    }
}

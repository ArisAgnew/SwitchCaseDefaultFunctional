using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFunc
{
    interface ISwitch<V>
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

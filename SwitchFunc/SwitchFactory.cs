using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFunc
{
    public abstract class SwitchFactory<V>
    {
        /// <summary>
        /// 
        /// </summary>
        private protected abstract void Breaker();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        private protected abstract void ExecutionBySwitchValue(Action<V> action);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        private protected abstract void ExecutionByCaseValue(Action<V> action);
    }
}

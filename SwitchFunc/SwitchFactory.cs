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
        protected abstract void Breaker();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionBySwitchValue"></param>
        protected abstract void ExecutionBySwitchValue(Action<V> actionBySwitchValue = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionByCaseValue"></param>
        protected abstract void ExecutionByCaseValue(Action<V> actionByCaseValue = default);
    }
}

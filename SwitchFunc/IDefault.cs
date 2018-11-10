﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFunc
{
    public interface IDefault<V>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="enableBreak"></param>
        /// <returns></returns>
        IDefault<V> Accomplish(Action action = default, bool enableBreak = !default(bool));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="enableBreak"></param>
        /// <returns></returns>
        IDefault<V> Accomplish(Action<V> action = default, bool enableBreak = !default(bool));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="enableBreak"></param>
        /// <returns></returns>
        V Accomplish(Func<V> supplier = default, bool enableBreak = !default(bool));
    }
}
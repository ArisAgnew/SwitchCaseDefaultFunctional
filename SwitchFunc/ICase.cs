using System;
using System.Collections.Immutable;

namespace SwitchFunc
{
    public interface ICase<V>
    {
        /// <summary>
        /// 
        /// </summary>
        V CaseValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cValue"></param>
        /// <returns></returns>
        ICase<V> CaseOf(V cValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="enableBreak"></param>
        /// <returns></returns>
        ICase<V> Accomplish(Action action = default, bool enableBreak = !default(bool));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="enableBreak"></param>
        /// <returns></returns>
        ICase<V> Accomplish(Action<V> action = default, bool enableBreak = !default(bool));

        /// <summary>
        /// 
        /// </summary>
        IDefault<V> ChangeOverToDefault { get; }
        
        ICase<V> Peek(Action<V> action);

        ImmutableList<V> GetCaseValuesAsImmutableList();
    }
}

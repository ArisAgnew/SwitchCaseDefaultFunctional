using System;

namespace SwitchFunc
{
    public interface ICase<V>
    {
        /// <summary>
        /// Simple trigger allowing to switch to default part
        /// </summary>
        IDefault<V> ChangeOverToDefault { get; }

        /// <summary>
        /// Performs matching against an expression to be specified in switch
        /// </summary>
        /// <param name="cValue">value possibly to be matched with switch</param>
        /// <param name="when">optional parameter to make use of predicate that emulates
        /// <code>when</code> keyword to have been added since C# 7.0</param>
        /// <returns>Returns <code>ICase<typeparamref name="V"/></code></returns>
        ICase<V> CaseOf(V cValue, Predicate<V> when = default);

        //ICase<V> CaseDynamicOf(V cValue, Predicate<dynamic> when = default);

        /// <summary>
        /// Performs action in case of 'case' value is matched up with 'switch' value
        /// </summary>
        /// <param name="action">action with no inbound parameter</param>
        /// <param name="enableBreak">optional parameter emulates regular <code>break</code></param>
        /// <returns>Returns <code>ICase<typeparamref name="V"/></code></returns>
        ICase<V> Accomplish(Action action = default, bool enableBreak = !default(bool));

        /// <summary>
        /// Performs action in case of 'case' value is matched up with 'switch' value
        /// </summary>
        /// <param name="action">action with matched 'сase' value as an inbound <typeparamref name="V"/> parameter</param>
        /// <param name="enableBreak">optional parameter emulates regular <code>break</code></param>
        /// <returns>Returns <code>ICase<typeparamref name="V"/></code></returns>
        ICase<V> Accomplish(Action<V> action = default, bool enableBreak = !default(bool));

        /// <summary>
        /// Provides an opportunity to peek in and apply some action(s) upon inbound parameter thereupon
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Returns <code>ICase<typeparamref name="V"/></code></returns>
        ICase<V> Peek(in Action<V> action);
    }
}

using System;

namespace SwitchFunc
{
    public interface IDefault<V>
    {
        /// <summary>
        /// Performs action in case of 'case' value is matched up with 'switch' value
        /// </summary>
        /// <param name="action">action with no inbound parameter</param>
        /// <param name="enableBreak">optional parameter emulates regular <code>break</code></param>
        /// <returns>Returns <code>IDefault<typeparamref name="V"/></code></returns>
        IDefault<V> Accomplish(Action action = default, bool enableBreak = !default(bool));

        /// <summary>
        /// Performs action in case of 'case' value is matched up with 'switch' value
        /// </summary>
        /// <param name="action">action with matched 'сase' value as an inbound <typeparamref name="V"/> parameter</param>
        /// <param name="enableBreak">optional parameter emulates regular <code>break</code></param>
        /// <returns>Returns <code>IDefault<typeparamref name="V"/></code></returns>
        IDefault<V> Accomplish(Action<V> action = default, bool enableBreak = !default(bool));

        /// <summary>
        /// Allows to retrieve final value after the whole cycle switch-case-defalt has been accomplished
        /// </summary>
        /// <param name="supplier">???</param>
        /// <param name="enableBreak">optional parameter emulates regular <code>break</code></param>
        /// <returns><typeparamref name="V"/></returns>
        [Obsolete] //to come up with another type of method 01/09/2019
        V AccomplishToGet(Func<V> supplier = default, bool enableBreak = !default(bool));

        /// <summary>
        /// Provides an opportunity to peek in and apply some action(s) upon inbound parameter thereupon
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Returns <code>IDefault<typeparamref name="V"/></code></returns>
        IDefault<V> Peek(in Action<V> action);
    }
}

using System;

namespace SwitchFunc
{
    public interface ISwitch<V>
    {
        /// <summary>
        /// Provides an opportunity to peek in and apply some action(s) upon inbound parameter thereupon
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Returns <code>ICase<typeparamref name="V"/></code></returns>
        ICase<V> Peek(in Action<V> action);
    }
}

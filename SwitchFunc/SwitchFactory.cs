using System;

namespace SwitchFunc
{
    public abstract class SwitchFactory<V>
    {
        /// <summary>
        /// Imitates the <c>break</c> statement that terminates <c>switch</c> statement in which it appears.
        /// </summary>
        /// <example>
        ///     <code>
        ///     (n is an int variable)
        ///          
        ///     switch (n)
        ///     {
        ///         case 1:
        ///             Console.WriteLine($"Current value is {1}");
        ///             break;
        ///         case 2:
        ///         ...
        ///     }
        ///     </code>
        /// </example>
        protected abstract void Breaker();

        /// <summary>
        /// The main execution in relation to 'switch' value
        /// </summary>
        /// <param name="actionBySwitchValue">
        /// Action using as an inbound parameter the very 'switch' value
        /// </param>
        protected abstract void ExecutionBySwitchValue(Action<V> actionBySwitchValue = default);

        /// <summary>
        /// The main execution in relation to 'case' value
        /// </summary>
        /// <param name="actionByCaseValue">
        /// Action using as an inbound parameter the very 'case' value
        /// </param>
        protected abstract void ExecutionByCaseValue(Action<V> actionByCaseValue = default);
    }
}

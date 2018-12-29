using System;
using System.Threading.Tasks;

namespace SwitchFunc
{
    public interface ICase<V>
    {
        IDefault<V> ChangeOverToDefault { get; }
        
        ICase<V> CaseOf(V cValue, Predicate<V> when = default);

        //ICase<V> CaseDynamicOf(V cValue, Predicate<dynamic> when = default);

        ICase<V> Accomplish(Action action = default, bool enableBreak = !default(bool));
               
        ICase<V> Accomplish(Action<V> action = default, bool enableBreak = !default(bool));

        ICase<V> AsyncAccomplish(Action<V> action = default, bool enableBreak = !default(bool));
                
        ICase<V> Peek(in Action<V> action);
    }
}

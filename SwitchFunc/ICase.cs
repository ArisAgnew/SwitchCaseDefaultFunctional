using System;

namespace SwitchFunc
{
    public interface ICase<V>
    {
        V CaseValue { get; set; }

        IDefault<V> ChangeOverToDefault { get; }
        
        ICase<V> CaseOf(V cValue, Predicate<V> when = default);

        //ICase<V> CaseOf(V cValue, Predicate<dynamic> when = default);

        ICase<V> Accomplish(Action action = default, bool enableBreak = !default(bool));
               
        ICase<V> Accomplish(Action<V> action = default, bool enableBreak = !default(bool));
                
        ICase<V> Peek(Action<V> action);
    }
}

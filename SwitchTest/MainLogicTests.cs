using Xunit;
using Xunit.Abstractions;
using System;
using System.Linq;

using SwitchFunc;
using System.Collections.Immutable;

namespace SwitchTest
{    
    public class MainLogicTests : TestData
    {
        private readonly ITestOutputHelper _output;
        public MainLogicTests(ITestOutputHelper output) => _output = output;

        [Fact]
        public void ByteTest()
        {
            _switchValSbyte = 99;//(sbyte)(new Random().Next(sbyte.MinValue, sbyte.MaxValue));
            var type = _switchValSbyte.GetType().GetGenericArguments().SingleOrDefault();

            Assert.StrictEqual(typeof(sbyte), _switchValSbyte.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(SByte)));
            Assert.True(type.IsValueType);

            _switchValSbyte
                .CaseOf(50).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf(75).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf(99).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .CaseOf(123).Accomplish(v => _output.WriteLine($"Fourth value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));

            _switchValSbyte
                .GetCaseValuesAsImmutableSortedSet()
                .SelectMany(l => ImmutableList.Create(l))
                .ToList()
                .ForEach(s => _output.WriteLine(s.ToString()));
        }

        [Fact]
        public void StringTest()
        {
            _switchRefString = ImmutableList<string>.Empty
                .Add(string.Empty)
                .Add("string")
                .Add("not string")
                .Add("String")
                [new Random().Next(0, 3)];

            var type = _switchRefString.GetType().GetGenericArguments().SingleOrDefault();
            
            Assert.StrictEqual(typeof(string), _switchRefString.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(String)));
            Assert.True(!type.IsValueType);
            Assert.False(type.IsValueType);

            _switchRefString
                .CaseOf("string").Accomplish(v => _output.WriteLine($"First ref: {v}"))
                .CaseOf("not string").Accomplish(v => _output.WriteLine($"Second ref: {v}"))
                .CaseOf("String").Accomplish(v => _output.WriteLine($"Third ref: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default ref: {vDef}"));
        }
    }
}

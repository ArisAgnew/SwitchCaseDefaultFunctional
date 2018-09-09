using Xunit;
using Xunit.Abstractions;
using System;
using System.Linq;

using SwitchFunc;

namespace SwitchTest
{    
    public class MainLogicTests
    {
        private readonly ITestOutputHelper _output;
        public MainLogicTests(ITestOutputHelper output) => _output = output;

        private SwitchCaseDefault<sbyte> _switchValSbyte = default;
        private SwitchCaseDefault<short> _switchValShort = default;
        private SwitchCaseDefault<int> _switchValInt = default;
        private SwitchCaseDefault<long> _switchValLong = default;
        private SwitchCaseDefault<byte> _switchValByte = default;
        private SwitchCaseDefault<ushort> _switchValUshort = default;
        private SwitchCaseDefault<uint> _switchValUint = default;
        private SwitchCaseDefault<ulong> _switchValUlong = default;
        private SwitchCaseDefault<char> _switchValChar = default;
        private SwitchCaseDefault<float> _switchValFloat = default;
        private SwitchCaseDefault<double> _switchValDouble = default;
        private SwitchCaseDefault<decimal> _switchValDecimal = default;
        private SwitchCaseDefault<bool> _switchValBool = default;
        private SwitchCaseDefault<TypeCode> _switchValEnum = default;

        private SwitchCaseDefault<object> _switchRefObject = default;
        private SwitchCaseDefault<string> _switchRefString = default;
        private SwitchCaseDefault<string[]> _switchRefOneDimensionalArray = default;
        private SwitchCaseDefault<string[][]> _switchRefTwoDimensionalArray = default;
        private SwitchCaseDefault<string[,]> _switchRefMultiDimensionalArray = default;

        [Fact]
        public void Test1()
        {
            _switchValSbyte = (sbyte)(new Random().Next(-128, 127)); //implicit operator in action
            var type = _switchValSbyte.GetType().GetGenericArguments().SingleOrDefault();

            Assert.StrictEqual(typeof(sbyte), _switchValSbyte.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(SByte)));
            Assert.True(type.IsValueType);

            _switchValSbyte
                .CaseOf(50).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf(75).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf(99).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));                        
        }

        [Fact(DisplayName = "ิเ๊๒ 2")]
        public void Test2()
        {
            _switchRefString = "String"; //implicit operator in action

            var type = _switchRefString.GetType().GetGenericArguments().SingleOrDefault();
            
            Assert.StrictEqual(typeof(string), _switchRefString.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(String)));
            Assert.False(type.IsValueType);
            
            _switchRefString
                .CaseOf("string").Accomplish(v => _output.WriteLine($"First ref: {v}"))
                .CaseOf("not string").Accomplish(v => _output.WriteLine($"Second ref: {v}"))
                .CaseOf("String").Accomplish(v => _output.WriteLine($"Third ref: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default ref: {vDef}"));
        }
    }
}

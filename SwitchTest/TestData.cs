using SwitchFunc;
using System;

namespace SwitchTest
{
    public class TestData
    {
        #region Value Types
        protected SwitchCaseDefault<sbyte> _switchValSbyte = default;
        protected SwitchCaseDefault<short> _switchValShort = default;
        protected SwitchCaseDefault<int> _switchValInt = default;
        protected SwitchCaseDefault<long> _switchValLong = default;
        protected SwitchCaseDefault<byte> _switchValByte = default;
        protected SwitchCaseDefault<ushort> _switchValUshort = default;
        protected SwitchCaseDefault<uint> _switchValUint = default;
        protected SwitchCaseDefault<ulong> _switchValUlong = default;
        protected SwitchCaseDefault<char> _switchValChar = default;
        protected SwitchCaseDefault<float> _switchValFloat = default;
        protected SwitchCaseDefault<double> _switchValDouble = default;
        protected SwitchCaseDefault<decimal> _switchValDecimal = default;
        protected SwitchCaseDefault<bool> _switchValBool = default;
        protected SwitchCaseDefault<TypeCode> _switchValEnum = default;
        #endregion

        #region Reference Types
        protected SwitchCaseDefault<object> _switchRefObject = default;
        protected SwitchCaseDefault<string> _switchRefString = default;
        protected SwitchCaseDefault<string[]> _switchRefOneDimensionalArray = default;
        protected SwitchCaseDefault<string[][]> _switchRefTwoDimensionalArray = default;
        protected SwitchCaseDefault<string[,]> _switchRefMultiDimensionalArray = default;
        #endregion
    }
}

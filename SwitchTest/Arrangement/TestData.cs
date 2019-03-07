using SwitchFunc;
using System;

namespace SwitchTest
{
    public abstract class TestData
    {
        #region Value Types
        public static SwitchCaseDefault<sbyte> _switchValSbyte = default;
        public static SwitchCaseDefault<short> _switchValShort = default;
        public static SwitchCaseDefault<int> _switchValInt = default;
        public static SwitchCaseDefault<long> _switchValLong = default;
        public static SwitchCaseDefault<byte> _switchValByte = default;
        public static SwitchCaseDefault<ushort> _switchValUshort = default;
        public static SwitchCaseDefault<uint> _switchValUint = default;
        public static SwitchCaseDefault<ulong> _switchValUlong = default;

        public static SwitchCaseDefault<char> _switchValChar = default;
        public static SwitchCaseDefault<float> _switchValFloat = default;
        public static SwitchCaseDefault<double> _switchValDouble = default;
        public static SwitchCaseDefault<decimal> _switchValDecimal = default;
        public static SwitchCaseDefault<bool> _switchValBool = default;
        public static SwitchCaseDefault<TypeCode> _switchValEnum = default;
        #endregion

        #region Reference Types
        public static SwitchCaseDefault<object> _switchRefObject = default;
        public static SwitchCaseDefault<string> _switchRefString = default;
        public static SwitchCaseDefault<string[]> _switchRefOneDimensionalArray = default;
        public static SwitchCaseDefault<string[,]> _switchRefTwoDimensionalArray = default;
        public static SwitchCaseDefault<string[,,]> _switchRefThreeDimensionalArray = default;
        public static SwitchCaseDefault<string[][]> _switchRefJaggedArray = default;
        public static SwitchCaseDefault<string[,][]> _switchRefJaggedFirstArray = default;
        public static SwitchCaseDefault<string[][,]> _switchRefJaggedSecondArray = default;
        #endregion
    }
}

namespace SwitchTest
{
    public abstract class Constants
    {
        #region Enum constant values
        internal enum SbyteConst : sbyte { SBYTE1 = default, SBYTE2 = sbyte.MinValue, SBYTE3 = sbyte.MaxValue }
        internal enum ShortConst : short { SHORT1 = default, SHORT2 = short.MinValue, SHORT3 = short.MaxValue }
        internal enum IntConst : int { INT1 = default, INT2 = int.MinValue, INT3 = int.MaxValue }
        internal enum LongConst : long { LONG1 = default, LONG2 = long.MinValue, LONG3 = long.MaxValue }
        internal enum ByteConst : byte { BYTE1 = default, BYTE2 = byte.MinValue, BYTE3 = byte.MaxValue }
        internal enum UshortConst : ushort { USHORT1 = default, USHORT2 = ushort.MinValue, USHORT3 = ushort.MaxValue }
        internal enum UintConst : uint { UINT1 = default, UINT2 = uint.MinValue, UINT3 = uint.MaxValue }
        internal enum UlongConst : ulong { ULONG1 = default, ULONG2 = ulong.MinValue, ULONG3 = ulong.MaxValue }
        #endregion

        #region Struct constant values
        internal struct CharConst
        {
            internal const char CHAR1 = default;
            internal const char CHAR2 = char.MinValue;
            internal const char CHAR3 = char.MaxValue;
        }

        internal struct FloatConst
        {
            internal const float FLOAT1 = default;
            internal const float FLOAT2 = float.MinValue;
            internal const float FLOAT3 = float.Epsilon;
            internal const float FLOAT4 = float.MaxValue;
            internal const float FLOAT5 = float.PositiveInfinity;
            internal const float FLOAT6 = float.NegativeInfinity;
            internal const float FLOAT7 = float.NaN;
        }

        internal struct DoubleConst
        {
            internal const double DOUBLE1 = default;
            internal const double DOUBLE2 = double.MinValue;
            internal const double DOUBLE3 = double.MaxValue;
            internal const double DOUBLE4 = double.Epsilon;
            internal const double DOUBLE5 = double.NegativeInfinity;
            internal const double DOUBLE6 = double.PositiveInfinity;
            internal const double DOUBLE7 = double.NaN;
        }

        internal struct DecimalConst
        {
            internal const decimal DECIMAL1 = default;
            internal const decimal DECIMAL2 = decimal.MinValue;
            internal const decimal DECIMAL3 = decimal.MinusOne;
            internal const decimal DECIMAL4 = decimal.MaxValue;
            internal const decimal DECIMAL5 = decimal.One;
            internal const decimal DECIMAL6 = decimal.Zero;
        }

        internal struct BooleanConst
        {
            internal const bool BOOL1 = default;
            internal const bool BOOL2 = !default(bool);
        }
        #endregion
    }
}

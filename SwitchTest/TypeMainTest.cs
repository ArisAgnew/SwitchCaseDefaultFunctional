using Xunit;
using Xunit.Abstractions;
using System;
using System.Linq;

using System.Collections.Immutable;

namespace SwitchTest
{
    public class TypeMainTest : TestData
    {
        private readonly ITestOutputHelper _output;
        public TypeMainTest(ITestOutputHelper output) => _output = output;

        #region Value Types Unit Tests
        [Theory]
        [InlineData(new sbyte[] { (sbyte)SbyteConst.SBYTE1, (sbyte)SbyteConst.SBYTE2, (sbyte)SbyteConst.SBYTE3 })]
        public void SbyteTest(in sbyte[] sbyteArray)
        {
            _switchValSbyte = sbyteArray
                .Concat(new sbyte[] { -23, 23 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<sbyte>()
                .FirstOrDefault();

            var type = _switchValSbyte
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(sbyte), _switchValSbyte.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(sbyte)));
            Assert.True(type.IsValueType);

            _switchValSbyte
                .CaseOf((sbyte)SbyteConst.SBYTE1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf((sbyte)SbyteConst.SBYTE2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf((sbyte)SbyteConst.SBYTE3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));

            /*_switchValSbyte
                .GetCaseValuesAsImmutableSortedSet()
                .SelectMany(l => ImmutableList.Create(l))
                .ToList()
                .ForEach(s => _output.WriteLine(s.ToString()));*/
        }

        [Theory]
        [InlineData(new short[] { (short)ShortConst.SHORT1, (short)ShortConst.SHORT2, (short)ShortConst.SHORT3 })]
        public void ShortTest(in short[] shortArray)
        {
            _switchValShort = shortArray
                .Concat(new short[] { -23000, 23000 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<short>()
                .FirstOrDefault();

            var type = _switchValShort
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(short), _switchValShort.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(short)));
            Assert.True(type.IsValueType);

            _switchValShort
                .CaseOf((short)ShortConst.SHORT1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf((short)ShortConst.SHORT2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf((short)ShortConst.SHORT3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new int[] { (int)IntConst.INT1, (int)IntConst.INT2, (int)IntConst.INT3 })]
        public void IntTest(in int[] intArray)
        {

        }

        [Theory]
        [InlineData(new long[] { (long)LongConst.LONG1, (long)LongConst.LONG2, (long)LongConst.LONG3 })]
        public void LongTest(in long[] longArray)
        {

        }

        [Theory]
        [InlineData(new byte[] { (byte)ByteConst.BYTE1, (byte)ByteConst.BYTE2, (byte)ByteConst.BYTE3 })]
        public void ByteTest(in byte[] byteArray)
        {

        }

        [Theory]
        [InlineData(new ushort[] { (ushort)UshortConst.USHORT1, (ushort)UshortConst.USHORT2, (ushort)UshortConst.USHORT3 })]
        public void UshortTest(in ushort[] ushortArray)
        {

        }

        [Theory]
        [InlineData(new uint[] { (uint)UintConst.UINT1, (uint)UintConst.UINT2, (uint)UintConst.UINT3 })]
        public void UintTest(in uint[] uintArray)
        {

        }

        [Theory]
        [InlineData(new ulong[] { (ulong)UlongConst.ULONG1, (ulong)UlongConst.ULONG2, (ulong)UlongConst.ULONG3 })]
        public void UlongTest(in ulong[] ulongArray)
        {

        }

        [Theory]
        [InlineData(new char[] { CharConst.CHAR1, CharConst.CHAR2, CharConst.CHAR3 })]
        public void CharTest(in char[] charArray)
        {
            _switchValChar = charArray
                .Concat(Enumerable.Range(0, char.MaxValue + 1)
                    .Select(i => (char)i)
                    .Where(c => !char.IsControl(c))
                    .ToArray())
                .OrderBy(z => Guid.NewGuid())
                .Cast<char>()
                .FirstOrDefault();

            var type = _switchValChar
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(char), _switchValChar.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(char)));
            Assert.True(type.IsValueType);

            _switchValChar
                .CaseOf(CharConst.CHAR1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf(CharConst.CHAR2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf(CharConst.CHAR3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new float[] {
            FloatConst.FLOAT1,
            FloatConst.FLOAT2,
            FloatConst.FLOAT3,
            FloatConst.FLOAT4,
            FloatConst.FLOAT5,
            FloatConst.FLOAT6,
            FloatConst.FLOAT7
        })]
        public void FloatTest(in float[] floatArray)
        {

        }

        [Theory]
        [InlineData(new double[] {
            DoubleConst.DOUBLE1,
            DoubleConst.DOUBLE2,
            DoubleConst.DOUBLE3,
            DoubleConst.DOUBLE4,
            DoubleConst.DOUBLE5,
            DoubleConst.DOUBLE6,
            DoubleConst.DOUBLE7
        })]
        public void DoubleTest(in double[] doubleArray)
        {

        }

        [Theory]
        [InlineData(default)]
        public void DecimalTest(in decimal[] decimalArray)
        {
            //todo
        }

        [Theory]
        [InlineData(new bool[] { BooleanConst.BOOL1, BooleanConst.BOOL2 })]
        public void BoolTest(in bool[] boolArray)
        {

        }

        [Theory]
        [InlineData(new TypeCode[] {
            TypeCode.Empty,
            TypeCode.Object,
            TypeCode.DBNull,
            TypeCode.Boolean,
            TypeCode.Char,
            TypeCode.SByte,
            TypeCode.Byte,
            TypeCode.Int16,
            TypeCode.UInt16,
            TypeCode.Int32,
            TypeCode.Int64,
            TypeCode.UInt64,
            TypeCode.Single,
            TypeCode.Double,
            TypeCode.Decimal,
            TypeCode.DateTime,
            TypeCode.String
        })]
        public void EnumTest(in TypeCode[] enumArray)
        {

        }

        #endregion

        #region Reference Types Unit Tests
        [Fact]
        public void StringTest()
        {
            _switchRefString = ImmutableList<string>.Empty
                .Add(string.Empty)
                .Add("USA")
                .Add("CANADA")
                .Add("AUSTRALIA")
                [new Random().Next(0, 3)];

            var type = _switchRefString
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();            

            Assert.StrictEqual(typeof(string), _switchRefString.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(String)));
            Assert.True(!type.IsValueType);
            Assert.False(type.IsValueType);                   

            _switchRefString

                .CaseOf("USA").Accomplish(v => _output.WriteLine($"First ref: {v}"))

                .CaseOf("CANADA").Accomplish(v => _output.WriteLine($"Second ref: {v}"))

                .CaseOf("AUSTRALIA").Accomplish(v => _output.WriteLine($"Third ref: {v}"))
                
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default ref: <{vDef}> <i.e. string.Empty>"));
        }
        #endregion
    }
}

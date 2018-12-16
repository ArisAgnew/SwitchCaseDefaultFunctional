using Xunit;
using Xunit.Abstractions;
using System;
using System.Linq;

using System.Collections.Immutable;

namespace SwitchTest
{
    #region Value Types Unit Tests
    public partial class TypeMainTest : TestData
    {
        private readonly ITestOutputHelper _output;
        public TypeMainTest(ITestOutputHelper output) => _output = output;
                
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
                .CaseOf((sbyte)SbyteConst.SBYTE1 + (-23), new Predicate<sbyte>(c => c > 0))
                .Accomplish(v => _output.WriteLine($"First value: {v}"))

                .CaseOf((sbyte)SbyteConst.SBYTE2, d => (long)d > 0) //test
                .Accomplish(v => _output.WriteLine($"Second value: {v}"))

                .CaseOf((sbyte)SbyteConst.SBYTE3)
                .Accomplish(v => _output.WriteLine($"Third value: {v}"))

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
            _switchValInt = intArray
                .Concat(new int[] { -2000000000, 2000000000 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<int>()
                .FirstOrDefault();

            var type = _switchValInt
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(int), _switchValInt.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(int)));
            Assert.True(type.IsValueType);

            _switchValInt
                .CaseOf((int)IntConst.INT1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf((int)IntConst.INT2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf((int)IntConst.INT3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new long[] { (long)LongConst.LONG1, (long)LongConst.LONG2, (long)LongConst.LONG3 })]
        public void LongTest(in long[] longArray)
        {
            _switchValLong = longArray
                .Concat(new long[] { -9000000000000000000, 9000000000000000000 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<long>()
                .FirstOrDefault();

            var type = _switchValLong
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(long), _switchValLong.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(long)));
            Assert.True(type.IsValueType);

            _switchValLong
                .CaseOf((long)LongConst.LONG1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf((long)LongConst.LONG2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf((long)LongConst.LONG3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new byte[] { (byte)ByteConst.BYTE1, (byte)ByteConst.BYTE2, (byte)ByteConst.BYTE3 })]
        public void ByteTest(in byte[] byteArray)
        {
            _switchValByte = byteArray
                .Concat(new byte[] { 1, 222 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<byte>()
                .FirstOrDefault();

            var type = _switchValByte
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(byte), _switchValByte.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(byte)));
            Assert.True(type.IsValueType);

            _switchValByte
                .CaseOf((byte)ByteConst.BYTE1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf((byte)ByteConst.BYTE2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf((byte)ByteConst.BYTE3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new ushort[] { (ushort)UshortConst.USHORT1, (ushort)UshortConst.USHORT2, (ushort)UshortConst.USHORT3 })]
        public void UshortTest(in ushort[] ushortArray)
        {
            _switchValUshort = ushortArray
                .Concat(new ushort[] { 1, 65000 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<ushort>()
                .FirstOrDefault();

            var type = _switchValUshort
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(ushort), _switchValUshort.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(ushort)));
            Assert.True(type.IsValueType);

            _switchValUshort
                .CaseOf((ushort)UshortConst.USHORT1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf((ushort)UshortConst.USHORT2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf((ushort)UshortConst.USHORT3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new uint[] { (uint)UintConst.UINT1, (uint)UintConst.UINT2, (uint)UintConst.UINT3 })]
        public void UintTest(in uint[] uintArray)
        {
            _switchValUint = uintArray
                .Concat(new uint[] { 1, 4000000000 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<uint>()
                .FirstOrDefault();

            var type = _switchValUint
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(uint), _switchValUint.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(uint)));
            Assert.True(type.IsValueType);

            _switchValUint
                .CaseOf((uint)UintConst.UINT1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf((uint)UintConst.UINT2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf((uint)UintConst.UINT3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new ulong[] { (ulong)UlongConst.ULONG1, (ulong)UlongConst.ULONG2, (ulong)UlongConst.ULONG3 })]
        public void UlongTest(in ulong[] ulongArray)
        {
            _switchValUlong = ulongArray
                .Concat(new ulong[] { 1, 18446744073709551615 - 1 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<ulong>()
                .FirstOrDefault();

            var type = _switchValUlong
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(ulong), _switchValUlong.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(ulong)));
            Assert.True(type.IsValueType);

            _switchValUlong
                .CaseOf((ulong)UlongConst.ULONG1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf((ulong)UlongConst.ULONG2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf((ulong)UlongConst.ULONG3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
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
            FloatConst.FLOAT4
        })]
        public void FloatTest(in float[] floatArray)
        {
            _switchValFloat= floatArray
                .Concat(new float[] { FloatConst.FLOAT5, FloatConst.FLOAT6, FloatConst.FLOAT7 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<float>()
                .FirstOrDefault();

            var type = _switchValFloat
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(float), _switchValFloat.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(float)));
            Assert.True(type.IsValueType);

            _switchValFloat
                .CaseOf(FloatConst.FLOAT1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf(FloatConst.FLOAT2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf(FloatConst.FLOAT3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .CaseOf(FloatConst.FLOAT4).Accomplish(v => _output.WriteLine($"Fourth value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new double[] {
            DoubleConst.DOUBLE1,
            DoubleConst.DOUBLE2,
            DoubleConst.DOUBLE3,
            DoubleConst.DOUBLE4
        })]
        public void DoubleTest(in double[] doubleArray)
        {
            _switchValDouble = doubleArray
                .Concat(new double[] { DoubleConst.DOUBLE5, DoubleConst.DOUBLE6, DoubleConst.DOUBLE7 })
                .OrderBy(z => Guid.NewGuid())
                .Cast<double>()
                .FirstOrDefault();

            var type = _switchValDouble
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(double), _switchValDouble.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(double)));
            Assert.True(type.IsValueType);

            _switchValDouble
                .CaseOf(DoubleConst.DOUBLE1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf(DoubleConst.DOUBLE2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf(DoubleConst.DOUBLE3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .CaseOf(DoubleConst.DOUBLE4).Accomplish(v => _output.WriteLine($"Fourth value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Fact]
        public void DecimalTest()
        {
            var decimalArrayMain = new decimal[] {
                DecimalConst.DECIMAL1,
                DecimalConst.DECIMAL2,
                DecimalConst.DECIMAL3
            };

            var decimalArrayExtra = new decimal[] {
                DecimalConst.DECIMAL4,
                DecimalConst.DECIMAL5,
                DecimalConst.DECIMAL6
            };

            _switchValDecimal = decimalArrayMain
                .Concat(decimalArrayExtra)
                .OrderBy(z => Guid.NewGuid())
                .Cast<decimal>()
                .FirstOrDefault();

            var type = _switchValDecimal
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(decimal), _switchValDecimal.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(decimal)));
            Assert.True(type.IsValueType);

            _switchValDecimal
                .CaseOf(DecimalConst.DECIMAL1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf(DecimalConst.DECIMAL2).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf(DecimalConst.DECIMAL3).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new bool[] { BooleanConst.BOOL1, BooleanConst.BOOL2 })]
        public void BoolTest(in bool[] boolArray)
        {
            _switchValBool = boolArray
                .OrderBy(z => Guid.NewGuid())
                .Cast<bool>()
                .FirstOrDefault();

            var type = _switchValBool
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(bool), _switchValBool.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(bool)));
            Assert.True(type.IsValueType);

            _switchValBool
                .CaseOf(BooleanConst.BOOL1).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }

        [Theory]
        [InlineData(new TypeCode[] {
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
            TypeCode.DateTime            
        })]
        public void EnumTest(in TypeCode[] enumArray)
        {
            _switchValEnum = enumArray
                .Concat(new TypeCode[] {
                    TypeCode.Empty,
                    TypeCode.Object,
                    TypeCode.DBNull,
                    TypeCode.String,
                    TypeCode.DateTime
                })
                .OrderBy(z => Guid.NewGuid())
                .Cast<TypeCode>()
                .FirstOrDefault();

            var type = _switchValEnum
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.StrictEqual(typeof(TypeCode), _switchValEnum.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(TypeCode)));
            Assert.True(type.IsValueType);

            _switchValEnum
                .CaseOf(TypeCode.Boolean).Accomplish(v => _output.WriteLine($"First value: {v}"))
                .CaseOf(TypeCode.Char).Accomplish(v => _output.WriteLine($"Second value: {v}"))
                .CaseOf(TypeCode.SByte).Accomplish(v => _output.WriteLine($"Third value: {v}"))
                .CaseOf(TypeCode.Byte).Accomplish(v => _output.WriteLine($"Fourth value: {v}"))
                .CaseOf(TypeCode.Int16).Accomplish(v => _output.WriteLine($"Fifth value: {v}"))
                .CaseOf(TypeCode.UInt16).Accomplish(v => _output.WriteLine($"Sixth value: {v}"))
                .CaseOf(TypeCode.Int32).Accomplish(v => _output.WriteLine($"Seventh value: {v}"))
                .CaseOf(TypeCode.Int64).Accomplish(v => _output.WriteLine($"Eighth value: {v}"))
                .CaseOf(TypeCode.UInt64).Accomplish(v => _output.WriteLine($"Ninth value: {v}"))
                .CaseOf(TypeCode.Single).Accomplish(v => _output.WriteLine($"Tenth value: {v}"))
                .CaseOf(TypeCode.Double).Accomplish(v => _output.WriteLine($"Eleventh value: {v}"))
                .CaseOf(TypeCode.Decimal).Accomplish(v => _output.WriteLine($"Twelfth value: {v}"))
                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default value: {vDef}"));
        }        
    }
    #endregion

    #region Reference Types Unit Tests
    public partial class TypeMainTest
    {
        [Fact]
        public void ObjectTest()
        {
            var objects = new object[] {
                new object(),
                (sbyte)SbyteConst.SBYTE2 | (sbyte)SbyteConst.SBYTE3,
                (short)ShortConst.SHORT2 | (short)ShortConst.SHORT3,
                (int)IntConst.INT2 | (int)IntConst.INT3,
                (long)LongConst.LONG2 | (long)LongConst.LONG3,
                (byte)ByteConst.BYTE2 | (byte)ByteConst.BYTE3,
                (ushort)UshortConst.USHORT2 | UshortConst.USHORT3,
                (uint)UintConst.UINT2 | (uint)UintConst.UINT3,
                (ulong)UlongConst.ULONG2 | (ulong)UlongConst.ULONG3,
                CharConst.CHAR2 | CharConst.CHAR3,
                FloatConst.FLOAT1,
                FloatConst.FLOAT2,
                FloatConst.FLOAT3,
                FloatConst.FLOAT4,
                FloatConst.FLOAT5,
                FloatConst.FLOAT6,
                FloatConst.FLOAT7,
                DoubleConst.DOUBLE1,
                DoubleConst.DOUBLE2,
                DoubleConst.DOUBLE3,
                DoubleConst.DOUBLE4,
                DoubleConst.DOUBLE5,
                DoubleConst.DOUBLE6,
                DoubleConst.DOUBLE7,
                DecimalConst.DECIMAL1,
                DecimalConst.DECIMAL2,
                DecimalConst.DECIMAL3,
                DecimalConst.DECIMAL4,
                DecimalConst.DECIMAL5,
                DecimalConst.DECIMAL6,
                BooleanConst.BOOL1,
                BooleanConst.BOOL2                
            };
            //todo: end up the array
            var extraObjects = new object[] {
                new string(new ReadOnlySpan<char>("CAESAR".ToCharArray())),
                new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } },
                new int[][,] {
                    new int[,] { { 1, 2 }, { 3, 4 } },
                    new int[,] { { 1, 2 }, { 3, 6 } },
                    new int[,] { { 1, 2 }, { 3, 5 }, { 8, 13 } }
                },
            };

            _switchRefObject = objects
                .Concat(extraObjects)
                .OrderBy(z => Guid.NewGuid())
                .Cast<object>()
                .FirstOrDefault();

            var type = _switchRefObject
                .GetType()
                .GetGenericArguments()
                .SingleOrDefault();

            Assert.NotStrictEqual(typeof(object), _switchRefObject.SwitchValue.GetType());
            Assert.True(type.IsEquivalentTo(typeof(object)));
            Assert.True(!type.IsValueType);
            Assert.False(type.IsValueType);

            _switchRefObject
                .CaseOf(new object())
                .Accomplish(v => _output.WriteLine($"First ref (<new object()>): {v}"))

                .CaseOf(CharConst.CHAR2 | CharConst.CHAR3)
                .Accomplish(v => _output.WriteLine($"Second ref: {v}"))

                .CaseOf((ulong)UlongConst.ULONG2 | (ulong)UlongConst.ULONG3)
                .Accomplish(v => _output.WriteLine($"Third ref: {v}"))

                .CaseOf(DecimalConst.DECIMAL4)
                .Accomplish(v => _output.WriteLine($"Fourth ref: {v}"))

                .CaseOf(new string(new ReadOnlySpan<char>("CAESAR".ToCharArray())))
                .Accomplish(v => _output.WriteLine($"Fifrth ref: {v}"))

                .ChangeOverToDefault.Accomplish(vDef => _output.WriteLine($"Default ref: <{vDef}> <i.e. string.Empty>"));

            _output.WriteLine($"{nameof(_switchRefObject.SwitchValue)}: {_switchRefObject.SwitchValue}");
        }

        [Fact]
        public void StringTest()
        {
            _switchRefString = ImmutableList<string>.Empty
                .Add("GREAT BRITAIN")
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
        
        [Fact]
        public void StringOneDimentionalArrayTest()
        {

        }

        [Fact]
        public void StringTwoDimentionalArrayTest()
        {

        }

        [Fact]
        public void StringThreeDimentionalArrayTest()
        {

        }

        [Fact]
        public void StringJaggedArrayTest()
        {

        }
    }
    #endregion
}

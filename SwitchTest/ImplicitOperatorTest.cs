using SwitchFunc;

using SwitchTest.Arrangement;

using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using Xunit.Abstractions;

using static SwitchTest.Constants;

namespace SwitchTest
{
    public class ImplicitOperatorTest
    {
        private readonly ITestOutputHelper _output = default;
        private readonly object[] _data = default;

        private static SwitchCaseDefault<object> _plainValue = SwitchCaseDefault<object>.EMPTY;
        
        public ImplicitOperatorTest(ITestOutputHelper output)
        {
            _output = output;
            _data = new object[] {
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
                BooleanConst.BOOL2,
                null,
                default
            };
        }

        [Fact]
        public void PlainValueOughtToBeInitializedTest()
        {
            Assert.All(_data, item => {
                _plainValue = item;

                Assert.NotNull(_plainValue);
                Assert.NotSame(_plainValue, item);
            });
        }

        [Fact]
        public void CastedSupplierOughtToBeInitializedTest()
        {
            Assert.All(_data, item => {
                _plainValue = (Func<object>)(() => item);

                Assert.NotNull(_plainValue);
                Assert.NotSame(_plainValue, item);
            });
        }

        [Fact]
        public void SupplierAsAnObjectOughtToBeInitializedTest()
        {
            Assert.All(_data, item => {
                _plainValue = new Func<object>(() => item);

                Assert.NotNull(_plainValue);
                Assert.NotSame(_plainValue, item);
            });
        }

        [Fact]
        public void ImplicitConversionTest()
        {
            ISet<object> __data = _data.Where(d => d != null || d != default).ToHashSet();

            Assert.All(__data, item => {
                Assert.True(_plainValue.GetType().HasImplicitConversionWith(item.GetType()));
            });
        }
    }
}

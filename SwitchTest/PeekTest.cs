using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace SwitchTest
{
    public sealed class PeekTest
    {
        private readonly ITestOutputHelper _output = default;

        public PeekTest(ITestOutputHelper output) => _output = output;


    }
}

using SwitchFunc;
using Xunit;
using Xunit.Abstractions;

namespace SwitchTest
{
    public class DemoMisc
    {
        private readonly ITestOutputHelper _output;
        public DemoMisc(ITestOutputHelper output) => _output = output;

        [Fact]
        public void Demo1()
        {
            SwitchCaseDefault<int> _switch = 65536;
            dynamic output = default; // there is no needful to use it, use GetCustomized() instead

            _switch
                .CaseOf(1).Accomplish(() => { })
                .CaseOf(int.MaxValue).Accomplish(v => output = v)
                .CaseOf(12).Accomplish(v => output = v)
                .CaseOf(-12).Accomplish(v => output = v)
                .CaseOf(65536).Accomplish(v => output = v)
                .ChangeOverToDefault.Accomplish(v => output = v);

            _output.WriteLine(output.ToString()); // there is no needful to use it, use GetCustomized() instead
            _output.WriteLine(_switch.GetSwitchCustomized(i => i).ToString());
            _output.WriteLine(_switch.GetSwitch().ToString());

            //============================================================

            SwitchCaseDefault<string> _switch1 = "something";

            _switch1
                .CaseOf("some").Accomplish(v => output = v)
                .CaseOf("something1").Accomplish(v => output = v)
                .ChangeOverToDefault.Accomplish(v => output = v);

            _output.WriteLine(output.ToString());
            _output.WriteLine(_switch1.GetCaseCustomized(s => s));
            _output.WriteLine(_switch1.GetSwitch().ToString());
        }
    }
}

using System.Diagnostics;

namespace Array.Tests
{
    [DebuggerDisplay("Size:{ArraySize},Diff:{AllDifferent},Sum:{SumToZero}")]
    class TestResult
    {
        public bool AllDifferent { get; set; }
        public bool SumToZero { get; set; }
        public int ArraySize { get; set; }
        public int[] Array { get; set; }
        public int ExpectedSize { get; set; }
    }
}

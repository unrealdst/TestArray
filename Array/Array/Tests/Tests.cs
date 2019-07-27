using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Array.Tests
{
    [TestClass]
    public class Tests
    {
        Func<TestResult, string> PrintFailMessage => x => $"Size: {x.ExpectedSize}{Environment.NewLine}{String.Join(", ", x.Array)}{Environment.NewLine}";

        [TestMethod]
        public void TestArray()
        {
            int testFrom = 1, testTo = 1000;
            var testResults = new List<TestResult>();
            var generator = new ArrayGenerator();

            for (int i = testFrom; i < testTo; i++)
            {
                int[] result = generator.Generate(i);

                testResults.Add(CheckResult(result, i));
            }

            Assert.IsTrue(testResults.All(x => x.ArraySize == x.ExpectedSize), CreateFailMessage(testResults, "ExpectedSize", x => x.ArraySize != x.ExpectedSize));
            Assert.IsTrue(testResults.All(x => x.SumToZero), CreateFailMessage(testResults, "SumToZero", x => !x.SumToZero));
            Assert.IsTrue(testResults.All(x => x.AllDifferent), CreateFailMessage(testResults, "AllDifferent", x => !x.AllDifferent));
        }

        private string CreateFailMessage(List<TestResult> testResults, string testName, Func<TestResult, bool> findFallingTests)
        {
            return $"{Environment.NewLine}{testName}{Environment.NewLine}{String.Join(Environment.NewLine, testResults.Where(findFallingTests).Select(PrintFailMessage))}";
        }

        private TestResult CheckResult(int[] result, int expected)
        {
            return new TestResult()
            {
                AllDifferent = result.Distinct().Count() == result.Count(),
                SumToZero = result.Sum() == 0,
                ArraySize = result.Count(),
                Array = result,
                ExpectedSize = expected
            };
        }
    }
}

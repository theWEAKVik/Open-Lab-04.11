using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Open_Lab_04._11
{
    [TestFixture]
    public class Tests
    {

        private StringTools tools;
        private bool shouldStop;

        private const int RandStrMinSize = 1;
        private const int RandStrMaxSize = 100;
        private const int RandSeed = 411411411;
        private const int RandTestCasesCount = 95;

        [OneTimeSetUp]
        public void Init()
        {
            tools = new StringTools();
            shouldStop = false;
        }

        [TearDown]
        public void TearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome;

            if (outcome == ResultState.Failure || outcome == ResultState.Error)
                shouldStop = true;
        }

        [TestCase("hello", "ehllo")]
        [TestCase("edabit", "abdeit")]
        [TestCase("hacker", "acehkr")]
        [TestCase("geek", "eegk")]
        [TestCase("javascript", "aacijprstv")]
        public void AlphabetSoupTest(string str, string expected) =>
            Assert.That(tools.AlphabetSoup(str), Is.EqualTo(expected));

        [TestCaseSource(nameof(GetRandom))]
        public void AlphabetSoupTestRandom(string str, string expected)
        {
            if (shouldStop)
                Assert.Ignore("Previous test failed!");

            AlphabetSoupTest(str, expected);
        }

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arr = new char[rand.Next(RandStrMinSize, RandStrMaxSize + 1)];

                for (var j = 0; j < arr.Length; j++)
                    arr[j] = (char) rand.Next('a', 'z' + 1);

                yield return new TestCaseData(new string(arr), new string(arr.OrderBy(ch => ch).ToArray()));
            }
        }

    }
}

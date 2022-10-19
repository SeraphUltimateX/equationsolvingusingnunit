using EquationSolving;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;
using System.Data;
using System.Formats.Asn1;
using System.Net;
using Microsoft.VisualBasic;
using static EquationSolving.QuadraticEquation;

namespace EquationSolvingTests
{
    [TestFixture]
    public class BaseTests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("Set up fixture");
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Tear down fixture");
        }
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Begin test");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("End of test");
        }

        [Test, Ignore("For demo only")]
        public void TestAssertions()
        {
            Assert.That(new double[] { 6, 2 }, Is.Ordered.Descending);
            Assert.That(new int[] { 1, 2, 1 }, Is.Not.Unique);
        }

        [Test, Sequential, Category("Should return correct roots")]
        public void TestSolveGivenRightArgumentsReturnsWell(
            [Values(4, 5, 1)] double a,
            [Values(8, 2, 0)] double b,
            [Values(3, 10, 0)] double c,
            [Values(new double[] { -1.5, -0.5 },
                    new double[] {},
                    new double[] { 0 })] double[] expected)
        {
            Assert.That(Solve(a, b, c), Is.EquivalentTo(expected));
        }

        [TestCase(0, 5, 9)]
        [TestCase(0, 5, 0)]
        public void TestSolveGivenWrongArgumentsThrowsException(double x, double y, double z)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { Solve(x, y, z); });
        }

        [TestCase(0, 5, 9), Category("a == 0 -> Should throw exception")]
        [TestCase(0, 5, 0), Category("a == 0 -> Should throw exception")]
        public void TestSolveGivenWrongArgumentsThrowsException2(double a, double b, double c)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { Solve(a, b, c); }, "Should have thrown {0}", nameof(ArgumentOutOfRangeException));
        }


        public struct Values
        {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }
            public double[] Roots { get; set; }
        }

        [Datapoints]
        private Values[] _values = new Values[]
    {
        new Values{A=20, B=10, C=0, Roots=new double[] { -1/2d, 0d} },
        new Values{A=10, B=0, C=2, Roots=new double[] { }},
        new Values{A=0, B=2, C=2, Roots=new double[] {1,1,1,1,0,0,0,0}},
    };

        [Theory]
        public void TestSolveInAllCases(Values values)
        {
            Assume.That(values.A, Is.Not.EqualTo(0));

            Assert.That(Solve(values.A, values.B, values.C), Is.EquivalentTo(values.Roots));
        }
    }

    [TestFixture]
    class PoShenLohTests
    {


        [TestCase(4, 8, 3, new double[] { -1.5, -0.5 })]
        [TestCase(1, 2, 1, new double[] { -1 })]
        [TestCase(9, -0, 9, new double[] { })]
        public void TestSolvePoShenLohGivenRightArgumentsReturnsWell(double a, double b, double c, double[] expected)
        {
            Assert.That(Solve_Po_Shen_Loh(a, b, c), Is.EquivalentTo(expected));
        }

        private static readonly object[][] Coefficients = new object[][]
        {
            new object[] {0d, 8d, 6565d},
            new object[] {0d, 9.215454d, -66662.1d },
            new object[] {0d, 0d, 0d },
            new object[] {0d, -35451515d, 69995965d}
        };

        [Test]
        public void TestSolvePoShenLohGivenWrongArgumentsThrowsException([ValueSource(nameof(Coefficients))] object[] coeffs)
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => { Solve_Po_Shen_Loh((double)coeffs[0], (double)coeffs[1], (double)coeffs[2]); });
            Assert.Catch<Exception>(() => { Solve_Po_Shen_Loh((double)coeffs[0], (double)coeffs[1], (double)coeffs[2]); });
            Assert.That(ex.Message, Does.Contain("quadratic term cannot be 0"));
        }

/*        private IEnumerable<int[]> GetTestData()
        {
            using (var csv = new CsvReader(new StreamReader("test-data.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    int data1 = int.Parse(csv[0]);
                    int data2 = int.Parse(csv[1]);
                    int expectedOutput = int.Parse(csv[2]);
                    yield return new[] { data1, data2, expectedOutput };
                }
            }
        }*/
    }
}
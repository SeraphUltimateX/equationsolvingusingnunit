using EquationSolving;
using System.Net;
using static EquationSolving.QuadraticEquation;

namespace EquationSolvingTests
{
    [TestFixture]
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        private static readonly double[][] Coefficients =
        {
           new double[] {0, 8, 6565},
           new double[] {0, 9.215454, -66662.1 },
           new double[] {0, 0, 0 },
           new double[] {0, -35451515, 69995965}
        };

        [Test]
        public void TestSolvePoShenLohGivenWrongArgumentsThrowsException([ValueSource(nameof(Coefficients))] double[] coeffs)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { Solve_Po_Shen_Loh(coeffs[0], coeffs[1], coeffs[2]); });
        }

        [Test]
        [TestCase(4, 8, 3, new double[] { -1.5, -0.5 })]
        [TestCase(1, 2, 1, new double[] { -1 })]
        [TestCase(9, -0, 9, new double[] { })]
        [TestCase(12, -50, 1, new double[] { 4.1465697338567, 0.020096932810009 })]
        public void TestSolvePoShenLohGivenRightArgumentsReturnsWell(double x, double y, double z, double[] expected)
        {
            Assert.That(Solve_Po_Shen_Loh(4, 8, 3), Is.EquivalentTo(new double[] { -1.5, -0.5 }));
        }

        [Test, Sequential]
        public void TestSolveGivenRightArgumentsReturnsWell(
            [Values(4, 5, 1)] double x,
            [Values(8, 2, 0)] double y,
            [Values(3, 10, 0)] double z,
            [Values(new double[] { -1.5, -0.5 },
                    new double[] {},
                    new double[] { 0 })] double[] expected) =>
            Assert.That(Solve(x, y, z), Is.EquivalentTo(expected));

        [Test]
        [TestCase(0, 5, 9)]
        [TestCase(0, 5, 0)]
        [TestCase(0, 0, 9)]
        [TestCase(0, 0, 0)]
        public void TestSolveGivenWrongArgumentsThrowsException(double x, double y, double z) => Assert.Throws<ArgumentOutOfRangeException>(() => { Solve(x, y, z); });


        /*[TestCaseSource]*/
        public class LinearEquationTests
        {
            [SetUp]
            public void Setup()
            {

            }
            [Test]
            [TestCase(1, -3, new double[] { 3 })]
            [TestCase(1, 5, new double[] { -5 })]
            public void LinearEquationSolveGivenWrongArguments(double a, double b, double[] expected)
            {
                Assert.That(LinearEquation.LinearEquationSolve(a, b), Is.EqualTo(expected));
            }

            [Test]
            [TestCase(0, 5)]
            [TestCase(1, 5)]
            [TestCase(0, 0)]
            public void LinearEquationSolveGivenWrongArgumentsThrowsException(double a, double b)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => { LinearEquation.LinearEquationSolve(a, b); });
            }
        }


        public class TestCase        {
            [SetUp]
            public void Setup()
            {

            }


            [Test, Sequential]//Test case 1
            public void TestSolvePTB3GivenRightArgumentsReturnsWell(
                [Values(1, 0, 1)] double x,
                [Values(1, 2, 0)] double y,
                [Values(-3, 0, 0)] double z,
                [Values(1, 2, 0)] double t,
                [Values(new [] {1, 0.41421356237282331, -2.414213562373142},
                    new double[] {0.0, -0.0,-0.0},
                    new double[] {0}
            )] double[] expected) => Assert.That(expected, Is.EquivalentTo(PTB3.SolvePT3(x, y, z, t)));

        }
    }
}



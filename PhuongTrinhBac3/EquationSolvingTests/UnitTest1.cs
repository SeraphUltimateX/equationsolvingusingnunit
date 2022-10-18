using Microsoft.VisualStudio.TestPlatform.TestHost;
using PhuongTrinhBac3;


namespace EquationSolvingTests
{
    public class Tests
    {
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
            )] double[] expected
                     
            )
        {
             {
                Assert.That(expected, Is.EquivalentTo(PTB3.SolvePT3(x, y, z, t)));
              }
        }   
    }
}




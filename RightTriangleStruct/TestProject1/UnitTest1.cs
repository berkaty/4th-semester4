
namespace TestProject1
{
    namespace RightTriangle.UnitTests
    {
        [TestFixture]
        public class RightTriangleTests
        {
            [Test]
            public void ConstructorTest()
            {
                var angle = new RightTriangle(-42, 18, 21);
                Assert.That(angle.Degrees, Is.EqualTo(-42));
                Assert.That(angle.Minutes, Is.EqualTo(18));
                Assert.That(angle.Seconds, Is.EqualTo(21));
            }
            [TestCase(-30)]
            [TestCase(75)]
            public void MinutesSet_NegativeOrBigValue_ArgumentException(int val)
            {
                var angle = new Angle();
                Assert.That(() => angle.Minutes = val, Throws.ArgumentException);
            }
            [TestCase(-30)]
            [TestCase(75)]
            public void SecondsSet_NegativeOrBigValue_ArgumentException(int val)
            {
                var angle = new Angle();
                Assert.That(() => angle.Seconds = val, Throws.ArgumentException);
            }
            [TestCase(15, 42, 18, 56538)]
            [TestCase(0, 0, 0, 0)]
            [TestCase(-15, 42, 18, -56538)]
            public void ValueInSecondsTest(
            int degrees, int minutes, int sceconds, int result)
            {
                var angle = new Angle(degrees, minutes, sceconds);
                Assert.That(angle.ValueInSeconds, Is.EqualTo(result));
            }
            [TestCase(15, 42, 18, "15°42'18\"")]
            [TestCase(0, 0, 0, "0°0'0\"")]
            [TestCase(-15, 42, 18, "-15°42'18\"")]
            public void ToStringTest(int degrees, int minutes, int sceconds, string result)
            {
                var angle = new Angle(degrees, minutes, sceconds);
                Assert.That(angle.ToString(), Is.EqualTo(result));
            }
            [TestCase(30, 30, true)]
            [TestCase(30, 15, false)]
            public void Equals_TwoAngles_ExpectedResult(
            int degrees1, int degrees2, bool result)
            {
                var angle1 = new Angle(degrees1, 0, 0);
                var angle2 = new Angle(degrees2, 0, 0);
                Assert.That(angle1.Equals(angle2), Is.EqualTo(result));
            }
            [Test]
            public void Equals_WrongArgument_ArgumentException()
            {
                var angle = new Angle();
                var smth = new object();
                Assert.That(() => angle.Equals(smth), Throws.ArgumentException);
            }
            [Test]
            public static void GetHashCodeTest()
            {
                var x = new Angle(45, 18, 31);
                var y = new Angle(45, 18, 31);
                var z = new Angle(-30, 45, 7);
                Assert.That(x.Equals(y), Is.True);
                Assert.That(x.Equals(z), Is.False);
            }
            [Test]
            public static void ComparisonTest()
            {
                var x = new Angle(45, 18, 31);
                var y = new Angle(45, 18, 31);
                var z = new Angle(-30, 45, 7);
                Assert.That(x == y, Is.True);
                Assert.That(x != y, Is.False);
                Assert.That(x == z, Is.False);
                Assert.That(x != z, Is.True);
            }
            [TestCase(30, 40, 50, 20, 30, 40, 51, 11, 30)]
            [TestCase(30, 40, 50, -20, 30, 40, 10, 10, 10)]
            [TestCase(-30, 40, 50, 20, 30, 40, -10, 10, 10)]
            [TestCase(30, 40, 50, 0, 0, 0, 30, 40, 50)]
            public void AdditionTest(
            int degrees1, int minutes1, int seconds1,
            int degrees2, int minutes2, int seconds2,
            int resultDegrees, int resultMinutes, int resultseconds)
            {
                var angle1 = new Angle(degrees1, minutes1, seconds1);
                var angle2 = new Angle(degrees2, minutes2, seconds2);
                var result = new Angle(resultDegrees, resultMinutes, resultseconds);
                Assert.That(angle1 + angle2, Is.EqualTo(result));
            }
            [TestCase(2, 31, 41, 51, 63, 23, 42)]
            [TestCase(0.5, 31, 41, 51, 15, 50, 56)]
            public void MultiplicationTest(double k,
            int degrees, int minutes, int seconds,
            int resultDegrees, int resultMinutes, int resultseconds)
            {
                var angle = new Angle(degrees, minutes, seconds);
                var result = new Angle(resultDegrees, resultMinutes, resultseconds);
                Assert.That(k * angle, Is.EqualTo(result));
            }
        }
    }
}
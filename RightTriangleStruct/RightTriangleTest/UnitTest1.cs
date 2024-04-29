namespace RightTriangleStruct.UnitTests
{
    [TestFixture]
    public class RightTriangleTests
    {
        [Test]
        public void ConstructorTest()
        {
            var righttriangle = new RightTriangle(8, 6);
            Assert.That(righttriangle.A, Is.EqualTo(8));
            Assert.That(righttriangle.B, Is.EqualTo(6));
        }
        [TestCase(-8)]
        [TestCase(0)]
        public void СathetusASet_NegativeOrZero_ArgumentException(double val)
        {
            var righttriangle = new RightTriangle();
            Assert.That(() => righttriangle.A = val, Throws.ArgumentException);
        }
        [TestCase(-8)]
        [TestCase(0)]
        public void СathetusBSet_NegativeOrZero_ArgumentException(double val)
        {
            var righttriangle = new RightTriangle();
            Assert.That(() => righttriangle.B = val, Throws.ArgumentException);
        }
        [TestCase(6, 8, 10)]
        [TestCase(3, 4, 5)]
        public void HypotenuseTest(double a, double b, double result)
        {
            var righttriangle = new RightTriangle(a, b);
            Assert.That(righttriangle.Hypotenuse, Is.EqualTo(result));
        }
        [TestCase(6, 8, "Прямоугольный треугольник с катетами 6 см и 8 см")]
        [TestCase(3,4, "Прямоугольный треугольник с катетами 3 см и 4 см")]
        public void ToStringTest(double a, double b, string result)
        {
            var righttriangle = new RightTriangle(a, b);
            Assert.That(righttriangle.ToString(), Is.EqualTo(result));
        }
        [TestCase(6, 6, true)]
        [TestCase(6, 8, false)]
        public void Equals_RightTriangles_ExpectedResult(double a1, double a2, bool result)
        {
            var righttriangle1 = new RightTriangle(a1, 6);
            var righttriangle2 = new RightTriangle(a2, 6);
            Assert.That(righttriangle1.Equals(righttriangle2), Is.EqualTo(result));
        }
        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var righttriangle = new RightTriangle();
            var smth = new object();
            Assert.That(() => righttriangle.Equals(smth), Throws.ArgumentException);
        }
        [Test]
        public static void GetHashCodeTest()
        {
            var x = new RightTriangle(6, 8);
            var y = new RightTriangle(6, 8);
            var z = new RightTriangle(3, 4);
            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }
        [Test]
        public static void ComparisonTest()
        {
            var x = new RightTriangle(6, 8);
            var y = new RightTriangle(6, 8);
            var z = new RightTriangle(3, 4);
            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }
        [TestCase(2, 3, 4, 6, 8)]
        [TestCase(0.5, 3, 4, 1.5, 2)]
        public void StretchingOrCompressionTest(double k,
        double a, double b, 
        double resultA, double resultB)
        {
            var righttriangle = new RightTriangle(a, b);
            var result = new RightTriangle(resultA, resultB);
            Assert.That(k * righttriangle, Is.EqualTo(result));
        }
    }
}
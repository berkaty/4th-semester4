using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangleStruct
{
    public struct RightTriangle
    {
        double a;
        public double A
        {
            get => a;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Значение длины катета должно быть положительным");
                a = value;
            }
        }
        double b;
        public double B
        {
            get => b;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Значение длины катета должно быть положительным");
                b = value;
            }
        }
        public double Hypotenuse
        {
            get => Math.Sqrt(A * A + B * B);
        }
        public RightTriangle(double a, double b) : this()
        {
            A = a; B = b;
        }
        public override string ToString() => $"Прямоугольный треугольник с катетами {A} см и {B} см";
        public override bool Equals(object obj)
        {
            if (obj is RightTriangle)
                return (A == ((RightTriangle)obj).A)&&(B == ((RightTriangle)obj).B);
            throw new ArgumentException("Объект для сравнения не является прямоугольным треугольником");
        }
        public override int GetHashCode() => Hypotenuse.GetHashCode();
        public static bool operator ==(RightTriangle x, RightTriangle y) => x.Equals(y);
        public static bool operator !=(RightTriangle x, RightTriangle y) => !x.Equals(y);
        public static RightTriangle operator *(double k, RightTriangle triangle) => new RightTriangle(triangle.A * k, triangle.B * k);
        
        
    }
}

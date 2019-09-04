using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTasks.Antal.Shapes
{
    public class TriangleByThreeSides : IAreaCalculator
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public TriangleByThreeSides(double a, double b, double c)
        {
            CheckArgument.GreaterThanZero(a, nameof(a));
            CheckArgument.GreaterThanZero(b, nameof(b));
            CheckArgument.GreaterThanZero(c, nameof(c));

            if (!IsTriangle(a, b, c))
                throw new ArgumentException("The sum of the lengths of any two sides of a triangle is greater than the length of the third side.");

            A = a;
            B = b;
            C = c;
        }

        public double CalculateArea()
        {
            var p = (A + B + C) / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        private bool IsTriangle(double a, double b, double c)
        {
            var sides = new[] { a, b, c };

            return Enumerable.Range(0, sides.Length).All(index => IsLessThanSumOfTheOthers(index));

            bool IsLessThanSumOfTheOthers(int index) =>
                sides.SkipAt(index).Sum() - sides[index] > Tolerance.Epsilon;
        }
    }
}

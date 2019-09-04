using System;
using System.Linq;

namespace InterviewTasks.Antal.Shapes
{
    public static class TriangleByThreeSidesExtensions
    {
        public static bool IsRectangular(this TriangleByThreeSides triangle)
        {
            CheckArgument.NotNull(triangle, nameof(triangle));

            var squares =
                new[] { triangle.A, triangle.B, triangle.C }
                .Select(i => Math.Pow(i, 2))
                .ToArray();

            return Enumerable.Range(0, squares.Length).Any(index => IsHypotenuse(index));

            bool IsHypotenuse(int index) =>
                Math.Abs(squares[index] - squares.SkipAt(index).Sum()) < Tolerance.Epsilon;
        }
    }
}

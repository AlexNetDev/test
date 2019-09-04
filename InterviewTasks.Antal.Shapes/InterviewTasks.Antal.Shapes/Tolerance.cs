using System;

namespace InterviewTasks.Antal.Shapes
{
    public static class Tolerance
    {
        public const double Epsilon = 10e-10;

        public static bool AreEqual(double a, double b) =>
            Math.Abs(a - b) < Epsilon;
    }
}

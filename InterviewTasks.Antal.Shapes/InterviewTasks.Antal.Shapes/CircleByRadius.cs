using System;

namespace InterviewTasks.Antal.Shapes
{
    public class CircleByRadius : IAreaCalculator
    {
        public double Radius { get; }

        public CircleByRadius(double radius)
        {
            CheckArgument.GreaterThanZero(radius, nameof(radius));
            Radius = radius;
        }

        public double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
    }
}

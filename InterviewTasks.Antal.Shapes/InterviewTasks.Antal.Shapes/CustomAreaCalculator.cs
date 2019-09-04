using System;
using System.Collections.Generic;

namespace InterviewTasks.Antal.Shapes
{
    public class CustomAreaCalculator : IAreaCalculator
    {
        private readonly double[] arguments;

        public IReadOnlyList<double> Arguments => arguments;
        public Func<double[], double> Formula { get; }

        public CustomAreaCalculator(Func<IReadOnlyList<double>, double> formula, double[] arguments)
        {
            CheckArgument.NotNull(formula, nameof(formula));
            CheckArgument.NotNull(arguments, nameof(arguments));

            this.arguments = new double[arguments.Length];
            Array.Copy(arguments, this.arguments, arguments.Length);
            Formula = formula;
        }

        public double CalculateArea() => Formula(arguments);
    }
}

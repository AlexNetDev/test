using System;

namespace InterviewTasks.Antal.Shapes
{
    internal static class CheckArgument
    {
        public static void GreaterThanZero(double param, string name)
        {
            if (param <= 0)
                throw new ArgumentException($"Argument '{name}' should be greater than '0'.");
        }

        public static void NotNull(object param, string name)
        {
            if (param == null)
                throw new ArgumentNullException($"Argument '{name}' can not be 'null'.");
        }
    }
}

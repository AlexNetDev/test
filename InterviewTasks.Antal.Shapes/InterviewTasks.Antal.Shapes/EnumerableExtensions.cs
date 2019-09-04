using System.Collections.Generic;

namespace InterviewTasks.Antal.Shapes
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> SkipAt<T>(this IEnumerable<T> collection, int index)
        {
            CheckArgument.NotNull(collection, nameof(collection));

            return collection.SkipAtImpl(index);
        }

        private static IEnumerable<T> SkipAtImpl<T>(this IEnumerable<T> collection, int index)
        {
            int i = 0;
            foreach (var item in collection)
                if (i++ != index)
                    yield return item;
        }
    }
}

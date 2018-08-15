namespace xBDD.Features 
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class Extension
    {
        public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            foreach (var item in enumerable)
            {
                await action(item);
            }
        }
    }
}
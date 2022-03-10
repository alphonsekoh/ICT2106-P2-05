using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Areas.Admin.Util
{
    public static class Utility
    {
        // Helper to mask names
        public static string MaskName(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3)
            {
                return value;
            }
            else if (value.Length <= 4)
            {
                return value.Substring(0, 2) +
                       new string('*', value.Length - 2);
            }
            else
            {
                return value.Substring(0, 2) +
                       new string('*', value.Length - 3) +
                       value[^1..];
            }
        }

        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }


        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
        {
            for (int i = 0; i < source.Count(); i += chunkSize)
            {
                yield return source.Skip(i).Take(chunkSize);
            }
        }

    }


}

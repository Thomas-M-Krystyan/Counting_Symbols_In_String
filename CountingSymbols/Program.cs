namespace CountingSymbols
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            const string textData = @"[SerializableAttribute] public class SortedDictionary<TKey, TValue> " +
                                    ": IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, " +
                                    "IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, " +
                                    "IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>";

            CountAlgorithm.Process(textData);  // Case sensitive mode (default: true)
        }
    }
}

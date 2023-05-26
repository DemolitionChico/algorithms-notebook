namespace AlgorithmsAndDataStructures.Algorithms.FisherYatesShuffle;

public static class Operators
{
    public static IEnumerator<T> BeginShuffle<T>(this IEnumerable<T> sequence) => new FisherYatesShuffle<T>(sequence);

    public static IEnumerable<T> Enumerate<T>(this IEnumerator<T> enumerator)
    {
        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
    }
}
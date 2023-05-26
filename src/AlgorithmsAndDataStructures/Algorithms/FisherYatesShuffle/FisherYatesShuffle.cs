using System.Collections;

namespace AlgorithmsAndDataStructures.Algorithms.FisherYatesShuffle;

public class FisherYatesShuffle<T> : IEnumerator<T>
{
    public FisherYatesShuffle(IEnumerable<T> sequence)
    {
        Data = sequence.ToArray();
    }

    public T Current => Data[Position];
    
    private T[] Data { get; }
    private Random RandomNumbers { get; } = new Random(Guid.NewGuid().GetHashCode());
    private int Position { get; set; } = -1;

    object? IEnumerator.Current => Current;
    
    public bool MoveNext()
    {
        if (Position >= Data.Length - 1)
            return false;
        int randomPos = RandomNumbers.Next(++Position, Data.Length);
        (Data[Position], Data[randomPos]) = (Data[randomPos], Data[Position]);
        return true;
    }

    public void Reset()
    {
        Position = -1;
    }

    public void Dispose()
    {
    }
}
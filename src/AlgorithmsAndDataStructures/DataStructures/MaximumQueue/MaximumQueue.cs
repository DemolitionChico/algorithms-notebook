using System.Collections;

namespace AlgorithmsAndDataStructures.DataStructures.MaximumQueue;

public class MaximumQueue<T> : IEnumerable<T>
{
    public MaximumQueue(IComparer<T> comparer)
    {
        _comparer = comparer;
    }

    public MaximumQueue()
        : this(Comparer<T>.Default)
    {
    }

    private IComparer<T> _comparer;
    private Stack<T> _input = new();
    private bool HasInput => _input.Count > 0;

    private T _inputMaximum = default;

    private T InputMaximum
    {
        get => HasInput ? _inputMaximum : throw new InvalidOperationException();
        set => _inputMaximum = value;
    }

    private Stack<(T value, T max)> _output = new();
    private bool HasOutput => _output.Count > 0;

    private T OutputMaximum => HasOutput ? _output.Peek().max : throw new InvalidOperationException();

    private T Greater(T a, T b) => _comparer.Compare(a, b) >= 0 ? a : b;

    private void PushToInput(T item)
    {
        InputMaximum = HasInput ? Greater(item, InputMaximum) : item;
        _input.Push(item);
    }

    private void EnsureHasOutput()
    {
        if (HasOutput)
        {
            return;
        }

        if (!HasInput)
        {
            throw new InvalidOperationException();
        }

        T max = _input.Pop();
        _output.Push((max, max));
        while (_input.TryPop(out T? item) && item is not null)
        {
            max = this.Greater(item, max);
            _output.Push((item, max));
        }
    }

    private T PopFromOutput()
    {
        EnsureHasOutput();
        return _output.Pop().value;
    }

    public T Maximum => !HasInput ? OutputMaximum
        : !HasOutput ? InputMaximum
        : Greater(InputMaximum, OutputMaximum);

    public int Count => _input.Count + _output.Count;

    public void Enqueue(T item) => PushToInput(item);

    public T Dequeue() => PopFromOutput();

    public T Peek()
    {
        EnsureHasOutput();
        return _output.Peek().value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        yield break;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
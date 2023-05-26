using AlgorithmsAndDataStructures.Algorithms.FisherYatesShuffle;

namespace AlgorithmsNotebookTests;

public class FisherYatesShuffleShould
{
    [Fact]
    public void ReturnDifferentSequence()
    {
        IEnumerable<int> sequence = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        IEnumerable<int> shuffledSequence1 = sequence.BeginShuffle().Enumerate();
        IEnumerable<int> shuffledSequence2 = sequence.BeginShuffle().Enumerate();

        Assert.NotEqual(sequence, shuffledSequence1);
        Assert.NotEqual(sequence, shuffledSequence2);
        Assert.NotEqual(shuffledSequence1, shuffledSequence2);
    }
}
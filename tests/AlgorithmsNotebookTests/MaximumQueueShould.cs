using AlgorithmsAndDataStructures.Algorithms.FisherYatesShuffle;
using AlgorithmsAndDataStructures.DataStructures.MaximumQueue;

namespace AlgorithmsNotebookTests;

public class MaximumQueueShould
{
    [Fact]
    public void ContainAllItemsInOrder()
    {
        IEnumerable<int> sequence = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var maximumQueue = new MaximumQueue<int>();

        foreach (var item in sequence)  
        {
            maximumQueue.Enqueue(item);
        }

        foreach (var item in sequence)
        {
            Assert.Equal(item, maximumQueue.Dequeue());
        }
    }
    
    [Fact]
    public void ReturnProperMaximum()
    {
        IList<int> sequence = new[] {1, 2, 3, 2, 3, 4, 1, 2, 5, 1, 2, 3};
        IList<int> properMax = new[] {1, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 5};

        var maximumQueue = new MaximumQueue<int>();

        for (int i = 0; i < sequence.Count(); i++)
        {
            maximumQueue.Enqueue(sequence[i]);
            
            Assert.Equal(maximumQueue.Maximum, properMax[i]);
        }
    }
    
    [Fact]
    public void PreserveProperMaximumWhileRemoving()
    {
        IList<int> sequence = new[]  {1, 2, 3, 2, 3, 4, 5, 2, 4, 1, 2, 3};
        IList<int> properMax = new[] {5, 5, 5, 5, 5, 5, 5, 4, 4, 3, 3, 3};

        var maximumQueue = new MaximumQueue<int>();
        foreach (var item in sequence)
        {
            maximumQueue.Enqueue(item);
        }

        for (int i = 0; i < sequence.Count; i++)
        {
            Assert.Equal(properMax[i], maximumQueue.Maximum);
            
            maximumQueue.Dequeue();
        }
    }
}
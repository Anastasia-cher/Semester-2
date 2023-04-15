namespace PriorityQueue.Tests;

public class Tests
{
    [Test]
    public void AfterAddingAnEntryTheQueueShouldNotBeEmpty()
    {
        var queue = new PriorityQueue<People>();

        queue.Enqueue(new People("Masha", 19));
        Assert.That(!queue.IsEmpty());
    }

    [Test]
    public void TheQueueShouldBeEmpty()
    {
        var queue = new PriorityQueue<People>();

        Assert.That(queue.IsEmpty());
    }

    [Test]
    public void DequeueFromAnEmptyQueueShouldThrowAnException()
    {
        var queue = new PriorityQueue<People>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Test]
    public void DequeueSouldReturnTheElementWithTheHighestPriority()
    {
        var queue = new PriorityQueue<People>();

        queue.Enqueue(new People("Masha", 21));
        queue.Enqueue(new People("Colya", 25));
        queue.Enqueue(new People("Nikita", 20));
        queue.Enqueue(new People("Anna", 18));
        var result = queue.Dequeue();

        Assert.That(result.Name, Is.EqualTo("Colya"));
    }

    [Test]
    public void DequeueShouldReturTheFirstOfTwoItemsWithTheSamePriority()
    {
        var queue = new PriorityQueue<People>();

        queue.Enqueue(new People("Nikita", 23));
        queue.Enqueue(new People("Masha", 18));
        queue.Enqueue(new People("Colya", 19));
        queue.Enqueue(new People("Anna", 23));
        var result = queue.Dequeue();

        Assert.That(result.Name, Is.EqualTo("Nikita"));
    }
}
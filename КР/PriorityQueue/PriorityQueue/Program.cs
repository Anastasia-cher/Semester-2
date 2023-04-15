using PriorityQueue;

var queue = new PriorityQueue<People>();
queue.Enqueue(new People("Masha", 23));
queue.Enqueue(new People("Colya", 19));
queue.Enqueue(new People("Anna", 18));
queue.Enqueue(new People("Nikita", 20));

while (queue.Entries.Count > 0)
{
    var person = queue.Dequeue();
    Console.WriteLine($"{person.Name}, {person.Priority}");
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue;

public sealed class People : IPriority
{
    public People(string name, int age)
    {
        Name = name;
        Priority = age;
    }

    /// <summary>
    /// Name of the person.
    /// </summary>
    public string Name;

    /// <summary>
    /// Age of the person.
    /// </summary>
    public int Priority { get; set; }
}

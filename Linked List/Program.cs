using Linked_List.Model;

using System;

namespace Linked_List
{
    internal static class Program
    {
        private static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.Add(1);
            list.Add(5);
            list.Add(17);
            list.Add(42);
            list.AddToHead(-69);
            list.InsertAfter(1, 2);

            list.Delete(17);

            Console.WriteLine(list.Contains(8));

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
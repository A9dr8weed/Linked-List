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

            CircularLinkedList<int> circularLinkedList = new CircularLinkedList<int>();

            circularLinkedList.Add(100);
            circularLinkedList.Add(200);
            circularLinkedList.Add(300);
            circularLinkedList.Add(400);
            circularLinkedList.InsertAfter(100, 2);
            circularLinkedList.AddToHead(0);

            circularLinkedList.Delete(200);

            Console.WriteLine(circularLinkedList.Contains(100));

            foreach (int item in circularLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
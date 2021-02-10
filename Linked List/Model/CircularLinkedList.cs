using System;
using System.Collections;
using System.Collections.Generic;

namespace Linked_List.Model
{
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// The first item in the list.
        /// </summary>
        private Item<T> Head;

        /// <summary>
        /// The last item in the list.
        /// </summary>
        private Item<T> Tail;

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        private int count;

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Create an empty list.
        /// </summary>
        public CircularLinkedList() => Clear();

        /// <summary>
        /// Add data to the end of the list.
        /// </summary>
        /// <param name="data"> Added data. </param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public void Add(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> item = new Item<T>(data);

            if (Head == null)
            {
                Head = item;
                Tail = item;
                Tail.Next = Head;
            }
            else
            {
                item.Next = Head;
                Tail.Next = item;
                Tail = item;
            }
            count++;
        }

        /// <summary>
        /// Delete the first occurrence of data in the list.
        /// </summary>
        /// <param name="data"> Data to be deleted. </param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public void Delete(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // The currently viewed item in the list.
            Item<T> current = Head;

            // The previous element of the list, before the viewed one.
            Item<T> previous = null;

            for (int i = 0; i < count; i++)
            {
                // If the node is in the middle or at the end.
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        // remove the current node, now previous refers not to current, but to current.Next
                        previous.Next = current.Next;

                        // If the node is last
                        if (current == Tail)
                        {
                            // change the tail variable
                            Tail = previous;
                        }
                    }
                    else if (count == 1) // if there is only one element in the list
                    {
                        Head = Tail = null;
                    }
                    else
                    {
                        Head = current.Next;
                        Tail.Next = current.Next;
                    }

                    count--;
                }

                previous = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Insert data after the desired value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                Item<T> current = Head;

                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        current.Next = new Item<T>(data)
                        {
                            Next = current.Next
                        };
                        count++;

                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Add data to the top of the list.
        /// </summary>
        /// <param name="data"></param>
        public void AddToHead(T data)
        {
            Item<T> item = new Item<T>(data);

            if (Head == null)
            {
                Head = item;
                Tail = item;
            }

            item.Next = Head;
            Tail.Next = item;
            Head = item;

            count++;
        }

        /// <summary>
        /// Check for element.
        /// </summary>
        /// <param name="data"> Data to be checked </param>
        /// <returns> String with message </returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public string Contains(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> current = Head;

            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(data))
                {
                    return $"Elements {data} is in the list.";
                }
                current = current.Next;
            }

            return $"Elements {data} is not in the list.";
        }

        /// <summary>
        /// Clear list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        /// <summary>
        /// Return an enumerator that iterates through all the elements in a linked list.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate over the collection. </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;

            for (int i = 0; i < count; i++)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Return an enumerator that iterates through the linked list.
        /// </summary>
        /// <returns> The IEnumerator used to traverse the collection. </returns>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }
}
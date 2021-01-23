using System;
using System.Collections;
using System.Collections.Generic;

namespace Linked_List.Model
{
    /// <summary>
    /// Single-linked list.
    /// </summary>
    public class LinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// The first item in the list.
        /// </summary>
        private Item<T> Head = null;

        /// <summary>
        /// The last item in the list.
        /// </summary>
        private Item<T> Tail = null;

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        public int Count
        {
            get => count;
        }

        /// <summary>
        /// Create an empty list.
        /// </summary>
        public LinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Add data to the end of the list.
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Create a new linked list item.
            Item<T> item = new Item<T>(data);

            // If the linked list is empty, then add the created element to the beginning,
            // otherwise add this element as the next one after the outermost element.
            if (Head == null)
            {
                Head = item;
            }
            else
            {
                Tail.Next = item;
            }

            // Install this element last.
            Tail = item;

            // We increase the counter of the number of elements.
            count++;
        }

        /// <summary>
        /// Delete the first occurrence of data in the list.
        /// </summary>
        /// <param name="data"> Data to be deleted. </param>
        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // The currently viewed item in the list.
            Item<T> current = Head;

            // The previous element of the list, before the viewed one.
            Item<T> previous = null;

            // We go through all the elements of the list until it is completed,
            // or until the element to be removed is found.
            while (current != null)
            {
                // If the data of the viewed element matches the deleted data,
                // then we delete the current element given its position in the chain.
                if (current.Data.Equals(data))
                {
                    // If the item is in the middle or at the end of the list, throw the current item out of the list.
                    // Otherwise, this is the first element of the list, throw out the first item from the list.
                    if (previous != null)
                    {
                        // Set the previous element's pointer to the next element from the current one.
                        previous.Next = current.Next;

                        // If it was the last element of the list, then change the pointer to the outermost element of the list.
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                    }
                    else
                    {
                        // Set the head element next.
                        Head = Head.Next;

                        // If the list is empty, then we also zero out the outermost element.
                        if (Head == null)
                        {
                            Tail = null;
                        }
                    }

                    // The item has been removed.
                    // Decrease the number of elements and exit the loop.
                    count--;
                    break;
                }

                // Move on to the next item in the list.
                previous = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Add data to the top of the list.
        /// </summary>
        /// <param name="data"></param>
        public void AddToHead(T data)
        {
            Head = new Item<T>(data)
            {
                Next = Head
            };

            count++;
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
        public IEnumerator<T> GetEnumerator()
        {
            // We iterate over all the elements of the linked list to be presented as a collection of elements.
            Item<T> current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Return an enumerator that iterates through the linked list.
        /// </summary>
        /// <returns> The IEnumerator used to traverse the collection. </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Just return the enumerator defined above.
            // This is required to implement the IEnumerable interface
            // to be able to iterate over the elements of the linked list with the foreach operation.
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
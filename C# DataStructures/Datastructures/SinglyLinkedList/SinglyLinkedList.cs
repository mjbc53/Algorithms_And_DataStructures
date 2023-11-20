using C__DataStructures.Datastructures.Shared.Base;
using C__DataStructures.Datastructures.Shared.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__DataStructures.Datastructures.SinglyLinkedList
{
   
    public class SinglyLinkedList<T> : BaseLinkedList<OneWayNode<T>>
    {
        public SinglyLinkedList()
        {
            Length = 0;
            Head = null;
        }

        public SinglyLinkedList(OneWayNode<T> item)
        {
            Length = 1;
            Head = item;
        }


        //public float this[int index] {
        //    get =>

        //}

        public override void Add(OneWayNode<T> item)
        {
            AddLast(item);
        }

        public override void AddLast(OneWayNode<T> item)
        {
            //If the list if empty and the head is null. Then we will set the head of the linked list
            //Else we will loop through the linked list and add to the end of it
            //Time Complexity: O(N)
            if (IsEmpty() || Head == null)
            {
                Head = item;
            }
            else
            {
                //set the place holder for the previous node
                OneWayNode<T>? prevNode = null;
                //set the place holder for the current node
                OneWayNode<T>? currentNode = Head;
                //Loop throught the nodes and get to the end of the list
                while (currentNode != null)
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }

                //set the previous nodes next pointer value
                prevNode.Next = item;
                //add to the length
                Length++;
            }
        }

        public override void AddFirst(OneWayNode<T> item)
        {
            //if the list is empty or if the header is null. Then we will set the head item
            //Else we will create a reference to the head value, then we will set the new head as the item passed in an we will set its next pointer
            if (IsEmpty() || Head == null)
            {
                Head = item;
            }
            else { 
                OneWayNode<T> currentHeadNode = Head;

                Head = item;

                item.Next = currentHeadNode;
            }

        }

        public override void Clear()
        {
            Length = 0;
            Head = null;
        }

        public override void Remove()
        {

        }

        public override void RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public override void RemoveLast()
        {
            if (IsEmpty() || Head == null)
            {
                throw new InvalidOperationException("The Linked list is currently empty. Please add a value to it before continuing.");
            }
            else if (Length == 1 && Head != null)
            {
                Head = null;
            }
            else {
                //Pseudo code.
                  // we need to travese through the list until we get to the second to last element.
                  //Once we get the the second to last element then we need to record that node. We will then need to use the node to remove the last node.

                //Set the placeholder for the prev value
                OneWayNode<T>? prevNode = null;
                //Set the place holder for the current value 
                OneWayNode<T>? currentNode = Head;
                int counter = 0;

                //This may be incorrect for getting the last node. Need to figure out a proper way of getting the last node without a counter
                while (counter != Length - 1) {
                    //This may not be needed
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }

                //Set the next node to null.
                prevNode.Next = null;
     

            }
        }

        public override bool RemoveItem(OneWayNode<T> iiem)
        {
            throw new NotImplementedException();
        }

        public override bool Contains(OneWayNode<T> item)
        {
            throw new NotImplementedException();
        }

        public override int IndexOf(OneWayNode<T> item)
        {
            throw new NotImplementedException();
        }

        public override bool IsEmpty()
        {
            //if the length is less than or equal to zero then we will return true, else it will return false.
            return Length <= 0;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}

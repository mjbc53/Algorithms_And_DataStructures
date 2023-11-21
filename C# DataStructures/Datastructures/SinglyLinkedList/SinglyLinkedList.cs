using C__DataStructures.Datastructures.Shared.Base;
using C__DataStructures.Datastructures.Shared.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__DataStructures.Datastructures.SinglyLinkedList
{
   
    public class SinglyLinkedList<T> : BaseLinkedList<OneWayNode<T>,T>
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
                Length++;
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
            //Call the remove last method.
            RemoveLast();
        }

        public override void RemoveFirst()
        {
            //If the list is empty and the head is null then we will throw an error
            if (IsEmpty() || Head == null)
            {
                //Throw error
                throw new InvalidOperationException("The linked list is currently empty. Please add a value ti it before continuing.");
            }
            //If the length is 1 and the head is not null then we will set the head to null and subtract from the length
            else if (Length == 1 && Head != null)
            {
                //Set the head to null
                Head = null;
                //Subtract from the list
                Length--;
            }
            //Else we will set the head to the current head's next node and subtract from the length
            else {
                //Set the head to the current heads next value
                Head = Head.Next;
                //Subtract from the length
                Length--;
            }
        }

        public override void RemoveLast()
        {
            //If the list is empty and the head is null then we will throw an error
            if (IsEmpty() || Head == null)
            {
                //Throw an error
                throw new InvalidOperationException("The Linked list is currently empty. Please add a value to it before continuing.");
            }
            //If the length is 1 and the head is not null then we will set the head to null and subtract from the length
            else if (Length == 1 && Head != null)
            {
                //Set the head to null
                Head = null;
                //Subtract from the length of the list
                Length--;
            }
            //Else traverse through the list, until we get to the end, keeping track of the value before the tail node.
            //Then set the second to last node next pointer to null
            else
            {
                //Set the placeholder for the prev value
                OneWayNode<T>? prevNode = null;
                //Set the place holder for the current value 
                OneWayNode<T>? currentNode = Head;

                //This may be incorrect for getting the last node. Need to figure out a proper way of getting the last node without a counter
                while (currentNode.Next != null)
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }

                //Set the next node to null.
                prevNode.Next = null;
                //Subtract from the length of the list
                Length--;
            }
        }

        public override void RemoveItem(T data)
        {
            //If the list is empty and the head is null then we will throw an error
            if (IsEmpty() || Head == null)
            {
                //Throw an error
                throw new InvalidOperationException("The Linked list is currently empty. Please add a value to it before continuing.");
            }
            //If the head data is equal to the data passed in and the length is greater then 1.
            //Then we will set the head to the current heads next node value as the current head matches the data passed.
            //Then we will subtract from the length
            else if (Head.Data.Equals(data) && Length > 1)
            {
                //Set the head to the next node
                Head = Head.Next;
                //Subtract from the length
                Length--;
            }
            //Else if the length is 1 and the head is not null. We will remove the head and subtract from the length
            else if (Length == 1 && Head != null)
            {
                //Set the head to null
                Head = null;
                //Subtract from the length
                Length--;
            }
            else
            {

                //Placeholder for the previous node
                OneWayNode<T>? prevNode = null;
                //Placeholder for the current node. We are skipping the first head node as we have already checked if the node was the node we wanted to remove
                OneWayNode<T>? currentNode = Head.Next;

                //Loop through the nodes until we find the node where the data equals the data passed in.
                //If we find the node with the same data as the data passed in then we will break from the loop.
                while (currentNode != null)
                {
                    if (currentNode.Data.Equals(data))
                    {
                        break;
                    }
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }

                //Double check that the current nodes data equals the data passed in.
                //If it does then we will remove the node where the data matches and we will subtract from the length.
                if (currentNode.Data.Equals(data)) { 
                    prevNode.Next = currentNode.Next;
                    Length--;
                }
            }
        }

        

        

        public override void Find(OneWayNode<T> item)
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

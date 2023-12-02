using C__DataStructures.Datastructures.Shared.Base;
using C__DataStructures.Datastructures.Shared.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
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
        public override OneWayNode<T> this[int index] { 
            get {

                if (index > Length - 1 || index < 0|| IsEmpty()) { 
                    throw new IndexOutOfRangeException("Out of range. Index is two large or two small.");
                }

                var toReturn = Head;

                for (int i = 0; i <= index; i++) {
                    toReturn = toReturn.Next;
                }

                if (toReturn == null) {
                    throw new NullReferenceException("Incountered a null reference issue while tring to retrive the item by the index");
                }

                return toReturn;
            }
        }

        public override void Add(OneWayNode<T> item)
        {
            AddLast(item);
        }

        protected internal override void AddLast(OneWayNode<T> item)
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
            //set the length to zero
            Length = 0;
            //clear the header which will drop all of the values on the linked list.
            Head = null;
            
        }

        public override OneWayNode<T>? Remove(OneWayNode<T> item)
        {
            //Call the protected method to remove the items and return the removed item
           return RemoveItem(item);
        }

        public override OneWayNode<T> RemoveFirst()
        {
            //Check if the list is empty. If it is throw an error
            if (IsEmpty() || Head == null)
            {
                throw new InvalidOperationException("The Linked list is currently empty. Please add a value to it before continuing.");
            }
            //else clear out the head node
            else {
                //Set a placeholder var for the head to return
                var headPlaceHolder = Head;
                //Clear the head node.
                Head = Head.Next;
                //subtract from the length.
                Length--;
                //Return the placeholder
                return headPlaceHolder;
            }
        }

        public override OneWayNode<T> RemoveLast()
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
                //Create a place holder for the current head value.
                var headPlaceHolder = Head;

                //Set the head to null
                Head = Head.Next;

                //Subtract from the length
                Length--;

                //Return the head placeholder.
                return headPlaceHolder;
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
     
                return prevNode;
            }
        }
        protected internal override OneWayNode<T>? RemoveItem(OneWayNode<T> item)
        {
            //Check if the list is empty or null. If it is then throw an error
            if (IsEmpty() || Head == null)
            {
                throw new InvalidOperationException("The Linked list is currently empty. Please add a value to it before continuing.");
            }
            //Check if the lenght of the list is one, the head is not null and the head data matches the 
            else if (Head != null && Comparer<T>.Default.Compare(item.Data, Head.Data) >= 0)
            {
                //Set a placeholder for the head value
                var headPlaceHolder = Head;
                //Change the head to is next value. This will either be the next node or null.
                Head = Head.Next;
                //Subtract from the length 
                Length--;
                //return the palceholder
                return headPlaceHolder;
            }
            else {

                //Set the placeholder for the prev value
                OneWayNode<T>? prevNode = null;
                //Set the place holder for the current value 
                OneWayNode<T>? currentNode = Head.Next;

                //Loop though until we find the node we are looking for or until the currentnode is null
                while (currentNode != null) {
                    //Break from the while loop early if we find the item we are looking for
                    if (Comparer<T>.Default.Compare(item.Data, currentNode.Data) >= 0) {
                        break;
                    }

                    //Set the prev node to the current node
                    prevNode = currentNode;
                    //Set the current node to the current nodes next node
                    currentNode = currentNode.Next;
                }

                //If the the current node is null then throw an error
                if (currentNode == null) {
                    throw new ArgumentException("Invalid item pass to this method to remove. No item was found to remove");
                }

                //Set the prev nodes next node to the node to removes next node
                prevNode.Next = currentNode.Next;

                //Subtract from the length
                Length--;

                //return the current node.
                return currentNode;
            }
        }

        public override bool Contains(OneWayNode<T> item)
        {
            if (IsEmpty() || Head == null)
            {
                throw new InvalidOperationException("The Linked list is currently empty. Please add a value to it before continuing.");
            }
            else {
                for (int index = 0; index <= Length - 1; index++) {
                    if (Comparer<T>.Default.Compare(item.Data, this[index].Data) >= 0) {
                        return true;
                    }
                }    
                return false;
            }
            
        }

        public override int IndexOf(OneWayNode<T> item)
        {

            if (IsEmpty() || Head == null)
            {
                throw new InvalidOperationException("The Linked list is currently empty. Please add a value to it before continuing.");
            }
            else
            {
                for (int index = 0; index <= Length - 1; index++)
                {
                    if (Comparer<T>.Default.Compare(item.Data, this[index].Data) >= 0)
                    {
                        return index;
                    }
                }
               return -1;
            }
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

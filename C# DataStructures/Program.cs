using C__DataStructures.Datastructures.Shared.Nodes;
using C__DataStructures.Datastructures.SinglyLinkedList;

var list = new SinglyLinkedList<int>();

var itemToRemove = new OneWayNode<int>(3);

list.Add(new OneWayNode<int>(1));
list.Add(new OneWayNode<int>(2));
list.Add(new OneWayNode<int>(3));
list.Add(new OneWayNode<int>(4));

list.RemoveItem(itemToRemove);
list.RemoveLast();
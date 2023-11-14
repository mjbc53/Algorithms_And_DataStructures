from typing import Generic
from typing import TypeVar

#None is null in python

T = TypeVar("T")

#Define the node class 
class Node(Generic[T]):
  def  __init__ (self, data: T):
    self.data = data
    self.nxt  = None

  
 

class SinglyLinkedList:
  # A singly linked list uses a single pointer to reference the
  # Next node
  def __init__(self) -> None:
    self.size: int = 0
    self.head: Node = None
    self.tail: Node = None

  #Indexer for the singly linked list
  def __getitem__ (self, index: int) -> Node:
    #Base case to check if the index is larger then the size of the singly
    #linked list or if the list is empty
    if(index > self.size - 1 or self.isEmpty()):
        raise Exception("Out of range")
      
    #Set the current item to the head   
    currentItem = self.head
    #Loop over the singly linked list using a range from the index
    for n in range(index):
      #Set the current item
      currentItem = currentItem.nxt
    
    #Set the currentItem
    return currentItem
  
  #ToString handling
  def __str__(self):
    #Set the output we will be adding to
    output = "["

    # Get the current item
    currentItem = self.head

    #Loop through the list using a range from the current size of the singly
    #linked list
    for n in range(self.size):
      #Add to the value to the output
      output += f"{currentItem.data}"
      #If the currentItems nxt node is not None then we will also add a comma 
      if(currentItem.nxt != None):
        output += ","
      #Set the current item
      currentItem = currentItem.nxt
    #Add the closing bracket to the string.
    output += "]"
    #Return the string
    return output

  # Add Element
  def add(self, item: Node) -> None:
    # Call the add last element method
    self.addLast(item)

  # Add Element to the end of the list
  def addLast(self, item: Node) -> None:
    #If the list is empty then we will set the head and tail values
    if(self.isEmpty()):
      self.head = item
      self.tail = item
    #Else set the tail's next value to the item passed in, then set the tail to
    #the item passed in 
    else:
      self.tail.nxt = item
      self.tail = item
    #Add to the size of the list
    self.size += 1

  # Add Element to the begin of the list
  def addFirst(self, item: Node) -> None:
    #If the list is empty then we will set the head and tail values
    if(self.isEmpty()):
      self.head = item
      self.tail = item
    #Else set the items, next value to the head then set the header to the item
    #passed in
    else:
      item.nxt = self.head
      self.head = item
    #Add to the size of the list
    self.size += 1

  # Remove the first value from the SinglyLinked List
  def removeFirst(self) -> None:
    #Set a header ref value for garbage collection if needed. This will be
    #handled behind the scene in python
    headRef = None # for garbage collection if needed.
    #If the singly linked list is empty then throw an exception 
    if(self.isEmpty()):
        raise Exception("This linked list is empty")
    #If we only have a single value then set the head and tail to null
    elif(self.size == 1):
      self.head = None
      self.tail = None
    #Else set the header to the headers next node
    else:
      self.head = self.head.nxt
    # subtract from the size
    self.size -= 1

  # Remove the last value from the Singlylinked List
  def removeLast(self) -> None:
    #If the signly linked list is empty then throw and exception
    if(self.isEmpty()):
        raise Exception("This linked list is empty")
    #If the singly linked list only has on value then set the head and tail to None
    elif(self.size == 1):
      self.head = None
      self.tail = None
    #Else iterate throught the singly linked list and set the nodes to remove
    #the last node
    else:
      #Set a tail ref incase we need to garbage collect.
      tailNodeRef = self.tail # For garbage collection if needed
      #Set a placeholder for the previous Node
      previousNode = None
      #Set the current value we are looping over
      currentNode = self.head

      #Loop though the until we find a currentItem where the next value is None
      while currentNode.nxt is not None:
        #Set the previousItem to the current item
        previousNode = currentNode
        #Set the currentItem to the next node
        currentNode = currentNode.nxt

    #Set the previousItems next node to None
    previousNode.nxt = None
    #Set the tail
    self.tail = previousNode
    #Subtract from the size
    self.size -= 1
      
  #Remove an item by the data of a node    
  def removeItem(self, data: T) -> None:
    #If the singly linked list is empty throw an exception
    if(self.isEmpty()):
      raise Exception("This linked list is empty")
    #If the head.data equals the data passed in then set the head to the current
    #heads next value
    elif(self.head.data == data):
      self.head = self.head.nxt
      self.size -= 1
      return
    
    #If the size is only a length of 1 then clear the head and tail
    elif(self.size == 1):
      self.head = None
      self.tail = None
    else:
      
      #Set the NodRef Placeholder for garbage collection
      nodeRef = None #for garbage collection
      #Set the previous for the previous node
      previousNode = None
      #Set the current node
      currentNode = self.head
      
      #Loop though the nodes until we get to a node that is none
      while currentNode is not None:
        #If the currentNode's data matches the data passed in then break the loop
        if(currentNode.data == data):
            break
        #Set the previous node to the current node
        previousNode = currentNode
        #Set the current node to the next node of the current node
        currentNode = currentNode.nxt
    #If the current node is none then we will return
    if(currentNode == None):
      return

    #Set the previous node's next node to the current node's next value    
    previousNode.nxt = currentNode.nxt
    #Subtract from the size of the singly linked list
    self.size -= 1
    

  #Check if the linked list is empty.
  def isEmpty(self) -> bool:
    #Return the bool value from the check
    return self.size == 0
  
  #Method to get the index
  def indexOf(self, data:T) -> int:
    # Set the index
    index = 0
    
    #Set the current item to the head value
    currentItem = self.head
    #Loop throught the items while the current items is not None
    while currentItem is not None:
      # If the current items data equals the data passed in then break from the loop
      if(currentItem.data == data):
        break
      # Set the current item to the next item the current item has a point to
      currentItem = currentItem.nxt
      # Increase the size of the index
      index += 1
    # If the index is larger then the size of the linked list then we will
    # return -1
    if(index > self.size):
      return -1
    # Else we will return the index
    else:
      return index
    
  #Method to check if the singly linked list contains a node with certain data
  def contains(self, data: T) -> bool:
    # Get the index of the data passed in. If the index returns -1 then we will
    # return false. Else we will return true 
    return self.indexOf(data) != -1

 
#Create list
list = SinglyLinkedList()
#Add values to the list
list.add(Node("Mon"))
list.add(Node("Tues"))
list.add(Node("Wed"))
list.add(Node("Thurs"))
list.add(Node("Fri"))
list.add(Node("Sat"))
list.add(Node("Sun"))


#Method Testing


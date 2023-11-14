

class Node:
  def __init__(self, data: int) -> None:
    self.data = data
    self.next = None
    self.prev = None

class DynamicLinkedList:
  
  def __init__(self) -> None:
    self.size = 0
    self.head: Node = None
    self.tail: Node = None
    self.iterCurrnet = None

  # Indexing
  def __getitem__ (self, index: int) -> None:
    if(index > self.size  - 1 or self.IsEmpty() ):
      raise Exception("Out Of Range")
    
    currentNode: self.head
    for n in range(index):
      currentNode = currentNode.next
    
    return currentNode

  #Define iterator
  def __iter__(self):
    self.iterCurrnet = self.head
    return self
    
  #Iterator
  def __next__(self):
    # If the iterCurrent is none then we will stop iteration
    if (self.iterCurrnet is None):
      self.iterCurrnet = None
      raise StopIteration
    # Else we will return the current node that is being iterated over and set
    # the next iteratable node
    else:
      item = self.iterCurrnet
      self.iterCurrnet = self.iterCurrnet.next
      return item
  

  def __str__(self) -> str:
    pass
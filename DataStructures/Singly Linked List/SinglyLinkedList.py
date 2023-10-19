from typing import optional
from typing import Generic
from typing import TypeVar

#None is null in python

T = TypeVar("T")

#Define the node class 
class Node(Generic[T]):
  def  __init__ (self, data: T):
    self.data = data
    self.nxt  = None

  @property
  def data(self) -> T:
    return self.data
  
  @property
  def next(self) -> 'Node':
    return self.node
  
 

class SinglyLinkedList:
  # A singly linked list uses a single pointer to reference the
  # Next node
  def __init__(self) -> None:
    self.size: int = 0
    self.head: Node = None
    self.tail: Node = None

  def add(item: Node) -> None:
    if(self.isEmpty()):
      header = Node
      tail = Node
    else:
      tail.nxt = Node

  def isEmpty() -> bool:
    return self.size == 0

  pass
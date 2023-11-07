from typing import Generic
from typing import TypeVar

T = TypeVar("T")

# Need documentation on methods that have been created. 
# Need to complete all methods that are needed for using this array in the
# dynamic array. Some methods may need to be cleaned up or improved on. 

# something to look into: how we can create this static array without using
# pythons built in list methods. That would make this class more custom. If the
# numpy package is open source it may be good to look at how the array in the
# numpy is implemented.
class StaticArray(Generic[T]):

  def __init__(self, capacity:int) -> None:
    if(capacity == 0 or capacity is None):
      raise Exception("capacity must not be null or 0")
    self.length: int = 0
    self.capacity: int = capacity
    self.array = list()

  def __getitem__ (self, index:int) ->  T or None:
    if(index > self.length - 1 or self.isEmpty()):
        raise Exception("Out of Range")

    el = None
    for n in range(index):
      el = self.array[n]

    return el
  
  def __str__(self) -> str:
    output = "["

    counter = 0

    while(counter < self.length):
      if(counter == self.length - 1):
        output += f"{self.array[counter]}]"
      else:
        output += f"{self.array[counter]},"
      counter += 1
    return output
      
  
  def isEmpty (self) -> bool:
    return self.length == 0
  
  def add(self, item:T) -> None:
    if(self.length == self.capacity):
      raise Exception("Array is already at max capacity")
    
    self.array.insert(self.length ,item) 
    self.length += 1

  def removeAt(self, index:int) -> None:
    if(self.isEmpty()):
      raise Exception("Array is empty")
    elif (self.length < index):
      raise Exception("Out of Range")
    
    del self.array[index]

  def contains(self, item:T) -> bool:
    return self.find(item) != None

  def find(self,item:T) -> T or None:
    if(self.isEmpty()):
      raise Exception("Array is empty")

    el = None

    for n in range(self.length):
      if(arr[n] == item):
        el = arr[n]
    
    return el



arr = StaticArray(5)

arr.add(10)
arr.add(2)
arr.add(3)
arr.add(4)
arr.add(5)

print(arr[1])

print(arr.__str__())

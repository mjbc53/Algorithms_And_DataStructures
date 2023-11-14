from StaticArray import StaticArray
from typing import Generic
from typing import TypeVar

T = TypeVar("T")

# TODO: Need to complete testing on this dynamic
class DynamicArray(Generic[T]):

  # Constructor for dynamic array
  def __init__(self, initialCapacity: int or None = None) -> None:
    # define the base length
    self.length: int = 0
    # define the capacity of the static array
    if(initialCapacity is None):
      self.capacity: int = 5
    else:
        self.capacity: int = initialCapacity
    # create the static array 
    self.array: StaticArray = StaticArray(self.capacity)

  # set up the indexer for dynamic array
  def __getitem__ (self, index:int) -> T or None:
    # If the index passed it larger than the length or the array is empty then
    # we will return
    if(index > self.length -1 or self.array.isEmpty()):
        raise Exception("Out of range")

    # return element from array by index
    return self.array[index]

  #Set up the to string method
  # Time Complexity O(n)
  def __str__(self) -> str:
    # Return string value of array 
    return self.array.__str__()

  # Check if the array is empty
  def isEmpty(self) -> bool:
    # check if the length of the array if it zero or less then return true
    return self.length <= 0
  
  # Add to the dynamic array
  # Time Complexity O(n)
  def add(self, item:T) -> None:
    # Check if we add to the array again if it will be larger then the static
    # arrays capacity. It will be we will create a new static array and map all
    # of the old values to the new array. Then we will set the new array as the
    # dynamic array
    if(self.length + 1 > self.capacity):
      newArr = StaticArray(self.capacity * 2)
      for n in range(0,self.length):
        newArr.add(self.array[n])
      self.array = newArr
      self.capacity = self.capacity * 2
    
    # Add to the array
    self.array.add(item)
    # Add to the length of the array
    self.length += 1

  # Remove an item at a certain index
  # Time Complexity O(n)
  def removeAt(self, index:int) -> None:
    # Check if the array is empty and throw an error if it is
    if(self.isEmpty()):
      raise Exception("Array is empty")
    # Check if the index is large than the length of the dynamic array, if so
    # then throw an error
    elif(index > self.length -1):
      raise Exception("Out of range")

    # Call the remove at index static array methodd
    self.array.removeAt(index)
    # Subtract from the array
    self.length -= 1

  # Remove an certain item
  # Time Complexity O(n)
  def remove(self, item:T) -> None:
    # Check if the array is empty and throw an error if it is
    if(self.isEmpty()):
      raise Exception("Array is empty")

    # Remove item
    self.array.remove(item)
    # remove from the length
    self.length -= 1

  # Find a certain item in the array
  # Time Complexity O(n)
  def find(self, item:T) -> T or None:
     # Check if the array is empty and throw an error if it is
    if(self.isEmpty()):
      raise Exception("Array is empty")
    
    # Return the found element or null
    return self.array.find(item)
  
  # Find if the array contains a certain item
  # Time Complexity O(n)
  def contains(self, item:T) -> T:
     # Check if the array is empty and throw an error if it is
    if(self.isEmpty()):
      raise Exception("Array is empty")
    
    # Check it the array contains an element
    return self.array.contains(item)

  # Clear the array and set it back to the default
  def clear(self) -> None:
    # Set capacity back to 5
    self.capacity = 5
    # Set the length to 0
    self.length = 0
    # Set the array to a new static array
    self.array = StaticArray(self.capacity)

  # Find the index of an element
  # Time Complexity O(n)
  def indexOf(self,item:T) -> int:
    # Check if the array is empty and throw an error if it is
    if(self.isEmpty()):
      raise Exception("Array is empty")
    # Return the index of an item or -1 if not found
    return self.array.indexOf(item)

# Testing
# dyArr = DynamicArray()

# dyArr.add("a")
# dyArr.add("b")
# dyArr.add("c")
# dyArr.add("d")
# dyArr.add("e")
# dyArr.add("f")
# dyArr.add("g")

# print(dyArr.__str__())

# dyArr.remove("a")

# print(dyArr.__str__())


# print("index of b", dyArr.indexOf("b"))
# print("contains d", dyArr.contains("d"))
# print("find g", dyArr.find("g"))
from typing import Generic
from typing import TypeVar

T = TypeVar("T")

# something to look into: how we can create this static array without using
# pythons built in list methods. That would make this class more custom. If the
# numpy package is open source it may be good to look at how the array in the
# numpy is implemented.
class StaticArray(Generic[T]):

  # define the constructor
  def __init__(self, capacity:int) -> None:
    # if the capactiy is none or 0 then we will throw an error
    if(capacity == 0 or capacity is None):
      raise Exception("capacity must not be null or 0")
    # define the lenght
    self.length: int = 0
    # define the capacity
    self.capacity: int = capacity
    # created the base array
    self.array = list()

  #Set up the indexer for the static array
  # Time Complexity O(N)
  def __getitem__ (self, index:int) ->  T or None:
    # if the index is greater than the length or if the array is empty then we
    # will throw an error
    if(index > self.length - 1 or self.isEmpty()):
        raise Exception("Out of Range")

    # Set up the element that we will be returning
    el = None

    # Loop throught the array and find the element and return it
    for n in range(index + 1):
      # Set the element to return
      el = self.array[n]

    # Return the element
    return el
  
  # Set up the to string method
  # Time Complexity O(N)
  def __str__(self) -> str:
    # Set up the string output that we will be adding to
    output = "["

    # Loop through the range array and add each element to the string
    for n in range(self.length):
      # If n is the length the array - 1 then we add extra values to the end of
      # the string
      if(n == self.length - 1):
        output += f"{self.array[n]}]"
      # Else we will just add the data to the array
      else:
        output += f"{self.array[n]},"
    return output
  
  # Check if the array is empty
  def isEmpty (self) -> bool:
    # Check if the length is zero
    return self.length == 0
  
  # Add to the array 
  # Time Complexity O(1)
  def add(self, item:T) -> None:
    # Check if the lenght is the capacity. If it is then throw and error
    if(self.length == self.capacity):
      raise Exception("Array is already at max capacity")
    
    #Add the the array at the next index. This has to be done usign the insert
    #method in python. 
    self.array.insert(self.length, item) 
    # Add to the length of the static array
    self.length += 1

  # Remove a item at a certain index 
  # Time Complexity O(1)
  def removeAt(self, index:int) -> None:
    # Check if the array is empty. If it is empty throw an error 
    if(self.isEmpty()):
      raise Exception("Array is empty")
    # check if the index is greater than the length of the array if it is throw
    # and error
    elif (index > self.length - 1):
      raise Exception("Out of Range")
    # Deletet the element in the array
    del self.array[index]
    #Removed from the length
    self.length -= 1


  # Remove a item in the array by its value
  # Time Complexity O(N)
  def remove(self, item:T) -> None:
    # Check if the array is empty, if it is throw an error
    if(self.isEmpty()):
      raise Exception("Array is empty")
    
    # Get the index of the item
    index = self.indexOf(item)
    
    # if the index is -1 then we will throw an error as no element was found by
    # the indexof method.
    if(index == -1):
      raise Exception("Element does not exist in array")
    # Else we will delete the element at the index we found
    else:
      del self.array[index]
      #Removed from the length
      self.length -= 1

  # Check if a element is in the array
  # Time Complexity O(n)
  def contains(self, item:T) -> bool:
    # Call the find method. If it does not equal null then we will return true
    # else we will return false
    return self.find(item) != None

  # Find an element
  # Time Complexity O(n)
  def find(self,item:T) -> T or None:
    # Check the if the array is empty. If it is then we will throw and error
    if(self.isEmpty()):
      raise Exception("Array is empty")

    # Create a place holder for the element if we find it
    el = None

    # Loop through the array and look for the element we are looking for
    for n in range(0, self.length):
      # If the element equals the item we passed in then we will set the el placeholder
      if(self.array[n] == item):
        el = self.array[n]
    
    # Return the element
    return el
  
  # Clear the array
  def clear(self) -> None:
    self.array = list()
    self.length = 0

  # Look for the index of the array
  # Time Complexity O(n)
  def indexOf(self, item:T) -> int:
    # Check if the array is empty or not, if it is throw an error
    if(self.isEmpty()):
        raise Exception("Array is empty")
    
    # Create the index place holder
    index = None

    # Loop through the array and find the index of the element
    for n in range(0,self.length):
      # If the item matches the item at the index of n then we will set the index
      if(item is self.array[n]):
        index = n
    # If the index is null then we will return -1
    if(index is None ):
      return -1
    # return index if it is not none
    return index



#Testing
# arr = StaticArray(5)

# arr.add(10)
# arr.add(2)
# arr.add(3)
# arr.add(4)
# arr.add(5)

# print(arr[0])

# arr.remove(5)

# print(arr.__str__())
# print("Index of element 2 {0}",arr.indexOf(2))


# print("Find element 3 {0}", arr.find(3))
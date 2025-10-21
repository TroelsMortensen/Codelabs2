# Exercise 18 - Binary Data Exercises

This exercise will help you practice working with binary data, object serialization, and file I/O operations. You'll create several classes and learn how to save and load Java objects to/from binary files.

## Setup

Create a new package called `binaryexercises` in your project. All classes should be placed in this package.

## Exercise 18.1: MyData Class

Create a class called `MyData` with the following requirements:

### Requirements

- **Package**: `binaryexercises`
- **Implements**: `Serializable` interface
- **Fields**: Include various simple data types:
  - `String name`
  - `int age`
  - `double salary`
  - `boolean isActive`
  - `char grade`
- **Methods**: 
  - Constructor that takes all parameters
  - Getters and setters for all fields
  - `toString()` method that returns a formatted string

This class doesn't really represent anything, we just need it to practice writing and reading objects to and from a binary file.

### Class Diagram

Getters and setters are left out for brevity.

```mermaid
classDiagram
    class MyData {
        - name : String
        - age : int
        - salary : double
        - isActive : boolean
        - grade : char
        + MyData(name : String, age : int, salary : double, isActive : boolean, grade : char)
        + toString() String
    }
    
    Serializable ()-- MyData
```

### Example Output

```
MyData{name='John Doe', age=25, salary=50000.0, isActive=true, grade='A'}
```

## Exercise 18.2: Single Object Serialization

Create a class called `SingleObjectTest` with a main method that:

### Requirements

1. **Create an instance** of `MyData` with sample data
2. **Write the object** to a binary file called `mysingleobject.bin`
3. **Read the object back** from the file
4. **Print both objects** (original and retrieved)
5. **Compare the objects** using `==` and `.equals()`
6. **Discuss the results** in comments



### Expected Output

```
Original: MyData{name='Alice Smith', age=30, salary=75000.0, isActive=true, grade='B'}
Object written to file successfully!
Object read from file successfully!
Retrieved: MyData{name='Alice Smith', age=30, salary=75000.0, isActive=true, grade='B'}
Are they the same object (==): false
```

Now, why are they not the same object? Is it not the same we put into the file and loaded back? No, it is not. The object is serialized, and when it is read back from the file, it is a new object. The deserialization step creates a `new` object, and whenever the `new` operator is used, a new object is created.

This is why `==` returns false, and `.equals()` returns false as well (unless overridden).


## Exercise 18.3: ArrayList Serialization

Create a class called `ArrayListTest` with a main method that:

### Requirements

1. **Create an ArrayList** of `MyData` objects
2. **Add several MyData objects** to the list, at least, like.. maybe 3. Or 7 or so.
3. **Write the entire list** to a binary file called `mydatalist.bin`
4. **Read the list back** from the file
5. **Print the retrieved list**
6. **Compare the original and retrieved lists**


### Expected Output

Depending on how you choose to format the output, it may look like this:

```
Original list:
  MyData{name='John Doe', age=25, salary=50000.0, isActive=true, grade='A'}
  MyData{name='Jane Smith', age=30, salary=60000.0, isActive=false, grade='B'}
  MyData{name='Bob Johnson', age=35, salary=70000.0, isActive=true, grade='C'}
List written to file successfully!
List read from file successfully!
Retrieved list:
  MyData{name='John Doe', age=25, salary=50000.0, isActive=true, grade='A'}
  MyData{name='Jane Smith', age=30, salary=60000.0, isActive=false, grade='B'}
  MyData{name='Bob Johnson', age=35, salary=70000.0, isActive=true, grade='C'}
```

## Exercise 18.4: DataContainer Class

This time, we step up the game. Imagine in a larger application, you will have to save multiple kinds of objects. We can do this to a single file. But, we cannot write a list of `MyData` objects to a file, and a list of `MyOtherData` objects to a file. We need to write a _single object_ to the file, that contains both lists.

So, we create a container class, which will contain _all_ data for the application.


### Requirements

1. **Create MyOtherData class** with different field types:
   - `String description`
   - `int quantity`
   - `boolean isAvailable`
   - `double price`

2. **Create DataContainer class** with:
   - `List<MyData> myDataList`
   - `List<MyOtherData> myOtherDataList`
   - Constructor, getters, setters, toString

3. **Create ContainerTest class** with main method that:
   - Creates instances of both data types
   - Adds them to a DataContainer
   - Writes the container to a file
   - Reads it back and prints the results


### DataContainer Class

```java
package binaryexercises;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class DataContainer implements Serializable {
    private List<MyData> myDataList;
    private List<MyOtherData> myOtherDataList;
    
    public DataContainer() {
        this.myDataList = new ArrayList<>();
        this.myOtherDataList = new ArrayList<>();
    }
    
    // methods to add objects to the lists, and to retrieve the lists. 
    // no need to copy stuff
}
```

### Main method

Create a main method that:
- Creates several instances of both data types
- Adds them to a DataContainer
- Writes the container to a file
- Reads it back and prints the results

## Why Use DataContainer?

### Discussion Points

**Why do we need the DataContainer class instead of writing two separate lists?**

1. **Atomic Operations**: All data is saved/loaded together as one unit
2. **Data Integrity**: Ensures both lists are always in sync
3. **Single File**: One file contains all related data
4. **Easier Management**: One object to handle instead of multiple files
5. **Consistency**: If one list fails to save/load, the entire operation fails
6. **Relationship Preservation**: Maintains the relationship between the two data types

### But then the drawbacks

It is not all rainbows and unicorns. There are some drawbacks to this approach.
- **Performance**: Loading all data into memory at once can be slow.
- **Memory usage**: Loading all data into memory at once can use a lot of memory.
- **Data integrity**: If one list is corrupted, the entire operation fails.
- **Data consistency**: If one list is out of sync, the entire operation fails.
- **Data management**: If you have a lot of data, it is hard to manage.

So, this is not a good approach for large datasets. But it is a good approach for small datasets, which is what you will be doing in this course. And your semester project.


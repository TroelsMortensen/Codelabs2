# Adding elements to the List

On this page we will explore the `add(..)` method of the `ArrayList`, which allows us to add elements to the list.

Elements are automatically added to the end of the list, and the list will grow as needed to accommodate new elements.

I prefer to think of the list as initially having no available cells, and then as we add elements, the list will grow a new cell to accommodate them. This is not exactly how it works, but it is a good mental model.

In theory, the List can contain an infinite number of elements, but in practice, it is limited by the available memory of the system.

## Example 1: Adding elements to an ArrayList
```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> myList = new ArrayList<>();
        myList.add("Apple");
        myList.add("Banana");
        myList.add("Cherry");
    }
}
```



## Exercise 1: Adding Elements to a List

Write a program, which creates an ArrayList containing integers.

Then add 100 numbers to the list, starting from 1 up to 100.

At the end, you can print out the number of elements in the list, using the `size()` method of the ArrayList: `int listSize = myList.size();`.

## Growing and shrinking
Initially the ArrayList declares an array of size 10 to hold the elements. But as you add more elements, the ArrayList will automatically grow to accommodate them.

When the number of elements exceeds the current size of the array, the ArrayList will create a new array with a larger size (usually double the previous size), copy the existing elements to the new array, and then add the new element.

Similarly, if you remove elements from the list, the ArrayList may shrink the size of the underlying array to save memory, but this is not guaranteed to happen immediately after removing elements.

All this happens automatically behind the scenes, so you don't have to worry about managing the size of the array yourself. Did you do the last exercises from the array session? Remember how you had to manually copy the elements from one array to another, larger, array?

## Add at index
Using the above explained `add(..)` method, the element is always added to the end of the list.
For example, if the list has 3 elements:

| 0     | 1      | 2      |
|-------|--------|--------|
| Apple | Banana | Cherry |

And you add "Orange" at index 1, the list will look like this:

| 0     | 1      | 2      | 3      |
|-------|--------|--------|--------|
| Apple | Banana | Cherry | Orange |


But, sometimes you might want to add an element at a specific index in the list.

You can do this by using the `add(int index, E element)` method of the `ArrayList`.

## Example 2: Adding an element at a specific index

The following code snippet shows how to add an element at a specific index.

```java{11}
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> myList = new ArrayList<>();
        myList.add("Apple");
        myList.add("Banana");
        myList.add("Cherry");

        // Adding an element at a specific index
        myList.add(1, "Orange");

        // Print the list
        for (String fruit : myList) {
            System.out.println(fruit);
        }
    }
}
```

**Output:**
```
Apple
Orange
Banana
Cherry
```

Notice how "Orange" is added at index 1, shifting "Banana" and "Cherry" to the right.

The List can be shown before the addition like this:

| Index | 0     | 1      | 2      |
|-------|-------|--------|--------|
| Value | Apple | Banana | Cherry |

After adding "Orange" at index 1, the List looks like this:

| Index | 0     | 1      | 2      | 3      |
|-------|-------|--------|--------|--------|
| Value | Apple | **Orange** | Banana | Cherry |

All elements after the specified index are shifted to the right to make space for the new element.

## Exercise 2: Printing a list
The List's `toString()` method has a built in formatting method for printing the contents of the list.

Create a program that creates an ArrayList of strings, adds a few elements to it, and then prints the list like this:

`System.out.println(myList);`

What you should see is a string representation of the list, like this:

```
[Apple, Banana, Cherry]
```

## Exercise 3: Adding Elements at Specific Indexes

1.\
Write a program that creates an ArrayList of strings, then adds the following elements: apple, banana, citrus.

2.\
Print out the list.

3.\
Now, add "orange" at index 1 and print the list again. What does the list like now?

4.\
Then add "grape" at index 0 and print the list again.

Now, your list should look like this:

```
[grape, orange, apple, banana, citrus]
```

You have 5 elements in the list, and the last is at index 4. 

5.\
Try to insert "kiwi" at index 5. That should work, because it is the _next available index_ after the last element. So, that is a valid position.

6.\
Finally, try to insert "melon" at index 8. What happens? Why?

<hint title="Hint">

When you try to add an element at an index that is greater than the current size of the list, Java will throw an `IndexOutOfBoundsException`. The valid indices for a list of size `n` are from `0` to `n`. However, If you want to add an element at the end of the list, you can simply use `myList.add(element)` without specifying an index.

The ArrayList actually starts with an array of size 10, but the ArrayList keeps track of which cells are in use, and which are valid to use. Therefore, even if there is room in the array at index 8, it is not a valid index for the ArrayList, given its current size.

</hint>


## Exercise 4: Type mismatch

Create a program that declares an ArrayList of `Integer` elements, and then try to add a `String` element to it. What happens? Why?

```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<Integer> myList = new ArrayList<>();
        myList.add(1);
        myList.add(2);
        myList.add(3);

        // Try to add a String element
        myList.add("Hello");  // This will cause a compile-time error
    }
}
```

In this example, you will get a compile-time error because you are trying to add a `String` element to an `ArrayList` that is declared to hold `Integer` elements. Java's type system is designed to prevent this kind of error by enforcing type safety at compile time.

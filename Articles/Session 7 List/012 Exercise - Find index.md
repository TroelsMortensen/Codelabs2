# Exercise - Find the index of an element in a List

Create a program that creates an `ArrayList` of strings, adds a few elements to it, and requests the user to enter a string to search for. 

The program should check if the string exists in the list and:
- If found, print out the index of the element. 
- If not found, print a message indicating that it was not found. 
 
Do this in a loop, so the user can keep searching until they enter "exit" to stop.

Start with the following elements in the list: "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "kiwi".

Remember, an easy way to quickly create an `ArrayList` with initial values is to use the `Arrays.asList()` method.

```java
String[] initialFruits = {"apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "kiwi"};
ArrayList<String> fruits = new ArrayList<>(initialFruits.asList());
```

### Example Input:
```
Enter a fruit to search for (or 'exit' to stop): banana
Found: banana at index 1
Enter a fruit to search for (or 'exit' to stop): kiwi
Found: kiwi at index 7
Enter a fruit to search for (or 'exit' to stop): mango
Not found: mango
Enter a fruit to search for (or 'exit' to stop): exit
Exiting the program.
```

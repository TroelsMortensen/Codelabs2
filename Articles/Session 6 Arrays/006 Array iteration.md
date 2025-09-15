# Array Iteration in Java

Now that you understand (hopefully) arrays and their length property, it's time to learn how to efficiently process all elements in an array. Instead of accessing each element individually by index, we can use loops (typically a for-loop) to iterate through arrays automatically.

## Why Iterate Over Arrays?

Imagine you have an array with 100 elements. Writing 100 separate lines to access each element would be impractical:

```java
// This is not practical for large arrays!
int[] scores = new int[100];
System.out.println(scores[0]);
System.out.println(scores[1]);
System.out.println(scores[2]);
// ... 97 more lines!
```

Or maybe you don't know ahead of time how many elements you have in the array, then you cannot hardcode the print out statements.

Instead, we can use loops to process all elements in the array in turn.

## For Loop with Index

The most common way to iterate over an array is using a `for` loop with an index variable.

### Basic Syntax:
```java
for (int i = 0; i < arrayName.length; i++) {
    // Access element at index i: arrayName[i]
}
```

### Example 1: Printing All Elements
```java
int[] numbers = {10, 20, 30, 40, 50};

System.out.println("Array elements:");
for (int i = 0; i < numbers.length; i++) {
    System.out.println("Element at index " + i + ": " + numbers[i]);
}
```

**Output:**
```
Array elements:
Element at index 0: 10
Element at index 1: 20
Element at index 2: 30
Element at index 3: 40
Element at index 4: 50
```


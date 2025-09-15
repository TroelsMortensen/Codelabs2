
# Enhanced For-Loop (For-Each Loop) in Java

The enhanced for-loop, also known as the "for-each loop," is a simplified way to iterate through arrays and collections in Java. It provides a cleaner, more readable syntax when you only need to access the values of each element, not their indices.

## Basic Syntax

```java
for (dataType variableName : arrayOrCollection) {
    // Code to execute for each element
}
```

The enhanced for-loop reads as: "for each element in the array, do something with that element."

## Key Components

- **dataType**: The type of elements in the array (e.g., `int`, `String`, `double`)
- **variableName**: A temporary variable that holds the current element during each iteration
- **arrayOrCollection**: The array or collection you want to iterate through
- **Colon (:)**: Separates the variable from the array/collection (read as "in")

## Simple Examples

### Example 1: Printing Array Elements
```java
int[] numbers = {10, 20, 30, 40, 50};

System.out.println("Numbers in the array:");


// Using enhanced for-loop
for (int number : numbers) {
    System.out.println(number);
}
```

**Output:**
```
Numbers in the array:
10
20
30
40
50
```

### Example 2: Working with Strings
```java
String[] fruits = {"apple", "banana", "orange", "grape"};

System.out.println("Fruits:");
for (String fruit : fruits) {
    System.out.println("I like " + fruit + "s");
}
```

**Output:**
```
Fruits:
I like apples
I like bananas
I like oranges
I like grapes
```

### Example 3: Calculating Sum
```java
double[] prices = {19.99, 25.50, 12.75, 8.99, 33.25};
double total = 0;

for (double price : prices) {
    total += price;
}

System.out.println("Total cost: $" + total);
```

**Output:**
```
Total cost: $100.48
```

## Comparison: Regular vs Enhanced For-Loop

All three code snippets below do the same thing.

### Regular For-Loop (with index)
```java
int[] scores = {85, 92, 78, 96, 88};

// Using regular for-loop
for (int i = 0; i < scores.length; i++) {
    System.out.println("Score " + (i + 1) + ": " + scores[i]);
}

// or with a temporary variable
for (int i = 0; i < scores.length; i++) {
    int score = scores[i];
    System.out.println("Score " + (i + 1) + ": " + score);
}
```

### Enhanced For-Loop (without index)
```java
int[] scores = {85, 92, 78, 96, 88};

// Using enhanced for-loop
for (int score : scores) {
    System.out.println("Score: " + score);
}
```

## When to Use Enhanced For-Loop

### ✅ Use Enhanced For-Loop When:
- You only need to **read** the values
- You don't need the **index** of elements
- You want **cleaner, more readable** code
- You're processing each element **independently**
- You're performing operations like **sum, average, search**

### ❌ Don't Use Enhanced For-Loop When:
- You need to **modify** array elements
- You need the **index** of elements
- You want to **iterate backwards**
- You need to **skip** certain elements
- You're comparing **adjacent** elements

## Practical Examples

### Example 1: Finding Maximum Value
```java
int[] temperatures = {23, 28, 21, 30, 25, 27};
int maxTemp = temperatures[0]; // Start with first element

for (int temp : temperatures) {
    if (temp > maxTemp) {
        maxTemp = temp;
    }
}

System.out.println("Maximum temperature: " + maxTemp);
```

### Example 2: Counting Specific Values
```java
char[] grades = {'A', 'B', 'A', 'C', 'A', 'B', 'A'};
int countA = 0;

for (char grade : grades) {
    if (grade == 'A') {
        countA++;
    }
}

System.out.println("Number of A grades: " + countA);
```

### Example 3: Boolean Array Processing
```java
boolean[] testResults = {true, false, true, true, false, true};
int passed = 0;
int failed = 0;

for (boolean result : testResults) {
    if (result) {
        passed++;
    } else {
        failed++;
    }
}

System.out.println("Tests passed: " + passed);
System.out.println("Tests failed: " + failed);
```

## Limitations of Enhanced For-Loop

### 1. Cannot Modify Array Elements
```java
int[] numbers = {1, 2, 3, 4, 5};

// This WON'T modify the original array
for (int number : numbers) {
    number = number * 2; // Only changes the local variable
}
// Array still contains {1, 2, 3, 4, 5}

// To modify, use regular for-loop
for (int i = 0; i < numbers.length; i++) {
    numbers[i] = numbers[i] * 2; // This WILL modify the array
}
// Now array contains {2, 4, 6, 8, 10}
```

### 2. No Access to Index
```java
String[] names = {"Alice", "Bob", "Charlie"};

// Enhanced for-loop - no index available
for (String name : names) {
    System.out.println(name); // Can't print position number
}

// Regular for-loop - index available
for (int i = 0; i < names.length; i++) {
    System.out.println((i + 1) + ". " + names[i]); // Can print position
}
```

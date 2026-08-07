# Different ways to initialize arrays in Java

When working with arrays in Java, there are several ways to create and initialize them. Understanding these different approaches will help you choose the most appropriate method for your specific needs.

## 1. Creating Empty Arrays (with default values)

The most basic way to create an array is to specify its size. Java will automatically initialize all elements with default values.

### Syntax:
```java
dataType[] arrayName = new dataType[size];
```

### Examples:

**Integer Array:**
```java
int[] numbers = new int[5]; // Creates an array of 5 integers, all initialized to 0
```

**String Array:**
```java
String[] names = new String[3]; // Creates an array of 3 strings, all initialized to null
```

### Default Values by Data Type:
- **int, byte, short, long**: `0`
- **float, double**: `0.0`
- **boolean**: `false`
- **char**: `'\u0000'` (null character)
- **Object types (String, etc.)**: `null`

## 2. Array Initialization with Values

When you know the values you want to store in advance, you can initialize the array with those values directly.

### Method 1: Array Literal Syntax
```java
dataType[] arrayName = {value1, value2, value3, ...};
```

**Examples:**
```java
int[] scores = {85, 92, 78, 96, 88}; // Array of 5 integers
String[] colors = {"red", "green", "blue"}; // Array of 3 strings
double[] temperatures = {23.5, 25.0, 21.5, 24.0}; // Array of 4 doubles
boolean[] results = {true, false, true, true}; // Array of 4 booleans
```

### Method 2: Using the `new` keyword with values
```java
dataType[] arrayName = new dataType[]{value1, value2, value3, ...};
```

**Examples:**
```java
int[] ages = new int[]{18, 25, 30, 22, 35};
String[] cities = new String[]{"Copenhagen", "Stockholm", "Oslo"};
double[] weights = new double[]{65.5, 70.2, 58.9, 80.1};
```

In each of the above examples, the array is created and initialized with specific values. The _size_ of the array is determined by the number of values provided.

## 3. Mixed Approach: Create Empty, Then Assign Values

You can also create an empty array first and then assign values to specific positions:

```java
// Create empty array
int[] grades = new int[4];

// Assign values to specific indices
grades[0] = 90;
grades[1] = 85;
grades[2] = 92;
grades[3] = 88;
```

## 4. Array Size is Fixed
Once an array is created, its size cannot be changed:
```java
int[] numbers = new int[5]; // Size is 5 and cannot be modified
// numbers.length will always be 5
```
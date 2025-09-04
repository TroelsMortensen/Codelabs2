# Method Overloading Exercises

## Exercise 1 - Calculator Class

Create a Calculator class with overloaded methods for basic arithmetic operations. Implement multiple versions of add, subtract, multiply, and divide methods to handle different parameter types and counts.

**Requirements:**
- Overloaded `add` methods: two integers, two doubles, three integers, array of integers
- Overloaded `subtract` methods: two integers, two doubles
- Overloaded `multiply` methods: two integers, two doubles, integer and double
- Overloaded `divide` methods: two integers (return double), two doubles, integer by double
- Static methods for each operation
- Handle division by zero with appropriate messages

```console
Enter two integers:
10 5
Addition: 15
Subtraction: 5
Multiplication: 50
Division: 2.0

Enter two doubles:
3.5 2.1
Addition: 5.6
Subtraction: 1.4
Multiplication: 7.35
Division: 1.67

Enter three integers:
2 3 4
Addition: 9
```

## Exercise 2 - String Utility Class

Implement a StringUtils class with overloaded static methods for string manipulation. Create multiple versions of methods to handle different parameter combinations.

**Requirements:**
- Overloaded `format` methods:
  - format(String template, String value1)
  - format(String template, String value1, String value2)
  - format(String template, int value1, String value2)
  - format(String template, String value1, int value2, double value3)
- Overloaded `contains` methods:
  - contains(String text, String substring)
  - contains(String text, char character)
  - contains(String text, String substring, boolean caseSensitive)
- Overloaded `replace` methods:
  - replace(String text, String oldStr, String newStr)
  - replace(String text, char oldChar, char newChar)
  - replace(String text, String oldStr, String newStr, int maxReplacements)

```console
Enter a template (use {0}, {1}, {2} for placeholders):
Hello {0}, you have {1} messages and {2} unread emails
Enter value 1:
John
Enter value 2:
5
Enter value 3:
2.5
Formatted: Hello John, you have 5 messages and 2.5 unread emails

Enter text to search:
Hello World
Enter substring:
world
Case sensitive search (true/false):
false
Contains: true

Enter text to replace in:
Java is great, Java is powerful
Enter old string:
Java
Enter new string:
Python
Enter max replacements:
1
Result: Python is great, Java is powerful
```

## Exercise 3 - Shape Area Calculator

Create a ShapeCalculator class with overloaded methods to calculate areas of different geometric shapes. Include both static and instance methods with various parameter combinations.

**Requirements:**
- Static overloaded `calculateArea` methods:
  - calculateArea(double radius) - circle
  - calculateArea(double length, double width) - rectangle
  - calculateArea(double base, double height, String shape) - triangle/parallelogram
  - calculateArea(double side1, double side2, double side3) - triangle using Heron's formula
- Instance overloaded `setDimensions` methods:
  - setDimensions(double radius)
  - setDimensions(double length, double width)
  - setDimensions(double base, double height)
  - setDimensions(double side1, double side2, double side3)
- Instance method `getArea()` that returns the calculated area
- Constructor overloads for different shapes

```console
Choose calculation type (static/instance):
static
Enter shape type (circle/rectangle/triangle/heron):
circle
Enter radius:
5.0
Area: 78.54

Choose calculation type (static/instance):
instance
Enter shape type (rectangle/triangle):
rectangle
Enter length:
10.0
Enter width:
6.0
Area: 60.0

Choose calculation type (static/instance):
static
Enter shape type (heron):
heron
Enter side 1:
3.0
Enter side 2:
4.0
Enter side 3:
5.0
Area: 6.0
```

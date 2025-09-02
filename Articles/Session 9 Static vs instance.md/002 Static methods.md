# Static Methods in Java

You just read about static field variables, which belong to the class itself rather than to an instance of the class. Similarly, static methods belong to the class itself rather than to an instance of the class.

Watch the following video to understand the difference between static and instance methods:

<video src="https://youtu.be/v8zYkjeC2LU"></video>

Wauw, that was a lot of person class versus instance of the person class.\
Remember, the class is the blueprint, and the instance is the object we can create from the blueprint.\
Objects are instances created based on the class, with the `new` keyword.

## Static methods

Static methods in Java are methods that belong to the class itself rather than to instances (objects) of the class. They can be called directly on the class without creating an object first.

Until now, all methods have been instance methods, that is, they belong to an _instance_ of a class. You first create a new Person object, then you can call the method on that object.\
Now, you can call methods without instantiating an object.

## Key Characteristics of Static Methods

- **Belong to the class**: They are associated with the class, not with individual objects
- **No instance required**: Can be called using the class name directly
- **Cannot access instance variables**: They can only work with static variables and parameters
- **Cannot use `this` keyword**: Since there's no instance, `this` doesn't exist

## Syntax

```java
public class MyClass {
    // Static method declaration
    public static returnType methodName(parameters) {
        // method body
    }
}

// Calling a static method
MyClass.methodName(arguments);
```

Notice the `static` keyword before the method name. And below, when calling the method, we call it on the class name, `MyClass.methodName(arguments);`

## Examples

### Example 1: Basic Static Method

```java
public class MathUtils {
    // Static method to add two numbers
    public static int add(int a, int b) {
        return a + b;
    }
    
    // Static method to calculate area of a circle
    public static double calculateCircleArea(double radius) {
        return Math.PI * radius * radius;
    }
}

// Using the static methods
public class Main {
    public static void main(String[] args) {
        // Call static methods directly on the class
        int sum = MathUtils.add(5, 3);           // Returns 8
        double area = MathUtils.calculateCircleArea(2.5); // Returns ~19.63
        
        System.out.println("Sum: " + sum);
        System.out.println("Area: " + area);
    }
}
```

### Example 2: Static vs Instance Methods

Static methods belong to the class, not to an instance of the class. That also means, that static methods cannot access instance variables. Only static fields are accessible. For example:

```java
public class Calculator {
    // Instance variable
    private int memory;
    
    // Instance method - requires an object
    public void storeInMemory(int value) {
        this.memory = value;
    }
    
    public int getMemory() {
        return this.memory;
    }
    
    // Static method - can be called on the class
    public static int add(int a, int b) {
        return a + b;
    }
    
    // Static method - cannot access instance variables
    public static void clearMemory() {
        // This won't work! Static methods can't access instance variables
        // memory = 0;  // Compilation error!
    }
}

// Usage
public class Main {
    public static void main(String[] args) {
        // Static method - call on class
        int result = Calculator.add(10, 20);  // Works fine
        
        // Instance method - need an object
        Calculator calc = new Calculator();
        calc.storeInMemory(100);
        System.out.println("Memory: " + calc.getMemory());
    }
}
```



## When to Use Static Methods

### Use Static Methods When:
- The method doesn't need to access instance variables
- The method performs a utility function that doesn't depend on object state
- You want to provide factory methods for creating objects
- The method is purely functional (same input always produces same output)

### Don't Use Static Methods When:
- The method needs to access instance variables
- The method's behavior depends on the object's state
- You want to override the method in subclasses
- The method needs to use `this` keyword

## Common Built-in Static Methods

Java provides many useful static methods in built-in classes:

```java
// Math class
double sqrt = Math.sqrt(16.0);        // 4.0
double random = Math.random();        // Random number between 0.0 and 1.0
int max = Math.max(10, 20);          // 20

// String class
String value = String.valueOf(42);    // "42"
String joined = String.join("-", "a", "b", "c"); // "a-b-c"

// Arrays class
int[] numbers = {3, 1, 4, 1, 5};
Arrays.sort(numbers);                 // Sorts the array
String arrayStr = Arrays.toString(numbers); // "[1, 1, 3, 4, 5]"
```

## Summary

Static methods are powerful tools in Java that allow you to:
- Create utility functions that don't require object instances
- Implement factory patterns for object creation
- Provide class-level functionality
- Improve memory efficiency by sharing code across all instances

Remember that static methods cannot access instance variables or use the `this` keyword, but they can access other static members of the class.

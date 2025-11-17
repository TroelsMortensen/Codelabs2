# Exercise 1

Draw a sequence diagram based on the following Java code:

```java
public class Main {
    
    public static void main(String[] args) {
        Calculator calculator = new Calculator();
        
        int sum = calculator.add(5, 3);
        System.out.println("Sum: " + sum);
        
        int product = calculator.multiply(4, 7);
        System.out.println("Product: " + product);
        
        calculator.reset();
    }
}

public class Calculator {
    
    
    public int add(int a, int b) {
        int result = a + b;
        return result;
    }
    
    public int multiply(int a, int b) {
        int result = calculateProduct(a, b);
        return result;
    }
    
    private int calculateProduct(int a, int b) {
        return a * b;
    }
}
```

**Tasks:**
1. Draw a sequence diagram showing all method calls
2. Include the object creation (`<<create>>`)
3. Show the calls to `add()`, `multiply()`, etc.
4. Show the self-call from `multiply()` to `calculateProduct()` with nested activation bars
5. Include return arrows (dashed lines) for methods that return values

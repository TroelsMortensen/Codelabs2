# Import Statements

## What are Import Statements?

Import statements tell Java where to find classes that you want to use in your code. Without import statements, you would have to use the full package name every time you reference a class from another package.

## Why Do We Need Import Statements?

### Without Import Statements
```java
package com.company.graphics;

public class ShapeManager {
    public void createShapes() {
        // Must use full package name
        java.util.ArrayList<java.awt.Color> colors = new java.util.ArrayList<>();
        java.awt.Color red = new java.awt.Color(255, 0, 0);
        colors.add(red);
        
        java.util.Date currentDate = new java.util.Date();
        System.out.println("Created shapes on: " + currentDate);
    }
}
```

### With Import Statements
```java
package com.company.graphics;

import java.util.ArrayList;
import java.util.Date;
import java.awt.Color;

public class ShapeManager {
    public void createShapes() {
        // Can use short class names
        ArrayList<Color> colors = new ArrayList<>();
        Color red = new Color(255, 0, 0);
        colors.add(red);
        
        Date currentDate = new Date();
        System.out.println("Created shapes on: " + currentDate);
    }
}
```

## Import Statement Syntax

### Basic Import
```java
import package.name.ClassName;
```

### Wildcard Import
```java
import package.name.*;
```

### Static Import
```java
import static package.name.ClassName.staticMember;
```

## Types of Import Statements

### 1. **Single Class Import**
Import one specific class:

```java
import java.util.ArrayList;
import java.util.Date;
import java.awt.Color;
```

### 2. **Wildcard Import**
Import all classes from a package:

```java
import java.util.*;
import java.awt.*;
```

### 3. **Static Import**
Import static members (fields and methods):

```java
import static java.lang.Math.PI;
import static java.lang.Math.sqrt;
import static java.lang.System.out;
```

## Import Statement Rules

### 1. **Must Come After Package Declaration**
```java
package com.company.graphics;

import java.util.ArrayList;  // Correct - after package
import java.awt.Color;

public class Circle {
    // class implementation
}
```

### 2. **Must Come Before Class Declaration**
```java
package com.company.graphics;

import java.util.ArrayList;
import java.awt.Color;

public class Circle {  // Correct - after imports
    // class implementation
}
```

### 3. **No Duplicate Imports**
```java
import java.util.ArrayList;
import java.util.ArrayList;  // ERROR! Duplicate import
```

## Real-World Example: E-commerce System

### Without Imports (Full Package Names)
```java
package com.ecommerce.ui;

public class ProductWindow {
    public void displayProducts() {
        java.util.List<com.ecommerce.model.Product> products = 
            new java.util.ArrayList<>();
        
        com.ecommerce.model.Product product1 = 
            new com.ecommerce.model.Product("Laptop", 999.99, 5);
        com.ecommerce.model.Product product2 = 
            new com.ecommerce.model.Product("Mouse", 29.99, 20);
        
        products.add(product1);
        products.add(product2);
        
        for (com.ecommerce.model.Product product : products) {
            java.lang.System.out.println("Product: " + product.getName() + 
                                       ", Price: $" + product.getPrice());
        }
    }
}
```

### With Imports (Clean Code)
```java
package com.ecommerce.ui;

import java.util.List;
import java.util.ArrayList;
import com.ecommerce.model.Product;

public class ProductWindow {
    public void displayProducts() {
        List<Product> products = new ArrayList<>();
        
        Product product1 = new Product("Laptop", 999.99, 5);
        Product product2 = new Product("Mouse", 29.99, 20);
        
        products.add(product1);
        products.add(product2);
        
        for (Product product : products) {
            System.out.println("Product: " + product.getName() + 
                             ", Price: $" + product.getPrice());
        }
    }
}
```

## Common Java Packages and Imports

### 1. **java.lang Package**
Automatically imported - no need to import:

```java
// These are automatically available
String name = "Hello";
System.out.println(name);
Integer number = 42;
```

### 2. **java.util Package**
Collections and utilities:

```java
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.HashMap;
import java.util.Date;
import java.util.Calendar;
```

### 3. **java.io Package**
Input/Output operations:

```java
import java.io.File;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.IOException;
```

### 4. **java.awt Package**
Abstract Window Toolkit:

```java
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Point;
```

### 5. **javax.swing Package**
Swing GUI components:

```java
import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
```

## Static Imports

### Regular Import vs Static Import

#### Regular Import
```java
import java.lang.Math;

public class Calculator {
    public double calculateCircleArea(double radius) {
        return Math.PI * Math.pow(radius, 2);
    }
    
    public double calculateSquareRoot(double number) {
        return Math.sqrt(number);
    }
}
```

#### Static Import
```java
import static java.lang.Math.PI;
import static java.lang.Math.pow;
import static java.lang.Math.sqrt;

public class Calculator {
    public double calculateCircleArea(double radius) {
        return PI * pow(radius, 2);  // No Math. prefix needed
    }
    
    public double calculateSquareRoot(double number) {
        return sqrt(number);  // No Math. prefix needed
    }
}
```

### Static Import Examples
```java
import static java.lang.System.out;
import static java.lang.System.err;
import static java.lang.Math.*;
import static java.util.Collections.sort;

public class Example {
    public void demonstrateStaticImports() {
        out.println("This goes to standard output");
        err.println("This goes to standard error");
        
        double result = sqrt(16) + pow(2, 3);
        out.println("Result: " + result);
        
        List<String> names = Arrays.asList("Alice", "Bob", "Charlie");
        sort(names);  // No Collections.sort needed
    }
}
```

## Import Conflicts

### Same Class Name in Different Packages
```java
import java.util.Date;
import java.sql.Date;  // ERROR! Conflicting imports

public class Example {
    public void demonstrateConflict() {
        Date date1 = new Date();  // Which Date class?
    }
}
```

### Solution: Use Full Package Name
```java
import java.util.Date;

public class Example {
    public void demonstrateConflict() {
        java.util.Date utilDate = new java.util.Date();
        java.sql.Date sqlDate = new java.sql.Date(System.currentTimeMillis());
    }
}
```

## Wildcard Imports

### When to Use Wildcard Imports
```java
// Good - when using many classes from the same package
import java.util.*;
import java.awt.*;

public class GraphicsExample {
    public void createComponents() {
        List<String> items = new ArrayList<>();
        Map<String, Integer> counts = new HashMap<>();
        Set<String> uniqueItems = new HashSet<>();
        
        Color red = new Color(255, 0, 0);
        Font boldFont = new Font("Arial", Font.BOLD, 12);
        Point position = new Point(100, 200);
    }
}
```

### When NOT to Use Wildcard Imports
```java
// Bad - when using only one or two classes
import java.util.*;
import java.awt.*;

public class SimpleExample {
    public void simpleMethod() {
        ArrayList<String> list = new ArrayList<>();  // Only using ArrayList
        // Wildcard import is overkill
    }
}
```

## Import Best Practices

### 1. **Import Only What You Need**
```java
// Good - specific imports
import java.util.ArrayList;
import java.util.List;
import java.awt.Color;

// Bad - wildcard when only using one class
import java.util.*;
import java.awt.*;
```

### 2. **Group Imports by Package**
```java
// Good - grouped by package
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import java.awt.Color;
import java.awt.Font;

import com.company.model.Product;
import com.company.service.ProductService;
```

### 3. **Use Static Imports Sparingly**
```java
// Good - for frequently used static members
import static java.lang.Math.PI;
import static java.lang.System.out;

// Bad - importing too many static members
import static java.lang.Math.*;
import static java.lang.System.*;
```

### 4. **Avoid Import Conflicts**
```java
// Good - use full package name for conflicts
import java.util.Date;

public class Example {
    public void method() {
        java.util.Date utilDate = new java.util.Date();
        java.sql.Date sqlDate = new java.sql.Date(System.currentTimeMillis());
    }
}
```

## Import Statement Checklist

- [ ] Import statements come after package declaration
- [ ] Import statements come before class declaration
- [ ] No duplicate imports
- [ ] Import only what you need
- [ ] Group imports by package
- [ ] Use static imports sparingly
- [ ] Resolve import conflicts with full package names

## Summary

Import statements are essential for:

- **Clean, readable code** - No need for full package names
- **Code organization** - Clear what external classes you're using
- **Avoiding conflicts** - Resolve naming conflicts between packages
- **Professional development** - Standard practice in Java development

In the next article, we'll learn about package organization and best practices for structuring your code.

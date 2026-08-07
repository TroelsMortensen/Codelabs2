# Import Statements

## What are Import Statements?

Import statements tell Java where to find classes that you want to use in your code. Without import statements, you would have to use the full package name every time you reference a class from another package.

## Why Do We Need Import Statements?

### Without Import Statements

Notice the full names of types. This is not very readable.

```java{6,7,10}
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

This is what you are most familiar with, here we import a specific class from a package. Notice `ClassName` is PascalCase, so it is a class name.

```java
import package.name.ClassName;
```

### Wildcard Import

This is when you want to import all classes from a package.

```java
import package.name.*;
```


### 3. **Static Import**
Import static members (fields and methods). This will allow you to call static methods, without prefixing the class name. For example, instead of calling `Math.PI`, you can call `PI`.

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

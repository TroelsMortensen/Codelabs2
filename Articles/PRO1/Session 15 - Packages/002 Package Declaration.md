# Package Declaration

## Package Declaration
Each Java file must declare its package at the top:

```java
package com.company.project.graphics;

public class Circle {
    // class implementation
}
```

Whenever you create a new class in IntelliJ, it will automatically declare the package at the top of the file.


### Example
```java
package com.company.graphics;

public class Circle {
    private double radius;
    
    public Circle(double radius) {
        this.radius = radius;
    }
    
    public double getArea() {
        return Math.PI * radius * radius;
    }
}
```

## Package Declaration Rules

### 1. **Must be First Line**
The package declaration must be the first non-comment line in the file:

```java
package com.company.graphics;

// This is correct
public class Circle {
    // class implementation
}
```

### 2. **Only One Package Declaration**
Each file can have only one package declaration:

```java
package com.company.graphics;
// package com.company.database; // ERROR! Only one package declaration allowed

public class Circle {
    // class implementation
}
```

### 3. **Must Match Directory Structure**
The package declaration must match the directory structure:

```
Directory: src/com/company/graphics/Circle.java
Package:   package com.company.graphics;
```


## Default Package

### What is the Default Package?
If you don't declare/create a package, your class goes into the "default package":

```java
// No package declaration
public class Circle {
    // This class is in the default package
}
```

Don't do this. It will cause problems.

### Problems with Default Package
- **Cannot be imported** - Other packages can't import from default package
- **Not recommended** - Makes code organization difficult
- **Hard to maintain** - No clear structure
# Package Declaration

## How to Declare Packages

Every Java file must declare its package at the very beginning of the file, before any import statements or class declarations.

## Basic Package Declaration

### Syntax
```java
package package.name;
```

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

## Package Naming Examples

### Simple Package
```java
package graphics;

public class Circle {
    // class implementation
}
```

### Hierarchical Package
```java
package com.company.project.graphics;

public class Circle {
    // class implementation
}
```

### Deep Package Structure
```java
package com.company.project.ui.components.buttons;

public class CustomButton {
    // class implementation
}
```

## Default Package

### What is the Default Package?
If you don't declare a package, your class goes into the "default package":

```java
// No package declaration
public class Circle {
    // This class is in the default package
}
```

### Problems with Default Package
- **Cannot be imported** - Other packages can't import from default package
- **Not recommended** - Makes code organization difficult
- **Hard to maintain** - No clear structure

### Best Practice
Always declare a package, even for simple projects:

```java
package com.yourname.projectname;

public class Circle {
    // Much better!
}
```

## Real-World Example: E-commerce System

### Package Structure
```
src/
├── com/
│   └── ecommerce/
│       ├── model/
│       │   ├── Product.java
│       │   ├── User.java
│       │   └── Order.java
│       ├── dao/
│       │   ├── ProductDAO.java
│       │   ├── UserDAO.java
│       │   └── OrderDAO.java
│       ├── service/
│       │   ├── ProductService.java
│       │   ├── UserService.java
│       │   └── OrderService.java
│       └── ui/
│           ├── MainWindow.java
│           ├── ProductWindow.java
│           └── UserWindow.java
```

### Package Declarations

#### Model Package
```java
package com.ecommerce.model;

public class Product {
    private String name;
    private double price;
    private int quantity;
    
    public Product(String name, double price, int quantity) {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }
    
    // getters and setters
    public String getName() { return name; }
    public void setName(String name) { this.name = name; }
    
    public double getPrice() { return price; }
    public void setPrice(double price) { this.price = price; }
    
    public int getQuantity() { return quantity; }
    public void setQuantity(int quantity) { this.quantity = quantity; }
}
```

#### DAO Package
```java
package com.ecommerce.dao;

import com.ecommerce.model.Product;

public class ProductDAO {
    public void save(Product product) {
        System.out.println("Saving product: " + product.getName());
    }
    
    public Product findById(int id) {
        System.out.println("Finding product with ID: " + id);
        return new Product("Sample Product", 29.99, 10);
    }
    
    public void delete(int id) {
        System.out.println("Deleting product with ID: " + id);
    }
}
```

#### Service Package
```java
package com.ecommerce.service;

import com.ecommerce.model.Product;
import com.ecommerce.dao.ProductDAO;

public class ProductService {
    private ProductDAO productDAO;
    
    public ProductService() {
        this.productDAO = new ProductDAO();
    }
    
    public void addProduct(Product product) {
        productDAO.save(product);
    }
    
    public Product getProduct(int id) {
        return productDAO.findById(id);
    }
    
    public void removeProduct(int id) {
        productDAO.delete(id);
    }
}
```

#### UI Package
```java
package com.ecommerce.ui;

import com.ecommerce.model.Product;
import com.ecommerce.service.ProductService;

public class ProductWindow {
    private ProductService productService;
    
    public ProductWindow() {
        this.productService = new ProductService();
    }
    
    public void displayProduct(int id) {
        Product product = productService.getProduct(id);
        System.out.println("Product: " + product.getName() + 
                         ", Price: $" + product.getPrice());
    }
}
```

## Package Organization Best Practices

### 1. **Logical Grouping**
Group related classes together:

```java
// Good - related functionality
package com.company.graphics;
package com.company.database;
package com.company.ui;

// Bad - mixed functionality
package com.company.stuff;
```

### 2. **Consistent Naming**
Use consistent naming conventions:

```java
// Good - consistent hierarchy
package com.company.project.model;
package com.company.project.service;
package com.company.project.dao;

// Bad - inconsistent naming
package com.company.project.model;
package com.company.project.business;
package com.company.project.data;
```

### 3. **Avoid Deep Nesting**
Don't create too many levels:

```java
// Good - reasonable depth
package com.company.project.module;

// Bad - too deep
package com.company.project.module.submodule.component.part;
```

### 4. **Meaningful Names**
Use descriptive package names:

```java
// Good - descriptive
package com.company.inventory.management;
package com.company.user.authentication;

// Bad - vague
package com.company.stuff;
package com.company.things;
```

## Common Package Patterns

### 1. **MVC Pattern**
```
com.company.project.model
com.company.project.view
com.company.project.controller
```

### 2. **Layered Architecture**
```
com.company.project.presentation
com.company.project.business
com.company.project.data
```

### 3. **Feature-Based**
```
com.company.project.user
com.company.project.product
com.company.project.order
```

### 4. **Technical Layers**
```
com.company.project.dao
com.company.project.service
com.company.project.util
```

## Package Declaration Checklist

- [ ] Package declaration is the first line (after comments)
- [ ] Only one package declaration per file
- [ ] Package name matches directory structure
- [ ] Package name follows naming conventions
- [ ] Package name is descriptive and meaningful
- [ ] No classes in default package (unless absolutely necessary)

## Summary

Package declaration is essential for:

- **Organizing code** into logical groups
- **Avoiding naming conflicts** between classes
- **Creating unique identifiers** for classes
- **Enabling proper access control** between packages
- **Making code maintainable** and professional

In the next article, we'll learn how to use import statements to access classes from other packages.

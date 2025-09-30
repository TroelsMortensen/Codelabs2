# Package Organization

## Why Package Organization Matters

Good package organization is crucial for:
- **Maintainability** - Easy to find and modify code
- **Team Development** - Clear boundaries between different parts
- **Code Reuse** - Easy to share and import packages
- **Scalability** - Can grow with your project

## Common Package Organization Patterns

### 1. **Layer-Based Organization**
Organize by technical layers:

```
com.company.project
├── presentation/     # UI layer
│   ├── controllers/
│   ├── views/
│   └── forms/
├── business/         # Business logic layer
│   ├── services/
│   ├── managers/
│   └── validators/
├── data/            # Data access layer
│   ├── dao/
│   ├── repositories/
│   └── entities/
└── util/            # Utility classes
    ├── helpers/
    ├── constants/
    └── exceptions/
```

### 2. **Feature-Based Organization**
Organize by business features:

```
com.company.project
├── user/            # User management feature
│   ├── model/
│   ├── service/
│   ├── dao/
│   └── controller/
├── product/         # Product management feature
│   ├── model/
│   ├── service/
│   ├── dao/
│   └── controller/
└── order/           # Order management feature
    ├── model/
    ├── service/
    ├── dao/
    └── controller/
```

### 3. **Hybrid Organization**
Combine both approaches:

```
com.company.project
├── shared/          # Shared across features
│   ├── model/
│   ├── util/
│   └── exceptions/
├── features/        # Feature-specific code
│   ├── user/
│   ├── product/
│   └── order/
└── infrastructure/  # Technical infrastructure
    ├── database/
    ├── messaging/
    └── security/
```

## Real-World Example: Library Management System

### Package Structure
```
src/
├── com/
│   └── library/
│       ├── model/           # Data models
│       │   ├── Book.java
│       │   ├── Author.java
│       │   ├── Member.java
│       │   └── Loan.java
│       ├── service/         # Business logic
│       │   ├── BookService.java
│       │   ├── MemberService.java
│       │   └── LoanService.java
│       ├── dao/            # Data access
│       │   ├── BookDAO.java
│       │   ├── MemberDAO.java
│       │   └── LoanDAO.java
│       ├── controller/     # Controllers
│       │   ├── BookController.java
│       │   ├── MemberController.java
│       │   └── LoanController.java
│       ├── ui/             # User interface
│       │   ├── MainWindow.java
│       │   ├── BookWindow.java
│       │   └── MemberWindow.java
│       ├── util/           # Utilities
│       │   ├── DateHelper.java
│       │   ├── ValidationHelper.java
│       │   └── Constants.java
│       └── exception/      # Custom exceptions
│           ├── BookNotFoundException.java
│           ├── MemberNotFoundException.java
│           └── LoanException.java
```

### Package Contents

#### Model Package
```java
package com.library.model;

public class Book {
    private String isbn;
    private String title;
    private String author;
    private boolean isAvailable;
    
    public Book(String isbn, String title, String author) {
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.isAvailable = true;
    }
    
    // getters and setters
    public String getIsbn() { return isbn; }
    public String getTitle() { return title; }
    public String getAuthor() { return author; }
    public boolean isAvailable() { return isAvailable; }
    public void setAvailable(boolean available) { this.isAvailable = available; }
}
```

#### Service Package
```java
package com.library.service;

import com.library.model.Book;
import com.library.dao.BookDAO;
import com.library.exception.BookNotFoundException;

public class BookService {
    private BookDAO bookDAO;
    
    public BookService() {
        this.bookDAO = new BookDAO();
    }
    
    public Book findBook(String isbn) throws BookNotFoundException {
        Book book = bookDAO.findByIsbn(isbn);
        if (book == null) {
            throw new BookNotFoundException("Book with ISBN " + isbn + " not found");
        }
        return book;
    }
    
    public void addBook(Book book) {
        bookDAO.save(book);
    }
    
    public void removeBook(String isbn) throws BookNotFoundException {
        Book book = findBook(isbn);
        bookDAO.delete(book);
    }
}
```

#### DAO Package
```java
package com.library.dao;

import com.library.model.Book;
import java.util.ArrayList;
import java.util.List;

public class BookDAO {
    private List<Book> books;
    
    public BookDAO() {
        this.books = new ArrayList<>();
    }
    
    public void save(Book book) {
        books.add(book);
    }
    
    public Book findByIsbn(String isbn) {
        for (Book book : books) {
            if (book.getIsbn().equals(isbn)) {
                return book;
            }
        }
        return null;
    }
    
    public void delete(Book book) {
        books.remove(book);
    }
    
    public List<Book> findAll() {
        return new ArrayList<>(books);
    }
}
```

#### Exception Package
```java
package com.library.exception;

public class BookNotFoundException extends Exception {
    public BookNotFoundException(String message) {
        super(message);
    }
}
```

## Package Naming Conventions

### 1. **Use Lowercase Letters**
```java
// Good
package com.company.project.model;
package com.company.project.service;

// Bad
package com.company.project.Model;
package com.company.project.Service;
```

### 2. **Use Reverse Domain Name**
```java
// Good - using your domain
package com.yourcompany.projectname;
package org.apache.commons;
package edu.university.project;

// Bad - using someone else's domain
package com.google.mypackage;
package com.microsoft.mypackage;
```

### 3. **Use Descriptive Names**
```java
// Good - descriptive
package com.company.inventory.management;
package com.company.user.authentication;
package com.company.payment.processing;

// Bad - vague
package com.company.stuff;
package com.company.things;
package com.company.misc;
```

### 4. **Avoid Abbreviations**
```java
// Good - full words
package com.company.user.management;
package com.company.product.catalog;

// Bad - abbreviations
package com.company.usr.mgmt;
package com.company.prod.cat;
```

## Package Dependencies

### 1. **Avoid Circular Dependencies**
```java
// Bad - circular dependency
// Package A imports Package B
// Package B imports Package A

// Good - one-way dependency
// Package A imports Package B
// Package B doesn't import Package A
```

### 2. **Minimize Dependencies**
```java
// Bad - too many dependencies
package com.company.ui;
import com.company.model.*;
import com.company.service.*;
import com.company.dao.*;
import com.company.util.*;
import com.company.exception.*;

// Good - minimal dependencies
package com.company.ui;
import com.company.model.Product;
import com.company.service.ProductService;
```

### 3. **Use Interfaces for Loose Coupling**
```java
// Good - using interface
package com.company.service;
import com.company.dao.ProductDAO;

public class ProductService {
    private ProductDAO productDAO;  // Interface, not concrete class
    
    public ProductService(ProductDAO productDAO) {
        this.productDAO = productDAO;
    }
}
```

## Package Access Control

### 1. **Package-Private Access**
Classes in the same package can access each other's package-private members:

```java
package com.company.model;

class Book {  // package-private class
    String title;  // package-private field
    
    void displayInfo() {  // package-private method
        System.out.println("Title: " + title);
    }
}

class Author {
    public void showBookInfo() {
        Book book = new Book();  // Can access package-private class
        book.title = "Java Guide";  // Can access package-private field
        book.displayInfo();  // Can access package-private method
    }
}
```

### 2. **Public Access for Cross-Package**
Classes in different packages need public access:

```java
package com.company.service;

import com.company.model.Book;  // Must be public

public class BookService {
    public void processBook(Book book) {  // Book must be public
        // Process the book
    }
}
```

## Package Documentation

### 1. **Package-Level Documentation**
Create `package-info.java` files:

```java
package com.company.model;

/**
 * This package contains all the data models for the application.
 * 
 * <p>Models represent the core business entities and their relationships.
 * They are used throughout the application to represent data.</p>
 * 
 * <p>Key models include:</p>
 * <ul>
 *   <li>{@link Book} - Represents a book in the library</li>
 *   <li>{@link Author} - Represents an author</li>
 *   <li>{@link Member} - Represents a library member</li>
 * </ul>
 * 
 * @author Your Name
 * @version 1.0
 * @since 2024-01-01
 */
```

### 2. **Package Dependencies Documentation**
Document which packages depend on which:

```java
/**
 * Package Dependencies:
 * 
 * This package depends on:
 * - com.company.util (for utility classes)
 * - com.company.exception (for custom exceptions)
 * 
 * This package is used by:
 * - com.company.service (for business logic)
 * - com.company.ui (for user interface)
 */
```

## Package Organization Best Practices

### 1. **Start Simple, Grow Gradually**
```java
// Start with basic structure
com.company.project
├── model/
├── service/
└── ui/

// Add more packages as needed
com.company.project
├── model/
├── service/
├── ui/
├── dao/
├── util/
└── exception/
```

### 2. **Keep Related Classes Together**
```java
// Good - related classes together
com.company.project.user
├── User.java
├── UserService.java
├── UserDAO.java
└── UserController.java

// Bad - scattered classes
com.company.project
├── User.java
├── ProductService.java
├── UserDAO.java
└── ProductController.java
```

### 3. **Use Consistent Naming**
```java
// Good - consistent naming
com.company.project
├── model/
├── service/
├── dao/
└── controller/

// Bad - inconsistent naming
com.company.project
├── model/
├── business/
├── data/
└── ui/
```

### 4. **Avoid Deep Nesting**
```java
// Good - reasonable depth
com.company.project.feature

// Bad - too deep
com.company.project.module.submodule.component.part
```

## Package Organization Checklist

- [ ] Use consistent naming conventions
- [ ] Group related classes together
- [ ] Avoid circular dependencies
- [ ] Minimize package dependencies
- [ ] Use interfaces for loose coupling
- [ ] Document package purposes
- [ ] Keep package structure simple
- [ ] Plan for future growth

## Summary

Good package organization is essential for:

- **Maintainable code** - Easy to find and modify
- **Team collaboration** - Clear boundaries and responsibilities
- **Code reuse** - Well-organized packages are easier to share
- **Scalability** - Structure can grow with your project
- **Professional development** - Industry standard practices

In the next article, we'll learn how to represent packages in UML diagrams.

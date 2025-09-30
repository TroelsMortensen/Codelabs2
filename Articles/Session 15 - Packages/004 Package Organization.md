# Package Organization

As your system grows it becomes increasingly important to organize your code into packages.

## Why Package Organization Matters

Good package organization is crucial for:
- **Maintainability** - Easy to find and modify code
- **Team Development** - Clear boundaries between different parts
- **Code Reuse** - Easy to share and import packages
- **Scalability** - Can grow with your project

## Common Package Organization Patterns

There are various strategies for organizing your packages.

### 1. **Layer-Based Organization**
Organize by technical layers. This is a common approach, and probably what you will be doing for the next couple of semesters.

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
│       ├── model/                              # Data models, classes representing real-world objects
│       │   ├── Book.java
│       │   ├── Author.java
│       │   ├── Member.java
│       │   └── Loan.java
│       ├── service/                            # Business logic, the business rules
│       │   ├── BookService.java
│       │   ├── MemberService.java
│       │   └── LoanService.java
│       ├── dao/                                # Data access, saving data in files or databases
│       │   ├── BookDAO.java
│       │   ├── MemberDAO.java
│       │   └── LoanDAO.java
│       ├── controller/                         # Controllers, handling user input and output
│       │   ├── BookController.java
│       │   ├── MemberController.java
│       │   └── LoanController.java
│       ├── ui/                                 # User interface, displaying the data to the user
│       │   ├── MainWindow.java
│       │   ├── BookWindow.java
│       │   └── MemberWindow.java
│       ├── util/                               # Utilities, helper classes
│       │   ├── DateHelper.java
│       │   ├── ValidationHelper.java
│       │   └── Constants.java
│       └── exception/                          # Custom exceptions, handling errors
│           ├── BookNotFoundException.java
│           ├── MemberNotFoundException.java
│           └── LoanException.java
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

# Introduction to Java Packages

You already know a little about packages, when we introduced imports. But we will just cover it in slightly more detail here.

## What are Packages?

A **package** in Java is a namespace that organizes a set of related classes and interfaces. Think of packages as folders on your computer - they help you organize files in a logical way so you can find them easily and avoid naming conflicts.

## Why Do We Need Packages?

### 1. **Organization**
Packages help organize code into logical groups:
- All classes related to graphics go in `com.company.graphics`
- All classes related to database operations go in `com.company.database`
- All classes related to user interface go in `com.company.ui`

As your system grows larger, this organization becomes more important.

### 2. **Avoiding Naming Conflicts**
Without packages, you couldn't have two classes with the same name. With packages:
- `com.company.graphics.Circle` and `com.othercompany.graphics.Circle` can coexist
- The full name (including package) makes each class unique

### 3. **Access Control**
Packages provide another level of access control:
- Classes in the same package can access each other's package-private members
- Classes in different packages need public access to interact

You have learned about class encapsulation. But encapsulation can exist at different levels in your system. Packages are a way to encapsulate classes at a higher level. Later you may also encounter module encapsulation.

### 4. **Code Reuse**
Packages make it easy to:
- Share code between projects
- Distribute libraries
- Import only what you need

## Real-World Analogy

Think of packages like a **library system**:

- **Library** = Your project
- **Sections** = Packages (Fiction, Non-fiction, Science, History)
- **Books** = Classes (each book has a unique title within its section)
- **Catalog** = Import statements (how you find and access books)

You wouldn't put all books in one giant pile - you organize them by topic. Similarly, you don't put all classes in one folder - you organize them, often by functionality.

## Package Naming Convention

### alllowercase


Packages should be named in all lowercase. You may include underscores. For example:
```java
package com.company.project.graphics;
```



## Package Structure

### Directory Structure
Packages map directly to directory structure. If you open a folder in Windows (explorer), and navigate to your project, you will see the packages and classes, in the same structure as in IntelliJ. Most languages have some kind of grouping, similar to packages, though not always do they allign with folder structure.

```
src/
├── com/
│   └── company/
│       └── project/
│           ├── graphics/
│           │   ├── Circle.java
│           │   ├── Rectangle.java
│           │   └── Triangle.java
│           ├── database/
│           │   ├── DatabaseConnection.java
│           │   └── UserDAO.java
│           └── ui/
│               ├── MainWindow.java
│               └── Button.java
```


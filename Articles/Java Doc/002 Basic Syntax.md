# JavaDoc Basic Syntax

## The JavaDoc Comment Block

A JavaDoc comment starts with `/**` and ends with `*/`. It must be placed immediately before the element it documents (class, method, field, etc.).

```java
/**
 * This is a JavaDoc comment.
 * It can span multiple lines.
 */
public class Example {
    // class content
}
```

Notice the double asterisk `/**` at the start - this is what makes it a JavaDoc comment instead of a regular multi-line comment.

## Structure

The basic structure of a JavaDoc comment is:

```java
/**
 * Brief description - a short summary in one sentence.
 * 
 * Detailed description - additional information that provides
 * more context and explanation. This can span multiple lines
 * and paragraphs.
 * 
 * @tag description for the tag
 */
```

## Best Practices for Formatting

### Leading Asterisks
By convention, each line in a JavaDoc comment starts with an asterisk aligned with the first asterisk:

```java
/**
 * First line of comment.
 * Second line of comment.
 * Third line of comment.
 */
```

### First Sentence is Special
The first sentence (up to the first period followed by a space) is used as the summary in generated documentation. Make it concise and descriptive.

```java
/**
 * Calculates the total price including tax. The tax rate
 * is determined by the customer's location and the type
 * of product being purchased.
 */
```

## Where to Place JavaDoc

JavaDoc comments must be placed **immediately before** the element they document:

```java
/**
 * Represents a bank account with basic operations.
 */
public class BankAccount {
    
    /**
     * The current balance in the account.
     */
    private double balance;
    
    /**
     * Creates a new bank account with zero balance.
     */
    public BankAccount() {
        this.balance = 0.0;
    }
    
    /**
     * Deposits money into the account.
     */
    public void deposit(double amount) {
        balance += amount;
    }
}
```

## Simple Example

Here's a complete simple example:

```java
/**
 * Represents a student in the university system.
 */
public class Student {
    
    /**
     * The student's unique identification number.
     */
    private int studentId;
    
    /**
     * The student's full name.
     */
    private String name;
    
    /**
     * Creates a new student with the given ID and name.
     */
    public Student(int studentId, String name) {
        this.studentId = studentId;
        this.name = name;
    }
    
    /**
     * Returns the student's ID number.
     */
    public int getStudentId() {
        return studentId;
    }
    
    /**
     * Returns the student's name.
     */
    public String getName() {
        return name;
    }
}
```

In the next page, we'll learn about the special tags you can use in JavaDoc comments to provide more structured information.


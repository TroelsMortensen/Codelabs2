# Throws Keyword

The `throws` keyword is used in method signatures to declare that a method might throw certain types of exceptions. This is especially important for **checked exceptions**, which the Java compiler requires you to either catch or declare.

## Basic Syntax

```java
public void methodName() throws ExceptionType1, ExceptionType2 {
    // Method body
}
```

## Why Use `throws`?

### 1. **Compiler Requirement for Checked Exceptions**
Java requires you to handle checked exceptions. You have two options:
- **Catch** the exception in a try-catch block
- **Declare** it with `throws` in the method signature

### 2. **Documentation**
The `throws` clause documents what exceptions a method might throw, making your code more readable and maintainable.

### 3. **Method Contracts**
It establishes a contract: "This method might fail in these specific ways."

## Simple Example

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileReader {
    // This method declares that it might throw FileNotFoundException
    public static void readFile(String filename) throws FileNotFoundException {
        File file = new File(filename);
        Scanner scanner = new Scanner(file);
        
        while (scanner.hasNextLine()) {
            String line = scanner.nextLine();
            System.out.println(line);
        }
        
        scanner.close();
    }
    
    public static void main(String[] args) {
        try {
            readFile("data.txt");
        } catch (FileNotFoundException e) {
            System.out.println("File not found: " + e.getMessage());
        }
    }
}
```

## Multiple Exceptions

You can declare multiple exceptions in the `throws` clause:

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Scanner;

public class FileProcessor {
    // This method can throw multiple types of exceptions
    public static void processFile(String filename) 
            throws FileNotFoundException, IOException {
        
        File file = new File(filename);
        Scanner scanner = new Scanner(file);
        
        while (scanner.hasNextLine()) {
            String line = scanner.nextLine();
            // Some processing that might cause IOException
            if (line.length() > 1000) {
                throw new IOException("Line too long: " + line.length());
            }
            System.out.println(line);
        }
        
        scanner.close();
    }
    
    public static void main(String[] args) {
        try {
            processFile("data.txt");
        } catch (FileNotFoundException e) {
            System.out.println("File not found: " + e.getMessage());
        } catch (IOException e) {
            System.out.println("IO error: " + e.getMessage());
        }
    }
}
```

## Checked vs Unchecked Exceptions

### Checked Exceptions (Must be declared)
```java
import java.io.FileNotFoundException;

public class CheckedExceptionExample {
    // FileNotFoundException is checked - MUST be declared
    public static void readFile() throws FileNotFoundException {
        // This method might throw FileNotFoundException
        // The compiler requires us to declare it
    }
    
    public static void main(String[] args) {
        try {
            readFile();
        } catch (FileNotFoundException e) {
            System.out.println("File not found!");
        }
    }
}
```

### Unchecked Exceptions (Optional to declare)
```java
public class UncheckedExceptionExample {
    // RuntimeException is unchecked - optional to declare
    public static void divide(int a, int b) throws ArithmeticException {
        if (b == 0) {
            throw new ArithmeticException("Division by zero");
        }
        System.out.println("Result: " + (a / b));
    }
    
    public static void main(String[] args) {
        // We can call this without try-catch because ArithmeticException is unchecked
        divide(10, 2);
        
        // But we can still catch it if we want
        try {
            divide(10, 0);
        } catch (ArithmeticException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

## Method Overriding with `throws`

When overriding a method, you have specific rules about the `throws` clause:

### Rule 1: You can throw fewer exceptions
```java
class Parent {
    public void method() throws IOException, SQLException {
        // Parent method throws two exceptions
    }
}

class Child extends Parent {
    @Override
    public void method() throws IOException {
        // Child method only throws one exception - this is allowed
    }
}
```

### Rule 2: You can throw more specific exceptions
```java
class Parent {
    public void method() throws Exception {
        // Parent method throws general Exception
    }
}

class Child extends Parent {
    @Override
    public void method() throws IOException {
        // Child method throws more specific IOException - this is allowed
    }
}
```

### Rule 3: You cannot throw more general exceptions
```java
class Parent {
    public void method() throws IOException {
        // Parent method throws specific IOException
    }
}

class Child extends Parent {
    @Override
    public void method() throws Exception { // COMPILER ERROR!
        // Cannot throw more general Exception
    }
}
```

## Real-World Example: Database Operations

```java
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class DatabaseManager {
    // This method declares multiple SQL-related exceptions
    public static void executeQuery(String query) 
            throws SQLException, ClassNotFoundException {
        
        // Load database driver
        Class.forName("com.mysql.jdbc.Driver");
        
        // Create connection
        Connection conn = DriverManager.getConnection(
            "jdbc:mysql://localhost:3306/mydb", "username", "password");
        
        try {
            Statement stmt = conn.createStatement();
            stmt.executeQuery(query);
        } finally {
            conn.close();
        }
    }
    
    public static void main(String[] args) {
        try {
            executeQuery("SELECT * FROM users");
        } catch (SQLException e) {
            System.out.println("Database error: " + e.getMessage());
        } catch (ClassNotFoundException e) {
            System.out.println("Driver not found: " + e.getMessage());
        }
    }
}
```

## Network Operations Example

```java
import java.io.IOException;
import java.net.URL;
import java.net.URLConnection;
import java.util.Scanner;

public class NetworkReader {
    // This method declares that it might throw IOException
    public static String readFromUrl(String urlString) throws IOException {
        URL url = new URL(urlString);
        URLConnection connection = url.openConnection();
        
        Scanner scanner = new Scanner(connection.getInputStream());
        StringBuilder content = new StringBuilder();
        
        while (scanner.hasNextLine()) {
            content.append(scanner.nextLine()).append("\n");
        }
        
        scanner.close();
        return content.toString();
    }
    
    public static void main(String[] args) {
        try {
            String content = readFromUrl("http://example.com");
            System.out.println("Content length: " + content.length());
        } catch (IOException e) {
            System.out.println("Network error: " + e.getMessage());
        }
    }
}
```

## Custom Exception with `throws`

```java
// Custom exception class
class InsufficientFundsException extends Exception {
    public InsufficientFundsException(String message) {
        super(message);
    }
}

class BankAccount {
    private double balance;
    
    public BankAccount(double initialBalance) {
        this.balance = initialBalance;
    }
    
    // This method declares that it might throw our custom exception
    public void withdraw(double amount) throws InsufficientFundsException {
        if (amount > balance) {
            throw new InsufficientFundsException(
                "Insufficient funds. Balance: " + balance + ", Requested: " + amount);
        }
        balance -= amount;
    }
    
    public static void main(String[] args) {
        BankAccount account = new BankAccount(1000.0);
        
        try {
            account.withdraw(500.0);  // This will work
            account.withdraw(800.0);  // This will throw exception
        } catch (InsufficientFundsException e) {
            System.out.println("Withdrawal failed: " + e.getMessage());
        }
    }
}
```

## Best Practices

### 1. **Only Declare What You Actually Throw**
Don't declare exceptions that your method doesn't actually throw.

### 2. **Be Specific**
Declare specific exception types rather than the general `Exception` class.

### 3. **Document the Exceptions**
Use JavaDoc comments to explain when and why exceptions are thrown:

```java
/**
 * Reads data from a file.
 * @param filename the name of the file to read
 * @throws FileNotFoundException if the file doesn't exist
 * @throws IOException if there's an error reading the file
 */
public void readFile(String filename) throws FileNotFoundException, IOException {
    // Method implementation
}
```

### 4. **Consider Your Callers**
Think about whether callers should handle the exception or if you should handle it internally.

### 5. **Use Unchecked Exceptions for Programming Errors**
Use unchecked exceptions (RuntimeException subclasses) for programming errors that should be fixed in the code.

## Common Patterns

### Pattern 1: Propagate the Exception
```java
public void methodA() throws IOException {
    methodB(); // Let IOException propagate up
}

public void methodB() throws IOException {
    // Some operation that might throw IOException
}
```

### Pattern 2: Catch and Re-throw
```java
public void methodA() throws CustomException {
    try {
        methodB();
    } catch (IOException e) {
        throw new CustomException("Failed to process data", e);
    }
}
```

## What's Next?

Now that you understand the `throws` keyword, let's learn how to create your own custom exception classes for specific situations in your applications!

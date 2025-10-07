# Common Exception Scenarios

In real-world applications, you'll encounter many common exception scenarios. Let's explore the most frequent ones and learn how to handle them properly.

## 1. File Operations

### File Not Found
```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileOperations {
    public static void readFile(String filename) {
        try {
            File file = new File(filename);
            Scanner scanner = new Scanner(file);
            
            while (scanner.hasNextLine()) {
                String line = scanner.nextLine();
                System.out.println(line);
            }
            
            scanner.close();
        } catch (FileNotFoundException e) {
            System.out.println("File not found: " + filename);
            System.out.println("Please check the file path and try again.");
        }
    }
    
    public static void main(String[] args) {
        readFile("nonexistent.txt");
    }
}
```

### File Permission Issues
```java
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class FilePermissions {
    public static void writeToFile(String filename, String content) {
        try {
            File file = new File(filename);
            FileWriter writer = new FileWriter(file);
            writer.write(content);
            writer.close();
            System.out.println("File written successfully");
        } catch (IOException e) {
            System.out.println("Cannot write to file: " + e.getMessage());
            System.out.println("Check file permissions and disk space.");
        }
    }
    
    public static void main(String[] args) {
        writeToFile("readonly.txt", "This might fail if file is read-only");
    }
}
```

## 2. Network Operations

### Connection Timeout
```java
import java.io.IOException;
import java.net.URL;
import java.net.URLConnection;
import java.util.Scanner;

public class NetworkOperations {
    public static void readFromUrl(String urlString) {
        try {
            URL url = new URL(urlString);
            URLConnection connection = url.openConnection();
            connection.setConnectTimeout(5000); // 5 second timeout
            
            Scanner scanner = new Scanner(connection.getInputStream());
            while (scanner.hasNextLine()) {
                System.out.println(scanner.nextLine());
            }
            scanner.close();
            
        } catch (IOException e) {
            System.out.println("Network error: " + e.getMessage());
            System.out.println("Check your internet connection and try again.");
        }
    }
    
    public static void main(String[] args) {
        readFromUrl("http://example.com");
    }
}
```

## 3. User Input Validation

### Invalid Number Format
```java
import java.util.Scanner;

public class InputValidation {
    public static void getValidAge() {
        Scanner scanner = new Scanner(System.in);
        boolean validInput = false;
        
        while (!validInput) {
            try {
                System.out.print("Enter your age: ");
                int age = scanner.nextInt();
                
                if (age < 0 || age > 150) {
                    System.out.println("Please enter a valid age between 0 and 150.");
                    continue;
                }
                
                System.out.println("Your age is: " + age);
                validInput = true;
                
            } catch (Exception e) {
                System.out.println("Please enter a valid number for your age.");
                scanner.nextLine(); // Clear the invalid input
            }
        }
        
        scanner.close();
    }
    
    public static void main(String[] args) {
        getValidAge();
    }
}
```

### Input Mismatch
```java
import java.util.InputMismatchException;
import java.util.Scanner;

public class InputMismatchHandling {
    public static void getNumbers() {
        Scanner scanner = new Scanner(System.in);
        
        try {
            System.out.print("Enter first number: ");
            double num1 = scanner.nextDouble();
            
            System.out.print("Enter second number: ");
            double num2 = scanner.nextDouble();
            
            double result = num1 / num2;
            System.out.println("Result: " + result);
            
        } catch (InputMismatchException e) {
            System.out.println("Please enter valid numbers only.");
        } catch (ArithmeticException e) {
            System.out.println("Cannot divide by zero.");
        } finally {
            scanner.close();
        }
    }
    
    public static void main(String[] args) {
        getNumbers();
    }
}
```

## 4. Array and Collection Operations

### Array Index Out of Bounds
```java
public class ArrayOperations {
    public static void safeArrayAccess(int[] array, int index) {
        try {
            int value = array[index];
            System.out.println("Value at index " + index + ": " + value);
        } catch (ArrayIndexOutOfBoundsException e) {
            System.out.println("Index " + index + " is out of bounds.");
            System.out.println("Array has " + array.length + " elements (indices 0-" + (array.length - 1) + ")");
        }
    }
    
    public static void main(String[] args) {
        int[] numbers = {10, 20, 30, 40, 50};
        safeArrayAccess(numbers, 2);  // Valid
        safeArrayAccess(numbers, 10); // Invalid
    }
}
```

### Null Pointer in Collections
```java
import java.util.ArrayList;
import java.util.List;

public class CollectionOperations {
    public static void processList(List<String> list) {
        if (list == null) {
            System.out.println("List is null. Cannot process.");
            return;
        }
        
        try {
            for (String item : list) {
                if (item != null) {
                    System.out.println("Processing: " + item.toUpperCase());
                } else {
                    System.out.println("Skipping null item");
                }
            }
        } catch (Exception e) {
            System.out.println("Error processing list: " + e.getMessage());
        }
    }
    
    public static void main(String[] args) {
        List<String> items = new ArrayList<>();
        items.add("apple");
        items.add(null);
        items.add("banana");
        
        processList(items);
        processList(null); // Test with null list
    }
}
```

## 5. Database Operations

### SQL Exceptions
```java
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class DatabaseOperations {
    public static void executeQuery(String query) {
        Connection conn = null;
        Statement stmt = null;
        
        try {
            // Simulate database connection
            conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/test", "user", "pass");
            stmt = conn.createStatement();
            stmt.executeQuery(query);
            System.out.println("Query executed successfully");
            
        } catch (SQLException e) {
            System.out.println("Database error: " + e.getMessage());
            System.out.println("Error code: " + e.getErrorCode());
            System.out.println("SQL state: " + e.getSQLState());
            
            // Handle specific SQL errors
            if (e.getErrorCode() == 1146) {
                System.out.println("Table does not exist");
            } else if (e.getErrorCode() == 1054) {
                System.out.println("Unknown column in query");
            }
            
        } finally {
            try {
                if (stmt != null) stmt.close();
                if (conn != null) conn.close();
            } catch (SQLException e) {
                System.out.println("Error closing database resources: " + e.getMessage());
            }
        }
    }
    
    public static void main(String[] args) {
        executeQuery("SELECT * FROM nonexistent_table");
    }
}
```

## 6. Parsing Operations

### Number Format Exception
```java
public class ParsingOperations {
    public static void parseNumbers(String[] inputs) {
        for (String input : inputs) {
            try {
                int number = Integer.parseInt(input);
                System.out.println("Parsed: " + number);
            } catch (NumberFormatException e) {
                System.out.println("Cannot parse '" + input + "' as an integer");
                System.out.println("Please enter a valid number");
            }
        }
    }
    
    public static void parseDouble(String input) {
        try {
            double number = Double.parseDouble(input);
            System.out.println("Parsed double: " + number);
        } catch (NumberFormatException e) {
            System.out.println("Invalid number format: " + input);
            System.out.println("Expected format: digits with optional decimal point");
        }
    }
    
    public static void main(String[] args) {
        String[] testInputs = {"123", "45.67", "abc", "12.34.56", ""};
        parseNumbers(testInputs);
        
        System.out.println("\nTesting double parsing:");
        parseDouble("3.14159");
        parseDouble("not-a-number");
    }
}
```

## 7. Resource Management

### Try-With-Resources
```java
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class ResourceManagement {
    public static void copyFile(String sourceFile, String destFile) {
        try (Scanner scanner = new Scanner(new File(sourceFile));
             FileWriter writer = new FileWriter(destFile)) {
            
            while (scanner.hasNextLine()) {
                String line = scanner.nextLine();
                writer.write(line + "\n");
            }
            
            System.out.println("File copied successfully");
            
        } catch (IOException e) {
            System.out.println("Error copying file: " + e.getMessage());
        }
        // Resources are automatically closed here
    }
    
    public static void main(String[] args) {
        copyFile("source.txt", "destination.txt");
    }
}
```

## 8. Business Logic Validation

### Custom Business Exceptions
```java
// Custom exception for business logic
class InvalidOrderException extends Exception {
    private String orderId;
    private String reason;
    
    public InvalidOrderException(String orderId, String reason) {
        super("Invalid order: " + orderId + " - " + reason);
        this.orderId = orderId;
        this.reason = reason;
    }
    
    public String getOrderId() { return orderId; }
    public String getReason() { return reason; }
}

public class OrderProcessing {
    public static void processOrder(String orderId, int quantity, double price) 
            throws InvalidOrderException {
        
        if (orderId == null || orderId.trim().isEmpty()) {
            throw new InvalidOrderException(orderId, "Order ID cannot be empty");
        }
        
        if (quantity <= 0) {
            throw new InvalidOrderException(orderId, "Quantity must be positive");
        }
        
        if (price < 0) {
            throw new InvalidOrderException(orderId, "Price cannot be negative");
        }
        
        if (quantity > 100) {
            throw new InvalidOrderException(orderId, "Quantity exceeds maximum limit of 100");
        }
        
        System.out.println("Order " + orderId + " processed successfully");
    }
    
    public static void main(String[] args) {
        try {
            processOrder("ORD001", 5, 25.99);
            processOrder("", 10, 15.50); // This will throw exception
        } catch (InvalidOrderException e) {
            System.out.println("Order processing failed:");
            System.out.println("  Order ID: " + e.getOrderId());
            System.out.println("  Reason: " + e.getReason());
        }
    }
}
```

## 9. Concurrent Operations

### Thread Interruption
```java
public class ConcurrentOperations {
    public static void longRunningTask() {
        try {
            for (int i = 0; i < 100; i++) {
                Thread.sleep(100); // Simulate work
                System.out.println("Working... " + i);
                
                // Check if thread was interrupted
                if (Thread.currentThread().isInterrupted()) {
                    throw new InterruptedException("Task was interrupted");
                }
            }
            System.out.println("Task completed successfully");
            
        } catch (InterruptedException e) {
            System.out.println("Task interrupted: " + e.getMessage());
            Thread.currentThread().interrupt(); // Restore interrupt status
        }
    }
    
    public static void main(String[] args) {
        Thread worker = new Thread(() -> longRunningTask());
        worker.start();
        
        // Interrupt the thread after 2 seconds
        try {
            Thread.sleep(2000);
            worker.interrupt();
        } catch (InterruptedException e) {
            System.out.println("Main thread interrupted");
        }
    }
}
```

## 10. Configuration and Environment Issues

### Missing Configuration
```java
import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class ConfigurationHandling {
    public static void loadConfiguration(String configFile) {
        Properties config = new Properties();
        
        try (FileInputStream fis = new FileInputStream(configFile)) {
            config.load(fis);
            
            String dbUrl = config.getProperty("database.url");
            String dbUser = config.getProperty("database.user");
            
            if (dbUrl == null) {
                throw new RuntimeException("Missing required configuration: database.url");
            }
            if (dbUser == null) {
                throw new RuntimeException("Missing required configuration: database.user");
            }
            
            System.out.println("Configuration loaded successfully");
            System.out.println("Database URL: " + dbUrl);
            System.out.println("Database User: " + dbUser);
            
        } catch (IOException e) {
            System.out.println("Cannot load configuration file: " + configFile);
            System.out.println("Using default configuration");
            // Fall back to default values
        } catch (RuntimeException e) {
            System.out.println("Configuration error: " + e.getMessage());
            System.out.println("Please check your configuration file");
        }
    }
    
    public static void main(String[] args) {
        loadConfiguration("config.properties");
    }
}
```

## Key Takeaways

1. **Always validate input** before processing
2. **Provide meaningful error messages** to help users understand what went wrong
3. **Use try-with-resources** for automatic resource management
4. **Handle specific exceptions** rather than catching everything
5. **Log errors appropriately** for debugging
6. **Provide fallback behavior** when possible
7. **Validate configuration** and environment setup
8. **Handle network and I/O operations** with appropriate timeouts
9. **Use custom exceptions** for business logic validation
10. **Always clean up resources** in finally blocks or try-with-resources

These common scenarios will help you build robust applications that handle errors gracefully and provide good user experience!

## What's Next?

Now that you've seen common exception scenarios, let's put your knowledge to practice with some hands-on exercises!

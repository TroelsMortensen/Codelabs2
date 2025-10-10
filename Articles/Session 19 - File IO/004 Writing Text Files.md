# Writing Text to Files

Now let's learn how to write text data to files using Java. This is one of the most common file operations you'll perform.

## Basic Text Writing

### Using FileWriter

`FileWriter` is the simplest way to write text to a file:

```java
import java.io.FileWriter;
import java.io.IOException;

public class TextWriter {
    public static void main(String[] args) {
        try {
            FileWriter writer = new FileWriter("output.txt");
            writer.write("Hello World!");
            writer.write("\nThis is line 2");
            writer.write("\nThis is line 3");
            writer.close();
            System.out.println("File written successfully!");
        } catch (IOException e) {
            System.out.println("Error writing file: " + e.getMessage());
        }
    }
}
```

### Output File Content:
```
Hello World!
This is line 2
This is line 3
```

## Better Approach: Using PrintWriter

`PrintWriter` provides more convenient methods for writing formatted text:

```java
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;

public class BetterTextWriter {
    public static void main(String[] args) {
        try {
            FileWriter fileWriter = new FileWriter("greeting.txt");
            PrintWriter printWriter = new PrintWriter(fileWriter);
            
            printWriter.println("Welcome to Java File I/O!");
            printWriter.println("Today's date: " + java.time.LocalDate.now());
            printWriter.printf("Temperature: %.1f degrees%n", 23.5);
            printWriter.println("Status: Active");
            
            printWriter.close();
            System.out.println("File written successfully!");
            
        } catch (IOException e) {
            System.out.println("Error writing file: " + e.getMessage());
        }
    }
}
```

### Output File Content:
```
Welcome to Java File I/O!
Today's date: 2024-01-15
Temperature: 23.5 degrees
Status: Active
```

## Using Try-With-Resources

The recommended approach is to use try-with-resources for automatic resource management:

```java
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;

public class SafeTextWriter {
    public static void main(String[] args) {
        try (FileWriter fileWriter = new FileWriter("data.txt");
             PrintWriter printWriter = new PrintWriter(fileWriter)) {
            
            printWriter.println("Name: John Doe");
            printWriter.println("Age: 25");
            printWriter.println("Occupation: Software Developer");
            printWriter.println("Location: New York");
            
        } catch (IOException e) {
            System.out.println("Error writing file: " + e.getMessage());
        }
        // Resources are automatically closed here
    }
}
```

## Writing Different Data Types

### Writing Various Data Types
```java
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;
import java.time.LocalDateTime;

public class DataTypeWriter {
    public static void main(String[] args) {
        try (PrintWriter writer = new PrintWriter(new FileWriter("data_types.txt"))) {
            
            // String
            writer.println("Text: Hello World");
            
            // Integer
            int number = 42;
            writer.println("Integer: " + number);
            
            // Double
            double price = 19.99;
            writer.println("Price: $" + price);
            writer.printf("Formatted Price: $%.2f%n", price);
            
            // Boolean
            boolean isActive = true;
            writer.println("Active: " + isActive);
            
            // Date/Time
            LocalDateTime now = LocalDateTime.now();
            writer.println("Current time: " + now);
            
            // Array
            String[] colors = {"Red", "Green", "Blue"};
            writer.println("Colors: " + String.join(", ", colors));
            
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

## Writing Structured Data

### Writing CSV Format
```java
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;

public class CSVWriter {
    public static void main(String[] args) {
        try (PrintWriter writer = new PrintWriter(new FileWriter("students.csv"))) {
            
            // Write header
            writer.println("Name,Age,Grade,Subject");
            
            // Write data rows
            writer.println("Alice Johnson,20,A,Mathematics");
            writer.println("Bob Smith,22,B,Physics");
            writer.println("Carol Davis,19,A+,Chemistry");
            writer.println("David Wilson,21,B+,Biology");
            
        } catch (IOException e) {
            System.out.println("Error writing CSV: " + e.getMessage());
        }
    }
}
```

### Output File Content:
```
Name,Age,Grade,Subject
Alice Johnson,20,A,Mathematics
Bob Smith,22,B,Physics
Carol Davis,19,A+,Chemistry
David Wilson,21,B+,Biology
```

## Common FileWriter Methods

| Method | Description |
|--------|-------------|
| `write(String)` | Writes a string to the file |
| `write(char[])` | Writes a character array |
| `write(int)` | Writes a single character |
| `flush()` | Forces any buffered data to be written |
| `close()` | Closes the file writer |

## Common PrintWriter Methods

| Method | Description |
|--------|-------------|
| `print(String)` | Prints a string without newline |
| `println(String)` | Prints a string with newline |
| `printf(String, Object...)` | Prints formatted string |
| `flush()` | Forces any buffered data to be written |
| `close()` | Closes the print writer |

## Error Handling Best Practices

### Always Handle IOException
```java
try {
    FileWriter writer = new FileWriter("important.txt");
    writer.write("Critical data");
    writer.close();
} catch (IOException e) {
    System.err.println("Failed to write file: " + e.getMessage());
    e.printStackTrace();
}
```

### Check if File Was Created Successfully
```java
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class FileCheck {
    public static void main(String[] args) {
        String filename = "test.txt";
        
        try (FileWriter writer = new FileWriter(filename)) {
            writer.write("Test content");
        } catch (IOException e) {
            System.out.println("Error writing file: " + e.getMessage());
            return;
        }
        
        // Check if file exists and has content
        File file = new File(filename);
        if (file.exists() && file.length() > 0) {
            System.out.println("File created successfully!");
            System.out.println("File size: " + file.length() + " bytes");
        } else {
            System.out.println("File creation failed!");
        }
    }
}
```

## What's Next?

Now that you know how to write text to files, let's practice with an exercise! You'll create a console application that can write different types of data to files.

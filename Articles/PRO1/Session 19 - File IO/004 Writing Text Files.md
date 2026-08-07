# Writing Text to Files

Now let's learn how to write text data to files using Java. This is one of the most common file operations you'll perform. A lot of data is in some kind of text-format, readable by humans. And within "readable text-format", we have many types for formatting, where the structure have important meaning. Examples are:

- CSV (Comma Separated Values)
- JSON (JavaScript Object Notation)
- XML (eXtensible Markup Language)
- Properties (Configuration Files)
- Log files
- Configuration files
- Data exchanges
- ... and many more

And all of these are text-based formats, but with different structures and meanings. They are written in plain text, meaning you can also easily open the file in a text-editor, and manually edit the data. This is sometimes very useful.

## Basic Text Writing

We will not yet concern ourselves with the different formats, but for now just put text into a file. That text _could_ be in one format or other, but that does not change _how_ the text is written to the file.

### Using FileWriter

`FileWriter` is the simplest way to write text to a file. Behind the scenes, it is using a stream to write the text to the file.\
We loose the flexibility of polymorphism this way, i.e. we cannot easily change _where_ the data is coming from, which is the point of using streams. But, it is much simpler, and a good starting point. We don't have to manually convert our text to bytes, and write them to the file. This is handled and hidden from us.

Here is an example of how to write text to a file using `FileWriter`.

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

And an explanation of the code:

- We create a `FileWriter` object iun line 7, and pass the filename, `output.txt`, to the constructor.
- We write the text to the file using the `write` method in line 8-10. This will _append_ the text to the file. The `\n` is a newline character, which is used to create a new line in the file.
- We close the file using the `close` method in line 11. This is important to do, otherwise the data will not be written to the file!
- We must wrap the file writing in a "try-catch" block, to handle the `IOException` that can be thrown if the file cannot be written to.
  - Maybe you are not allowed to create a file at the given location.
  - Or an existing file is read-only.
  - Or the disk is full.
  - Or the file is already open by another process.
  - Or the file is too large.
  - Or the file is corrupted.
  - Or the file is not a text file.
  - Or the file is not a valid file.
  - Or... you get, stuff goes wrong occasionally.

This is the simplest way to write text to a file, and it is a good starting point.

### Output File Content:
```
Hello World!
This is line 2
This is line 3
```

## Easier Approach: Using PrintWriter

Another class is the `PrintWriter` class. This is a more flexible way to write text to a file. It _uses_ a `FileWriter` internally, but it provides more convenient methods for writing formatted text.

Here is an example of how to write text to a file using `PrintWriter`.\
Notice the `PrintWriter` class has a few convenient methods:

- `println(String)`: Writes a string to the file, and automatically adds a newline character.
- `printf(String, Object...)`: Writes a formatted string to the file. The `%n` is a newline character.
- `close()`: Closes the file writer.

```java
import java.io.PrintWriter;
import java.io.IOException;

public class TextWriter {
    public static void main(String[] args) {
        try 
        {
            FileWriter fileWriter = new FileWriter("greeting.txt");
            PrintWriter printWriter = new PrintWriter(fileWriter);
            
            printWriter.println("Welcome to Java File I/O!");
            printWriter.println("Today's date: " + java.time.LocalDate.now());
            printWriter.printf("Temperature: %.1f degrees%n", 23.5);
            printWriter.println("Status: Active");
            
            printWriter.close();
            System.out.println("File written successfully!");
            
        } 
        catch (IOException e) 
        {
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

Notice above, how you must manually `.close()` the file writer. This is a bit of a pain, and it is easy to forget. There are several types in Java, which must be closed, or in some other way "cleaned up" after use.	

The recommended approach is to use "try-with-resources" for automatic resource management.

Notice the change compared to the previous example. Now the "try" part has parentheses, and the `PrintWriter` object is created inside the parentheses. This means the `PrintWriter` object will be closed automatically when the `try` block is exited, in line 18, at the closing brace.

```java{3,11}
public class SafeTextWriter {
    public static void main(String[] args) {
        try (PrintWriter printWriter = new PrintWriter(new FileWriter("greeting.txt"))) 
        {
            
            printWriter.println("Welcome to Java File I/O!");
            printWriter.println("Today's date: " + java.time.LocalDate.now());
            printWriter.printf("Temperature: %.1f degrees%n", 23.5);
            printWriter.println("Status: Active");
                         
            // printWriter.close(); no longer needed, as it is closed automatically when the try block is exited
            System.out.println("File written successfully!");
            
        } 
        catch (IOException e) 
        {
            System.out.println("Error writing file: " + e.getMessage());
        }
        // Resources are automatically closed here
    }
}
```

## Writing Different Data Types

Sometimes you want to write different data types to a file. For example, you want to write a string, an integer, a double, a boolean, a date/time, and an array. Here is an example of how to do this. Similar to how the `System.out.println()` method works by using the `toString()` method to convert the data to a string, this also happens here.

The `println()` method has overloads to handle different data types.

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



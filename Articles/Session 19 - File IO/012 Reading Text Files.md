# Reading Text Files

Now let's learn how to read text data from files. Java provides several ways to read files, from simple byte-by-byte reading to high-level line-by-line reading.

## Basic Text Reading

### Using FileReader

LoL, you can use this class, but that's just annoying. Let's skip it.

## Better Approach: Using BufferedReader

`BufferedReader` provides more convenient methods for reading text. It allows you to read text from a file line by line.
This will not read all the content at once, but instead scan the text file line by line, basically only looking at one line at a time. This is how we can read massively large files, without running out of memory. Only one line at a time is loaded into memory.

Again, we use the try-with-resources approach, where we create a new BufferedReader object, and pass a FileReader object to the constructor. The FileReader object is responsible for reading the file, and the BufferedReader object is responsible for reading the file line by line.\
The BufferedReader adds that extra level of abstraction and usability, making things easier for us, the developers.

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class BetterTextReader {
    public static void main(String[] args) {
        try (BufferedReader reader = new BufferedReader(new FileReader("data.txt"))) {
            String line;
            while ((line = reader.readLine()) != null) {
                System.out.println(line);
            }
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
    }
}
```

## Modern Approach: Files.readAllLines()

Java 8+ provides convenient methods for reading entire files. This can simplify the above example, but if the file is too large, it will still cause memory issues.

You have two methods:
- 
- `Files.readAllLines()` - reads all lines at once and returns a list of strings
- `Files.readString()` - reads the entire file as a single string


### Reading all lines at once

Let's use the `Files.readAllLines()` method for this example.

```java{10}
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class ModernFileReader {
    public static void main(String[] args) {
        try {
            // Read all lines at once
            List<String> lines = Files.readAllLines(Paths.get("data.txt"));
            
            System.out.println("File contains " + lines.size() + " lines:");
            for (int i = 0; i < lines.size(); i++) {
                System.out.println((i + 1) + ": " + lines.get(i));
            }
            
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
    }
}
```

### Reading Entire File as String

This is a very similar example, but we use the `Files.readString()` method instead to get the entire file content as a single string.

```java{9}
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class StringFileReader {
    public static void main(String[] args) {
        try {
            // Read entire file as a single string
            String content = Files.readString(Paths.get("data.txt"));
            System.out.println("File content:");
            System.out.println(content);
             
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
    }
}
```



## Common Reading Methods Summary

| Method | Use Case | Memory Usage | Performance |
|--------|----------|--------------|-------------|
| `FileReader.read()` | Character by character | Low | Slow |
| `BufferedReader.readLine()` | Line by line | Medium | Good |
| `Files.readAllLines()` | Entire file at once | High | Fast (small files) |
| `Files.readString()` | Entire file as string | High | Fast (small files) |


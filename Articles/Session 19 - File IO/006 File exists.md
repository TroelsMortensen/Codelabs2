# Testing if a File Exists

You can check if a file already exists before trying to create, read or write to it. This helps avoid errors and allows you to make decisions about what to do with existing files.

## Files class

The `Files` class is a modern way to work with files in Java. It is part of the `java.nio.file` package, and it is a more flexible way to work with files than the `File` class. It contains a lot of helper methods for working with files and directories.

## Using Files.exists()

The modern approach using `Files` class' `exists` method. It requires an argument of type `Path`, which is a new type in Java 7. It is a path to a file or directory.

```java
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class ModernFileExists {
    public static void main(String[] args) {
        Path filePath = Paths.get("data.txt");
        
        if (Files.exists(filePath)) {
            System.out.println("File exists!");
        } else {
            System.out.println("File does not exist.");
        }
    }
}
```

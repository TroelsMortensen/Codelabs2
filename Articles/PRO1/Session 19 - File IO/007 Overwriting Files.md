# Overwriting Existing Files

When you write to a file that already exists, Java will generally**overwrite** the existing content by default (depends on which class you use to write to the file). This means the old content is completely replaced with the new content, and that is not always ideal.

## Default Behavior: Overwriting

This example contains two parts:
1. Creating a file with some content
2. Writing to the same file again, overwriting the existing content

This is apparent in the two separate try-with-resources blocks.

After each try-block ends, the `PrintWriter` object is closed, and we can no longer print new lines to the file. This is only possible as long as the PrintWriter object is open.

```java{8-14,17-22}
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;

public class OverwriteExample {
    public static void main(String[] args) {
        // First, create a file with some content
        try (PrintWriter writer = new PrintWriter(new FileWriter("example.txt"))) {
            writer.println("Original content");
            writer.println("This is the first version");
            writer.println("Line 3");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
        
        // Later, (over)write to the same file again, by opening it again
        try (PrintWriter writer = new PrintWriter(new FileWriter("example.txt"))) {
            writer.println("New content");
            writer.println("This overwrites everything");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

### Result:
The file `example.txt` will contain:
```
New content
This overwrites everything
```

**The original content is completely lost!**

However! You may not always want to overwrite the file. You may want to append to the file. You won't believe what happens next!
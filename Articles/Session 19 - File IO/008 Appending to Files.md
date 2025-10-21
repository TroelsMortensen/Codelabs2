# Appending to Existing Files

Sometimes you want to **add content** to an existing file instead of overwriting it. This is called **appending**. Appending adds new content to the end of the file while preserving the existing content.

## Appending vs Overwriting

### Overwriting (Default Behavior)

This deletes the original content, and writes the new content.

First, we create a file with some content:
```java
// Original file content
try (PrintWriter writer = new PrintWriter(new FileWriter("log.txt"))) {
    writer.println("2024-01-15 10:00:00 - Application started");
}
```

Then, we overwrite the file with new content:

```java
// Overwrite - original content is lost
try (PrintWriter writer = new PrintWriter(new FileWriter("log.txt"))) {
    writer.println("2024-01-15 11:00:00 - Application restarted");
}
```

**Result:**
```
2024-01-15 11:00:00 - Application restarted
```

Notice the timestamp is from the write operation, not the original content.

### Appending (Preserves Existing Content)

To append, i.e. add new content to the end of the file, while preserving the original content, we use the second parameter in the `FileWriter` constructor: `true`.

First, we create a file with some content:

```java
// Original file content
try (PrintWriter writer = new PrintWriter(new FileWriter("log.txt"))) {
    writer.println("2024-01-15 10:00:00 - Application started");
}
```

Then, we append to the file. Notice the second parameter is `true`, which means append to the file.

```java
// Append - original content is preserved
try (PrintWriter writer = new PrintWriter(new FileWriter("log.txt", true))) {
    writer.println("2024-01-15 11:00:00 - Application restarted");
}
```

**Result:**
```
2024-01-15 10:00:00 - Application started
2024-01-15 11:00:00 - Application restarted
```

## The Append Parameter

The key to appending is the second parameter in the `FileWriter` constructor:

```java
FileWriter(String filename, boolean append)
```

- `append = false` (default): **Overwrite** the file
- `append = true`: **Append** to the file

## Log files

It is often useful to append rather than overwrite. Log files are often used in systems, to store data about what has happened, especially in case of crashes. Have you ever had an application crash on you, and a popup asking if you would like to send the log file to the developer? That's because the log file contains information about the actions that led to the crash, as well as information about any exceptions or stacktraces.

In case of log files, we clearly want to keep appending data, rather than overwriting all the time.

## Appending vs Creating New Files

### When to Append:
- **Log files** - continuously growing records
- **Data collection** - adding new entries
- **User activity** - tracking user actions
- **Backup logs** - recording backup operations
- **Error logs** - accumulating error information

### When NOT to Append:
- **Configuration files** - should be complete and clean
- **Reports** - should be self-contained
- **Temporary files** - should be replaced each time
- **Data processing** - intermediate results should be overwritten

## PrintWriter vs FileWriter

The above shows examples with the FileWriter class. The PrintWriter class is a wrapper around the FileWriter class, and it provides more convenient methods for writing text to a file.

The PrintWriter can also append text to a file, using it's `append` method. You can explore this yourself, if you want to.

## Insertion?

What about inserting a new line, in the middle of the file? This is not really possible, and instead we can read the file into a list of lines, insert the new line, and then write the list back to the file. Here is an example:

```java
import java.io.PrintWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class InsertInMiddle {
    public static void main(String[] args) {
        String filename = "data.txt";
        
        try {
            // Read all lines from the file
            List<String> lines = Files.readAllLines(Paths.get(filename));
            
            // Insert new line at position 2 (0-based index)
            lines.add(2, "This line was inserted in the middle!");
            
            // Write all lines back to the file
            try (PrintWriter writer = new PrintWriter(new FileWriter(filename))) {
                for (String line : lines) {
                    writer.println(line);
                }
            }
            
            System.out.println("Line inserted successfully!");
            
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

If the file is very large, you may need to use a stream instead, which can read one line at a time. This way you can line by line transfer a line from one file (source) to another (destination). At the right point, you can insert the new line in the destination file, and then continue transferring the rest of the lines.

I leave this as an exercise for you to explore.
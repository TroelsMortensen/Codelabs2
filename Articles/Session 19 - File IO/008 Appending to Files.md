# Appending to Existing Files

Sometimes you want to **add content** to an existing file instead of overwriting it. This is called **appending**. Appending adds new content to the end of the file while preserving the existing content.

## Appending vs Overwriting

### Overwriting (Default Behavior)
```java
// Original file content
try (PrintWriter writer = new PrintWriter(new FileWriter("log.txt"))) {
    writer.println("2024-01-15 10:00:00 - Application started");
}
```

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

### Appending (Preserves Existing Content)
```java
// Original file content
try (PrintWriter writer = new PrintWriter(new FileWriter("log.txt"))) {
    writer.println("2024-01-15 10:00:00 - Application started");
}
```

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

## Basic Appending Examples

### Example 1: Simple Text Appending
```java
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;

public class SimpleAppend {
    public static void main(String[] args) {
        // Create initial file
        try (PrintWriter writer = new PrintWriter(new FileWriter("notes.txt"))) {
            writer.println("=== MY NOTES ===");
            writer.println("Meeting notes from Monday");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
        
        // Append to the file
        try (PrintWriter writer = new PrintWriter(new FileWriter("notes.txt", true))) {
            writer.println();
            writer.println("Additional notes from Tuesday");
            writer.println("Remember to follow up on project");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

**Final file content:**
```
=== MY NOTES ===
Meeting notes from Monday

Additional notes from Tuesday
Remember to follow up on project
```

### Example 2: Log File Appending
```java
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class LogAppender {
    private static final String LOG_FILE = "application.log";
    private static final DateTimeFormatter FORMATTER = 
        DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
    
    public static void logInfo(String message) {
        try (PrintWriter writer = new PrintWriter(new FileWriter(LOG_FILE, true))) {
            writer.println(LocalDateTime.now().format(FORMATTER) + " [INFO] " + message);
        } catch (IOException e) {
            System.err.println("Error writing to log: " + e.getMessage());
        }
    }
    
    public static void logError(String message) {
        try (PrintWriter writer = new PrintWriter(new FileWriter(LOG_FILE, true))) {
            writer.println(LocalDateTime.now().format(FORMATTER) + " [ERROR] " + message);
        } catch (IOException e) {
            System.err.println("Error writing to log: " + e.getMessage());
        }
    }
    
    public static void main(String[] args) {
        logInfo("Application started");
        logInfo("Database connection established");
        logError("Failed to load configuration file");
        logInfo("Application shutdown");
    }
}
```

**Log file content:**
```
2024-01-15 10:30:15 [INFO] Application started
2024-01-15 10:30:16 [INFO] Database connection established
2024-01-15 10:30:17 [ERROR] Failed to load configuration file
2024-01-15 10:30:20 [INFO] Application shutdown
```

### Example 3: Data Collection Appending
```java
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;
import java.util.Scanner;

public class DataCollector {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String filename = "survey_data.csv";
        
        // Write header if file doesn't exist
        if (!new java.io.File(filename).exists()) {
            try (PrintWriter writer = new PrintWriter(new FileWriter(filename))) {
                writer.println("Name,Age,City,Occupation");
            } catch (IOException e) {
                System.out.println("Error creating file: " + e.getMessage());
                return;
            }
        }
        
        // Collect and append data
        while (true) {
            System.out.println("Enter survey data (or 'quit' to exit):");
            System.out.print("Name: ");
            String name = scanner.nextLine();
            
            if (name.equalsIgnoreCase("quit")) {
                break;
            }
            
            System.out.print("Age: ");
            String age = scanner.nextLine();
            
            System.out.print("City: ");
            String city = scanner.nextLine();
            
            System.out.print("Occupation: ");
            String occupation = scanner.nextLine();
            
            // Append to file
            try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
                writer.printf("%s,%s,%s,%s%n", name, age, city, occupation);
                System.out.println("Data saved!");
            } catch (IOException e) {
                System.out.println("Error saving data: " + e.getMessage());
            }
        }
        
        scanner.close();
    }
}
```

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

## Advanced Appending Patterns

### Pattern 1: Conditional Appending
```java
public class ConditionalAppender {
    public static void appendIfNew(String filename, String content) {
        try {
            // Read existing content
            String existingContent = "";
            if (new File(filename).exists()) {
                existingContent = Files.readString(Paths.get(filename));
            }
            
            // Only append if content is not already there
            if (!existingContent.contains(content)) {
                try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
                    writer.println(content);
                }
            }
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

### Pattern 2: Structured Appending
```java
public class StructuredAppender {
    public static void appendWithSeparator(String filename, String content) {
        try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
            // Add separator if file has content
            if (new File(filename).length() > 0) {
                writer.println("---");
            }
            writer.println(content);
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

### Pattern 3: Timestamped Appending
```java
public class TimestampedAppender {
    public static void appendWithTimestamp(String filename, String content) {
        try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
            String timestamp = LocalDateTime.now().format(
                DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
            writer.printf("[%s] %s%n", timestamp, content);
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

## File Appending Best Practices

### 1. **Always Use Try-With-Resources**
```java
// Good
try (PrintWriter writer = new PrintWriter(new FileWriter("file.txt", true))) {
    writer.println("New content");
} catch (IOException e) {
    // Handle error
}

// Bad - resource leak
PrintWriter writer = new PrintWriter(new FileWriter("file.txt", true));
writer.println("New content");
// Missing close()!
```

### 2. **Handle File Creation**
```java
public static void safeAppend(String filename, String content) {
    try {
        // Create parent directories if they don't exist
        File file = new File(filename);
        file.getParentFile().mkdirs();
        
        // Append content
        try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
            writer.println(content);
        }
    } catch (IOException e) {
        System.out.println("Error appending to file: " + e.getMessage());
    }
}
```

### 3. **Add Appropriate Separators**
```java
public static void appendWithSeparator(String filename, String content) {
    try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
        File file = new File(filename);
        
        // Add newline before content if file exists and has content
        if (file.exists() && file.length() > 0) {
            writer.println();
        }
        
        writer.println(content);
    } catch (IOException e) {
        System.out.println("Error: " + e.getMessage());
    }
}
```

### 4. **Consider File Size**
```java
public static void appendWithSizeCheck(String filename, String content) {
    File file = new File(filename);
    
    // Check if file is getting too large (e.g., 10MB)
    if (file.exists() && file.length() > 10 * 1024 * 1024) {
        System.out.println("Warning: File is getting large (" + file.length() + " bytes)");
    }
    
    try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
        writer.println(content);
    } catch (IOException e) {
        System.out.println("Error: " + e.getMessage());
    }
}
```

## What's Next?

Now that you understand how to append to files, let's practice with an exercise that combines file writing, overwriting, and appending! You'll create a more sophisticated file manager that can handle all these operations.

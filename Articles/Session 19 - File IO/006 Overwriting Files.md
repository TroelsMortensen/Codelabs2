# Overwriting Existing Files

When you write to a file that already exists, Java will **overwrite** the existing content by default. This means the old content is completely replaced with the new content.

## Default Behavior: Overwriting

```java
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
        
        // Later, write to the same file again
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

## File Overwriting in Detail

### What Happens During Overwrite:

1. **File is opened** for writing
2. **File pointer** is positioned at the beginning (byte 0)
3. **New content** is written from the beginning
4. **Old content** beyond the new content is still there (but not accessible)

### Example with Different Content Lengths:

```java
// Original file content (3 lines)
try (PrintWriter writer = new PrintWriter(new FileWriter("demo.txt"))) {
    writer.println("Line 1");
    writer.println("Line 2");
    writer.println("Line 3");
    writer.println("Line 4");
}
```

```java
// Overwrite with shorter content (2 lines)
try (PrintWriter writer = new PrintWriter(new FileWriter("demo.txt"))) {
    writer.println("New Line 1");
    writer.println("New Line 2");
}
```

### Result:
```
New Line 1
New Line 2
Line 3      ← This old content might still be there!
Line 4
```

## Controlling Overwrite Behavior

### Method 1: Check if File Exists First

```java
import java.io.File;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;
import java.util.Scanner;

public class SafeOverwrite {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String filename = "data.txt";
        
        File file = new File(filename);
        
        if (file.exists()) {
            System.out.println("File '" + filename + "' already exists!");
            System.out.print("Do you want to overwrite it? (y/n): ");
            String response = scanner.nextLine().toLowerCase();
            
            if (!response.equals("y") && !response.equals("yes")) {
                System.out.println("Operation cancelled.");
                return;
            }
        }
        
        try (PrintWriter writer = new PrintWriter(new FileWriter(filename))) {
            writer.println("This will overwrite the file");
            writer.println("Current time: " + java.time.LocalDateTime.now());
            System.out.println("File written successfully!");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

### Method 2: Create Backup Before Overwriting

```java
import java.io.File;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

public class BackupBeforeOverwrite {
    public static void main(String[] args) {
        String filename = "important.txt";
        File file = new File(filename);
        
        if (file.exists()) {
            try {
                // Create backup
                String backupName = filename + ".backup";
                Files.copy(file.toPath(), 
                          new File(backupName).toPath(), 
                          StandardCopyOption.REPLACE_EXISTING);
                System.out.println("Backup created: " + backupName);
            } catch (IOException e) {
                System.out.println("Could not create backup: " + e.getMessage());
                return;
            }
        }
        
        try (PrintWriter writer = new PrintWriter(new FileWriter(filename))) {
            writer.println("Updated content");
            writer.println("Backup was created before this overwrite");
            System.out.println("File updated successfully!");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

### Method 3: Version Control

```java
import java.io.File;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class VersionedFile {
    public static void main(String[] args) {
        String baseFilename = "document";
        String timestamp = LocalDateTime.now().format(DateTimeFormatter.ofPattern("yyyyMMdd_HHmmss"));
        String versionedFilename = baseFilename + "_" + timestamp + ".txt";
        
        try (PrintWriter writer = new PrintWriter(new FileWriter(versionedFilename))) {
            writer.println("Document content");
            writer.println("Created: " + LocalDateTime.now());
            writer.println("Version: " + timestamp);
            System.out.println("File created: " + versionedFilename);
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

## File Overwrite Scenarios

### Scenario 1: Log File Rotation
```java
public class LogRotation {
    public static void rotateLog(String logFile) {
        File file = new File(logFile);
        
        if (file.exists() && file.length() > 1024 * 1024) { // 1MB
            // Move current log to archive
            String archiveFile = logFile + "." + System.currentTimeMillis();
            file.renameTo(new File(archiveFile));
            System.out.println("Log rotated to: " + archiveFile);
        }
        
        // Create new log file
        try (PrintWriter writer = new PrintWriter(new FileWriter(logFile))) {
            writer.println("=== NEW LOG SESSION ===");
            writer.println("Started: " + java.time.LocalDateTime.now());
        } catch (IOException e) {
            System.out.println("Error creating new log: " + e.getMessage());
        }
    }
}
```

### Scenario 2: Configuration Update
```java
public class ConfigUpdater {
    public static void updateConfig(String key, String value) {
        String configFile = "app.properties";
        
        // In a real application, you'd read the existing config first
        // and merge with the new value
        
        try (PrintWriter writer = new PrintWriter(new FileWriter(configFile))) {
            writer.println("# Application Configuration");
            writer.println("app.version=1.0.0");
            writer.println("app.name=MyApplication");
            writer.println(key + "=" + value);
            writer.println("last.updated=" + java.time.LocalDateTime.now());
        } catch (IOException e) {
            System.out.println("Error updating config: " + e.getMessage());
        }
    }
}
```

## Best Practices for File Overwriting

### 1. **Always Ask for Confirmation**
```java
private boolean confirmOverwrite(String filename) {
    File file = new File(filename);
    if (!file.exists()) {
        return true; // File doesn't exist, safe to create
    }
    
    Scanner scanner = new Scanner(System.in);
    System.out.println("File '" + filename + "' already exists.");
    System.out.print("Overwrite? (y/n): ");
    String response = scanner.nextLine().toLowerCase();
    return response.equals("y") || response.equals("yes");
}
```

### 2. **Create Backups for Important Files**
```java
private void backupFile(String filename) throws IOException {
    File file = new File(filename);
    if (file.exists()) {
        String backupName = filename + ".bak";
        Files.copy(file.toPath(), 
                  new File(backupName).toPath(), 
                  StandardCopyOption.REPLACE_EXISTING);
    }
}
```

### 3. **Use Descriptive Filenames**
```java
// Instead of overwriting the same file
String filename = "data_" + LocalDateTime.now().format(
    DateTimeFormatter.ofPattern("yyyyMMdd_HHmmss")) + ".txt";
```

### 4. **Handle Errors Gracefully**
```java
private void safeOverwrite(String filename, String content) {
    try {
        // Create backup first
        backupFile(filename);
        
        // Write new content
        try (PrintWriter writer = new PrintWriter(new FileWriter(filename))) {
            writer.print(content);
        }
        
        System.out.println("File updated successfully!");
        
    } catch (IOException e) {
        System.out.println("Error updating file: " + e.getMessage());
        // Could restore from backup here
    }
}
```

## What's Next?

Now that you understand how file overwriting works, let's practice with an exercise that builds on your previous text writer application. You'll add features to handle existing files safely!

# Exercise - File Manager

Create a robust file management system that handles various file operations and gracefully manages file-related exceptions. This exercise will help you practice handling `IOException`, `FileNotFoundException`, and other file-related exceptions.

## Requirements

Create a `FileManager` class with the following methods:

### 1. File Reading Operations
- `readFile(String filename)` - Read entire file content
- `readFileLines(String filename)` - Read file line by line
- `getFileInfo(String filename)` - Get file information (size, last modified, etc.)

### 2. File Writing Operations
- `writeFile(String filename, String content)` - Write content to file
- `appendToFile(String filename, String content)` - Append content to existing file
- `createDirectory(String dirname)` - Create a new directory

### 3. File Management Operations
- `deleteFile(String filename)` - Delete a file
- `copyFile(String source, String destination)` - Copy file from source to destination
- `listFiles(String directory)` - List all files in a directory

### 4. Exception Handling
Handle the following exceptions appropriately:
- **File not found** - `FileNotFoundException`
- **Permission denied** - `SecurityException`
- **IO errors** - `IOException`
- **Invalid file paths** - `IllegalArgumentException`

## Implementation Guidelines

### FileManager Class Structure
```java
import java.io.*;
import java.nio.file.*;
import java.util.*;

public class FileManager {
    // File reading methods
    public String readFile(String filename) throws IOException { /* implementation */ }
    public List<String> readFileLines(String filename) throws IOException { /* implementation */ }
    public FileInfo getFileInfo(String filename) throws IOException { /* implementation */ }
    
    // File writing methods
    public void writeFile(String filename, String content) throws IOException { /* implementation */ }
    public void appendToFile(String filename, String content) throws IOException { /* implementation */ }
    public void createDirectory(String dirname) throws IOException { /* implementation */ }
    
    // File management methods
    public void deleteFile(String filename) throws IOException { /* implementation */ }
    public void copyFile(String source, String destination) throws IOException { /* implementation */ }
    public List<String> listFiles(String directory) throws IOException { /* implementation */ }
}
```

### FileInfo Class
Create a simple class to hold file information:

```java
public class FileInfo {
    private String filename;
    private long size;
    private long lastModified;
    private boolean exists;
    
    public FileInfo(String filename, long size, long lastModified, boolean exists) {
        this.filename = filename;
        this.size = size;
        this.lastModified = lastModified;
        this.exists = exists;
    }
    
    // Getters and toString method
    public String getFilename() { return filename; }
    public long getSize() { return size; }
    public long getLastModified() { return lastModified; }
    public boolean exists() { return exists; }
    
    @Override
    public String toString() {
        return String.format("File: %s, Size: %d bytes, Last Modified: %d, Exists: %s",
                           filename, size, lastModified, exists);
    }
}
```

### Method Implementations

#### File Reading
```java
public String readFile(String filename) throws IOException {
    if (filename == null || filename.trim().isEmpty()) {
        throw new IllegalArgumentException("Filename cannot be null or empty");
    }
    
    try (BufferedReader reader = new BufferedReader(new FileReader(filename))) {
        StringBuilder content = new StringBuilder();
        String line;
        
        while ((line = reader.readLine()) != null) {
            content.append(line).append("\n");
        }
        
        return content.toString();
    } catch (FileNotFoundException e) {
        throw new FileNotFoundException("File not found: " + filename);
    }
}

public List<String> readFileLines(String filename) throws IOException {
    if (filename == null || filename.trim().isEmpty()) {
        throw new IllegalArgumentException("Filename cannot be null or empty");
    }
    
    List<String> lines = new ArrayList<>();
    
    try (BufferedReader reader = new BufferedReader(new FileReader(filename))) {
        String line;
        while ((line = reader.readLine()) != null) {
            lines.add(line);
        }
    } catch (FileNotFoundException e) {
        throw new FileNotFoundException("File not found: " + filename);
    }
    
    return lines;
}
```

#### File Writing
```java
public void writeFile(String filename, String content) throws IOException {
    if (filename == null || filename.trim().isEmpty()) {
        throw new IllegalArgumentException("Filename cannot be null or empty");
    }
    
    try (FileWriter writer = new FileWriter(filename)) {
        writer.write(content);
    } catch (SecurityException e) {
        throw new SecurityException("Permission denied to write file: " + filename);
    }
}

public void appendToFile(String filename, String content) throws IOException {
    if (filename == null || filename.trim().isEmpty()) {
        throw new IllegalArgumentException("Filename cannot be null or empty");
    }
    
    try (FileWriter writer = new FileWriter(filename, true)) { // true for append mode
        writer.write(content);
    } catch (SecurityException e) {
        throw new SecurityException("Permission denied to append to file: " + filename);
    }
}
```

#### File Management
```java
public void copyFile(String source, String destination) throws IOException {
    if (source == null || destination == null) {
        throw new IllegalArgumentException("Source and destination cannot be null");
    }
    
    File sourceFile = new File(source);
    if (!sourceFile.exists()) {
        throw new FileNotFoundException("Source file not found: " + source);
    }
    
    try (FileInputStream fis = new FileInputStream(source);
         FileOutputStream fos = new FileOutputStream(destination)) {
        
        byte[] buffer = new byte[1024];
        int length;
        while ((length = fis.read(buffer)) > 0) {
            fos.write(buffer, 0, length);
        }
    } catch (SecurityException e) {
        throw new SecurityException("Permission denied for file operation");
    }
}
```

## Test Class

Create a `FileManagerTester` class with comprehensive testing:

```java
public class FileManagerTester {
    public static void main(String[] args) {
        FileManager fm = new FileManager();
        
        // Test file operations
        testFileOperations(fm);
        
        // Test exception handling
        testExceptionHandling(fm);
        
        // Test file management
        testFileManagement(fm);
    }
    
    public static void testFileOperations(FileManager fm) {
        System.out.println("=== Testing File Operations ===");
        
        try {
            // Create a test file
            fm.writeFile("test.txt", "Hello, World!\nThis is a test file.\nLine 3");
            System.out.println("✓ File created successfully");
            
            // Read the file
            String content = fm.readFile("test.txt");
            System.out.println("✓ File read successfully");
            System.out.println("Content: " + content);
            
            // Read file lines
            List<String> lines = fm.readFileLines("test.txt");
            System.out.println("✓ File lines read successfully");
            System.out.println("Number of lines: " + lines.size());
            
            // Get file info
            FileInfo info = fm.getFileInfo("test.txt");
            System.out.println("✓ File info retrieved: " + info);
            
        } catch (IOException e) {
            System.out.println("Error in file operations: " + e.getMessage());
        }
    }
    
    public static void testExceptionHandling(FileManager fm) {
        System.out.println("\n=== Testing Exception Handling ===");
        
        // Test file not found
        try {
            fm.readFile("nonexistent.txt");
        } catch (FileNotFoundException e) {
            System.out.println("✓ Caught FileNotFoundException: " + e.getMessage());
        } catch (IOException e) {
            System.out.println("✓ Caught IOException: " + e.getMessage());
        }
        
        // Test invalid filename
        try {
            fm.writeFile("", "content");
        } catch (IllegalArgumentException e) {
            System.out.println("✓ Caught IllegalArgumentException: " + e.getMessage());
        } catch (IOException e) {
            System.out.println("✓ Caught IOException: " + e.getMessage());
        }
        
        // Test null filename
        try {
            fm.readFile(null);
        } catch (IllegalArgumentException e) {
            System.out.println("✓ Caught IllegalArgumentException: " + e.getMessage());
        } catch (IOException e) {
            System.out.println("✓ Caught IOException: " + e.getMessage());
        }
    }
    
    public static void testFileManagement(FileManager fm) {
        System.out.println("\n=== Testing File Management ===");
        
        try {
            // Create directory
            fm.createDirectory("test_dir");
            System.out.println("✓ Directory created successfully");
            
            // List files
            List<String> files = fm.listFiles(".");
            System.out.println("✓ Files listed successfully");
            System.out.println("Files in current directory: " + files.size());
            
            // Copy file
            fm.copyFile("test.txt", "test_copy.txt");
            System.out.println("✓ File copied successfully");
            
            // Append to file
            fm.appendToFile("test.txt", "\nAppended content");
            System.out.println("✓ Content appended successfully");
            
            // Clean up
            fm.deleteFile("test.txt");
            fm.deleteFile("test_copy.txt");
            System.out.println("✓ Files deleted successfully");
            
        } catch (IOException e) {
            System.out.println("Error in file management: " + e.getMessage());
        }
    }
}
```

## Expected Output

```
=== Testing File Operations ===
✓ File created successfully
✓ File read successfully
Content: Hello, World!
This is a test file.
Line 3

✓ File lines read successfully
Number of lines: 3
✓ File info retrieved: File: test.txt, Size: 35 bytes, Last Modified: 1234567890, Exists: true

=== Testing Exception Handling ===
✓ Caught FileNotFoundException: File not found: nonexistent.txt
✓ Caught IllegalArgumentException: Filename cannot be null or empty
✓ Caught IllegalArgumentException: Filename cannot be null or empty

=== Testing File Management ===
✓ Directory created successfully
✓ Files listed successfully
Files in current directory: 5
✓ File copied successfully
✓ Content appended successfully
✓ Files deleted successfully
```

## Bonus Challenges

### 1. Interactive File Manager
Create an interactive version with a menu system:

```java
import java.util.Scanner;

public class InteractiveFileManager {
    public static void main(String[] args) {
        FileManager fm = new FileManager();
        Scanner scanner = new Scanner(System.in);
        
        while (true) {
            System.out.println("\n=== File Manager Menu ===");
            System.out.println("1. Read file");
            System.out.println("2. Write file");
            System.out.println("3. Copy file");
            System.out.println("4. Delete file");
            System.out.println("5. List files");
            System.out.println("6. Quit");
            System.out.print("Choose an option: ");
            
            try {
                int choice = scanner.nextInt();
                scanner.nextLine(); // Consume newline
                
                switch (choice) {
                    case 1:
                        handleReadFile(fm, scanner);
                        break;
                    case 2:
                        handleWriteFile(fm, scanner);
                        break;
                    // ... other cases
                    case 6:
                        System.out.println("Goodbye!");
                        return;
                    default:
                        System.out.println("Invalid option. Please try again.");
                }
            } catch (Exception e) {
                System.out.println("Error: " + e.getMessage());
                scanner.nextLine(); // Clear invalid input
            }
        }
        
        scanner.close();
    }
    
    private static void handleReadFile(FileManager fm, Scanner scanner) {
        try {
            System.out.print("Enter filename to read: ");
            String filename = scanner.nextLine();
            String content = fm.readFile(filename);
            System.out.println("File content:\n" + content);
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
    }
    
    // ... other handler methods
}
```

### 2. Custom File Exceptions
Create custom exception classes for file operations:

```java
class FileOperationException extends Exception {
    private String filename;
    private String operation;
    
    public FileOperationException(String message, String filename, String operation) {
        super(message);
        this.filename = filename;
        this.operation = operation;
    }
    
    public String getFilename() { return filename; }
    public String getOperation() { return operation; }
}

class FileAccessDeniedException extends FileOperationException {
    public FileAccessDeniedException(String filename, String operation) {
        super("Access denied for " + operation + " on file: " + filename, filename, operation);
    }
}
```

### 3. File Backup System
Add functionality to create backups of files before operations:

```java
public void safeWriteFile(String filename, String content) throws IOException {
    // Create backup if file exists
    File file = new File(filename);
    if (file.exists()) {
        String backupName = filename + ".backup";
        copyFile(filename, backupName);
        System.out.println("Backup created: " + backupName);
    }
    
    // Write new content
    writeFile(filename, content);
}
```

## Learning Objectives

After completing this exercise, you should be able to:

1. **Handle file-related exceptions** (`IOException`, `FileNotFoundException`, `SecurityException`)
2. **Use try-with-resources** for automatic resource management
3. **Validate file paths and inputs** before operations
4. **Implement robust file operations** with proper error handling
5. **Create user-friendly error messages** for file operations
6. **Handle permission and security issues** gracefully
7. **Test file operations thoroughly** with various scenarios
8. **Design exception handling strategies** for file management systems

## Tips

- **Always use try-with-resources** for file operations to ensure proper cleanup
- **Validate inputs early** to prevent unnecessary file operations
- **Provide specific error messages** that help users understand what went wrong
- **Handle both checked and unchecked exceptions** appropriately
- **Test with various file scenarios**: existing files, non-existent files, read-only files, etc.
- **Consider security implications** when handling file operations

Good luck with your file manager implementation!

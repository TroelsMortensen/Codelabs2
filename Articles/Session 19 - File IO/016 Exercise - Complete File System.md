# Exercise - Complete File Management System

Create a comprehensive file management system that combines all the concepts you've learned: text files, binary files, object serialization, file reading, writing, appending, and advanced file operations.

## Requirements

Create a `CompleteFileSystem` class that provides a full-featured file management interface with the following capabilities:

### 1. Text File Operations
- Create, read, write, append, and modify text files
- Support different text formats (plain text, CSV, JSON-like)
- Advanced text processing and analysis

### 2. Binary File Operations
- Create, read, and manipulate binary files
- Support different binary formats (custom headers, structured data)
- Binary file analysis and comparison

### 3. Object Serialization
- Save and load Java objects to/from binary files
- Support collections and complex object hierarchies
- Object versioning and migration

### 4. File Management
- File system navigation and organization
- File backup, restore, and version control
- File statistics and analysis
- File search and filtering

### 5. Data Conversion
- Convert between text and binary formats
- Import/export data between different file types
- Data validation and transformation

## Implementation Guidelines

### Basic Class Structure
```java
import java.io.*;
import java.nio.file.*;
import java.util.*;
import java.util.regex.Pattern;

public class CompleteFileSystem {
    private Scanner scanner;
    private String currentDirectory;
    
    public CompleteFileSystem() {
        this.scanner = new Scanner(System.in);
        this.currentDirectory = System.getProperty("user.dir");
    }
    
    public void run() {
        // Main menu loop
    }
    
    // Text File Operations
    private void textFileOperations() { }
    private void createTextFile() { }
    private void readTextFile() { }
    private void modifyTextFile() { }
    private void analyzeTextFile() { }
    
    // Binary File Operations
    private void binaryFileOperations() { }
    private void createBinaryFile() { }
    private void readBinaryFile() { }
    private void analyzeBinaryFile() { }
    
    // Object Serialization
    private void objectOperations() { }
    private void saveObject() { }
    private void loadObject() { }
    private void objectManagement() { }
    
    // File Management
    private void fileManagement() { }
    private void navigateDirectory() { }
    private void fileStatistics() { }
    private void backupOperations() { }
    
    // Data Conversion
    private void dataConversion() { }
    private void textToBinary() { }
    private void binaryToText() { }
    
    public static void main(String[] args) {
        new CompleteFileSystem().run();
    }
}
```

### Main Menu Structure
```
=== Complete File Management System ===
Current Directory: /path/to/current/directory

1. Text File Operations
2. Binary File Operations
3. Object Serialization
4. File Management
5. Data Conversion
6. System Information
7. Settings
8. Exit

Choose an option (1-8):
```

## Detailed Requirements

### 1. Text File Operations

#### Text File Menu
```
=== Text File Operations ===

1. Create New Text File
2. Read Text File
3. Write to Text File
4. Append to Text File
5. Modify Text File
6. Analyze Text File
7. Convert Text Format
8. Text File Comparison
9. Back to Main Menu

Choose an option (1-9):
```

#### Advanced Text Operations
- **Create with templates**: Pre-defined templates for common file types
- **Smart formatting**: Auto-format JSON, XML, CSV files
- **Content validation**: Validate file format and content
- **Text analysis**: Word count, character analysis, readability metrics

### 2. Binary File Operations

#### Binary File Menu
```
=== Binary File Operations ===

1. Create Binary File
2. Read Binary File
3. Analyze Binary File
4. Compare Binary Files
5. Binary File Conversion
6. Custom Binary Format
7. Binary Data Editor
8. Back to Main Menu

Choose an option (1-8):
```

#### Custom Binary Format Example
```java
public class CustomBinaryFormat {
    public static void writeCustomFormat(String filename, List<DataRecord> records) {
        try (DataOutputStream outputStream = new DataOutputStream(
                new FileOutputStream(filename))) {
            
            // Write header
            outputStream.writeUTF("CUSTOM_FORMAT_V1");
            outputStream.writeLong(System.currentTimeMillis());
            outputStream.writeInt(records.size());
            
            // Write records
            for (DataRecord record : records) {
                outputStream.writeUTF(record.getName());
                outputStream.writeInt(record.getId());
                outputStream.writeDouble(record.getValue());
                outputStream.writeBoolean(record.isActive());
            }
            
            // Write footer
            outputStream.writeUTF("END_OF_FILE");
            
        } catch (IOException e) {
            System.out.println("Error writing custom format: " + e.getMessage());
        }
    }
    
    public static List<DataRecord> readCustomFormat(String filename) {
        List<DataRecord> records = new ArrayList<>();
        
        try (DataInputStream inputStream = new DataInputStream(
                new FileInputStream(filename))) {
            
            // Read header
            String magic = inputStream.readUTF();
            if (!magic.equals("CUSTOM_FORMAT_V1")) {
                throw new IOException("Invalid file format");
            }
            
            long timestamp = inputStream.readLong();
            int recordCount = inputStream.readInt();
            
            System.out.println("File created: " + new Date(timestamp));
            System.out.println("Record count: " + recordCount);
            
            // Read records
            for (int i = 0; i < recordCount; i++) {
                String name = inputStream.readUTF();
                int id = inputStream.readInt();
                double value = inputStream.readDouble();
                boolean active = inputStream.readBoolean();
                
                records.add(new DataRecord(name, id, value, active));
            }
            
            // Verify footer
            String footer = inputStream.readUTF();
            if (!footer.equals("END_OF_FILE")) {
                System.out.println("Warning: Invalid file footer");
            }
            
        } catch (IOException e) {
            System.out.println("Error reading custom format: " + e.getMessage());
        }
        
        return records;
    }
}
```

### 3. Object Serialization

#### Object Management Menu
```
=== Object Serialization ===

1. Save Single Object
2. Load Single Object
3. Save Collection
4. Load Collection
5. Object Browser
6. Object Comparison
7. Object Migration
8. Back to Main Menu

Choose an option (1-8):
```

#### Object Browser Implementation
```java
private void objectBrowser() {
    System.out.println("\n=== Object Browser ===");
    
    // List serialized object files
    File currentDir = new File(currentDirectory);
    File[] objectFiles = currentDir.listFiles((dir, name) -> 
        name.endsWith(".ser") || name.endsWith(".dat"));
    
    if (objectFiles == null || objectFiles.length == 0) {
        System.out.println("No object files found.");
        return;
    }
    
    System.out.println("Available object files:");
    for (int i = 0; i < objectFiles.length; i++) {
        System.out.printf("%d. %s (%,d bytes)%n", 
                         i + 1, objectFiles[i].getName(), objectFiles[i].length());
    }
    
    System.out.print("Select file to examine (1-" + objectFiles.length + "): ");
    int choice = Integer.parseInt(scanner.nextLine()) - 1;
    
    if (choice >= 0 && choice < objectFiles.length) {
        examineObjectFile(objectFiles[choice]);
    }
}

private void examineObjectFile(File file) {
    try (ObjectInputStream inputStream = new ObjectInputStream(
            new FileInputStream(file))) {
        
        Object obj = inputStream.readObject();
        
        System.out.println("\n=== Object Analysis ===");
        System.out.println("File: " + file.getName());
        System.out.println("Size: " + file.length() + " bytes");
        System.out.println("Type: " + obj.getClass().getSimpleName());
        System.out.println("Content: " + obj.toString());
        
        // Additional analysis based on object type
        if (obj instanceof Collection) {
            Collection<?> collection = (Collection<?>) obj;
            System.out.println("Collection size: " + collection.size());
        }
        
    } catch (IOException | ClassNotFoundException e) {
        System.out.println("Error examining object file: " + e.getMessage());
    }
}
```

### 4. File Management

#### Advanced File Operations
```java
private void fileManagement() {
    System.out.println("\n=== File Management ===");
    System.out.println("1. Navigate Directory");
    System.out.println("2. File Statistics");
    System.out.println("3. Backup Operations");
    System.out.println("4. File Search");
    System.out.println("5. File Organization");
    System.out.println("6. Cleanup Operations");
    System.out.println("7. Back to Main Menu");
    
    int choice = getMenuChoice(1, 7);
    
    switch (choice) {
        case 1: navigateDirectory(); break;
        case 2: fileStatistics(); break;
        case 3: backupOperations(); break;
        case 4: fileSearch(); break;
        case 5: fileOrganization(); break;
        case 6: cleanupOperations(); break;
        case 7: return;
    }
}

private void fileSearch() {
    System.out.println("\n=== File Search ===");
    System.out.print("Enter search term: ");
    String searchTerm = scanner.nextLine();
    
    System.out.println("Search options:");
    System.out.println("1. Search by filename");
    System.out.println("2. Search by content");
    System.out.println("3. Search by file type");
    System.out.println("4. Advanced search");
    
    int searchType = getMenuChoice(1, 4);
    
    List<File> results = new ArrayList<>();
    
    switch (searchType) {
        case 1: results = searchByFilename(searchTerm); break;
        case 2: results = searchByContent(searchTerm); break;
        case 3: results = searchByFileType(searchTerm); break;
        case 4: results = advancedSearch(); break;
    }
    
    displaySearchResults(results);
}

private List<File> searchByContent(String searchTerm) {
    List<File> results = new ArrayList<>();
    
    try {
        Files.walk(Paths.get(currentDirectory))
            .filter(Files::isRegularFile)
            .filter(path -> {
                try {
                    // Only search text files
                    String filename = path.toString().toLowerCase();
                    if (filename.endsWith(".txt") || filename.endsWith(".java") || 
                        filename.endsWith(".csv") || filename.endsWith(".xml")) {
                        
                        String content = Files.readString(path);
                        return content.toLowerCase().contains(searchTerm.toLowerCase());
                    }
                } catch (IOException e) {
                    // Skip files that can't be read
                }
                return false;
            })
            .forEach(path -> results.add(path.toFile()));
            
    } catch (IOException e) {
        System.out.println("Error during search: " + e.getMessage());
    }
    
    return results;
}
```

### 5. Data Conversion

#### Conversion Operations
```java
private void dataConversion() {
    System.out.println("\n=== Data Conversion ===");
    System.out.println("1. Text to Binary");
    System.out.println("2. Binary to Text");
    System.out.println("3. Object to Text");
    System.out.println("4. Text to Object");
    System.out.println("5. Format Conversion");
    System.out.println("6. Back to Main Menu");
    
    int choice = getMenuChoice(1, 6);
    
    switch (choice) {
        case 1: textToBinary(); break;
        case 2: binaryToText(); break;
        case 3: objectToText(); break;
        case 4: textToObject(); break;
        case 5: formatConversion(); break;
        case 6: return;
    }
}

private void textToBinary() {
    System.out.println("\n=== Text to Binary Conversion ===");
    
    System.out.print("Enter text file path: ");
    String textFile = scanner.nextLine();
    
    System.out.print("Enter output binary file path: ");
    String binaryFile = scanner.nextLine();
    
    try {
        // Read text file
        String content = Files.readString(Paths.get(textFile));
        
        // Write as binary
        try (DataOutputStream outputStream = new DataOutputStream(
                new FileOutputStream(binaryFile))) {
            
            outputStream.writeUTF("TEXT_TO_BINARY");
            outputStream.writeLong(System.currentTimeMillis());
            outputStream.writeUTF(content);
            outputStream.writeUTF("END_OF_TEXT");
        }
        
        System.out.println("Conversion completed successfully!");
        
    } catch (IOException e) {
        System.out.println("Error during conversion: " + e.getMessage());
    }
}
```

## Sample Program Flow

```
=== Complete File Management System ===
Current Directory: C:\MyStuff\DotNet Projects\Codelabs2\Articles

1. Text File Operations
2. Binary File Operations
3. Object Serialization
4. File Management
5. Data Conversion
6. System Information
7. Settings
8. Exit

Choose an option (1-8): 1

=== Text File Operations ===
1. Create New Text File
2. Read Text File
3. Write to Text File
4. Append to Text File
5. Modify Text File
6. Analyze Text File
7. Convert Text Format
8. Text File Comparison
9. Back to Main Menu

Choose an option (1-9): 6

=== Text File Analysis ===

Available text files:
1. data.txt (1.2 KB)
2. config.txt (456 bytes)

Enter filename: data.txt

=== Analysis Results ===
File: data.txt
Size: 1,245 bytes
Lines: 45
Characters: 1,245
Words: 387
Average words per line: 8.6
Longest line: 67 characters
Empty lines: 5
File type: Plain text
Encoding: UTF-8

Most common words:
1. "the" - 23 occurrences
2. "and" - 18 occurrences
3. "of" - 15 occurrences

Press Enter to continue...
```

## Learning Objectives

After completing this exercise, you should be able to:

1. **Integrate all file I/O concepts** into a comprehensive system
2. **Handle different file formats** (text, binary, serialized objects)
3. **Implement advanced file operations** (search, analysis, conversion)
4. **Create robust error handling** for all file operations
5. **Design user-friendly interfaces** for complex file management
6. **Optimize file operations** for performance and reliability
7. **Implement data validation** and format checking
8. **Create extensible systems** that can handle new file types

## Bonus Challenges

1. **Plugin system**: Allow users to add custom file format handlers
2. **File synchronization**: Compare and sync files between directories
3. **Compression support**: Handle compressed files (ZIP, GZIP)
4. **Network file operations**: Support FTP, HTTP file operations
5. **File encryption**: Add encryption/decryption capabilities
6. **Batch operations**: Process multiple files simultaneously
7. **File monitoring**: Watch for file changes and auto-backup
8. **Cloud integration**: Support cloud storage services

Good luck with your complete file management system implementation!

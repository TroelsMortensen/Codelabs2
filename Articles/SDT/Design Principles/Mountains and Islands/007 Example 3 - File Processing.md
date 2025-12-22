# Example 3 - File Processing

Let's see one more example of transforming a mountain into islands, this time with file processing operations.

## The Mountain (Violation)

Here's a method that processes files from a directory. Notice the deep nesting with file operations, error handling, and filtering:

```java
public void processFiles(String directoryPath) {
    if (directoryPath != null) {                              // Base Camp (Level 0)
        File directory = new File(directoryPath);
        if (directory.exists()) {                            // 1000 meters (Level 1)
            if (directory.isDirectory()) {                    // 2000 meters (Level 2)
                File[] files = directory.listFiles();
                if (files != null) {                          // 3000 meters (Level 3)
                    for (File file : files) {                // 4000 meters (Level 4)
                        if (file.isFile()) {                  // 5000 meters (Level 5)
                            if (file.getName().endsWith(".txt")) { // 6000 meters (Level 6)
                                try {                         // 7000 meters (Level 7)
                                    if (file.canRead()) {     // 8000 meters (Level 8)
                                        String content = readFile(file);
                                        if (content != null) { // 9000 meters (Level 9)
                                            if (!content.isEmpty()) {
                                                String processed = processContent(content);
                                                if (processed != null) { // 10000 meters (Level 10) The Peak 🚩quite steep, isn't it?
                                                    writeFile(file, processed);
                                                    log.info("Processed: " + file.getName());
                                                }
                                            }
                                        }
                                    }
                                } catch (IOException e) {
                                    log.error("Error processing file: " + file.getName(), e);
                                }
                            }
                        }
                    }
                }
            } else {
                throw new NotADirectoryException(directoryPath);
            }
        } else {
            throw new DirectoryNotFoundException(directoryPath);
        }
    } else {
        throw new NullPathException();
    }
}
```


## The Islands (Solution)

Now let's break this mountain into flat, accessible islands:

```java
// Island 1: The Coordinator
public void processFiles(String directoryPath) {
    File directory = validateAndGetDirectory(directoryPath);
    File[] files = getFilesFromDirectory(directory);
    
    for (File file : files) {
        processFileIfValid(file);
    }
}

// Island 2: Directory Validation
private File validateAndGetDirectory(String directoryPath) {
    if (directoryPath == null) {
        throw new NullPathException();
    }
    
    File directory = new File(directoryPath);
    if (!directory.exists()) {
        throw new DirectoryNotFoundException(directoryPath);
    }
    if (!directory.isDirectory()) {
        throw new NotADirectoryException(directoryPath);
    }
    
    return directory;
}

// Island 3: File Retrieval
private File[] getFilesFromDirectory(File directory) {
    File[] files = directory.listFiles();
    if (files == null) {
        return new File[0]; // Return empty array instead of null
    }
    return files;
}

// Island 4: File Processing Gate
private void processFileIfValid(File file) {
    if (!file.isFile()) return;           // Guard clause
    if (!isTextFile(file)) return;       // Guard clause
    if (!file.canRead()) return;          // Guard clause
    
    processTextFile(file);
}

// Island 5: Text File Processing
private void processTextFile(File file) {
    try {
        String content = readFileContent(file);
        if (content == null || content.isEmpty()) return; // Guard clause
        
        String processed = processContent(content);
        if (processed == null) return; // Guard clause
        
        writeProcessedContent(file, processed);
        log.info("Processed: " + file.getName());
    } catch (IOException e) {
        log.error("Error processing file: " + file.getName(), e);
    }
}

// Island 6: File Type Check
private boolean isTextFile(File file) {
    return file.getName().endsWith(".txt");
}

// Island 7: File Reading
private String readFileContent(File file) throws IOException {
    // File reading logic
    return Files.readString(file.toPath());
}

// Island 8: Content Processing
private String processContent(String content) {
    // Content processing logic
    return content.toUpperCase(); // Example: convert to uppercase
}

// Island 9: File Writing
private void writeProcessedContent(File file, String content) throws IOException {
    // File writing logic
    Files.writeString(file.toPath(), content);
}
```


### Benefits of This Refactoring

1. **Flat structure** - Maximum 1-2 levels of nesting
2. **Clear separation** - Each operation is separate
3. **Easy to read** - Can understand each operation independently
4. **Easy to test** - Can test each operation separately
5. **Easy to extend** - Adding new file types or operations is simple
6. **Clear error handling** - Each operation handles its own errors
7. **Single responsibility** - Each method does one thing

## Step-by-Step Refactoring

### Step 1: Extract Directory Validation

**Before:**
```java
if (directoryPath != null) {
    File directory = new File(directoryPath);
    if (directory.exists()) {
        if (directory.isDirectory()) {
            // process files
        }
    }
}
```

**After:**
```java
private File validateAndGetDirectory(String directoryPath) {
    if (directoryPath == null) {
        throw new NullPathException();
    }
    // ... other validations - all flat
    return directory;
}
```

This separates directory validation into its own method.

### Step 2: Extract File Retrieval

**Before:**
```java
File[] files = directory.listFiles();
if (files != null) {
    for (File file : files) {
        // process
    }
}
```

**After:**
```java
private File[] getFilesFromDirectory(File directory) {
    File[] files = directory.listFiles();
    return files == null ? new File[0] : files; // Handle null gracefully
}
```

This separates file retrieval and handles null gracefully.

### Step 3: Use Guard Clauses for File Filtering

**Before:**
```java
for (File file : files) {
    if (file.isFile()) {
        if (file.getName().endsWith(".txt")) {
            if (file.canRead()) {
                // process
            }
        }
    }
}
```

**After:**
```java
for (File file : files) {
    processFileIfValid(file); // Extract to method
}

private void processFileIfValid(File file) {
    if (!file.isFile()) return;      // Guard clause
    if (!isTextFile(file)) return;    // Guard clause
    if (!file.canRead()) return;      // Guard clause
    // process - now flat
}
```

This flattens nested conditions using guard clauses.

### Step 4: Extract File Operations

**Before:**
```java
try {
    String content = readFile(file);
    if (content != null) {
        if (!content.isEmpty()) {
            String processed = processContent(content);
            if (processed != null) {
                writeFile(file, processed);
            }
        }
    }
} catch (IOException e) {
    // handle
}
```

**After:**
```java
private void processTextFile(File file) {
    try {
        String content = readFileContent(file);
        if (content == null || content.isEmpty()) return; // Guard clause
        
        String processed = processContent(content);
        if (processed == null) return; // Guard clause
        
        writeProcessedContent(file, processed);
    } catch (IOException e) {
        log.error("Error processing file: " + file.getName(), e);
    }
}
```

This separates file operations and uses guard clauses.

## Comparison

### Before (Mountain)
- **Nesting levels:** 8
- **Method length:** Extremely long, impossible to see all at once
- **Responsibilities:** Multiple (validation, filtering, reading, processing, writing, error handling)
- **Testability:** Very hard - need to mock file system and test all combinations
- **Readability:** Very poor - must track 8 nested conditions
- **Maintainability:** Very poor - adding operations increases nesting
- **Error handling:** Scattered throughout nested blocks

### After (Islands)
- **Nesting levels:** 1-2 maximum
- **Method length:** Short, easy to see all at once
- **Responsibilities:** Single per method
- **Testability:** Easy - can test each operation independently
- **Readability:** Excellent - each method is clear and focused
- **Maintainability:** Excellent - adding operations is just adding methods
- **Error handling:** Clear and focused per operation


## Adding New File Types

With the island structure, adding new file types is easy:

```java
// Just modify the gate method
private void processFileIfValid(File file) {
    if (!file.isFile()) return;
    if (!isTextFile(file) && !isJsonFile(file)) return; // Add new type
    if (!file.canRead()) return;
    
    if (isTextFile(file)) {
        processTextFile(file);
    } else if (isJsonFile(file)) {
        processJsonFile(file); // New method
    }
}

private boolean isJsonFile(File file) {
    return file.getName().endsWith(".json");
}

private void processJsonFile(File file) {
    // New processing logic - flat and separate
}
```

No need to add more nesting - just add new methods!

## Summary

This example demonstrates:
- **Transforming an 8-level mountain into 1-2 level islands**
- **Separating file operations** into focused methods
- **Using guard clauses** to flatten nested conditions
- **Handling nulls gracefully** instead of nesting
- **Improving testability** through isolation
- **Improving maintainability** through separation
- **Making it easy to extend** with new file types or operations

The code went from an impossible mountain climb to an easy island-hopping swim.

## Conclusion

These three examples show how the "Make Islands, Not Mountains" principle applies to different scenarios:
- **Transaction processing** - Business logic with validation
- **User validation** - Multiple validation checks
- **File processing** - File system operations

In all cases, the transformation from mountains to islands results in:
- **Flatter code** (1-2 levels vs 5-8 levels)
- **Better readability** (clear, focused methods)
- **Better testability** (isolated, testable methods)
- **Better maintainability** (easy to modify and extend)

Remember: **Keep your code at low altitude. Make islands, not mountains!**


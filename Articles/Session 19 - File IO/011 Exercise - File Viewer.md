# Exercise - File Viewer and Analyzer

Create a comprehensive file viewer application that can read, display, and analyze text files. This exercise will help you practice file reading operations and create a useful tool for examining file contents.

## Requirements

Create a `FileViewer` class with a menu-driven console interface that provides various ways to view and analyze text files:

### 1. File Content Display
- Display entire file content with line numbers
- Show file content in pages (pagination)
- Display file statistics (lines, characters, words)

### 2. File Analysis
- Count different types of content (words, lines, characters)
- Find specific text within files
- Analyze file structure and format

### 3. File Comparison
- Compare two files line by line
- Show differences between files
- Display file statistics comparison

### 4. Content Filtering
- Filter lines containing specific text
- Display only lines matching certain patterns
- Search and highlight content

## Implementation Guidelines

### Basic Class Structure
```java
import java.io.*;
import java.nio.file.*;
import java.util.*;
import java.util.regex.Pattern;

public class FileViewer {
    private Scanner scanner;
    
    public FileViewer() {
        this.scanner = new Scanner(System.in);
    }
    
    public void run() {
        // Main menu loop
    }
    
    private void displayFileContent() {
        // Implementation for basic file display
    }
    
    private void paginatedView() {
        // Implementation for paginated viewing
    }
    
    private void analyzeFile() {
        // Implementation for file analysis
    }
    
    private void searchInFile() {
        // Implementation for text search
    }
    
    private void compareFiles() {
        // Implementation for file comparison
    }
    
    private void filterContent() {
        // Implementation for content filtering
    }
    
    public static void main(String[] args) {
        new FileViewer().run();
    }
}
```

### Menu Structure
```
=== File Viewer and Analyzer ===

1. Display File Content
2. Paginated View
3. Analyze File
4. Search in File
5. Compare Files
6. Filter Content
7. List Available Files
8. File Statistics
9. Exit

Choose an option (1-9):
```

## Detailed Requirements

### Option 1: Display File Content
Show complete file content with line numbers:

```
=== Display File Content ===

Available files:
1. data.txt (1.2 KB)
2. config.txt (456 bytes)
3. log.txt (2.1 KB)

Select file (1-3): 1

=== File Content: data.txt ===
   1: Name,Age,City,Occupation
   2: John Doe,25,New York,Engineer
   3: Jane Smith,30,London,Designer
   4: Bob Johnson,35,Tokyo,Manager
   5: Alice Brown,28,Paris,Developer
   6: 
   7: Total records: 4
```

### Option 2: Paginated View
Display file content in pages for large files:

```
=== Paginated View ===

Enter filename: large_file.txt

=== Page 1 of 15 ===
  1: This is line 1
  2: This is line 2
  ...
 20: This is line 20

Commands: [n]ext, [p]revious, [j]ump to page, [q]uit
Enter command: n

=== Page 2 of 15 ===
 21: This is line 21
 22: This is line 22
 ...
```

### Option 3: Analyze File
Provide comprehensive file analysis:

```
=== File Analysis ===

Enter filename: document.txt

=== Analysis Results ===
File: document.txt
Size: 2,456 bytes
Lines: 45
Characters: 2,456
Characters (no spaces): 2,031
Words: 387
Average words per line: 8.6
Longest line: 67 characters
Shortest line: 3 characters
Empty lines: 5

Most common words:
1. "the" - 23 occurrences
2. "and" - 18 occurrences
3. "of" - 15 occurrences
```

### Option 4: Search in File
Find and display lines containing specific text:

```
=== Search in File ===

Enter filename: data.txt
Enter search term: John

=== Search Results ===
Found 2 occurrences of "John":

Line 2: John Doe,25,New York,Engineer
Line 8: John Smith,22,Chicago,Analyst

Search completed in 0.002 seconds
```

### Option 5: Compare Files
Compare two files and show differences:

```
=== Compare Files ===

Enter first filename: file1.txt
Enter second filename: file2.txt

=== File Comparison ===
File 1: file1.txt (45 lines)
File 2: file2.txt (47 lines)

Differences found:
Line 3: 
  File1: "Original content"
  File2: "Modified content"

Line 5: 
  File1: [MISSING]
  File2: "New line added"

Line 7: 
  File1: "This line was removed"
  File2: [MISSING]

Total differences: 3
```

## Implementation Details

### File Content Display with Line Numbers
```java
private void displayFileContent() {
    System.out.println("\n=== Display File Content ===");
    
    String filename = getExistingFilename();
    if (filename == null) return;
    
    try (BufferedReader reader = Files.newBufferedReader(Paths.get(filename))) {
        String line;
        int lineNumber = 1;
        
        System.out.println("\n=== File Content: " + filename + " ===");
        while ((line = reader.readLine()) != null) {
            System.out.printf("%4d: %s%n", lineNumber, line);
            lineNumber++;
        }
        
    } catch (IOException e) {
        System.out.println("Error reading file: " + e.getMessage());
    }
}
```

### Paginated View Implementation
```java
private void paginatedView() {
    System.out.println("\n=== Paginated View ===");
    
    String filename = getExistingFilename();
    if (filename == null) return;
    
    try {
        List<String> lines = Files.readAllLines(Paths.get(filename));
        int totalPages = (int) Math.ceil(lines.size() / 20.0);
        int currentPage = 1;
        
        while (true) {
            displayPage(lines, currentPage, totalPages);
            
            System.out.print("\nCommands: [n]ext, [p]revious, [j]ump to page, [q]uit: ");
            String command = scanner.nextLine().toLowerCase();
            
            switch (command) {
                case "n":
                case "next":
                    if (currentPage < totalPages) currentPage++;
                    break;
                case "p":
                case "previous":
                    if (currentPage > 1) currentPage--;
                    break;
                case "j":
                case "jump":
                    currentPage = getPageNumber(totalPages);
                    break;
                case "q":
                case "quit":
                    return;
                default:
                    System.out.println("Invalid command!");
            }
        }
        
    } catch (IOException e) {
        System.out.println("Error reading file: " + e.getMessage());
    }
}

private void displayPage(List<String> lines, int page, int totalPages) {
    System.out.printf("\n=== Page %d of %d ===%n", page, totalPages);
    
    int startIndex = (page - 1) * 20;
    int endIndex = Math.min(startIndex + 20, lines.size());
    
    for (int i = startIndex; i < endIndex; i++) {
        System.out.printf("%4d: %s%n", i + 1, lines.get(i));
    }
}
```

### File Analysis Implementation
```java
private void analyzeFile() {
    System.out.println("\n=== File Analysis ===");
    
    String filename = getExistingFilename();
    if (filename == null) return;
    
    try {
        String content = Files.readString(Paths.get(filename));
        Path filePath = Paths.get(filename);
        
        // Basic statistics
        long fileSize = Files.size(filePath);
        String[] lines = content.split("\n");
        String[] words = content.split("\\s+");
        
        // Count characters
        int totalChars = content.length();
        int charsNoSpaces = content.replaceAll("\\s", "").length();
        
        // Count empty lines
        long emptyLines = Arrays.stream(lines)
            .mapToLong(line -> line.trim().isEmpty() ? 1 : 0)
            .sum();
        
        // Find longest and shortest lines
        String longestLine = Arrays.stream(lines)
            .max(Comparator.comparing(String::length))
            .orElse("");
        String shortestLine = Arrays.stream(lines)
            .filter(line -> !line.trim().isEmpty())
            .min(Comparator.comparing(String::length))
            .orElse("");
        
        // Display results
        System.out.println("\n=== Analysis Results ===");
        System.out.println("File: " + filename);
        System.out.println("Size: " + String.format("%,d", fileSize) + " bytes");
        System.out.println("Lines: " + lines.length);
        System.out.println("Characters: " + String.format("%,d", totalChars));
        System.out.println("Characters (no spaces): " + String.format("%,d", charsNoSpaces));
        System.out.println("Words: " + words.length);
        System.out.printf("Average words per line: %.1f%n", 
                         words.length / (double) lines.length);
        System.out.println("Longest line: " + longestLine.length() + " characters");
        System.out.println("Shortest line: " + shortestLine.length() + " characters");
        System.out.println("Empty lines: " + emptyLines);
        
    } catch (IOException e) {
        System.out.println("Error analyzing file: " + e.getMessage());
    }
}
```

### Search Implementation
```java
private void searchInFile() {
    System.out.println("\n=== Search in File ===");
    
    String filename = getExistingFilename();
    if (filename == null) return;
    
    System.out.print("Enter search term: ");
    String searchTerm = scanner.nextLine().trim();
    
    if (searchTerm.isEmpty()) {
        System.out.println("Search term cannot be empty!");
        return;
    }
    
    try {
        List<String> lines = Files.readAllLines(Paths.get(filename));
        List<Integer> matches = new ArrayList<>();
        
        long startTime = System.currentTimeMillis();
        
        // Search for term (case-insensitive)
        for (int i = 0; i < lines.size(); i++) {
            if (lines.get(i).toLowerCase().contains(searchTerm.toLowerCase())) {
                matches.add(i + 1);
            }
        }
        
        long endTime = System.currentTimeMillis();
        
        // Display results
        System.out.println("\n=== Search Results ===");
        if (matches.isEmpty()) {
            System.out.println("No occurrences of \"" + searchTerm + "\" found.");
        } else {
            System.out.printf("Found %d occurrence(s) of \"%s\":%n%n", 
                             matches.size(), searchTerm);
            
            for (int lineNum : matches) {
                System.out.printf("Line %d: %s%n", lineNum, lines.get(lineNum - 1));
            }
        }
        
        System.out.printf("%nSearch completed in %.3f seconds%n", 
                         (endTime - startTime) / 1000.0);
        
    } catch (IOException e) {
        System.out.println("Error searching file: " + e.getMessage());
    }
}
```

### File Comparison Implementation
```java
private void compareFiles() {
    System.out.println("\n=== Compare Files ===");
    
    System.out.print("Enter first filename: ");
    String filename1 = scanner.nextLine().trim();
    System.out.print("Enter second filename: ");
    String filename2 = scanner.nextLine().trim();
    
    try {
        List<String> lines1 = Files.readAllLines(Paths.get(filename1));
        List<String> lines2 = Files.readAllLines(Paths.get(filename2));
        
        System.out.println("\n=== File Comparison ===");
        System.out.printf("File 1: %s (%d lines)%n", filename1, lines1.size());
        System.out.printf("File 2: %s (%d lines)%n", filename2, lines2.size());
        
        List<String> differences = new ArrayList<>();
        int maxLines = Math.max(lines1.size(), lines2.size());
        
        for (int i = 0; i < maxLines; i++) {
            String line1 = i < lines1.size() ? lines1.get(i) : null;
            String line2 = i < lines2.size() ? lines2.get(i) : null;
            
            if (!Objects.equals(line1, line2)) {
                differences.add(String.format("Line %d:", i + 1));
                if (line1 != null) {
                    differences.add("  File1: \"" + line1 + "\"");
                } else {
                    differences.add("  File1: [MISSING]");
                }
                if (line2 != null) {
                    differences.add("  File2: \"" + line2 + "\"");
                } else {
                    differences.add("  File2: [MISSING]");
                }
                differences.add("");
            }
        }
        
        if (differences.isEmpty()) {
            System.out.println("Files are identical!");
        } else {
            System.out.println("\nDifferences found:");
            differences.forEach(System.out::println);
            System.out.println("Total differences: " + (differences.size() / 4));
        }
        
    } catch (IOException e) {
        System.out.println("Error comparing files: " + e.getMessage());
    }
}
```

## Sample Program Flow

```
=== File Viewer and Analyzer ===

1. Display File Content
2. Paginated View
3. Analyze File
4. Search in File
5. Compare Files
6. Filter Content
7. List Available Files
8. File Statistics
9. Exit

Choose an option (1-9): 3

=== File Analysis ===

Available files:
1. data.txt (1.2 KB)
2. config.txt (456 bytes)

Enter filename: data.txt

=== Analysis Results ===
File: data.txt
Size: 1,245 bytes
Lines: 8
Characters: 1,245
Characters (no spaces): 1,031
Words: 156
Average words per line: 19.5
Longest line: 67 characters
Shortest line: 3 characters
Empty lines: 1

Press Enter to continue...
```

## Learning Objectives

After completing this exercise, you should be able to:

1. **Read and display file content** with proper formatting
2. **Implement pagination** for large files
3. **Analyze file statistics** (lines, words, characters)
4. **Search for text** within files efficiently
5. **Compare files** and identify differences
6. **Handle file reading errors** gracefully
7. **Create user-friendly interfaces** for file viewing
8. **Optimize file operations** for performance

## Bonus Challenges

1. **Syntax highlighting**: Color-code different file types
2. **Regular expressions**: Support regex search patterns
3. **File encoding detection**: Handle different text encodings
4. **Large file optimization**: Handle files larger than memory
5. **Export results**: Save analysis results to files
6. **File history**: Track recently viewed files
7. **Bookmarks**: Save specific line positions in files

Good luck with your file viewer implementation!

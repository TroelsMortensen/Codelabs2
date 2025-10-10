# Exercise - Advanced File Manager with Appending

Extend your File Manager exercise to include file appending capabilities. This exercise will help you practice all three file writing modes: creating new files, overwriting existing files, and appending to existing files.

## Requirements

Enhance your `EnhancedTextFileWriter` class to include comprehensive file appending features:

### 1. Append Mode Operations
- Add new options for appending content to existing files
- Allow users to choose between overwrite and append modes
- Provide clear feedback about which mode is being used

### 2. Smart File Operations
- Automatically detect if file exists and offer append option
- Show file content preview before appending
- Allow users to specify where to append content (beginning, end, specific line)

### 3. Content Management
- Add content to existing files without losing original content
- Support different append styles (with separators, timestamps, etc.)
- Handle different file formats appropriately

## Implementation Guidelines

### Enhanced Menu Structure
```
=== Advanced File Manager ===

1. Write Simple Text (New File)
2. Write Personal Information (New File)
3. Write Shopping List (New File)
4. Write Configuration Data (New File)
5. Append to Existing File
6. Add to Shopping List
7. Add to Personal Profile
8. Log Entry
9. List Existing Files
10. View File Content
11. Create Backup
12. Restore from Backup
13. Settings
14. Exit

Choose an option (1-14):
```

### New Methods to Implement

```java
public class AdvancedFileManager {
    private Scanner scanner;
    private boolean safeMode;
    private String logFile;
    
    public AdvancedFileManager() {
        this.scanner = new Scanner(System.in);
        this.safeMode = true;
        this.logFile = "application.log";
    }
    
    // Existing methods...
    
    private void appendToExistingFile() {
        // Implementation for option 5
    }
    
    private void addToShoppingList() {
        // Implementation for option 6
    }
    
    private void addToPersonalProfile() {
        // Implementation for option 7
    }
    
    private void logEntry() {
        // Implementation for option 8
    }
    
    private void viewFileContent() {
        // Implementation for option 10
    }
    
    private void appendWithSeparator(String filename, String content) {
        // Helper method for structured appending
    }
    
    private void appendWithTimestamp(String filename, String content) {
        // Helper method for timestamped appending
    }
    
    private String getFileContentPreview(String filename, int lines) {
        // Helper method for file content preview
    }
}
```

## Detailed Requirements

### Option 5: Append to Existing File
Allow users to append content to any existing file:

```
=== Append to Existing File ===

Available files:
1. notes.txt (245 bytes)
2. data.txt (1.2 KB)
3. config.txt (456 bytes)

Select file to append to (1-3): 1

Current content preview (last 3 lines):
- Meeting notes from Monday
- Project discussion points
- Action items

Enter new content to append:
[User types content]

Append options:
1. Append to end
2. Add with separator
3. Add with timestamp
4. Custom format

Choose append style (1-4): 2

Content appended successfully!
```

### Option 6: Add to Shopping List
Smart shopping list management:

```
=== Shopping List Manager ===

Available shopping lists:
1. groceries.txt
2. office_supplies.txt
3. weekend_trips.txt

Select list (1-3): 1

Current items:
1. Milk
2. Bread
3. Eggs
4. Apples

Add new item: Chicken

Item added to shopping list!
New list:
1. Milk
2. Bread
3. Eggs
4. Apples
5. Chicken
```

### Option 7: Add to Personal Profile
Extend personal profiles with new information:

```
=== Personal Profile Manager ===

Available profiles:
1. john_profile.txt
2. alice_profile.txt

Select profile (1-2): 1

Current profile:
Name: John Doe
Age: 25
Email: john@example.com

Add new field:
Field name: Phone
Field value: (555) 123-4567

Profile updated successfully!
```

### Option 8: Log Entry
Add entries to application logs:

```
=== Log Entry ===

Log levels:
1. INFO
2. WARNING
3. ERROR
4. DEBUG

Select level (1-4): 1

Enter log message: User logged in successfully

Log entry added:
2024-01-15 14:30:22 [INFO] User logged in successfully
```

### Option 10: View File Content
Preview file content before making changes:

```
=== View File Content ===

Enter filename: notes.txt

=== File Content ===
=== MY NOTES ===
Meeting notes from Monday
- Discussed project timeline
- Assigned tasks to team members
- Set up next meeting for Friday

Additional notes from Tuesday
- Reviewed progress
- Updated timeline
- Identified potential risks

--- End of File ---
File size: 245 bytes
Last modified: 2024-01-15 10:30:25
```

## Implementation Details

### Smart Append Detection
```java
private void appendToExistingFile() {
    System.out.println("\n=== Append to Existing File ===");
    
    // List available files
    listExistingFiles();
    
    String filename = getExistingFilename();
    if (filename == null) return;
    
    // Show file preview
    showFilePreview(filename);
    
    // Get content to append
    String content = getTextInput();
    
    // Choose append style
    int style = getAppendStyle();
    
    // Perform append based on style
    switch (style) {
        case 1: appendSimple(filename, content); break;
        case 2: appendWithSeparator(filename, content); break;
        case 3: appendWithTimestamp(filename, content); break;
        case 4: appendCustom(filename, content); break;
    }
}
```

### File Content Preview
```java
private void showFilePreview(String filename) {
    try {
        List<String> lines = Files.readAllLines(Paths.get(filename));
        
        System.out.println("\nCurrent content preview (last 5 lines):");
        System.out.println("-".repeat(40));
        
        int startIndex = Math.max(0, lines.size() - 5);
        for (int i = startIndex; i < lines.size(); i++) {
            System.out.println("- " + lines.get(i));
        }
        
        System.out.println("-".repeat(40));
        System.out.println("Total lines: " + lines.size());
        
    } catch (IOException e) {
        System.out.println("Error reading file: " + e.getMessage());
    }
}
```

### Different Append Styles
```java
private void appendSimple(String filename, String content) {
    try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
        writer.println(content);
        System.out.println("Content appended successfully!");
    } catch (IOException e) {
        System.out.println("Error appending content: " + e.getMessage());
    }
}

private void appendWithSeparator(String filename, String content) {
    try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
        File file = new File(filename);
        if (file.exists() && file.length() > 0) {
            writer.println("\n" + "=".repeat(30));
        }
        writer.println(content);
        System.out.println("Content appended with separator!");
    } catch (IOException e) {
        System.out.println("Error appending content: " + e.getMessage());
    }
}

private void appendWithTimestamp(String filename, String content) {
    try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
        String timestamp = LocalDateTime.now().format(
            DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
        writer.printf("[%s] %s%n", timestamp, content);
        System.out.println("Content appended with timestamp!");
    } catch (IOException e) {
        System.out.println("Error appending content: " + e.getMessage());
    }
}
```

### Smart Shopping List Management
```java
private void addToShoppingList() {
    System.out.println("\n=== Shopping List Manager ===");
    
    String filename = getShoppingListFile();
    if (filename == null) return;
    
    // Show current items
    showShoppingList(filename);
    
    // Add new items
    System.out.println("Enter new items (type 'done' when finished):");
    List<String> newItems = new ArrayList<>();
    
    while (true) {
        System.out.print("Item: ");
        String item = scanner.nextLine().trim();
        
        if (item.equalsIgnoreCase("done")) {
            break;
        }
        
        if (!item.isEmpty()) {
            newItems.add(item);
        }
    }
    
    // Append new items
    if (!newItems.isEmpty()) {
        try (PrintWriter writer = new PrintWriter(new FileWriter(filename, true))) {
            for (String item : newItems) {
                writer.println(item);
            }
            System.out.println("Added " + newItems.size() + " items to shopping list!");
        } catch (IOException e) {
            System.out.println("Error adding items: " + e.getMessage());
        }
    }
}
```

### Log Entry System
```java
private void logEntry() {
    System.out.println("\n=== Log Entry ===");
    
    // Select log level
    System.out.println("Log levels:");
    System.out.println("1. INFO");
    System.out.println("2. WARNING");
    System.out.println("3. ERROR");
    System.out.println("4. DEBUG");
    
    int level = getMenuChoice(1, 4);
    String[] levels = {"", "INFO", "WARNING", "ERROR", "DEBUG"};
    
    // Get log message
    System.out.print("Enter log message: ");
    String message = scanner.nextLine();
    
    // Write log entry
    try (PrintWriter writer = new PrintWriter(new FileWriter(logFile, true))) {
        String timestamp = LocalDateTime.now().format(
            DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
        writer.printf("%s [%s] %s%n", timestamp, levels[level], message);
        System.out.println("Log entry added successfully!");
    } catch (IOException e) {
        System.out.println("Error writing log: " + e.getMessage());
    }
}
```

## Sample Program Flow

```
=== Advanced File Manager ===

1. Write Simple Text (New File)
2. Write Personal Information (New File)
3. Write Shopping List (New File)
4. Write Configuration Data (New File)
5. Append to Existing File
6. Add to Shopping List
7. Add to Personal Profile
8. Log Entry
9. List Existing Files
10. View File Content
11. Create Backup
12. Restore from Backup
13. Settings
14. Exit

Choose an option (1-14): 5

=== Append to Existing File ===

Available files:
1. notes.txt (245 bytes)
2. data.txt (1.2 KB)

Select file to append to (1-2): 1

Current content preview (last 5 lines):
----------------------------------------
- Meeting notes from Monday
- Project discussion points
- Action items
----------------------------------------
Total lines: 3

Enter new content to append: Follow-up meeting scheduled for next week

Append options:
1. Append to end
2. Add with separator
3. Add with timestamp
4. Custom format

Choose append style (1-4): 3

Content appended with timestamp!

Press Enter to continue...
```

## Learning Objectives

After completing this exercise, you should be able to:

1. **Implement file appending** with different styles and formats
2. **Preview file content** before making modifications
3. **Manage structured data** (shopping lists, profiles, logs)
4. **Choose appropriate append styles** for different use cases
5. **Handle file operations** with comprehensive error checking
6. **Create intelligent file managers** that adapt to user needs
7. **Implement logging systems** with different severity levels
8. **Design user-friendly interfaces** for complex file operations

## Bonus Challenges

1. **Search and replace**: Find and replace text within files
2. **File merging**: Combine multiple files into one
3. **Content validation**: Validate data before appending
4. **Undo functionality**: Undo last append operation
5. **File locking**: Prevent concurrent access to files
6. **Auto-backup**: Automatically backup before appending
7. **Content templates**: Use predefined templates for appending

Good luck with your advanced file manager implementation!

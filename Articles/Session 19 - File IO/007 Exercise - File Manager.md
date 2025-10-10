# Exercise - File Manager with Overwrite Protection

Extend your previous Text File Writer exercise to include safe file handling and overwrite protection. This exercise will help you practice managing existing files and implementing user-friendly file operations.

## Requirements

Enhance your `TextFileWriter` class to include the following new features:

### 1. File Existence Checking
- Check if a file already exists before writing
- Show file information if it exists (size, last modified date)
- Ask for confirmation before overwriting

### 2. Backup Creation
- Create automatic backups before overwriting files
- Show backup filename to user
- Allow user to choose backup filename

### 3. File Listing
- List all .txt files in the current directory
- Show file size and modification date
- Allow user to select existing files to overwrite

### 4. Safe File Operations
- Implement "safe write" mode that always creates backups
- Add option to restore from backup
- Show confirmation messages for all operations

## Implementation Guidelines

### Enhanced Menu Structure
```
=== Enhanced Text File Writer ===

1. Write Simple Text
2. Write Personal Information
3. Write Shopping List
4. Write Configuration Data
5. List Existing Files
6. Create Backup
7. Restore from Backup
8. Settings
9. Exit

Choose an option (1-9):
```

### New Methods to Implement

```java
public class EnhancedTextFileWriter {
    private Scanner scanner;
    private boolean safeMode;
    
    public EnhancedTextFileWriter() {
        this.scanner = new Scanner(System.in);
        this.safeMode = true; // Default to safe mode
    }
    
    // Existing methods...
    
    private void listExistingFiles() {
        // Implementation for option 5
    }
    
    private void createBackup() {
        // Implementation for option 6
    }
    
    private void restoreFromBackup() {
        // Implementation for option 7
    }
    
    private void showSettings() {
        // Implementation for option 8
    }
    
    private boolean confirmOverwrite(String filename) {
        // Helper method for overwrite confirmation
    }
    
    private void createBackupFile(String originalFile) {
        // Helper method for creating backups
    }
    
    private void showFileInfo(String filename) {
        // Helper method for displaying file information
    }
}
```

## Detailed Requirements

### Option 5: List Existing Files
Display all .txt files in the current directory with information:

```
=== Existing Text Files ===

1. data.txt          (1,245 bytes) - Modified: 2024-01-15 10:30:25
2. config.txt        (456 bytes)   - Modified: 2024-01-15 09:15:10
3. backup_data.txt   (1,245 bytes) - Modified: 2024-01-14 16:45:30

Total files: 3
```

### Option 6: Create Backup
Allow manual backup creation:

```
Enter filename to backup: data.txt
Enter backup filename (or press Enter for auto): data_backup_20240115.txt
Backup created successfully!
Original: data.txt (1,245 bytes)
Backup: data_backup_20240115.txt (1,245 bytes)
```

### Option 7: Restore from Backup
Restore a file from its backup:

```
Available backups:
1. data_backup_20240115.txt
2. config_backup_20240114.txt

Select backup to restore (1-2): 1
Restore data_backup_20240115.txt to data.txt? (y/n): y
File restored successfully!
```

### Option 8: Settings
Configure application behavior:

```
=== Settings ===

1. Safe Mode: ON (always create backups)
2. Auto-confirm overwrite: OFF (ask for confirmation)
3. Backup location: ./backups/
4. Default file extension: .txt

Choose setting to change (1-4) or 0 to return:
```

## Enhanced File Writing with Safety Checks

### Modified writeSimpleText() Method
```java
private void writeSimpleText() {
    System.out.println("\n=== Write Simple Text ===");
    
    String content = getTextInput();
    String filename = getValidFilename();
    
    // Check if file exists
    File file = new File(filename);
    if (file.exists()) {
        showFileInfo(filename);
        
        if (!confirmOverwrite(filename)) {
            System.out.println("Operation cancelled.");
            return;
        }
        
        if (safeMode) {
            createBackupFile(filename);
        }
    }
    
    // Write the file
    writeToFile(filename, content);
}
```

### Helper Methods

#### File Information Display
```java
private void showFileInfo(String filename) {
    File file = new File(filename);
    if (file.exists()) {
        System.out.println("\nFile Information:");
        System.out.println("Name: " + file.getName());
        System.out.println("Size: " + file.length() + " bytes");
        System.out.println("Last Modified: " + new Date(file.lastModified()));
        System.out.println("Path: " + file.getAbsolutePath());
    }
}
```

#### Overwrite Confirmation
```java
private boolean confirmOverwrite(String filename) {
    System.out.println("\nFile '" + filename + "' already exists!");
    System.out.print("Do you want to overwrite it? (y/n): ");
    String response = scanner.nextLine().toLowerCase().trim();
    return response.equals("y") || response.equals("yes");
}
```

#### Backup Creation
```java
private void createBackupFile(String originalFile) {
    try {
        String timestamp = LocalDateTime.now().format(
            DateTimeFormatter.ofPattern("yyyyMMdd_HHmmss"));
        String backupName = originalFile.replace(".txt", "_backup_" + timestamp + ".txt");
        
        Files.copy(Paths.get(originalFile), 
                  Paths.get(backupName), 
                  StandardCopyOption.REPLACE_EXISTING);
        
        System.out.println("Backup created: " + backupName);
    } catch (IOException e) {
        System.out.println("Warning: Could not create backup: " + e.getMessage());
    }
}
```

#### File Listing
```java
private void listExistingFiles() {
    System.out.println("\n=== Existing Text Files ===");
    
    File currentDir = new File(".");
    File[] files = currentDir.listFiles((dir, name) -> name.toLowerCase().endsWith(".txt"));
    
    if (files == null || files.length == 0) {
        System.out.println("No .txt files found in current directory.");
        return;
    }
    
    System.out.printf("%-4s %-20s %-12s %-25s%n", "#", "Filename", "Size", "Modified");
    System.out.println("".repeat(65));
    
    for (int i = 0; i < files.length; i++) {
        File file = files[i];
        String size = formatFileSize(file.length());
        String modified = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
            .format(new Date(file.lastModified()));
        
        System.out.printf("%-4d %-20s %-12s %-25s%n", 
                         i + 1, file.getName(), size, modified);
    }
    
    System.out.println("\nTotal files: " + files.length);
}
```

#### File Size Formatting
```java
private String formatFileSize(long bytes) {
    if (bytes < 1024) return bytes + " B";
    if (bytes < 1024 * 1024) return String.format("%.1f KB", bytes / 1024.0);
    return String.format("%.1f MB", bytes / (1024.0 * 1024.0));
}
```

## Sample Program Flow

```
=== Enhanced Text File Writer ===

1. Write Simple Text
2. Write Personal Information
3. Write Shopping List
4. Write Configuration Data
5. List Existing Files
6. Create Backup
7. Restore from Backup
8. Settings
9. Exit

Choose an option (1-9): 5

=== Existing Text Files ===
#    Filename             Size         Modified                  
1    test.txt             45 B         2024-01-15 10:30:25      
2    data.txt             1.2 KB       2024-01-15 09:15:10      

Total files: 2

Press Enter to continue...

Choose an option (1-9): 1

=== Write Simple Text ===
Enter the text content: This is new content!
Enter filename (with .txt extension): test.txt

File Information:
Name: test.txt
Size: 45 bytes
Last Modified: Mon Jan 15 10:30:25 GMT 2024
Path: /current/directory/test.txt

File 'test.txt' already exists!
Do you want to overwrite it? (y/n): y
Backup created: test_backup_20240115_143022.txt
File 'test.txt' created successfully!

Press Enter to continue...
```

## Learning Objectives

After completing this exercise, you should be able to:

1. **Check file existence** and display file information
2. **Implement overwrite protection** with user confirmation
3. **Create automatic backups** before file operations
4. **List directory contents** and filter by file type
5. **Format file information** (size, dates) for display
6. **Implement safe file operations** with error handling
7. **Create user-friendly file management** interfaces
8. **Handle file restoration** from backups

## Bonus Challenges

1. **File search**: Search for files by name pattern or content
2. **Batch operations**: Select multiple files for backup or deletion
3. **File comparison**: Compare original and backup files
4. **Compression**: Compress backup files to save space
5. **Cloud backup**: Integrate with cloud storage services
6. **File history**: Keep version history of files
7. **Undo functionality**: Undo last file operation

Good luck with your enhanced file manager implementation!

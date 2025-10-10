# Exercise - Text File Writer

Create a console application that allows users to write different types of text data to files. This exercise will help you practice basic file writing operations.

## Requirements

Create a `TextFileWriter` class with a menu-driven console interface that allows users to:

### 1. Write Simple Text
- Prompt user for text content
- Write the text to a file
- Allow user to specify the filename

### 2. Write Personal Information
- Collect user's name, age, email, and phone number
- Write this information to a file in a formatted way
- Use a structured format (like a profile)

### 3. Write a Shopping List
- Allow user to enter multiple items
- Write items to a file with numbering
- Continue until user enters "done"

### 4. Write Configuration Data
- Write application settings to a file
- Include various data types (strings, numbers, booleans)

## Implementation Guidelines

### Basic Class Structure
```java
import java.io.*;
import java.util.*;

public class TextFileWriter {
    private Scanner scanner;
    
    public TextFileWriter() {
        this.scanner = new Scanner(System.in);
    }
    
    public void run() {
        // Main menu loop
    }
    
    private void writeSimpleText() {
        // Implementation for option 1
    }
    
    private void writePersonalInfo() {
        // Implementation for option 2
    }
    
    private void writeShoppingList() {
        // Implementation for option 3
    }
    
    private void writeConfiguration() {
        // Implementation for option 4
    }
    
    public static void main(String[] args) {
        new TextFileWriter().run();
    }
}
```

### Menu Structure
```
=== Text File Writer ===

1. Write Simple Text
2. Write Personal Information
3. Write Shopping List
4. Write Configuration Data
5. Exit

Choose an option (1-5):
```

## Detailed Requirements

### Option 1: Write Simple Text
- Prompt: "Enter the text content:"
- Prompt: "Enter filename (with .txt extension):"
- Write the text to the specified file
- Confirm successful creation

**Example:**
```
Enter the text content: This is my first text file!
Enter filename (with .txt extension): mytext.txt
File 'mytext.txt' created successfully!
```

### Option 2: Write Personal Information
Collect and write the following information:
- Full Name
- Age
- Email Address
- Phone Number
- Occupation

**Output Format:**
```
=== PERSONAL PROFILE ===
Name: John Doe
Age: 25
Email: john.doe@email.com
Phone: (555) 123-4567
Occupation: Software Developer
Created: 2024-01-15
```

### Option 3: Write Shopping List
- Allow user to enter items one by one
- Continue until user types "done"
- Number each item in the list

**Example Output:**
```
=== SHOPPING LIST ===
1. Milk
2. Bread
3. Eggs
4. Apples
5. Chicken
Total items: 5
```

### Option 4: Write Configuration Data
Write application configuration with these settings:
- App Name: "MyApplication"
- Version: "1.0.0"
- Debug Mode: true
- Max Users: 100
- Database URL: "localhost:3306"
- Timeout: 30 seconds

**Output Format:**
```
# Application Configuration
app.name=MyApplication
app.version=1.0.0
debug.mode=true
max.users=100
database.url=localhost:3306
timeout.seconds=30
```

## Implementation Tips

### 1. Use Try-With-Resources
Always use try-with-resources for automatic file handling:

```java
try (PrintWriter writer = new PrintWriter(new FileWriter(filename))) {
    // Write content
} catch (IOException e) {
    System.out.println("Error: " + e.getMessage());
}
```

### 2. Input Validation
Validate user input where appropriate:

```java
private String getValidFilename() {
    String filename;
    do {
        System.out.print("Enter filename: ");
        filename = scanner.nextLine().trim();
        if (filename.isEmpty()) {
            System.out.println("Filename cannot be empty!");
        }
    } while (filename.isEmpty());
    return filename;
}
```

### 3. Error Handling
Handle file writing errors gracefully:

```java
private void writeToFile(String filename, String content) {
    try (PrintWriter writer = new PrintWriter(new FileWriter(filename))) {
        writer.print(content);
        System.out.println("File '" + filename + "' created successfully!");
    } catch (IOException e) {
        System.out.println("Error creating file: " + e.getMessage());
    }
}
```

### 4. Menu Loop
Implement a clean menu system:

```java
public void run() {
    int choice;
    do {
        displayMenu();
        choice = getMenuChoice();
        
        switch (choice) {
            case 1: writeSimpleText(); break;
            case 2: writePersonalInfo(); break;
            case 3: writeShoppingList(); break;
            case 4: writeConfiguration(); break;
            case 5: System.out.println("Goodbye!"); break;
            default: System.out.println("Invalid choice!");
        }
        
        if (choice != 5) {
            System.out.println("\nPress Enter to continue...");
            scanner.nextLine();
        }
    } while (choice != 5);
}
```

## Sample Program Flow

```
=== Text File Writer ===

1. Write Simple Text
2. Write Personal Information
3. Write Shopping List
4. Write Configuration Data
5. Exit

Choose an option (1-5): 1

Enter the text content: Hello, this is a test file!
Enter filename (with .txt extension): test.txt
File 'test.txt' created successfully!

Press Enter to continue...

=== Text File Writer ===

1. Write Simple Text
2. Write Personal Information
3. Write Shopping List
4. Write Configuration Data
5. Exit

Choose an option (1-5): 2

Enter your full name: Alice Johnson
Enter your age: 28
Enter your email: alice@example.com
Enter your phone: (555) 987-6543
Enter your occupation: Data Scientist
Enter filename: alice_profile.txt
File 'alice_profile.txt' created successfully!

Press Enter to continue...

Choose an option (1-5): 5
Goodbye!
```

## Learning Objectives

After completing this exercise, you should be able to:

1. **Create and write to text files** using FileWriter and PrintWriter
2. **Handle file I/O exceptions** properly with try-catch blocks
3. **Use try-with-resources** for automatic resource management
4. **Format text output** with proper structure and formatting
5. **Create interactive console applications** with menu systems
6. **Validate user input** for filenames and content
7. **Write different data types** to files in text format

## Bonus Challenges

1. **Add file listing**: Show existing .txt files in the current directory
2. **File overwrite protection**: Ask for confirmation before overwriting existing files
3. **Append mode**: Add option to append to existing files instead of overwriting
4. **Multiple formats**: Support different output formats (CSV, JSON, XML)
5. **File preview**: Show file content before saving

Good luck with your text file writer implementation!

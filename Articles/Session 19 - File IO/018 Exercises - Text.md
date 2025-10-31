# Exercises about writing and reading text files

Create a new package for the exercises in this page.

## Exercise 15.1 - Simple console file writing app

Create a console application that allows users to write different types of text data to files. 

## Requirements

Create a `TextFileWriter` class with a menu-driven console interface that allows users to:

### 1. Write Simple Text
- Allow user to specify the filename (automatically add .txt extension)
- Prompt user for text content
- Write the text to a file

The above can then be done repeatedly, creating multiple files.

Predefine the folder, where the files are written to.

Hint: You could create an object for the data, generate a toString method for it, and then write that to the file.


## Implementation Tips

### 1. Use Try-With-Resources
Generally, use try-with-resources for automatic file handling:

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

## Example Output

```
=== Text File Writer ===
1. Write simple text
2. Exit
Choose option: 1

Enter filename: 
note
Enter text content: 
This is my first note!
File 'note.txt' created successfully!

=== Text File Writer ===
1. Write simple text
2. Exit
Choose option: 1

Enter filename: 
shopping
Enter text content: 
Milk, Eggs, Bread, Coffee
File 'shopping.txt' created successfully!

=== Text File Writer ===
1. Write simple text
2. Exit
Choose option: 1

Enter filename: 

Filename cannot be empty!
Enter filename: reminder
Enter text content: 
Remember to call mom at 3 PM today
File 'reminder.txt' created successfully!

=== Text File Writer ===
1. Write simple text
2. Exit
Choose option: 2

Goodbye!
```

After running the program, the following files would be created:

**note.txt:**
```
This is my first note!
```

**shopping.txt:**
```
- Milk
- Eggs
- Bread
- Coffee
```

**reminder.txt:**
```
Remember to call mom at 3 PM today
```

## Exercise 15.2 - Read files

Expand the above exercise, to now allow the user to
- get a list of existing files, and then 
- choose one to read. The content should then be displayed in the console.
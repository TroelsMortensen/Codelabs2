# Exercise - File Manager

Create a console application that allows users to manage files in a single working directory. 

Yes, this is just a slightly larger version of a previous exercise. You could just copy the code from the previous exercise, and modify it to suit your needs. But _do_ make a copy of the previous exercise.

## Requirements

Your file manager should provide the following functionality:

### Functional requirements

1. **Create a new file** - Create a new text file with user-provided content
2. **Overwrite a file** - Replace the entire content of an existing file
3. **Append text to a file** - Add new content to the end of an existing file (this is perhaps tricky with binary files, consider it a challenge)
4. **List existing files** - Show all files in the working directory
5. **View file content** - Show the content of a file


Can you think of any other features that would be useful?

Extra features, could be:
- Delete a file
- Rename a file

### Non-functional requirements
You decide whether to use binary or text files.

### User Interface

The application should present a menu-driven interface:

```
=== File Manager ===

1. Create new file
2. Overwrite existing file
3. Append to existing file 
4. List all files
5. View file content
5. Exit

Choose an option (1-5):
```

## Implementation Details

### File Operations

- **Create new file**: Ask for filename and content, create the file
- **Overwrite file**: Ask for filename and new content, replace all existing content
- **Append to file**: Ask for filename and additional content, add to the end
- **List files**: Show all files in the current directory with basic information
- **View file content**: Show the content of a file

Handle potential errors gracefully.


### User Experience

- Provide clear feedback for all operations
- Show success/error messages
- Allow users to continue after each operation
- Handle user input validation

## Example Program Flow

```
=== File Manager ===

1. Create new file
2. Overwrite existing file
3. Append to existing file
4. List all files
5. Exit

Choose an option (1-5): 1

Enter filename: notes.txt
Enter content (type 'END' on a new line to finish):
This is my first note.
I can write multiple lines.
END
File 'notes.txt' created successfully!

Press Enter to continue...

Choose an option (1-5): 4

Files in current directory:
- notes.txt (2 lines, 45 bytes)
- config.txt (1 line, 12 bytes)

Press Enter to continue...

Choose an option (1-5): 3

Enter filename: notes.txt
Enter content to append (type 'END' on a new line to finish):
This is additional content.
END
Content appended to 'notes.txt' successfully!

Press Enter to continue...

Choose an option (1-5): 5

Goodbye!
```

## Technical Requirements

### File Information Display

When listing files, show:
- Filename
- Number of lines (for text files)
- File size in bytes
- Last modified date (optional)

### Input Handling

- Use `Scanner` for user input
- Handle multi-line input for file content
- Validate filename input
- Provide clear prompts and instructions

### File Operations

- Use appropriate Java I/O classes (`FileWriter`, `PrintWriter`, `Files`, etc.)
- Implement proper exception handling
- Use try-with-resources for automatic resource management


## Implementation Tips

### File Content Input

For multi-line input, consider this approach:

```java
Scanner scanner = new Scanner(System.in);
StringBuilder contentBuilder = new StringBuilder();
String line;

System.out.println("Enter content (type 'END' on a new line to finish):");
while (scanner.hasNextLine()) {
    line = scanner.nextLine();
    if (line.equals("END")) {
        break;
    }
    contentBuilder.append(line).append("\n");
}
String result = contentBuilder.toString();
```

What's the StringBuilder, you might ask? It is a class that allows you to build a string incrementally. It is more efficient than concatenating strings using the `+` operator. Just use the above code, or google further details.

### File Information

Use `Files` class methods to get file information:

```java
Path filePath = Paths.get(filename);
long size = Files.size(filePath);
BasicFileAttributes attrs = Files.readAttributes(filePath, BasicFileAttributes.class);
```

### Error Handling

Implement comprehensive error handling:

```java
try {
    // File operation
} catch (FileNotFoundException e) {
    System.out.println("Error: File not found - " + e.getMessage());
} catch (IOException e) {
    System.out.println("Error: Unable to access file - " + e.getMessage());
} catch (SecurityException e) {
    System.out.println("Error: Permission denied - " + e.getMessage());
}
```

## Testing Your Application

Test your file manager with these scenarios:

1. **Create a new file** with multi-line content
2. **Overwrite an existing file** with different content
3. **Append to a file** multiple times
4. **List files** in an empty directory
5. **List files** in a directory with multiple files
6. **Handle errors** by trying to overwrite a non-existent file
7. **Handle errors** by trying to append to a non-existent file

## Success Criteria

Your file manager is successful if it:

- ✅ Provides a clear, intuitive menu interface
- ✅ Successfully creates, overwrites, and appends to files
- ✅ Lists files with useful information
- ✅ Handles errors gracefully with informative messages
- ✅ Allows users to perform multiple operations in one session
- ✅ Uses proper Java I/O practices (try-with-resources, exception handling)
- ✅ Provides clear feedback for all operations

Good luck building your file manager!
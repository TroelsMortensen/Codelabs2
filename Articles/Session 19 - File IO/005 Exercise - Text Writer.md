# Exercises - Text File Writer

## Exercise 5.0 - Relative path
First, let's just explore the text writing a little bit. And play with file locations.

Create a new class, and put the following code in it:

```java
public static void main(String[] args) {
    try {
        FileWriter writer = new FileWriter("test.txt");
        writer.write("Hello, World!");
        writer.close();
    } catch (IOException e) {
        System.out.println("Error writing file: " + e.getMessage());
    }
}
```

This should write out "Hello, World!" to the file "test.txt". But where is that file?
Well, if you give it just a name, like above, the location will be relative, to where your program is running.

Mine ends up here:

![File location](Resources/FileLocation.png)

You can double click it, and verify the content. IntelliJ can open text files just fine.

## Exercise 5.1 - Absolute path

Another approach is to use an absolute path, which is a full path to the file. This is useful if you want to write to a file in a different location.

For example, I can define the file path and name like below, and the file will be created in the Documents folder of my user account.

```java
public static void main(String[] args) {
    try {
        FileWriter writer = new FileWriter("C:\\Users\\YourUsername\\Documents\\test.txt");
        writer.write("Hello, World!");
        writer.close();
    } catch (IOException e) {
        System.out.println("Error writing file: " + e.getMessage());
    }
}
```

Give it a try, remember to update the path to something on your computer.

Why the `\\` escape character? Because the `\` is used as an escape character in Java strings. So, we need to escape it with another `\`. 

If you are on mac or linux, you can use the `/` character instead of `\`.

## Exercise 5.2 - Simple console file app

Create a console application that allows users to write different types of text data to files. 

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

Hint: You could create an object for the data, generate a toString method for it, and then write that to the file.



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

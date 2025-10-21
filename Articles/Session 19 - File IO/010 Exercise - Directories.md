# Exercise - Directories

In this exercise you will create a Directories class, which can work with directories, similar to the Files class can work with files (and directories). This is to make it clearer if you are trying to work with files or directories.

The plan is to use the Files class to handle all these operations. We just wrap those Files-methods in a more user-friendly way.

Similar to how the PrintWriter wraps the FileWriter class.

## Exercise 10.0 - Create Directories class
First, create a new class called `Directories`. Yeah, that's it, quickly done.

You _might_ actually want to create a new package for this, outside of the `session19` package. This helper class could become useful in other exercises.

A package structure could look like this:

```
src/
├── directorymanagement
│   └── Directories.java
... all the other sessionX packages...
```

## Exercise 10.1 - Create single directory

### A - relative directory

Add a method to the Directories class called `createRelativeDirectory` that takes a String argument and creates a directory with that name.

Example usage:

```java
Directories.createRelativeDirectory("test");
```

This should create a directory called `test` in the current working directory.



### B - absolute directory

Sometimes, relative directories are not enough. You want to create a directory in a specific location. For example, you want to create a directory in the `src` directory.

Add a method to the Directories class called `createAbsoluteDirectory` that takes a String argument and creates a directory with that name in the `src` directory.

Example usage:

```java
Directories.createAbsoluteDirectory("C:\\Users\\YourUsername\\Documents\\test");
```

This should create a directory called `test` in the `C:\Users\YourUsername\Documents` directory.

Remember to verify that the parent directory exists! You can use the `Files.exists` method to check if a directory exists. Otherwise throw an exception, either an `IOException` or your own custom exception. Should this be a checked exception, or an unchecked exception?

## Exercise 10.2 - Create nested directories

Create two new methods: `createRelativeDirectories` and `createAbsoluteDirectories`. They should create all necessary parent directories.

Example usage:

```java
Directories.createRelativeDirectories("test\\test2");
```

This should create a directory called `test` in the current working directory, and then create a directory called `test2` in the `test` directory.

Or with absolute directories:

```java
Directories.createAbsoluteDirectories("C:\\Users\\YourUsername\\Documents\\test\\test2");
```

This should create a directory called `test` in the `C:\Users\YourUsername\Documents` directory, and then create a directory called `test2` in the `test` directory.

Again, there are relevant methods on the `Files` class to help you with this.

## Exercise 10.3 - Check if directory exists

Add a method called `exists` that takes a String argument and returns a boolean indicating whether the directory exists.

Example usage:

```java
if (Directories.exists("test")) {
    System.out.println("Directory exists!");
} else {
    System.out.println("Directory does not exist.");
}
```

Consider handling both relative and absolute directories with the same method. `Files` has a method called `exists` that can be used to check if a directory exists.

## Exercise 10.4 - Delete directory

Add a method called `delete` that takes a String argument and deletes the directory. The directory must be empty for this to work!!!!

Example usage:

```java
Directories.delete("test");
```

**Hint**: Use `Files.delete()` method. Handle the case where the directory is not empty - you might want to throw a custom exception or return a boolean indicating success/failure. Figure out how to check if the directory is empty.

## Exercise 10.5 - List directory contents

Add a method called `listContents` that takes a String argument (directory path) and returns a list of all files and directories in that directory.

Example usage:

```java
List<String> contents = Directories.listContents("src");
for (String item : contents) {
    System.out.println(item);
}
```

**Hint**: Use `Files.list()` or `Files.walk()` methods. Return just the names, not the full paths. Append a (file) or (directory) to the name, to indicate if it is a file or a directory.

## Exercise 10.6 - Console application for directory management

Create a console application that allows users to manage directories. The application should have a menu with the following options:

```
=== Directory Manager ===

1. Create single directory
2. Create nested directories
3. Check if directory exists
4. Delete directory
5. List directory contents
6. Exit

Choose an option (1-6):
```

### Implementation Requirements

- Use the `Directories` class you created
- Handle all exceptions gracefully
- Provide clear feedback to the user
- Allow users to specify both relative and absolute paths
- For listing contents, show whether each item is a file or directory


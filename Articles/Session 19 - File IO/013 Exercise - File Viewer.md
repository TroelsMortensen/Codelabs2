# Exercise 13 - File Viewer

This exercise builds on your previous **File Manager** exercise. You'll create an enhanced version that can also display the content of files, making it a complete file management and viewing application.

## Step 1: Copy Your File Manager

First, make a copy of your previous **File Manager** exercise, from page 11, "Exercise - File Manager". This will serve as the foundation for the enhanced version. You make the copy, to make it easier to present your work in class.


### Copy Instructions

1. Create a new package called `filemanagerv2` in your `session19` package. Or whatever you wanna call it, and whereever you wanna put it 
2. Copy all your File Manager code
3. Update all the package declarations

Maybe more..

## Step 2: Enhance with File Viewing

Add the following new functionality to your existing file manager:

### New Menu Option

Update your menu to include file viewing:

```
=== File Viewer ===

1. Create new file
2. Overwrite existing file
3. Append to existing file
4. List all files
5. View file content
6. Exit

Choose an option (1-6):
```

### File Content Display

Implement a `viewFileContent` method that:

- **Asks for filename** from the user. When option 5 above is selected, you could show a list of all the files, and ask which one the user wants to view
- **Reads and displays** the entire file content



## Bonus Challenges

You can further expand on your exercise with the following features:
- allow the user to create new folders
- delete a file
- delete a folder (if it is empty)
- allow the user to copy a file. Ask what the new filename should be. Check if the file already exists, and if so, ask the user if they want to overwrite it.
- display file meta information, such as size, creation date, last modified date, etc.

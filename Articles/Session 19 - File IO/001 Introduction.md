# Introduction to File I/O

Welcome to the world of file input and output in Java! In this learning path, you'll learn how to work with files - reading data from them, writing data to them, and understanding the different ways computers store information.

## What are Files?

A **file** is a collection of data stored on a computer's storage device (like a hard drive, SSD, or USB stick). Think of files like digital containers that hold information. You have already been working plenty with all kinds of files, like text files, images, videos, etc. The concept should be familiar to you.

### Real-World Analogy

Imagine files like **physical documents**:
- A **text file** is like a handwritten letter or printed document
- A **binary file** is like a photo, video, or music file
- A **folder** is like a filing cabinet that organizes your documents

This is how we organize data on our computer, and we will learn how to work with them in Java.

## Why Store Data in Files?

### 1. **Persistence**

Let's start with the definition:

> Persistence means that the data is stored for a longer period of time, than the program's lifetime. You can close your program, restart it, and the data will still be there. 

Persistence is usually done with databases, but you will have to wait until next semester for that. This semester, we will focus on files.

When your program ends, all the data stored in variables is lost. Files allow data to survive beyond the program's lifetime:

```java
// This data is lost when the program ends
String userData = "John, 25, Engineer";
int score = 1500;
```

Imagine we have a method, which will save some data to a file. Even if the program ends, the data will still be there, in the file.

```java
// This data is saved permanently in a file
// Even after the program ends, the data remains
saveToFile("userdata.txt", userData);
saveToFile("scores.txt", score);
```

### 2. **Data Sharing**
Files allow different programs to share data:

```
Program A writes data → File → Program B reads data
```

### 3. **Large Amounts of Data**
Files can store much more data than memory:

- **Memory**: Limited (usually 4-16 GB)
- **Files**: Can be gigabytes or terabytes in size

### 4. **Backup and Recovery**
Files can be backed up, copied, and restored if something goes wrong.


## What You'll Learn

In this learning path, you'll learn how to:

1. **Understand file types** - text vs binary files
2. **Work with streams** - the mechanism for reading/writing data
3. **Write text to files** - create and save text content
4. **Read text from files** - load and process file content
5. **Handle binary data** - work with non-text files
6. **Serialize objects** - save complex Java objects to files
7. **Error handling** - deal with file operations that might fail
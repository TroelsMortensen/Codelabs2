# Introduction to File I/O

Welcome to the world of file input and output in Java! In this session, you'll learn how to work with files - reading data from them, writing data to them, and understanding the different ways computers store information.

## What are Files?

A **file** is a collection of data stored on a computer's storage device (like a hard drive, SSD, or USB stick). Think of files like digital containers that hold information.

### Real-World Analogy

Imagine files like **physical documents**:
- A **text file** is like a handwritten letter or printed document
- A **binary file** is like a photo, video, or music file
- A **folder** is like a filing cabinet that organizes your documents

## Why Store Data in Files?

### 1. **Persistence**
When your program ends, all the data stored in variables is lost. Files allow data to survive beyond the program's lifetime:

```java
// This data is lost when the program ends
String userData = "John, 25, Engineer";
int score = 1500;
```

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

## Common Use Cases

### **Configuration Files**
Store settings for your application:
```
database.url=jdbc:mysql://localhost:3306/mydb
database.user=admin
database.password=secret123
```

### **User Data**
Save user preferences, profiles, or game progress:
```
Player Name: Alice
Level: 15
Score: 2,450
Achievements: [Speed Runner, Collector, Explorer]
```

### **Log Files**
Record what happens in your program for debugging:
```
2024-01-15 10:30:15 - User login successful
2024-01-15 10:31:22 - Database connection established
2024-01-15 10:32:05 - Error: File not found
```

### **Data Exchange**
Import/export data between systems:
```
CSV files for spreadsheets
JSON files for web APIs
XML files for configuration
```

## What You'll Learn

In this session, you'll learn how to:

1. **Understand file types** - text vs binary files
2. **Work with streams** - the mechanism for reading/writing data
3. **Write text to files** - create and save text content
4. **Read text from files** - load and process file content
5. **Handle binary data** - work with non-text files
6. **Serialize objects** - save complex Java objects to files
7. **Error handling** - deal with file operations that might fail

## Getting Started

File I/O in Java involves several key concepts:
- **Files** - the actual data containers
- **Streams** - the pathways for data flow
- **Readers/Writers** - specialized tools for text
- **InputStreams/OutputStreams** - tools for binary data

Let's start by understanding the different types of files and how Java handles them!

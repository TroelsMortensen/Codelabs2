# File Types: Text vs Binary

Understanding the difference between text and binary files is fundamental to working with files in Java. Let's explore these two main categories.

## Text Files

**Text files** contain human-readable characters that can be displayed and edited with a simple text editor.

### Characteristics of Text Files:
- **Human-readable** - you can open them in Notepad, VS Code, etc.
- **Character-based** - store letters, numbers, punctuation, and symbols
- **Line-oriented** - often organized into lines of text
- **Platform-independent** - mostly work the same across different operating systems

### Examples of Text Files:
```
- .txt files (plain text)
- .java files (Java source code)
- .html files (web pages)
- .csv files (comma-separated values)
- .json files (data exchange)
- .xml files (structured data)
- .properties files (configuration)
- .log files (application logs)
```

### Example Text File Content:
```
Hello World!
This is a text file.
Line 3
Special characters: @#$%^&*()
Numbers: 12345
```

## Binary Files

**Binary files** contain data in a format that's not directly human-readable. They store data as sequences of bytes that represent specific formats.

### Characteristics of Binary Files:
- **Not human-readable** - appear as gibberish in a text editor
- **Byte-based** - store raw data in binary format
- **Format-specific** - require specific programs to interpret
- **Often more efficient** - can store data more compactly

### Examples of Binary Files:
```
- .jpg, .png files (images)
- .mp3, .wav files (audio)
- .mp4, .avi files (video)
- .pdf files (documents)
- .exe files (executable programs)
- .zip files (compressed archives)
- .class files (compiled Java code)
```

### What Binary Data Looks Like:
If you opened a binary file in a text editor, you might see:
```
ÿØÿàJFIFHHÿÛC           !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~ÿÛC
```

## Key Differences

| Aspect | Text Files | Binary Files |
|--------|------------|--------------|
| **Readability** | Human-readable | Not human-readable |
| **Content** | Characters/text | Raw bytes |
| **Editing** | Any text editor | Specialized tools |
| **Size** | Larger for complex data | Often more compact |
| **Portability** | High (mostly universal) | Format-dependent |
| **Java Classes** | Reader/Writer | InputStream/OutputStream |

## Why This Matters in Java

Java provides different classes for handling these file types:

### For Text Files:
```java
// Reading text files
FileReader reader = new FileReader("data.txt");
BufferedReader bufferedReader = new BufferedReader(reader);

// Writing text files
FileWriter writer = new FileWriter("output.txt");
BufferedWriter bufferedWriter = new BufferedWriter(writer);
```

### For Binary Files:
```java
// Reading binary files
FileInputStream inputStream = new FileInputStream("image.jpg");

// Writing binary files
FileOutputStream outputStream = new FileOutputStream("copy.jpg");
```

## Choosing the Right Type

### Use Text Files When:
- Data is human-readable
- You want easy debugging
- Data needs to be edited by hand
- You're working with configuration or logs
- Data is relatively simple

### Use Binary Files When:
- Working with media files (images, audio, video)
- Need maximum efficiency
- Storing complex data structures
- Data contains non-text characters
- Performance is critical

## Common Text File Formats

### **CSV (Comma-Separated Values)**
```
Name,Age,City
John,25,New York
Alice,30,London
Bob,35,Tokyo
```

### **JSON (JavaScript Object Notation)**
```json
{
  "name": "John",
  "age": 25,
  "city": "New York",
  "hobbies": ["reading", "gaming", "cooking"]
}
```

### **Properties File**
```
database.url=jdbc:mysql://localhost:3306/mydb
database.user=admin
database.password=secret123
app.version=1.0.0
```

## What's Next?

Now that you understand the difference between text and binary files, let's learn about **streams** - the mechanism Java uses to read and write data to and from files!

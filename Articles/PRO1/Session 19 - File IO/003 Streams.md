# Streams: The Flow of Data

Streams are Java's way of handling the flow of data to and from files. Think of streams as **pipes** that connect your program to files, allowing data to flow in one direction. It is not all in one go, but rather in chunks.

And then Java introduced another kind of streams, which operate on collections of data, like lists and sets. But that kind of stream is not covered in this learning path.

## What are Streams?

A **stream** is an abstraction that represents a flow of data. It's like a water pipe - data flows through it from a source to a destination (e.g. from file to program).

### Real-World Analogy

Imagine streams like **water pipes**:
- **Input Stream** = Water flowing INTO your house
- **Output Stream** = Water flowing OUT of your house
- **Source** = Water reservoir or tank
- **Destination** = Your faucet or drain

## Types of Streams

### **Input Streams** (Reading Data)
Data flows **FROM** a source **TO** your program:

```
File ──> InputStream ──> Your Program
```

### **Output Streams** (Writing Data)
Data flows **FROM** your program **TO** a destination:

```
Your Program ──> OutputStream ──> File
```

## Stream Hierarchy in Java

Java has a well-organized hierarchy of stream classes, including:

```mermaid
classDiagram
    class _InputStream_ {
        <<abstract>>
        +read() int
        +read(byte[]) int
        +close() void
    }
    
    class _OutputStream_ {
        <<abstract>>
        +write(int) void
        +write(byte[]) void
        +close() void
    }
    
    class FileInputStream {
        +FileInputStream(File)
        +FileInputStream(String)
    }
    
    class FileOutputStream {
        +FileOutputStream(File)
        +FileOutputStream(String)
    }
    
    class FileReader {
        +FileReader(File)
        +FileReader(String)
    }
    
    class FileWriter {
        +FileWriter(File)
        +FileWriter(String)
    }
    
    _InputStream_ <|-- FileInputStream
    _OutputStream_ <|-- FileOutputStream
    FileReader ..> _InputStream_ : uses
    FileWriter ..> _OutputStream_ : uses
```

We will come back to concrete examples of these classes later in this learning path.

## Stream Characteristics

### **1. Sequential Access**
Streams read/write data in order, like reading a book page by page:

```java
// You can't skip to the middle without reading the beginning
FileInputStream stream = new FileInputStream("largefile.txt");
int firstByte = stream.read();  // Reads byte 1
int secondByte = stream.read(); // Reads byte 2
// Can't directly jump to byte 1000
```

Is this actually usable? Not really. You don't want to manually read each byte of a file to then reconstruct the data from that sequence of bytes. We will use another class for that particular purpose. That other class, the stream, will then use the `FileInputStream` to read the data.

### **2. One-Way Flow**
Streams flow in one direction:
- **Input streams** only read
- **Output streams** only write

## Common Stream Classes

| Class | Purpose | Data Type |
|-------|---------|-----------|
| `FileInputStream` | Read binary data from files | Bytes |
| `FileOutputStream` | Write binary data to files | Bytes |
| `FileReader` | Read text from files | Characters |
| `FileWriter` | Write text to files | Characters |
| `BufferedReader` | Read text with buffering | Lines/Strings |
| `PrintWriter` | Write formatted text | Strings |
| `ObjectInputStream` | Read Java objects | Objects |
| `ObjectOutputStream` | Write Java objects | Objects |

## What's Next?

Now that you understand streams (maybe?), let's start working with text files! We'll begin with writing text to files using Java's file I/O classes.

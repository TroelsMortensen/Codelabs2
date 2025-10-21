# Binary Data

So far, we've focused on **text files** - files that contain human-readable characters. Now let's explore **binary data** - data that's not directly human-readable and is stored as sequences of bytes.

## What is Binary Data?

**Binary data** is information stored in a format that uses only two states: 0 and 1. Each piece of information is represented as a sequence of bits (binary digits).

### Real-World Analogy

Think of binary data like **digital photos**:
- A **text file** is like a handwritten letter - you can read it directly
- A **binary file** is like a photograph - you need special tools (like a photo viewer) to see what it contains

## Binary vs Text Data

### Text Data
- **Human-readable** characters (letters, numbers, symbols)
- **Platform-dependent** encoding (ASCII, UTF-8, etc.)
- **Line-oriented** structure
- Examples: `.txt`, `.java`, `.html`, `.csv`

### Binary Data
- **Not human-readable** - appears as gibberish in text editors
- **Format-specific** - requires special programs to interpret
- **Byte-oriented** structure
- Examples: `.jpg`, `.mp3`, `.pdf`, `.exe`, `.class`

## Binary Data Examples

### What Binary Data Looks Like
If you open a binary file in a text editor, you might see:
```
ÿØÿàJFIFHHÿÛC           !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~ÿÛC
```

This is actually a JPEG image file header, but it's not readable as text.

### Common Binary File Types

| File Type | Description | Example |
|-----------|-------------|---------|
| **Images** | Photos, graphics | `.jpg`, `.png`, `.gif`, `.bmp` |
| **Audio** | Music, sounds | `.mp3`, `.wav`, `.flac` |
| **Video** | Movies, clips | `.mp4`, `.avi`, `.mov` |
| **Documents** | PDFs, Word docs | `.pdf`, `.docx` |
| **Executables** | Programs | `.exe`, `.dll` |
| **Compressed** | Archives | `.zip`, `.rar`, `.tar` |
| **Java** | Compiled code | `.class`, `.jar` |

## Working with Binary Data in Java

### Reading Binary Data

```java
import java.io.FileInputStream;
import java.io.IOException;

public class BinaryReader {
    public static void main(String[] args) {
        try (FileInputStream inputStream = new FileInputStream("image.jpg")) {
            int byteData;
            int byteCount = 0;
            
            System.out.println("First 20 bytes of the file:");
            while ((byteData = inputStream.read()) != -1 && byteCount < 20) {
                System.out.printf("%02X ", byteData);
                byteCount++;
                
                if (byteCount % 10 == 0) {
                    System.out.println(); // New line every 10 bytes
                }
            }
            
        } catch (IOException e) {
            System.out.println("Error reading binary file: " + e.getMessage());
        }
    }
}
```

**Output:**
```
First 20 bytes of the file:
FF D8 FF E0 00 10 4A 46 49 46 
00 01 01 01 00 48 00 48 00 00 
```

### Writing Binary Data

```java
import java.io.FileOutputStream;
import java.io.IOException;

public class BinaryWriter {
    public static void main(String[] args) {
        // Create some binary data (bytes)
        byte[] data = {0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64};
        
        try (FileOutputStream outputStream = new FileOutputStream("binary_data.dat")) {
            outputStream.write(data);
            System.out.println("Binary data written successfully!");
        } catch (IOException e) {
            System.out.println("Error writing binary file: " + e.getMessage());
        }
    }
}
```

### Copying Binary Files

```java
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class BinaryFileCopier {
    public static void copyFile(String sourceFile, String destFile) {
        try (FileInputStream inputStream = new FileInputStream(sourceFile);
             FileOutputStream outputStream = new FileOutputStream(destFile)) {
            
            int byteData;
            while ((byteData = inputStream.read()) != -1) {
                outputStream.write(byteData);
            }
            
            System.out.println("File copied successfully!");
            
        } catch (IOException e) {
            System.out.println("Error copying file: " + e.getMessage());
        }
    }
    
    public static void main(String[] args) {
        copyFile("original.jpg", "copy.jpg");
    }
}
```

## Binary Data Analysis

### File Header Analysis

Many binary files have recognizable headers that identify their type:

```java
import java.io.FileInputStream;
import java.io.IOException;

public class FileTypeDetector {
    public static String detectFileType(String filename) {
        try (FileInputStream inputStream = new FileInputStream(filename)) {
            byte[] header = new byte[4];
            int bytesRead = inputStream.read(header);
            
            if (bytesRead < 4) {
                return "Unknown";
            }
            
            // Check for common file signatures
            if (header[0] == (byte)0xFF && header[1] == (byte)0xD8) {
                return "JPEG Image";
            } else if (header[0] == (byte)0x89 && header[1] == 0x50 && 
                      header[2] == 0x4E && header[3] == 0x47) {
                return "PNG Image";
            } else if (header[0] == 0x25 && header[1] == 0x50 && 
                      header[2] == 0x44 && header[3] == 0x46) {
                return "PDF Document";
            } else if (header[0] == 0x50 && header[1] == 0x4B) {
                return "ZIP Archive";
            } else {
                return "Unknown";
            }
            
        } catch (IOException e) {
            return "Error reading file";
        }
    }
    
    public static void main(String[] args) {
        String[] files = {"image.jpg", "document.pdf", "archive.zip"};
        
        for (String filename : files) {
            System.out.println(filename + ": " + detectFileType(filename));
        }
    }
}
```

### Binary Data Statistics

```java
import java.io.FileInputStream;
import java.io.IOException;

public class BinaryAnalyzer {
    public static void analyzeBinaryFile(String filename) {
        try (FileInputStream inputStream = new FileInputStream(filename)) {
            long totalBytes = 0;
            int[] byteFrequency = new int[256]; // Count frequency of each byte value
            
            int byteData;
            while ((byteData = inputStream.read()) != -1) {
                byteFrequency[byteData]++;
                totalBytes++;
            }
            
            System.out.println("=== Binary File Analysis ===");
            System.out.println("File: " + filename);
            System.out.println("Total bytes: " + totalBytes);
            System.out.println("File size: " + (totalBytes / 1024.0) + " KB");
            
            // Find most common byte values
            System.out.println("\nMost common byte values:");
            for (int i = 0; i < 10; i++) {
                int maxFreq = 0;
                int maxByte = 0;
                
                for (int j = 0; j < 256; j++) {
                    if (byteFrequency[j] > maxFreq) {
                        maxFreq = byteFrequency[j];
                        maxByte = j;
                    }
                }
                
                if (maxFreq > 0) {
                    System.out.printf("0x%02X: %d occurrences (%.1f%%)%n", 
                                     maxByte, maxFreq, (maxFreq * 100.0 / totalBytes));
                    byteFrequency[maxByte] = 0; // Remove from consideration
                }
            }
            
        } catch (IOException e) {
            System.out.println("Error analyzing file: " + e.getMessage());
        }
    }
    
    public static void main(String[] args) {
        analyzeBinaryFile("image.jpg");
    }
}
```

## Binary Data in Java Objects

### Primitive Data Types as Binary

```java
import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class PrimitiveBinaryWriter {
    public static void main(String[] args) {
        try (DataOutputStream outputStream = new DataOutputStream(
                new FileOutputStream("primitives.dat"))) {
            
            // Write different primitive types
            outputStream.writeBoolean(true);
            outputStream.writeByte(127);
            outputStream.writeShort(32000);
            outputStream.writeInt(123456789);
            outputStream.writeLong(9876543210L);
            outputStream.writeFloat(3.14159f);
            outputStream.writeDouble(2.718281828459045);
            outputStream.writeChar('A');
            outputStream.writeUTF("Hello World"); // UTF-8 encoded string
            
            System.out.println("Primitive data written to binary file!");
            
        } catch (IOException e) {
            System.out.println("Error writing binary data: " + e.getMessage());
        }
    }
}
```

### Reading Primitive Data

```java
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;

public class PrimitiveBinaryReader {
    public static void main(String[] args) {
        try (DataInputStream inputStream = new DataInputStream(
                new FileInputStream("primitives.dat"))) {
            
            // Read data in the same order it was written
            boolean bool = inputStream.readBoolean();
            byte b = inputStream.readByte();
            short s = inputStream.readShort();
            int i = inputStream.readInt();
            long l = inputStream.readLong();
            float f = inputStream.readFloat();
            double d = inputStream.readDouble();
            char c = inputStream.readChar();
            String str = inputStream.readUTF();
            
            System.out.println("=== Read Binary Data ===");
            System.out.println("Boolean: " + bool);
            System.out.println("Byte: " + b);
            System.out.println("Short: " + s);
            System.out.println("Int: " + i);
            System.out.println("Long: " + l);
            System.out.println("Float: " + f);
            System.out.println("Double: " + d);
            System.out.println("Char: " + c);
            System.out.println("String: " + str);
            
        } catch (IOException e) {
            System.out.println("Error reading binary data: " + e.getMessage());
        }
    }
}
```

## Why Use Binary Files?

### Advantages of Binary Files
1. **Efficiency**: More compact storage
2. **Speed**: Faster reading/writing
3. **Precision**: Exact representation of data types
4. **Structure**: Can store complex data structures

### When to Use Binary Files
- **Large datasets** that need efficient storage
- **Media files** (images, audio, video)
- **Program data** that doesn't need human readability
- **Performance-critical** applications
- **Data exchange** between programs

## What's Next?

Now that you understand binary data, let's learn about **object serialization** - a powerful way to save entire Java objects to binary files and read them back later!

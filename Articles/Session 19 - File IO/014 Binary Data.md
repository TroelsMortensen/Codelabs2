# Binary Data

So far, we've focused on **text files** - files that contain human-readable characters. Now let's explore **binary data** - data that's not directly human-readable and is stored as sequences of bytes.


## What is Binary Data?

**Binary data** is information stored in a format that uses only two states: 0 and 1. Each piece of information is represented as a sequence of bits (binary digits).

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

This is not really important, you won't be doing this. It's only to show you how annoying it is to work with binary data. We will do this, but hide most of the details from you.

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

### So...

Okay, that looks super annoying to work with, so let's cut it short. Instead, we will use this mainly by converting data (e.g. objects) to binary, and write that binary to a file.

Let's explore that next.
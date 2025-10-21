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

All these files can be opened and read with a text editor, like Notepad, VS Code, etc.

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

Depending on what program tries to read a binary file, it will be able to interpret the data. For example, a photo viewer will be able to show you the photo, but a text editor will not.

And, as you will see, we can take an object in Java, convert it to binary, and save that to a file. This will be good for your semester project.

### What Binary Data Looks Like:
If you opened a binary file in a text editor, you might see:
```
ÿØÿàJFIFHHÿÛC           !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~ÿÛC
```

Not super meaningful, and that's because the binary data may not even represent text. It could be a photo, or a video, or an executable program, or a compressed archive, or a compiled Java code, or anything else.

## Key Differences

| Aspect | Text Files | Binary Files |
|--------|------------|--------------|
| **Readability** | Human-readable | Not human-readable |
| **Content** | Characters/text | Raw bytes |
| **Editing** | Any text editor | Specialized tools |
| **Size** | Larger for complex data | Often more compact |
| **Portability** | High (mostly universal) | Format-dependent |
| **Java Classes** | Reader/Writer | InputStream/OutputStream |


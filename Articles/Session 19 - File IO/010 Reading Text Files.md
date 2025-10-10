# Reading Text Files

Now let's learn how to read text data from files. Java provides several ways to read files, from simple byte-by-byte reading to high-level line-by-line reading.

## Basic Text Reading

### Using FileReader

`FileReader` is the simplest way to read text from a file:

```java
import java.io.FileReader;
import java.io.IOException;

public class BasicTextReader {
    public static void main(String[] args) {
        try {
            FileReader reader = new FileReader("data.txt");
            
            int character;
            while ((character = reader.read()) != -1) {
                System.out.print((char) character);
            }
            
            reader.close();
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
    }
}
```

### Using Try-With-Resources (Recommended)

```java
import java.io.FileReader;
import java.io.IOException;

public class SafeTextReader {
    public static void main(String[] args) {
        try (FileReader reader = new FileReader("data.txt")) {
            int character;
            while ((character = reader.read()) != -1) {
                System.out.print((char) character);
            }
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
        // Reader is automatically closed here
    }
}
```

## Better Approach: Using BufferedReader

`BufferedReader` provides more convenient methods for reading text:

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class BetterTextReader {
    public static void main(String[] args) {
        try (BufferedReader reader = new BufferedReader(new FileReader("data.txt"))) {
            String line;
            while ((line = reader.readLine()) != null) {
                System.out.println(line);
            }
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
    }
}
```

## Reading Different Data Types

### Reading Structured Data

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class StructuredDataReader {
    public static void main(String[] args) {
        List<String> lines = new ArrayList<>();
        
        try (BufferedReader reader = new BufferedReader(new FileReader("students.csv"))) {
            String line;
            while ((line = reader.readLine()) != null) {
                lines.add(line);
            }
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
        
        // Process the data
        System.out.println("=== Student Data ===");
        for (int i = 0; i < lines.size(); i++) {
            if (i == 0) {
                System.out.println("Header: " + lines.get(i));
            } else {
                System.out.println("Student " + i + ": " + lines.get(i));
            }
        }
    }
}
```

### Reading Configuration Files

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

public class ConfigReader {
    public static void main(String[] args) {
        Map<String, String> config = new HashMap<>();
        
        try (BufferedReader reader = new BufferedReader(new FileReader("config.properties"))) {
            String line;
            while ((line = reader.readLine()) != null) {
                // Skip empty lines and comments
                if (line.trim().isEmpty() || line.trim().startsWith("#")) {
                    continue;
                }
                
                // Parse key=value pairs
                int equalIndex = line.indexOf('=');
                if (equalIndex > 0) {
                    String key = line.substring(0, equalIndex).trim();
                    String value = line.substring(equalIndex + 1).trim();
                    config.put(key, value);
                }
            }
        } catch (IOException e) {
            System.out.println("Error reading config: " + e.getMessage());
        }
        
        // Display configuration
        System.out.println("=== Configuration ===");
        for (Map.Entry<String, String> entry : config.entrySet()) {
            System.out.println(entry.getKey() + " = " + entry.getValue());
        }
    }
}
```

## Modern Approach: Files.readAllLines()

Java 8+ provides convenient methods for reading entire files:

```java
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class ModernFileReader {
    public static void main(String[] args) {
        try {
            // Read all lines at once
            List<String> lines = Files.readAllLines(Paths.get("data.txt"));
            
            System.out.println("File contains " + lines.size() + " lines:");
            for (int i = 0; i < lines.size(); i++) {
                System.out.println((i + 1) + ": " + lines.get(i));
            }
            
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
    }
}
```

### Reading Entire File as String

```java
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class StringFileReader {
    public static void main(String[] args) {
        try {
            // Read entire file as a single string
            String content = Files.readString(Paths.get("data.txt"));
            System.out.println("File content:");
            System.out.println(content);
            
            // Get file statistics
            long lineCount = content.split("\n").length;
            System.out.println("Total lines: " + lineCount);
            System.out.println("Total characters: " + content.length());
            
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
        }
    }
}
```

## Reading with Error Handling

### Comprehensive Error Handling

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class RobustFileReader {
    public static void main(String[] args) {
        String filename = "data.txt";
        Path filePath = Paths.get(filename);
        
        // Check if file exists
        if (!Files.exists(filePath)) {
            System.out.println("Error: File '" + filename + "' does not exist!");
            return;
        }
        
        // Check if file is readable
        if (!Files.isReadable(filePath)) {
            System.out.println("Error: File '" + filename + "' is not readable!");
            return;
        }
        
        // Check file size
        try {
            long fileSize = Files.size(filePath);
            System.out.println("File size: " + fileSize + " bytes");
            
            if (fileSize == 0) {
                System.out.println("Warning: File is empty!");
                return;
            }
            
        } catch (IOException e) {
            System.out.println("Error getting file size: " + e.getMessage());
            return;
        }
        
        // Read the file
        try (BufferedReader reader = new BufferedReader(new FileReader(filename))) {
            System.out.println("\n=== File Content ===");
            
            String line;
            int lineNumber = 1;
            while ((line = reader.readLine()) != null) {
                System.out.printf("%3d: %s%n", lineNumber, line);
                lineNumber++;
            }
            
            System.out.println("\nFile read successfully!");
            
        } catch (IOException e) {
            System.out.println("Error reading file: " + e.getMessage());
            e.printStackTrace();
        }
    }
}
```

## Reading Different File Formats

### Reading CSV Files

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class CSVReader {
    public static void main(String[] args) {
        List<String[]> data = new ArrayList<>();
        
        try (BufferedReader reader = new BufferedReader(new FileReader("students.csv"))) {
            String line;
            while ((line = reader.readLine()) != null) {
                // Split by comma and trim whitespace
                String[] row = line.split(",");
                for (int i = 0; i < row.length; i++) {
                    row[i] = row[i].trim();
                }
                data.add(row);
            }
        } catch (IOException e) {
            System.out.println("Error reading CSV: " + e.getMessage());
            return;
        }
        
        // Display CSV data
        System.out.println("=== CSV Data ===");
        for (int i = 0; i < data.size(); i++) {
            System.out.print("Row " + (i + 1) + ": ");
            for (int j = 0; j < data.get(i).length; j++) {
                System.out.print(data.get(i)[j]);
                if (j < data.get(i).length - 1) {
                    System.out.print(" | ");
                }
            }
            System.out.println();
        }
    }
}
```

### Reading Log Files

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class LogReader {
    public static void main(String[] args) {
        try (BufferedReader reader = new BufferedReader(new FileReader("application.log"))) {
            String line;
            int totalLines = 0;
            int errorLines = 0;
            int warningLines = 0;
            
            while ((line = reader.readLine()) != null) {
                totalLines++;
                
                if (line.contains("[ERROR]")) {
                    errorLines++;
                    System.out.println("ERROR: " + line);
                } else if (line.contains("[WARNING]")) {
                    warningLines++;
                    System.out.println("WARNING: " + line);
                }
            }
            
            System.out.println("\n=== Log Summary ===");
            System.out.println("Total lines: " + totalLines);
            System.out.println("Error lines: " + errorLines);
            System.out.println("Warning lines: " + warningLines);
            
        } catch (IOException e) {
            System.out.println("Error reading log file: " + e.getMessage());
        }
    }
}
```

## Performance Considerations

### Reading Large Files

For very large files, reading everything at once might cause memory issues:

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class LargeFileReader {
    public static void main(String[] args) {
        String filename = "large_file.txt";
        
        try (BufferedReader reader = new BufferedReader(new FileReader(filename))) {
            String line;
            int lineCount = 0;
            
            // Process file line by line to save memory
            while ((line = reader.readLine()) != null) {
                lineCount++;
                
                // Process each line (e.g., search for specific content)
                if (line.contains("search_term")) {
                    System.out.println("Found at line " + lineCount + ": " + line);
                }
                
                // Print progress every 1000 lines
                if (lineCount % 1000 == 0) {
                    System.out.println("Processed " + lineCount + " lines...");
                }
            }
            
            System.out.println("Total lines processed: " + lineCount);
            
        } catch (IOException e) {
            System.out.println("Error reading large file: " + e.getMessage());
        }
    }
}
```

## Common Reading Methods Summary

| Method | Use Case | Memory Usage | Performance |
|--------|----------|--------------|-------------|
| `FileReader.read()` | Character by character | Low | Slow |
| `BufferedReader.readLine()` | Line by line | Medium | Good |
| `Files.readAllLines()` | Entire file at once | High | Fast (small files) |
| `Files.readString()` | Entire file as string | High | Fast (small files) |

## What's Next?

Now that you understand how to read text files, let's practice with an exercise that combines file reading with your previous file writing exercises. You'll create a file viewer and analyzer that can read and display file contents in different ways!

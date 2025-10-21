# Reading Binary Files

Now let's learn how to read binary data from files and reconstruct Java objects. This is the complement to writing binary files and completes the cycle of data persistence.

## Reading Primitive Data Types

### Using DataInputStream

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

### Reading Arrays of Primitives

```java
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;

public class ArrayBinaryReader {
    public static void main(String[] args) {
        try (DataInputStream inputStream = new DataInputStream(
                new FileInputStream("arrays.dat"))) {
            
            // Read array length first
            int arrayLength = inputStream.readInt();
            System.out.println("Array length: " + arrayLength);
            
            // Read array of integers
            int[] numbers = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++) {
                numbers[i] = inputStream.readInt();
            }
            
            // Read array of doubles
            int doubleArrayLength = inputStream.readInt();
            double[] decimals = new double[doubleArrayLength];
            for (int i = 0; i < doubleArrayLength; i++) {
                decimals[i] = inputStream.readDouble();
            }
            
            // Display results
            System.out.println("Integer array: " + java.util.Arrays.toString(numbers));
            System.out.println("Double array: " + java.util.Arrays.toString(decimals));
            
        } catch (IOException e) {
            System.out.println("Error reading arrays: " + e.getMessage());
        }
    }
}
```

## Reading Serialized Objects

### Basic Object Reading

```java
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;

public class ObjectReader {
    public static void main(String[] args) {
        try (ObjectInputStream inputStream = new ObjectInputStream(
                new FileInputStream("person.dat"))) {
            
            // Read the object
            Person person = (Person) inputStream.readObject();
            
            System.out.println("Person loaded successfully:");
            System.out.println(person);
            
        } catch (IOException | ClassNotFoundException e) {
            System.out.println("Error reading object: " + e.getMessage());
        }
    }
}
```

### Reading Collections of Objects

```java
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.util.List;

public class CollectionReader {
    public static void main(String[] args) {
        try (ObjectInputStream inputStream = new ObjectInputStream(
                new FileInputStream("people.dat"))) {
            
            // Read the list of people
            @SuppressWarnings("unchecked")
            List<Person> people = (List<Person>) inputStream.readObject();
            
            System.out.println("Loaded " + people.size() + " people:");
            for (int i = 0; i < people.size(); i++) {
                System.out.println((i + 1) + ": " + people.get(i));
            }
            
        } catch (IOException | ClassNotFoundException e) {
            System.out.println("Error reading collection: " + e.getMessage());
        }
    }
}
```

## Reading Mixed Data Types

### Reading Structured Binary Files

```java
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;

public class StructuredBinaryReader {
    public static void main(String[] args) {
        try (DataInputStream inputStream = new DataInputStream(
                new FileInputStream("structured_data.dat"))) {
            
            System.out.println("=== Reading Structured Data ===");
            
            // Read header information
            String fileType = inputStream.readUTF();
            int version = inputStream.readInt();
            long timestamp = inputStream.readLong();
            
            System.out.println("File Type: " + fileType);
            System.out.println("Version: " + version);
            System.out.println("Timestamp: " + new java.util.Date(timestamp));
            
            // Read number of records
            int recordCount = inputStream.readInt();
            System.out.println("Record Count: " + recordCount);
            
            // Read each record
            for (int i = 0; i < recordCount; i++) {
                String name = inputStream.readUTF();
                int age = inputStream.readInt();
                double salary = inputStream.readDouble();
                boolean isActive = inputStream.readBoolean();
                
                System.out.printf("Record %d: %s, %d years, $%.2f, Active: %s%n",
                                i + 1, name, age, salary, isActive);
            }
            
        } catch (IOException e) {
            System.out.println("Error reading structured data: " + e.getMessage());
        }
    }
}
```

## Error Handling and Validation

### Robust Binary File Reading

```java
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class RobustBinaryReader {
    public static void readBinaryFile(String filename) {
        // Check if file exists
        if (!Files.exists(Paths.get(filename))) {
            System.out.println("Error: File '" + filename + "' does not exist!");
            return;
        }
        
        // Check file size
        try {
            long fileSize = Files.size(Paths.get(filename));
            if (fileSize == 0) {
                System.out.println("Error: File is empty!");
                return;
            }
            System.out.println("File size: " + fileSize + " bytes");
        } catch (IOException e) {
            System.out.println("Error getting file size: " + e.getMessage());
            return;
        }
        
        // Read the file
        try (DataInputStream inputStream = new DataInputStream(
                new FileInputStream(filename))) {
            
            System.out.println("=== Binary File Content ===");
            
            int byteCount = 0;
            int data;
            
            while ((data = inputStream.read()) != -1) {
                System.out.printf("%02X ", data);
                byteCount++;
                
                if (byteCount % 16 == 0) {
                    System.out.println(); // New line every 16 bytes
                }
            }
            
            if (byteCount % 16 != 0) {
                System.out.println(); // Final newline if needed
            }
            
            System.out.println("Total bytes read: " + byteCount);
            
        } catch (IOException e) {
            System.out.println("Error reading binary file: " + e.getMessage());
            e.printStackTrace();
        }
    }
    
    public static void main(String[] args) {
        readBinaryFile("data.dat");
    }
}
```

### Safe Object Reading with Validation

```java
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;

public class SafeObjectReader {
    public static <T> T safeReadObject(String filename, Class<T> expectedType) {
        try (ObjectInputStream inputStream = new ObjectInputStream(
                new FileInputStream(filename))) {
            
            Object obj = inputStream.readObject();
            
            // Validate object type
            if (expectedType.isInstance(obj)) {
                @SuppressWarnings("unchecked")
                T result = (T) obj;
                System.out.println("Object loaded successfully from " + filename);
                return result;
            } else {
                System.out.println("Error: Expected " + expectedType.getSimpleName() + 
                                 ", but got " + obj.getClass().getSimpleName());
                return null;
            }
            
        } catch (IOException e) {
            System.out.println("Error reading file " + filename + ": " + e.getMessage());
            return null;
        } catch (ClassNotFoundException e) {
            System.out.println("Error: Class not found - " + e.getMessage());
            return null;
        } catch (ClassCastException e) {
            System.out.println("Error: Invalid object type - " + e.getMessage());
            return null;
        }
    }
    
    public static void main(String[] args) {
        // Safe reading with type validation
        Person person = safeReadObject("person.dat", Person.class);
        if (person != null) {
            System.out.println("Loaded person: " + person);
        }
    }
}
```

## Reading Large Binary Files

### Streaming Large Files

```java
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;

public class LargeFileReader {
    public static void readLargeBinaryFile(String filename) {
        try (DataInputStream inputStream = new DataInputStream(
                new FileInputStream(filename))) {
            
            System.out.println("Reading large binary file: " + filename);
            
            int recordCount = 0;
            long totalBytes = 0;
            
            try {
                // Read number of records first
                int totalRecords = inputStream.readInt();
                System.out.println("Total records to read: " + totalRecords);
                
                // Read records in batches
                while (recordCount < totalRecords) {
                    // Read a batch of records
                    int batchSize = Math.min(1000, totalRecords - recordCount);
                    
                    for (int i = 0; i < batchSize; i++) {
                        String name = inputStream.readUTF();
                        int value = inputStream.readInt();
                        
                        recordCount++;
                        totalBytes += name.getBytes().length + 4; // UTF-8 bytes + int
                        
                        // Process record (in real application, you'd do something useful)
                        if (recordCount % 10000 == 0) {
                            System.out.println("Processed " + recordCount + " records...");
                        }
                    }
                    
                    // Optional: Add delay for very large files
                    // Thread.sleep(10);
                }
                
                System.out.println("Finished reading " + recordCount + " records");
                System.out.println("Total data processed: " + totalBytes + " bytes");
                
            } catch (IOException e) {
                System.out.println("Error reading record " + recordCount + ": " + e.getMessage());
            }
            
        } catch (IOException e) {
            System.out.println("Error opening file: " + e.getMessage());
        }
    }
    
    public static void main(String[] args) {
        readLargeBinaryFile("large_data.dat");
    }
}
```

## Reading Custom Binary Formats

### Game Save File Reader

```java
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class GameSaveReader {
    public static class GameSave {
        public String playerName;
        public int level;
        public int score;
        public List<String> inventory;
        public double[] position;
        
        public GameSave(String playerName, int level, int score, 
                       List<String> inventory, double[] position) {
            this.playerName = playerName;
            this.level = level;
            this.score = score;
            this.inventory = inventory;
            this.position = position;
        }
        
        @Override
        public String toString() {
            return String.format("GameSave{Player='%s', Level=%d, Score=%d, Inventory=%s, Position=[%.2f, %.2f]}",
                               playerName, level, score, inventory, position[0], position[1]);
        }
    }
    
    public static GameSave readGameSave(String filename) {
        try (DataInputStream inputStream = new DataInputStream(
                new FileInputStream(filename))) {
            
            // Read game save header
            String magic = inputStream.readUTF();
            if (!magic.equals("GAME_SAVE_V1")) {
                System.out.println("Error: Invalid save file format");
                return null;
            }
            
            // Read player data
            String playerName = inputStream.readUTF();
            int level = inputStream.readInt();
            int score = inputStream.readInt();
            
            // Read inventory
            int inventorySize = inputStream.readInt();
            List<String> inventory = new ArrayList<>();
            for (int i = 0; i < inventorySize; i++) {
                inventory.add(inputStream.readUTF());
            }
            
            // Read position (x, y coordinates)
            double[] position = new double[2];
            position[0] = inputStream.readDouble();
            position[1] = inputStream.readDouble();
            
            return new GameSave(playerName, level, score, inventory, position);
            
        } catch (IOException e) {
            System.out.println("Error reading game save: " + e.getMessage());
            return null;
        }
    }
    
    public static void main(String[] args) {
        GameSave save = readGameSave("player_save.dat");
        if (save != null) {
            System.out.println("Game save loaded:");
            System.out.println(save);
        }
    }
}
```

## Performance Considerations

### Buffered Reading for Better Performance

```java
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;

public class BufferedBinaryReader {
    public static void readWithBuffering(String filename) {
        try (DataInputStream inputStream = new DataInputStream(
                new BufferedInputStream(new FileInputStream(filename)))) {
            
            System.out.println("Reading with buffering for better performance...");
            
            long startTime = System.currentTimeMillis();
            
            // Read data
            int recordCount = inputStream.readInt();
            for (int i = 0; i < recordCount; i++) {
                String data = inputStream.readUTF();
                int value = inputStream.readInt();
                
                // Process data...
            }
            
            long endTime = System.currentTimeMillis();
            System.out.println("Read " + recordCount + " records in " + 
                             (endTime - startTime) + " ms");
            
        } catch (IOException e) {
            System.out.println("Error reading buffered file: " + e.getMessage());
        }
    }
    
    public static void main(String[] args) {
        readWithBuffering("large_data.dat");
    }
}
```

## What's Next?

Now that you understand how to read binary files and objects, let's practice with a comprehensive exercise that combines all the concepts you've learned about file I/O, serialization, and binary data handling!

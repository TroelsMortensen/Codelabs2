# Provided Logging "Library"

Below you will find the source code for a class, which can output information to a file.

Put this class into your new package, from the previous page.

```java
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

/**
 * FileLogOutputter - Provided class for file-based logging.
 * This class has an incompatible interface with LogOutput.
 * DO NOT MODIFY THIS CLASS - Create an adapter instead.
 */
public class FileLogOutputter {
    private final String logFilePath;
    private final String minimumLogLevel;
    private static final DateTimeFormatter DATE_FORMATTER = 
        DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
    
    public FileLogOutputter(String logFilePath, String minimumLogLevel) {
        this.logFilePath = logFilePath;
        this.minimumLogLevel = minimumLogLevel.toUpperCase();
        ensureLogDirectoryExists();
    }
    
    public void logInfo(String message) {
        writeToFile("INFO", message);
    }
    
    public void logWarning(String message) {
        writeToFile("WARNING", message);
    }
    
    public void logError(String message) {
        writeToFile("ERROR", message);
    }
    
    private void ensureLogDirectoryExists() {
        File logFile = new File(logFilePath);
        File parentDir = logFile.getParentFile();
        if (parentDir != null && !parentDir.exists()) {
            parentDir.mkdirs();
        }
    }
    
    private void writeToFile(String level, String message) {
        if (!shouldLog(level)) {
            return; // Filtered out by minimum log level
        }
        
        try (PrintWriter writer = new PrintWriter(
                new FileWriter(logFilePath, true))) {
            String timestamp = LocalDateTime.now().format(DATE_FORMATTER);
            writer.println(String.format("[%s] %s: %s", timestamp, level, message));
        } catch (IOException e) {
            System.err.println("Failed to write to log file: " + e.getMessage());
        }
    }
    
    private boolean shouldLog(String level) {
        String upperLevel = level.toUpperCase();
        return switch (minimumLogLevel) {
            case "NONE" -> false; // Logging is turned off
            case "ERROR" -> "ERROR".equals(upperLevel);
            case "WARNING" -> "WARNING".equals(upperLevel) || "ERROR".equals(upperLevel);
            case "INFO" -> "INFO".equals(upperLevel) || "WARNING".equals(upperLevel) || "ERROR".equals(upperLevel);
            default -> false; // Unknown minimumLogLevel, do not log anything
        };
    }
}
```
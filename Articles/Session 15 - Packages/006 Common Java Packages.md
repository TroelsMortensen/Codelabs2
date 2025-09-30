# Common Java Packages

## Built-in Java Packages

Java comes with many built-in packages that provide essential functionality. Understanding these packages is crucial for effective Java development.

## Core Language Packages

### 1. **java.lang Package**
Automatically imported - no need to import explicitly:

```java
// These are automatically available
String name = "Hello World";
System.out.println(name);
Integer number = 42;
Double value = 3.14;
Boolean flag = true;
```

**Key Classes:**
- `String` - Text manipulation
- `System` - System operations
- `Object` - Base class for all objects
- `Math` - Mathematical operations
- `Integer`, `Double`, `Boolean` - Wrapper classes

### 2. **java.util Package**
Collections and utilities:

```java
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.HashMap;
import java.util.Date;
import java.util.Calendar;
import java.util.Random;
import java.util.Scanner;

public class UtilExample {
    public void demonstrateUtil() {
        // Collections
        List<String> names = new ArrayList<>();
        names.add("Alice");
        names.add("Bob");
        
        Map<String, Integer> ages = new HashMap<>();
        ages.put("Alice", 25);
        ages.put("Bob", 30);
        
        // Date and time
        Date now = new Date();
        Calendar calendar = Calendar.getInstance();
        
        // Random numbers
        Random random = new Random();
        int randomNumber = random.nextInt(100);
        
        // Input
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
    }
}
```

**Key Classes:**
- `ArrayList`, `LinkedList` - Lists
- `HashMap`, `TreeMap` - Maps
- `HashSet`, `TreeSet` - Sets
- `Date`, `Calendar` - Date/time
- `Random` - Random numbers
- `Scanner` - Input reading

### 3. **java.io Package**
Input/Output operations:

```java
import java.io.File;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.FileWriter;
import java.io.BufferedWriter;
import java.io.IOException;

public class IOExample {
    public void demonstrateIO() {
        // File operations
        File file = new File("data.txt");
        
        try {
            // Reading from file
            FileReader fileReader = new FileReader(file);
            BufferedReader reader = new BufferedReader(fileReader);
            String line = reader.readLine();
            reader.close();
            
            // Writing to file
            FileWriter fileWriter = new FileWriter(file);
            BufferedWriter writer = new BufferedWriter(fileWriter);
            writer.write("Hello World");
            writer.close();
            
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }
    }
}
```

**Key Classes:**
- `File` - File operations
- `FileReader`, `FileWriter` - Character I/O
- `BufferedReader`, `BufferedWriter` - Buffered I/O
- `InputStream`, `OutputStream` - Byte I/O
- `IOException` - I/O exceptions

## GUI Packages

### 4. **java.awt Package**
Abstract Window Toolkit:

```java
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class AWTExample {
    public void demonstrateAWT() {
        // Colors
        Color red = new Color(255, 0, 0);
        Color blue = Color.BLUE;
        
        // Fonts
        Font boldFont = new Font("Arial", Font.BOLD, 12);
        Font italicFont = new Font("Times", Font.ITALIC, 14);
        
        // Points and dimensions
        Point position = new Point(100, 200);
        Dimension size = new Dimension(300, 400);
        
        // Event handling
        ActionListener listener = new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                System.out.println("Button clicked!");
            }
        };
    }
}
```

**Key Classes:**
- `Color` - Colors
- `Font` - Fonts
- `Graphics` - Drawing operations
- `Point`, `Dimension` - Geometry
- `event` package - Event handling

### 5. **javax.swing Package**
Swing GUI components:

```java
import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.JComboBox;
import javax.swing.JList;
import javax.swing.JTable;
import javax.swing.JScrollPane;

public class SwingExample {
    public void demonstrateSwing() {
        // Main window
        JFrame frame = new JFrame("My Application");
        frame.setSize(400, 300);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        // Components
        JPanel panel = new JPanel();
        JLabel label = new JLabel("Enter your name:");
        JTextField textField = new JTextField(20);
        JButton button = new JButton("Click Me");
        JComboBox<String> comboBox = new JComboBox<>();
        comboBox.addItem("Option 1");
        comboBox.addItem("Option 2");
        
        // Add components to panel
        panel.add(label);
        panel.add(textField);
        panel.add(button);
        panel.add(comboBox);
        
        // Add panel to frame
        frame.add(panel);
        frame.setVisible(true);
    }
}
```

**Key Classes:**
- `JFrame` - Main windows
- `JPanel` - Containers
- `JButton`, `JLabel` - Basic components
- `JTextField`, `JComboBox` - Input components
- `JList`, `JTable` - Data display
- `JScrollPane` - Scrolling

## Network and Database Packages

### 6. **java.net Package**
Network operations:

```java
import java.net.URL;
import java.net.URLConnection;
import java.net.Socket;
import java.net.ServerSocket;
import java.io.IOException;

public class NetworkExample {
    public void demonstrateNetwork() {
        try {
            // URL operations
            URL url = new URL("https://www.example.com");
            URLConnection connection = url.openConnection();
            
            // Socket operations
            Socket socket = new Socket("localhost", 8080);
            ServerSocket serverSocket = new ServerSocket(8080);
            
        } catch (IOException e) {
            System.err.println("Network error: " + e.getMessage());
        }
    }
}
```

**Key Classes:**
- `URL` - URL operations
- `URLConnection` - HTTP connections
- `Socket` - Client sockets
- `ServerSocket` - Server sockets

### 7. **java.sql Package**
Database operations:

```java
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class DatabaseExample {
    public void demonstrateDatabase() {
        try {
            // Database connection
            Connection conn = DriverManager.getConnection(
                "jdbc:mysql://localhost:3306/mydb", 
                "username", 
                "password"
            );
            
            // SQL statements
            Statement stmt = conn.createStatement();
            ResultSet rs = stmt.executeQuery("SELECT * FROM users");
            
            // Prepared statements
            PreparedStatement pstmt = conn.prepareStatement(
                "INSERT INTO users (name, email) VALUES (?, ?)"
            );
            pstmt.setString(1, "John Doe");
            pstmt.setString(2, "john@example.com");
            pstmt.executeUpdate();
            
            // Close connections
            rs.close();
            stmt.close();
            conn.close();
            
        } catch (SQLException e) {
            System.err.println("Database error: " + e.getMessage());
        }
    }
}
```

**Key Classes:**
- `Connection` - Database connections
- `DriverManager` - Connection management
- `Statement`, `PreparedStatement` - SQL execution
- `ResultSet` - Query results
- `SQLException` - Database exceptions

## Concurrency and Threading

### 8. **java.util.concurrent Package**
Advanced concurrency:

```java
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.Callable;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.Semaphore;

public class ConcurrencyExample {
    public void demonstrateConcurrency() {
        // Thread pool
        ExecutorService executor = Executors.newFixedThreadPool(4);
        
        // Submit tasks
        Future<String> future = executor.submit(new Callable<String>() {
            public String call() throws Exception {
                return "Task completed";
            }
        });
        
        // Synchronization
        CountDownLatch latch = new CountDownLatch(3);
        Semaphore semaphore = new Semaphore(2);
        
        // Shutdown
        executor.shutdown();
    }
}
```

**Key Classes:**
- `ExecutorService` - Thread pools
- `Future` - Asynchronous results
- `Callable` - Tasks with return values
- `CountDownLatch` - Synchronization
- `Semaphore` - Resource limiting

## Reflection and Annotations

### 9. **java.lang.reflect Package**
Reflection:

```java
import java.lang.reflect.Class;
import java.lang.reflect.Method;
import java.lang.reflect.Field;
import java.lang.reflect.Constructor;

public class ReflectionExample {
    public void demonstrateReflection() {
        try {
            // Get class information
            Class<?> clazz = String.class;
            String className = clazz.getName();
            
            // Get methods
            Method[] methods = clazz.getMethods();
            Method lengthMethod = clazz.getMethod("length");
            
            // Get fields
            Field[] fields = clazz.getDeclaredFields();
            
            // Get constructors
            Constructor<?>[] constructors = clazz.getConstructors();
            
        } catch (Exception e) {
            System.err.println("Reflection error: " + e.getMessage());
        }
    }
}
```

**Key Classes:**
- `Class` - Class information
- `Method` - Method information
- `Field` - Field information
- `Constructor` - Constructor information

### 10. **java.lang.annotation Package**
Annotations:

```java
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;
import java.lang.annotation.ElementType;

@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.METHOD)
public @interface MyAnnotation {
    String value() default "";
    int priority() default 0;
}

public class AnnotationExample {
    @MyAnnotation(value = "Important", priority = 1)
    public void importantMethod() {
        System.out.println("This is an important method");
    }
}
```

**Key Classes:**
- `@Retention` - Annotation retention
- `@Target` - Annotation targets
- `@Override` - Method overriding
- `@Deprecated` - Deprecated code

## Package Organization Examples

### Complete Application Structure
```java
// Main application
package com.mycompany.app;

import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;
import java.io.File;
import java.io.IOException;
import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MainApplication {
    private List<String> data;
    private Scanner scanner;
    
    public MainApplication() {
        this.data = new ArrayList<>();
        this.scanner = new Scanner(System.in);
    }
    
    public void run() {
        // Application logic
        System.out.println("Welcome to My Application");
        
        // GUI setup
        JFrame frame = new JFrame("My App");
        JPanel panel = new JPanel();
        JLabel label = new JLabel("Hello World");
        JButton button = new JButton("Click Me");
        
        button.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                System.out.println("Button clicked!");
            }
        });
        
        panel.add(label);
        panel.add(button);
        frame.add(panel);
        frame.setSize(300, 200);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
    }
    
    public static void main(String[] args) {
        MainApplication app = new MainApplication();
        app.run();
    }
}
```

## Package Import Best Practices

### 1. **Import Only What You Need**
```java
// Good - specific imports
import java.util.ArrayList;
import java.util.List;
import java.awt.Color;

// Bad - wildcard imports
import java.util.*;
import java.awt.*;
```

### 2. **Group Imports by Package**
```java
// Good - grouped by package
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import java.awt.Color;
import java.awt.Font;

import javax.swing.JFrame;
import javax.swing.JButton;
```

### 3. **Use Static Imports Sparingly**
```java
// Good - for frequently used static members
import static java.lang.Math.PI;
import static java.lang.System.out;

// Bad - importing too many static members
import static java.lang.Math.*;
import static java.lang.System.*;
```

## Package Documentation

### 1. **Package-Level Documentation**
Create `package-info.java` files:

```java
package com.mycompany.util;

/**
 * Utility classes for common operations.
 * 
 * <p>This package contains helper classes and utility methods
 * that are used throughout the application.</p>
 * 
 * <p>Key utilities include:</p>
 * <ul>
 *   <li>{@link StringHelper} - String manipulation utilities</li>
 *   <li>{@link DateHelper} - Date and time utilities</li>
 *   <li>{@link ValidationHelper} - Input validation utilities</li>
 * </ul>
 * 
 * @author Your Name
 * @version 1.0
 * @since 2024-01-01
 */
```

## Summary

Understanding common Java packages is essential for:

- **Effective development** - Know what's available
- **Code organization** - Use appropriate packages
- **Import management** - Import only what you need
- **Professional development** - Industry standard practices
- **Problem solving** - Choose the right tools for the job

In the next article, we'll learn how to create and use your own custom packages.

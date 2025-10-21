# Exercise - Object Storage System

Create a comprehensive object storage system that can save and load Java objects to/from binary files. This exercise will help you practice object serialization and create a useful data persistence system.

## Requirements

Create an `ObjectStorageSystem` class that can manage different types of objects:

### 1. Student Management System
- Create `Student` class with serializable data
- Save and load student records
- Manage multiple students in collections

### 2. Library Book System
- Create `Book` class with book information
- Track book availability and borrowing
- Save library inventory to files

### 3. Game Score System
- Create `GameScore` class for tracking scores
- Save high scores and player statistics
- Load and display leaderboards

### 4. Generic Object Storage
- Create a generic storage system for any serializable object
- Support different file formats and naming conventions
- Provide backup and restore functionality

## Implementation Guidelines

### Basic Class Structure
```java
import java.io.*;
import java.util.*;

public class ObjectStorageSystem {
    private Scanner scanner;
    
    public ObjectStorageSystem() {
        this.scanner = new Scanner(System.in);
    }
    
    public void run() {
        // Main menu loop
    }
    
    // Student Management
    private void manageStudents() { }
    private void saveStudents(List<Student> students) { }
    private List<Student> loadStudents() { }
    
    // Library Management
    private void manageLibrary() { }
    private void saveBooks(List<Book> books) { }
    private List<Book> loadBooks() { }
    
    // Game Score Management
    private void manageGameScores() { }
    private void saveScores(List<GameScore> scores) { }
    private List<GameScore> loadScores() { }
    
    // Generic Storage
    private void genericStorage() { }
    private <T> void saveObject(T obj, String filename) { }
    private <T> T loadObject(String filename, Class<T> clazz) { }
    
    public static void main(String[] args) {
        new ObjectStorageSystem().run();
    }
}
```

### Menu Structure
```
=== Object Storage System ===

1. Student Management
2. Library Book System
3. Game Score System
4. Generic Object Storage
5. File Management
6. Exit

Choose an option (1-6):
```

## Detailed Requirements

### 1. Student Management System

#### Student Class
```java
import java.io.Serializable;
import java.time.LocalDate;

public class Student implements Serializable {
    private static final long serialVersionUID = 1L;
    
    private String studentId;
    private String name;
    private LocalDate birthDate;
    private String email;
    private List<String> courses;
    private double gpa;
    
    public Student(String studentId, String name, LocalDate birthDate, 
                   String email, List<String> courses, double gpa) {
        this.studentId = studentId;
        this.name = name;
        this.birthDate = birthDate;
        this.email = email;
        this.courses = courses;
        this.gpa = gpa;
    }
    
    // Getters and setters...
    
    @Override
    public String toString() {
        return String.format("Student{ID='%s', Name='%s', Email='%s', GPA=%.2f, Courses=%s}", 
                           studentId, name, email, gpa, courses);
    }
}
```

#### Student Management Features
```
=== Student Management ===

1. Add New Student
2. View All Students
3. Search Student by ID
4. Update Student Information
5. Delete Student
6. Save Students to File
7. Load Students from File
8. Generate Student Report
9. Back to Main Menu

Choose an option (1-9):
```

### 2. Library Book System

#### Book Class
```java
import java.io.Serializable;
import java.time.LocalDate;

public class Book implements Serializable {
    private static final long serialVersionUID = 1L;
    
    private String isbn;
    private String title;
    private String author;
    private String genre;
    private int yearPublished;
    private boolean isAvailable;
    private String borrowedBy;
    private LocalDate borrowedDate;
    private LocalDate dueDate;
    
    public Book(String isbn, String title, String author, String genre, int yearPublished) {
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.genre = genre;
        this.yearPublished = yearPublished;
        this.isAvailable = true;
    }
    
    // Getters and setters...
    
    public void borrowBook(String borrower, LocalDate dueDate) {
        this.borrowedBy = borrower;
        this.borrowedDate = LocalDate.now();
        this.dueDate = dueDate;
        this.isAvailable = false;
    }
    
    public void returnBook() {
        this.borrowedBy = null;
        this.borrowedDate = null;
        this.dueDate = null;
        this.isAvailable = true;
    }
    
    @Override
    public String toString() {
        return String.format("Book{ISBN='%s', Title='%s', Author='%s', Available=%s}", 
                           isbn, title, author, isAvailable);
    }
}
```

#### Library Management Features
```
=== Library Book System ===

1. Add New Book
2. View All Books
3. Search Book by ISBN
4. Borrow Book
5. Return Book
6. View Borrowed Books
7. Save Library to File
8. Load Library from File
9. Generate Library Report
10. Back to Main Menu

Choose an option (1-10):
```

### 3. Game Score System

#### GameScore Class
```java
import java.io.Serializable;
import java.time.LocalDateTime;

public class GameScore implements Serializable {
    private static final long serialVersionUID = 1L;
    
    private String playerName;
    private int score;
    private int level;
    private long playTimeSeconds;
    private LocalDateTime dateAchieved;
    private String gameMode;
    
    public GameScore(String playerName, int score, int level, 
                    long playTimeSeconds, String gameMode) {
        this.playerName = playerName;
        this.score = score;
        this.level = level;
        this.playTimeSeconds = playTimeSeconds;
        this.gameMode = gameMode;
        this.dateAchieved = LocalDateTime.now();
    }
    
    // Getters and setters...
    
    public String getFormattedPlayTime() {
        long hours = playTimeSeconds / 3600;
        long minutes = (playTimeSeconds % 3600) / 60;
        long seconds = playTimeSeconds % 60;
        return String.format("%02d:%02d:%02d", hours, minutes, seconds);
    }
    
    @Override
    public String toString() {
        return String.format("Score{Player='%s', Score=%d, Level=%d, Time=%s, Mode='%s', Date=%s}", 
                           playerName, score, level, getFormattedPlayTime(), 
                           gameMode, dateAchieved.toLocalDate());
    }
}
```

#### Game Score Features
```
=== Game Score System ===

1. Add New Score
2. View All Scores
3. View High Scores (Top 10)
4. Search Scores by Player
5. View Scores by Game Mode
6. Calculate Player Statistics
7. Save Scores to File
8. Load Scores from File
9. Generate Score Report
10. Back to Main Menu

Choose an option (1-10):
```

## Implementation Details

### Generic Object Storage
```java
private <T> void saveObject(T obj, String filename) {
    try (ObjectOutputStream outputStream = new ObjectOutputStream(
            new FileOutputStream(filename))) {
        
        outputStream.writeObject(obj);
        System.out.println("Object saved to " + filename);
        
    } catch (IOException e) {
        System.out.println("Error saving object: " + e.getMessage());
    }
}

private <T> T loadObject(String filename, Class<T> clazz) {
    try (ObjectInputStream inputStream = new ObjectInputStream(
            new FileInputStream(filename))) {
        
        Object obj = inputStream.readObject();
        if (clazz.isInstance(obj)) {
            @SuppressWarnings("unchecked")
            T result = (T) obj;
            System.out.println("Object loaded from " + filename);
            return result;
        } else {
            System.out.println("Object type mismatch!");
            return null;
        }
        
    } catch (IOException | ClassNotFoundException e) {
        System.out.println("Error loading object: " + e.getMessage());
        return null;
    }
}
```

### Student Management Implementation
```java
private void manageStudents() {
    List<Student> students = loadStudents(); // Load existing students
    
    while (true) {
        System.out.println("\n=== Student Management ===");
        System.out.println("1. Add New Student");
        System.out.println("2. View All Students");
        System.out.println("3. Search Student by ID");
        System.out.println("4. Save Students to File");
        System.out.println("5. Load Students from File");
        System.out.println("6. Back to Main Menu");
        
        int choice = getMenuChoice(1, 6);
        
        switch (choice) {
            case 1: addStudent(students); break;
            case 2: viewAllStudents(students); break;
            case 3: searchStudent(students); break;
            case 4: saveStudents(students); break;
            case 5: students = loadStudents(); break;
            case 6: return;
        }
    }
}

private void addStudent(List<Student> students) {
    System.out.println("\n=== Add New Student ===");
    
    System.out.print("Student ID: ");
    String studentId = scanner.nextLine();
    
    System.out.print("Name: ");
    String name = scanner.nextLine();
    
    System.out.print("Email: ");
    String email = scanner.nextLine();
    
    System.out.print("GPA: ");
    double gpa = Double.parseDouble(scanner.nextLine());
    
    System.out.print("Courses (comma-separated): ");
    String coursesInput = scanner.nextLine();
    List<String> courses = Arrays.asList(coursesInput.split(","));
    
    Student student = new Student(studentId, name, LocalDate.now(), email, courses, gpa);
    students.add(student);
    
    System.out.println("Student added successfully!");
}
```

### High Score System
```java
private void viewHighScores(List<GameScore> scores) {
    System.out.println("\n=== High Scores (Top 10) ===");
    
    List<GameScore> sortedScores = new ArrayList<>(scores);
    sortedScores.sort((s1, s2) -> Integer.compare(s2.getScore(), s1.getScore()));
    
    System.out.printf("%-4s %-15s %-8s %-6s %-10s %-12s%n", 
                     "Rank", "Player", "Score", "Level", "Play Time", "Date");
    System.out.println("-".repeat(70));
    
    int rank = 1;
    for (GameScore score : sortedScores.subList(0, Math.min(10, sortedScores.size()))) {
        System.out.printf("%-4d %-15s %-8d %-6d %-10s %-12s%n",
                         rank++, 
                         score.getPlayerName(),
                         score.getScore(),
                         score.getLevel(),
                         score.getFormattedPlayTime(),
                         score.getDateAchieved().toLocalDate());
    }
}
```

### File Management Features
```java
private void fileManagement() {
    System.out.println("\n=== File Management ===");
    System.out.println("1. List Object Files");
    System.out.println("2. Backup Files");
    System.out.println("3. Restore from Backup");
    System.out.println("4. Delete Files");
    System.out.println("5. File Statistics");
    System.out.println("6. Back to Main Menu");
    
    int choice = getMenuChoice(1, 6);
    
    switch (choice) {
        case 1: listObjectFiles(); break;
        case 2: backupFiles(); break;
        case 3: restoreFromBackup(); break;
        case 4: deleteFiles(); break;
        case 5: fileStatistics(); break;
        case 6: return;
    }
}

private void listObjectFiles() {
    System.out.println("\n=== Object Files ===");
    
    File currentDir = new File(".");
    File[] files = currentDir.listFiles((dir, name) -> 
        name.endsWith(".dat") || name.endsWith(".ser"));
    
    if (files == null || files.length == 0) {
        System.out.println("No object files found.");
        return;
    }
    
    System.out.printf("%-20s %-10s %-20s%n", "Filename", "Size", "Last Modified");
    System.out.println("-".repeat(50));
    
    for (File file : files) {
        System.out.printf("%-20s %-10s %-20s%n",
                         file.getName(),
                         formatFileSize(file.length()),
                         new Date(file.lastModified()));
    }
}
```

## Sample Program Flow

```
=== Object Storage System ===

1. Student Management
2. Library Book System
3. Game Score System
4. Generic Object Storage
5. File Management
6. Exit

Choose an option (1-6): 1

=== Student Management ===
1. Add New Student
2. View All Students
3. Search Student by ID
4. Save Students to File
5. Load Students from File
6. Back to Main Menu

Choose an option (1-6): 1

=== Add New Student ===
Student ID: S001
Name: Alice Johnson
Email: alice@university.edu
GPA: 3.8
Courses (comma-separated): Java Programming, Data Structures, Algorithms
Student added successfully!

Choose an option (1-6): 4
Students saved to students.dat

Choose an option (1-6): 2

=== All Students ===
Student{ID='S001', Name='Alice Johnson', Email='alice@university.edu', GPA=3.80, Courses=[Java Programming, Data Structures, Algorithms]}

Choose an option (1-6): 6
```

## Learning Objectives

After completing this exercise, you should be able to:

1. **Implement Serializable interface** for custom classes
2. **Save and load objects** to/from binary files
3. **Manage collections of objects** with serialization
4. **Handle serialization exceptions** properly
5. **Create generic storage systems** for any serializable objects
6. **Implement data persistence** for applications
7. **Manage file operations** for object storage
8. **Design comprehensive object management** systems

## Bonus Challenges

1. **Database-like operations**: Implement CRUD operations for objects
2. **Object versioning**: Handle different versions of serialized objects
3. **Compression**: Compress serialized files to save space
4. **Encryption**: Encrypt sensitive serialized data
5. **Object relationships**: Handle complex object hierarchies
6. **Performance optimization**: Implement caching and lazy loading
7. **Data migration**: Convert between different object versions

Good luck with your object storage system implementation!

# Creating Custom Packages

## Why Create Custom Packages?

Custom packages help you:
- **Organize your code** into logical groups
- **Avoid naming conflicts** with other libraries
- **Share code** between projects
- **Create professional libraries** for distribution
- **Maintain clean project structure**

## Step-by-Step Package Creation

### 1. **Plan Your Package Structure**
Before creating packages, plan the structure:

```
com.yourcompany.projectname
├── model/          # Data models
├── service/        # Business logic
├── dao/           # Data access
├── util/          # Utilities
├── exception/     # Custom exceptions
└── ui/            # User interface
```

### 2. **Create Directory Structure**
Create the directory structure to match your package names:

```
src/
├── com/
│   └── yourcompany/
│       └── projectname/
│           ├── model/
│           ├── service/
│           ├── dao/
│           ├── util/
│           ├── exception/
│           └── ui/
```

### 3. **Create Package-Info Files**
Create `package-info.java` files for documentation:

```java
package com.yourcompany.projectname.model;

/**
 * Data models for the application.
 * 
 * <p>This package contains all the data models that represent
 * the core business entities in the application.</p>
 * 
 * @author Your Name
 * @version 1.0
 * @since 2024-01-01
 */
```

## Real-World Example: Student Management System

### Package Structure
```
src/
├── com/
│   └── university/
│       └── studentmanagement/
│           ├── model/
│           │   ├── Student.java
│           │   ├── Course.java
│           │   └── Enrollment.java
│           ├── service/
│           │   ├── StudentService.java
│           │   ├── CourseService.java
│           │   └── EnrollmentService.java
│           ├── dao/
│           │   ├── StudentDAO.java
│           │   ├── CourseDAO.java
│           │   └── EnrollmentDAO.java
│           ├── util/
│           │   ├── ValidationHelper.java
│           │   ├── DateHelper.java
│           │   └── Constants.java
│           ├── exception/
│           │   ├── StudentNotFoundException.java
│           │   ├── CourseNotFoundException.java
│           │   └── EnrollmentException.java
│           └── ui/
│               ├── MainWindow.java
│               ├── StudentWindow.java
│               └── CourseWindow.java
```

### Model Package
```java
package com.university.studentmanagement.model;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

/**
 * Represents a student in the university system.
 */
public class Student {
    private int id;
    private String firstName;
    private String lastName;
    private String email;
    private LocalDate dateOfBirth;
    private String major;
    private List<Course> enrolledCourses;
    
    public Student(int id, String firstName, String lastName, String email, 
                   LocalDate dateOfBirth, String major) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.dateOfBirth = dateOfBirth;
        this.major = major;
        this.enrolledCourses = new ArrayList<>();
    }
    
    // Getters and setters
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    
    public String getFirstName() { return firstName; }
    public void setFirstName(String firstName) { this.firstName = firstName; }
    
    public String getLastName() { return lastName; }
    public void setLastName(String lastName) { this.lastName = lastName; }
    
    public String getEmail() { return email; }
    public void setEmail(String email) { this.email = email; }
    
    public LocalDate getDateOfBirth() { return dateOfBirth; }
    public void setDateOfBirth(LocalDate dateOfBirth) { this.dateOfBirth = dateOfBirth; }
    
    public String getMajor() { return major; }
    public void setMajor(String major) { this.major = major; }
    
    public List<Course> getEnrolledCourses() { return enrolledCourses; }
    public void setEnrolledCourses(List<Course> enrolledCourses) { 
        this.enrolledCourses = enrolledCourses; 
    }
    
    // Business methods
    public void enrollInCourse(Course course) {
        if (!enrolledCourses.contains(course)) {
            enrolledCourses.add(course);
        }
    }
    
    public void dropCourse(Course course) {
        enrolledCourses.remove(course);
    }
    
    public String getFullName() {
        return firstName + " " + lastName;
    }
    
    @Override
    public String toString() {
        return "Student{" +
                "id=" + id +
                ", name='" + getFullName() + '\'' +
                ", email='" + email + '\'' +
                ", major='" + major + '\'' +
                '}';
    }
}
```

### Service Package
```java
package com.university.studentmanagement.service;

import com.university.studentmanagement.model.Student;
import com.university.studentmanagement.model.Course;
import com.university.studentmanagement.dao.StudentDAO;
import com.university.studentmanagement.exception.StudentNotFoundException;
import java.util.List;

/**
 * Service class for student-related operations.
 */
public class StudentService {
    private StudentDAO studentDAO;
    
    public StudentService() {
        this.studentDAO = new StudentDAO();
    }
    
    public void addStudent(Student student) {
        studentDAO.save(student);
    }
    
    public Student getStudent(int id) throws StudentNotFoundException {
        Student student = studentDAO.findById(id);
        if (student == null) {
            throw new StudentNotFoundException("Student with ID " + id + " not found");
        }
        return student;
    }
    
    public List<Student> getAllStudents() {
        return studentDAO.findAll();
    }
    
    public void updateStudent(Student student) throws StudentNotFoundException {
        Student existingStudent = getStudent(student.getId());
        studentDAO.update(student);
    }
    
    public void deleteStudent(int id) throws StudentNotFoundException {
        Student student = getStudent(id);
        studentDAO.delete(student);
    }
    
    public List<Student> getStudentsByMajor(String major) {
        return studentDAO.findByMajor(major);
    }
}
```

### DAO Package
```java
package com.university.studentmanagement.dao;

import com.university.studentmanagement.model.Student;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

/**
 * Data Access Object for Student entities.
 */
public class StudentDAO {
    private List<Student> students;
    private int nextId;
    
    public StudentDAO() {
        this.students = new ArrayList<>();
        this.nextId = 1;
    }
    
    public void save(Student student) {
        if (student.getId() == 0) {
            student.setId(nextId++);
        }
        students.add(student);
    }
    
    public Student findById(int id) {
        return students.stream()
                .filter(student -> student.getId() == id)
                .findFirst()
                .orElse(null);
    }
    
    public List<Student> findAll() {
        return new ArrayList<>(students);
    }
    
    public void update(Student student) {
        for (int i = 0; i < students.size(); i++) {
            if (students.get(i).getId() == student.getId()) {
                students.set(i, student);
                break;
            }
        }
    }
    
    public void delete(Student student) {
        students.remove(student);
    }
    
    public List<Student> findByMajor(String major) {
        return students.stream()
                .filter(student -> student.getMajor().equalsIgnoreCase(major))
                .collect(Collectors.toList());
    }
}
```

### Exception Package
```java
package com.university.studentmanagement.exception;

/**
 * Exception thrown when a student is not found.
 */
public class StudentNotFoundException extends Exception {
    public StudentNotFoundException(String message) {
        super(message);
    }
    
    public StudentNotFoundException(String message, Throwable cause) {
        super(message, cause);
    }
}
```

### Util Package
```java
package com.university.studentmanagement.util;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.format.DateTimeParseException;
import java.util.regex.Pattern;

/**
 * Utility class for common operations.
 */
public class ValidationHelper {
    private static final String EMAIL_PATTERN = 
        "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
    private static final Pattern emailPattern = Pattern.compile(EMAIL_PATTERN);
    
    public static boolean isValidEmail(String email) {
        if (email == null || email.trim().isEmpty()) {
            return false;
        }
        return emailPattern.matcher(email).matches();
    }
    
    public static boolean isValidName(String name) {
        return name != null && !name.trim().isEmpty() && 
               name.matches("^[a-zA-Z\\s]+$");
    }
    
    public static boolean isValidDate(String dateString) {
        try {
            LocalDate.parse(dateString, DateTimeFormatter.ISO_LOCAL_DATE);
            return true;
        } catch (DateTimeParseException e) {
            return false;
        }
    }
    
    public static boolean isValidId(int id) {
        return id > 0;
    }
}
```

### UI Package
```java
package com.university.studentmanagement.ui;

import com.university.studentmanagement.model.Student;
import com.university.studentmanagement.service.StudentService;
import com.university.studentmanagement.exception.StudentNotFoundException;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;

/**
 * Main window for the student management system.
 */
public class MainWindow extends JFrame {
    private StudentService studentService;
    private JTextArea displayArea;
    private JTextField idField;
    private JTextField firstNameField;
    private JTextField lastNameField;
    private JTextField emailField;
    
    public MainWindow() {
        this.studentService = new StudentService();
        initializeComponents();
        setupLayout();
        setupEventHandlers();
    }
    
    private void initializeComponents() {
        displayArea = new JTextArea(10, 40);
        displayArea.setEditable(false);
        
        idField = new JTextField(10);
        firstNameField = new JTextField(20);
        lastNameField = new JTextField(20);
        emailField = new JTextField(30);
        
        JButton addButton = new JButton("Add Student");
        JButton findButton = new JButton("Find Student");
        JButton listButton = new JButton("List All Students");
        
        // Add event handlers
        addButton.addActionListener(new AddStudentHandler());
        findButton.addActionListener(new FindStudentHandler());
        listButton.addActionListener(new ListStudentsHandler());
    }
    
    private void setupLayout() {
        setTitle("Student Management System");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());
        
        // Input panel
        JPanel inputPanel = new JPanel(new GridLayout(4, 2));
        inputPanel.add(new JLabel("ID:"));
        inputPanel.add(idField);
        inputPanel.add(new JLabel("First Name:"));
        inputPanel.add(firstNameField);
        inputPanel.add(new JLabel("Last Name:"));
        inputPanel.add(lastNameField);
        inputPanel.add(new JLabel("Email:"));
        inputPanel.add(emailField);
        
        // Button panel
        JPanel buttonPanel = new JPanel();
        buttonPanel.add(new JButton("Add Student"));
        buttonPanel.add(new JButton("Find Student"));
        buttonPanel.add(new JButton("List All Students"));
        
        // Display panel
        JPanel displayPanel = new JPanel(new BorderLayout());
        displayPanel.add(new JLabel("Students:"), BorderLayout.NORTH);
        displayPanel.add(new JScrollPane(displayArea), BorderLayout.CENTER);
        
        // Add panels to frame
        add(inputPanel, BorderLayout.NORTH);
        add(buttonPanel, BorderLayout.CENTER);
        add(displayPanel, BorderLayout.SOUTH);
        
        pack();
        setLocationRelativeTo(null);
    }
    
    private void setupEventHandlers() {
        // Event handlers will be implemented here
    }
    
    // Event handler classes
    private class AddStudentHandler implements ActionListener {
        public void actionPerformed(ActionEvent e) {
            try {
                int id = Integer.parseInt(idField.getText());
                String firstName = firstNameField.getText();
                String lastName = lastNameField.getText();
                String email = emailField.getText();
                
                Student student = new Student(id, firstName, lastName, email, 
                                            null, "Computer Science");
                studentService.addStudent(student);
                
                displayArea.append("Added student: " + student + "\n");
                clearFields();
                
            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(MainWindow.this, 
                    "Please enter a valid ID number", "Error", 
                    JOptionPane.ERROR_MESSAGE);
            }
        }
    }
    
    private class FindStudentHandler implements ActionListener {
        public void actionPerformed(ActionEvent e) {
            try {
                int id = Integer.parseInt(idField.getText());
                Student student = studentService.getStudent(id);
                displayArea.append("Found student: " + student + "\n");
                
            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(MainWindow.this, 
                    "Please enter a valid ID number", "Error", 
                    JOptionPane.ERROR_MESSAGE);
            } catch (StudentNotFoundException ex) {
                JOptionPane.showMessageDialog(MainWindow.this, 
                    ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
            }
        }
    }
    
    private class ListStudentsHandler implements ActionListener {
        public void actionPerformed(ActionEvent e) {
            List<Student> students = studentService.getAllStudents();
            displayArea.setText("All Students:\n");
            for (Student student : students) {
                displayArea.append(student + "\n");
            }
        }
    }
    
    private void clearFields() {
        idField.setText("");
        firstNameField.setText("");
        lastNameField.setText("");
        emailField.setText("");
    }
    
    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            new MainWindow().setVisible(true);
        });
    }
}
```

## Package Compilation and Execution

### 1. **Compile with Package Structure**
```bash
# Compile all Java files
javac -d . src/com/university/studentmanagement/*.java
javac -d . src/com/university/studentmanagement/model/*.java
javac -d . src/com/university/studentmanagement/service/*.java
javac -d . src/com/university/studentmanagement/dao/*.java
javac -d . src/com/university/studentmanagement/util/*.java
javac -d . src/com/university/studentmanagement/exception/*.java
javac -d . src/com/university/studentmanagement/ui/*.java
```

### 2. **Run the Application**
```bash
# Run the main class
java com.university.studentmanagement.ui.MainWindow
```

### 3. **Create JAR File**
```bash
# Create JAR file
jar -cvf studentmanagement.jar com/

# Run from JAR
java -cp studentmanagement.jar com.university.studentmanagement.ui.MainWindow
```

## Package Distribution

### 1. **Create JAR File**
```bash
# Create JAR with manifest
jar -cvfm studentmanagement.jar MANIFEST.MF com/

# MANIFEST.MF content:
# Main-Class: com.university.studentmanagement.ui.MainWindow
# Version: 1.0
# Author: Your Name
```

### 2. **Create Documentation**
```bash
# Generate JavaDoc
javadoc -d docs -sourcepath src -subpackages com.university.studentmanagement
```

### 3. **Create README**
```markdown
# Student Management System

## Description
A Java application for managing university students.

## Installation
1. Download the JAR file
2. Run: `java -jar studentmanagement.jar`

## Usage
- Add new students
- Find students by ID
- List all students
- Update student information

## Requirements
- Java 8 or higher
- Swing GUI support
```

## Package Best Practices

### 1. **Consistent Naming**
- Use reverse domain name
- Use descriptive package names
- Follow Java naming conventions

### 2. **Clear Structure**
- Group related classes together
- Use appropriate package levels
- Avoid deep nesting

### 3. **Documentation**
- Create package-info.java files
- Document public APIs
- Include usage examples

### 4. **Dependencies**
- Minimize package dependencies
- Use interfaces for loose coupling
- Avoid circular dependencies

### 5. **Testing**
- Create test packages
- Test each package independently
- Use unit testing frameworks

## Summary

Creating custom packages helps you:

- **Organize code** into logical groups
- **Create reusable libraries** for distribution
- **Maintain professional project structure**
- **Share code** between projects
- **Follow industry best practices**

Custom packages are essential for building professional Java applications and libraries that can be easily maintained, shared, and extended.

# Package Exercises

## Exercise 1: Basic Package Creation

### Task
Create a simple package structure for a **Library Management System** with the following requirements:

1. **Package Structure:**
   ```
   com.library.system
   ├── model/
   ├── service/
   ├── dao/
   └── util/
   ```

2. **Model Package:**
   - Create `Book` class with fields: `id`, `title`, `author`, `isbn`, `available`
   - Create `Member` class with fields: `id`, `name`, `email`, `phone`

3. **Service Package:**
   - Create `BookService` class with methods: `addBook()`, `findBook()`, `getAllBooks()`
   - Create `MemberService` class with methods: `addMember()`, `findMember()`, `getAllMembers()`

4. **DAO Package:**
   - Create `BookDAO` class with methods: `save()`, `findById()`, `findAll()`
   - Create `MemberDAO` class with methods: `save()`, `findById()`, `findAll()`

5. **Util Package:**
   - Create `ValidationHelper` class with methods: `isValidEmail()`, `isValidPhone()`, `isValidIsbn()`

### Solution
```java
// com.library.system.model.Book
package com.library.system.model;

public class Book {
    private int id;
    private String title;
    private String author;
    private String isbn;
    private boolean available;
    
    public Book(int id, String title, String author, String isbn) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.available = true;
    }
    
    // Getters and setters
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    
    public String getTitle() { return title; }
    public void setTitle(String title) { this.title = title; }
    
    public String getAuthor() { return author; }
    public void setAuthor(String author) { this.author = author; }
    
    public String getIsbn() { return isbn; }
    public void setIsbn(String isbn) { this.isbn = isbn; }
    
    public boolean isAvailable() { return available; }
    public void setAvailable(boolean available) { this.available = available; }
    
    @Override
    public String toString() {
        return "Book{" +
                "id=" + id +
                ", title='" + title + '\'' +
                ", author='" + author + '\'' +
                ", isbn='" + isbn + '\'' +
                ", available=" + available +
                '}';
    }
}
```

## Exercise 2: Package Dependencies

### Task
Create a **Bank Account System** with proper package dependencies:

1. **Package Structure:**
   ```
   com.bank.system
   ├── model/
   ├── service/
   ├── dao/
   ├── exception/
   └── ui/
   ```

2. **Dependencies:**
   - `service` package imports `model` and `dao` packages
   - `ui` package imports `service` and `model` packages
   - `dao` package imports `model` package
   - `exception` package is imported by `service` package

3. **Create Classes:**
   - `Account` model with `accountNumber`, `balance`, `accountType`
   - `AccountService` with `deposit()`, `withdraw()`, `getBalance()`
   - `AccountDAO` with `save()`, `findByAccountNumber()`
   - `InsufficientFundsException` custom exception
   - `BankUI` main interface class

### Solution
```java
// com.bank.system.model.Account
package com.bank.system.model;

public class Account {
    private String accountNumber;
    private double balance;
    private String accountType;
    
    public Account(String accountNumber, double balance, String accountType) {
        this.accountNumber = accountNumber;
        this.balance = balance;
        this.accountType = accountType;
    }
    
    // Getters and setters
    public String getAccountNumber() { return accountNumber; }
    public void setAccountNumber(String accountNumber) { this.accountNumber = accountNumber; }
    
    public double getBalance() { return balance; }
    public void setBalance(double balance) { this.balance = balance; }
    
    public String getAccountType() { return accountType; }
    public void setAccountType(String accountType) { this.accountType = accountType; }
    
    @Override
    public String toString() {
        return "Account{" +
                "accountNumber='" + accountNumber + '\'' +
                ", balance=" + balance +
                ", accountType='" + accountType + '\'' +
                '}';
    }
}
```

```java
// com.bank.system.exception.InsufficientFundsException
package com.bank.system.exception;

public class InsufficientFundsException extends Exception {
    public InsufficientFundsException(String message) {
        super(message);
    }
}
```

```java
// com.bank.system.service.AccountService
package com.bank.system.service;

import com.bank.system.model.Account;
import com.bank.system.dao.AccountDAO;
import com.bank.system.exception.InsufficientFundsException;

public class AccountService {
    private AccountDAO accountDAO;
    
    public AccountService() {
        this.accountDAO = new AccountDAO();
    }
    
    public void deposit(String accountNumber, double amount) {
        Account account = accountDAO.findByAccountNumber(accountNumber);
        if (account != null) {
            account.setBalance(account.getBalance() + amount);
            accountDAO.save(account);
        }
    }
    
    public void withdraw(String accountNumber, double amount) throws InsufficientFundsException {
        Account account = accountDAO.findByAccountNumber(accountNumber);
        if (account != null) {
            if (account.getBalance() >= amount) {
                account.setBalance(account.getBalance() - amount);
                accountDAO.save(account);
            } else {
                throw new InsufficientFundsException("Insufficient funds for withdrawal");
            }
        }
    }
    
    public double getBalance(String accountNumber) {
        Account account = accountDAO.findByAccountNumber(accountNumber);
        return account != null ? account.getBalance() : 0.0;
    }
}
```

## Exercise 3: Package Organization

### Task
Reorganize the following classes into proper packages:

**Given Classes:**
- `Student` (data model)
- `Course` (data model)
- `StudentService` (business logic)
- `CourseService` (business logic)
- `StudentDAO` (data access)
- `CourseDAO` (data access)
- `ValidationHelper` (utility)
- `DateHelper` (utility)
- `StudentNotFoundException` (exception)
- `CourseNotFoundException` (exception)
- `MainWindow` (user interface)
- `StudentWindow` (user interface)

**Create Package Structure:**
```
com.university.management
├── model/
├── service/
├── dao/
├── util/
├── exception/
└── ui/
```

### Solution
```java
// com.university.management.model.Student
package com.university.management.model;

public class Student {
    private int id;
    private String name;
    private String email;
    private String major;
    
    public Student(int id, String name, String email, String major) {
        this.id = id;
        this.name = name;
        this.email = email;
        this.major = major;
    }
    
    // Getters and setters
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    
    public String getName() { return name; }
    public void setName(String name) { this.name = name; }
    
    public String getEmail() { return email; }
    public void setEmail(String email) { this.email = email; }
    
    public String getMajor() { return major; }
    public void setMajor(String major) { this.major = major; }
    
    @Override
    public String toString() {
        return "Student{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", email='" + email + '\'' +
                ", major='" + major + '\'' +
                '}';
    }
}
```

```java
// com.university.management.util.ValidationHelper
package com.university.management.util;

import java.util.regex.Pattern;

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
    
    public static boolean isValidId(int id) {
        return id > 0;
    }
}
```

## Exercise 4: Package Documentation

### Task
Create comprehensive documentation for a **E-commerce System** package:

1. **Create Package-Info Files:**
   - `com.ecommerce.model` - Data models
   - `com.ecommerce.service` - Business logic
   - `com.ecommerce.dao` - Data access
   - `com.ecommerce.util` - Utilities
   - `com.ecommerce.exception` - Custom exceptions

2. **Include in Documentation:**
   - Package purpose and description
   - Key classes and their purposes
   - Usage examples
   - Dependencies
   - Version information

### Solution
```java
// com.ecommerce.model.package-info.java
package com.ecommerce.model;

/**
 * Data models for the e-commerce system.
 * 
 * <p>This package contains all the data models that represent
 * the core business entities in the e-commerce application.</p>
 * 
 * <p>Key models include:</p>
 * <ul>
 *   <li>{@link Product} - Represents a product in the catalog</li>
 *   <li>{@link Customer} - Represents a customer account</li>
 *   <li>{@link Order} - Represents a customer order</li>
 *   <li>{@link OrderItem} - Represents an item within an order</li>
 * </ul>
 * 
 * <p>Usage example:</p>
 * <pre>
 * Product product = new Product(1, "Laptop", 999.99, "Electronics");
 * Customer customer = new Customer(1, "John Doe", "john@example.com");
 * Order order = new Order(1, customer.getId(), 999.99);
 * </pre>
 * 
 * <p>Dependencies:</p>
 * <ul>
 *   <li>None - This package has no dependencies</li>
 * </ul>
 * 
 * @author E-commerce Team
 * @version 1.0
 * @since 2024-01-01
 */
```

```java
// com.ecommerce.service.package-info.java
package com.ecommerce.service;

/**
 * Business logic services for the e-commerce system.
 * 
 * <p>This package contains service classes that implement
 * the business logic of the e-commerce application.</p>
 * 
 * <p>Key services include:</p>
 * <ul>
 *   <li>{@link ProductService} - Product management operations</li>
 *   <li>{@link CustomerService} - Customer management operations</li>
 *   <li>{@link OrderService} - Order processing operations</li>
 *   <li>{@link PaymentService} - Payment processing operations</li>
 * </ul>
 * 
 * <p>Usage example:</p>
 * <pre>
 * ProductService productService = new ProductService();
 * Product product = productService.getProduct(1);
 * productService.updateProduct(product);
 * </pre>
 * 
 * <p>Dependencies:</p>
 * <ul>
 *   <li>com.ecommerce.model - For data models</li>
 *   <li>com.ecommerce.dao - For data access</li>
 *   <li>com.ecommerce.exception - For custom exceptions</li>
 * </ul>
 * 
 * @author E-commerce Team
 * @version 1.0
 * @since 2024-01-01
 */
```

## Exercise 5: Package Compilation and Execution

### Task
Create a complete **Inventory Management System** and demonstrate:

1. **Package Structure:**
   ```
   com.inventory.management
   ├── model/
   │   ├── Product.java
   │   └── Category.java
   ├── service/
   │   └── InventoryService.java
   ├── dao/
   │   └── ProductDAO.java
   ├── util/
   │   └── InventoryHelper.java
   └── ui/
       └── InventoryUI.java
   ```

2. **Compilation Steps:**
   - Compile all packages
   - Create JAR file
   - Run the application

3. **Create Build Script:**
   - Windows batch file
   - Linux shell script

### Solution
```java
// com.inventory.management.model.Product
package com.inventory.management.model;

public class Product {
    private int id;
    private String name;
    private String category;
    private double price;
    private int quantity;
    
    public Product(int id, String name, String category, double price, int quantity) {
        this.id = id;
        this.name = name;
        this.category = category;
        this.price = price;
        this.quantity = quantity;
    }
    
    // Getters and setters
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    
    public String getName() { return name; }
    public void setName(String name) { this.name = name; }
    
    public String getCategory() { return category; }
    public void setCategory(String category) { this.category = category; }
    
    public double getPrice() { return price; }
    public void setPrice(double price) { this.price = price; }
    
    public int getQuantity() { return quantity; }
    public void setQuantity(int quantity) { this.quantity = quantity; }
    
    @Override
    public String toString() {
        return "Product{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", category='" + category + '\'' +
                ", price=" + price +
                ", quantity=" + quantity +
                '}';
    }
}
```

```java
// com.inventory.management.ui.InventoryUI
package com.inventory.management.ui;

import com.inventory.management.model.Product;
import com.inventory.management.service.InventoryService;
import java.util.List;
import java.util.Scanner;

public class InventoryUI {
    private InventoryService inventoryService;
    private Scanner scanner;
    
    public InventoryUI() {
        this.inventoryService = new InventoryService();
        this.scanner = new Scanner(System.in);
    }
    
    public void run() {
        boolean running = true;
        
        while (running) {
            showMenu();
            int choice = scanner.nextInt();
            scanner.nextLine(); // Consume newline
            
            switch (choice) {
                case 1:
                    addProduct();
                    break;
                case 2:
                    viewProducts();
                    break;
                case 3:
                    updateProduct();
                    break;
                case 4:
                    deleteProduct();
                    break;
                case 5:
                    running = false;
                    break;
                default:
                    System.out.println("Invalid choice. Please try again.");
            }
        }
    }
    
    private void showMenu() {
        System.out.println("\n=== Inventory Management System ===");
        System.out.println("1. Add Product");
        System.out.println("2. View Products");
        System.out.println("3. Update Product");
        System.out.println("4. Delete Product");
        System.out.println("5. Exit");
        System.out.print("Enter your choice: ");
    }
    
    private void addProduct() {
        System.out.print("Enter product name: ");
        String name = scanner.nextLine();
        
        System.out.print("Enter category: ");
        String category = scanner.nextLine();
        
        System.out.print("Enter price: ");
        double price = scanner.nextDouble();
        
        System.out.print("Enter quantity: ");
        int quantity = scanner.nextInt();
        
        Product product = new Product(0, name, category, price, quantity);
        inventoryService.addProduct(product);
        System.out.println("Product added successfully!");
    }
    
    private void viewProducts() {
        List<Product> products = inventoryService.getAllProducts();
        System.out.println("\n=== All Products ===");
        for (Product product : products) {
            System.out.println(product);
        }
    }
    
    private void updateProduct() {
        System.out.print("Enter product ID to update: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline
        
        Product product = inventoryService.getProduct(id);
        if (product != null) {
            System.out.print("Enter new name: ");
            String name = scanner.nextLine();
            product.setName(name);
            
            System.out.print("Enter new price: ");
            double price = scanner.nextDouble();
            product.setPrice(price);
            
            inventoryService.updateProduct(product);
            System.out.println("Product updated successfully!");
        } else {
            System.out.println("Product not found!");
        }
    }
    
    private void deleteProduct() {
        System.out.print("Enter product ID to delete: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline
        
        if (inventoryService.deleteProduct(id)) {
            System.out.println("Product deleted successfully!");
        } else {
            System.out.println("Product not found!");
        }
    }
    
    public static void main(String[] args) {
        InventoryUI ui = new InventoryUI();
        ui.run();
    }
}
```

### Build Scripts

**Windows (build.bat):**
```batch
@echo off
echo Compiling Inventory Management System...

REM Create output directory
if not exist "build" mkdir build

REM Compile all Java files
javac -d build -sourcepath src src/com/inventory/management/*.java
javac -d build -sourcepath src src/com/inventory/management/model/*.java
javac -d build -sourcepath src src/com/inventory/management/service/*.java
javac -d build -sourcepath src src/com/inventory/management/dao/*.java
javac -d build -sourcepath src src/com/inventory/management/util/*.java
javac -d build -sourcepath src src/com/inventory/management/ui/*.java

if %ERRORLEVEL% EQU 0 (
    echo Compilation successful!
    echo Creating JAR file...
    jar -cvf inventory-management.jar -C build .
    echo JAR file created: inventory-management.jar
    echo.
    echo To run the application:
    echo java -cp inventory-management.jar com.inventory.management.ui.InventoryUI
) else (
    echo Compilation failed!
)
```

**Linux (build.sh):**
```bash
#!/bin/bash
echo "Compiling Inventory Management System..."

# Create output directory
mkdir -p build

# Compile all Java files
javac -d build -sourcepath src src/com/inventory/management/*.java
javac -d build -sourcepath src src/com/inventory/management/model/*.java
javac -d build -sourcepath src src/com/inventory/management/service/*.java
javac -d build -sourcepath src src/com/inventory/management/dao/*.java
javac -d build -sourcepath src src/com/inventory/management/util/*.java
javac -d build -sourcepath src src/com/inventory/management/ui/*.java

if [ $? -eq 0 ]; then
    echo "Compilation successful!"
    echo "Creating JAR file..."
    jar -cvf inventory-management.jar -C build .
    echo "JAR file created: inventory-management.jar"
    echo ""
    echo "To run the application:"
    echo "java -cp inventory-management.jar com.inventory.management.ui.InventoryUI"
else
    echo "Compilation failed!"
fi
```

## Exercise 6: Package Testing

### Task
Create unit tests for the **Student Management System** packages:

1. **Test Package Structure:**
   ```
   com.university.studentmanagement.test
   ├── model/
   ├── service/
   ├── dao/
   └── util/
   ```

2. **Create Test Classes:**
   - `StudentTest` - Test Student model
   - `StudentServiceTest` - Test StudentService
   - `StudentDAOTest` - Test StudentDAO
   - `ValidationHelperTest` - Test ValidationHelper

3. **Test Methods:**
   - Test getters and setters
   - Test business logic methods
   - Test validation methods
   - Test exception handling

### Solution
```java
// com.university.studentmanagement.test.model.StudentTest
package com.university.studentmanagement.test.model;

import com.university.studentmanagement.model.Student;
import org.junit.Test;
import static org.junit.Assert.*;

public class StudentTest {
    
    @Test
    public void testStudentCreation() {
        Student student = new Student(1, "John Doe", "john@example.com", "Computer Science");
        
        assertEquals(1, student.getId());
        assertEquals("John Doe", student.getName());
        assertEquals("john@example.com", student.getEmail());
        assertEquals("Computer Science", student.getMajor());
    }
    
    @Test
    public void testSetters() {
        Student student = new Student(1, "John Doe", "john@example.com", "Computer Science");
        
        student.setName("Jane Doe");
        student.setEmail("jane@example.com");
        student.setMajor("Mathematics");
        
        assertEquals("Jane Doe", student.getName());
        assertEquals("jane@example.com", student.getEmail());
        assertEquals("Mathematics", student.getMajor());
    }
    
    @Test
    public void testToString() {
        Student student = new Student(1, "John Doe", "john@example.com", "Computer Science");
        String expected = "Student{id=1, name='John Doe', email='john@example.com', major='Computer Science'}";
        
        assertEquals(expected, student.toString());
    }
}
```

```java
// com.university.studentmanagement.test.util.ValidationHelperTest
package com.university.studentmanagement.test.util;

import com.university.studentmanagement.util.ValidationHelper;
import org.junit.Test;
import static org.junit.Assert.*;

public class ValidationHelperTest {
    
    @Test
    public void testValidEmail() {
        assertTrue(ValidationHelper.isValidEmail("test@example.com"));
        assertTrue(ValidationHelper.isValidEmail("user.name@domain.co.uk"));
        assertTrue(ValidationHelper.isValidEmail("user+tag@example.org"));
    }
    
    @Test
    public void testInvalidEmail() {
        assertFalse(ValidationHelper.isValidEmail("invalid-email"));
        assertFalse(ValidationHelper.isValidEmail("@example.com"));
        assertFalse(ValidationHelper.isValidEmail("test@"));
        assertFalse(ValidationHelper.isValidEmail(""));
        assertFalse(ValidationHelper.isValidEmail(null));
    }
    
    @Test
    public void testValidName() {
        assertTrue(ValidationHelper.isValidName("John Doe"));
        assertTrue(ValidationHelper.isValidName("Jane Smith"));
        assertTrue(ValidationHelper.isValidName("A"));
    }
    
    @Test
    public void testInvalidName() {
        assertFalse(ValidationHelper.isValidName("John123"));
        assertFalse(ValidationHelper.isValidName("John@Doe"));
        assertFalse(ValidationHelper.isValidName(""));
        assertFalse(ValidationHelper.isValidName(null));
    }
    
    @Test
    public void testValidId() {
        assertTrue(ValidationHelper.isValidId(1));
        assertTrue(ValidationHelper.isValidId(100));
        assertTrue(ValidationHelper.isValidId(Integer.MAX_VALUE));
    }
    
    @Test
    public void testInvalidId() {
        assertFalse(ValidationHelper.isValidId(0));
        assertFalse(ValidationHelper.isValidId(-1));
        assertFalse(ValidationHelper.isValidId(-100));
    }
}
```

## Summary

These exercises help you practice:

- **Package creation** and organization
- **Package dependencies** and imports
- **Package documentation** and best practices
- **Package compilation** and execution
- **Package testing** and quality assurance

Complete these exercises to master Java package concepts and become proficient in organizing professional Java applications.

# Examples: Coupling and Cohesion in Practice

Real-world examples showing good and bad coupling and cohesion.

## Example 1: Order Processing System

### Bad: High Coupling + Low Cohesion

```java
// High Coupling: Direct dependencies on concrete classes
// Low Cohesion: Mixes validation, calculation, email, persistence
public class OrderProcessor {
    private MySQLDatabase database;  // Concrete class
    private GmailEmailService emailService;  // Concrete class
    private FileLogger logger;  // Concrete class
    
    public void processOrder(Order order) {
        // Validation (should be separate class)
        if (order.getCustomer() == null) {
            throw new IllegalArgumentException("Customer required");
        }
        if (order.getItems().isEmpty()) {
            throw new IllegalArgumentException("Items required");
        }
        
        // Calculation (should be separate class)
        double subtotal = 0;
        for (Item item : order.getItems()) {
            subtotal += item.getPrice() * item.getQuantity();
        }
        double tax = subtotal * 0.1;
        double total = subtotal + tax;
        order.setTotal(total);
        
        // Email (should be separate class)
        emailService.sendGmail(
            order.getCustomer().getEmail(), 
            "Order confirmed: " + order.getId()
        );
        
        // Persistence (should be separate class)
        database.executeSQL(
            "INSERT INTO orders (id, customer_id, total) VALUES (?, ?, ?)",
            order.getId(), 
            order.getCustomer().getId(), 
            total
        );
        
        // Logging (should be separate class)
        logger.writeToFile("Order processed: " + order.getId());
    }
}
```

**Problems:**
- Hard to test (needs real database, email, file system)
- Hard to change (tightly coupled to specific implementations)
- Hard to understand (does too many things)
- Violates Single Responsibility Principle

### Good: Low Coupling + High Cohesion

```java
// Low Coupling: Depends on interfaces
// High Cohesion: Each class has a single responsibility

// OrderValidator: High Cohesion - only validates
public class OrderValidator {
    public boolean validate(Order order) {
        return isValidCustomer(order) 
            && isValidItems(order) 
            && isValidTotal(order);
    }
    
    private boolean isValidCustomer(Order order) {
        return order.getCustomer() != null;
    }
    
    private boolean isValidItems(Order order) {
        return !order.getItems().isEmpty();
    }
    
    private boolean isValidTotal(Order order) {
        return order.getTotal() > 0;
    }
}

// OrderCalculator: High Cohesion - only calculates
public class OrderCalculator {
    public void calculateTotals(Order order) {
        double subtotal = calculateSubtotal(order);
        double tax = calculateTax(subtotal);
        double total = subtotal + tax;
        order.setTotal(total);
    }
    
    private double calculateSubtotal(Order order) {
        return order.getItems().stream()
            .mapToDouble(item -> item.getPrice() * item.getQuantity())
            .sum();
    }
    
    private double calculateTax(double subtotal) {
        return subtotal * 0.1;
    }
}

// OrderService: Low Coupling - depends on interfaces
public class OrderService {
    private IOrderValidator validator;  // Interface
    private IOrderCalculator calculator;  // Interface
    private IOrderRepository repository;  // Interface
    private IEmailService emailService;  // Interface
    private ILogger logger;  // Interface
    
    public OrderService(
        IOrderValidator validator,
        IOrderCalculator calculator,
        IOrderRepository repository,
        IEmailService emailService,
        ILogger logger
    ) {
        this.validator = validator;
        this.calculator = calculator;
        this.repository = repository;
        this.emailService = emailService;
        this.logger = logger;
    }
    
    public void processOrder(Order order) {
        if (!validator.validate(order)) {
            throw new IllegalArgumentException("Invalid order");
        }
        
        calculator.calculateTotals(order);
        repository.save(order);
        emailService.sendConfirmation(order);
        logger.log("Order processed: " + order.getId());
    }
}
```

**Benefits:**
- Easy to test (can inject mocks)
- Easy to change (swap implementations)
- Easy to understand (each class has one purpose)
- Follows Single Responsibility Principle

## Example 2: User Management System

### Bad: High Coupling

```java
// High Coupling: Direct access to internal implementation
public class User {
    public String name;  // Public field - exposes implementation
    public String email;  // Public field
    public List<String> roles;  // Public field
}

public class UserService {
    public void updateUser(User user, String newName) {
        // Directly modifying internal structure
        user.name = newName;  // High coupling!
        
        // Directly accessing internal list
        if (!user.roles.contains("admin")) {
            user.roles.add("user");
        }
    }
    
    public void printUser(User user) {
        // Directly accessing fields
        System.out.println(user.name + " <" + user.email + ">");
    }
}
```

**Problems:**
- Changes to `User` internals break `UserService`
- Violates encapsulation
- Cannot change `User` implementation

### Good: Low Coupling

```java
// Low Coupling: Uses public interface
public class User {
    private String name;
    private String email;
    private List<String> roles;
    
    public String getName() {
        return name;
    }
    
    public void setName(String name) {
        this.name = name;
    }
    
    public String getEmail() {
        return email;
    }
    
    public boolean hasRole(String role) {
        return roles.contains(role);
    }
    
    public void addRole(String role) {
        if (!roles.contains(role)) {
            roles.add(role);
        }
    }
    
    @Override
    public String toString() {
        return name + " <" + email + ">";
    }
}

public class UserService {
    public void updateUser(User user, String newName) {
        // Uses public interface, not internal structure
        user.setName(newName);
        
        if (!user.hasRole("admin")) {
            user.addRole("user");
        }
    }
    
    public void printUser(User user) {
        // Uses public interface
        System.out.println(user.toString());
    }
}
```

**Benefits:**
- `UserService` doesn't know about `User` internals
- Can change `User` implementation without breaking `UserService`
- Encapsulation maintained

## Example 3: Utility Class

### Bad: Low Cohesion

```java
// Low Cohesion: Unrelated methods grouped together
public class Utility {
    public double calculateTax(double amount) {
        return amount * 0.1;
    }
    
    public void sendEmail(String address, String message) {
        // Email sending logic
    }
    
    public String formatDate(Date date) {
        // Date formatting logic
    }
    
    public boolean validatePassword(String password) {
        // Password validation logic
    }
    
    public void processPayment(Payment payment) {
        // Payment processing logic
    }
}
```

**Problems:**
- No clear purpose
- Methods are unrelated
- Hard to understand what the class does
- Hard to find specific functionality

### Good: High Cohesion

```java
// High Cohesion: Each class has a single, clear purpose

public class TaxCalculator {
    private static final double TAX_RATE = 0.1;
    
    public double calculateTax(double amount) {
        return amount * TAX_RATE;
    }
    
    public double calculateTotalWithTax(double amount) {
        return amount + calculateTax(amount);
    }
}

public class EmailService {
    public void sendEmail(String address, String message) {
        // Email sending logic
    }
    
    public void sendBulkEmail(List<String> addresses, String message) {
        // Bulk email logic
    }
}

public class DateFormatter {
    public String formatDate(Date date) {
        // Date formatting logic
    }
    
    public String formatDateTime(Date date) {
        // DateTime formatting logic
    }
}

public class PasswordValidator {
    public boolean validatePassword(String password) {
        // Password validation logic
    }
    
    public boolean isStrongPassword(String password) {
        // Strength checking logic
    }
}

public class PaymentProcessor {
    public void processPayment(Payment payment) {
        // Payment processing logic
    }
    
    public void refundPayment(Payment payment) {
        // Refund logic
    }
}
```

**Benefits:**
- Each class has a clear purpose
- Related methods grouped together
- Easy to find functionality
- Easy to understand and maintain

## Example 4: Data Access Layer

### Bad: High Coupling + Low Cohesion

```java
// High Coupling: Directly uses database implementation
// Low Cohesion: Mixes data access, validation, and business logic
public class UserDAO {
    private MySQLConnection connection;  // Concrete class
    
    public void saveUser(User user) {
        // Validation (should be separate)
        if (user.getName() == null) {
            throw new IllegalArgumentException();
        }
        
        // Business logic (should be separate)
        if (user.getAge() < 18) {
            user.setStatus("minor");
        }
        
        // Data access (mixed with other concerns)
        connection.execute(
            "INSERT INTO users (name, email, age, status) VALUES (?, ?, ?, ?)",
            user.getName(), user.getEmail(), user.getAge(), user.getStatus()
        );
    }
    
    public User findUser(int id) {
        // Direct SQL access
        ResultSet rs = connection.executeQuery(
            "SELECT * FROM users WHERE id = ?", id
        );
        // Mapping logic mixed with data access
        User user = new User();
        user.setId(rs.getInt("id"));
        user.setName(rs.getString("name"));
        // ... more mapping
        return user;
    }
}
```

### Good: Low Coupling + High Cohesion

```java
// Low Coupling: Uses repository interface
// High Cohesion: Each class has a single responsibility

// UserValidator: High Cohesion - only validates
public class UserValidator {
    public boolean validate(User user) {
        return user.getName() != null 
            && user.getEmail() != null
            && user.getAge() > 0;
    }
}

// UserService: High Cohesion - only business logic
public class UserService {
    private IUserRepository repository;  // Interface
    private UserValidator validator;  // High cohesion class
    
    public UserService(IUserRepository repository) {
        this.repository = repository;
        this.validator = new UserValidator();
    }
    
    public void saveUser(User user) {
        if (!validator.validate(user)) {
            throw new IllegalArgumentException("Invalid user");
        }
        
        // Business logic
        if (user.getAge() < 18) {
            user.setStatus("minor");
        }
        
        repository.save(user);  // Simple interface
    }
}

// UserRepository: High Cohesion - only data access
public class UserRepository implements IUserRepository {
    private IDataSource dataSource;  // Interface, not concrete
    
    public UserRepository(IDataSource dataSource) {
        this.dataSource = dataSource;
    }
    
    public void save(User user) {
        // Only data access logic
        dataSource.execute(
            "INSERT INTO users (name, email, age, status) VALUES (?, ?, ?, ?)",
            user.getName(), user.getEmail(), user.getAge(), user.getStatus()
        );
    }
    
    public User findById(int id) {
        // Only data access logic
        ResultSet rs = dataSource.query(
            "SELECT * FROM users WHERE id = ?", id
        );
        return mapToUser(rs);
    }
    
    private User mapToUser(ResultSet rs) {
        // Mapping logic
        User user = new User();
        user.setId(rs.getInt("id"));
        user.setName(rs.getString("name"));
        // ... more mapping
        return user;
    }
}
```

**Benefits:**
- Easy to test (can mock repository)
- Easy to change (can swap database)
- Clear separation of concerns
- Each class has one responsibility

## Key Takeaways

From these examples:

1. **High Coupling** makes code hard to test, change, and maintain
2. **Low Cohesion** makes code hard to understand and reuse
3. **Low Coupling + High Cohesion** creates maintainable, flexible code
4. **Use interfaces** to achieve low coupling
5. **Single responsibility** to achieve high cohesion

The goal is always: **Low Coupling + High Cohesion = Well-Designed Code**


# Examples: Dependency Injection in Practice

Real-world examples showing dependency injection and how it relates to SOLID principles.

## Example 1: User Service

### Without Dependency Injection

```java
// Bad: Direct dependencies
public class UserService {
    private PostgreSQLDatabase database;
    private GmailEmailService emailService;
    private FileLogger logger;
    
    public UserService() {
        this.database = new PostgreSQLDatabase();  // Hardcoded!
        this.emailService = new GmailEmailService();  // Hardcoded!
        this.logger = new FileLogger();  // Hardcoded!
    }
    
    public void createUser(User user) {
        database.save(user);
        emailService.sendWelcomeEmail(user.getEmail());
        logger.log("User created: " + user.getName());
    }
}

// Problems:
// - Cannot test without real database, email, file system
// - Tightly coupled to specific implementations
// - Cannot change implementations without modifying code
// - Violates Dependency Inversion Principle
```

### With Dependency Injection

```java
// Good: Dependencies injected
public class UserService {
    private final Database database;  // Interface
    private final EmailService emailService;  // Interface
    private final Logger logger;  // Interface
    
    // Constructor injection - dependencies required
    public UserService(Database database, EmailService emailService, Logger logger) {
        if (database == null || emailService == null || logger == null) {
            throw new IllegalArgumentException("Dependencies cannot be null");
        }
        this.database = database;
        this.emailService = emailService;
        this.logger = logger;
    }
    
    public void createUser(User user) {
        database.save(user);
        emailService.sendWelcomeEmail(user.getEmail());
        logger.log("User created: " + user.getName());
    }
}

// Usage in production:
Database db = new PostgreSQLDatabase();
EmailService email = new GmailEmailService();
Logger logger = new FileLogger();
UserService service = new UserService(db, email, logger);

// Usage in testing:
Database mockDb = mock(Database.class);
EmailService mockEmail = mock(EmailService.class);
Logger mockLogger = mock(Logger.class);
UserService service = new UserService(mockDb, mockEmail, mockLogger);
```

**Benefits:**
- Easy to test (inject mocks)
- Loose coupling (depends on interfaces)
- Easy to change (swap implementations)
- Follows Dependency Inversion Principle

## Example 2: Order Processing

### Without Dependency Injection

```java
// Bad: Creates dependencies
public class OrderProcessor {
    private PaymentGateway paymentGateway;
    private InventoryService inventoryService;
    
    public OrderProcessor() {
        this.paymentGateway = new StripePaymentGateway();  // Hardcoded!
        this.inventoryService = new DatabaseInventoryService();  // Hardcoded!
    }
    
    public void processOrder(Order order) {
        // Process payment
        paymentGateway.charge(order.getTotal());
        
        // Update inventory
        inventoryService.reduceStock(order.getItems());
    }
}

// Testing is difficult:
@Test
public void testProcessOrder() {
    OrderProcessor processor = new OrderProcessor();
    // Problem: Uses real Stripe API and real database!
    // - Requires internet connection
    // - Charges real credit cards
    // - Modifies real inventory
    processor.processOrder(order);
}
```

### With Dependency Injection

```java
// Good: Dependencies injected
public class OrderProcessor {
    private final PaymentGateway paymentGateway;
    private final InventoryService inventoryService;
    
    public OrderProcessor(PaymentGateway paymentGateway, InventoryService inventoryService) {
        this.paymentGateway = paymentGateway;
        this.inventoryService = inventoryService;
    }
    
    public void processOrder(Order order) {
        paymentGateway.charge(order.getTotal());
        inventoryService.reduceStock(order.getItems());
    }
}

// Easy to test:
@Test
public void testProcessOrder() {
    // Inject mocks
    PaymentGateway mockPayment = mock(PaymentGateway.class);
    InventoryService mockInventory = mock(InventoryService.class);
    
    OrderProcessor processor = new OrderProcessor(mockPayment, mockInventory);
    Order order = new Order(/* ... */);
    
    processor.processOrder(order);
    
    // Verify interactions
    verify(mockPayment).charge(order.getTotal());
    verify(mockInventory).reduceStock(order.getItems());
}
```

## Example 3: Connection to Dependency Inversion Principle

Dependency Injection is the primary mechanism for achieving DIP:

### Violating DIP (Without DI)

```java
// High-level module depends on low-level module
public class UserService {  // High-level (business logic)
    private PostgreSQLDatabase database;  // Low-level (infrastructure)
    
    public UserService() {
        this.database = new PostgreSQLDatabase();
    }
}

// DIP Violation:
// - UserService (high-level) depends on PostgreSQLDatabase (low-level)
// - Both should depend on abstraction
```

### Following DIP (With DI)

```java
// Both depend on abstraction
public interface Database {  // Abstraction
    void save(Object entity);
    Object findById(String id);
}

public class UserService {  // High-level
    private Database database;  // Depends on abstraction
    
    public UserService(Database database) {
        this.database = database;
    }
}

public class PostgreSQLDatabase implements Database {  // Low-level
    @Override
    public void save(Object entity) {
        // PostgreSQL implementation
    }
    
    @Override
    public Object findById(String id) {
        // PostgreSQL implementation
    }
}

// DIP Followed:
// - UserService (high-level) depends on Database (abstraction)
// - PostgreSQLDatabase (low-level) implements Database (abstraction)
// - Both depend on abstraction ✓
```

## Example 4: Testing with Dependency Injection

The #1 reason for dependency injection: **Testing**

### Without DI: Hard to Test

```java
public class InvoiceService {
    private Database database;
    private EmailService emailService;
    private PdfGenerator pdfGenerator;
    
    public InvoiceService() {
        this.database = new PostgreSQLDatabase();  // Real database
        this.emailService = new GmailEmailService();  // Real email
        this.pdfGenerator = new ApachePdfGenerator();  // Real PDF library
    }
    
    public void generateAndSendInvoice(int invoiceId) {
        Invoice invoice = database.findInvoice(invoiceId);
        byte[] pdf = pdfGenerator.generate(invoice);
        emailService.send(invoice.getCustomerEmail(), pdf);
    }
}

// Testing requires:
// - Real database running
// - Real email service
// - Real PDF library
// - Network connection
// - Slow, fragile tests
```

### With DI: Easy to Test

```java
public class InvoiceService {
    private final Database database;
    private final EmailService emailService;
    private final PdfGenerator pdfGenerator;
    
    public InvoiceService(Database database, EmailService emailService, PdfGenerator pdfGenerator) {
        this.database = database;
        this.emailService = emailService;
        this.pdfGenerator = pdfGenerator;
    }
    
    public void generateAndSendInvoice(int invoiceId) {
        Invoice invoice = database.findInvoice(invoiceId);
        byte[] pdf = pdfGenerator.generate(invoice);
        emailService.send(invoice.getCustomerEmail(), pdf);
    }
}

// Easy to test:
@Test
public void testGenerateAndSendInvoice() {
    // Create mocks
    Database mockDb = mock(Database.class);
    EmailService mockEmail = mock(EmailService.class);
    PdfGenerator mockPdf = mock(PdfGenerator.class);
    
    // Setup mocks
    Invoice invoice = new Invoice(123, "customer@example.com", 100.0);
    when(mockDb.findInvoice(123)).thenReturn(invoice);
    when(mockPdf.generate(invoice)).thenReturn(new byte[]{1, 2, 3});
    
    // Inject mocks
    InvoiceService service = new InvoiceService(mockDb, mockEmail, mockPdf);
    
    // Test
    service.generateAndSendInvoice(123);
    
    // Verify
    verify(mockDb).findInvoice(123);
    verify(mockPdf).generate(invoice);
    verify(mockEmail).send("customer@example.com", new byte[]{1, 2, 3});
}

// Fast, isolated, reliable tests!
```

## Example 5: Different Environments

Dependency Injection makes it easy to use different implementations in different environments:

```java
public class UserService {
    private final Database database;
    
    public UserService(Database database) {
        this.database = database;
    }
}

// Development: Use in-memory database
Database devDb = new InMemoryDatabase();
UserService devService = new UserService(devDb);

// Testing: Use mock database
Database testDb = mock(Database.class);
UserService testService = new UserService(testDb);

// Production: Use real database
Database prodDb = new PostgreSQLDatabase();
UserService prodService = new UserService(prodDb);

// Same code, different implementations!
```

## Example 6: Connection to Other SOLID Principles

### Single Responsibility Principle

DI helps maintain SRP by allowing classes to focus on their core responsibility:

```java
// UserService focuses on user business logic
// Doesn't worry about creating dependencies
public class UserService {
    private final Database database;
    
    public UserService(Database database) {
        this.database = database;  // Just uses it, doesn't create it
    }
    
    // Focuses on user operations, not dependency management
    public void createUser(User user) {
        database.save(user);
    }
}
```

### Open/Closed Principle

DI enables OCP by allowing extension without modification:

```java
// Can add new Database implementations without modifying UserService
public class UserService {
    private final Database database;  // Any implementation works
    
    public UserService(Database database) {
        this.database = database;
    }
}

// New implementation - no need to modify UserService
public class MongoDBDatabase implements Database {
    // Implementation
}

// Use it:
UserService service = new UserService(new MongoDBDatabase());
```

## Key Takeaways

From these examples:

1. **Dependency Injection enables testing** - The #1 benefit
2. **DI implements Dependency Inversion Principle** - Primary mechanism for DIP
3. **DI supports other SOLID principles** - SRP, OCP, ISP
4. **Constructor injection is best practice** - Required, immutable, clear
5. **DI makes code flexible** - Easy to swap implementations
6. **DI reduces coupling** - Depend on interfaces, not implementations

The pattern is simple: **Don't create dependencies inside classes. Inject them from outside.**


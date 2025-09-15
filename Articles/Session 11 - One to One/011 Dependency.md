# Dependency Relationship

A **dependency** is a relationship where one class uses another class temporarily or for a specific operation. It's the weakest form of relationship where one class depends on another class's services or methods, but doesn't maintain a permanent reference to it.

## Key Characteristics

- **Temporary relationship**: Objects interact only when needed
- **No permanent reference**: The dependent class doesn't store a reference to the dependency
- **Method-level interaction**: Dependency is used through method parameters or local variables
- **Loose coupling**: Classes are independent and can exist separately

## How Dependency Works in Java

Dependency is implemented through:
- **Method parameters** that accept other objects
- **Local variables** that create temporary references
- **Return values** from method calls
- **Static method calls** to other classes

## Example 1: Order and PaymentProcessor

```java
public class PaymentProcessor 
{
    private String processorName;
    
    public PaymentProcessor(String processorName) 
    {
        this.processorName = processorName;
    }
    
    public boolean processPayment(double amount, String cardNumber) 
    {
        System.out.println("Processing $" + amount + " payment with " + processorName);
        // Simulate payment processing
        return Math.random() > 0.1; // 90% success rate
    }
    
    public String getProcessorName() 
    {
        return processorName;
    }
}

public class Order 
{
    private String orderId;
    private double totalAmount;
    private String customerName;
    
    public Order(String orderId, double totalAmount, String customerName) 
    {
        this.orderId = orderId;
        this.totalAmount = totalAmount;
        this.customerName = customerName;
    }
    
    // Dependency: Order uses PaymentProcessor temporarily
    public boolean processOrder(PaymentProcessor processor) 
    {
        System.out.println("Processing order " + orderId + " for " + customerName);
        System.out.println("Total amount: $" + totalAmount);
        
        // Order depends on PaymentProcessor for this operation
        boolean paymentSuccess = processor.processPayment(totalAmount, "1234-5678-9012-3456");
        
        if (paymentSuccess) 
        {
            System.out.println("Order " + orderId + " processed successfully!");
            return true;
        } 
        else 
        {
            System.out.println("Payment failed for order " + orderId);
            return false;
        }
    }
    
    public String getOrderInfo() 
    {
        return "Order " + orderId + " - " + customerName + " - $" + totalAmount;
    }
}
```

### Usage Example:

```java
public class DependencyExample 
{
    public static void main(String[] args) 
    {
        Order order = new Order("ORD-001", 99.99, "John Doe");
        PaymentProcessor processor = new PaymentProcessor("Stripe");
        
        // Order uses PaymentProcessor temporarily
        order.processOrder(processor);
        
        // After the method call, Order doesn't maintain reference to PaymentProcessor
        System.out.println("Order exists independently: " + order.getOrderInfo());
        System.out.println("PaymentProcessor exists independently: " + processor.getProcessorName());
    }
}
```

## Example 2: Student and GradeCalculator

```java
public class GradeCalculator 
{
    private String calculatorName;
    
    public GradeCalculator(String calculatorName) 
    {
        this.calculatorName = calculatorName;
    }
    
    public char calculateGrade(double score) 
    {
        if (score >= 90) return 'A';
        else if (score >= 80) return 'B';
        else if (score >= 70) return 'C';
        else if (score >= 60) return 'D';
        else return 'F';
    }
    
    public double calculateGPA(double[] scores) 
    {
        double total = 0;
        for (double score : scores) 
        {
            total += score;
        }
        return total / scores.length;
    }
}

public class Student 
{
    private String studentName;
    private String studentId;
    
    public Student(String studentName, String studentId) 
    {
        this.studentName = studentName;
        this.studentId = studentId;
    }
    
    // Dependency: Student uses GradeCalculator temporarily
    public void calculateFinalGrade(GradeCalculator calculator, double[] testScores) 
    {
        System.out.println("Calculating final grade for " + studentName);
        
        // Student depends on GradeCalculator for this operation
        double average = calculator.calculateGPA(testScores);
        char grade = calculator.calculateGrade(average);
        
        System.out.println("Student: " + studentName + " (ID: " + studentId + ")");
        System.out.println("Average Score: " + average);
        System.out.println("Final Grade: " + grade);
    }
    
    public String getStudentInfo() 
    {
        return studentName + " (" + studentId + ")";
    }
}
```

## Example 3: Email and EmailValidator

```java
public class EmailValidator 
{
    private String validatorName;
    
    public EmailValidator(String validatorName) 
    {
        this.validatorName = validatorName;
    }
    
    public boolean isValidEmail(String email) 
    {
        return email != null && email.contains("@") && email.contains(".");
    }
    
    public String getDomain(String email) 
    {
        if (isValidEmail(email)) 
        {
            return email.substring(email.indexOf("@") + 1);
        }
        return "Invalid email";
    }
}

public class Email 
{
    private String recipient;
    private String subject;
    private String content;
    
    public Email(String recipient, String subject, String content) 
    {
        this.recipient = recipient;
        this.subject = subject;
        this.content = content;
    }
    
    // Dependency: Email uses EmailValidator temporarily
    public boolean sendEmail(EmailValidator validator) 
    {
        System.out.println("Attempting to send email to: " + recipient);
        
        // Email depends on EmailValidator for this operation
        if (validator.isValidEmail(recipient)) 
        {
            String domain = validator.getDomain(recipient);
            System.out.println("Email sent successfully!");
            System.out.println("Recipient: " + recipient);
            System.out.println("Domain: " + domain);
            System.out.println("Subject: " + subject);
            return true;
        } 
        else 
        {
            System.out.println("Failed to send email - invalid recipient address");
            return false;
        }
    }
    
    public String getEmailInfo() 
    {
        return "To: " + recipient + ", Subject: " + subject;
    }
}
```

## Example 4: File and FileCompressor

```java
public class FileCompressor 
{
    private String compressionType;
    
    public FileCompressor(String compressionType) 
    {
        this.compressionType = compressionType;
    }
    
    public String compressFile(String fileName, long originalSize) 
    {
        // Simulate compression
        long compressedSize = originalSize / 2;
        double compressionRatio = (double) compressedSize / originalSize;
        
        return fileName + ".compressed (" + compressionType + ", " + 
               compressionRatio + " ratio)";
    }
    
    public String getCompressionType() 
    {
        return compressionType;
    }
}

public class File 
{
    private String fileName;
    private long fileSize;
    private String fileType;
    
    public File(String fileName, long fileSize, String fileType) 
    {
        this.fileName = fileName;
        this.fileSize = fileSize;
        this.fileType = fileType;
    }
    
    // Dependency: File uses FileCompressor temporarily
    public String compressFile(FileCompressor compressor) 
    {
        System.out.println("Compressing file: " + fileName);
        System.out.println("Original size: " + fileSize + " bytes");
        
        // File depends on FileCompressor for this operation
        String compressedFile = compressor.compressFile(fileName, fileSize);
        
        System.out.println("Compressed file: " + compressedFile);
        return compressedFile;
    }
    
    public String getFileInfo() 
    {
        return fileName + " (" + fileSize + " bytes, " + fileType + ")";
    }
}
```

## Key Points About Dependency

1. **Temporary Interaction**: Objects interact only when needed for specific operations
2. **No Permanent Reference**: The dependent class doesn't store references to dependencies
3. **Method-Level Coupling**: Dependency is established through method parameters
4. **Independent Lifecycle**: Both objects can exist and be destroyed independently
5. **Loose Coupling**: Changes to one class have minimal impact on the other

## Dependency vs Other Relationships

- **Association**: Objects have a permanent reference to each other
- **Aggregation**: One object contains another as a part
- **Composition**: One object owns another as an essential component
- **Dependency**: Objects interact temporarily without permanent references

## When to Use Dependency

Use dependency when:
- You need to perform operations on objects temporarily
- Objects should remain independent
- You want to minimize coupling between classes
- Objects are used as services or utilities
- You need to pass objects as parameters to methods

Dependency is the most flexible relationship and is commonly used for utility classes, service objects, and temporary interactions between classes.

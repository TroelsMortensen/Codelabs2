# Composition Relationship

**Composition** is a "part-of" relationship where one class contains another class as an essential component. The contained object cannot exist independently of the container - it's created, managed, and destroyed by the container. This represents the strongest form of relationship.

## Key Characteristics

- **"Part-of" relationship**: The contained object is an integral part of the container
- **Dependent existence**: The contained object cannot exist without the container
- **Exclusive ownership**: Only one container can own the contained object
- **Shared lifecycle**: When the container is destroyed, the contained object is also destroyed

## How Composition Works in Java

Composition is implemented through:
- **Instance variables** that hold references to other objects
- **Constructor creation** of contained objects within the container
- **Private access** to prevent external modification
- **No setter methods** for contained objects (they're created internally)

## Example 1: House and Room

```java
public class Room 
{
    private String roomType;
    private double area;
    private boolean hasWindow;
    
    public Room(String roomType, double area, boolean hasWindow) 
    {
        this.roomType = roomType;
        this.area = area;
        this.hasWindow = hasWindow;
    }
    
    public String getRoomInfo() 
    {
        return roomType + " (" + area + " sq ft" + (hasWindow ? ", with window" : "") + ")";
    }
    
    public double getArea() 
    {
        return area;
    }
}

public class House 
{
    private String address;
    private Room livingRoom; // Composition - House owns a Room
    private Room kitchen;    // Composition - House owns a Room
    
    public House(String address) 
    {
        this.address = address;
        // Rooms are created when house is created - composition
        this.livingRoom = new Room("Living Room", 300.0, true);
        this.kitchen = new Room("Kitchen", 150.0, true);
        System.out.println("House at " + address + " created with rooms");
    }
    
    public void displayHouseInfo() 
    {
        System.out.println("House at: " + address);
        System.out.println("  " + livingRoom.getRoomInfo());
        System.out.println("  " + kitchen.getRoomInfo());
        System.out.println("Total area: " + getTotalArea() + " sq ft");
    }
    
    private double getTotalArea() 
    {
        return livingRoom.getArea() + kitchen.getArea();
    }
    
    // No setter methods for rooms - they're part of the house
}
```

### Usage Example:

```java
public class CompositionExample 
{
    public static void main(String[] args) 
    {
        House myHouse = new House("123 Oak Street");
        myHouse.displayHouseInfo();
        
        // Rooms cannot be accessed or modified externally
        // They exist only as part of the house
    }
}
```

## Example 2: Computer and CPU

```java
public class CPU 
{
    private String brand;
    private String model;
    private double clockSpeed;
    private int cores;
    
    public CPU(String brand, String model, double clockSpeed, int cores) 
    {
        this.brand = brand;
        this.model = model;
        this.clockSpeed = clockSpeed;
        this.cores = cores;
    }
    
    public void process() 
    {
        System.out.println("CPU processing: " + brand + " " + model + " @ " + clockSpeed + "GHz");
    }
    
    public String getCPUSpecs() 
    {
        return brand + " " + model + " (" + cores + " cores, " + clockSpeed + " GHz)";
    }
}

public class Computer 
{
    private String computerName;
    private CPU processor; // Composition - Computer owns a CPU
    
    public Computer(String computerName, String cpuBrand, String cpuModel, double clockSpeed, int cores) 
    {
        this.computerName = computerName;
        // CPU is created when computer is created - composition
        this.processor = new CPU(cpuBrand, cpuModel, clockSpeed, cores);
        System.out.println("Computer '" + computerName + "' assembled with " + processor.getCPUSpecs());
    }
    
    public void bootUp() 
    {
        System.out.println("Booting " + computerName + "...");
        processor.process();
        System.out.println(computerName + " is ready!");
    }
    
    public void displaySpecs() 
    {
        System.out.println("Computer: " + computerName);
        System.out.println("Processor: " + processor.getCPUSpecs());
    }
    
    // No method to change CPU - it's an integral part of the computer
}
```

## Example 3: Bank Account and Account Number

```java
public class AccountNumber 
{
    private String accountNumber;
    private String bankCode;
    private String branchCode;
    
    public AccountNumber(String bankCode, String branchCode, String accountNumber) 
    {
        this.bankCode = bankCode;
        this.branchCode = branchCode;
        this.accountNumber = accountNumber;
    }
    
    public String getFullAccountNumber() 
    {
        return bankCode + "-" + branchCode + "-" + accountNumber;
    }
    
    public String getBankCode() 
    {
        return bankCode;
    }
    
    public String getBranchCode() 
    {
        return branchCode;
    }
}

public class BankAccount 
{
    private String accountHolderName;
    private AccountNumber accountNumber; // Composition - Account owns AccountNumber
    private double balance;
    
    public BankAccount(String accountHolderName, String bankCode, String branchCode) 
    {
        this.accountHolderName = accountHolderName;
        // Account number is generated when account is created - composition
        this.accountNumber = new AccountNumber(bankCode, branchCode, generateAccountNumber());
        this.balance = 0.0;
        System.out.println("Account created for " + accountHolderName + 
                          " with number: " + accountNumber.getFullAccountNumber());
    }
    
    private String generateAccountNumber() 
    {
        // Simple account number generation
        return String.valueOf(System.currentTimeMillis()).substring(8);
    }
    
    public void deposit(double amount) 
    {
        balance += amount;
        System.out.println("Deposited $" + amount + " to account " + accountNumber.getFullAccountNumber());
    }
    
    public void displayAccountInfo() 
    {
        System.out.println("Account Holder: " + accountHolderName);
        System.out.println("Account Number: " + accountNumber.getFullAccountNumber());
        System.out.println("Balance: $" + balance);
    }
    
    // Account number cannot be changed - it's part of the account identity
}
```

## Enforcing Composition Rules

To properly enforce composition in Java:

### 1. Create Objects in Constructor
```java
public class Container 
{
    private Component component;
    
    public Container() 
    {
        // Component is created here, not passed in
        this.component = new Component();
    }
}
```

### 2. Make Components Private
```java
public class Container 
{
    private Component component; // Private - no external access
    
    // No public getter for component
    // No public setter for component
}
```

### 3. No External References
```java
public class Container 
{
    private Component component;
    
    public Container() 
    {
        this.component = new Component();
    }
    
    // Don't provide methods that return the component
    // public Component getComponent() { return component; } // DON'T DO THIS
}
```

### 4. Handle Destruction Properly
```java
public class Container 
{
    private Component component;
    
    public Container() 
    {
        this.component = new Component();
    }
    
    // When container is destroyed, component is automatically destroyed
    // No need for explicit cleanup in most cases
}
```

## Key Points About Composition

1. **Strong Ownership**: Container completely owns the contained object
2. **Dependent Lifecycle**: Contained object cannot exist without container
3. **Exclusive Relationship**: Only one container can own the contained object
4. **Internal Creation**: Contained objects are created within the container
5. **No External Access**: Contained objects are not accessible from outside

## Composition vs Aggregation vs Association

- **Association**: Objects work together but are independent
- **Aggregation**: Objects have a whole-part relationship, but parts can exist independently
- **Composition**: Objects have a strong whole-part relationship where parts cannot exist without the whole

Composition is the strongest relationship and should be used when the contained object is an essential, inseparable part of the container.

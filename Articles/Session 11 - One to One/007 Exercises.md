# Composition Exercises

Practice implementing one-to-one composition relationships in Java with these engaging exercises. Remember: in composition, the contained object cannot exist without the container and is created internally.

## Exercise 1: Smartphone and Battery

Create a `Smartphone` class and a `Battery` class with composition. The smartphone owns its battery - the battery is created when the smartphone is manufactured and cannot be accessed externally.

### Requirements:
- `Battery` class with capacity (mAh), current charge level, and battery health
- `Smartphone` class with model name and internal battery (created in constructor)
- Methods to charge the phone, check battery status, and use apps
- Battery should be private and created internally

### Example Output:
```
iPhone 15 created with 4000mAh battery (100% charge, Health: 100%)
Charging iPhone 15... Battery now at 100%
Using Camera app... Battery drained to 95%
Battery Status: 95% charge, Health: 100%
```

## Exercise 2: Video Game Character and Inventory

Design a `GameCharacter` class and an `Inventory` class where each character has their own inventory that's created when the character is born.

### Requirements:
- `Inventory` class with item slots, weight limit, and current items
- `GameCharacter` class with name, level, and internal inventory
- Methods to add items, check inventory status, and level up
- Inventory should be created in character constructor and be private

### Example Output:
```
Warrior 'Aragorn' created with empty inventory (Max weight: 50kg)
Aragorn picked up: Iron Sword (5kg)
Aragorn picked up: Health Potion (1kg)
Inventory Status: 2 items, 6kg/50kg used
Aragorn leveled up! Inventory capacity increased to 60kg
```

## Exercise 3: Car and Engine Control Unit (ECU)

Build a `Car` class and an `ECU` class where the car has an ECU that's installed during manufacturing and controls the engine.

### Requirements:
- `ECU` class with firmware version, diagnostic codes, and engine parameters
- `Car` class with make, model, and internal ECU
- Methods to start engine, run diagnostics, and update firmware
- ECU should be created when car is manufactured and be inaccessible externally

### Example Output:
```
Tesla Model S manufactured with ECU v2.1.3
Starting Tesla Model S... ECU initializing engine systems
Engine RPM: 0, Temperature: 22°C, Status: Ready
Running diagnostics... All systems OK
ECU firmware updated to v2.1.4
```

## Exercise 4: Bank Account and Transaction History

Create a `BankAccount` class and a `TransactionHistory` class where each account has its own transaction log that's created when the account is opened.

### Requirements:
- `TransactionHistory` class with transaction list, maximum entries, and date tracking
- `BankAccount` class with account holder name and internal transaction history
- Methods to make deposits, withdrawals, and view transaction history
- Transaction history should be created when account is opened and be private

### Example Output:
```
Account opened for John Doe with transaction history initialized
Deposit: +$1000.00 - Balance: $1000.00
Withdrawal: -$150.00 - Balance: $850.00
Deposit: +$500.00 - Balance: $1350.00
Transaction History (Last 3):
1. Deposit: +$1000.00
2. Withdrawal: -$150.00
3. Deposit: +$500.00
```

## Implementation Guidelines

### 1. Enforce Composition Rules
```java
public class Container 
{
    private Component component; // Private - no external access
    
    public Container() 
    {
        // Component created internally
        this.component = new Component();
    }
    
    // No public getter for component
    // No public setter for component
}
```

### 2. Handle Component Operations Through Container
```java
public class Container 
{
    private Component component;
    
    public void performAction() 
    {
        // Use component internally
        component.doSomething();
    }
    
    public String getComponentInfo() 
    {
        // Return information about component, not component itself
        return component.getInfo();
    }
}
```

### 3. Validate Component State
```java
public class Container 
{
    private Component component;
    
    public void useComponent() 
    {
        if (component.isReady()) 
        {
            component.performTask();
        } 
        else 
        {
            System.out.println("Component not ready");
        }
    }
}
```

## Key Points to Remember

1. **Internal Creation**: Contained objects are created in the container's constructor
2. **Private Access**: Contained objects should be private and not accessible externally
3. **No Setters**: Don't provide methods to change the contained object
4. **Encapsulation**: All operations on contained objects go through the container
5. **Lifecycle Management**: Contained objects are destroyed when container is destroyed

## Bonus Challenges

1. **Add Error Handling**: What happens if the contained object fails to initialize?
2. **Resource Management**: How do you handle cleanup when the container is destroyed?
3. **State Validation**: How do you ensure the contained object is always in a valid state?
4. **Performance**: How do you optimize access to frequently used contained objects?

## Testing Your Implementation

Test that your composition is properly enforced:
- Try to access the contained object from outside the container (should fail)
- Verify that the contained object is created when the container is created
- Ensure that operations on the contained object go through the container
- Test that the contained object cannot exist independently

Remember: Composition represents the strongest relationship where the contained object is an essential, inseparable part of the container!

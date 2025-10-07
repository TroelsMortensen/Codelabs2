# Exercise - Bank Account

Create a comprehensive banking system with robust exception handling for various banking operations. This exercise will help you practice creating custom exceptions, handling business logic errors, and implementing proper validation.

## Requirements

Create a `BankAccount` class with the following functionality:

### 1. Account Management
- `BankAccount(String accountNumber, String accountHolder, double initialBalance)` - Constructor
- `getAccountNumber()` - Get account number
- `getAccountHolder()` - Get account holder name
- `getBalance()` - Get current balance
- `getAccountInfo()` - Get formatted account information

### 2. Banking Operations
- `deposit(double amount)` - Deposit money
- `withdraw(double amount)` - Withdraw money
- `transfer(BankAccount targetAccount, double amount)` - Transfer money to another account
- `getTransactionHistory()` - Get list of recent transactions

### 3. Custom Exceptions
Create the following custom exception classes:
- `InsufficientFundsException` - When withdrawal amount exceeds balance
- `InvalidAmountException` - When amount is negative or zero
- `InvalidAccountException` - When account number is invalid
- `AccountNotFoundException` - When account doesn't exist
- `TransactionLimitExceededException` - When daily transaction limit is exceeded

## Implementation Guidelines

### Custom Exception Classes

#### InsufficientFundsException
```java
public class InsufficientFundsException extends Exception {
    private double balance;
    private double requestedAmount;
    
    public InsufficientFundsException(double balance, double requestedAmount) {
        super(String.format("Insufficient funds. Balance: $%.2f, Requested: $%.2f", 
                           balance, requestedAmount));
        this.balance = balance;
        this.requestedAmount = requestedAmount;
    }
    
    public double getBalance() {
        return balance;
    }
    
    public double getRequestedAmount() {
        return requestedAmount;
    }
}
```

#### InvalidAmountException
```java
public class InvalidAmountException extends Exception {
    private double invalidAmount;
    
    public InvalidAmountException(double amount, String operation) {
        super(String.format("Invalid amount for %s: $%.2f. Amount must be positive.", 
                           operation, amount));
        this.invalidAmount = amount;
    }
    
    public double getInvalidAmount() {
        return invalidAmount;
    }
}
```

#### InvalidAccountException
```java
public class InvalidAccountException extends Exception {
    private String accountNumber;
    
    public InvalidAccountException(String accountNumber) {
        super("Invalid account number: " + accountNumber + 
              ". Account number must be 8 digits and start with 'ACC'.");
        this.accountNumber = accountNumber;
    }
    
    public String getAccountNumber() {
        return accountNumber;
    }
}
```

#### TransactionLimitExceededException
```java
public class TransactionLimitExceededException extends Exception {
    private int transactionCount;
    private int dailyLimit;
    
    public TransactionLimitExceededException(int transactionCount, int dailyLimit) {
        super(String.format("Daily transaction limit exceeded. " +
                           "Transactions today: %d, Limit: %d", 
                           transactionCount, dailyLimit));
        this.transactionCount = transactionCount;
        this.dailyLimit = dailyLimit;
    }
    
    public int getTransactionCount() {
        return transactionCount;
    }
    
    public int getDailyLimit() {
        return dailyLimit;
    }
}
```

### BankAccount Class Structure

```java
import java.util.ArrayList;
import java.util.List;

public class BankAccount {
    private String accountNumber;
    private String accountHolder;
    private double balance;
    private List<String> transactionHistory;
    private int dailyTransactionCount;
    private static final int DAILY_TRANSACTION_LIMIT = 10;
    
    public BankAccount(String accountNumber, String accountHolder, double initialBalance) 
            throws InvalidAccountException, InvalidAmountException {
        
        validateAccountNumber(accountNumber);
        validateAmount(initialBalance, "initial balance");
        
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this.balance = initialBalance;
        this.transactionHistory = new ArrayList<>();
        this.dailyTransactionCount = 0;
        
        addTransaction("Account opened with initial balance: $" + initialBalance);
    }
    
    private void validateAccountNumber(String accountNumber) throws InvalidAccountException {
        if (accountNumber == null || accountNumber.trim().isEmpty()) {
            throw new InvalidAccountException(accountNumber);
        }
        
        if (!accountNumber.startsWith("ACC") || accountNumber.length() != 11) {
            throw new InvalidAccountException(accountNumber);
        }
        
        // Check if the last 8 characters are digits
        String digits = accountNumber.substring(3);
        if (!digits.matches("\\d{8}")) {
            throw new InvalidAccountException(accountNumber);
        }
    }
    
    private void validateAmount(double amount, String operation) throws InvalidAmountException {
        if (amount <= 0) {
            throw new InvalidAmountException(amount, operation);
        }
    }
    
    private void checkTransactionLimit() throws TransactionLimitExceededException {
        if (dailyTransactionCount >= DAILY_TRANSACTION_LIMIT) {
            throw new TransactionLimitExceededException(dailyTransactionCount, DAILY_TRANSACTION_LIMIT);
        }
    }
    
    private void addTransaction(String description) {
        transactionHistory.add(description);
        dailyTransactionCount++;
    }
    
    // Getters
    public String getAccountNumber() { return accountNumber; }
    public String getAccountHolder() { return accountHolder; }
    public double getBalance() { return balance; }
    public List<String> getTransactionHistory() { return new ArrayList<>(transactionHistory); }
    
    public String getAccountInfo() {
        return String.format("Account: %s, Holder: %s, Balance: $%.2f", 
                           accountNumber, accountHolder, balance);
    }
    
    // Banking operations
    public void deposit(double amount) throws InvalidAmountException, TransactionLimitExceededException {
        validateAmount(amount, "deposit");
        checkTransactionLimit();
        
        balance += amount;
        addTransaction("Deposited: $" + amount + ", New balance: $" + balance);
    }
    
    public void withdraw(double amount) throws InvalidAmountException, InsufficientFundsException, 
                                              TransactionLimitExceededException {
        validateAmount(amount, "withdrawal");
        checkTransactionLimit();
        
        if (amount > balance) {
            throw new InsufficientFundsException(balance, amount);
        }
        
        balance -= amount;
        addTransaction("Withdrew: $" + amount + ", New balance: $" + balance);
    }
    
    public void transfer(BankAccount targetAccount, double amount) 
            throws InvalidAmountException, InsufficientFundsException, 
                   TransactionLimitExceededException, AccountNotFoundException {
        
        if (targetAccount == null) {
            throw new AccountNotFoundException("Target account is null");
        }
        
        validateAmount(amount, "transfer");
        checkTransactionLimit();
        
        if (amount > balance) {
            throw new InsufficientFundsException(balance, amount);
        }
        
        // Perform transfer
        balance -= amount;
        targetAccount.balance += amount;
        
        addTransaction("Transferred: $" + amount + " to " + targetAccount.getAccountNumber() + 
                      ", New balance: $" + balance);
        targetAccount.addTransaction("Received: $" + amount + " from " + accountNumber + 
                                   ", New balance: $" + targetAccount.balance);
    }
}
```

### AccountNotFoundException
```java
public class AccountNotFoundException extends Exception {
    private String accountIdentifier;
    
    public AccountNotFoundException(String accountIdentifier) {
        super("Account not found: " + accountIdentifier);
        this.accountIdentifier = accountIdentifier;
    }
    
    public String getAccountIdentifier() {
        return accountIdentifier;
    }
}
```

## Test Class

Create a `BankAccountTester` class with comprehensive testing:

```java
public class BankAccountTester {
    public static void main(String[] args) {
        System.out.println("=== Bank Account System Test ===\n");
        
        // Test account creation
        testAccountCreation();
        
        // Test banking operations
        testBankingOperations();
        
        // Test exception handling
        testExceptionHandling();
        
        // Test transfer operations
        testTransferOperations();
    }
    
    public static void testAccountCreation() {
        System.out.println("=== Testing Account Creation ===");
        
        try {
            // Valid account creation
            BankAccount account1 = new BankAccount("ACC12345678", "John Doe", 1000.0);
            System.out.println("✓ Account created successfully: " + account1.getAccountInfo());
            
            // Invalid account number
            try {
                BankAccount account2 = new BankAccount("INVALID123", "Jane Doe", 500.0);
            } catch (InvalidAccountException e) {
                System.out.println("✓ Caught InvalidAccountException: " + e.getMessage());
            }
            
            // Negative initial balance
            try {
                BankAccount account3 = new BankAccount("ACC87654321", "Bob Smith", -100.0);
            } catch (InvalidAmountException e) {
                System.out.println("✓ Caught InvalidAmountException: " + e.getMessage());
            }
            
        } catch (Exception e) {
            System.out.println("Unexpected error: " + e.getMessage());
        }
    }
    
    public static void testBankingOperations() {
        System.out.println("\n=== Testing Banking Operations ===");
        
        try {
            BankAccount account = new BankAccount("ACC11111111", "Alice Johnson", 2000.0);
            
            // Valid deposit
            account.deposit(500.0);
            System.out.println("✓ Deposit successful. Balance: $" + account.getBalance());
            
            // Valid withdrawal
            account.withdraw(300.0);
            System.out.println("✓ Withdrawal successful. Balance: $" + account.getBalance());
            
            // Show transaction history
            System.out.println("✓ Transaction history:");
            for (String transaction : account.getTransactionHistory()) {
                System.out.println("  - " + transaction);
            }
            
        } catch (Exception e) {
            System.out.println("Error in banking operations: " + e.getMessage());
        }
    }
    
    public static void testExceptionHandling() {
        System.out.println("\n=== Testing Exception Handling ===");
        
        try {
            BankAccount account = new BankAccount("ACC22222222", "Charlie Brown", 100.0);
            
            // Test insufficient funds
            try {
                account.withdraw(200.0);
            } catch (InsufficientFundsException e) {
                System.out.println("✓ Caught InsufficientFundsException: " + e.getMessage());
            }
            
            // Test invalid amount
            try {
                account.deposit(-50.0);
            } catch (InvalidAmountException e) {
                System.out.println("✓ Caught InvalidAmountException: " + e.getMessage());
            }
            
            // Test zero amount
            try {
                account.withdraw(0.0);
            } catch (InvalidAmountException e) {
                System.out.println("✓ Caught InvalidAmountException: " + e.getMessage());
            }
            
        } catch (Exception e) {
            System.out.println("Error in exception testing: " + e.getMessage());
        }
    }
    
    public static void testTransferOperations() {
        System.out.println("\n=== Testing Transfer Operations ===");
        
        try {
            BankAccount account1 = new BankAccount("ACC33333333", "David Wilson", 1500.0);
            BankAccount account2 = new BankAccount("ACC44444444", "Emma Davis", 800.0);
            
            // Valid transfer
            account1.transfer(account2, 200.0);
            System.out.println("✓ Transfer successful");
            System.out.println("  " + account1.getAccountInfo());
            System.out.println("  " + account2.getAccountInfo());
            
            // Test transfer with insufficient funds
            try {
                account2.transfer(account1, 1000.0);
            } catch (InsufficientFundsException e) {
                System.out.println("✓ Caught InsufficientFundsException: " + e.getMessage());
            }
            
            // Test transfer to null account
            try {
                account1.transfer(null, 100.0);
            } catch (AccountNotFoundException e) {
                System.out.println("✓ Caught AccountNotFoundException: " + e.getMessage());
            }
            
        } catch (Exception e) {
            System.out.println("Error in transfer testing: " + e.getMessage());
        }
    }
}
```

## Expected Output

```
=== Bank Account System Test ===

=== Testing Account Creation ===
✓ Account created successfully: Account: ACC12345678, Holder: John Doe, Balance: $1000.00
✓ Caught InvalidAccountException: Invalid account number: INVALID123. Account number must be 8 digits and start with 'ACC'.
✓ Caught InvalidAmountException: Invalid amount for initial balance: $-100.00. Amount must be positive.

=== Testing Banking Operations ===
✓ Deposit successful. Balance: $2500.00
✓ Withdrawal successful. Balance: $2200.00
✓ Transaction history:
  - Account opened with initial balance: $2000.0
  - Deposited: $500.0, New balance: $2500.0
  - Withdrew: $300.0, New balance: $2200.0

=== Testing Exception Handling ===
✓ Caught InsufficientFundsException: Insufficient funds. Balance: $100.00, Requested: $200.00
✓ Caught InvalidAmountException: Invalid amount for deposit: $-50.00. Amount must be positive.
✓ Caught InvalidAmountException: Invalid amount for withdrawal: $0.00. Amount must be positive.

=== Testing Transfer Operations ===
✓ Transfer successful
  Account: ACC33333333, Holder: David Wilson, Balance: $1300.00
  Account: ACC44444444, Holder: Emma Davis, Balance: $1000.00
✓ Caught InsufficientFundsException: Insufficient funds. Balance: $1000.00, Requested: $1000.00
✓ Caught AccountNotFoundException: Account not found: null
```

## Bonus Challenges

### 1. Interactive Banking System
Create an interactive banking system with a menu:

```java
import java.util.Scanner;

public class InteractiveBankingSystem {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        BankAccount currentAccount = null;
        
        while (true) {
            System.out.println("\n=== Banking System Menu ===");
            System.out.println("1. Create Account");
            System.out.println("2. Deposit");
            System.out.println("3. Withdraw");
            System.out.println("4. Transfer");
            System.out.println("5. View Balance");
            System.out.println("6. View Transaction History");
            System.out.println("7. Quit");
            System.out.print("Choose an option: ");
            
            try {
                int choice = scanner.nextInt();
                scanner.nextLine(); // Consume newline
                
                switch (choice) {
                    case 1:
                        currentAccount = handleCreateAccount(scanner);
                        break;
                    case 2:
                        handleDeposit(currentAccount, scanner);
                        break;
                    // ... other cases
                    case 7:
                        System.out.println("Thank you for using our banking system!");
                        return;
                    default:
                        System.out.println("Invalid option. Please try again.");
                }
            } catch (Exception e) {
                System.out.println("Error: " + e.getMessage());
                scanner.nextLine(); // Clear invalid input
            }
        }
        
        scanner.close();
    }
    
    private static BankAccount handleCreateAccount(Scanner scanner) {
        try {
            System.out.print("Enter account number (ACC + 8 digits): ");
            String accountNumber = scanner.nextLine();
            
            System.out.print("Enter account holder name: ");
            String accountHolder = scanner.nextLine();
            
            System.out.print("Enter initial balance: ");
            double initialBalance = scanner.nextDouble();
            scanner.nextLine(); // Consume newline
            
            BankAccount account = new BankAccount(accountNumber, accountHolder, initialBalance);
            System.out.println("Account created successfully!");
            return account;
            
        } catch (Exception e) {
            System.out.println("Error creating account: " + e.getMessage());
            return null;
        }
    }
    
    // ... other handler methods
}
```

### 2. Account Manager System
Create a system that manages multiple accounts:

```java
import java.util.HashMap;
import java.util.Map;

public class AccountManager {
    private Map<String, BankAccount> accounts;
    
    public AccountManager() {
        this.accounts = new HashMap<>();
    }
    
    public void addAccount(BankAccount account) throws InvalidAccountException {
        if (accounts.containsKey(account.getAccountNumber())) {
            throw new InvalidAccountException("Account already exists: " + account.getAccountNumber());
        }
        accounts.put(account.getAccountNumber(), account);
    }
    
    public BankAccount findAccount(String accountNumber) throws AccountNotFoundException {
        BankAccount account = accounts.get(accountNumber);
        if (account == null) {
            throw new AccountNotFoundException(accountNumber);
        }
        return account;
    }
    
    public void transferBetweenAccounts(String fromAccountNumber, String toAccountNumber, double amount) 
            throws AccountNotFoundException, InsufficientFundsException, InvalidAmountException, 
                   TransactionLimitExceededException {
        
        BankAccount fromAccount = findAccount(fromAccountNumber);
        BankAccount toAccount = findAccount(toAccountNumber);
        
        fromAccount.transfer(toAccount, amount);
    }
}
```

### 3. Enhanced Transaction History
Add more detailed transaction tracking with timestamps and transaction IDs.

## Learning Objectives

After completing this exercise, you should be able to:

1. **Create custom exception classes** for specific business logic errors
2. **Implement comprehensive input validation** with meaningful error messages
3. **Handle multiple exception types** in a single application
4. **Design robust business logic** with proper error handling
5. **Use exception propagation** effectively in complex operations
6. **Create user-friendly error messages** that help users understand problems
7. **Implement transaction tracking** and business rule enforcement
8. **Test exception handling thoroughly** with various scenarios

## Tips

- **Validate all inputs early** to prevent invalid operations
- **Use specific exception types** for different error conditions
- **Include relevant data in exception messages** (amounts, account numbers, etc.)
- **Implement business rules** (transaction limits, minimum balances, etc.)
- **Test edge cases** thoroughly (zero amounts, maximum amounts, etc.)
- **Consider security implications** when handling financial data
- **Use meaningful variable names** and method names for clarity

Good luck with your banking system implementation!

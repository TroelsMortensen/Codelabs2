# The `final` Keyword

## What is the `final` Keyword?

The `final` keyword in Java is used to restrict certain behaviors. It can be applied to:

1. **Classes** - Prevents inheritance
2. **Methods** - Prevents method overriding
3. **Variables** - Prevents reassignment (creates constants)

Think of `final` as a "lock" - once something is marked as `final`, it cannot be changed or extended.

## `final` Classes - Preventing Inheritance

### Basic Syntax
```java
final class MyClass {
    // This class cannot be extended
}
```

### Example: Immutable Class
```java
final class Person {
    private final String name;
    private final int age;
    
    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }
    
    public String getName() {
        return name;
    }
    
    public int getAge() {
        return age;
    }
    
    @Override
    public String toString() {
        return "Person{name='" + name + "', age=" + age + "}";
    }
}

// This will cause a compilation error
// class Student extends Person {  // ❌ ERROR! Cannot extend final class
//     // ...
// }
```

### Real-World Example: String Class
```java
// The String class in Java is final
// This is why you cannot extend String
// class MyString extends String {  // ❌ ERROR!
//     // ...
// }
```

## `final` Methods - Preventing Overriding

### Basic Syntax
```java
class Parent {
    public final void method() {
        // This method cannot be overridden
    }
}
```

### Example: Critical Method
```java
class BankAccount {
    protected double balance;
    protected String accountNumber;
    
    public BankAccount(String accountNumber, double initialBalance) {
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
    }
    
    // This method should never be overridden
    public final void validateAccount() {
        if (accountNumber == null || accountNumber.isEmpty()) {
            throw new IllegalArgumentException("Invalid account number");
        }
        if (balance < 0) {
            throw new IllegalArgumentException("Balance cannot be negative");
        }
    }
    
    // This method can be overridden
    public void withdraw(double amount) {
        validateAccount();  // Always call validation
        if (amount > 0 && amount <= balance) {
            balance -= amount;
        } else {
            throw new IllegalArgumentException("Invalid withdrawal amount");
        }
    }
    
    public double getBalance() {
        return balance;
    }
}

class SavingsAccount extends BankAccount {
    private double interestRate;
    
    public SavingsAccount(String accountNumber, double initialBalance, double interestRate) {
        super(accountNumber, initialBalance);
        this.interestRate = interestRate;
    }
    
    // This method can be overridden
    @Override
    public void withdraw(double amount) {
        validateAccount();  // Still calls the final method
        if (amount > 0 && amount <= balance) {
            balance -= amount;
            System.out.println("Withdrawal from savings account");
        } else {
            throw new IllegalArgumentException("Invalid withdrawal amount");
        }
    }
    
    // This will cause a compilation error
    // @Override
    // public final void validateAccount() {  // ❌ ERROR! Cannot override final method
    //     // ...
    // }
}
```

## `final` Variables - Creating Constants

### Basic Syntax
```java
final int MAX_SIZE = 100;
final String COMPANY_NAME = "MyCompany";
```

### Example: Configuration Constants
```java
class GameConfig {
    // Constants for game configuration
    public static final int MAX_PLAYERS = 4;
    public static final int MIN_PLAYERS = 1;
    public static final String GAME_VERSION = "1.0.0";
    public static final double GRAVITY = 9.81;
    
    // Instance constants
    private final String playerName;
    private final int playerId;
    
    public GameConfig(String playerName, int playerId) {
        this.playerName = playerName;
        this.playerId = playerId;
    }
    
    public String getPlayerName() {
        return playerName;
    }
    
    public int getPlayerId() {
        return playerId;
    }
}
```

## Complete Example: Game System

### Base Game Class with Final Methods
```java
abstract class Game {
    protected final String gameName;
    protected final int maxPlayers;
    protected boolean isRunning;
    
    public Game(String gameName, int maxPlayers) {
        this.gameName = gameName;
        this.maxPlayers = maxPlayers;
        this.isRunning = false;
    }
    
    // Final method - cannot be overridden
    public final void startGame() {
        if (isRunning) {
            throw new IllegalStateException("Game is already running");
        }
        isRunning = true;
        System.out.println("Starting " + gameName + " for up to " + maxPlayers + " players");
        initializeGame();
    }
    
    // Final method - cannot be overridden
    public final void endGame() {
        if (!isRunning) {
            throw new IllegalStateException("Game is not running");
        }
        isRunning = false;
        System.out.println("Ending " + gameName);
        cleanupGame();
    }
    
    // Abstract methods - must be implemented
    protected abstract void initializeGame();
    protected abstract void cleanupGame();
    public abstract void playTurn();
    
    // Regular method - can be overridden
    public void pauseGame() {
        System.out.println("Game paused");
    }
    
    public boolean isRunning() {
        return isRunning;
    }
}

class Chess extends Game {
    private String[][] board;
    private String currentPlayer;
    
    public Chess() {
        super("Chess", 2);
        this.board = new String[8][8];
        this.currentPlayer = "White";
    }
    
    @Override
    protected void initializeGame() {
        // Initialize chess board
        System.out.println("Setting up chess board");
        // ... board setup code
    }
    
    @Override
    protected void cleanupGame() {
        // Clean up chess game
        System.out.println("Cleaning up chess game");
        // ... cleanup code
    }
    
    @Override
    public void playTurn() {
        System.out.println(currentPlayer + " player's turn");
        // ... chess move logic
    }
    
    // This method can be overridden
    @Override
    public void pauseGame() {
        System.out.println("Chess game paused - saving current position");
    }
    
    // This will cause a compilation error
    // @Override
    // public final void startGame() {  // ❌ ERROR! Cannot override final method
    //     // ...
    // }
}

// Final class - cannot be extended
final class TicTacToe extends Game {
    private char[][] board;
    private char currentPlayer;
    
    public TicTacToe() {
        super("Tic-Tac-Toe", 2);
        this.board = new char[3][3];
        this.currentPlayer = 'X';
    }
    
    @Override
    protected void initializeGame() {
        System.out.println("Setting up 3x3 grid");
        // ... board setup code
    }
    
    @Override
    protected void cleanupGame() {
        System.out.println("Cleaning up tic-tac-toe game");
        // ... cleanup code
    }
    
    @Override
    public void playTurn() {
        System.out.println("Player " + currentPlayer + "'s turn");
        // ... tic-tac-toe move logic
    }
}

// This will cause a compilation error
// class AdvancedTicTacToe extends TicTacToe {  // ❌ ERROR! Cannot extend final class
//     // ...
// }
```

## When to Use `final`

### ✅ Use `final` for Classes When:
- **Security** - Preventing malicious subclassing
- **Immutability** - Ensuring class cannot be modified
- **API Design** - Preventing breaking changes
- **Performance** - Allowing compiler optimizations

### ✅ Use `final` for Methods When:
- **Critical Logic** - Methods that must never be changed
- **Security** - Preventing method tampering
- **API Stability** - Ensuring consistent behavior
- **Template Methods** - Part of a fixed algorithm

### ✅ Use `final` for Variables When:
- **Constants** - Values that never change
- **Configuration** - Settings that should be immutable
- **Performance** - Compiler optimizations
- **Thread Safety** - Immutable values are thread-safe

## Common Patterns with `final`

### 1. **Builder Pattern with Final Fields**
```java
public class Person {
    private final String name;
    private final int age;
    private final String email;
    
    private Person(Builder builder) {
        this.name = builder.name;
        this.age = builder.age;
        this.email = builder.email;
    }
    
    public static class Builder {
        private String name;
        private int age;
        private String email;
        
        public Builder setName(String name) {
            this.name = name;
            return this;
        }
        
        public Builder setAge(int age) {
            this.age = age;
            return this;
        }
        
        public Builder setEmail(String email) {
            this.email = email;
            return this;
        }
        
        public Person build() {
            return new Person(this);
        }
    }
}
```

### 2. **Constants Class**
```java
public final class Constants {
    private Constants() {}  // Prevent instantiation
    
    public static final String APP_NAME = "MyApp";
    public static final String VERSION = "1.0.0";
    public static final int MAX_RETRIES = 3;
    public static final double PI = 3.14159;
}
```

### 3. **Immutable Data Class**
```java
public final class Point {
    private final double x;
    private final double y;
    
    public Point(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    public double getX() {
        return x;
    }
    
    public double getY() {
        return y;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        Point point = (Point) obj;
        return Double.compare(point.x, x) == 0 && Double.compare(point.y, y) == 0;
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(x, y);
    }
}
```

## Summary

The `final` keyword is a powerful tool for:

- **Preventing inheritance** with final classes
- **Preventing method overriding** with final methods
- **Creating constants** with final variables
- **Improving security** and preventing tampering
- **Enabling compiler optimizations**

Use `final` judiciously to create more secure, stable, and maintainable code. It's particularly useful when designing APIs or creating immutable objects.

In the next article, we'll explore how to properly implement the `equals` method in inheritance hierarchies.

# Example 1 - Transaction Processing

Let's see a complete example of transforming a mountain into islands using a transaction processing scenario.

## The Mountain (Violation)

Here's a method that processes a list of transactions. Notice the deep nesting and "Arrow Code" shape:

```java
public void processTransactions(List<Transaction> transactions) {
    if (transactions != null) {                                 // Base Camp (Level 0)
        for (Transaction t : transactions) {                    // 1000 meters (Level 1)
            if (t.getStatus() == Status.PENDING) {              // 2000 meters (Level 2)
                if (t.getAmount() > 0) {                        // 3000 meters (Level 3)
                    try {                                       // 4000 meters (Level 4)
                        if (bank.isOpen()) {                    // The Peak 🚩 (Level 5)
                            bank.transfer(t);
                        }
                    } catch (Exception e) {
                        log.error(e);
                    }
                }
            }
        }
    }
}
```

## The Islands (Solution)

Now let's break this mountain into flat, accessible islands:

```java
// Island 1: The Coordinator
public void processTransactions(List<Transaction> transactions) {
    if (transactions == null) return; // Keep it flat - early return
    
    for (Transaction t : transactions) {
        processSingleTransaction(t);
    }
}

// Island 2: The Logic Gate
private void processSingleTransaction(Transaction t) {
    if (t.getStatus() != Status.PENDING) return; // Guard clause
    if (t.getAmount() <= 0) return;              // Guard clause
    
    executeTransfer(t);
}

// Island 3: The Dangerous Work
private void executeTransfer(Transaction t) {
    try {
        if (bank.isOpen()) {
            bank.transfer(t);
        }
    } catch (Exception e) {
        log.error(e);
    }
}
```

### Benefits of This Refactoring

1. **Flat structure** - Maximum 2 levels of nesting
2. **Clear separation** - Each method has one responsibility
3. **Easy to read** - Can understand each island independently
4. **Easy to test** - Can test each method separately
5. **Easy to maintain** - Changes are isolated to specific islands

## Step-by-Step Refactoring

### Step 1: Extract the Null Check

**Before:**
```java
if (transactions != null) {
    // rest of code
}
```

**After:**
```java
if (transactions == null) return; // Early return - flattens structure
// rest of code
```

This eliminates one level of nesting immediately.

### Step 2: Extract the Transaction Processing

**Before:**
```java
for (Transaction t : transactions) {
    if (t.getStatus() == Status.PENDING) {
        // nested logic
    }
}
```

**After:**
```java
for (Transaction t : transactions) {
    processSingleTransaction(t); // Extract to separate method
}
```

This separates iteration from processing logic.

### Step 3: Use Guard Clauses

**Before:**
```java
if (t.getStatus() == Status.PENDING) {
    if (t.getAmount() > 0) {
        // process
    }
}
```

**After:**
```java
if (t.getStatus() != Status.PENDING) return; // Guard clause
if (t.getAmount() <= 0) return;              // Guard clause
// process - now flat
```

This flattens nested conditions using early returns.

### Step 4: Extract the Transfer Logic

**Before:**
```java
try {
    if (bank.isOpen()) {
        bank.transfer(t);
    }
} catch (Exception e) {
    log.error(e);
}
```

**After:**
```java
// Extracted to separate method
private void executeTransfer(Transaction t) {
    try {
        if (bank.isOpen()) {
            bank.transfer(t);
        }
    } catch (Exception e) {
        log.error(e);
    }
}
```

This isolates the risky operation (bank transfer) in its own method.

## Comparison

### Before (Mountain)
- **Nesting levels:** 5
- **Method length:** Long, hard to see all at once
- **Responsibilities:** Multiple (validation, iteration, processing, error handling)
- **Testability:** Hard - need to set up all conditions
- **Readability:** Poor - must track all nested conditions
- **Maintainability:** Poor - changes affect entire structure

### After (Islands)
- **Nesting levels:** 2 maximum
- **Method length:** Short, easy to see all at once
- **Responsibilities:** Single per method
- **Testability:** Easy - can test each method independently
- **Readability:** Excellent - each method is clear and focused
- **Maintainability:** Excellent - changes are isolated

## The Swim

With the island version, you:
1. **Start at Island 1** - See that we process each transaction
2. **Swim to Island 2** - See the validation logic (guard clauses)
3. **Swim to Island 3** - See the actual transfer execution
4. **Done** - Easy navigation, no mental climbing


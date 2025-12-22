# Example 2 - User Validation

Let's see another example of transforming a mountain into islands, this time with user validation logic.

## The Mountain (Violation)

Here's a method that validates and registers a new user. Notice the deep nesting with multiple validation checks:

```java
public void registerUser(String username, String email, String password) {
    if (username != null) {                                    // Base Camp (Level 0)
        if (email != null) {                                  // 1000 meters (Level 1)
            if (password != null) {                           // 2000 meters (Level 2)
                if (username.length() >= 3) {                  // 3000 meters (Level 3)
                    if (email.contains("@")) {                // 4000 meters (Level 4)
                        if (password.length() >= 8) {        // 5000 meters (Level 5)
                            if (!userRepository.exists(username)) { // 6000 meters (Level 6)
                                if (!userRepository.emailExists(email)) { // The Peak 🚩 (Level 7)
                                    User user = new User(username, email, password);
                                    userRepository.save(user);
                                    emailService.sendWelcomeEmail(user);
                                } else {
                                    throw new EmailAlreadyExistsException();
                                }
                            } else {
                                throw new UsernameAlreadyExistsException();
                            }
                        } else {
                            throw new PasswordTooShortException();
                        }
                    } else {
                        throw new InvalidEmailException();
                    }
                } else {
                    throw new UsernameTooShortException();
                }
            } else {
                throw new PasswordRequiredException();
            }
        } else {
            throw new EmailRequiredException();
        }
    } else {
        throw new UsernameRequiredException();
    }
}
```

## The Islands (Solution)

Now let's break this mountain into flat, accessible islands:

```java
// Island 1: The Coordinator
public void registerUser(String username, String email, String password) {
    validateInputs(username, email, password);
    validateUserDoesNotExist(username, email);
    
    User user = createUser(username, email, password);
    saveAndNotifyUser(user);
}

// Island 2: Input Validation
private void validateInputs(String username, String email, String password) {
    if (username == null) {
        throw new UsernameRequiredException();
    }
    if (username.length() < 3) {
        throw new UsernameTooShortException();
    }
    
    if (email == null) {
        throw new EmailRequiredException();
    }
    if (!email.contains("@")) {
        throw new InvalidEmailException();
    }
    
    if (password == null) {
        throw new PasswordRequiredException();
    }
    if (password.length() < 8) {
        throw new PasswordTooShortException();
    }
}

// Island 3: Existence Validation
private void validateUserDoesNotExist(String username, String email) {
    if (userRepository.exists(username)) {
        throw new UsernameAlreadyExistsException();
    }
    if (userRepository.emailExists(email)) {
        throw new EmailAlreadyExistsException();
    }
}

// Island 4: User Creation
private User createUser(String username, String email, String password) {
    return new User(username, email, password);
}

// Island 5: Persistence and Notification
private void saveAndNotifyUser(User user) {
    userRepository.save(user);
    emailService.sendWelcomeEmail(user);
}
```

### Benefits of This Refactoring

1. **Flat structure** - Maximum 1-2 levels of nesting
2. **Clear separation** - Each validation is separate
3. **Easy to read** - Can understand each validation independently
4. **Easy to test** - Can test each validation separately
5. **Easy to extend** - Adding new validations is simple
6. **Clear error handling** - Each validation throws its own exception

## Step-by-Step Refactoring

### Step 1: Extract Input Validation

**Before:**
```java
if (username != null) {
    if (email != null) {
        if (password != null) {
            // nested validations
        }
    }
}
```

**After:**
```java
private void validateInputs(String username, String email, String password) {
    if (username == null) {
        throw new UsernameRequiredException();
    }
    // ... other validations - all flat
}
```

This separates input validation into its own method.

### Step 2: Extract Existence Validation

**Before:**
```java
if (!userRepository.exists(username)) {
    if (!userRepository.emailExists(email)) {
        // create user
    }
}
```

**After:**
```java
private void validateUserDoesNotExist(String username, String email) {
    if (userRepository.exists(username)) {
        throw new UsernameAlreadyExistsException();
    }
    if (userRepository.emailExists(email)) {
        throw new EmailAlreadyExistsException();
    }
}
```

This separates existence checks into their own method.

### Step 3: Extract User Creation

**Before:**
```java
User user = new User(username, email, password);
```

**After:**
```java
private User createUser(String username, String email, String password) {
    return new User(username, email, password);
}
```

This isolates user creation (could add more logic here later).

### Step 4: Extract Persistence and Notification

**Before:**
```java
userRepository.save(user);
emailService.sendWelcomeEmail(user);
```

**After:**
```java
private void saveAndNotifyUser(User user) {
    userRepository.save(user);
    emailService.sendWelcomeEmail(user);
}
```

This groups related operations together.

## Comparison

### Before (Mountain)
- **Nesting levels:** 7
- **Method length:** Very long, impossible to see all at once
- **Responsibilities:** Multiple (all validations, creation, persistence, notification)
- **Testability:** Very hard - need to test all combinations
- **Readability:** Very poor - must track 7 nested conditions
- **Maintainability:** Very poor - adding validation increases nesting
- **Error handling:** Scattered throughout nested blocks

### After (Islands)
- **Nesting levels:** 1-2 maximum
- **Method length:** Short, easy to see all at once
- **Responsibilities:** Single per method
- **Testability:** Easy - can test each validation independently
- **Readability:** Excellent - each method is clear and focused
- **Maintainability:** Excellent - adding validation is just adding a method
- **Error handling:** Clear and focused per validation


## Adding New Validations

With the island structure, adding new validations is easy:

```java
// Just add to the appropriate island
private void validateInputs(String username, String email, String password) {
    // ... existing validations
    
    // New validation - just add it here, flat!
    if (!isValidEmailFormat(email)) {
        throw new InvalidEmailFormatException();
    }
}
```

No need to add more nesting - just add to the flat structure!

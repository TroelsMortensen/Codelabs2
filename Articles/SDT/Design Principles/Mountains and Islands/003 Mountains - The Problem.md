# Mountains - The Problem

Let's examine what "mountains" look like in code and understand why they're problematic.

## What Mountains Look Like in Code

A **mountain** is code with deep nesting - multiple levels of indentation that create a tall, jagged structure when viewed from the side.

### Example: The Mountain Shape

```java
public void processData() {                            // Base Camp (Level 0)
    if (data != null) {                                // 1000 meters (Level 1)
        if (data.isValid()) {                          // 2000 meters (Level 2)
            for (Item item : data.getItems()) {        // 3000 meters (Level 3)
                if (item.isActive()) {                 // 4000 meters (Level 4)
                    try {                              // 5000 meters (Level 5)
                        if (processor.isReady()) {     // The Peak 🚩 (Level 6)
                            processor.process(item);   // The actual work
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


## The "Arrow Code" Anti-Pattern

Mountain code often takes the form of **"Arrow Code"** - code that keeps indenting to the right, forming an arrow shape:

```java
public void method() {
    if (condition1) {              // →
        if (condition2) {          //   →
            if (condition3) {      //     →
                if (condition4) {  //       →
                    // logic       //         →
                }                  //       ←
            }                      //     ←
        }                          //   ←
    }                              // ←
}
```

The arrow points right (deeper nesting) and then left (closing braces). This is a clear sign of a mountain.

## Problems Caused by Mountains

### 1. Cognitive Overload

To understand the code at the peak, you must hold the context of **all** the outer levels in your head:

- What is `data`?
- Is `data.isValid()` true?
- What items are we iterating over?
- Is the current item active?
- Is the processor ready?
- What happens if an exception occurs?

This is like climbing a mountain - you must remember everything you passed on the way up.

### 2. Hard to Understand

The deeper you go, the harder it is to see the big picture. You lose track of:
- Why you're at this level
- What conditions led you here
- What the overall purpose is

### 3. Hard to Test

Testing deeply nested code is difficult:
- You must set up all the outer conditions
- You can't easily test the inner logic in isolation
- Test setup becomes complex and error-prone


### 4. Hard to Maintain

Making changes requires:
- Understanding the entire nested structure
- Ensuring all conditions are still correct
- Risk of breaking something at a different level

### 5. Bugs at High Altitudes

**Avalanches (bugs) happen at high altitudes.**

When code is deeply nested:
- It's easy to make mistakes with conditions
- Logic errors are harder to spot
- Edge cases are easily missed
- Debugging requires navigating through all levels

### 6. Violates Single Responsibility

A mountain method typically does too many things:
- Validates input
- Iterates over data
- Filters items
- Handles errors
- Processes items

This violates the Single Responsibility Principle.

## Real-World Example

Here's a common mountain pattern:

```java
public void handleUserRequest(UserRequest request) {
    if (request != null) {
        if (request.isValid()) {
            User user = userRepository.find(request.getUserId());
            if (user != null) {
                if (user.isActive()) {
                    if (user.hasPermission(request.getAction())) {
                        try {
                            if (service.isAvailable()) {
                                service.process(request);
                            } else {
                                throw new ServiceUnavailableException();
                            }
                        } catch (Exception e) {
                            log.error("Error processing request", e);
                            throw new ProcessingException(e);
                        }
                    } else {
                        throw new PermissionDeniedException();
                    }
                } else {
                    throw new UserInactiveException();
                }
            } else {
                throw new UserNotFoundException();
            }
        } else {
            throw new InvalidRequestException();
        }
    } else {
        throw new NullRequestException();
    }
}
```

**Problems:**
- 7 levels of nesting
- Hard to see the happy path
- Error handling is scattered
- Can't easily test individual validations
- Requires understanding all levels to modify


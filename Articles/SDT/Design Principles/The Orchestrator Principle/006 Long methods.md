# Breaking up long methods

Even if code isn't deeply nested (a Mountain), a long, flat method is still a "Wall of Text". Or, maybe like rolling hills. It mixes **High-Level Policy** (what we want to do) with **Low-Level Implementation** (how we do it).

Here is an example of a **User Registration** process.

### 1. The Monolith (Wall of Text)
This method is linear (mostly flat), but it is cognitively heavy. To understand what happens, you have to read every line. You see regex patterns mixed with SQL queries mixed with HTML string concatenation. There are many details to filter through, just to actually get an idea of the overall behaviour.

```java
public class UserRegistrationService {

    public void registerUser(String username, String password, String email) {
        // --- STEP 1: Validation Logic ---
        if (username == null || username.trim().isEmpty()) {
            throw new IllegalArgumentException("Username required");
        }
        if (password.length() < 8) {
            throw new IllegalArgumentException("Password too short");
        }
        if (!email.contains("@") || !email.contains(".")) {
            throw new IllegalArgumentException("Invalid email");
        }

        // --- STEP 2: Security Logic (Hashing) ---
        String salt = "randomSalt123"; // Simplified
        String hashedPassword = new StringBuilder(password)
                                    .append(salt)
                                    .reverse()
                                    .toString(); // Fake hashing algo

        // --- STEP 3: Database Logic ---
        System.out.println("Opening DB Connection...");
        String sql = "INSERT INTO users (name, pass, email) VALUES ('" 
                     + username + "', '" + hashedPassword + "', '" + email + "')";
        System.out.println("Executing: " + sql);
        
        // --- STEP 4: Notification Logic ---
        String emailBody = "<h1>Welcome " + username + "!</h1>";
        emailBody += "<p>Thanks for joining us.</p>";
        
        System.out.println("Connecting to SMTP server...");
        System.out.println("Sending email to " + email + ": " + emailBody);
        
        // --- STEP 5: Audit Logic ---
        System.out.println("Writing to audit.log: User " + username + " registered.");
    }
}
```

### 2. The Orchestrator (Refactored)
Here, the `registerUser` method becomes the **Orchestrator**. It contains almost no logic itself; it simply directs the traffic.

Notice how this is **Orchestration, not Chaining**:
*   `validateInput` does **not** call `hashPassword`.
*   `saveToDatabase` does **not** call `sendWelcomeEmail`.
*   The Orchestrator passes the result of one step into the next.

```java
public class UserRegistrationService {

    // ✅ THE ORCHESTRATOR
    // This reads like a Table of Contents. 
    // You know exactly what this method does in 5 seconds.
    public void registerUser(String username, String password, String email) {
        
        // 1. Validate
        validateInput(username, password, email);

        // 2. Secure
        String hashedPassword = hashPassword(password);

        // 3. Persist
        User user = new User(username, hashedPassword, email);
        saveToDatabase(user);

        // 4. Notify
        sendWelcomeEmail(user);

        // 5. Audit
        logAudit(user);
    }

    // --- The Helpers (The "Spokes") ---
    // These contain the low-level details. 
    // They are small, focused, and easy to test in isolation.

    private void validateInput(String username, String password, String email) {
        if (username == null || username.trim().isEmpty()) 
            throw new IllegalArgumentException("Username required");
        if (password.length() < 8) 
            throw new IllegalArgumentException("Password too short");
        if (!email.contains("@")) 
            throw new IllegalArgumentException("Invalid email");
    }

    private String hashPassword(String password) {
        // The implementation details are hidden here.
        // If we change hashing algorithms, the Orchestrator doesn't care.
        return new StringBuilder(password).append("salt").reverse().toString();
    }

    private void saveToDatabase(User user) {
        System.out.println("INSERT INTO users VALUES (" + user.getName() + "...)");
    }

    private void sendWelcomeEmail(User user) {
        System.out.println("Sending Welcome Email to " + user.getEmail());
    }

    private void logAudit(User user) {
        System.out.println("Audit: User registered -> " + user.getName());
    }
}
```

### Why this is better
1.  **Single Level of Abstraction:** The Orchestrator speaks in high-level concepts ("Validate", "Save", "Notify"). It doesn't speak in low-level concepts ("Regex", "SQL", "SMTP").
2.  **Decoupling:** If you want to stop sending emails, you just comment out `sendWelcomeEmail(user)` in the orchestrator. In a "Chained" system, removing the email step might break the method that called it.
3.  **Readability:** You don't have to look at the bottom of the file to understand the flow of the top of the file.
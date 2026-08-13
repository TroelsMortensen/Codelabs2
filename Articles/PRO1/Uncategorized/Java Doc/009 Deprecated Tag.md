# The @deprecated Tag

Sometimes you need to keep old code for backward compatibility while guiding users toward better alternatives. The `@deprecated` tag marks code that should no longer be used.

## What Does Deprecated Mean?

**Deprecated** means:
- The code still works but is discouraged
- It may be removed in a future version
- There's usually a better alternative available
- Users should migrate to the recommended replacement

## Basic @deprecated Syntax

```java
/**
 * Calculates the area of a circle.
 * 
 * @param radius the radius of the circle
 * @return the area
 * @deprecated Use {@link #calculateCircleArea(double)} instead.
 *             This method will be removed in version 3.0.
 */
@Deprecated
public double getArea(double radius) {
    return Math.PI * radius * radius;
}
```

**Note:** Always use both:
1. `@deprecated` JavaDoc tag - for documentation
2. `@Deprecated` annotation - for compiler warnings

## When to Deprecate Code

### Poor Design
When you realize a method was poorly designed:

```java
/**
 * Gets customer data as a comma-separated string.
 * 
 * @return customer data
 * @deprecated This method returns inconsistent format. Use
 *             {@link #getCustomer()} instead to get a Customer
 *             object with proper getters.
 */
@Deprecated
public String getCustomerData() {
    return name + "," + age + "," + email;
}

/**
 * Returns the customer object with all data.
 * 
 * @return the customer
 */
public Customer getCustomer() {
    return new Customer(name, age, email);
}
```

### Better Alternative Available
When you've created a better version:

```java
/**
 * Searches for products by keyword.
 * 
 * @param keyword the search term
 * @return list of matching products
 * @deprecated Use {@link #searchProducts(SearchCriteria)} for more
 *             flexible searching with filters and sorting options.
 */
@Deprecated
public List<Product> search(String keyword) {
    // old implementation
}

/**
 * Searches for products using advanced criteria.
 * 
 * @param criteria the search criteria with filters and options
 * @return list of matching products
 */
public List<Product> searchProducts(SearchCriteria criteria) {
    // new implementation
}
```

### API Consolidation
When consolidating multiple methods into one:

```java
/**
 * Sets the customer's first name.
 * 
 * @param firstName the first name
 * @deprecated Use {@link #setName(String, String)} instead to set
 *             both first and last name together.
 */
@Deprecated
public void setFirstName(String firstName) {
    this.firstName = firstName;
}

/**
 * Sets the customer's last name.
 * 
 * @param lastName the last name
 * @deprecated Use {@link #setName(String, String)} instead to set
 *             both first and last name together.
 */
@Deprecated
public void setLastName(String lastName) {
    this.lastName = lastName;
}

/**
 * Sets the customer's full name.
 * 
 * @param firstName the first name
 * @param lastName the last name
 */
public void setName(String firstName, String lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
}
```

### Security or Safety Issues
When a method has security or safety concerns:

```java
/**
 * Stores the password as plain text.
 * 
 * @param password the password
 * @deprecated This method stores passwords in plain text, which is
 *             a security risk. Use {@link #setPassword(String)} which
 *             automatically hashes the password.
 */
@Deprecated
public void setPlainTextPassword(String password) {
    this.password = password;
}

/**
 * Sets the password with automatic hashing.
 * 
 * @param password the password in plain text (will be hashed)
 */
public void setPassword(String password) {
    this.passwordHash = BCrypt.hashpw(password, BCrypt.gensalt());
}
```

## How to Write Good @deprecated Documentation

### Always Explain Why

**Bad:**
```java
/**
 * @deprecated Don't use this.
 */
@Deprecated
public void oldMethod() {
    // implementation
}
```

**Good:**
```java
/**
 * @deprecated This method uses blocking I/O which causes performance
 *             issues. Use {@link #processAsync()} instead.
 */
@Deprecated
public void process() {
    // implementation
}
```

### Always Provide an Alternative

**Bad:**
```java
/**
 * @deprecated This method is deprecated.
 */
@Deprecated
public void calculate() {
    // implementation
}
```

**Good:**
```java
/**
 * @deprecated This method uses outdated calculation formula. Use
 *             {@link #calculateV2()} which implements the corrected
 *             algorithm.
 */
@Deprecated
public void calculate() {
    // implementation
}
```

### Specify When It Will Be Removed (If Known)

```java
/**
 * Processes payment using old API.
 * 
 * @param amount the payment amount
 * @deprecated The old payment API is being phased out. Use
 *             {@link #processPaymentV2(PaymentRequest)} instead.
 *             This method will be removed in version 4.0.
 */
@Deprecated
public void processPayment(double amount) {
    // implementation
}
```

## @Deprecated Annotation vs @deprecated Tag

### @deprecated Tag (JavaDoc)
- Goes in the JavaDoc comment
- Provides explanation and alternative
- Shows up in generated documentation
- For humans to read

### @Deprecated Annotation
- Goes before the method/class
- Causes compiler warnings
- Enables IDE warnings
- For tools to detect

### Always Use Both

```java
/**
 * Old authentication method.
 * 
 * @param username the username
 * @param password the password
 * @return true if authenticated
 * @deprecated Use {@link #authenticate(Credentials)} instead for
 *             more secure authentication with encryption.
 */
@Deprecated
public boolean login(String username, String password) {
    // implementation
}
```

## Compiler and IDE Behavior

When code is marked as deprecated:

### Compiler Warning
```
Note: SomeClass.java uses or overrides a deprecated API.
Note: Recompile with -Xlint:deprecation for details.
```

### IDE Warning
- IntelliJ IDEA: Strike-through text and warning tooltip
- Eclipse: Warning marker and strike-through

### Usage Example
```java
// This will generate a warning:
account.oldMethod(); // ← IDE shows strike-through
```

## Deprecating Classes

You can deprecate entire classes:

```java
/**
 * Legacy data access layer.
 * <p>
 * This class uses direct JDBC calls and is difficult to maintain.
 * 
 * @deprecated This entire class is deprecated. Use the new
 *             {@link com.example.repository.CustomerRepository}
 *             with JPA for database access. This class will be
 *             removed in version 5.0.
 */
@Deprecated
public class CustomerDAO {
    // implementation
}
```

## Deprecating Constructors

```java
public class Configuration {
    
    /**
     * Creates configuration from properties file.
     * 
     * @param filename the properties file path
     * @deprecated This constructor doesn't support environment-specific
     *             configurations. Use {@link #Configuration(String, String)}
     *             with environment parameter.
     */
    @Deprecated
    public Configuration(String filename) {
        // old implementation
    }
    
    /**
     * Creates configuration from properties file for specific environment.
     * 
     * @param filename the properties file path
     * @param environment the environment (dev, test, prod)
     */
    public Configuration(String filename, String environment) {
        // new implementation
    }
}
```

## Complete Example

```java
public class MathUtils {
    
    /**
     * Calculates the power using iterative multiplication.
     * <p>
     * This implementation is slow for large exponents and doesn't
     * handle negative exponents correctly.
     * 
     * @param base the base number
     * @param exponent the exponent (must be positive)
     * @return base raised to the exponent
     * @deprecated This method has limitations with negative exponents and
     *             poor performance. Use {@link Math#pow(double, double)}
     *             instead. This method will be removed in version 3.0.
     */
    @Deprecated
    public static double power(double base, int exponent) {
        double result = 1;
        for (int i = 0; i < exponent; i++) {
            result *= base;
        }
        return result;
    }
    
    /**
     * Calculates square root using Newton's method.
     * 
     * @param number the number to find square root of
     * @return the square root
     * @deprecated This custom implementation is less accurate than the
     *             standard library. Use {@link Math#sqrt(double)} instead.
     *             This method will be removed in version 3.0.
     */
    @Deprecated
    public static double squareRoot(double number) {
        // custom Newton's method implementation
        return 0.0; // simplified
    }
}
```

## Best Practices for Deprecation

1. ✅ Always explain **why** it's deprecated
2. ✅ Always provide an **alternative** or migration path
3. ✅ Use both `@deprecated` tag and `@Deprecated` annotation
4. ✅ Specify when it will be **removed** (if known)
5. ✅ Keep the deprecated code **working** until it's removed
6. ✅ Give users **time to migrate** (multiple versions if possible)
7. ✅ Update **documentation** to guide users to new methods
8. ✅ Consider providing **migration examples** for complex changes

Deprecation is about being kind to your users - give them clear guidance and time to update their code!


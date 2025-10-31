# Using HTML in JavaDoc

Since JavaDoc generates HTML documentation, you can use HTML tags directly in your JavaDoc comments to format the output. This is especially useful for complex formatting, lists, and code examples.

## Common HTML Tags

### Paragraphs - `<p>`

Use `<p>` to create paragraph breaks in longer descriptions:

```java
/**
 * Processes a customer order in the system.
 * <p>
 * This method validates the order, checks inventory availability,
 * calculates pricing, and creates the order record.
 * <p>
 * If any validation fails, the order is rejected and an exception
 * is thrown. No partial orders are created.
 * 
 * @param order the order to process
 * @return the processed order with assigned order number
 */
public Order processOrder(Order order) {
    // implementation
}
```

### Lists - `<ul>`, `<ol>`, `<li>`

Use HTML lists for enumerating items:

**Unordered list:**
```java
/**
 * Calculates employee salary with bonuses.
 * <p>
 * The following bonuses are applied:
 * <ul>
 *   <li>5% for employees with 5+ years of service</li>
 *   <li>10% for employees with 10+ years of service</li>
 *   <li>3% for employees with perfect attendance</li>
 *   <li>2% for employees with certifications</li>
 * </ul>
 * 
 * @param employee the employee to calculate salary for
 * @return the total salary including all applicable bonuses
 */
public double calculateSalary(Employee employee) {
    // implementation
}
```

**Ordered list:**
```java
/**
 * Registers a new user in the system.
 * <p>
 * The registration process follows these steps:
 * <ol>
 *   <li>Validate email format and uniqueness</li>
 *   <li>Hash the password using bcrypt</li>
 *   <li>Create user record in database</li>
 *   <li>Send verification email</li>
 *   <li>Return the user object</li>
 * </ol>
 * 
 * @param email the user's email address
 * @param password the password in plain text
 * @return the newly created user
 * @throws DuplicateEmailException if email already exists
 */
public User registerUser(String email, String password) 
        throws DuplicateEmailException {
    // implementation
}
```


### Code - `<code>` and `<pre>`

Use `<code>` for inline code references:

```java
/**
 * Parses a date string in ISO format.
 * <p>
 * The expected format is <code>YYYY-MM-DD</code>, for example
 * <code>2024-03-15</code>. Invalid formats will throw an exception.
 * 
 * @param dateString the date string to parse
 * @return the parsed date
 * @throws IllegalArgumentException if format is invalid
 */
public LocalDate parseDate(String dateString) {
    // implementation
}
```


### Line Breaks - `<br>`

Use `<br>` for line breaks within a paragraph:

```java
/**
 * Returns contact information for the customer.
 * <p>
 * Format:<br>
 * Line 1: Full Name<br>
 * Line 2: Street Address<br>
 * Line 3: City, State, ZIP<br>
 * Line 4: Phone Number
 * 
 * @param customerId the customer's ID
 * @return formatted contact information
 */
public String getContactInfo(int customerId) {
    // implementation
}
```

## HTML Best Practices

### Keep It Simple
Don't overuse HTML formatting. Your JavaDoc should be readable in the source code, not just in the generated HTML.

**Good - Simple and clear:**
```java
/**
 * Validates a password meets security requirements.
 * <p>
 * Requirements:
 * <ul>
 *   <li>At least 8 characters</li>
 *   <li>Contains uppercase and lowercase letters</li>
 *   <li>Contains at least one digit</li>
 * </ul>
 */
```

**Bad - Too much formatting:**
```java
/**
 * <div style="color: blue; font-weight: bold;">
 * Validates a password meets security requirements.
 * </div>
 * <table border="1">
 *   <tr><td><b>Min Length</b></td><td>8 characters</td></tr>
 * </table>
 */
```

### Escape Special Characters
If you need to show HTML characters literally, escape them:
- `&lt;` for `<`
- `&gt;` for `>`
- `&amp;` for `&`

```java
/**
 * Compares two values.
 * <p>
 * Returns true if value1 &lt; value2, false otherwise.
 * 
 * @param value1 the first value
 * @param value2 the second value
 * @return true if value1 is less than value2
 */
public boolean isLessThan(int value1, int value2) {
    return value1 < value2;
}
```

### Prefer Semantic HTML
Use tags that convey meaning:
- Use `<em>` (emphasis) instead of `<i>` (italic) when you mean to emphasize
- Use `<strong>` (strong importance) instead of `<b>` (bold) when you mean strong emphasis
- Use `<code>` for code, not just any monospace text

## Complete Example

```java
/**
 * Searches for products matching the given criteria.
 * <p>
 * This method supports multiple search strategies:
 * <ul>
 *   <li><b>Keyword search:</b> Searches in product name and description</li>
 *   <li><b>Category filter:</b> Limits results to specific category</li>
 *   <li><b>Price range:</b> Filters by minimum and maximum price</li>
 * </ul>
 * <p>
 * Example usage:
 * <pre><code>
 * SearchCriteria criteria = new SearchCriteria();
 * criteria.setKeyword("laptop");
 * criteria.setMinPrice(500.0);
 * criteria.setMaxPrice(1500.0);
 * List&lt;Product&gt; results = searchProducts(criteria);
 * </code></pre>
 * <p>
 * <i>Performance note:</i> This method uses database indexing and
 * typically returns results in under 100ms for datasets up to 1 million
 * products.
 * 
 * @param criteria the search criteria
 * @return list of matching products, sorted by relevance
 * @throws IllegalArgumentException if criteria is null
 */
public List<Product> searchProducts(SearchCriteria criteria) {
    // implementation
}
```

## When to Use HTML vs Plain Text

Use **plain text** for:
- Simple, short descriptions
- Basic parameter and return descriptions
- Most everyday documentation

Use **HTML** when you need:
- Lists of items or steps
- Code examples
- Multiple paragraphs with clear separation
- Emphasis on warnings or important notes
- Structured formatting that improves readability

Remember: The goal is clear communication, not fancy formatting.


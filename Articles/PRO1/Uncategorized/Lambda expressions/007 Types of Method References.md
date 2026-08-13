# Types of Method References

There are several types of method references in Java, I will show two. Each type uses the `::` operator but in different contexts.

## 1. Static Method Reference

References a static method from a class.

**Syntax:** `ClassName::staticMethodName`

**Example:**

```java
// Lambda version
Function<String, Integer> parser = s -> Integer.parseInt(s);

// Method reference version
Function<String, Integer> parser = Integer::parseInt;

// Usage
int number = parser.apply("42");  // 42
```


## 2. Instance Method Reference (on a specific object)

References an instance method of a specific object.

**Syntax:** `objectName::instanceMethodName`

**Example:**

```java
String prefix = "Hello, ";

// Lambda version
Function<String, String> greeter = name -> prefix.concat(name);

// Method reference version
Function<String, String> greeter = prefix::concat;

// Usage
System.out.println(greeter.apply("Alice"));  // Hello, Alice
```



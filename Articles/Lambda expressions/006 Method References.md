# Method References

Method references are a shorthand notation for lambda expressions that call an existing method. They make your code even more concise and readable.

## What is a Method Reference?

A method reference uses the `::` operator to refer to a method without actually calling it. When the lambda expression only calls a single existing method, you can use a method reference instead.

## The :: Operator

The double colon `::` operator separates the class or object name from the method name.

**Format:** `ClassName::methodName` or `object::methodName`

## When to Use Method References

Use method references when your lambda expression only does one thing: call an existing method.

**Lambda expression:**
```java
Consumer<String> printer = message -> System.out.println(message);
```

**Method reference:**
```java
Consumer<String> printer = System.out::println;
```

Both do exactly the same thing!

IntelliJ will usually suggest converting a lambda expression to a method reference, if it is possible. Pay attention to the yellow squiggly lines, and the suggestion to convert to a method reference.


## Example : Printing List Items

```java
List<String> names = Arrays.asList("Alice", "Bob", "Charlie");
names.forEach(name -> System.out.println(name));
names.forEach(System.out::println);
```


## When NOT to Use Method References

Method references only work when the lambda directly calls a method. If you need to do anything extra, stick with lambda expressions.

**This CAN'T be converted to method reference:**
```java
list.forEach(name -> System.out.println("Name: " + name));  // Adding extra text
list.map(x -> x * 2);  // Performing calculation
list.filter(n -> n > 10);  // Using operator
```

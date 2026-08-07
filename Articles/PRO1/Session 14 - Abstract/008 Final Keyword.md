# The `final` Keyword

You have seen `final` before. Last time, we used it to create constants:

```java
final int MAX_SIZE = 100;
```

This meant the variable `MAX_SIZE` could not be changed after it was declared. The following code would cause a compilation error:

```java
MAX_SIZE = 200;
```

```
error: cannot assign a value to final variable MAX_SIZE
MAX_SIZE = 200;
```

But, `final` can also be used to prevent inheritance, and method overriding.

## What is the `final` Keyword?

The `final` keyword in Java is used to restrict certain behaviors. It can be applied to:

1. **Classes** - Prevents inheritance
2. **Methods** - Prevents method overriding
3. **Variables** - Prevents reassignment (creates constants)

Think of `final` as a "lock" - once something is marked as `final`, it cannot be changed or extended.

## `final` Classes - Preventing Inheritance

### Basic Syntax
The following class is final, so it cannot be extended:

```java
public final class MyClass {
    // This class cannot be extended
}
```

This would now cause a compilation error:

```java
//error: cannot inherit from final MyClass
public class MySubClass extends MyClass {
    // ...
}
```

## `final` Methods - Preventing Overriding

### Basic Syntax
```java
public class Parent {
    public final void method() {
        // This method cannot be overridden
    }
}
```

The method above is final, so it cannot be overridden. The following code would cause a compilation error:

```java
//error: cannot override final method method() in Parent
public class MySubClass extends Parent {
    @Override
    public void method() {
        // ...
    }
}
```


## Summary

The `final` keyword is a powerful tool for:

- **Preventing inheritance** with final classes
- **Preventing method overriding** with final methods
- **Creating constants** with final variables

# String Concatenation

You can combine two or more strings using the `+` operator. This is called _string concatenation_.\
For example:

```java
String firstName = "John";
String lastName = "Doe";
String fullName = firstName + " " + lastName; // "John Doe"
System.out.println(fullName); // Prints "John Doe"
```


## String and primitive types

You can concatenate strings with primitive types like integers or characters. When you do this, Java automatically converts the primitive type to a string. For example:

```java
int age = 30;
String message = "I am " + age + " years old."; // "I am 30 years old."
System.out.println(message); // Prints "I am 30 years old."
```


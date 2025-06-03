# String equality

The String is not a simple type, so we cannot use the `==` operator to compare two strings. Instead, we use the `.equals()` method to check if two strings are equal.

This is a command we can execute on _object_ types, i.e. not primitive types like `int`, `double`, etc. 

If you use the `==` operator on strings, it will most likely return `false`, even if the strings have the same content. 

Here is an example of how to compare two strings using the `.equals()` method:

```java
String str1 = "Hello";
String str2 = "Hello";
boolean areEqual = str1.equals(str2); // true, because both strings have the same content
```

Calling the `.equals()` method (i.e. executing the command) on `str1` as above will compare the content of `str1` with `str2`. If they are the same, it returns `true`; otherwise, it returns `false`.
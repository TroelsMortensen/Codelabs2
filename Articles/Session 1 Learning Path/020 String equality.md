# String equality

The String is not a simple type, so we cannot use the `==` operator to compare two strings. Instead, we use the `.equals()` method to check if two strings are equal.

This is an operation we can execute on _object_ types, i.e. not primitive types like `int`, `double`, etc.\
For now, object types are just String. Later you will encounter other object types.

If you use the `==` operator on strings, it will most likely return `false`, even if the strings have the same content. 

Here is an example of how to compare two strings using the `.equals()` method:

```java
String str1 = "Hello";
String str2 = "Hello";
boolean areEqual = str1.equals(str2); // true, because both strings have the same content
```

Calling the `.equals()` method (i.e. executing the command) on `str1` as above will compare the _content_ of `str1` with `str2`. If they are the same, it returns `true`; otherwise, it returns `false`.

In some cases, though not always, comparing the above two strings with `==` will return false. For the above example, you will actually see true printed, even if using `==`, but that is because of a concept called _string interning_ in Java, where identical string literals may refer to the same object in memory. It is still possible to create two strings, with the same value, but the equality comparison will return false.

The point is, even though it may sometimes work when comparing two strings with `==`, it is not a reliable method for checking string equality. Always use the `.equals()` method for comparing strings in Java.
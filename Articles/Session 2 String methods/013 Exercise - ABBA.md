# Exercise - Make ABBA


Given two strings, a and b, return the result of putting them together in the order abba, e.g. "Hi" and "Bye" returns "HiByeByeHi".

Copy in the follow code snippet and complete the `makeAbba` method:

```java
public class MakeAbba {
    public static void main(String[] args) {
        printAbba("Hi", "Bye");     // "HiByeByeHi"
        printAbba("Yo", "Alice");   // "YoAliceAliceYo"
        printAbba("What", "Up");    // "WhatUpUpWhat"
        printAbba("Hello", "World"); // "HelloWorldWorldHello"
    }

    static void printAbba(String a, String b) {
        // Your logic here
    }
}
```
# Exercise - Combo string

Given 2 strings, a and b, return a string of the form short+long+short, with the shorter string on the outside and the longer string on the inside. 

The strings will not be the same length, but they may be empty (length 0).

```java
public class ComboString {
    public static void main(String[] args) {
        printComboString("hi", "hello"); // "hiHellohi"
        printComboString("hello", "hi"); // "hiHellohi"
        printComboString("abc", "defgh"); // "abcdefgabc"
        printComboString("java", "c"); // "cjavac"
    }

    public static void printComboString(String a, String b) {
        // Your logic here
    }
}
```
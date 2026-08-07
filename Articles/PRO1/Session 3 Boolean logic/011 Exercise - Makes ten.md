# Exercise - Makes ten

Given 2 ints, a and b, return true if one of them is 10 _or_ if their sum is 10.

Write a program to determine if the conditions are met based on the values of a and b.

```java
public class MakesTen {
    public static void main(String[] args) {
        makesTen(10, 0);    // should print true
        makesTen(0, 10);    // should print true
        makesTen(5, 5);     // should print true
        makesTen(2, 8);     // should print true
        makesTen(3, 7);     // should print true
        makesTen(1, 9);     // should print true
        makesTen(4, 7);     // should print false
        makesTen(6, 1);     // should print false
    }

    public static void makesTen(int a, int b) {
        // Your logic here, print out the result
    }
}
```
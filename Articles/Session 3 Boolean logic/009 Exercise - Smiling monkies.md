# Exercise - Are we in trouble?

We have two monkeys, a and b, and the parameters aSmile and bSmile indicate if each is smiling. We are in trouble if they are both smiling or if neither of them is smiling. Return true if we are in trouble.

Write a program to dertermine if we are in trouble based on the smiling status of the monkeys.

Consider creating a helper method to encapsulate the logic.

Like this:

```java
public class MonkeyTrouble {
    public static void main(String[] args) {
        weAreInTrouble(true, true); // should return true
        weAreInTrouble(false, false); // should return true
        weAreInTrouble(true, false); // should return false
        weAreInTrouble(false, true); // should return false
    }

    public static void weAreInTrouble(boolean aSmile, boolean bSmile) {
        // Your logic here
    }
}
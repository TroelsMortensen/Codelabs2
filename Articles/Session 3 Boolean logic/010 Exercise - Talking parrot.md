# Exercise - Talking Parrot


We have a loud talking parrot. The "hour" parameter is the current hour time in the range 0..23. We are in trouble if the parrot is talking and the hour is before 7 or after 20. Return true if we are in trouble.

Write a program to determine if we are in trouble based on the talking status of the parrot and the current hour.

Again, I suggest creating a helper method to encapsulate the logic.

```java
public class TalkingParrot {
    public static void main(String[] args) {
        weAreInTrouble(true, 6); // should print out true
        weAreInTrouble(true, 7); // should print out false
        weAreInTrouble(false, 6); // should print out false
        weAreInTrouble(true, 21); // should print out true
        weAreInTrouble(false, 21); // should print out false
        weAreInTrouble(true, 20); // should print out false
    }

    public static void weAreInTrouble(boolean isTalking, int hour) {
        // Your logic here, print out the result
    }
}
```
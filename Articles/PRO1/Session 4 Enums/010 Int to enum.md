# Converting an Integer to an Enum in Java

In Java, you can convert an integer to an enum by using the `values()` method of the enum class. This method returns a collection of all enum constants, and you can access a specific constant using its index.

### Example Code
```java
public class IntToEnumExample {
    public static void main(String[] args) {
        int dayIndex = 2; // Example input (0-based index)

        Day day = Day.values()[dayIndex];  // Accessing enum value at index 2 (WEDNESDAY)

        System.out.println("The day is: " + day);
    }
}

enum Day {
    MONDAY,
    TUESDAY,
    WEDNESDAY,
    THURSDAY,
    FRIDAY,
    SATURDAY,
    SUNDAY;
}
```

### Explanation
1. **`values()` Method**: Returns a collection of all enum constants in the order they are declared, i.e. `MONDAY` is at index 0, `TUESDAY` at index 1, and so on.
2. **Index Access**: Use the integer as an index to access the corresponding enum constant.

---

### Exercise: Traffic Light Simulation with Integer Input
Redo the previous traffic light exercise, but now instead of reading a string from the console and parsing it to the enum, the user should input an integer (e.g., `0` for `RED`, `1` for `YELLOW`, `2` for `GREEN`).


<hint title="Solution">

```java
import java.util.Scanner;

public class TrafficLightSimulation {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter a number (0 for RED, 1 for YELLOW, 2 for GREEN):");
        
        int input = scanner.nextInt();

        TrafficLight light = TrafficLight.fromValue(input);
        
        switch (light) {
            case RED:
                System.out.println("Action: Stop");
                break;
            case YELLOW:
                System.out.println("Action: Caution");
                break;
            case GREEN:
                System.out.println("Action: Go");
                break;
        }
    }

}

enum TrafficLight {
    RED,
    YELLOW,
    GREEN;
}
```

</hint>
# Should you sleep in?

Write a program, which asks the user if it is a weekday or weekend, and if they are on vacation. Use boolean logic to determine if the user should sleep in.

We sleep in if it is not a weekday or we're on vacation. Return true if we sleep in.

Example Output:
```yaml
Is it a weekday? (true/false): false
Are you on vacation? (true/false): false
Should you sleep in? true   
```

```yaml
Is it a weekday? (true/false): true
Are you on vacation? (true/false): true
Should you sleep in? true
```

```yaml
Is it a weekday? (true/false): true
Are you on vacation? (true/false): true
Should you sleep in? true
```

```yaml
Is it a weekday? (true/false): true
Are you on vacation? (true/false): false
Should you sleep in? false
```

<hint title="Solution">

```java
import java.util.Scanner;
public class SleepIn {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Is it a weekday? (true/false): ");
        boolean isWeekday = scanner.nextBoolean();

        System.out.print("Are you on vacation? (true/false): ");
        boolean isVacation = scanner.nextBoolean();

        boolean shouldSleepIn = !isWeekday || isVacation;
        System.out.println("Should you sleep in? " + shouldSleepIn);
    }
}
```

<video src="https://youtu.be/kcVN4Uz5quc"></video>

</hint>
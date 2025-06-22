# Exercise - Reverse a String

## Task
Write a Java program that asks the user to input a string and prints out the reverse of the string.

### Example Input:
```
Enter a string: hello
```

### Example Output:
```
olleh
```

<hint title="Hint 1">

Use a `for` loop to iterate through the string in reverse order and construct the reversed string.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class ReverseString {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a string: ");
        String input = scanner.nextLine();

        String reversed = "";
        for (int i = input.length() - 1; i >= 0; i--) {
            reversed += input.charAt(i);
        }

        System.out.println("Reversed string: " + reversed);
    }
}
```

</hint>
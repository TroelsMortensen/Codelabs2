# Exercise 2 - Two inputs

Write a program which request two inputs, and output a concatenated string.

The interaction should look like this:

```console

Please input first text:
hello
Please input second text:
world
Here is your concatenated text:
hello world
```

<hint title="Hint 1">

You must call the nextLine method on the Scanner object twice, once for each input.

</hint>


<hint title="Solution">

```java
import java.util.Scanner;

public class ConcatenateStrings {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        
        System.out.println("Please input first text:");
        String firstInput = in.nextLine();
        
        System.out.println("Please input second text:");
        String secondInput = in.nextLine();
        
        String concatenatedText = firstInput + " " + secondInput;
        
        System.out.println("Here is your concatenated text:\n" + concatenatedText);
    }
}
```
</hint>


# Exercise - Echo String

We start out small and simple.

Write a program, which will request a `String` from the user,
and then print it back to the console.

The interaction should look like this:

```console
Please input text:
hello there                         (<-- user input)
Here is your text back: 
hello there
```

<hint title="Solution">

```java
import java.util.Scanner;

public class EchoString
{
    public static void main(String[] args)
    {
        System.out.println("Please input text:");
        Scanner in = new Scanner(System.in);
        String input = in.nextLine();
        System.out.println("Here is your text back:\n" + input);
    }
}
```

<video src="https://youtu.be/8lcO3dhbnUs"></video>

</hint>
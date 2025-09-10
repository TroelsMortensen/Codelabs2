

The problem with the switch _statement_, is if you use it to assign a value to a variable, you need to declare the variable before the switch statement. This can lead to errors.\
Another problem is you need the `break`s. If you forget, you have a bug in your code. Or they just bloat your code. The switch _expression_ can provide some slightly cleaner code. It is also known as the _enhanced switch statement_.

Consider the following example, which we will afterwards fix using a switch _expression_. Can you spot the errors?

```java
import java.util.Scanner;

public class SwitchStatementExample 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a day of the week (1-7): ");
        int day = scanner.nextInt();
        
        String dayName = null;
        
        switch (day) 
        {
            case 1:
                dayName = "Monday";
                break;
            case 2:
                dayName = "Tuesday";
            case 3:
                dayName = "Wednesday";
                break;
            case 4:
                dayName = "Thursday";
                break;
            case 5:
                dayName = "Friday";
                break;
            case 6:
                dayName = "Saturday";
                break;
        }
        
        System.out.println("The day is: " + dayName);
    }
}
```

But oops, I forgot to handle case `7` (Sunday) and the default case. If the user enters `7`, the program will not print anything, which is not what we want.

I also forgot a `break` statement after case `2`, which means that if the user enters `2`, it will continue to execute the code for case `3` as well, leading to incorrect output.

The above can be fixed, yes, but I find the switch expression is just cleaner, easier, and simpler, when the point is to assign a value to a variable based on a condition.

Let's rewrite the above example using a switch _expression_:

```java
import java.util.Scanner;

public class SwitchExpressionExample 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a day of the week (1-7): ");
        int day = scanner.nextInt();
        
        String dayName = switch (day) 
        {
            case 1 -> "Monday";
            case 2 -> "Tuesday";
            case 3 -> "Wednesday";
            case 4 -> "Thursday";
            case 5 -> "Friday";
            case 6 -> "Saturday";
            case 7 -> "Sunday"; 
            default -> "Invalid day"; // Default case
        };
        
        System.out.println("The day is: " + dayName);
    }
}
```
Notice that we are doing an _assignment_ of the result of the switch to the `String dayName` variable.\
Switching on the `day` variable will find a `String` value based on which case is matched, and that value is assigned to the `dayName` variable.

## Switch expression "abuse"
The switch expression can be used without assigning a result to a variable. So, it can be a shorter-hand normal switch statement. 

Consider this example:

```java
Scanner scanner = new Scanner(System.in);
System.out.print("Enter a letter: ");
char letter = Character.toLowerCase(scanner.next().charAt(0));

switch (letter) 
{
    case 'a', 'e', 'i', 'o', 'u' -> System.out.println("Vowel");
    default -> System.out.println("Consonant");
}
```

Here, I can list all the cases as a comma-separated list, and I can use the `->` (arrow) operator to execute a single statement for each case. This is a very concise way to write a switch statement when you don't need to assign a value to a variable.

With the standard switch statement, you would have to write each case with a `break` statement, which makes the code longer and less readable.

```java
Scanner scanner = new Scanner(System.in);
System.out.print("Enter a letter: ");
char letter = Character.toLowerCase(scanner.next().charAt(0));

switch (letter) {
    case 'a':
    case 'e':
    case 'i':
    case 'o':
    case 'u':
        System.out.println("Vowel");
        break;
    default:
        System.out.println("Consonant");
}
```


If you want to do the above example with a switch expression, you can do it like this:

```java
Scanner scanner = new Scanner(System.in);
System.out.print("Enter a letter: ");
char letter = Character.toLowerCase(scanner.next().charAt(0));

String result = switch (letter) {
    case 'a', 'e', 'i', 'o', 'u' -> "Vowel";
    default -> "Consonant";
};

System.out.println(result);
```
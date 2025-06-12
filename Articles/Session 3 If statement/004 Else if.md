# If-else-if-else

Yes, it is beginning to get funky. 

On the previous page, you saw could have an either-or situation with an if-else statement. Execute code A _or_ code B, depending on a condition.

What if we have A, B, C, and D? What if we have more than two options? This is where the `else if` statement comes in.

Watch the video below to learn how to use the `else if` statement in Java.

<video src="https://youtu.be/P0e-KIHchF4"></video>


## Comment to video

In the video, I showed the "full" structure, including the `else` block. However, you can also use an `if-else-if` structure without an `else` block at the end. This is useful when you want to check multiple conditions but don't need a default case.

For example:

```java
if (conditionA) {
    System.out.println("condition A is true");
} else if (conditionB) {
    System.out.println("condition B is true");
} 
```

## Comment 2 to video
It is important to note that the `else if` structure is evaluated in order. The first condition that evaluates to `true` will execute its block of code, and the rest will be skipped. This means that if you have multiple conditions, only the first one that is true will be executed.

```java
if (conditionA) {
    System.out.println("condition A is true");
} else if (conditionB) {
    System.out.println("condition B is true");
} else if (conditionC) {
    System.out.println("condition C is true");
} else {
    System.out.println("None of the conditions are true");
}
```

If, for example, `conditionA` is true, the program will print "condition A is true" and skip the rest of the conditions. If `conditionA` is false but `conditionB` is true, it will print "condition B is true" and skip `conditionC` and the `else` block.


# Exercises

### Exercise 1: Number Classification
Write a program that asks the user to enter a number. Use an if-else-if-else structure to classify the number as:
- "Positive" if the number is greater than 0
- "Zero" if the number is equal to 0
- "Negative" if the number is less than 0

Example Output:
```
Enter a number:
-5
The number is Negative
```

```
Enter a number:
5
The number is Positive
```

<hint title="Solution">

```java
import java.util.Scanner;

public class NumberClassification {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int number = scanner.nextInt();

        if (number > 0) {
            System.out.println("The number is Positive");
        } else if (number == 0) {
            System.out.println("The number is Zero");
        } else {
            System.out.println("The number is Negative");
        }
    }
}
```
</hint>


### Exercise 2: Temperature Description
Write a program that asks the user to enter the current temperature. Use an if-else-if-else structure to print:
- "It's hot" for temperatures above 30
- "It's warm" for temperatures between 20 and 30 (inclusive)
- "It's cool" for temperatures between 10 and 19 (inclusive)
- "It's cold" for temperatures below 10

Example Output:
```
Enter the temperature:
15
It's cool
```

<hint title="Solution">

```java
import java.util.Scanner;

public class TemperatureDescription {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the temperature: ");
        int temperature = scanner.nextInt();

        if (temperature > 30) {
            System.out.println("It's hot");
        } else if (temperature >= 20) {
            System.out.println("It's warm");
        } else if (temperature >= 10) {
            System.out.println("It's cool");
        } else {
            System.out.println("It's cold");
        }
    }
}
```
</hint>

### Exercise 3 Grade Evaluation
Write a program that asks the user to enter their exam score. Use an if-else-if-else structure to print the grade based on the score:
- "A" for scores 90 and above
- "B" for scores 80 to 89
- "C" for scores 70 to 79
- "D" for scores 60 to 69
- "F" for scores below 60

Example Output:
```
Enter your score:
85
Your grade is: B
```

<hint title="Solution">

```java
import java.util.Scanner;

public class GradeEvaluation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter your score: ");
        int score = scanner.nextInt();

        if (score >= 90) {
            System.out.println("Your grade is: A");
        } else if (score >= 80) {
            System.out.println("Your grade is: B");
        } else if (score >= 70) {
            System.out.println("Your grade is: C");
        } else if (score >= 60) {
            System.out.println("Your grade is: D");
        } else {
            System.out.println("Your grade is: F");
        }
    }
}
```
</hint>


### Exercise 4: Sequential ifs vs else-ifs

Consider the solution of the previous exercise. What if we had used sequential if-statements instead of an else-if structure?

It would look like this:

```java
import java.util.Scanner;
public class GradeEvaluationSequential {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter your score: ");
        int score = scanner.nextInt();

        if (score >= 90) {
            System.out.println("Your grade is: A");
        }
        if (score >= 80) {
            System.out.println("Your grade is: B");
        }
        if (score >= 70) {
            System.out.println("Your grade is: C");
        }
        if (score >= 60) {
            System.out.println("Your grade is: D");
        }
        if (score < 60) {
            System.out.println("Your grade is: F");
        }
        if (score < 40) {
            System.out.println("You failed the exam");
        }
    }
}
```

Try creating a program with the above code example, and input different scores to see the output.

The point here is to see that multiple if-statements can lead to multiple outputs, while an else-if structure ensures that only one block of code is executed based on the first true condition.


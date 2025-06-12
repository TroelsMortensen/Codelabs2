# Exercise - Quadratic Equation Solver

 In math a quadratic equation is given as: 
 
$$ax^2 + bx + c = 0$$

 For such an equation the discriminant (`D`) is calculated as: 
 
$$D = b^2 - 4ac$$

and the solution to the equation is given by:

If `D` is negative, there are no real solutions.

If `D` is zero, there is one real solution:


$$x = \frac{-b}{2a}$$

If `D` is positive, there are two real solutions:

$$x = \frac{-b + \sqrt{D}}{2a}$$

$$x = \frac{-b - \sqrt{D}}{2a}$$


Create a program that asks the user for input values for `a`, `b`, and `c`, and then calculates the solutions (if any) to the quadratic equation.\
Print the solutions to the console.

<hint title="Hint: Calculating Square Root in Java">

To calculate the square root of a number in Java, you can use the `Math.sqrt()` method from the `java.lang` package.\
This method takes a `double` (`int` is also okay) as input and returns the square root of the number.

### Example:
```java
double number = 16;
double squareRoot = Math.sqrt(number);
System.out.println("The square root of " + number + " is: " + squareRoot);
```
This will output:
```
The square root of 16 is: 4.0
```
</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class QuadraticEquationSolver {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter value for a: ");
        double a = scanner.nextDouble();

        System.out.print("Enter value for b: ");
        double b = scanner.nextDouble();

        System.out.print("Enter value for c: ");
        double c = scanner.nextDouble();

        double discriminant = Math.pow(b, 2) - 4 * a * c;

        if (discriminant < 0) {
            System.out.println("No real solutions.");
        } else if (discriminant == 0) {
            double x = -b / (2 * a);
            System.out.println("One real solution: x = " + x);
        } else {
            double x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.sqrt(discriminant)) / (2 * a);
            System.out.println("Two real solutions: x1 = " + x1 + ", x2 = " + x2);
        }
    }
}
```
</hint>


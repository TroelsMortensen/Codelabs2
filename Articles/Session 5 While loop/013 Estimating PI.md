# Estimating PI

PI is a mathematical constant, the first five digits of which are 3.14159. It is the ratio of a circle's circumference to its diameter. 

PI can be estimated using various methods, one of which is the following formula:

$$\pi = 4 \times \left(1 - \frac{1}{3} + \frac{1}{5} - \frac{1}{7} + \frac{1}{9} - \frac{1}{11} + \frac{1}{13} - \frac{1}{15} + \ldots\right)$$

The longer the series is continued, the closer the estimate to the value of π the result is.

## Exercise: Estimate PI Using 10 Terms

Write a Java program that estimates the value of PI using the first 10 terms of the formula above. Use a `while` loop to calculate the sum and display both the estimated value and the actual value of PI for comparison.

### Example Output:
```
Estimated PI using 10 terms: 3.0418396189294032
Actual PI: 3.141592653589793
Difference: 0.09975283465960932
```

**Note:** Java provides the actual value of PI through `Math.PI` which you can use for comparison. E.g.: `double actualPI = Math.PI;`. You will be prompted to import the `Math` class.

<hint title="Hint 1">

Start with a sum of 0 and use a counter to track which term you're calculating. For each term, calculate `1 / (2*i - 1)` where i is the term number. Alternate between adding and subtracting terms.

</hint>

<hint title="Hint 2">

The pattern for the denominators is: 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 (odd numbers). You can generate these using `2*i - 1` where i goes from 1 to 10.

</hint>

<hint title="Solution">

```java
public class EstimatePI {
    public static void main(String[] args) {
        double sum = 0.0;
        int terms = 10;
        int i = 1;
        
        while (i <= terms) {
            double term = 1.0 / (2 * i - 1);
            
            if (i % 2 == 1) {
                sum += term;  // Add for odd positions (1st, 3rd, 5th, etc.)
            } else {
                sum -= term;  // Subtract for even positions (2nd, 4th, 6th, etc.)
            }
            
            i++;
        }
        
        double estimatedPI = 4 * sum;
        double actualPI = Math.PI;
        double difference = Math.abs(actualPI - estimatedPI);
        
        System.out.println("Estimated PI using " + terms + " terms: " + estimatedPI);
        System.out.println("Actual PI: " + actualPI);
        System.out.println("Difference: " + difference);
    }
}
```

</hint>

## Exercise 2: Interactive PI Estimation

Write a Java program that estimates PI using an iterative approach. Start by calculating the first 5 terms of the formula, then ask the user if they want to continue. If they choose to continue, calculate 5 more terms and ask again. If they choose to stop, display the final results. Use a `while` loop to control the continuation process.

### Example Output:
```
Estimated PI using 5 terms: 2.9760461760461761
Actual PI: 3.141592653589793
Difference: 0.16554647754361693

Do you want to calculate 5 more terms? (y/n): y

Estimated PI using 10 terms: 3.0418396189294032
Actual PI: 3.141592653589793
Difference: 0.09975283465960932

Do you want to calculate 5 more terms? (y/n): y

Estimated PI using 15 terms: 3.0739909665427886
Actual PI: 3.141592653589793
Difference: 0.06760168704700434

Do you want to calculate 5 more terms? (y/n): n

Final Results:
Estimated PI using 15 terms: 3.0739909665427886
Actual PI: 3.141592653589793
Difference: 0.06760168704700434
```

<hint title="Hint 1">

Use a Scanner to read user input. Start with 5 terms and use a while loop that continues as long as the user enters "y". Inside the loop, calculate 5 more terms each time and display intermediate results.

</hint>

<hint title="Hint 2">

Keep track of the current term number and the running sum. Each iteration should add exactly 5 more terms to the calculation.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class InteractivePIEstimation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double sum = 0.0;
        int currentTerm = 1;
        int termsPerBatch = 5;
        int totalTerms = 0;
        boolean continueCalculation = true;
        
        while (continueCalculation) {
            // Calculate 5 terms
            for (int batch = 0; batch < termsPerBatch; batch++) {
                double term = 1.0 / (2 * currentTerm - 1);
                
                if (currentTerm % 2 == 1) {
                    sum += term;  // Add for odd positions
                } else {
                    sum -= term;  // Subtract for even positions
                }
                
                currentTerm++;
            }
            
            totalTerms += termsPerBatch;
            double estimatedPI = 4 * sum;
            double actualPI = Math.PI;
            double difference = Math.abs(actualPI - estimatedPI);
            
            System.out.println("Estimated PI using " + totalTerms + " terms: " + estimatedPI);
            System.out.println("Actual PI: " + actualPI);
            System.out.println("Difference: " + difference);
            System.out.println();
            
            System.out.print("Do you want to calculate 5 more terms? (y/n): ");
            String userInput = scanner.nextLine();
            
            if (!userInput.equalsIgnoreCase("y")) {
                continueCalculation = false;
                System.out.println("\nFinal Results:");
                System.out.println("Estimated PI using " + totalTerms + " terms: " + estimatedPI);
                System.out.println("Actual PI: " + actualPI);
                System.out.println("Difference: " + difference);
            }
        }
    }
}
```

</hint>




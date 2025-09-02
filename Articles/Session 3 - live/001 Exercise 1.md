# Exercise - Clean up

Consider the following code snippet:

```java
public class EvaluateStudent
{
    public static void main(String[] args) {
        // Test case 1: Student with good score
        System.out.println("Test 1 - Expected: Student driver with good score");
        evaluateStudent(20, true, 85, "student");
        System.out.println();

        // Test case 2: Professional with good score
        System.out.println("Test 2 - Expected: Professional driver with good score");
        evaluateStudent(30, true, 90, "professional");
        System.out.println();

        // Test case 3: Driver with average score
        System.out.println("Test 3 - Expected: Driver with average score");
        evaluateStudent(25, true, 70, "other");
        System.out.println();

        // Test case 4: Driver with poor score
        System.out.println("Test 4 - Expected: Driver with poor score");
        evaluateStudent(22, true, 45, "student");
        System.out.println();

        // Test case 5: Adult without license
        System.out.println("Test 5 - Expected: Adult without license");
        evaluateStudent(28, false, 80, "professional");
        System.out.println();

        // Test case 6: Minor
        System.out.println("Test 6 - Expected: Minor");
        evaluateStudent(16, true, 95, "student");
        System.out.println();

        // Test case 7: Driver with good score (other category)
        System.out.println("Test 7 - Expected: Driver with good score");
        evaluateStudent(35, true, 88, "other");
    }

    static void evaluateStudent(int age, boolean hasLicense, int score, String category) {
        if (age >= 18) {
            if (hasLicense) {
                if (score >= 80) {
                    if (category.equals("student")) {
                        System.out.println("Student driver with good score");
                    } else if (category.equals("professional")) {
                        System.out.println("Professional driver with good score");
                    } else {
                        System.out.println("Driver with good score");
                    }
                } else if (score >= 60) {
                    System.out.println("Driver with average score");
                } else {
                    System.out.println("Driver with poor score");
                }
            } else {
                System.out.println("Adult without license");
            }
        } else {
            System.out.println("Minor");
        }
    }
}
```


Untangle the `evaluateStudent()` method, so that it is instead one chain of if-else, without nested ifs.
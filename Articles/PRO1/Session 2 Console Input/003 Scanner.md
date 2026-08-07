# The Scanner Class

What can we actually do with the `Scanner` class?\
The `Scanner` class is a powerful tool for reading input from various sources, including the console.\
We will focus on reading input from the console, only.

To set up the `Scanner`, we need to create an instance of it.\
This is done by calling the constructor of the `Scanner` class, passing `System.in` as an argument.

```java
import java.util.Scanner;

public class ScannerExample {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in); // Create a Scanner object
    }

}
```

Similar to the `String` class, the `Scanner` is also a class, and we can create a new instance of it using the `new` keyword.\
This is about objects and classes, which we will get back to later in the course.

Just accept for now, this is how we access a Scanner, which can read input from the console.
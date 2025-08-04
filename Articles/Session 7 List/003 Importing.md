# Importing the ArrayList

In order to use the `ArrayList` in your Java programs, you need to import it from the Java Collections Framework. This is done using the `import` statement at the beginning of your Java file.

Remember, how this needs to be done with the Scanner class to read user input? The same applies here.

```java{1}
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> myList = new ArrayList<>();
    }
}

Notice the first line, this imports the `ArrayList` class from the `java.util` package, which is where all the collection classes are located.\
You can now create an `ArrayList` object and use it in your program.


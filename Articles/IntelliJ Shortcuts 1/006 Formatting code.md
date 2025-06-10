# Code formatting

IntelliJ IDEA provides powerful code formatting capabilities that can be customized to fit your coding style.\
You probably don't need to change the default settings, but it's good to know how to format your code properly.

The short cut for this feature is <kbd>CTRL</kbd> + <kbd>ALT</kbd> + <kbd>L</kbd>.

Consider the following three code snippets. From the compiler's perspective, they are equivalent, but to the programmer, they are not equally easy to read.\
Formatting your code makes it more readable and maintainable. It is _very_ important to format your code properly, especially when working in a team.



```java
public class Average
{
    public static void main(String[] args)
    {
        int shares = 220;
        double averagePrice = 14.67;
        System.out.println("There were " + shares + " shares sold at $" + averagePrice + " per share.");
    }
}
```

```java
public class Average
{
public static void main(String[] args)
{
int shares = 220;
double averagePrice = 14.67;
System.out.println("There were " + shares + " shares sold at $" + averagePrice + " per share.");
}
}
```

```java
public class Average {public static void main(String[] args){int shares=220; double averagePrice=14.67; System.out.println("There were "+shares+" shares sold at $"+averagePrice+" per share.");}}
```

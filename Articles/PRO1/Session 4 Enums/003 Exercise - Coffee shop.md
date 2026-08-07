# Exercise - Coffee Sizes

Create an enum called `CoffeeSize` with values `SMALL`, `MEDIUM`, and `LARGE`. Write a program that prints out the price given a size.


### Instructions
1. Define an enum `CoffeeSize` with the values `SMALL`, `MEDIUM`, and `LARGE`.
2. Fill out the `printPrice` method to print the price based on the selected coffee size:
   - SMALL: $2.50
   - MEDIUM: $3.50
   - LARGE: $4.50

### Example Code
```java

public class CoffeeShop {
    public static void main(String[] args) {
        printPrice(CoffeeSize.SMALL);
        printPrice(CoffeeSize.MEDIUM);
        printPrice(CoffeeSize.LARGE);
    }

    public static void printPrice(CoffeeSize size) {
        // Your logic here
    }
}

enum CoffeeSize {
    SMALL,
    MEDIUM,
    LARGE;
}
```
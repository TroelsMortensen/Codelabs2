# Exercise - Seasons

Create an enum called `Season` with values `SPRING`, `SUMMER`, `FALL`, and `WINTER`. Write a program that prints out a description of the season.

### Example Output
```
WINTER is cold and snowy.
SUMMER is hot and sunny.
FALL is cool and windy.
SPRING is mild and blooming.
```

### Example Code
```java
public class SeasonExample {
    public static void main(String[] args) {
        printWeather(Season.SPRING);
        printWeather(Season.SUMMER);
        printWeather(Season.FALL);
        printWeather(Season.WINTER);
    }

    public static void printWeather(Season season) {
        // Your logic here
    }
}

enum Season {
    SPRING,
    SUMMER,
    FALL,
    WINTER;
}
```

Exercise 5 - City information

Write a program that asks the user to enter the name of their favorite city. 
Use a String variable to store the input.\
The
program should display the following:
* The number of characters in the city name
* The name of the city in all uppercase letters
* The name of the city in all lowercase letters
* The first character in the name of the city

The interaction should look like this:

```console
Please enter the name of your favorite city:
Paris
The number of characters in the city name: 5
The name of the city in uppercase: PARIS
The name of the city in lowercase: paris
The first character in the city name: P
```

<hint title="Solution">

```java
import java.util.Scanner;
public class CityInformation {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        
        System.out.println("Please enter the name of your favorite city:");
        String city = in.nextLine(); // Read the city name
        
        int length = city.length(); // Get the number of characters
        String upperCaseCity = city.toUpperCase(); // Convert to uppercase
        String lowerCaseCity = city.toLowerCase(); // Convert to lowercase
        char firstCharacter = city.charAt(0); // Get the first character
        
        // Output the results
        System.out.println("The number of characters in the city name: " + length);
        System.out.println("The name of the city in uppercase: " + upperCaseCity);
        System.out.println("The name of the city in lowercase: " + lowerCaseCity);
        System.out.println("The first character in the city name: " + firstCharacter);
    }
}
```

</hint>

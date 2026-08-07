# Exercise - Clean up

Consider the following code snippet:

```java
public class WeatherExample {
    public static void main(String[] args) {
        // Test case 1: Sunny morning with high temperature
        System.out.println("Test 1 - Expected: Morning jog in the sun");
        evaluateWeather("sunny", 28, true, "morning");
        System.out.println();
        
        // Test case 2: Sunny afternoon with high temperature
        System.out.println("Test 2 - Expected: Beach time!");
        evaluateWeather("sunny", 30, true, "afternoon");
        System.out.println();
        
        // Test case 3: Sunny evening with high temperature
        System.out.println("Test 3 - Expected: Evening walk in the sun");
        evaluateWeather("sunny", 27, true, "evening");
        System.out.println();
        
        // Test case 4: Sunny with moderate temperature
        System.out.println("Test 4 - Expected: Nice day for outdoor activities");
        evaluateWeather("sunny", 20, true, "morning");
        System.out.println();
        
        // Test case 5: Sunny but cold
        System.out.println("Test 5 - Expected: Sunny but too cold");
        evaluateWeather("sunny", 12, true, "afternoon");
        System.out.println();
        
        // Test case 6: Rainy with umbrella and warm
        System.out.println("Test 6 - Expected: Rainy walk with umbrella");
        evaluateWeather("rainy", 18, true, "morning");
        System.out.println();
        
        // Test case 7: Rainy with umbrella but cold
        System.out.println("Test 7 - Expected: Cold rainy day with umbrella");
        evaluateWeather("rainy", 8, true, "afternoon");
        System.out.println();
        
        // Test case 8: Rainy without umbrella
        System.out.println("Test 8 - Expected: Stay indoors - it's raining");
        evaluateWeather("rainy", 15, false, "morning");
        System.out.println();
        
        // Test case 9: Cloudy day
        System.out.println("Test 9 - Expected: Cloudy day");
        evaluateWeather("cloudy", 22, true, "afternoon");
    }
    
    static void evaluateWeather(String weather, int temperature, boolean hasUmbrella, String timeOfDay) {
        if (weather.equals("sunny")) {
            if (temperature > 25) {
                if (timeOfDay.equals("morning")) {
                    System.out.println("Morning jog in the sun");
                } else if (timeOfDay.equals("afternoon")) {
                    System.out.println("Beach time!");
                } else {
                    System.out.println("Evening walk in the sun");
                }
            } else if (temperature > 15) {
                System.out.println("Nice day for outdoor activities");
            } else {
                System.out.println("Sunny but too cold");
            }
        } else if (weather.equals("rainy")) {
            if (hasUmbrella) {
                if (temperature > 10) {
                    System.out.println("Rainy walk with umbrella");
                } else {
                    System.out.println("Cold rainy day with umbrella");
                }
            } else {
                System.out.println("Stay indoors - it's raining");
            }
        } else {
            System.out.println("Cloudy day");
        }
    }
}
```


Untangle the `evaluateStudent()` method, so that it is instead one chain of if-else, without nested ifs.
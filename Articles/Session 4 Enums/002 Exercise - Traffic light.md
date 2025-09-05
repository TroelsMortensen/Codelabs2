# Exercise - Traffic Light Simulation

Enums are compared like primitive types, i.e. using the `==` operator. For example:

```java
TrafficLight light = TrafficLight.RED;
System.out.println(light == TrafficLight.RED); // true
```

Above, the `light` variable is assigned the value `RED`, and then we compare it to the value `RED` using the `==` operator. This will return `true`, as is printed out.

## The actual exercise

Create an enum called `TrafficLight` with values `RED`, `YELLOW`, and `GREEN`. Write a program that simulates a traffic light. Print out the action, given a traffic light colour.

Start with the following code snippet.

The printAction should print out as follows based on the traffic light color:

- RED: "Action: Stop"
- YELLOW: "Action: Caution"
- GREEN: "Action: Go"

```java
public class TrafficLightSimulation {
    public static void main(String[] args) {
        printAction(TrafficLight.RED);
        printAction(TrafficLight.YELLOW);
        printAction(TrafficLight.GREEN);
    }

    public static void printAction(TrafficLight trafficLight) {
        // Your logic here
    }
}

enum TrafficLight {
    RED,
    YELLOW,
    GREEN;
}
```

# Iterating Through a Map

When you need both keys and values, iterate through `entrySet()`.

## Why `entrySet()`?

Each entry contains:

- one key
- one value

This makes iteration clear and efficient.

## Example

```java
import java.util.HashMap;
import java.util.Map;

Map<String, Double> planetDistance = new HashMap<>();
planetDistance.put("Mercury", 0.39);
planetDistance.put("Venus", 0.72);
planetDistance.put("Earth", 1.00);

for (Map.Entry<String, Double> entry : planetDistance.entrySet())
{
    String planet = entry.getKey();
    Double distanceAU = entry.getValue();
    System.out.println(planet + " -> " + distanceAU);
}
```

## Quick Summary

- Use `entrySet()` when you need key and value together
- Use `getKey()` and `getValue()` on each entry

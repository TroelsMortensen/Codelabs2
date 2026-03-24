# Iterating Through a Map

There are several ways to iterate through, or loop through, a `Map`:
-
- `entrySet()`
- `keySet()`
- `values()`

## `entrySet()`

When you need both keys and values, iterate through `entrySet()`.

Each entry contains:

- one key
- one value

This makes iteration clear and efficient.

## Example

```java
import java.util.HashMap;
import java.util.Map;

Map<String, Double> planetDistanceMap = new HashMap<>();
planetDistanceMap.put("Mercury", 0.39);
planetDistanceMap.put("Venus", 0.72);
planetDistanceMap.put("Earth", 1.00);

for (Map.Entry<String, Double> entry : planetDistanceMap.entrySet())
{
    String planet = entry.getKey();
    Double distanceAU = entry.getValue();
    System.out.println(planet + " -> " + distanceAU);
}
```

## `keySet()`

Use `keySet()` when you only need keys. This method will return a collection of the keys.

```java
for (String planet : planetDistanceMap.keySet())
{
    System.out.println("Planet: " + planet);
    System.out.println("Distance from sun: " + planetDistanceMap.get(planet));
}
```

## `values()`

Use `values()` when you only need values. This method will return a collection of the values. Here, we don't know what the associated key is, so we can't print the planet name.

```java
for (Double distanceAU : planetDistanceMap.values())
{
    System.out.println("Distance from sun: " + distanceAU);
}
```



## Quick Summary

- Use `entrySet()` when you need key and value together
- Use `getKey()` and `getValue()` on each entry
- Use `keySet()` when you only need keys
- Use `values()` when you only need values

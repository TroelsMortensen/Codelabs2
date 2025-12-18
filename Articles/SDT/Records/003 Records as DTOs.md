# Records as DTOs

Let's see how records work as DTOs using the Space Explorer domain.

## Example: PlanetDTO as a Record

Here's a complete DTO for the `Planet` entity:

```java
public record PlanetDTO(
    int id,
    String name,
    String climateDescription,
    double distanceFromStarAU,
    boolean hasAtmosphere,
    boolean hasLife
) {}
```

**Usage:**
```java
PlanetDTO planet = new PlanetDTO(1, "Kepler-442b", "Temperate", 0.4, true, false);
System.out.println(planet.name());  // "Kepler-442b"
System.out.println(planet.id());    // 1
System.out.println(planet.hasAtmosphere());  // true
```


## Benefits for DTOs

Using records for DTOs gives you:

- ✅ **Less code** - No need to write constructors, getters, equals, hashCode, toString
- ✅ **Immutability** - All fields are automatically final
- ✅ **Consistency** - All records work the same way
- ✅ **Readability** - The record declaration clearly shows what data it contains
- ✅ **Maintainability** - Adding or removing fields is simple

Records make DTOs much simpler to implement while maintaining all the benefits of immutable data classes.


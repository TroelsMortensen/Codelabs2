# More Useful Map Methods

Here is a quick overview of other helpful `Map` methods.

- `containsKey(key)` - checks whether a key exists, returns true if the key is found, false otherwise
- `containsValue(value)` - checks whether a value exists, returns true if the value is found, false otherwise
- `getOrDefault(key, defaultValue)` - returns a fallback when key is missing, returns the value if the key is found, otherwise returns the default value
- `putIfAbsent(key, value)` - adds only if the key is not already present
- `size()` - returns the number of entries
- `isEmpty()` - returns `true` if there are no entries

## Example Snapshot

```java
import java.util.HashMap;
import java.util.Map;

Map<String, Integer> score = new HashMap<>();
score.put("Ana", 84);

System.out.println(score.containsKey("Ana"));          // true
System.out.println(score.getOrDefault("Ben", 0));      // 0
score.putIfAbsent("Ana", 100);                         // not updated
System.out.println(score.size());                      // 1
```

These methods cover many common day-to-day `Map` tasks.

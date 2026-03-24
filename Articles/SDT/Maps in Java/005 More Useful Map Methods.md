# More Useful Map Methods

Here is a quick overview of other helpful `Map` methods.

- `containsKey(key)` - checks whether a key exists
- `containsValue(value)` - checks whether a value exists
- `getOrDefault(key, defaultValue)` - returns a fallback when key is missing
- `putIfAbsent(key, value)` - adds only if the key is not already present
- `keySet()` - returns all keys
- `values()` - returns all values
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

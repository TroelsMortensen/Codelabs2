# Updating and Removing Entries

You can update existing values and remove entries from a `Map`.

## Updating with `put()`

If a key already exists, `put()` replaces the old value.

```java
import java.util.HashMap;
import java.util.Map;

Map<String, Integer> stock = new HashMap<>();

stock.put("Keyboard", 12);
stock.put("Keyboard", 15); // Overwrites 12

System.out.println(stock.get("Keyboard")); // 15
```

Same key, new value.

## Removing with `remove(key)`

`remove()` deletes an entry by key.

```java
stock.put("Mouse", 25);
stock.remove("Mouse");

System.out.println(stock.get("Mouse")); // null
```

If the key does not exist, nothing is removed.


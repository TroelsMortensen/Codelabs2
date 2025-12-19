# The Principle

Let's dive deeper into what the "Make Islands, Not Mountains" principle means and how to apply it.

## The Rule: Topography over Topology

**Topography over Topology.**

This means we care more about the **shape** of the code (how it looks when rotated) than the **structure** of the logic (how it's organized). The visual "altitude" of your code matters more than the logical organization.

## What is "Altitude" in Code?

**Altitude** refers to the **indentation level** - how many levels deep your code is nested.

```java
// Ground level (altitude 0)
public void method() {
    // Level 1 (altitude 1)
    if (condition) {
        // Level 2 (altitude 2)
        for (item : items) {
            // Level 3 (altitude 3)
            if (anotherCondition) {
                // Level 4 (altitude 4) - Getting high!
                try {
                    // Level 5 (altitude 5) - Very high!
                    // The actual logic is here
                }
            }
        }
    }
}
```

Each level of indentation increases the "altitude." The deeper you go, the higher the altitude, and the harder it becomes to understand the code.

## The Oxygen Equipment Metaphor

**If you need oxygen equipment (deep mental context) to reach the inner-most if statement, the method is too steep.**

This metaphor means:
- **Low altitude** = Easy to understand, no special mental preparation needed
- **High altitude** = Requires holding multiple contexts in your head, like needing oxygen at high elevations

When code is too deeply nested, you need to:
- Remember all the outer conditions
- Track all the variables in scope
- Understand how all the levels interact
- Navigate back through all the levels

This is mentally exhausting - like climbing a mountain without proper equipment.

## When Code Becomes "Too Steep"

Code becomes too steep when:

1. **More than 3-4 levels of nesting** - Beyond this, cognitive load increases significantly
2. **You can't see the full structure** - The method is too long to see all levels at once
3. **You forget outer conditions** - You need to scroll up to remember what's true
4. **Testing becomes difficult** - You can't easily test the inner logic in isolation
5. **Changes are risky** - Modifying code requires understanding the entire nested structure


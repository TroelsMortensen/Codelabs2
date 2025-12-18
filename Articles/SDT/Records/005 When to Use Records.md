# When to Use Records

Let's compare records with regular classes and understand when to use each for DTOs.

## Records vs Regular Classes for DTOs

| Aspect | Record | Regular Class |
|--------|--------|---------------|
| **Boilerplate** | Minimal | More code needed |
| **Immutability** | Built-in | Must use `final` fields |
| **Getter naming** | `name()` | `getName()` |
| **Customization** | Limited | Full control |
| **Inheritance** | Cannot extend classes | Can extend classes |
| **Additional methods** | Can add methods | Full flexibility |

## When to Use Records for DTOs

**Use records when:**

- ✅ Your DTO is a simple data container
- ✅ You want immutability (which is recommended for DTOs)
- ✅ You don't need inheritance
- ✅ You want less boilerplate code

Records are ideal for most DTO scenarios because DTOs are typically:
- Simple data containers
- Immutable
- Don't need inheritance
- Benefit from less boilerplate

## When to Use Regular Classes

**Use regular classes when:**

- ❌ You need inheritance (DTOs extending other DTOs)
- ❌ You need complex initialization logic
- ❌ You need mutable DTOs (though this is rare and not recommended)
- ❌ You're working with older Java versions (before Java 14)
- ❌ You need very specific control over equals/hashCode/toString behavior

For most DTO use cases, these requirements are rare, so records are usually the better choice.

## Recommendation

**For DTOs, prefer records** unless you have a specific reason not to:

1. DTOs are data containers - records are designed for this
2. DTOs should be immutable - records enforce this
3. DTOs rarely need inheritance - records don't support it, which is fine
4. Less code means fewer bugs and easier maintenance


## Summary

- **Records** are concise, immutable data classes perfect for DTOs
- They're **ideal for most DTO scenarios** - simple, immutable data containers
- Accessor methods use field names directly: `planet.name()` not `planet.getName()`
- Records can be customized with compact constructors and additional methods
- Use records for simple DTOs, regular classes only when you need inheritance or are on older Java versions

**Records make DTOs even simpler to implement!**


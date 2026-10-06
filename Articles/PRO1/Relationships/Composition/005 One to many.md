# One to many composition

A flying carpet can have many enchantments. Those enchantments are integral parts of the carpet — they cannot exist independently of it. Once an enchantment takes effect, it is bound to the carpet. That is composition.

## Example: FlyingCarpet and Enchantment

Here are three alternative approaches for adding enchantments. In real code you would pick one; they are shown separately so you can compare them.

### Approach 1: Add by providing details (create internally)

```java
public void addEnchantment(String enchantmentName, int powerLevel, String magicType)
{
    Enchantment newEnchantment = new Enchantment(enchantmentName, powerLevel, magicType);
    this.enchantments.add(newEnchantment);
}
```

### Approach 2: Add by providing an object, copy with constructor data

```java
public void addEnchantment(Enchantment enchantment)
{
    Enchantment copy = new Enchantment(
        enchantment.getEnchantmentName(),
        enchantment.getPowerLevel(),
        enchantment.getMagicType());
    this.enchantments.add(copy);
}
```

### Approach 3: Add by providing an object, use a copy method

```java
public void addEnchantment(Enchantment enchantment)
{
    this.enchantments.add(enchantment.createCopy());
}
```

Approaches 2 and 3 have the same method signature — you cannot have both in one class at the same time. Choose one style.

### Full classes

```java{4,13-16}
public class FlyingCarpet
{
    private String carpetName;
    private String material;
    private ArrayList<Enchantment> enchantments;

    public FlyingCarpet(String carpetName, String material)
    {
        this.carpetName = carpetName;
        this.material = material;
        this.enchantments = new ArrayList<>();
    }

    public void addEnchantment(Enchantment enchantment)
    {
        this.enchantments.add(enchantment.createCopy());
    }
}

public class Enchantment
{
    private String enchantmentName;
    private int powerLevel;
    private String magicType;

    public Enchantment(String enchantmentName, int powerLevel, String magicType)
    {
        this.enchantmentName = enchantmentName;
        this.powerLevel = powerLevel;
        this.magicType = magicType;
    }

    public Enchantment createCopy()
    {
        return new Enchantment(this.enchantmentName, this.powerLevel, this.magicType);
    }

    public String getEnchantmentName() { return enchantmentName; }
    public int getPowerLevel() { return powerLevel; }
    public String getMagicType() { return magicType; }
}
```

### Conceptual meaning

The child objects (`Enchantment`) are integral parts of the parent (`FlyingCarpet`). They cannot exist independently. The parent has exclusive ownership and creates the children internally (or copies them). No other objects reference the same child instances. Ownership is the strongest of all relationship types.

And yes — all the copy stuff to enforce strong ownership can be a bit challenging.

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Why does <code>addEnchantment(Enchantment)</code> call <code>createCopy()</code>?</p>",
    "Options": [
        {
            "Text": "So the carpet stores its own Enchantment instance, not the caller's reference",
            "IsCorrect": true
        },
        {
            "Text": "Because ArrayList requires copies",
            "IsCorrect": false
        },
        {
            "Text": "To make the method compile",
            "IsCorrect": false
        },
        {
            "Text": "Because UML requires it",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Composition needs exclusive ownership — see approaches 2 and 3.",
    "Explanation": "Storing the caller's Enchantment would share the reference and break composition. Storing a copy keeps ownership exclusive."
}
</Quiz>

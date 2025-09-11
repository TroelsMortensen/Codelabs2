# Association Exercises

Practice implementing one-to-one association relationships in Java with these fun and interesting exercises.

## Exercise 1: Wizard and Wand

Create a `Wizard` class and a `Wand` class with a one-to-one association. The wizard can cast spells using their wand, and the wand has magical properties.

### Requirements:
- `Wand` class with properties: wood type, core material, and power level
- `Wizard` class with properties: name and associated wand
- Methods for casting spells and checking wand compatibility
- Ability to change wands (showing loose coupling)

### Example Output:
```
Gandalf casts 'Fireball' with his Oak wand (Phoenix feather core, Power: 85)
Wand changed! Gandalf now wields an Elder wand (Dragon heartstring core, Power: 95)
```

## Exercise 2: Chef and Recipe

Design a `Chef` class and a `Recipe` class where each chef specializes in one signature recipe. The chef can cook their recipe and modify it.

### Requirements:
- `Recipe` class with ingredients list, cooking time, and difficulty level
- `Chef` class with name and their signature recipe
- Methods to cook the recipe and add new ingredients
- Ability to learn a new recipe (replacing the current one)

### Example Output:
```
Chef Gordon is cooking: Spaghetti Carbonara
Ingredients: Pasta, Eggs, Cheese, Bacon
Cooking time: 15 minutes, Difficulty: Medium
Chef Gordon learned a new recipe: Beef Wellington
```

## Exercise 3: Astronaut and Spacesuit

Create an `Astronaut` class and a `Spacesuit` class. Each astronaut has one spacesuit for space missions, and the spacesuit has life support capabilities.

### Requirements:
- `Spacesuit` class with oxygen level, temperature control, and mission type
- `Astronaut` class with name and assigned spacesuit
- Methods to check suit status and perform spacewalk
- Ability to switch spacesuits for different missions

### Example Output:
```
Astronaut Neil Armstrong wearing Exploration Suit
Oxygen: 95%, Temperature: 22°C, Mission: Lunar Landing
Spacewalk authorized! Neil is now outside the spacecraft.
```

## Exercise 4: Detective and Case

Build a `Detective` class and a `Case` class where each detective works on one active case at a time. The case contains evidence and clues.

### Requirements:
- `Case` class with case number, crime type, evidence list, and status
- `Detective` class with name and current case
- Methods to investigate, add evidence, and solve cases
- Ability to take on new cases (closing the previous one)

### Example Output:
```
Detective Sherlock Holmes working on Case #2024-001
Crime: Theft, Status: Under Investigation
Evidence found: Fingerprints, Security footage
Case #2024-001 SOLVED! Detective Holmes can now take on Case #2024-002
```

## Tips for Implementation

1. **Use constructors** to establish initial associations
2. **Implement setter methods** to change associations at runtime
3. **Add validation** to ensure objects are properly associated
4. **Include null checks** when accessing associated objects
5. **Show the flexibility** of association by allowing object swapping

## Bonus Challenge

For each exercise, add a method that demonstrates the independence of the objects:
- What happens when you create a wizard without a wand?
- Can a recipe exist without a chef?
- What if an astronaut's spacesuit malfunctions?
- Can a case be solved without a detective?

Remember: In association, both objects can exist independently, so your code should handle cases where one object might not have an associated object.

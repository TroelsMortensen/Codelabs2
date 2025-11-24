# Exercise 19 - Fantasy Game System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Game {
        - gameName : String
        + addCharacter(character : Character) void
        + getCharactersByClass(className : String) ArrayList~Character~
        + battle(char1 : Character, char2 : Character) Character
        + getTotalCharacters() int
    }
    
    class Character {
        - characterId : int
        - name : String
        - level : int
        - health : int
        - maxHealth : int
        - experience : int
        + Character(characterId : int, name : String, level : int)
        + getName() String
        + getLevel() int
        + getHealth() int
        + takeDamage(damage : int) void
        + heal(amount : int) void
        + gainExperience(xp : int) void
        + isAlive() boolean
        + attack() int
        + defend() int
    }
    
    class Warrior {
        - strength : int
        - armor : int
        + attack() int
        + defend() int
    }
    
    class Mage {
        - intelligence : int
        - mana : int
        - maxMana : int
        + attack() int
        + defend() int
        + castSpell(spellName : String) int
    }
    
    class Rogue {
        - agility : int
        - stealth : int
        + attack() int
        + defend() int
        + criticalStrike() int
    }
    
    class Inventory {
        - maxCapacity : int
        + addItem(item : Item) boolean
        + removeItem(itemName : String) void
        + getItems() ArrayList~Item~
        + getTotalWeight() double
    }
    
    class Item {
        - itemName : String
        - weight : double
        - value : int
        + Item(itemName : String, weight : double, value : int)
        + getItemName() String
        + getWeight() double
        + getValue() int
    }
    
    class Weapon {
        - damage : int
        - durability : int
        + getDamage() int
        + use() void
    }
    
    class Potion {
        - effect : String
        - potency : int
        + use(character : Character) void
    }
    
    Game --> "*" Character : characters
    Character --> "1" Inventory : inventory
    Warrior --|> Character
    Mage --|> Character
    Rogue --|> Character
    Inventory --> "*" Item : items
    Weapon --|> Item
    Potion --|> Item
```

## Notes:
- Warriors attack with base damage = strength * 2 + armor
- Mages attack with base damage = intelligence * 3 (costs 10 mana)
- Rogues attack with base damage = agility * 2, critical strike does triple damage
- Warriors defend by reducing damage by armor value
- Mages defend by reducing damage by intelligence / 2
- Rogues defend by dodging (50% chance to take no damage based on agility)
- Characters level up every 100 experience points
- Health potions heal for their potency value, mana potions restore mana
- This exercise does not require date handling


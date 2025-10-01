# Exercise: Game Character Battle System

## Description

Create a fantasy game battle system with different character classes, abilities, items, and a turn-based combat system. Characters can use abilities, equip items, and battle against each other. Different character types have unique attributes and abilities.

This exercise focuses on:
- Creating abstract base classes for characters, abilities, and items
- Implementing inheritance for different character classes and ability types
- Modeling game mechanics with appropriate attributes and methods
- Managing character inventories and equipped items
- Implementing a turn-based battle system

## Class Diagram

```mermaid
classDiagram
    class _Character_ {
        <<abstract>>
        - name : String
        - level : int
        - health : int
        - maxHealth : int
        - mana : int
        - maxMana : int
        - equipped Weapon : Weapon
        - equippedArmor : Armor
        - abilities : ArrayList~Ability~
        + Character(name : String, level : int)
        + getName() String
        + getLevel() int
        + getHealth() int
        + getMaxHealth() int
        + getMana() int
        + getMaxMana() int
        + isAlive() boolean
        + takeDamage(damage : int) void
        + heal(amount : int) void
        + useMana(amount : int) boolean
        + restoreMana(amount : int) void
        + equipWeapon(weapon : Weapon) void
        + equipArmor(armor : Armor) void
        + getWeapon() Weapon
        + getArmor() Armor
        + addAbility(ability : Ability) void
        + getAbilities() ArrayList~Ability~
        + calculateAttackPower() int
        + calculateDefense() int
        + getCharacterClass()* String
        + toString() String
    }
    
    class Warrior {
        - strength : int
        - stamina : int
        + Warrior(name : String, level : int)
        + getStrength() int
        + getStamina() int
        + calculateAttackPower() int
        + calculateDefense() int
        + getCharacterClass() String
        + rage() void
    }
    
    class Mage {
        - intelligence : int
        - wisdom : int
        + Mage(name : String, level : int)
        + getIntelligence() int
        + getWisdom() int
        + calculateAttackPower() int
        + calculateDefense() int
        + getCharacterClass() String
        + meditate() void
    }
    
    class Archer {
        - dexterity : int
        - agility : int
        + Archer(name : String, level : int)
        + getDexterity() int
        + getAgility() int
        + calculateAttackPower() int
        + calculateDefense() int
        + getCharacterClass() String
        + dodge() void
    }
    
    class Healer {
        - faith : int
        - compassion : int
        + Healer(name : String, level : int)
        + getFaith() int
        + getCompassion() int
        + calculateAttackPower() int
        + calculateDefense() int
        + getCharacterClass() String
        + pray() void
    }
    
    class _Ability_ {
        <<abstract>>
        - name : String
        - manaCost : int
        - description : String
        + Ability(name : String, manaCost : int, description : String)
        + getName() String
        + getManaCost() int
        + getDescription() String
        + canUse(character : Character) boolean
        + use(caster : Character, target : Character)* void
        + getAbilityType()* String
        + toString() String
    }
    
    class AttackAbility {
        - baseDamage : int
        + AttackAbility(name : String, manaCost : int, description : String, baseDamage : int)
        + getBaseDamage() int
        + use(caster : Character, target : Character) void
        + getAbilityType() String
    }
    
    class HealingAbility {
        - healAmount : int
        + HealingAbility(name : String, manaCost : int, description : String, healAmount : int)
        + getHealAmount() int
        + use(caster : Character, target : Character) void
        + getAbilityType() String
    }
    
    class DefenseAbility {
        - defenseBoost : int
        - duration : int
        + DefenseAbility(name : String, manaCost : int, description : String, defenseBoost : int, duration : int)
        + getDefenseBoost() int
        + getDuration() int
        + use(caster : Character, target : Character) void
        + getAbilityType() String
    }
    
    class _Item_ {
        <<abstract>>
        - name : String
        - value : int
        - description : String
        + Item(name : String, value : int, description : String)
        + getName() String
        + getValue() int
        + getDescription() String
        + getItemType()* String
        + toString() String
    }
    
    class Weapon {
        - attackBonus : int
        - weaponType : String
        + Weapon(name : String, value : int, description : String, attackBonus : int, weaponType : String)
        + getAttackBonus() int
        + getWeaponType() String
        + getItemType() String
    }
    
    class Armor {
        - defenseBonus : int
        - armorType : String
        + Armor(name : String, value : int, description : String, defenseBonus : int, armorType : String)
        + getDefenseBonus() int
        + getArmorType() String
        + getItemType() String
    }
    
    class Inventory {
        - items : ArrayList~Item~
        - maxCapacity : int
        + Inventory(maxCapacity : int)
        + addItem(item : Item) boolean
        + removeItem(item : Item) void
        + getItems() ArrayList~Item~
        + isFull() boolean
        + getCurrentCapacity() int
        + getMaxCapacity() int
        + getTotalValue() int
        + showInventory() void
    }
    
    class Battle {
        - character1 : Character
        - character2 : Character
        - turnCount : int
        + Battle(character1 : Character, character2 : Character)
        + startBattle() void
        + executeTurn(attacker : Character, defender : Character) void
        + isOver() boolean
        + getWinner() Character
        + showBattleStatus() void
    }
    
    class GameTester {
        + main(args : String[]) void
    }
    
    _Character_ <|-- Warrior
    _Character_ <|-- Mage
    _Character_ <|-- Archer
    _Character_ <|-- Healer
    _Ability_ <|-- AttackAbility
    _Ability_ <|-- HealingAbility
    _Ability_ <|-- DefenseAbility
    _Item_ <|-- Weapon
    _Item_ <|-- Armor
    _Character_ --> Weapon
    _Character_ --> Armor
    _Character_ --> _Ability_
    Inventory --> _Item_
    Battle --> _Character_
    GameTester --> Battle
    GameTester --> _Character_
```

## Class Descriptions

### Abstract Class: Character

The base class for all game characters.

**Fields:**
- `name` - Character's name
- `level` - Character's level
- `health` - Current health points
- `maxHealth` - Maximum health points
- `mana` - Current mana points
- `maxMana` - Maximum mana points
- `equippedWeapon` - Currently equipped weapon (can be null)
- `equippedArmor` - Currently equipped armor (can be null)
- `abilities` - List of available abilities

**Methods:**
- `Character(name, level)` - Constructor (initializes health and mana based on level)
- `getName()` - Returns character name
- `getLevel()` - Returns level
- `getHealth()` - Returns current health
- `getMaxHealth()` - Returns max health
- `getMana()` - Returns current mana
- `getMaxMana()` - Returns max mana
- `isAlive()` - Returns true if health > 0
- `takeDamage(damage)` - Reduces health by damage amount (minimum 0)
- `heal(amount)` - Increases health by amount (maximum maxHealth)
- `useMana(amount)` - Attempts to use mana, returns true if successful
- `restoreMana(amount)` - Restores mana (maximum maxMana)
- `equipWeapon(weapon)` - Equips a weapon
- `equipArmor(armor)` - Equips armor
- `getWeapon()` - Returns equipped weapon
- `getArmor()` - Returns equipped armor
- `addAbility(ability)` - Adds an ability to the character
- `getAbilities()` - Returns list of abilities
- `calculateAttackPower()` - Abstract method to calculate total attack power
- `calculateDefense()` - Abstract method to calculate total defense
- `getCharacterClass()` - Abstract method returning character class name
- `toString()` - Returns formatted string with character stats

### Class: Warrior extends Character

A melee combat specialist with high strength and stamina.

**Fields:**
- `strength` - Strength attribute (affects attack power)
- `stamina` - Stamina attribute (affects health)

**Methods:**
- `Warrior(name, level)` - Constructor (sets strength = 15 + level * 2, stamina = 12 + level * 2)
- `getStrength()` - Returns strength
- `getStamina()` - Returns stamina
- `calculateAttackPower()` - Returns strength + (weapon bonus if equipped)
- `calculateDefense()` - Returns stamina / 2 + (armor bonus if equipped)
- `getCharacterClass()` - Returns "Warrior"
- `rage()` - Special ability that temporarily boosts attack (prints message)

### Class: Mage extends Character

A magic user with high intelligence and wisdom.

**Fields:**
- `intelligence` - Intelligence attribute (affects spell power)
- `wisdom` - Wisdom attribute (affects mana)

**Methods:**
- `Mage(name, level)` - Constructor (sets intelligence = 18 + level * 3, wisdom = 14 + level * 2)
- `getIntelligence()` - Returns intelligence
- `getWisdom()` - Returns wisdom
- `calculateAttackPower()` - Returns intelligence + (weapon bonus if equipped)
- `calculateDefense()` - Returns wisdom / 3 + (armor bonus if equipped)
- `getCharacterClass()` - Returns "Mage"
- `meditate()` - Restores 20 mana points (prints message)

### Class: Archer extends Character

A ranged specialist with high dexterity and agility.

**Fields:**
- `dexterity` - Dexterity attribute (affects ranged attack)
- `agility` - Agility attribute (affects defense)

**Methods:**
- `Archer(name, level)` - Constructor (sets dexterity = 16 + level * 2, agility = 14 + level * 2)
- `getDexterity()` - Returns dexterity
- `getAgility()` - Returns agility
- `calculateAttackPower()` - Returns dexterity + (weapon bonus if equipped)
- `calculateDefense()` - Returns agility / 2 + (armor bonus if equipped)
- `getCharacterClass()` - Returns "Archer"
- `dodge()` - Special ability that increases evasion (prints message)

### Class: Healer extends Character

A support character with healing abilities.

**Fields:**
- `faith` - Faith attribute (affects healing power)
- `compassion` - Compassion attribute (affects mana and healing)

**Methods:**
- `Healer(name, level)` - Constructor (sets faith = 16 + level * 2, compassion = 15 + level * 2)
- `getFaith()` - Returns faith
- `getCompassion()` - Returns compassion
- `calculateAttackPower()` - Returns faith / 2 + (weapon bonus if equipped)
- `calculateDefense()` - Returns compassion / 2 + (armor bonus if equipped)
- `getCharacterClass()` - Returns "Healer"
- `pray()` - Restores health to nearby allies (prints message)

### Abstract Class: Ability

The base class for all character abilities.

**Fields:**
- `name` - Ability name
- `manaCost` - Mana cost to use the ability
- `description` - Description of what the ability does

**Methods:**
- `Ability(name, manaCost, description)` - Constructor
- `getName()` - Returns ability name
- `getManaCost()` - Returns mana cost
- `getDescription()` - Returns description
- `canUse(character)` - Returns true if character has enough mana
- `use(caster, target)` - Abstract method to use the ability on target
- `getAbilityType()` - Abstract method returning ability type
- `toString()` - Returns formatted string with ability details

### Class: AttackAbility extends Ability

An offensive ability that deals damage.

**Fields:**
- `baseDamage` - Base damage of the ability

**Methods:**
- `AttackAbility(name, manaCost, description, baseDamage)` - Constructor
- `getBaseDamage()` - Returns base damage
- `use(caster, target)` - Uses mana, calculates damage (baseDamage + caster's attack power / 4), applies to target
- `getAbilityType()` - Returns "Attack"

### Class: HealingAbility extends Ability

A support ability that heals the target.

**Fields:**
- `healAmount` - Amount of health restored

**Methods:**
- `HealingAbility(name, manaCost, description, healAmount)` - Constructor
- `getHealAmount()` - Returns heal amount
- `use(caster, target)` - Uses mana, heals target by healAmount
- `getAbilityType()` - Returns "Healing"

### Class: DefenseAbility extends Ability

A buff ability that increases defense.

**Fields:**
- `defenseBoost` - Amount of defense increase
- `duration` - Duration in turns

**Methods:**
- `DefenseAbility(name, manaCost, description, defenseBoost, duration)` - Constructor
- `getDefenseBoost()` - Returns defense boost
- `getDuration()` - Returns duration
- `use(caster, target)` - Uses mana, prints message about defense boost
- `getAbilityType()` - Returns "Defense"

### Abstract Class: Item

The base class for all items.

**Fields:**
- `name` - Item name
- `value` - Gold value of the item
- `description` - Item description

**Methods:**
- `Item(name, value, description)` - Constructor
- `getName()` - Returns item name
- `getValue()` - Returns value
- `getDescription()` - Returns description
- `getItemType()` - Abstract method returning item type
- `toString()` - Returns formatted string with item details

### Class: Weapon extends Item

An item that increases attack power.

**Fields:**
- `attackBonus` - Attack bonus provided
- `weaponType` - Type of weapon (sword, staff, bow, etc.)

**Methods:**
- `Weapon(name, value, description, attackBonus, weaponType)` - Constructor
- `getAttackBonus()` - Returns attack bonus
- `getWeaponType()` - Returns weapon type
- `getItemType()` - Returns "Weapon"

### Class: Armor extends Item

An item that increases defense.

**Fields:**
- `defenseBonus` - Defense bonus provided
- `armorType` - Type of armor (heavy, light, robes, etc.)

**Methods:**
- `Armor(name, value, description, defenseBonus, armorType)` - Constructor
- `getDefenseBonus()` - Returns defense bonus
- `getArmorType()` - Returns armor type
- `getItemType()` - Returns "Armor"

### Class: Inventory

Manages a collection of items.

**Fields:**
- `items` - List of items
- `maxCapacity` - Maximum number of items

**Methods:**
- `Inventory(maxCapacity)` - Constructor
- `addItem(item)` - Adds item if not full, returns success
- `removeItem(item)` - Removes item from inventory
- `getItems()` - Returns list of items
- `isFull()` - Returns true if at capacity
- `getCurrentCapacity()` - Returns current item count
- `getMaxCapacity()` - Returns max capacity
- `getTotalValue()` - Returns sum of all item values
- `showInventory()` - Prints all items in inventory

### Class: Battle

Manages a turn-based battle between two characters.

**Fields:**
- `character1` - First character
- `character2` - Second character
- `turnCount` - Current turn number

**Methods:**
- `Battle(character1, character2)` - Constructor
- `startBattle()` - Starts the battle loop until one character is defeated
- `executeTurn(attacker, defender)` - Executes one turn of combat
- `isOver()` - Returns true if either character is defeated
- `getWinner()` - Returns the winning character (or null if battle not over)
- `showBattleStatus()` - Prints current status of both characters

### Class: GameTester

Main testing class to demonstrate the game system.

**Methods:**
- `main(args)` - Creates characters, equips items, adds abilities, runs battles, displays results

## Testing Requirements

The `GameTester` class should demonstrate:
1. Creating different character types
2. Creating and equipping weapons and armor
3. Creating and adding abilities to characters
4. Using abilities
5. Managing character health and mana
6. Creating a battle between two characters
7. Executing turns and showing battle progression
8. Determining the winner

This exercise provides comprehensive practice with inheritance, abstract classes, and complex game mechanics!

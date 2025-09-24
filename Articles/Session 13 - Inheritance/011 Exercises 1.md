# Fun Inheritance Exercise Ideas

## 1. Magical Creature Zoo

Create a hierarchy of magical creatures where each has unique abilities:

```mermaid
classDiagram
    class MagicalCreature {
        - name : String
        - age : int
        - magicLevel : int
        + makeSound() void
        + useMagic() void
        + rest() void
    }
    
    class Dragon {
        - fireBreath : boolean
        - wingSpan : double
        + breatheFire() void
        + fly() void
    }
    
    class Unicorn {
        - hornLength : double
        - healingPower : int
        + heal() void
        + sparkle() void
    }
    
    class Phoenix {
        - rebirthCycle : int
        - flameColor : String
        + resurrect() void
        + soar() void
    }
    
    MagicalCreature <|-- Dragon
    MagicalCreature <|-- Unicorn
    MagicalCreature <|-- Phoenix
```

## 2. Superhero Team Builder

Design a superhero inheritance system with different power types:

```mermaid
classDiagram
    class Superhero {
        - heroName : String
        - secretIdentity : String
        - powerLevel : int
        + usePower() void
        + saveDay() void
    }
    
    class ElementalHero {
        - element : String
        - elementalMastery : int
        + controlElement() void
        + elementalAttack() void
    }
    
    class PhysicalHero {
        - strength : int
        - speed : int
        + superStrength() void
        + superSpeed() void
    }
    
    class MentalHero {
        - psychicPower : int
        - telepathyRange : double
        + readMind() void
        + telekinesis() void
    }
    
    class FireHero {
        - flameIntensity : int
        - fireResistance : boolean
        + fireball() void
        + fireShield() void
    }
    
    class Speedster {
        - maxSpeed : double
        - timeDilation : boolean
        + timeTravel() void
        + speedForce() void
    }
    
    Superhero <|-- ElementalHero
    Superhero <|-- PhysicalHero
    Superhero <|-- MentalHero
    ElementalHero <|-- FireHero
    PhysicalHero <|-- Speedster
```

## 6. Space Vehicle Fleet

Build spacecraft classes with different propulsion systems:

```mermaid
classDiagram
    class Spacecraft {
        - name : String
        - maxCrew : int
        - fuelCapacity : double
        + launch() void
        + land() void
        + communicate() void
    }
    
    class Fighter {
        - weaponSystems : String[]
        - maneuverability : int
        + engageEnemy() void
        + evasiveManeuver() void
    }
    
    class Transport {
        - cargoCapacity : double
        - passengerSeats : int
        + loadCargo() void
        + transportPassengers() void
    }
    
    class Explorer {
        - sensorArray : String[]
        - researchLabs : int
        + scanPlanet() void
        + collectSamples() void
    }
    
    class IonDrive {
        - ionThrust : double
        - efficiency : double
        + ionPropulsion() void
    }
    
    class WarpDrive {
        - warpFactor : double
        - subspaceField : boolean
        + enterWarp() void
    }
    
    Spacecraft <|-- Fighter
    Spacecraft <|-- Transport
    Spacecraft <|-- Explorer
    Fighter <|-- IonDrive
    Transport <|-- WarpDrive
```

## 7. Mythical Weapon Forge

Create a weapon crafting system with magical properties:

```mermaid
classDiagram
    class Weapon {
        - name : String
        - damage : int
        - durability : int
        + attack() void
        + repair() void
    }
    
    class MetalWeapon {
        - metalType : String
        - sharpness : int
        + forge() void
        + temper() void
    }
    
    class WoodWeapon {
        - woodType : String
        - flexibility : int
        + carve() void
        + enchant() void
    }
    
    class CrystalWeapon {
        - crystalType : String
        - magicResonance : int
        + charge() void
        + discharge() void
    }
    
    class Excalibur {
        - holyPower : int
        - kinglyAura : boolean
        + divineStrike() void
        + banishEvil() void
    }
    
    class StaffOfPower {
        - spellAmplification : int
        - manaCapacity : int
        + castSpell() void
        + channelEnergy() void
    }
    
    Weapon <|-- MetalWeapon
    Weapon <|-- WoodWeapon
    Weapon <|-- CrystalWeapon
    MetalWeapon <|-- Excalibur
    CrystalWeapon <|-- StaffOfPower
```

## 9. Fantasy Pet Evolution

Build a pet system with evolution stages:

```mermaid
classDiagram
    class FantasyPet {
        - name : String
        - level : int
        - experience : int
        + play() void
        + sleep() void
        + levelUp() void
    }
    
    class Egg {
        - incubationTime : int
        - warmthLevel : int
        + incubate() void
        + hatch() void
    }
    
    class BabyPet {
        - growthRate : double
        - careNeeds : int
        + feed() void
        + cuddle() void
    }
    
    class AdultPet {
        - specialAbilities : String[]
        - trainingLevel : int
        + train() void
        + battle() void
    }
    
    class LegendaryPet {
        - legendaryPower : String
        - auraEffect : boolean
        + legendaryAbility() void
        + inspireOthers() void
    }
    
    class DragonEgg {
        - fireResistance : boolean
        - scales : String
        + breatheFire() void
    }
    
    class PhoenixEgg {
        - rebirthCycle : int
        - flameColor : String
        + resurrect() void
    }
    
    FantasyPet <|-- Egg
    FantasyPet <|-- BabyPet
    FantasyPet <|-- AdultPet
    FantasyPet <|-- LegendaryPet
    Egg <|-- DragonEgg
    Egg <|-- PhoenixEgg
```

## Exercise Instructions

For each diagram above, implement the classes with:

1. **Constructors** that initialize the specific properties
2. **Method overriding** where appropriate (e.g., different attack methods)
3. **Polymorphism** - create arrays of the base class and call methods
4. **Additional methods** that showcase the unique abilities of each class
5. **toString() methods** to display creature/hero/vehicle/weapon/pet information

### Bonus Challenges:
- Add **interaction methods** between different types
- Implement **battle systems** or **evolution mechanics**
- Create **factory methods** to generate random instances
- Add **validation** for power levels, damage, etc.
- Implement **special abilities** that can only be used under certain conditions

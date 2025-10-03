# Exercise: Zoo Animal Management

## Description

Create a zoo management system that models different types of animals and their enclosures. The system should handle animal feeding, health tracking, and enclosure management. Different animal categories have unique characteristics, and different enclosure types have specific requirements.

This exercise focuses on:
- Creating abstract base classes for animals and enclosures
- Implementing multiple levels of inheritance (Animal → Mammal → Lion)
- Modeling real-world entities with appropriate attributes
- Managing relationships between animals and their enclosures
- Calculating feeding costs and enclosure capacities

## Class Diagram

You can right click the image, and "open in new tab" to view it better.

![class diagram](Resources/ZooClassDiagram.svg)
classDiagram
    namespace animals {
        class _Animal_ {
            - name : String
            - age : int
            - weight : double
            - isHealthy : boolean
            + Animal(name : String, age : int, weight : double)
            + getName() String
            + getAge() int
            + getWeight() double
            + isHealthy() boolean
            + setHealthy(healthy : boolean) void
            + feed() void
            + getDailyFoodAmount()* double
            + getFoodType()* String
            + getAnimalType()* String
            + makeSound()* void
            + toString() String
        }
        
        class _Mammal_ {
            <<abstract>>
            - furColor : String
            - bodyTemperature : double
            + Mammal(name : String, age : int, weight : double, furColor : String)
            + getFurColor() String
            + getBodyTemperature() double
            + setBodyTemperature(temp : double) void
            + checkHealth() void
        }
        
        class Lion {
            - prideSize : int
            + Lion(name : String, age : int, weight : double, furColor : String, prideSize : int)
            + getPrideSize() int
            + setPrideSize(size : int) void
        }
        
        class Elephant {
            - tuskLength : double
            + Elephant(name : String, age : int, weight : double, furColor : String, tuskLength : double)
            + getTuskLength() double
        }
        
        class _Bird_ {
            <<abstract>>
            - wingspan : double
            - canFly : boolean
            + Bird(name : String, age : int, weight : double, wingspan : double, canFly : boolean)
            + getWingspan() double
            + canFly() boolean
            + checkHealth() void
        }
        
        class Eagle {
            - maxAltitude : double
            + Eagle(name : String, age : int, weight : double, wingspan : double, maxAltitude : double)
            + getMaxAltitude() double
        }
        
        class Penguin {
            - swimSpeed : double
            + Penguin(name : String, age : int, weight : double, wingspan : double, swimSpeed : double)
            + getSwimSpeed() double
        }
        
        class _Reptile_ {
            <<abstract>>
            - scaleType : String
            - isColdBlooded : boolean
            + Reptile(name : String, age : int, weight : double, scaleType : String)
            + getScaleType() String
            + isColdBlooded() boolean
            + checkHealth() void
        }
        
        class Snake {
            - length : double
            - isVenomous : boolean
            + Snake(name : String, age : int, weight : double, scaleType : String, length : double, isVenomous : boolean)
            + getLength() double
            + isVenomous() boolean
        }
    }
    
    class _Enclosure_ {
        <<abstract>>
        - enclosureId : String
        - name : String
        - animals : ArrayList~Animal~
        + Enclosure(enclosureId : String, name : String)
        + getEnclosureId() String
        + getName() String
        + getAnimals() ArrayList~Animal~
        + addAnimal(animal : Animal) boolean
        + removeAnimal(animal : Animal) void
        + getMaxCapacity()* int
        + getEnclosureType()* String
        + isFull() boolean
        + getCurrentCapacity() int
        + getTotalDailyFoodCost() double
        + showEnclosureInfo() void
    }
    
    class SavannaEnclosure {
        - hasWaterHole : boolean
        - grassAreaSize : double
        + SavannaEnclosure(enclosureId : String, name : String, hasWaterHole : boolean, grassAreaSize : double)
        + hasWaterHole() boolean
        + getGrassAreaSize() double
    }
    
    class AviaryEnclosure {
        - height : double
        - hasCoverTop : boolean
        + AviaryEnclosure(enclosureId : String, name : String, height : double, hasCoverTop : boolean)
        + getHeight() double
        + hasCoverTop() boolean
    }
    
    class ReptileHouse {
        - temperature : double
        - humidityLevel : int
        + ReptileHouse(enclosureId : String, name : String, temperature : double, humidityLevel : int)
        + getTemperature() double
        + setTemperature(temp : double) void
        + getHumidityLevel() int
        + setHumidityLevel(humidity : int) void
    }
    
    class Zoo {
        - zooName : String
        - enclosures : ArrayList~Enclosure~
        + Zoo(zooName : String)
        + getZooName() String
        + addEnclosure(enclosure : Enclosure) void
        + getEnclosures() ArrayList~Enclosure~
        + findEnclosure(enclosureId : String) Enclosure
        + getAllAnimals() ArrayList~Animal~
        + getTotalAnimals() int
        + getTotalDailyFoodCost() double
        + showZooStatus() void
    }
    
    class ZooTester {
        + main(args : String[]) void
    }
    

    _Bird_ <|-- Eagle
    _Bird_ <|-- Penguin
    _Reptile_ <|-- Snake
    _Enclosure_ <|-- SavannaEnclosure
    _Enclosure_ <|-- AviaryEnclosure
    _Enclosure_ <|-- ReptileHouse
    _Enclosure_ o--> _Animal_
    Zoo *--> _Enclosure_
    ZooTester --> Zoo
    _Animal_ <|-- _Mammal_
    _Animal_ <|-- _Bird_
    _Animal_ <|-- _Reptile_
    _Mammal_ <|-- Lion
    _Mammal_ <|-- Elephant
```

## Class Descriptions

### Abstract Class: Animal

The base class for all animals in the zoo.

**Fields:**
- `name` - Name of the animal
- `age` - Age in years
- `weight` - Weight in kilograms
- `isHealthy` - Health status of the animal
- `enclosure` - The enclosure where the animal is housed

**Methods:**
- `Animal(name, age, weight)` - Constructor
- `getName()` - Returns the animal's name
- `getAge()` - Returns the age
- `getWeight()` - Returns the weight
- `isHealthy()` - Returns health status
- `setHealthy(healthy)` - Sets the health status
- `getEnclosure()` - Returns the assigned enclosure
- `assignToEnclosure(enclosure)` - Assigns the animal to an enclosure
- `feed()` - Feeds the animal (prints message with food type and amount)
- `getDailyFoodAmount()` - Abstract method returning daily food amount in kg
- `getFoodType()` - Abstract method returning the type of food
- `getAnimalType()` - Abstract method returning the animal type
- `makeSound()` - Abstract method that prints the animal's sound
- `toString()` - Returns formatted string with animal details

### Abstract Class: Mammal extends Animal

Represents mammals with fur and body temperature.

**Fields:**
- `furColor` - Color of the fur
- `bodyTemperature` - Current body temperature in Celsius

**Methods:**
- `Mammal(name, age, weight, furColor)` - Constructor (sets body temp to 37.0)
- `getFurColor()` - Returns the fur color
- `getBodyTemperature()` - Returns body temperature
- `setBodyTemperature(temp)` - Sets body temperature
- `checkHealth()` - Checks if body temperature is in healthy range (36-38°C), updates health status

### Class: Lion extends Mammal

Represents a lion.

**Fields:**
- `prideSize` - Size of the pride this lion belongs to

**Methods:**
- `Lion(name, age, weight, furColor, prideSize)` - Constructor
- `getPrideSize()` - Returns pride size
- `setPrideSize(size)` - Sets pride size
- `getDailyFoodAmount()` - Returns 8.0 kg
- `getFoodType()` - Returns "Meat"
- `getAnimalType()` - Returns "Lion"
- `makeSound()` - Prints "Roaaar!"
- `toString()` - Returns formatted string with lion details

### Class: Elephant extends Mammal

Represents an elephant.

**Fields:**
- `tuskLength` - Length of tusks in centimeters

**Methods:**
- `Elephant(name, age, weight, furColor, tuskLength)` - Constructor
- `getTuskLength()` - Returns tusk length
- `getDailyFoodAmount()` - Returns 150.0 kg
- `getFoodType()` - Returns "Vegetation"
- `getAnimalType()` - Returns "Elephant"
- `makeSound()` - Prints "Trumpet!"
- `toString()` - Returns formatted string with elephant details

### Abstract Class: Bird extends Animal

Represents birds with wings.

**Fields:**
- `wingspan` - Wingspan in meters
- `canFly` - Whether the bird can fly

**Methods:**
- `Bird(name, age, weight, wingspan, canFly)` - Constructor
- `getWingspan()` - Returns wingspan
- `canFly()` - Returns true if bird can fly
- `checkHealth()` - Checks if weight is appropriate for wingspan, updates health status

### Class: Eagle extends Bird

Represents an eagle.

**Fields:**
- `maxAltitude` - Maximum flying altitude in meters

**Methods:**
- `Eagle(name, age, weight, wingspan, maxAltitude)` - Constructor (canFly = true)
- `getMaxAltitude()` - Returns max altitude
- `getDailyFoodAmount()` - Returns 1.5 kg
- `getFoodType()` - Returns "Fish"
- `getAnimalType()` - Returns "Eagle"
- `makeSound()` - Prints "Screech!"
- `toString()` - Returns formatted string with eagle details

### Class: Penguin extends Bird

Represents a penguin.

**Fields:**
- `swimSpeed` - Swimming speed in km/h

**Methods:**
- `Penguin(name, age, weight, wingspan, swimSpeed)` - Constructor (canFly = false)
- `getSwimSpeed()` - Returns swim speed
- `getDailyFoodAmount()` - Returns 2.0 kg
- `getFoodType()` - Returns "Fish"
- `getAnimalType()` - Returns "Penguin"
- `makeSound()` - Prints "Squawk!"
- `toString()` - Returns formatted string with penguin details

### Abstract Class: Reptile extends Animal

Represents reptiles with scales.

**Fields:**
- `scaleType` - Type of scales
- `isColdBlooded` - Whether the reptile is cold-blooded (always true)

**Methods:**
- `Reptile(name, age, weight, scaleType)` - Constructor (sets isColdBlooded to true)
- `getScaleType()` - Returns scale type
- `isColdBlooded()` - Returns true
- `checkHealth()` - Simple health check, prints status message

### Class: Snake extends Reptile

Represents a snake.

**Fields:**
- `length` - Length in meters
- `isVenomous` - Whether the snake is venomous

**Methods:**
- `Snake(name, age, weight, scaleType, length, isVenomous)` - Constructor
- `getLength()` - Returns length
- `isVenomous()` - Returns true if venomous
- `getDailyFoodAmount()` - Returns 0.5 kg
- `getFoodType()` - Returns "Rodents"
- `getAnimalType()` - Returns "Snake"
- `makeSound()` - Prints "Hisss!"
- `toString()` - Returns formatted string with snake details

### Abstract Class: Enclosure

The base class for all enclosures.

**Fields:**
- `enclosureId` - Unique identifier
- `name` - Name of the enclosure
- `animals` - List of animals in this enclosure

**Methods:**
- `Enclosure(enclosureId, name)` - Constructor
- `getEnclosureId()` - Returns the ID
- `getName()` - Returns the name
- `getAnimals()` - Returns list of animals
- `addAnimal(animal)` - Adds animal to enclosure if not full, assigns enclosure to animal, returns success
- `removeAnimal(animal)` - Removes animal from enclosure
- `getMaxCapacity()` - Abstract method returning maximum capacity
- `getEnclosureType()` - Abstract method returning enclosure type
- `isFull()` - Returns true if at maximum capacity
- `getCurrentCapacity()` - Returns current number of animals
- `getTotalDailyFoodCost()` - Calculates total daily food cost (sum of all animals' food amounts * $2 per kg)
- `showEnclosureInfo()` - Prints enclosure information including animals

### Class: SavannaEnclosure extends Enclosure

Enclosure for savanna animals.

**Fields:**
- `hasWaterHole` - Whether there's a water hole
- `grassAreaSize` - Size of grass area in square meters

**Methods:**
- `SavannaEnclosure(enclosureId, name, hasWaterHole, grassAreaSize)` - Constructor
- `hasWaterHole()` - Returns true if has water hole
- `getGrassAreaSize()` - Returns grass area size
- `getMaxCapacity()` - Returns 10
- `getEnclosureType()` - Returns "Savanna"

### Class: AviaryEnclosure extends Enclosure

Enclosure for birds.

**Fields:**
- `height` - Height in meters
- `hasCoverTop` - Whether the top is covered

**Methods:**
- `AviaryEnclosure(enclosureId, name, height, hasCoverTop)` - Constructor
- `getHeight()` - Returns height
- `hasCoverTop()` - Returns true if covered
- `getMaxCapacity()` - Returns 20
- `getEnclosureType()` - Returns "Aviary"

### Class: ReptileHouse extends Enclosure

Enclosure for reptiles with climate control.

**Fields:**
- `temperature` - Temperature in Celsius
- `humidityLevel` - Humidity percentage

**Methods:**
- `ReptileHouse(enclosureId, name, temperature, humidityLevel)` - Constructor
- `getTemperature()` - Returns temperature
- `setTemperature(temp)` - Sets temperature
- `getHumidityLevel()` - Returns humidity level
- `setHumidityLevel(humidity)` - Sets humidity level
- `getMaxCapacity()` - Returns 15
- `getEnclosureType()` - Returns "Reptile House"

### Class: Zoo

Manages all enclosures in the zoo.

**Fields:**
- `zooName` - Name of the zoo
- `enclosures` - List of all enclosures

**Methods:**
- `Zoo(zooName)` - Constructor
- `getZooName()` - Returns zoo name
- `addEnclosure(enclosure)` - Adds an enclosure to the zoo
- `getEnclosures()` - Returns list of enclosures
- `findEnclosure(enclosureId)` - Finds enclosure by ID
- `getAllAnimals()` - Returns list of all animals across all enclosures
- `getTotalAnimals()` - Returns total count of animals
- `getTotalDailyFoodCost()` - Calculates total daily food cost for all animals
- `showZooStatus()` - Prints zoo status including all enclosures and animals

### Class: ZooTester

Main testing class to demonstrate the zoo system.

**Methods:**
- `main(args)` - Creates zoo, enclosures, animals, performs operations, and displays results

## Testing Requirements

The `ZooTester` class should demonstrate:
1. Creating a zoo
2. Creating different types of enclosures
3. Adding enclosures to the zoo
4. Creating various animals (lions, elephants, eagles, penguins, snakes)
5. Adding animals to appropriate enclosures
6. Making animals produce sounds
7. Feeding animals
8. Checking enclosure capacities
9. Calculating daily food costs
10. Displaying zoo status

This exercise provides comprehensive practice with multi-level inheritance, abstract classes, and complex object relationships!

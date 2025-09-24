# Inheritance Hierarchy Exercises

## Exercise 1: School System

Given the following nouns, create an inheritance hierarchy:

**Nouns:**
- Person
- Student
- Teacher
- Principal
- Janitor
- Course
- Classroom

**Task:**
1. Identify which nouns represent classes that could be in an inheritance relationship
2. Create a hierarchy showing the "is a" relationships
3. Draw the UML diagram using Mermaid

**Hint:** Think about who "is a" person in this system.

---

## Exercise 2: Transportation

Given the following nouns, create an inheritance hierarchy:

**Nouns:**
- Vehicle
- Car
- Motorcycle
- Truck
- Bicycle
- Airplane
- Boat
- Engine
- Wheel

**Task:**
1. Identify which nouns represent classes that could be in an inheritance relationship
2. Create a hierarchy showing the "is a" relationships
3. Draw the UML diagram using Mermaid

**Hint:** Focus on the "is a" relationship. Not all nouns will be in the inheritance hierarchy.

---

## Exercise 3: Animals

Given the following nouns, create an inheritance hierarchy:

**Nouns:**
- Animal
- Dog
- Cat
- Bird
- Fish
- Mammal
- Reptile
- Eagle
- Goldfish
- Labrador
- Siamese

**Task:**
1. Identify which nouns represent classes that could be in an inheritance relationship
2. Create a hierarchy showing the "is a" relationships
3. Draw the UML diagram using Mermaid

**Hint:** Consider multiple levels of inheritance. Some animals are more specific types of other animals.

---

## Exercise 4: Electronics

Given the following nouns, create an inheritance hierarchy:

**Nouns:**
- ElectronicDevice
- Computer
- Smartphone
- Tablet
- Laptop
- Desktop
- iPhone
- Android
- Samsung
- MacBook
- Processor
- Screen

**Task:**
1. Identify which nouns represent classes that could be in an inheritance relationship
2. Create a hierarchy showing the "is a" relationships
3. Draw the UML diagram using Mermaid

**Hint:** Think about different levels of specificity. Some devices are more general, others are very specific.

---

## Exercise 5: Shapes

Given the following nouns, create an inheritance hierarchy:

**Nouns:**
- Shape
- Rectangle
- Circle
- Triangle
- Square
- Polygon
- EquilateralTriangle
- RightTriangle
- Ellipse
- Color
- Point

**Task:**
1. Identify which nouns represent classes that could be in an inheritance relationship
2. Create a hierarchy showing the "is a" relationships
3. Draw the UML diagram using Mermaid

**Hint:** Consider that some shapes are special cases of other shapes (e.g., a square is a special rectangle).

---

## Solutions

### Exercise 1 Solution:
```mermaid
classDiagram
    class Person {
        -String name
        -int age
        +getName() String
        +getAge() int
    }
    
    class Student {
        -String studentId
        -double gpa
        +study() void
    }
    
    class Teacher {
        -String employeeId
        -String subject
        +teach() void
    }
    
    class Principal {
        -String office
        +manageSchool() void
    }
    
    class Janitor {
        -String shift
        +clean() void
    }
    
    Student --|> Person : inherits
    Teacher --|> Person : inherits
    Principal --|> Person : inherits
    Janitor --|> Person : inherits
```

### Exercise 2 Solution:
```mermaid
classDiagram
    class Vehicle {
        -String brand
        -int year
        +start() void
        +stop() void
    }
    
    class Car {
        -int doors
        +honk() void
    }
    
    class Motorcycle {
        -boolean hasWindshield
        +rev() void
    }
    
    class Truck {
        -double cargoCapacity
        +loadCargo() void
    }
    
    class Bicycle {
        -int gears
        +pedal() void
    }
    
    class Airplane {
        -int wingspan
        +fly() void
    }
    
    class Boat {
        -double displacement
        +sail() void
    }
    
    Car --|> Vehicle : inherits
    Motorcycle --|> Vehicle : inherits
    Truck --|> Vehicle : inherits
    Bicycle --|> Vehicle : inherits
    Airplane --|> Vehicle : inherits
    Boat --|> Vehicle : inherits
```

### Exercise 3 Solution:
```mermaid
classDiagram
    class Animal {
        -String name
        -int age
        +eat() void
        +sleep() void
    }
    
    class Mammal {
        -boolean hasFur
        +giveBirth() void
    }
    
    class Bird {
        -boolean canFly
        +fly() void
    }
    
    class Fish {
        -boolean livesInWater
        +swim() void
    }
    
    class Dog {
        -String breed
        +bark() void
    }
    
    class Cat {
        -boolean isIndoor
        +meow() void
    }
    
    class Eagle {
        -double wingspan
        +hunt() void
    }
    
    class Goldfish {
        -String color
        +bubble() void
    }
    
    class Labrador {
        -String color
        +retrieve() void
    }
    
    class Siamese {
        -String pattern
        +purr() void
    }
    
    Mammal --|> Animal : inherits
    Bird --|> Animal : inherits
    Fish --|> Animal : inherits
    Dog --|> Mammal : inherits
    Cat --|> Mammal : inherits
    Eagle --|> Bird : inherits
    Goldfish --|> Fish : inherits
    Labrador --|> Dog : inherits
    Siamese --|> Cat : inherits
```

### Exercise 4 Solution:
```mermaid
classDiagram
    class ElectronicDevice {
        -String brand
        -double price
        +turnOn() void
        +turnOff() void
    }
    
    class Computer {
        -String processor
        -int ram
        +compute() void
    }
    
    class Smartphone {
        -String os
        -int batteryLife
        +makeCall() void
    }
    
    class Tablet {
        -double screenSize
        -boolean hasStylus
        +touch() void
    }
    
    class Laptop {
        -double weight
        -int batteryHours
        +close() void
    }
    
    class Desktop {
        -String caseType
        -int powerSupply
        +upgrade() void
    }
    
    class iPhone {
        -String model
        +useSiri() void
    }
    
    class Android {
        -String version
        +useGoogle() void
    }
    
    class Samsung {
        -String galaxyModel
        +useBixby() void
    }
    
    class MacBook {
        -String chip
        +useTouchBar() void
    }
    
    Computer --|> ElectronicDevice : inherits
    Smartphone --|> ElectronicDevice : inherits
    Tablet --|> ElectronicDevice : inherits
    Laptop --|> Computer : inherits
    Desktop --|> Computer : inherits
    iPhone --|> Smartphone : inherits
    Android --|> Smartphone : inherits
    Samsung --|> Android : inherits
    MacBook --|> Laptop : inherits
```

### Exercise 5 Solution:
```mermaid
classDiagram
    class Shape {
        -String color
        -Point center
        +getArea() double
        +getPerimeter() double
    }
    
    class Polygon {
        -int numberOfSides
        +getNumberOfSides() int
    }
    
    class Rectangle {
        -double width
        -double height
        +getWidth() double
        +getHeight() double
    }
    
    class Circle {
        -double radius
        +getRadius() double
    }
    
    class Triangle {
        -double base
        -double height
        +getBase() double
        +getHeight() double
    }
    
    class Square {
        -double side
        +getSide() double
    }
    
    class EquilateralTriangle {
        -double side
        +getSide() double
    }
    
    class RightTriangle {
        -double base
        -double height
        +getHypotenuse() double
    }
    
    class Ellipse {
        -double majorAxis
        -double minorAxis
        +getMajorAxis() double
        +getMinorAxis() double
    }
    
    Polygon --|> Shape : inherits
    Rectangle --|> Polygon : inherits
    Circle --|> Shape : inherits
    Triangle --|> Polygon : inherits
    Square --|> Rectangle : inherits
    EquilateralTriangle --|> Triangle : inherits
    RightTriangle --|> Triangle : inherits
    Ellipse --|> Shape : inherits
```

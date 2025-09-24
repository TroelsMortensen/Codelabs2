# Introduction to Inheritance

This learning path will introduce you to the concept of inheritance. It will also be explored further in upcoming sessions.

## What is Inheritance?

Inheritance is one of the fundamental concepts in object-oriented programming. It allows a class to _inherit_ properties and methods from another class, creating a parent-child relationship between classes (superclass and subclass). This is, however, different from other relationships, where we have also used the parent and child terminology.

Think of inheritance like a family tree. Just as children inherit characteristics from their parents, classes can inherit features from other classes.

## Real-World Examples

Consider some real-world examples. You may notice that the "parent" is a kind of generalization, and the "child" is a more specific instance of the parent.

### People and Professions
- **Person** (parent class) - person is a generalization of all people. It has basic properties like name, age, etc.
  - **Student** (child class) - inherits basic person properties like name, age. Further, it has student specific properties, like the student ID, current semester, etc.
  - **Teacher** (child class) - inherits basic person properties like name, age. Further, it has a teacher specific property, like the teacher ID, current subjects, office hours, etc.
  - **Doctor** (child class) - inherits basic person properties like name, age. Further, it has doctor specific properties, like medical specialization.

### Animals
- **Bird** (parent class) - bird is a generalization of all birds. It has basic properties like feather colours, ability to fly, etc.
  - **Pigeon** (child class) - inherits bird properties like wings, ability to fly. Further, it has pigeon specific properties, like the pigeon's name, current location, current message being carried, etc.
  - **Eagle** (child class) - inherits bird properties like wings, ability to fly. Further, it has eagle specific properties, like the eagle's current prey.
  - **Penguin** (child class) - inherits bird properties but may not fly. Further, it has penguin specific properties, like... I don't know, maybe it has a penguin specific property. Waddle speed?

### Shapes
- **Shape** (parent class) - shape is a generalization of all shapes. It has basic properties like area calculation, perimeter calculation, etc.
  - **Square** (child class) - inherits shape properties like area calculation. Further, it has square specific properties, like the square's side length.
  - **Triangle** (child class) - inherits shape properties like area calculation. Further, it has triangle specific properties, like the triangle's base length and height.
  - **Circle** (child class) - inherits shape properties like area calculation. Further, it has circle specific properties, like the circle's radius.

So, the superclass/generalization/parent has some general properties for a "category" of objects, while the subclass/specialization/child has more specific properties for a more specific instance of the parent.

## Key Concepts

### Parent Class (Superclass)
- The class that is being inherited from
- Contains common properties and methods
- In Java this is called the "superclass"

### Child Class (Subclass)
- The class that inherits from another class (superclass)
- Inherits properties and methods from the parent
- Can add its own unique properties and methods (specialization)
- Can override (replace) methods from the parent

## Benefits of Inheritance

1. **Code Reuse**: Write common code once in the superclass
2. **Consistency**: All child classes share the same interface
3. **Maintainability**: Changes to parent class affect all children
4. **Extensibility**: Easy to add new types without changing existing code

## Example Structure

```
Vehicle (superclass)
├── Car (subclass)
├── Motorcycle (subclass)
└── Truck (subclass)
```

All vehicles might have (superclass properties):
- Engine
- Wheels
- Start method
- Stop method

But each type can have unique features (subclass properties):
- Car: 4 doors, air conditioning
- Motorcycle: 2 wheels, handlebars
- Truck: cargo bed, towing capacity

Inheritance helps us organize our code in a logical, hierarchical way that mirrors how we think about the real world. It can be a powerful tool for code reuse and organization.

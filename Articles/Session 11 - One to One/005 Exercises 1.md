# Association Exercises

Practice implementing one-to-one association relationships in Java with these fun and interesting exercises.

## Exercise 1: Wizard and Wand

Create a `Wizard` class and a `Wand` class with a one-to-one association. The wizard can cast spells using their wand, and the wand has magical properties.

### Requirements:
- `Wand` class with properties: wood type, core material, and power level
- `Wizard` class with properties: name and associated wand
- Method for casting a spell, on the wizard. This method takes a spell name, and the required power level. Check if the wand's power level is sufficient to cast the spell. If it is, cast the spell, and print a message for the effect. If it is not, print some kind of error message.
- Ability to change wands (showing loose coupling)


### UML Diagram:

Below you will find the UML diagram for the exercise.

```mermaid
classDiagram
    class Wizard {
        - name : String
        - wand : Wand
        + Wizard(name : String, wand : Wand)
        + castSpell(spellName : String, requiredPower : int) void
        + changeWand(newWand : Wand) void
        + toString() String
    }
    
    class Wand {
        - woodType : WoodType
        - coreMaterial : String
        - powerLevel : int
        + Wand(woodType : WoodType, coreMaterial : String, powerLevel : int)
        + getWoodType() WoodType
        + getCoreMaterial() String
        + getPowerLevel() int
        + getWandDescription() String
        + toString() String
    }

    class  WoodType 
    <<enum>> WoodType
    WoodType : OAK 
    WoodType : ELDER
    WoodType : HAWTHORN
    WoodType : CYPRESS
    WoodType : YEW
    
    
    Wizard --> Wand 
    Wand --> WoodType
```


### Example Output:
```
Gandalf casts 'Fireball' with his Oak wand (Phoenix feather core, Power: 85)
Wand changed! Gandalf now wields an Elder wand (Dragon heartstring core, Power: 95)
```

### Comment
In this exercise, note that the wand is an object, and the wizard has a reference to it. This is a one-to-one association. It does not make sense for a wizard to have multiple wands, in this example. And each wand is wielded by one wizard at a time. We can change the wand, making this a loosly coupled relationship, and thereby an association.


## Exercise 2: Detective and Case

Build a `Detective` class and a `Case` class where each detective works on one active case at a time. The case contains evidence and clues.

### Requirements:
- `Case` class with case number, crime type, evidence list, and status
- `Detective` class with name and current case
- Methods to investigate, add evidence, and solve cases
- Ability to take on new cases (closing the previous one)

### UML Diagram:

```mermaid
classDiagram
    class Detective {
        - name : String
        - badgeNumber : String
        - currentCase : Case
        + Detective(name : String, badgeNumber : String)
        + takeCase(newCase : Case) void
        + takeOffCase() void
        + addEvidence(evidence : String) void
        + solveCase() void
        + closeCase() void
        + toString() String
    }
    
    class Case {
        - caseNumber : String
        - crimeType : String
        - evidence : List~String~
        - status : String
        + Case(caseNumber : String, crimeType : String)
        + getCaseNumber() String
        + getCrimeType() String
        + addEvidence(evidence : String) void
        + getEvidence() List~String~
        + setStatus(status : String) void
        + getStatus() String
        + toString() String
    }
    
    Detective --> Case
```

For the `Detective` class, you have the following methods, with specified behaviour:

- `takeCase(newCase : Case) void`: This method takes a new case and assigns it to the detective.
- `takeOffCase() void`: This method takes the detectiveoff the current case. You do this by setting the current case to null.
- `addEvidence(evidence : String) void`: This method adds evidence to the current case, so the method will have to call the `addEvidence` method on the case object.
- `solveCase() void`: This method solves the current case. You do this by setting the status of the case to "SOLVED".
- `closeCase() void`: This method closes the current case. You do this by setting the status of the case to "CLOSED".
- `toString() String`: This method returns a string representation of the detective, including relevant information about the detective and the case. You might use the `toString` method on the case object to get the case information.
  

And for the `Case` class, you have the following methods, with specified behaviour:

- `addEvidence(evidence : String) void`: This method adds evidence to the case.
- `getEvidence() List<String>`: This method returns the evidence list.
- `setStatus(status : String) void`: This method sets the status of the case.
- `getStatus() String`: This method returns the status of the case.
- `toString() String`: This method returns a string representation of the case, including relevant information about the case.
  

### Example Output:
```
Detective Sherlock Holmes working on Case #2024-001
Crime: Theft, Status: Under Investigation
Evidence found: Fingerprints, Security footage
Case #2024-001 SOLVED! Detective Holmes can now take on Case #2024-002
```


## Exercise 3: Detective and Case version 2

Make a copy of your detective and case classes from the previous exercise.

Now we expand a little bit. Instead of the `evidence` being a list of strings, it is a list of `Evidence` objects. What should an Evidence object contain? You could things like include:

- `description` (String)
- `type` (String)
- `date` (LocalDate)
- `location` (String)
- `suspect` (String)
- `weapon` (String)
- `time` (LocalTime)
- `latitude` (double)
- `longitude` (double)
- `altitude` (double)
- `speed` (double)


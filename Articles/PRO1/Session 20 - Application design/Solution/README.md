# Extraterrestrial Exploration System

This is a complete implementation of the space exploration management system described in the "Session 20 - Application design" learning path.

## Project Structure

```
src/
└── extraterrestrialexploration/
    ├── domain/
    │   ├── Alien.java
    │   ├── Encounter.java
    │   ├── Explorer.java
    │   └── Planet.java
    ├── persistence/
    │   ├── DataContainer.java
    │   ├── DataManager.java (interface)
    │   └── FileDataManager.java
    ├── presentation/
    │   ├── MainMenu.java
    │   ├── RunApplication.java
    │   └── planetmanagement/
    │       ├── AddPlanet.java
    │       ├── DeletePlanet.java
    │       ├── ListPlanets.java
    │       ├── PlanetMenu.java
    │       ├── ShowPlanet.java
    │       └── UpdatePlanet.java
    └── test/
        └── persistence/
            ├── TestDeletePlanet.java
            ├── TestGetAllPlanets.java
            ├── TestSaveAndLoadPlanet.java
            └── TestUpdatePlanet.java
```

## Architecture

The system follows a **layered architecture** pattern with three main layers:

### 1. Domain Layer
Contains the core business entities:
- **Planet**: Represents a planet with climate, distance, atmosphere, and life indicators
- **Alien**: Represents an alien species
- **Explorer**: Represents a space explorer
- **Encounter**: Represents an encounter between an explorer and an alien on a planet

All entities:
- Implement `Serializable` for persistence
- Have auto-generated IDs
- Include getters, setters, and `toString()` methods

### 2. Persistence Layer
Handles data storage and retrieval using binary files:
- **DataManager** (interface): Defines CRUD operations for all entities
- **FileDataManager**: Implements the interface using binary file storage
- **DataContainer**: Wrapper class for serializing collections of entities

Features:
- Automatic ID generation
- Binary file persistence (`data.bin`)
- Full CRUD operations for all entity types

### 3. Presentation Layer
Console-based user interface:
- **RunApplication**: Main entry point
- **MainMenu**: Top-level menu
- **PlanetMenu**: Sub-menu for planet management
- Feature classes for each operation:
  - AddPlanet
  - ShowPlanet
  - ListPlanets
  - UpdatePlanet
  - DeletePlanet

## How to Run

### Running the Application
```bash
javac src/extraterrestrialexploration/presentation/RunApplication.java
java extraterrestrialexploration.presentation.RunApplication
```

### Running Tests
Each test can be run independently:
```bash
java extraterrestrialexploration.test.persistence.TestSaveAndLoadPlanet
java extraterrestrialexploration.test.persistence.TestDeletePlanet
java extraterrestrialexploration.test.persistence.TestUpdatePlanet
java extraterrestrialexploration.test.persistence.TestGetAllPlanets
```

## Features Implemented

### Planet Management (Complete)
- ✓ Add new planets
- ✓ View planet details by ID
- ✓ List all planets
- ✓ Update planet information
- ✓ Delete planets

### Extensibility
The system is designed to easily add management features for:
- Aliens
- Explorers
- Encounters

The persistence layer already includes full CRUD operations for all entity types. To add management features, simply create new menu classes following the pattern established in `planetmanagement/`.

## Design Patterns Used

1. **Layered Architecture**: Clear separation of concerns between domain, persistence, and presentation
2. **Interface Segregation**: DataManager interface allows for different persistence implementations
3. **Single Responsibility**: Each class has one clear purpose
4. **Menu Pattern**: Consistent menu structure throughout the application

## Data Storage

- Data is stored in a binary file named `data.bin` in the project root
- The file is automatically created on first run
- All entity collections are serialized together in a `DataContainer`

## Error Handling

- Input validation throughout the UI
- Try-catch blocks for I/O operations
- User-friendly error messages
- Graceful failure handling

## Future Enhancements

As suggested in the learning path, students can extend this system by:
1. Adding management menus for Aliens, Explorers, and Encounters
2. Implementing the "Move Explorer" feature
3. Adding search and filter capabilities
4. Implementing more sophisticated ID generation
5. Adding data validation rules
6. Creating additional test classes for other entity types


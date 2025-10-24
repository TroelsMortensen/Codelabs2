# The Planet management menu

Now we start on the planet manage menu. This requires the class itself, and updating the main menu to include it.

## Creating the PlanetMenu class

We will start with the class, and add the method for handling the planet management menu. We will also leave the method empty for now, and move back to update the main menu.

Start by creating the class in the `presentation` package. Here is your current application structure:

```
📁src/
├── 📁presentation/
│   ├── 📄MainMenu.java
│   ├── 📄RunApplication.java
│   └── 📁planetmanagement/
│       └── 📄PlanetMenu.java
├── 📁persistence/
│   ├── 📄DataContainer.java
│   ├── 📄DataManager.java
│   └── 📄FileDataManager.java
├── 📁domain/
│    ├── 📄Alien.java
│    ├── 📄Encounter.java
│    ├── 📄Explorer.java
│    └── 📄Planet.java
└── 📁test/
    └── 📁persistence/
        ├── 📄TestSaveAndLoadPlanet.java
        ├── 📄TestDeletePlanet.java
        ├── 📄TestUpdatePlanet.java
        └── 📄TestGetAllPlanets.java
``` 

## Adding the method for the planet management menu

In the PlanetMenu class, add a method called `handlePlanetMenu()`. Leave the body empty for now.

```java
public class PlanetMenu {
    public void handlePlanetMenu() {
        // TODO: Implement the planet management menu
    }
}
```

## Update main menu

Back in the MainMenu class, add a new menu item to the main menu, called "Planet Management". This should instantiate a new PlanetMenu object, and call the handlePlanetMenu() method:

```java{20,30,31}
public class MainMenu {
    private Scanner scanner;
    
    public MainMenu() {
        this.scanner = new Scanner(System.in);
    }
    
    public void handleMainMenu() {
        
        while (true) {
            printMainMenu();
            int choice = getUserChoice();
            
            switch (choice) {
                case 1 -> {
                    System.out.println("Goodbye!");
                    return;
                }
                case 2 -> {
                    new PlanetMenu().handlePlanetMenu();
                }
                default -> System.out.println("Invalid choice. Please try again.");
            }
        }
    }
    
    private void printMainMenu() {
        System.out.println("\n=== Main Menu ===");
        System.out.println("1. Planet Management");
        System.out.println("2. Exit");
        System.out.print("Enter your choice: ");
    }
    
    private int getUserChoice() {
        // TODO: Read user input and return as integer
        // TODO: Handle invalid input (non-numeric)
        return 0; // Placeholder
    }
}
```

## Update the planet management menu

Back to the PlanetMenu class, add a method called `printPlanetMenu()`. This method should print the planet management menu. For now, you can just have the option for "Back to Main Menu".

Implement the `handlePlanetMenu()` method, which should print the planet management menu, and read the user's choice. If the user chooses "Back to Main Menu", the program should return to the main menu.

Handle invalid input by the user, and print an error message.

The `handlePlanetMenu()` method will have a very similar structure to the `handleMainMenu()` method seen above.

## Test

You should now run your program, and verify that you can navigate to the planet management menu, and back to the main menu.
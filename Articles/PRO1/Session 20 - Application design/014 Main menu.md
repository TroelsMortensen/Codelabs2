# The Main Menu

For each of the menu points on the previous page (and again below), we will create a new class.

```
Main Menu
    - Manage Planets
        - Add Planet
        - Update Planet
        - Delete Planet
        - View Planet
        - List Planets
        - Back to Main Menu
    - Manage Explorers
        - Add Explorer
        - Update Explorer
        - Move Explorer
        - Delete Explorer
        - View Explorer
        - List Explorers
        - Back to Main Menu
    - Manage Aliens
        - Add Alien
        - Update Alien
        - View Alien
        - List Aliens
        - Delete Alien
        - Back to Main Menu
    - Manage Encounters
        - Add Encounter
        - Update Encounter
        - Delete Encounter
        - View Encounter
        - List Encounters
        - Back to Main Menu
    - Exit
```

That means we have a class responsible for just printing out the main menu, and accepting the users choice for which sub-menu to enter. Each sub-menu will list all the actions, and the user can choose which action to perform. Then a class for each action. Yeah, that's a lot of classes. And many, small classes are actually a good thing. Whenever you need to change something, it should be very easy to find. You don't have to scroll through hundreds, or even thousands of lines of code to find the thing you need to change.

Small stuff is great. 

## Creating the Main Menu class

So, let's start with the main menu. Create a new class called `MainMenu`, in the `presentation` package. You are very welcome to further divide the presentation package into sub-packages, if you want to. For example by entity type. But the main menu does not belong in a sub-package.

Here is your current application structure:

```console
📁src/
├── 📁presentation/
│   └── 📄MainMenu.java
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

## Filling out the class

Let's add a method to the MainMenu class, called `handleMainMenu()`.

This method should:

1. Print out the main menu, start with just one item: "Exit".
2. Read the user's choice.
3. If the user chooses "Exit", the program should terminate. You can do that by returning from the method.

You can either request the user to type in words, or just use numbers. It is up to you.

You should check for the input in a switch statement.

You should verify the input is a valid choice. If it is not, you should print an error message and ask the user to try again.

Here is some of the code:

```Java
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
                default -> System.out.println("Invalid choice. Please try again.");
            }
        }
    }
    
    private void printMainMenu() {
        System.out.println("\n=== Main Menu ===");
        System.out.println("1. Exit");
        System.out.print("Enter your choice: ");
    }
    
    private int getUserChoice() {
        // TODO: Read user input and return as integer
        // TODO: Handle invalid input (non-numeric)
        return 0; // Placeholder
    }
}
```

The `return` statement in line 17 is used to exit the method. In this case, we are exiting the while loop, and returning from the method. That leads us back to the main method in the RunApplication class, and the program will terminate. See below.

## Add a main method

Now, to test this, we should create a class to actually run the program, and show the main menu. Create a new class called `RunApplication`, in the `presentation` package.

Here is your current application structure:

```
📁src/
├── 📁presentation/
│   ├── 📄MainMenu.java
│   └── 📄RunApplication.java
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

The RunApplication class should have a main method, which creates a new MainMenu object, and calls the handleMainMenu() method. 

Try it out. You should see the main menu, and be able to exit the program.
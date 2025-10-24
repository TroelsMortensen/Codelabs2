# First tests

Now you should have a FileDataManager class, which can save a planet, and retrieve a planet again. It is time to test if it works.

> Schrödinger's cat in its box is both dead and alive, until you open the box.\
> Schrödinger's software both works and doesn't work, until you test it.

## Test package

Generally, we will separate tests from the rest of the code. On second semester, we will explore this further.

For now, create a new package called "test" in the src directory, and a new package called "persistence" in the test package:

```{12}
📁src/
├── 📁presentation/
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
```

I now realize the packages above are not ordered alphabetically. This annoys me slightly, but it is what it is. I will _probably_ survive this.

In the `test/persistence` package, create a new class called "TestSaveAndLoadPlanet" with a main method. This main method should have two try catch blocks. The first block will add data, the second will load it.
Just catch `Exception` in the catch blocks.

```{13}
📁src/
├── 📁presentation/
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
        └── 📄TestSaveAndLoadPlanet.java
```


**First** try block should:

1) Create a new FileDataManager object
2) Create a new Planet object
3) Add the planet to the FileDataManager

At this point, there should be a .bin file, with data in it.

**Second** try block should:

1) Create a new FileDataManager object
2) Get the planet from the FileDataManager (you will need the planet id, which is set from in the FileDataManager, however, the Planet object you created in the main method, will now have the id set)
3) Print out the planet (do you have a toString() method?)

If you don't have a toString() method, you will see that the initial Planet and the loaded Planet are not the same. If you do have a toString() method, you will see that the two planets have the same content. Why is this expected and reasonable?

Here is the template:

```Java
public class TestSaveAndLoadPlanet {
    public static void main(String[] args) {
        try {
            // TODO: Create a new FileDataManager object
            // TODO: Create a new Planet object
            // TODO: Add the planet to the FileDataManager
        } catch (Exception e) {
            System.out.println("Error saving data: " + e.getMessage());
            return;
        }
        
        try {
            // TODO: Create a new FileDataManager object
            // TODO: Load the data from the FileDataManager
            // TODO: Print out the planet (do you have a toString() method?)
        } catch (Exception e) {
            System.out.println("Error loading data: " + e.getMessage());
            return;
        }
        
        System.out.println("Test was successful. Data saved and loaded successfully");
    }
}
```

The primary point of the catch blocks are just to make sure, we use two different instances of the FileDataManager class.
In the case of an exception, the test is considered a failure whether we catch the exception, or if we just let the program crash.
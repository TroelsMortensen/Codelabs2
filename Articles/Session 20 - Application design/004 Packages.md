# Application packages

We start by creating the packages for the application. We will leave them empty for now, but add to them along the way. You may also add further sub-packages inside each layer, to keep your code organized.

Somewhere, in your current project, or a new, create a new package for the application. Call it `spaceexplorer`.

The structure of the packages should look like this (don't create any classes yet):

```
📁src/
└── 📁extraterrestrialexploration/
    ├── RunApplication.java
    ├── 📁model/
    │   ├── 📄Alien.java
    │   ├── 📄Encounter.java
    │   ├── 📄Explorer.java
    │   └── 📄Planet.java
    ├── 📁persistence/
    │   ├── 📄DataContainer.java
    │   ├── 📄DataManager.java
    │   └── 📄FileDataManager.java
    └── 📁presentation/
        └── 📄MainMenu.java
```

I include some of the classes just to give you an idea of the structure. But don't create any classes yet. Just the packages for now.

I have also named the package differently from the previous pages. That's because the previous version, with presentation, persistence and domain, are somewhat broader in what they will contain. In this application, we will have a more specific structure.\
We will have the **model** classes, representing the real-world objects, the **persistence** classes for saving and loading the data, and then the **ui** classes for the console user interface.
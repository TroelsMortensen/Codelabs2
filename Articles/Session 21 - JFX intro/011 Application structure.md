# Application structure

Enough with simple UI elements. You are now ready to build slightly larger applications.

That requires _structure_. Organizing your code. Somewhat similar to what you did in the previous learning path.

Watch the below video to see how to structure your application into three parts: start up, presentation, and persistence.

<video src="https://youtu.be/tjq0XfaY6Zg"></video>

[The code is on GitHub](https://github.com/TroelsMortensen/JavaFxExamples/tree/master/SimpleAppStructure)

In short, your JavaFX application should have three main parts:

```console
📁src/
├── 📁presentation/
├── 📁persistence/
└── 📄StartUp.java
```

This structure is also relevant for your semester project, though you may also want a domain layer (package), for your domain entities:

```console
📁src/
├── 📁domain/
├── 📁presentation/
├── 📁persistence/
└── 📄StartUp.java
```

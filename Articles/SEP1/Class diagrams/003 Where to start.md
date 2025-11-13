# Where to start

The class diagram shows your entire system, all the classes involved. Their fields and methods, and so on.

## Packages
You have been introduced to an approach to organize your code into packages. This is a good starting point.

Sometime like...


```console
📁src/
└── 📁yourprojectname/
    ├── 📄RunApplication.java
    ├── 📁domain/
    ├── 📁persistence/
    └── 📁presentation/
```

This is a good starting point, no matter which project you are working on. On first semester. Later semesters will require more packages, and an expanded structure.

You should _probably_ also add some sub-packages inside each layer, to keep your code organized.

## Domain model first
A good starting point is looking at the domain model. You are going to create classes based on the entities in the domain model.\
Define the field variables, judge which types they should be, and so on.

Let's call these classes _domain entities_. Sometimes they are just called the model, or something similar. But these are the classes that represent the real-world objects.

Then you may need methods on your domain entities. These are the operations that can be performed on the objects.
Typically, getters and setters for the field variables, and maybe some other methods.

## But then what

You will also need classes for the _user interface_, and usually some classes for the _persistence_, to save and load the data. Where you start is less obvious, and probably also less important. 

You have seen one approach for persistence, using a file, with the `DataManager` interface and the `FileDataManager` class. And then the `DataContainer`. This is a common approach, which can also work for most of your systems.

## Persistence layer

So, define the interface, with whatever methods you will need to add, update, delete, and get data, for each of your domain entities. Add the implementing class, and the data container class.\
This should be pretty much copy paste from the previous theory.

## User interface layer

Now, you need to look at your user stories. Consider which of them will require a dedicated view. And which can be rolled in together.

Consider:
- view a list of planets
- deleting a planet

Is this two different views, or one view? You _could_ have two different views, one for listing planets, and one for deleting planets. But you _could_ also have one view that lists all planets, e.g. in a table, which includes a delete button per row.

```
┌─────────────────────────────────────────────────────────────┐
│                    Planet List View                         │
├─────────────────────────────────────────────────────────────┤
│  ┌───────────────────────────────────────────────────────┐  │
│  │ Name          │ Type      │ Distance   │ Moons │      │  │
│  ├───────────────┼───────────┼────────────┼───────┼──────┤  │
│  │ Mercury       │ Rocky     │ 57.9M km   │ 0     │  X   │  │ 
│  ├───────────────┼───────────┼────────────┼───────┼──────┤  │
│  │ Venus         │ Rocky     │ 108.2M km  │ 0     │  X   │  │ 
│  ├───────────────┼───────────┼────────────┼───────┼──────┤  │
│  │ Earth         │ Rocky     │ 149.6M km  │ 1     │  X   │  │ 
│  ├───────────────┼───────────┼────────────┼───────┼──────┤  │
│  │ Mars          │ Rocky     │ 227.9M km  │ 2     │  X   │  │ 
│  ├───────────────┼───────────┼────────────┼───────┼──────┤  │
│  │ Jupiter       │ Gas Giant │ 778.5M km  │ 95    │  X   │  │ 
│  ├───────────────┼───────────┼────────────┼───────┼──────┤  │
│  │ Saturn        │ Gas Giant │ 1.43B km   │ 146   │  X   │  │ 
│  └───────────────┴───────────┴────────────┴───────┴──────┘  │
└─────────────────────────────────────────────────────────────┘
```

But, try to go through your user stories, and see which of these require a dedicated view.\
Then define controller classes for each of these views, and an fxml to go with it.

Consider what you can do for each view, and define methods to represent these actions.




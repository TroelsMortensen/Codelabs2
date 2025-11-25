# Controller configuration

Very briefly, _dependency injection_ is a technique where a class is given its dependencies, rather than creating them itself. Usually this means it accepts them as constructor parameters.

Consider first the case of a class, `SomeClass`, that is dependent on another class, `OtherClass`. This is a dependency (in this case, specifically, it's an association). And `SomeClass` creates an instance of `OtherClass` itself.


```java
public class public class SomeClass 
{
    private OtherClass otherClass;
    public SomeClass() 
    {
        this.otherClass = new OtherClass();
    }
}
```

The above is a common starting point. But it is less _flexible_. I won't dig too much into details, we will explore this more in the next semester.

But the other approach is to create the `OtherClass` instance outside of `SomeClass`. And then pass it to `SomeClass` as a constructor parameter. Like this:

```java
public class SomeClass 
{
    private OtherClass otherClass;
    public SomeClass(OtherClass otherClass) 
    {
        this.otherClass = otherClass;
    }
}
```

In this case, `SomeClass` is dependent on `OtherClass`. And it is given `OtherClass` as a constructor parameter. This is dependency injection.

I can then create a sub-class of `OtherClass`, with slightly different behaviour, and pass that in instead. This is the power of polymorphism. Still, `SomeClass` will still only know about the `OtherClass` class, so nothing needs change in the `SomeClass` class.

This page explains how to configure the controllers in the JavaFX application, using dependency injection. Watch the below video to see how this is done.

## Controller configuration

Most of the JavaFX controllers will need to be configured, i.e. they need some other class to function. In my examples, and probably your semester project too, most controllers will need a `DataManager` to function. They need to store and retrieve data, which is persisted in a file.\
In some rarer cases, a specific controller will need some other class to function. For example, the `LoginController` might need a `UserManager` to function, and maybe this `UserManager` then keeps track of who is currently logged in.

### Current approach

So far, each controller has created its own dependencies, either in a parameterless constructor, or in an `initialize` method:

```java
public class SomeController  implements Initializable
{
    // fields
    private DataManager dataManager;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle)
    {
        this.dataManager = new ListDataManager();
    }
}
```

All my many controllers will have a similar setup. But, this is limiting:

- If I want to change the data manager, to e.g. `FileDataManager`, I would need to change each controller. That can potentially be a lot of places. What if I forget one?
- If I want to let two controllers share some data, I might do that by giving both access to a `ViewState` class. If each controller creates its own instance of this `ViewState` class, I would have to make part of its data static, which is generally not recommended.
- Testing, while out of scope, is more difficult.

### Providing the dependencies

A _very_ common approach is instead to create the dependencies in a central place, and then hand them over to the controllers.

The idea is:
- Load an fxml file
- The controller is also created, by JavaFX, at this point
- Call "set-methods" on the controller, to provide the dependencies, e.g. `setDataManager(DataManager dataManager)`
- The controller can then use the dependencies, e.g. `this.dataManager.loadData();`
- The controller will know about the _interface_, i.e. `DataManager`, not the concrete class, `ListDataManager` or `FileDataManager`.	

This is a very common approach, and it is used in many frameworks, including JavaFX.

Now, instead of multiple set-methods, I will introduce a single `init()` method, which will be called just after the controller is created. This init method will take a `DataManager` as a parameter, and it will set the data manager on the controller.

### The ControllerConfigurator class

For convenience, I am creating a `ControllerConfigurator` class, which will be responsible for creating the `DataManager` and then calling the `init()` method on the controller.

Here is the central piece of code:

```java
public class ControllerConfigurator
{
    // private static DataManager dataManager;

    public static void configure(Object controller)
    {
        if(controller == null) return;
        switch(controller)
        {
            case AddAuthorController ctrl -> ctrl.init(getDataManager());
            case AddBookController ctrl -> ctrl.init(getDataManager());
            case AddShelfController ctrl -> ctrl.init(getDataManager());
            case SelectShelfController ctrl -> ctrl.init(getDataManager());
            case ViewShelfController ctrl -> ctrl.init(getDataManager());
            default -> throw new RuntimeException("Controller of type '" + controller.getClass().getSimpleName() + "' not valid.");
        }
    }

    private static DataManager getDataManager()
    {
        return new ListDataManager();
    }
}
```

- A controller is passed in as parameter.
- I use the switch statement to figure out exactly which controller is being passed in.
- There is an implicit cast from `Object` to the specific controller type, now the variable `ctrl` is of the specific controller type.
- I call the `init()` method on the controller, passing in the `DataManager`.
- The `DataManager` is created in a private static method, `getDataManager()`. This is the _only_ place across my entire application that creates the `DataManager`. If I need to change from List to File, I only need to change _this one place_.

The `getDataManager()` method is responsible for creating the `DataManager`. In this case, it creates a `ListDataManager`, but it could be any other implementation of the `DataManager` interface.

In this case, all my controllers are being init'ed the same way, by just getting a `DataManager`. So here, it might be overkill to have a `ControllerConfigurator` class. But once your system expands, many controllers will need different dependencies, and this class can then manage the configuration of each controller in a specific way.

For example, i might update the LoginController's init method to

```java
public void init(DataManager dataManager, UserManager userManager)
```



Watch the below video to see how this is done.

<video src="https://youtu.be/AUNqzm4AJxo"></video>

[Here is the code from the video](https://github.com/TroelsMortensen/JavaFxExamples/tree/master/ControllerConfiguratorExample)

This approach is a small step up from the previous page, and it may not be all that relevant for your semester project.

It _does_ allow you to start out with a ListDataManager, and later swap it out for the FileDataManager, should you require so.

We _will_ use this approach next semester.

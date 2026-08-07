# Controller Factory

**Note: This page has been updated January 26, 2026**\
It used to be called "Controller configuration", but I have renamed it to "Controller Factory" to reflect the updated concept.


## Dependency Injection
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

And second semester, you will need to more fine grained configuration of controllers and their dependencies.

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
- Testing, while out of scope in this learning path, is more difficult.

### Providing the dependencies

A _very_ common approach is instead to create the dependencies in a central place, and then hand them over to the controllers. I.e. use dependency injection, as explained above.

The idea is:
- Instantiate an FXMLLoader
- Set the _controller factory_ on the FXMLLoader
- Load an fxml file
- JavaFX uses the _controller factory_ to create the controller, by calling the controllers constructor, and passing in the dependencies.
- The controller can then use the dependencies, e.g. `this.dataManager.loadData();`
- The controller will know about the _interface_, i.e. `DataManager`, not the concrete class, `ListDataManager` or `FileDataManager`.	

This is a very common approach, and it is used in many frameworks, including JavaFX.


So, what is this mythical _controller factory_? It is a class, which creates a given controller, and passes in the dependencies.

### The ControllerFactory class

The ControllerFactory class is responsible for creating a given controller, and passing in the dependencies. JavaFX passes in an argument to indicate which specific controller to create, and we just have a chain of if-statements to handle the different controllers.

Here is an example of a ControllerFactory class, which can create five different types of controllers.

```java
public class ControllerFactory implements Callback<Class<?>, Object>
{
    @Override
    public Object call(Class<?> controllerType)
    {
        if(controllerType == AddAuthorController.class) return new AddAuthorController(getDataManager());
        if(controllerType == AddBookController.class) return new AddBookController(getDataManager());
        if(controllerType == AddShelfController.class) return new AddShelfController(getDataManager());
        if(controllerType == SelectShelfController.class) return new SelectShelfController(getDataManager());
        if(controllerType == ViewShelfController.class) return new ViewShelfController(getDataManager());
        // add more in the future

        throw new RuntimeException("Controller of type '" + controllerType.getSimpleName() + "' is not supported!");
    }

    private DataManager getDataManager()
    {
        return new ListDataManager();
    }
}
```

So, let's start from the top.
- The interface `Callback<Class<?>, Object>` is from JavaFX. The generic template parameters `<Class<?>, Object>` basically means "call this method with a Class _type_, and return an Object". That _Object_ is the controller instance.\
The interface requires us to override the `call` method. The parameter here is the type of controller we must create. Don't worry too much about how `Class<?>` works, it is just a way to represent a class type.
- We have a chain of if-statements to handle the different controllers. If the controller type is `AddAuthorController`, we create a new `AddAuthorController` instance, and pass in the `DataManager`. If the controller type is `AddBookController`, we create a new `AddBookController` instance, and pass in the `DataManager`. And so on.\
I acknowledge this example is a bit boring, since we are just doing the same thing for each controller. But still, some controller in the future might need a different set of dependencies.
- I was unable to make this elegantly work with a switch statement, unfortunately.
- Every time a new controller is added to your program, you must add another if-statement.
- The `getDataManager()` method is responsible for creating the `DataManager`. In this case, it creates a `ListDataManager`, but it could be any other implementation of the `DataManager` interface.\
I have this method here, because now there is only _a single place in my entire application_ that creates a new instance of the `DataManager`. If I need to change from List to File, I only need to change _this one place_.

## Updating the ViewManager

The ViewManager is still responsible for loading fxml files, and some basic configuration. We need to update it to use the ControllerFactory.

Here is part of the ViewManager class, you can see the entire code in the link below, pointing to the GitHub repository.

```java{7}
public static void showView(String viewName, String argument)
{
    FXMLLoader loader = new FXMLLoader();
    loader.setLocation(ViewManager.class.getResource(fxmlDirectoryPath + viewName + ".fxml"));
    try
    {
        loader.setControllerFactory(new ControllerFactory());
        Parent root = loader.load();
        AcceptsStringArgument controller = loader.getController();
        controller.setArgument(argument);
        mainLayout.setCenter(root);
    }
    catch (Exception e)
    {
        // ... handle the exception ...
    }
}
```
Notice in line 7, we set the _controller factory_ on the FXMLLoader. I create a new instance of my ControllerFactory class, and pass it to the `setControllerFactory` method.

## Video

Watch the below video to see how this is done.

<video src="https://youtu.be/_vEapBhebPs"></video>

[Here is the code from the video](https://github.com/TroelsMortensen/JavaFxExamples/tree/master/17_ControllerFactoryExample)

This approach is a small step up from the previous page, and it may not be all that relevant for your semester project.

It _does_ allow you to start out with a ListDataManager, and later swap it out for the FileDataManager, should you require so.

We _will_ use this approach next semester.


## OPTIONAL:Improving the if-statements

We can improve the if-statements, by using a map to store the controller types and their corresponding classes. This is perhaps a more elegant solution, and it is more flexible, for example allowing us to add new controller configurations without having to change the code of the ControllerFactory class.

I leave it to you to implement this, as an exercise, should you be interested.

## OPTIONAL: Cleaning up the ViewManager

My current version of the ViewManager has three ways to open a view: `showView(String viewName)`, `showView(String viewName, String argument)`, and `showView(String viewName, Object argument)`. This has resulted in some duplication of code.\
I could keep the three methods, but extract the body into a single method, this would be a lot cleaner.

I do this in one of my later vidoes, should you be interested. Again, this is an optional exercise, and you are free to skip it.

<video src="https://youtu.be/gxKpus7t8w0"></video>

And the code is here: [GitHub repository](https://github.com/TroelsMortensen/JavaFxExamples/blob/master/19_ChangingViewThroughEvents/src/okayreads/presentation/core/ViewManager.java)
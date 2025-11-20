# Controller configuration

Very briefly, _dependency injection_ is a technique where a class is given its dependencies, rather than creating them itself. Usually this means it accepts them as constructor parameters.

Consider first the case of a class, `SomeClass`, that is dependent on another class, `OtherClass`. This is a dependency. And `SomeClass` creates an instance of `OtherClass` itself.

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

This page explains how to configure the controllers in the JavaFX application, using dependency injection. Watch the below video to see how this is done.

<video src=""></video>

This approach is a small step up from the previous page, and it may not be all that relevant for your semester project.

It _does_ allow you to start out with a ListDataManager, and later swap it out for the FileDataManager, should you require so.

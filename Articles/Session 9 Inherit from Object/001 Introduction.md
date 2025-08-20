# All classes are objects

This article implicitly deals with a concept called "inheritance". We will come back to this in details later, but for now, it is important to understand that all classes in Java inherit from the `Object` class. This means that every class you create is a subclass of `Object`, and thus, it has access to methods defined in `Object`.

All classes you ever create is an `Object`, which means all your classes will automatically include certain functionality. We will look at three methods, which all your classes get by default: 

* `equals()`
* `hashCode()`
* `toString()`.

You have already seen `toString()`, though I will just cover it again briefly.

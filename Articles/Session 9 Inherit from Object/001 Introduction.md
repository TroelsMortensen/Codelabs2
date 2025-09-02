# All classes are objects

This article implicitly deals with a concept called "inheritance". We will come back to this in details later, but for now, it is important to understand that all classes in Java inherit from the `Object` class. This means that every class you create is a "subclass" of `Object`, and thus, it has access to methods defined in `Object`. Consider this:

* All persons have a name. A student _IS A_ person. Therefore, every student has a name.
* All vehicles have a license plate. A car _IS A_ vehicle. Therefore, every car has a license plate.
* All birds have wings. A pigeon _IS A_ bird. Therefore, every pigeon has wings.
* All mammals have a heart. A dog _IS A_ mammal. Therefore, every dog has a heart.
* All employees at VIA has a via email. A teacher _Is AN_ employee. Therefore, every teacher has a via email.
* All books have an ISBN. A novel _IS A_ book. Therefore, every novel has an ISBN.
* All shapes have an area. A triangle IS A shape. Therefore, every triangle has an area.
* All containers have a capacity. A bottle _IS A_ container. Therefore, every bottle has a capacity.

We will get to this concept. For now, every class is an Object. An Object has certain methods, which are defined in the `Object` class. Therefore, every class you create will automatically have these methods.\
In this article, I will introduce you to three of these methods:

* `equals()`
* `hashCode()`
* `toString()`.

You have already seen `toString()`, though I will just cover it again briefly.
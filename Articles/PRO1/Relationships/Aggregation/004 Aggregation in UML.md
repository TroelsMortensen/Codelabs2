# Aggregation in UML

The aggregation relationship is represented in UML as an arrow with an **empty** (open) diamond at the start, and an open arrowhead at the end.

## One to one

```mermaid
classDiagram
    class Car {
        - make : String
        - model : String
        - engine : Engine
        + Car(make : String, model : String)
        + removeEngine() Engine
        + installEngine(engine : Engine) void
        + startCar() void
    }

    class Engine {
        - engineType : String
        - horsepower : int
        - fuelType : String
        + Engine(engineType : String, horsepower : int, fuelType : String)
        + start() void
        + getEngineSpecs() String
    }

    Car o--> " " Engine
```

Notice the empty diamond is at the "owner" side, and the open arrowhead is at the "owned" side. Here `Car` knows about `Engine`, but `Engine` does not know about `Car`. Notice also the field variable `engine` in the `Car` class.

We do not put a `1` on the relationship line for one-to-one. We conventionally leave out the multiplicity when aggregating a single object.

## One to many

We use the same empty diamond, and add a star at the arrow head:

```mermaid
classDiagram
    class Library {
        - libraryName : String
        - books : ArrayList~Book~
        + Library(libraryName : String)
        + addBook(book : Book) void
        + removeBook(book : Book) Book
    }

    class Book {
        - title : String
        - author : String
        - isbn : String
        + Book(title : String, author : String, isbn : String)
    }
    Library o--> "*" Book
```

## Recap

| Element | Meaning |
| --- | --- |
| Empty diamond (`◇──>`) | Aggregation |
| Diamond at the start | The whole / owner side |
| Arrowhead at the end | The part / owned side |
| No multiplicity | One (conventionally omitted) |
| `*` at arrow head | Many parts |



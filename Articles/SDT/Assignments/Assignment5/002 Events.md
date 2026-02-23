# Events

You may or may not need one or more classes to carry your data between a Subject and a Listener. We could call this a "Data Transfer Object" (DTO). You might use a record instead of a class.

And we could put these events in a nice and safe place in the architecture.

So, here's some food for thought.

## The deep reference

Given that the StockMarket notifies the system that a stock has been updated, you might consider putting the DTO together with the StockMarket.

I believe, I have recommended a package struture like this:

```
📁src/
└── 📁business/
    └── 📁stockmarket/
        ├── 📁events/
        │    └── 📄StockUpdateEvent.java
        └── 📄StockMarket.java
```

But now the presentation layer needs to reference something somewhat "deep" inside the business layer. This may not be a good idea.  
We may decide to restructure the internals of this particular part of the architecture, and that should ideally not affect other layers.

But an import statement in the presentation layer would have to be changed, if we move around the packages of the business layer.

Consider this "encapsulation" on package level. You have heard about this concept on class level. And it actually also applies on Module level, should you use those.

## The shallow reference

The opposite approach is to primarily "expose" classes/interfaces at the "boundary" or "surface" of the business layer. This is the "shallow reference" approach.

In this case, we would put the events package at the same level as the stockmarket package.

```
📁src/
└── 📁business/
    └── 📁events/
    │   └── 📄StockUpdateEvent.java
    └── 📁stockmarket/
        └── 📄StockMarket.java
```

Now the presentation layer can reference the events package directly, without having to go through the stockmarket package.

## Conclusion

You can pick the approach you prefer. I prefer the shallow reference approach, as it is more flexible and easier to maintain, given that I can restructure the internals of the business layer, without having to change the import statements in the presentation layer.

## Tying it to familiar ideas

- **Stable Dependencies / Dependency Rule**: Upper layers (like presentation) should preferably depend on the stable boundary of lower layers, not on internal package details. With shallow references, restructuring internals is less likely to affect imports in other layers.

- **Information hiding (Parnas)**: How the business layer organizes itself (e.g. sub-packages under `stockmarket`) is an internal design decision. Deep references expose that decision to other layers. Shallow references hide it better.

- **Public API vs internal packages**: A common approach is to treat certain packages (like `events`, `dtos`, or `api`) as the public surface of a layer, and the rest as internal. Deep references tend to couple to internals, while shallow references couple to the public surface.

Deep vs shallow is an informal, practical way to talk about this difference: depending on internals vs depending on the layer boundary.

## Parnas's Law

> Only what is hidden can be changed without risk.

[David L. Parnas](https://en.wikipedia.org/wiki/David_Parnas) is a foundational software engineering researcher, best known for the idea of information hiding in modular design.

In practical terms, his point is:
* A module should hide its internal design decisions.
* Other parts of the system should depend only on the module’s interface, not its internals.
* This reduces ripple effects when internals change.


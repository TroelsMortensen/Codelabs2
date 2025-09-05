# Introduction

You are being introduced to UML (Unified Modeling Language), throughout the course, and so, various parts have popped up at various times throughout the course.\
When you learned about classes, you saw UML for that. Then you learned about relationships, and saw UML for that. You learned about inheritance, and saw UML for that.

So, the UML teachings were spread out, over many learning paths.

This article aims to put it all in one place.

I also, eventually, plan on having small videos accompanying each page, explaining how to do that particular concept in Astah.

## Astah vs Mermaid

Some diagram examples in this article are created in Astah, and screenshot. Other examples are rendered directly using Mermaid UML (this is easier, and quicker for me).\
This is only to say, there may be small differences in how the diagrams might look. 

You do not have to care about Mermaid at all.

For comparison, here is a diagram as a screenshot from Astah:

![astah example](Resources/class-example.png)

And here is the same diagram using Mermaid:

```mermaid
classDiagram
    class Person{
        - age : int
        - name : String
        + Person(age : int, name : String)
        + greet() void
        + getName() String
        + setAge(newAge : int) void
    }
```
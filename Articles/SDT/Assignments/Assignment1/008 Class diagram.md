# Class diagram

Create a class diagram for your domain entities. Include the relevant packages as well.

As there are no associations between the entities, because of the foreign keys, you should instead use the dependency arrow.

```mermaid
classDiagram
    class Entity1 {
        - id : int
    }
    
    class Entity2 {
        - id : int
        - entity1Id : int
    }
    
    Entity2 ..> Entity1 
```

You should still add multiplicities, if relevant.
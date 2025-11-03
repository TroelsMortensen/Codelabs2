# Sequence

A sequence is multiple activities, or steps, one after another. You draw them as arrows, from one activity to the next.


1) Do this
2) Then do this
3) And then do that


And here is the diagram, which shows the sequence of activities.

```mermaid
flowchart TD
    A[Do this] --> B[Then do this]
    B --> C[And then do that]

    classDef activityBox fill:#ffffe0,stroke:#000000,stroke-width:2px,color:#000000,rx:10,ry:10
    class A,B,C activityBox
```
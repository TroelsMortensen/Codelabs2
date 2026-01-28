# States and Transitions

States and transitions are the fundamental building blocks of state machines. Understanding them is essential for modeling entity behavior.

## What are States?

A **state** is a discrete condition or situation that an entity can be in at a given time.

### Characteristics of States

- **Discrete** - States are distinct and separate (not continuous)
- **Mutually exclusive** - An entity can only be in one state at a time
- **Persistent** - A state persists until a transition occurs
- **Observable** - You can determine which state an entity is in

### Examples of States

- **Traffic Light**: Red, Yellow, Green
- **Door**: Locked, Unlocked
- **Order**: Pending, Processing, Shipped, Delivered, Cancelled
- **Stock**: Steady, Growing, Declining, Bankrupt, Reset
- **Document**: Draft, Review, Approved, Published
- **Game Character**: Idle, Walking, Running, Jumping, Attacking

### State Names

State names should be:
- **Clear and descriptive** - "Processing" is better than "Proc"
- **Noun or adjective** - States describe conditions, not actions
- **Consistent** - Use consistent naming conventions
- **Distinct** - Each state should be clearly different from others

## What are Transitions?

A **transition** is a change from one state to another. It represents the entity moving from its current state to a new state.

### Characteristics of Transitions

- **Directed** - Transitions go from one state to another (one direction)
- **Triggered** - Something causes the transition (an event or condition)
- **Instantaneous** - The transition happens immediately (conceptually)
- **Complete** - The entity is fully in the new state after the transition

### Transition Notation

In state diagrams, transitions are shown as arrows:

```
State1 ──────> State2
```

The arrow points from the source state to the target state.

## Events

An **event** is something that happens that can trigger a transition. Events are the "causes" that make state changes occur.

### Types of Events

- **User actions** - Button click, form submission, menu selection
- **System events** - Timer expiration, data received, error occurred
- **External events** - Message received, sensor triggered, API call completed
- **Internal events** - Condition met, threshold reached, process completed


## Summary

- **States** are discrete conditions an entity can be in
- **Transitions** are changes from one state to another
- **Events** trigger transitions
- **Valid transitions** are explicitly defined in the state machine
- **Invalid transitions** are not shown and should be prevented
- **State transition paths** show sequences of states an entity can follow

Understanding states and transitions is the foundation for modeling and understanding state machines.

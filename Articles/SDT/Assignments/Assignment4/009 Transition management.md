# OPTIONAL CHALLENGE: The Transition Manager


This part is optional. You may skip it.

With the common approach to the State Pattern, most state classes need to know about the other state classes. This can be a problem, as it makes the state classes tightly coupled. Each new state added _must_ require at least one other state class to be updated. Otherwise, how would the context transition to the new state?

This can be solved by using a Transition Manager. This class will know about all the states, and will be responsible for managing the transitions between them. Sure, this will also require updates whenever a new state is added, but it is centralized, one place, always the same to update. That's a decent trade-off.

## Introducing the Transition Manager

The concept is, each State class will have a reference to the Transition Manager. 

Then the Transition Manager...

* must somehow keep track of each possible state, and which _other_ states can be transitioned to.
* must define when a transition is valid.
* must provide a method to transition to a new state. This method will regularly be called by the State classes, and is then responsible for checking if the transition is valid, if it should happen, and if so, to transition to the new state.

Either:
- The Transition Manager will set the state on the context. Or
- The Transition Manager will return the new state, and who-ever called the Transition Manager will set the state on the context. It was probably a State class that called the Transition Manager.

Depending on the particular state machine, the strategy for implementing the transition manager will be different.

In our particular case, we can illustrate the transitions as a table:

| From \ To | Steady | Growing | Declining |
|-----------|--------|---------|-----------|
| **Steady**   | 80% | 10% | 10% |
| **Growing**  | 20% | 75% | 5%  |
| **Declining**| 25% | 10% | 65% |

Adding a new state will require updating the transition manager with a new column and row in the table, to define the posibility of transitioning to the new state from each of the other states. And _from_ the new state, to each of the other states.

If a transition is not possible, you can use a probability of 0. Then, either return null to indicate no new state, or just return a new instance of the current state (which only works, if your State classes have no field variables).

So, after each tick, the Transition Manager will check if a transition should happen. If so, it will transition to the new state.
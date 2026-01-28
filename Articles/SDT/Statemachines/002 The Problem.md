# The Problem: Unclear and Unmanaged States

Without a clear state machine model, managing entity states becomes problematic. States become unclear, transitions are undefined, and invalid states can occur.

## The Problem: Unclear State Management

When entities have states but those states aren't modeled as a state machine, several problems arise:

### Problem 1: Unclear Valid States

Without a state machine, it's unclear what states are actually valid for an entity.

Consider a `Stock` entity with a `currentState` field stored as a string. What are the valid values?

- "Steady"?
- "steady"?
- "STEADY"?
- "Steady State"?
- "Stable"?
- "Normal"?

Without a state machine, you might:
- Use different names in different parts of the code
- Have typos that create invalid states
- Not know all the possible states
- Have states that are semantically the same but named differently

### Problem 2: Invalid State Values

When states are stored as strings or unmanaged values, invalid states can easily occur:

- **Typos**: "Steady" vs "Steady " (extra space) vs "Steedy" (typo)
- **Case sensitivity**: "Steady" vs "steady" vs "STEADY"
- **Inconsistent naming**: "Growing" vs "Grows" vs "Growth"
- **Undefined states**: A state that shouldn't exist but does due to a bug

These invalid states can cause:
- Bugs that are hard to find
- Unexpected behavior
- System crashes
- Data corruption

### Problem 3: Unclear Valid Transitions

Without a state machine, it's unclear which state transitions are valid.

For example, in a stock trading game:
- Can a stock go directly from "Steady" to "Bankrupt"?
- Can a stock go from "Bankrupt" back to "Growing"?
- Can a stock be "Reset" from any state, or only from "Bankrupt"?

Without a state machine, you might:
- Allow invalid transitions (e.g., "Bankrupt" → "Growing")
- Miss valid transitions (e.g., "Declining" → "Reset")
- Have inconsistent transition rules in different parts of the code
- Create bugs where entities end up in impossible states

### Problem 4: Hard to Understand and Maintain

Without a state machine model, understanding the system's behavior requires reading through code, which is:

- **Time-consuming** - You have to trace through multiple methods
- **Error-prone** - Easy to miss edge cases or special conditions
- **Incomplete** - Code might not show all possible states or transitions
- **Scattered** - State logic might be spread across many files

### Problem 5: No Visual Representation

Without a state machine diagram, you can't easily:
- See all states at a glance
- Understand the flow between states
- Identify missing transitions
- Communicate behavior to others
- Validate that the implementation matches the design

## Example: The Stock Entity Problem

Let's consider the `Stock` entity from Assignment 1, which has a `currentState` stored as a string.

### Without a State Machine

The state is just a string field. You might have code like:

```
Stock has currentState: "Steady" | "Growing" | "Declining" | "Bankrupt" | "Reset"
```

**Problems:**
- What if someone sets it to "Steady " (with a space)?
- What if someone sets it to "growing" (lowercase)?
- What if someone sets it to "Inactive" (a state that doesn't exist)?
- Can a stock go from "Steady" directly to "Bankrupt"?
- Can a stock go from "Bankrupt" to "Growing"?
- What triggers the transition from "Growing" to "Declining"?

Without a state machine, these questions are unanswered or answered inconsistently across the codebase.

### With a State Machine

A state machine would clearly define:

- **Valid states**: Steady, Growing, Declining, Bankrupt, Reset
- **Valid transitions**: 
  - Steady → Growing (when price starts rising)
  - Steady → Declining (when price starts falling)
  - Growing → Steady (when price stabilizes)
  - Growing → Declining (when price reverses)
  - Declining → Steady (when price stabilizes)
  - Declining → Bankrupt (when company fails)
- **Invalid transitions**: 
  - Bankrupt → Growing (impossible - company is gone)
  - Steady → Bankrupt (usually requires going through Declining first)

This makes the behavior clear, testable, and maintainable.



## The Consequences

When states are unclear or unmanaged:

1. **Bugs** - Invalid states cause runtime errors or unexpected behavior
2. **Inconsistency** - Different parts of the system handle states differently
3. **Maintenance burden** - Hard to understand and modify state-related code
4. **Testing difficulty** - Hard to test all state combinations
5. **Communication problems** - Team members have different understandings
6. **Documentation gaps** - No clear way to document state behavior
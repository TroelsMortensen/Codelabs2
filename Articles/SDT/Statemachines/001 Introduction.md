# Introduction to State Machines

Welcome to **State Machines**! This is a powerful modeling concept that helps you understand and design systems where entities can exist in different states and transition between them.

## What is a State Machine?

A **state machine** (also called a finite state machine or FSM) is a model/diagram that describes the behavior of an entity by defining:
- **States** - The distinct conditions or situations the entity can be in
- **Transitions** - How the entity moves from one state to another
- **Events** - What triggers these transitions

### The Core Idea

Think of a state machine as a map that shows:
- Where an entity can be (its possible states)
- How it can move between states (valid transitions)
- What causes it to move (events, triggers, or conditions)

An entity can only be in **one state at a time**, and it moves between states based on specific events or conditions.

## Real-World Analogies

State machines are everywhere in the real world. Here are some familiar examples:

### Traffic Light

A traffic light is a simple state machine:

- **States**: Red, Yellow, Green
- **Transitions**: Red → Green → Yellow → Red (in a cycle)
- **Events**: Timer events that trigger the transitions

The traffic light can only be in one state at a time (it can't be both red and green simultaneously), and it follows a specific pattern of transitions.

### Vending Machine

A vending machine has states like:

- **Idle** - Waiting for money
- **Collecting Money** - User inserting coins
- **Dispensing** - Product being dispensed
- **Out of Stock** - No products available

The machine transitions between these states based on events like "coin inserted", "product selected", or "product dispensed".

### Game Character

A game character might have states:

- **Idle** - Standing still
- **Walking** - Moving around
- **Running** - Moving fast
- **Jumping** - In the air
- **Attacking** - Performing an attack
- **Defending** - Blocking attacks

The character transitions between states based on player input or game events.

### Order Processing

An order in an e-commerce system might have states:

- **Pending** - Order placed, waiting for payment
- **Processing** - Payment confirmed, preparing order
- **Shipped** - Order sent to customer
- **Delivered** - Order received by customer
- **Cancelled** - Order cancelled before completion

The order moves through these states based on events like "payment received", "order shipped", or "order cancelled".

## Why State Machines Matter in Software Development

State machines are valuable in software development because they help you:

### 1. **Clarify Behavior**

By explicitly defining states and transitions, you make the behavior of your system clear and understandable. Anyone can look at a state machine and understand what states are possible and how the system moves between them.

### 2. **Prevent Invalid States**

A state machine makes it clear which states are valid and which transitions are allowed. This helps prevent bugs where an entity ends up in an invalid or unexpected state.

### 3. **Document Requirements**

State machines serve as documentation. They show stakeholders (developers, testers, product owners) exactly how the system should behave.

### 4. **Guide Implementation**

Once you have a state machine, it guides your implementation. You know what states to handle, what transitions to support, and what events to listen for.

### 5. **Enable Testing**

With a clear state machine, you can systematically test:
- All possible states
- All valid transitions
- All invalid transitions (should be rejected)
- Edge cases and error conditions

## Connection to Your Projects

You've already encountered state machines in your assignments! In Assignment 1, the `Stock` entity has a `currentState` field that can be:

- **Steady** - Stock price is stable
- **Growing** - Stock price is increasing
- **Declining** - Stock price is decreasing
- **Bankrupt** - Company has gone bankrupt
- **Reset** - Stock has been reset

This can be modeled with a state machine! The stock can be in one of these states, and it transitions between them based on market conditions or game events.

## When to Use State Machines

Use state machines when:

- **An entity has distinct states** - The entity can be in clearly different conditions
- **Transitions are well-defined** - You can specify when and how the entity moves between states
- **State matters** - The current state affects what the entity can do or how it behaves
- **Invalid states are possible** - You want to prevent the entity from being in invalid states, or you want to prevent invalid transitions


# Introduction to JavaFX Data Bindings

JavaFX **data bindings** let you connect values so that when one changes, others update automatically—without writing listeners or manual sync code. This learning path explains the concept and the APIs.

## What Are Data Bindings?

In ordinary code, a value is just a value: you put a number or string in a variable, and nothing else knows when it changes. **Data binding** means wrapping that value in an **observable container** (in JavaFX, a **property**). When the value inside the container changes, anything that **depends** on it can be updated automatically.

So instead of "variable A changed, so I must remember to update B and C," you say "B is bound to A" and "C is bound to A." When A changes, B and C stay in sync without extra code.

## Why Does JavaFX Have Properties and Bindings?

A graphical UI must stay in sync with data: when the user edits a field, the model updates; when the model updates, the display should reflect it. JavaFX provides **properties** (observable values) and **bindings** (relationships between them) so that:

- Changing a property automatically updates anything bound to it.
- You can bind a UI control's property (e.g. a label's text) to a value in your model, and the screen updates when the model changes.

Using these APIs in a full JavaFX application—with controllers, view models, and FXML—is covered elsewhere. Here we focus only on **properties and bindings themselves**.

## Scope of This Learning Path

This path covers **only**:

- What properties are and how to create and use them.
- Unidirectional binding (one property follows another).
- Bidirectional binding (two properties stay in sync).
- Computed bindings (a value derived from one or more properties, including mapping between types).

All examples use a **simple `main` method**: we create properties, bind them, and print values. No Stage, Scene, FXML, or application lifecycle. That keeps the focus on the binding APIs. When you later connect model to UI, you will use these same properties and bindings.

## What You Will See

1. **Property types**: Integer, Double, String, Boolean, and Object properties; how to create them and get/set values.
2. **Unidirectional binding**: `bind()` — one property (the target) follows another (the source) and becomes read-only.
3. **Bidirectional binding**: `bindBidirectional()` — two properties stay in sync; both remain writable.
4. **Computed bindings**: Values derived from other properties (e.g. sum of two numbers, concatenation of strings, or a number formatted as text). This includes **mapping between types** (e.g. number → string).

Once you understand these, you can use the same ideas when wiring up a real JavaFX UI.

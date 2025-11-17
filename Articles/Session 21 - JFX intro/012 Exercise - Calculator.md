# Exercise - Calculator

In this exercise, we will create a very simple calculator. It will also be ugly.

Create a structure as below:

```console
📁src/
├── 📁presentation/
│   └── 📄Calculator.java
└── 📄StartUp.java
```

The calculator should have the following features:

- Two text fields, for the two numbers to be calculated.
- Four buttons, for the four operations: +, -, *, /
- A label, to display the result of the calculation.


## UI Layout
I recommend creating 3 VBoxes inside a HBox.\
The first VBox should contain the two text fields, the second HBox should contain the four buttons, and the third HBox should contain the result label.

Something like this:

```
┌─────────────────────────────────────────────┐
│           Simple Calculator                 │
├─────────────────────────────────────────────┤
│                                             │
│  Row 1: Text Fields                         │
│  ┌──────────────┐     ┌──────────────┐      │
│  │   Number 1   │     │   Number 2   │      │
│  └──────────────┘     └──────────────┘      │
│                                             │
│  Row 2: Operation Buttons                   │
│  ╭────╮  ╭────╮  ╭────╮  ╭────╮             │
│  │ +  │  │ -  │  │ *  │  │ /  │             │
│  ╰────╯  ╰────╯  ╰────╯  ╰────╯             │
│                                             │
│  Row 3: Result Display                      │
│  ┌───────────────────────────────────────┐  │
│  │  Result: 0                            │  │
│  └───────────────────────────────────────┘  │
│                                             │
└─────────────────────────────────────────────┘
```

```java
HBox row1 = new HBox(10, ...);
HBox row2 = new HBox(10, ...);
HBox row3 = new HBox(10, ...);

VBox vbox = new VBox(10, row1, row2, row3);
```

## Tips

- You can set the preferred width of the text fields using `textField.setPrefWidth(50)` to make them more uniform
- Remember to parse the text field values to numbers before performing calculations
- Consider handling potential errors when the user enters invalid numbers, you could just put an error message in the result label.

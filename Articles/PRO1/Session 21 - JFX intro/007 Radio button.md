# Radio Button

A radio button is a UI element that allows users to select one option from a group of mutually exclusive choices. When one radio button is selected, all others in the same group are automatically deselected.

You can [read about RadioButton in the JavaFX documentation here](https://docs.oracle.com/javase/8/javafx/api/javafx/scene/control/RadioButton.html).

## Toggle Group

Radio buttons must be added to a `ToggleGroup` to work together. Without a toggle group, each radio button would work independently (like checkboxes).

## Primary Methods

The primary methods are exemplified below:

```java
ToggleGroup group = new ToggleGroup();

RadioButton option1 = new RadioButton("Small");
RadioButton option2 = new RadioButton("Medium");
RadioButton option3 = new RadioButton("Large");

option1.setToggleGroup(group);
option2.setToggleGroup(group);
option3.setToggleGroup(group);

option2.setSelected(true);

Toggle selectedToggle = group.getSelectedToggle();
RadioButton selectedButton = (RadioButton) selectedToggle;
String selectedText = selectedButton.getText();
```

Lines:

1, create a toggle group to connect radio buttons.\
3-5, create three radio buttons with different labels.\
7-9, add each radio button to the toggle group.\
11, set the second radio button as selected by default.\
13, get the currently selected toggle from the group.\
14, cast the toggle to a RadioButton to access its properties.\
15, get the text of the selected radio button.




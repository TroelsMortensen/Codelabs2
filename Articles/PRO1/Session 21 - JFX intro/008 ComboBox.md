# ComboBox

A combo box (also called a dropdown) is a UI element that presents a list of options in a compact space. Users click on it to reveal all available choices and select one.

You can [read about ComboBox in the JavaFX documentation here](https://docs.oracle.com/javase/8/javafx/api/javafx/scene/control/ComboBox.html).


## Primary Methods

The primary methods are exemplified below:

```java
ComboBox<String> comboBox = new ComboBox<>();

comboBox.getItems().addAll("Red", "Green", "Blue");
comboBox.setValue("Green");
comboBox.setPromptText("Choose a color");

String selected = comboBox.getValue();
comboBox.setEditable(true);
```

Lines:

1, create a combo box that will hold String values.\
3, add multiple items to the combo box.\
4, set the currently selected value.\
5, set placeholder text shown when nothing is selected.\
7, get the currently selected value (returns null if nothing is selected).\
8, make the combo box editable, allowing users to type custom values.

## Listening for Changes

You can listen for selection changes using:

```java
comboBox.setOnAction(_ -> {
    String selected = comboBox.getValue();
    System.out.println("Selected: " + selected);
});
```



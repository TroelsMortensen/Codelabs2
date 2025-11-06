# Checkbox

This is a UI element allowing the user to select a boolean value. True or false. On or off.

* [ ] off
* [x] on

I don't have a video for this. Instead, [you can read about checkboxes here](https://docs.oracle.com/javase/8/javafx/api/javafx/scene/control/CheckBox.html).

The checkbox in JavaFX has three states:
- `SELECTED`
- `UNSELECTED`
- `INDETERMINATE`

The indeterminate state is used when the checkbox is partially selected. For example, if you have a checkbox for "I agree to the terms and conditions", and the user has not read the terms and conditions, you might want to set the checkbox to indeterminate. The user has not yet made a choice.

The checkbox allows the developer to disable the option for indeterminate state, reducing the valid values to true or false: `SELECTED` or `UNSELECTED`.

The primary methods are exemplified below:

```java
CheckBox checkBox = new CheckBox("Check this out");

boolean isSelected = checkBox.isSelected();
boolean isIndeterminate = checkBox.isIndeterminate();
boolean thisCheckBoxAllowsIndeterminateState = checkBox.isAllowIndeterminate();
checkBox.setSelected(true);
checkBox.setAllowIndeterminate(false);
```	

Lines:

1, create a checkbox, the string is the text that will be displayed next to the checkbox.\
3, get the selected state of the checkbox. Returns true if the checkbox is selected, false otherwise.\
4, get the indeterminate state of the checkbox. Returns true if the checkbox is indeterminate, false otherwise.\
5, get the allow indeterminate state of the checkbox. Returns true if the checkbox allows indeterminate state, false otherwise.\
6, set the selected state of the checkbox. Sets the checkbox to selected if the boolean is true, unselected if the boolean is false.\
7, set the allow indeterminate state of the checkbox. Sets the checkbox to allow indeterminate state if the boolean is true, do not allow indeterminate state if the boolean is false.

## Exercise 5.1 - Create a checkbox

Create a small application, which shows a checkbox, with the text "Pick me!".\
Add a button, which when clicked will print out the state of the checkbox.\
Play around with the indeterminate state, selected and unselected, to see how it works.

<hint title="Solution">

```java
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.CheckBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

public class CheckBoxExample extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        CheckBox checkBox = new CheckBox("Pick me!");
        checkBox.setAllowIndeterminate(true);
        
        Button button = new Button("Print State");
        button.setOnAction(_ -> {
            if (checkBox.isIndeterminate()) {
                System.out.println("Indeterminate");
            } else if (checkBox.isSelected()) {
                System.out.println("Selected");
            } else {
                System.out.println("Unselected");
            }
        });
        
        VBox root = new VBox(10, checkBox, button);
        Scene scene = new Scene(root, 300, 200);
        
        primaryStage.setTitle("CheckBox Example");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}
```

</hint>


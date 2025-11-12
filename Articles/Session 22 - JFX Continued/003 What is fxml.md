# What is fxml?

So far, you have set up your UI with layout and elements through code. Creating buttons, text fields, labels, etc. and adding them to panes, like VBox, HBox, AnchorPane, etc. Then putting that into a scene, into a stage, and then showing the stage.

While doable, this is tedious. There is a better way.

You can use an fxml file to set up your UI. An fxml file is an XML file that describes your UI. 

Let's take the following code. Multiple ui elements are created, and added to a VBox.

```java
TextField textField = new TextField();
Button button = new Button("Add string");
Label dataShowingLabel = new Label();
Button displayDataButton = new Button("Show data");
VBox box = new VBox(textField, button, displayDataButton, dataShowingLabel);
```

We can describe this in an fxml file like this:

```xml
<VBox>
    <TextField />
    <Button text="Add string" />
    <Label />
    <Button text="Show data" />
</VBox>
```

The tags should be clear, I trust. We have a VBox element, which contains a TextField, a Button, a Label, and another Button.

Is this better? Well, maybe.. 


## SceneBuilder

So, do you have to manually write out the fxml file? No, you can use a tool to help you. There is a drag-and-drop tool called SceneBuilder, which can help you visually setup a scene, and then produce the fxml file for you.
# Buttons

Buttons are a very important part of any GUI. They are the way for the user to interact with the application.

And so, it is a good starting point.

Watch the video below to see how to create a button in JavaFX, and how to attach functionality to that button.

<video src="https://youtu.be/_jEooKZFWkI"></video>

[The code is on GitHub](https://github.com/TroelsMortensen/JavaFxExamples/tree/master/YourFirstButton)


## Excercise 3.1 - Create a button

In this exercise, write an application, which shows a button, with the text "Click me". When the button is clicked, the application should print "Button clicked" to the console.

<hint title="Solution">

```java
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

public class ButtonExample extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        Button button = new Button("Click me");
        button.setOnAction(_ -> System.out.println("Button clicked"));
        
        StackPane root = new StackPane(button);
        Scene scene = new Scene(root, 300, 200);
        
        primaryStage.setTitle("Button Example");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}
```

The scene dimensions are set to 300x200 pixels, when creating the scene object.


</hint>

## Exercise 3.2 - Setting text in a label

For this exercise create a gui with three elements.

You don't have to care about any particular layout, just throw those elements on the screen, however you like.

- A label with the text "Hello, World!"
- A button, with the text "Set Moon!", which when clicked, should change the text of the label to "Hello, Moon!"
- A button, with the text "Set Sun!", which when clicked, should change the text of the label to "Hello, Sun!"

So, you should be able to click back and forth between the two buttons, to make the text change between "Hello, Moon!" and "Hello, Sun!".

<hint title="Solution">

```java
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

public class LabelChangeExample extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        Label label = new Label("Hello, World!");
        
        Button moonButton = new Button("Set Moon!");
        moonButton.setOnAction(_ -> label.setText("Hello, Moon!"));
        
        Button sunButton = new Button("Set Sun!");
        sunButton.setOnAction(_ -> label.setText("Hello, Sun!"));
        
        VBox root = new VBox(10, label, moonButton, sunButton);
        Scene scene = new Scene(root, 300, 200);
        
        primaryStage.setTitle("Label Change Example");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
    
    public static void main(String[] args) {
        launch(args);
    }
}
```

The scene dimensions are set to 300x200 pixels, when creating the scene object.

</hint>


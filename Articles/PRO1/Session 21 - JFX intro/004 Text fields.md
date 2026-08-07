# Text fields

Text fields are a common way to allow the user to input text into the application. These too are an essential part of any GUI.

Watch the video below to see how to create a text field in JavaFX.

<video src="https://youtu.be/pv4pZx7ewww"></video>

[The code is on GitHub](https://github.com/TroelsMortensen/JavaFxExamples/tree/master/YourFirstTextField)

## Exercise 4.1 - Print the text field value

Create a gui application, with a text field and a button. When the button is clicked, the text field value should be printed to the console.

<hint title="Solution">

```java
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

public class TextFieldExample extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        TextField textField = new TextField();
        
        Button button = new Button("Print Text");
        button.setOnAction(_ -> {
            String text = textField.getText();
            System.out.println(text);
        });
        
        VBox root = new VBox(10, textField, button);
        Scene scene = new Scene(root, 300, 200);
        
        primaryStage.setTitle("Text Field Example");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}
```

The `10` in the `VBox` constructor is the spacing between the elements.\

</hint>

## Exercise 4.2 - Clearing the text field

To the above exercise, add another button, with the text "Clear". When the button is clicked, the text field should be cleared.

<hint title="Solution">

```java
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

public class TextFieldExample extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        TextField textField = new TextField();
        
        Button printButton = new Button("Print Text");
        printButton.setOnAction(_ -> {
            String text = textField.getText();
            System.out.println(text);
        });
        
        Button clearButton = new Button("Clear");
        clearButton.setOnAction(_ -> textField.clear());
        
        VBox root = new VBox(10, textField, printButton, clearButton);
        Scene scene = new Scene(root, 300, 200);
        
        primaryStage.setTitle("Text Field Example");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}
```

</hint>


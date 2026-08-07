# Text Area

A text area is a UI element that allows users to enter multiple lines of text. Unlike a text field, which is designed for single-line input, a text area is ideal for longer content like comments, descriptions, or messages.

You can [read about TextArea in the JavaFX documentation here](https://docs.oracle.com/javase/8/javafx/api/javafx/scene/control/TextArea.html).



## Primary Methods

The primary methods are exemplified below:

```java
TextArea textArea = new TextArea();

String text = textArea.getText();
textArea.setText("Hello, World!");
textArea.appendText("\nMore text");
textArea.clear();
textArea.setWrapText(true);
textArea.setPrefRowCount(5);
textArea.setPrefColumnCount(40);
```

Lines:

1, create a text area.\
3, get the text from the text area. Returns the entire text content as a single string.\
4, set the text in the text area. Replaces all existing text.\
5, append text to the existing content. The `\n` creates a new line.\
6, clear all text from the text area.\
7, enable word wrapping. When true, long lines will wrap to the next line instead of requiring horizontal scrolling.\
8, set the preferred number of visible rows (height).\
9, set the preferred number of visible columns (width).



## Exercise 6.1 - Create a text area

Create a small application with a text area and a button.\
When the button is clicked, print the content of the text area to the console.\
Set the text area to wrap text and make it 10 rows tall and 30 columns wide.

<hint title="Solution">

```java
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

public class TextAreaExample extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        TextArea textArea = new TextArea();
        textArea.setWrapText(true);
        textArea.setPrefRowCount(10);
        textArea.setPrefColumnCount(30);
        
        Button button = new Button("Print Text");
        button.setOnAction(_ -> {
            String text = textArea.getText();
            System.out.println(text);
        });
        
        VBox root = new VBox(10, textArea, button);
        Scene scene = new Scene(root, 400, 300);
        
        primaryStage.setTitle("TextArea Example");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}
```

</hint>

## Exercise 6.2 - Append text to text area

Extend the previous exercise by adding a text field and a second button labeled "Append".\
When the "Append" button is clicked, take the text from the text field and append it to the text area on a new line.\
After appending, clear the text field.

<hint title="Solution">

```java
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

public class TextAreaExample extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        TextArea textArea = new TextArea();
        textArea.setWrapText(true);
        textArea.setPrefRowCount(10);
        textArea.setPrefColumnCount(30);
        
        TextField textField = new TextField();
        textField.setPromptText("Enter text to append...");
        
        Button appendButton = new Button("Append");
        appendButton.setOnAction(_ -> {
            String text = textField.getText();
            if (!text.isEmpty()) {
                textArea.appendText(text + "\n");
                textField.clear();
            }
        });
        
        Button printButton = new Button("Print Text");
        printButton.setOnAction(_ -> {
            String text = textArea.getText();
            System.out.println(text);
        });
        
        VBox root = new VBox(10, textArea, textField, appendButton, printButton);
        Scene scene = new Scene(root, 400, 350);
        
        primaryStage.setTitle("TextArea Example");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}
```

</hint>



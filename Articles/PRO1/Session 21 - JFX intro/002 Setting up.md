# Your first JavaFX application

The video below will show you how to set up a new JavaFX application. Consider this a test run, just to ensure you can make stuff work. Sometimes it's a bit glitchy.

I have created a new project dedicated to my JavaFX stuff, but you can probably just use your current PRO1 project, if you like.

<video src="https://youtu.be/LsxLAjTXROw"></video>

[The code is on GitHub](https://github.com/TroelsMortensen/JavaFxExamples/tree/master/FirstApp)

## Problems?

Maybe you do not get the little green run arrow for the class that has your start method.

If this happens, my best suggestion, is to add a main method to your class, like this:

```java
public class RunApp extends Application {

    @Override
    public void start(Stage stage) throws Exception {
        stage.setTitle("Hello, World!");
        stage.setScene(new Scene(new HBox(new Label("Hello, World!"))));
        stage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
```

In some cases, this will allow you to run the main method, which then starts the application. The `launch()` method is from the `Application` class, so the main method must be in a class that extends `Application`.

## Exercise 2.1

Redo the example from the video, again, just to ensure you can make stuff work. 

Show a label, in a window, with the text "Hello, World!".
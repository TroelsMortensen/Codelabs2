# Exercise - Login form

Let's follow up with an exercise, just to make sure you understand the concept of controllers, event handling, and fxml views.

We will create a login form. 

## UI

It should look something like this:

```
┌─────────────────────────────────────────┐
│            User Login                   │
├─────────────────────────────────────────┤
│                                         │
│  Username:                              │
│  ┌───────────────────────────────────┐  │
│  │                                   │  │
│  └───────────────────────────────────┘  │
│                                         │
│  Password:                              │
│  ┌───────────────────────────────────┐  │
│  │ ••••••••••••                      │  │
│  └───────────────────────────────────┘  │
│                                         │
│         ╭─────────────────────╮         │
│         │      Login          │         │
│         ╰─────────────────────╯         │
│                                         │
│  Status: Ready to login                 │
│                                         │
└─────────────────────────────────────────┘
```

Notice the bottom, there is a status label. Here you can put a message to the user, like "Ready to login", "Invalid username or password", "Login successful", etc.

## Logic

The logic should be as follows:

- When the user clicks the Login button, the app should check if the username and password are correct. You should just predefine what the correct username and password are. Put these in constants in your controller class.
- If they are correct, the app should show a success message and enable the Login button.
- If they are incorrect, the app should show an error message and disable the Login button.

## Extra

If you are feeling ambitious, then update the behaviour of the button:
- upon successful login, the text on the button should change to "Logout", and when clicked, it should reset the ui, i.e. input fields, button text, and status label.

---

<hint title="Solution">

Here's a basic structure to get you started. I have created two files: `RunApp.java` and `LoginController.java`. And an fxml file, `LoginView.fxml`, not shown here.

### RunApp.java

```java
package loginapp;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

public class RunApp extends Application
{
    @Override
    public void start(Stage primaryStage) throws Exception
    {
        Parent root = FXMLLoader.load(getClass().getResource("LoginView.fxml"));
        Scene scene = new Scene(root, 400, 300);
        primaryStage.setTitle("User Login");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    public static void main(String[] args)
    {
        launch(args);
    }
}
```

### LoginController.java

```java
package loginapp.presentation;

import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;

public class LoginController
{
    private static final String CORRECT_USERNAME = "admin";
    private static final String CORRECT_PASSWORD = "password123";

    @FXML
    private TextField usernameField;

    @FXML
    private PasswordField passwordField;

    @FXML
    private Button loginButton;

    @FXML
    private Label statusLabel;

    private boolean isLoggedIn = false;

    // This method is called after the FXML components are loaded, automatically.
    @FXML
    public void initialize()
    {
        statusLabel.setText("Ready to login");
    }

    @FXML
    private void handleLogin()
    {
        if (!isLoggedIn)
        {
            // Login logic
            String username = usernameField.getText();
            String password = passwordField.getText();

            if (username.equals(CORRECT_USERNAME) && password.equals(CORRECT_PASSWORD))
            {
                statusLabel.setText("Login successful!");
                statusLabel.setStyle("-fx-text-fill: green;");
                loginButton.setText("Logout");
                isLoggedIn = true;
            }
            else
            {
                statusLabel.setText("Invalid username or password");
                statusLabel.setStyle("-fx-text-fill: red;");
                loginButton.setDisable(true);
            }
        }
        else
        {
            // Logout logic
            usernameField.clear();
            passwordField.clear();
            statusLabel.setText("Ready to login");
            statusLabel.setStyle("-fx-text-fill: black;");
            loginButton.setText("Login");
            loginButton.setDisable(false);
            isLoggedIn = false;
        }
    }
}
```

**Tips:**
- Use a `TextField` for the username
- Use a `PasswordField` for the password (it automatically masks input)
- Use `fx:id` in FXML to link UI components to controller fields
- Use `onAction="#handleLogin"` on the button to wire up the event handler
- The `initialize()` method automatically runs after FXML components are loaded


</hint>
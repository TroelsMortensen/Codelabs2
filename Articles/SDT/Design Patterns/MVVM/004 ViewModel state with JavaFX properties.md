# ViewModel state with JavaFX properties

In JavaFX MVVM, the ViewModel exposes state through JavaFX properties so views can observe and bind to changes.

By state, we mean the data that the ViewModel needs to expose to the View:
- Username
- Status messages
- Validation flags
- List of items
- Data for a table
- etc.


## Reference before this page

This page assumes you already know the property APIs.  
For full property and binding mechanics, read [about data binding](https://troelsmortensen.github.io/Codelabs2/article/TroelsMortensen/SDT%2FData%20Bindings)


Here we focus on architectural usage in MVVM.

## What belongs in ViewModel state

Typical examples:

- form input values (`StringProperty`)
- derived display text (`StringProperty` or computed binding)
- selected item (`ObjectProperty<T>`)
- validation flags (`BooleanProperty`)
- status messages (`StringProperty`)

## ViewModel example

In a login view, we want the ViewModel to know about the username and password, and whether the user can login. And when they attempt to login, we want to show if it failed. All this is data, and data is kept in the ViewModel properties. For example:

```java
public class LoginViewModel {
    private final StringProperty username = new SimpleStringProperty("");
    private final StringProperty password = new SimpleStringProperty("");
    private final BooleanProperty canLogin = new SimpleBooleanProperty(false);
    private final StringProperty errorMessage = new SimpleStringProperty("");
}
```

## Exposure guideline

Expose property accessors where binding is needed (`usernameProperty()`)

For example:

```java
public class LoginViewModel {

    // properties

    public StringProperty usernameProperty() {
        return username;
    }
}
```

When we expose the properties, the view can bind to them. For example:
```java
public class LoginController {
    @FXML
    private TextField usernameField;
    @FXML
    private PasswordField passwordField;

    private final LoginViewModel viewModel;

    public LoginController(LoginViewModel viewModel) {
        this.viewModel = viewModel;
    }

    public void initialize() {
        usernameField.textProperty().bind(viewModel.usernameProperty());
        passwordField.textProperty().bind(viewModel.passwordProperty());
    }
}
```

## Recap

In short:
* All the data that the view can present, is kept in the ViewModel properties, or Observable lists.
* All the data that the user inputs, is "pushed" automatically to the ViewModel properties.
* All the data that the ViewModel needs to know about, is kept in the ViewModel properties.

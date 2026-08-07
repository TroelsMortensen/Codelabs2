# Exercise - Login form

In this exercise, you will create a two-view application, where the user can login, and then see a welcome message.

You will need:
- fxml files for the login view and the welcome view
- a controller class for each view
- a main class to run the application, i.e. the usual start method
- The ViewManager class, to switch between the views

Just put everything into the same package. Next session we will explore application structure a bit more.

## UI
Below, you will see two wire frames of the views, use these as inspiration.

### View 1: Login Screen

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

### View 2: Welcome Screen

```
┌─────────────────────────────────────────┐
│            Welcome!                     │
├─────────────────────────────────────────┤
│                                         │
│                                         │
│         Hello, [Username]!              │
│                                         │
│         You have successfully           │
│         logged in to the system.        │
│                                         │
│                                         │
│         ╭─────────────────────╮         │
│         │      Logout         │         │
│         ╰─────────────────────╯         │
│                                         │
│                                         │
└─────────────────────────────────────────┘
```

## Requirements

- Keep a list of at least three `User` objects in a list in the login controller, and verify the inputs against this list.
- When the user clicks "Login", validate that both username and password fields are not empty
- If validation passes, switch to the welcome view and display the username
- The welcome view should show a personalized greeting with the username from the login form
- When the user clicks "Logout", return to the login view and clear the fields
- Update the status label on the login screen to provide feedback (e.g., "Logging in...", "Login successful", "Please enter username and password", etc)



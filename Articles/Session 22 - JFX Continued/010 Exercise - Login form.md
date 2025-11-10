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
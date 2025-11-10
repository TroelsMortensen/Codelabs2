# Exercises - SceneBuilder

The following exercises will present you with a UI screenshot, and you should try to recreate it using SceneBuilder. It's not super important, that you get it 100% correct, the main purpose is just to play around with the SceneBuilder.

Remember, you can use the _preview_ to do some basic testing of the UI.

## Exercise 1 - Login Form

Create a simple login form with the following layout:

```
┌────────────────────────────────────────┐
│           Login to System              │
├────────────────────────────────────────┤
│                                        │
│  Username:                             │
│  ┌──────────────────────────────────┐  │
│  │                                  │  │
│  └──────────────────────────────────┘  │
│                                        │
│  Password:                             │
│  ┌──────────────────────────────────┐  │
│  │ ••••••••••••••••                 │  │
│  └──────────────────────────────────┘  │
│                                        │
│     ╭──────────╮    ╭──────────╮       │
│     │  Login   │    │  Cancel  │       │
│     ╰──────────╯    ╰──────────╯       │
│                                        │
└────────────────────────────────────────┘
```

**Hints:**
- Use a VBox as the main container
- Use Labels for "Username:" and "Password:"
- Use TextField for username and PasswordField for password
- Use an HBox for the buttons at the bottom
- Add spacing between elements for better appearance

## Exercise 2 - Calculator Layout

Create a calculator interface with the following layout:

```
┌─────────────────────────────────────┐
│          Calculator                 │
├─────────────────────────────────────┤
│                                     │
│  ┌───────────────────────────────┐  │
│  │                             0 │  │
│  └───────────────────────────────┘  │
│                                     │
│  ╭────╮  ╭────╮  ╭────╮  ╭────╮     │
│  │ 7  │  │ 8  │  │ 9  │  │ /  │     │
│  ╰────╯  ╰────╯  ╰────╯  ╰────╯     │
│                                     │
│  ╭────╮  ╭────╮  ╭────╮  ╭────╮     │
│  │ 4  │  │ 5  │  │ 6  │  │ *  │     │
│  ╰────╯  ╰────╯  ╰────╯  ╰────╯     │
│                                     │
│  ╭────╮  ╭────╮  ╭────╮  ╭────╮     │
│  │ 1  │  │ 2  │  │ 3  │  │ -  │     │
│  ╰────╯  ╰────╯  ╰────╯  ╰────╯     │
│                                     │
│  ╭────╮  ╭────╮  ╭────╮  ╭────╮     │
│  │ 0  │  │ .  │  │ =  │  │ +  │     │
│  ╰────╯  ╰────╯  ╰────╯  ╰────╯     │
│                                     │
└─────────────────────────────────────┘
```

**Hints:**
- Use a VBox as the main container
- Use a TextField at the top for the display (set it to right-aligned)
- Use a GridPane for the button layout (4 columns × 4 rows)
- Set all buttons to have the same size
- Add some spacing between buttons

## Exercise 3 - Contact Form

Create a contact information form with the following layout:

```
┌──────────────────────────────────────────────┐
│         Contact Information Form             │
├──────────────────────────────────────────────┤
│                                              │
│  First Name:          Last Name:             │
│  ┌─────────────────┐  ┌─────────────────┐    │
│  │                 │  │                 │    │
│  └─────────────────┘  └─────────────────┘    │
│                                              │
│  Email:                                      │
│  ┌────────────────────────────────────────┐  │
│  │                                        │  │
│  └────────────────────────────────────────┘  │
│                                              │
│  Phone Number:        Age:                   │
│  ┌─────────────────┐  ┌──────────┐           │
│  │                 │  │          │           │
│  └─────────────────┘  └──────────┘           │
│                                              │
│  Country:                                    │
│  ┌────────────────────────────────────────┐  │
│  │ Select Country                       ▼ │  │
│  └────────────────────────────────────────┘  │
│                                              │
│  Comments:                                   │
│  ┌────────────────────────────────────────┐  │
│  │                                        │  │
│  │                                        │  │
│  │                                        │  │
│  └────────────────────────────────────────┘  │
│                                              │
│           ╭──────────╮  ╭──────────╮         │
│           │  Submit  │  │  Clear   │         │
│           ╰──────────╯  ╰──────────╯         │
│                                              │
└──────────────────────────────────────────────┘
```

**Hints:**
- Use a VBox as the main container
- Use GridPane for the form fields to align labels and inputs
- Use HBox for fields that should be side-by-side (First/Last Name, Phone/Age)
- Use ComboBox for the country dropdown
- Use TextArea for the comments section (multi-line)
- Use an HBox for the buttons at the bottom
- Add appropriate spacing and padding throughout
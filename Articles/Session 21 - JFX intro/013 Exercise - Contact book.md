# Exercise - Contact Book

In this exercise, you will create a contact book application that allows users to add and view contacts.

## Requirements

### Project Structure
```console
📁src/
├── 📁domain/
│   └── 📄Contact.java
├── 📁persistence/
│   └── 📄ContactManager.java
├── 📁presentation/
│   └── 📄ContactBookView.java
└── 📄StartUp.java
```

### Data Structure

Create a `Contact` class with the following fields:
- `name` (String)
- `phone` (String)

Create a `ContactManager` class that stores a list of contacts and provides methods to:
- Add a contact
- Get all contacts. It will be the responsibility of the UI to convert this list so some presentable format.

### User Interface

The application should have two VBoxes side by side (put them in an HBox, to arrange them side by side).

```
┌─────────────────────────────────────────────────────┐
│                Contact Book                         │
├──────────────────────┬──────────────────────────────┤
│  Add Contact         │  View Contacts               │
│                      │                              │
│  Name:               │  ╭─────────────────────────╮ │
│  ┌────────────────┐  │  │ Show All Contacts       │ │
│  │                │  │  ╰─────────────────────────╯ │
│  └────────────────┘  │                              │
│                      │  ┌─────────────────────────┐ │
│  Phone:              │  │                         │ │
│  ┌────────────────┐  │  │ John - 555-1234         │ │
│  │                │  │  │ Jane - 555-5678         │ │
│  └────────────────┘  │  │ Alice - 555-9012        │ │
│                      │  │ Bob - 555-3456          │ │
│                      │  │ Charlie - 555-7890      │ │
│                      │  │                         │ │
│                      │  └─────────────────────────┘ │
│  ╭────────────────╮  │                              │
│  │ Add Contact    │  │                              │
│  ╰────────────────╯  │                              │
└──────────────────────┴──────────────────────────────┘
```

**Left VBox (Input Section):**
- A TextField for entering the contact name
- A TextField for entering the phone number
- A Button labeled "Add Contact" that creates a new Contact object and adds it to the ContactManager

**Right VBox (Display Section):**
- A Button labeled "Show All Contacts" at the top
- A Label below the button to display the list of contacts

When the "Show All Contacts" button is clicked, the label should display all contacts in a readable format, for example:
```
John Doe - 555-1234
Jane Smith - 555-5678
Bob Johnson - 555-9012
```

## Validation

Add a label to the left side, above the button.

This label should hold any validation error messages.

Validation should include:
- Empty name
- Empty phone number
- Phone number must be exactly 8 digits

## Tips

- Remember to clear the text fields after adding a contact
- Make sure to handle empty input gracefully
- Consider adding some spacing between elements for better visual appearance
- You may want to set a preferred width for the label to ensure it displays properly

## Bonus Challenges

If you finish early, try adding:
1. A "Clear All" button to remove all contacts from the manager
3. A counter showing how many contacts are stored


# More UI Elements

JavaFX offers many more UI elements beyond what we've covered. Here's a list of commonly used components you might encounter or need in your applications.

Below is a list. I have intentionally _not included_ layout elements, as we will cover those in the next section. You have seen the AnchorPane, VBox, and HBox.

Just as you can add ui elements to these containers, you can also add containers to containers. E.g. put two VBoxes inside an AnchorPane, to create two columns.

## Additional Input Controls

**Slider** - A control that allows users to select a numeric value by dragging a thumb along a track. Useful for settings like volume, brightness, or zoom level.

**DatePicker** - A control that lets users select a date from a calendar dropdown. Essential for booking systems, forms, and scheduling applications.

**ColorPicker** - A control that provides a color selection dialog. Users can pick colors visually or enter RGB/HSB values.

**PasswordField** - A specialized text field that masks the entered characters for security. Extends TextField but displays dots or asterisks instead of the actual text.

**ChoiceBox** - A simpler alternative to ComboBox for selecting from a small list of options. Takes up less space and doesn't support custom rendering.

**Spinner** - A control with up/down arrows for incrementing or decrementing a value. Good for numeric input with specific ranges or steps.

## Display Controls

**Label** - Displays non-editable text or images. Often used to describe other controls or show information to the user.

**ProgressBar** - Shows the progress of a task as a horizontal bar filling from left to right. Common in file downloads or long-running operations.

**ProgressIndicator** - A circular version of ProgressBar, often animated to show indeterminate progress (when you don't know how long something will take).

**Separator** - A horizontal or vertical line used to visually divide groups of UI elements. Helps organize complex interfaces.

**ImageView** - Displays images in your application. Supports various image formats and can be scaled or transformed.

## Advanced Controls

**ListView** - Displays a scrollable list of items where users can select one or multiple entries. More flexible than ComboBox for larger datasets.

**TableView** - Displays data in rows and columns, similar to a spreadsheet. Supports sorting, editing, and custom cell rendering.

**TreeView** - Shows hierarchical data in an expandable tree structure. Common for file systems, organizational charts, or nested categories.

**MenuBar** - A traditional application menu at the top with dropdown menus (File, Edit, View, etc.). Essential for desktop applications.

**ContextMenu** - A popup menu that appears when right-clicking on a component. Provides contextual actions relevant to the clicked item.

**ToolBar** - A horizontal or vertical bar containing buttons and other controls for quick access to common actions. Often found at the top of applications.

**Tooltip** - A small popup that appears when hovering over a control, providing helpful information or instructions.

## Dialog Controls

**Alert** - A pre-built dialog for showing information, warnings, errors, or confirmation messages. Much simpler than creating custom dialogs.

**Dialog** - A customizable popup window for collecting user input or displaying information. Can be modal (blocking) or non-modal.

**FileChooser** - Opens the system's file browser for selecting files to open or locations to save. Essential for file-based applications.

**DirectoryChooser** - Similar to FileChooser but specifically for selecting folders instead of individual files.

---

You can explore any of these elements in the [JavaFX API documentation](https://docs.oracle.com/javase/8/javafx/api/overview-summary.html). Each control has detailed documentation with methods, properties, and usage examples.

If you need a specific UI element for your application, browse through the `javafx.scene.control` package in the documentation to see what's available.


# Notifications

This is introduced in the second session about MVVM.

Sometimes stuff happens, and we need to notify the user.

Maybe some event from the service layer, and you want to show a popup to the user.

Or, maybe the user tried to do something, they were not allowed to do, and you catch an exception in a try-catch block in a ViewModel.

Either way, you need to notify the user.

I have some future plans for this, so you must follow a certain pattern:

## Define interface

You must define an interface for the notification service. You could name it `NotificationManager`.

The interface must declare method(s) to accept a message, and a type of notification. Similar to the Logger, the type can be
* error
* warning
* info

## Create implementation

You must also create an implementation of the interface. Name it according to how it outputs the notification.
You could print it to the console. But the user won't see that.

You could use the `Alert` class to show a popup to the user:

```java
Alert alert = new Alert(alertType);
alert.setTitle("Stock Trading Game");
alert.setHeaderText(null);
alert.setContentText(message);
alert.showAndWait();
```

Or come up with some other approach.
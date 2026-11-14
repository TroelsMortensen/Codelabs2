# How to handle multiple views

In many applications, you will need to show different views to the user. For example, you may have a login view, and after successful login, you may want to show a different view. Or you may want to show a another view, depending on the user's role. Then the user can browse between the different views, and the application will show the appropriate view for the user.

Each view is defined by an fxml file, and each view has a controller class. We need a way to swap between these views, in a convenient way.

If you look online, you will find many examples of how to do this, and most will put the responsibility for switching views into the controller classes. Each controller will then have to duplicate the logic for loading the fxml file and setting up the controller. If we change something about how this is done, we have to change it in many places. We don't want to do that. It is obviously not great.

We need to manage this in a somewhat consistent, centralized way.

The below video introduces the concept of a "View Manager", which is responsible for switching between the different views.

<video src="https://youtu.be/peZT8Fv6MzE"></video>

[The code is on GitHub](https://github.com/TroelsMortensen/JavaFxExamples/tree/master/11_IntroducingTheViewManager)
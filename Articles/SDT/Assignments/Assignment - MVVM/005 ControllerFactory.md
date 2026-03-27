# The ControllerFactory class

Your ViewManager class will need to create the controllers. This is where the ControllerFactory comes in.

We have previously used an almost-same approach, with the ControllerConfigurator class. But the ControllerFactory is the official JavaFX approach.

Create the class.

You don't have any controllers yet, so the method in the ControllerFactory is just empty.

You ControllerFactory will be responsible for creating the controllers.

Initially, you may also want to create controller dependencies in the ControllerFactory:
* Services
* DAOs
* UoW
* Etc

The creation of these services, however, will be moved to the ApplicationContext class, when that is introduced.
# The ApplicationContext class

Initially, you may have used the ControllerFactory to create the controllers and their dependencies.

After this pattern has been introduced, you must move the responsibility for creating the dependencies to the ApplicationContext class.

Your ApplicationContext class will be responsible for creating the dependencies, and other relevant setup stuff.
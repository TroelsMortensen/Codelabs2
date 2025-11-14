# Introduction to sequence diagrams

This type of diagram is a _dynamic diagram_. It is a diagram that shows a flow through the system _over time_. It is a _temporal_ representation of the system.

It is a _design artefact_, a way to represent the behaviour of the system..

I basically shows that 
- user clicks button
- that activates a method in the controller
- that calls another method in the data manager
- that updates the file system
- that returns a result
- that updates the UI

So, it is a sequence of actions, one after another. It shows _a path_ through the system. That sounds like the activity diagram? Yes, and no. The sequence diagram is more focused on the _flow_ of the _code_ of your system. So, it is very specific for your particular implementation. An activity diagram could be implemented in many different ways.
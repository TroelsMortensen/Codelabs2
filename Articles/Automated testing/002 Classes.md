# The classes

The classes involved in this example is shown in the below tree structure. We will then cover each of the classes in detail.

```console
📁src/
└── 📁automatedtesting/
    ├── 📁assertions/
    │   ├── 📄Assert.java
    │   └── 📄AssertionFailure.java
    ├── 📁examples/
    │    └── 📄ClassUnderTest.java
    ├── 📄MethodsToTest.java
    ├── 📄MoreMethodsToTest.java
    └── 📄TestRunner.java
```

Brief overview:
* `Assert` is a helper class with methods to verify various things. It just reduces the amount of code you have to write/duplicate.
* `AssertionFailure` is a custom exception class, which is used to indicate that a test has failed.
* `ClassUnderTest` is the class you want to test, it's just a boring example class with a few simple methods. It represents the code you want to test.
* `MethodsToTest` and `MoreMethodsToTest` are the test classes. They contain the test cases. Each method in here is a test case, which is supposed to test a single thing.
* `TestRunner` is the class that runs the tests. It's the entry point of the application. It will execute the test cases, and print the results to the console. This is the main method.


You can of course organize the classes differently. Perhaps, if you have several classes, like `MethodsToTest` and `MoreMethodsToTest`, you may want a package for all of them. It can be a good idea to have several classes, as this will allow you to better organize your test cases.

Maybe one class contains test cases (methods) for the `passwordIsStrong` method, and another class contains test cases (methods) for the `usernameIsValid` method.
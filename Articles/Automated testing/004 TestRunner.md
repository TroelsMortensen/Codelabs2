# The test runner

This class is responsible for running each of the test cases (methods), one after the other, and printing the results to the console.

There are a few things going on, which we must talk about.

## Runnable interface

This is an existing interface in Java. It is actually used for a different purpose, but we can use it here. You will see it again on second semester, when you learn about multi-threading.

The interface has a single method, `run()`, which takes no arguments, and returns void.

## Method reference

Your variables generally is either a value, i.e. simple type, or a _reference_ to an object.

However, Java also allows you to reference a method, instead of an object. This is called a "method reference". Behind the scenes, Java will still do some conversion to wrap the method reference into a class or interface. Sort of.

If I define a method, with no arguments, and no return valu, i.e. `void`, I can create a variable of type `Runnable`, and assign it to the method.

The example below shows how to do this. Notice the `::` operator. This is used to reference the `myMethod` method. The left of that operator is the class name, and the left is the method name.

```java
public class TestRunner {
    public static void main(String[] args) {
        Runnable r = TestRunner::myMethod;
        r.run();
    }

    public static void myMethod() {
        System.out.println("Hello, world!");
    }
}
```

When calling `r.run()`, it will call the `myMethod` method, and print "Hello, world!" to the console.

Is this weird? Well, it's actually not all that important, just accept it for now. You won't have to use it too much.

## The `TestCase` class

I have a `TestCase` class, inside the TestRunner class. It is a private static inner class. I use this to combine a name with a method reference, so that I can better organize the print outs.

```java
public class TestRunner {

    // ... other code ...
 

    private static class TestCase {
        public String name;
        public Runnable testCase;

        public TestCase(String name, Runnable testCase) {
            this.name = name;
            this.testCase = testCase;
        }
    }   
    
    // ... other code ...

}
```

Notice that, for simplicity, I am making the field variables public. It just reduces the amount of code you have to write, no getters or setters.\
Even better, I should have used a Record type, but I don't want to explain that.

## The test cases

I also need to keep track of all the test cases, so that I can execute them one after the other. This is done with an array, inside the TestRunner class.

Here:

```java
public class TestRunner {
    private static final TestCase[] testCases = new TestCase[]
    {
        new TestCase("MethodsToTest::test1", MethodsToTest::test1),
        new TestCase("MethodsToTest::test2", MethodsToTest::test2),
        new TestCase("MethodsToTest::test3", MethodsToTest::test3),
        new TestCase("MethodsToTest::test4", MethodsToTest::test4),
        new TestCase("MoreMethodsToTest::test5", MoreMethodsToTest::test5),
        new TestCase("MoreMethodsToTest::test6", MoreMethodsToTest::test6),
        new TestCase("MoreMethodsToTest::test7", MoreMethodsToTest::test7)
    };

    public static class TestCase {
    // ... other code ...
}
```

Each line creates a new `TestCase` object, with a name and a method reference. The name is a string, to explain which method in which class is being tested. I have followed a specific format here, but it could be any message which clearly identifies the test case. This format allows you to easily find the specific method, which was run. 

## The main method

So, we have the test cases defined. Now we need to run them one after the other.

We do that with a main method.

```java
public class TestRunner {


    public static void main(String[] args)
    {
        for (TestCase testCase : testCases)
        {
            try
            {
                testCase.test.run();
                System.out.println("✅" + testCase.name);
            }
            catch (Exception e)
            {  // Catches both Exception and Error
                System.out.println("❌" + testCase.name + ": " );
                System.out.println("\t\t\t"+ e.getMessage());
            }
        }
    }

    private static final TestCase[] testCases = new TestCase[]{
        // ... other code ...
    };

    public static class TestCase {
        // ... other code ...
    }
}
```

The main method is pretty simple. It loops over the `testCases` array, and for each test case, it tries to execute the test case (method), see line 10 above.\
Notice the `testCase.testCase.run()` line. This is where the test case is executed.

If the test case executes without any exceptions escaping it, it prints a success message right after. If an exception escapes the test case, the success-message print out is skipped, and execution jumps to the catch block, where it prints a failure message.

The `try-catch` block is used to catch all `Exception`, including the `AssertionFailure` exception. This is because `Exception` is the base class for all exceptions.

The `e.getMessage()` is used to get the message of the exception. This is often somewhat user friendly, and is a good place to start, when trying to give feedback to the user.
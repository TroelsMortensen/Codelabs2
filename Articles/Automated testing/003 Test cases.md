# Test cases

We start with a class containing your test cases.

Each test case is a single method inside the class.

The test case is supposed to execute some code, and somehow give a response about the result. In case of success, we don't do anything. In case of failure, we throw an exception. 


You should 

```java
public class MethodsToTest {
    public void test1() {
        boolean result = ClassUnderTest.passwordIsStrong("12345678");
        if(!result) {
            throw new AssertionFailure("Password is not strong");
        }
    }

    public void test2() {
        boolean result = ClassUnderTest.passwordIsStrong("Tx4!@#$%^&*()");
        if(!result) {
            throw new AssertionFailure("Password is not strong");
        }
    }
}
```

So, the point is here, that we can create several test cases, which provide different inputs to the code we want to test.

Maybe the code you want to test throws exceptions in case of invalid input. In that case you need to catch the specific exception, if that is the expected output. 

Something like below. 

Notice that in `test3` I am providing a strong password, which should not throw an exception. If such an exception is thrown, it is caught, and we throw an assertion failure. The test has failed.

In `test4` I am providing a weak password, which _should_ throw an exception. If such an exception is thrown, it is caught, we do nothing, and just `return;`. The test has passed.\
If such an exception was _not_ thrown, at the end of the method, I instead throw an assertion failure. The test has failed. We should not have reached this line of code, if they `passwordIsStrong` method works as expected.

```java
public void test3() {
    try {
        ClassUnderTest.passwordIsStrong("Tx4!@#$%^&*()");
    } catch (WeakPasswordException e) {
        throw new AssertionFailure("Password is weak: " + e.getMessage());
    }
    // No exception thrown, so test passes
}

public void test4() {
    try {
        ClassUnderTest.passwordIsStrong("12345678");
    } catch (WeakPasswordException e) {
        return;
    }
    throw new AssertionFailure("Password is strong");
}
```

Hmm... maybe it gets a bit convoluted.

The point is, if a test method executes without any exceptions escaping it, the test is a success.\
If an `AssertionFailure` is thrown, the test is a failure.\
If any other exception escapes the test method, it is considered a failure.

The job of the `TestRunner` class is to execute each of these methods/test cases, one after the other, and print the results to the console.
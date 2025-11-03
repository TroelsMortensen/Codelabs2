# Introduction to Automated Testing

This topic will be covered in detail on second semester. However, on your first semester, you may also have some code, which you want to test, in some kind of automated way.

And what does automated testing mean?

You click a button to run a program, which will execute some code, and then print out whether the code executed successfully or not.

For example, the output of the test runner program, you will see in this learning path, will look like this:

```console
✅MethodsToTest::test1
❌MethodsToTest::test2: 
			43 != 42
❌MethodsToTest::test3: 
			This probably fails
❌MethodsToTest::test4: 
			Super fail!
✅MoreMethodsToTest::test5
❌MoreMethodsToTest::test6: 
			Objects are not equal
✅MoreMethodsToTest::test7
```

The `✅` means that the test passed, and the `❌` means that the test failed.

After the icon, the format is [Class name]::[Test name]. I.e. we have a class called `MethodsToTest`, and a method inside this class called `test1`.

In the case of a failed test, the line below, indented, will contain some explanation of what went wrong.
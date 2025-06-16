# Postfix and Prefix Increment/Decrement

Consider the following code snippet:

```java
int a = 5;
System.out.println(a++); 
```

What will this print out? Create a program to test it.

<hint title="Explanation">

What happens here is a _postfix_ increment. The value of `a` is printed first, and then `a` is incremented by 1. So the output will be `5`, and after this line, `a` will be `6`.

In short, post-fix is:
1) Use it
2) Then increment

</hint>


Now, consider this code snippet:

```java
int b = 5;
System.out.println(++b); 
```

Here, we see a _prefix_ increment. Running this code, what do you observe?

<hint title="Explanation">

In this case, the value of `b` is incremented first, and then the new value is printed. So the output will be `6`, and after this line, `b` will still be `6`.

In short, pre-fix is:
1) Increment it
2) Then use it

</hint>


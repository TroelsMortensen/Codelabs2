# Exercise - print numbers from 10 to 1

Write a Java program that uses a `for` loop to print numbers from 10 descending to 1. Each number should be printed on a new line.

### Example Output:

```yaml
10
9
8
7
6
5
4
3
2
1
```

<hint title="Hint 1">

The variable `i` in a `for` loop can be initialized to a value other than 0. For this exercise, you can start `i` at 10.

</hint>

<hint title="Hint 2">

To decrement an integer in Java, you can use the `i--` operator.

</hint>

<hint title="Solution">

```java
for (int i = 10; i > 0; i--) {
    System.out.println(i);
}
```

Notice the variable `i` is initialized to 10, and the condition is `i > 0`, and the variable is decremented by 1 in each iteration. That means, we start at 10, and decrement until we reach 1, i.e. as long as `i` is greater than 0.

</hint>


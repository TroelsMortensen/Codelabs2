# Array introduction

In this learning path, we will explore arrays in Java. But first, we must generalize a bit, and talk about _collections_.

## What is a collection?

A collection is a data structure that allows you to store multiple items together. Collections can be of various types, such as lists, sets, or maps, and they can hold elements of the same type or different types.

Normally, a variable can store a single value, like an integer or a string: 

```java
int score = 95; // A single integer value
String name = "Alice"; // A single string value
```

However, collections allow you to store multiple values in a single variable. Conceptually, like this (though not valid Java syntax):

```java
ArrayOfInts scores = {95, 85, 75}; // A collection of integers
ArrayOfStrings names = {"Alice", "Bob", "Charlie"}; // A collection of strings
```

So, instead of having separate variables for each student's score, you can use a collection to store all scores in one place, in one variable.

## What is an array?

An array is a specific type of collection (in most programming languages there are many types of collections) that holds a fixed number of values of the same type. Arrays are useful when you want to store multiple items together and access them using an index, i.e. their position in the collection.

In Java, you can create an array to hold a list of integers, strings, or any other data type. The size of the array is defined when you create it, and it cannot be changed later.

```java
int[] scores = new int[5]; // An array to hold 5 integer scores
String[] names = new String[3]; // An array to hold 3 names
```

Watch the following video, to get a brief introduction to arrays in Java:

<video src="https://youtu.be/OvTsLiMCkHk" ></video>


# Exercises - round 2

We will expand on the current `Person` class to practice writing methods with various input and output types.

## Exercise 4: Greeting


First, create a person class like in the video, include field variables for `name` and `age`. Add a constructor.
### Example:

```java
public class Person {
	private String name;
	private int age;

	// Constructor
	public Person(String name, int age) {
		this.name = name;
		this.age = age;
	}
}
```

Now, add a greeting method, which prints out a greeting, the signature is:

```java
public void greet()
```

Fill in the method body to print a greeting message.

<hint title="Solution">

```java
public void greet() {
	System.out.println("Hello, my name is " + name + " and I am " + age + " years old.");
}
```

</hint>



## Exercise 5: Update name

Add a method to your `Person` class that allows you to update the person's name after the object has been created. The method should take a `String` parameter and update the `name` field.

What is the method signature?

<hint title="Hint">

Method signature: `public void setName(String newName)`

</hint>

Test your method by: 
- creating a `Person` object
- calling the greet method to verify the initial name
- update the name using your new method
- call the greet method again to verify the updated name

<hint title="Solution">

```java
public void setName(String newName) {
	this.name = newName;
}
```

The method is return type `void`, because it has no output, there is nothing relevant to return to the caller.\
It defines a parameter of type `String`. This is the value, which will be assigned to the field variable, to update the data of the `Person` instance.

</hint>




## Exercise 6: Update age

Add a method to your `Person` class that allows you to update the person's age after the object has been created. The method should take an `int` parameter and update the `age` field.

- Method signature: `public void setAge(int newAge)`

Test your method by creating a `Person` object, updating the age, and printing the result.

<hint title="Solution">

```java
public void setAge(int newAge) {
    this.age = newAge;
}
```

</hint>



## Exercise 7: Add hobby

We wish to add information about a persons hobbies. Add an ArrayList containing Strings to the person class. A hobby will just be a piece of text, a String, like "playing guitar".

Do not modify the constructor parameters, but inside the constructor, initialize the list.

<hint title="Solution">

```java
import java.util.ArrayList;

public class Person {
   
    private String name;
    private int age;
    private ArrayList<String> hobbies;

    // Constructor
    public Person(String name, int age) {
        this.name = name;
        this.age = age;
        this.hobbies = new ArrayList<>();
    }
}
```

</hint>

## Exercise 8: Add a hobby

Create a method in your `Person` class that receives a `String` hobby and adds it to the person's list of hobbies.

<hint title="Hint">

Method signature: `public void addHobby(String hobby)`

</hint>


<hint title="Solution">

```java
public void addHobby(String hobby) {
    hobbies.add(hobby);
}
```

</hint>

## Exercise 9: To string

We have added several methods to modify the data of the `person` class, but the greeint does not feel like a good place to print this all out.

Instead, override the to string method, as seen on page 5.

Print out some kind of representation of the person, including all the data, name, age, hobbies.

<hint title="Solution">

```java
@Override
public String toString() {
    return "Person{" +
            "name='" + name + '\'' +
            ", age=" + age +
            ", hobbies=" + hobbies +
            '}';
}
```

</hint>

## Exercise 10: Get age

Add a method to your `Person` class that returns the person's age. The method should have the signature:

<hint title="Hint - method signature">

```java
public int getAge()
```

</hint>

In your main method, create a `Person` object and call this method get the age of the person. Then print it out from the main method.

**Example usage**

```java
public static void main(String[] args) {
    Person person = new Person("Alice", 30);
    int age = person.getAge();
    System.out.println("Age: " + age);
}
```

<hint title="Solution">

```java
public int getAge() {
    return age;
}
```

</hint>

## Exercise 11: Hobbies as String[]

Add a method to your `Person` class that returns the person's hobbies as an array of Strings. You currently have the hobbies in an ArrayList. It must be converted to an array instead. How you do that is less important.

This is the method signature, we are looking for:

```java
public String[] getHobbies()
```

Then, in the main method, create a `Person` object, add some hobbies, and call this method to get the hobbies as an array. Using a for-loop in your main method, print out the hobbies.
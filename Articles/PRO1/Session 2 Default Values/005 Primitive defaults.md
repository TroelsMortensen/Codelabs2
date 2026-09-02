# Primitive default values

In Java, when you declare a variable without assigning a value, it gets a default value based on its type. 

### Exercise: Primitive Default Values

Here is the list of primitive types in Java, as a reminder:

```java
int myInt;
double myDouble;
boolean myBoolean;
char myChar;
byte myByte;
short myShort;
long myLong;
float myFloat;
```

Unassigned variables can only be used, if they are _field variables_, otherwise the compiler will not allow you to do anything with them. So, for this exercise, we have to use "fields". These are covered later in the course, so don't despair just yet.

Now, create a new class, for example, `PrimitiveDefaults`, and declare variables of each primitive type without assigning them a value. 

It will look something like this:

```java
void main()
{
    // code here
}

int myInt;
double myDouble;
boolean myBoolean;
char myChar;
byte myByte;
short myShort;
long myLong;
float myFloat;
```

Notice, how the variables are defined _outside_ the scope of the main method, upgrading them from _local_ variables to _field_ variables. You should now be able to print them out from the main method.

Print these variables to see their default values.

I suggest a comment for each variable to indicate its type and default value. Like:
```java	
IO.println("Default value for int: " + myInt);
```

Inspect the output to see the default values for each primitive type.


<hint title="Solution">

The result:

```java
int defaultInt = 0;             // Default value for int
double defaultDouble = 0.0;     // Default value for double
boolean defaultBoolean = false; // Default value for boolean
char defaultChar = '\u0000';    // Default value for char (null character)
byte defaultByte = 0;           // Default value for byte
short defaultShort = 0;         // Default value for short
long defaultLong = 0L;          // Default value for long
float defaultFloat = 0.0f;      // Default value for float
```
</hint>

Match each primitive type to the default value you saw.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match each primitive to its default",
  "Pairs": [
    {
      "Prompt": "<code>int</code>",
      "Answer": "<code>0</code>"
    },
    {
      "Prompt": "<code>double</code>",
      "Answer": "<code>0.0</code>"
    },
    {
      "Prompt": "<code>boolean</code>",
      "Answer": "<code>false</code>"
    },
    {
      "Prompt": "<code>char</code>",
      "Answer": "<code>'\\u0000'</code> (null character)"
    },
    {
      "Prompt": "<code>long</code>",
      "Answer": "<code>0L</code>"
    },
    {
      "Prompt": "<code>float</code>",
      "Answer": "<code>0.0f</code>"
    }
  ],
  "Hint": "Whole-number types go to zero; <code>boolean</code> is the odd one out; <code>char</code> is not a space. These are the defaults for the variables you declared in the class."
}
</Quiz>
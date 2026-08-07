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

Now, create a new class, for example, `PrimitiveDefaults`, and declare variables of each primitive type without assigning them a value. Then print these variables to see their default values.

I suggest a comment for each variable to indicate its type and default value. Like:
```java	
System.out.println("Default value for int: " + myInt);
```

Inspect the output to see the default values for each primitive type.


<hint title="Solution">


```java
int myNumber; // Declaration without assignment
System.out.println(myNumber); // This will print 0, the default value for int

boolean myBoolean; // Declaration without assignment
System.out.println(myBoolean); // This will print false, the default value for boolean
```

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
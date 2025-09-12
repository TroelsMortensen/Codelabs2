# Association Relationship

An **association** is a relationship between two classes where one class "knows about" or "uses" another class. It represents a loose coupling where objects can exist independently of each other. In a one-to-one association, each instance of one class is associated with exactly one instance of another class.

This is the most common relationship between two objects.

The short version is that one object has a reference to another object, i.e. a field variable of the first object is an instance of the second object.

Watch the following video for an overview of the association relationship:

<video src="..."></video>




## Key Characteristics

- **Loose coupling**: Objects can exist independently
- **Bidirectional or unidirectional**: Objects can reference each other
- **No ownership**: Neither object owns the other
- **Flexible**: Objects can be created and destroyed independently

## How Association Works in Java

Association is implemented by having a field variable of the first class, which is an instance of the second class.

Class `A` has a field variable `b` of type `B`. So, `A` has an association with `B`.
This field variable generally makes it an association.


## Example 1: Person and Address
In the following example, the `Person` class has a field variable `address` of type `Address`. So, `Person` has an association with `Address`.

First the `Address` class:

```java
public class Address 
{
    private String street;
    private String city;
    private String zipCode;
    
    public Address(String street, String city, String zipCode) 
    {
        this.street = street;
        this.city = city;
        this.zipCode = zipCode;
    }
    
    public String getFullAddress() 
    {
        return street + ", " + city + " " + zipCode;
    }
}
```

And here the `Person` class, notice the field variable `address` of type `Address`. This is the association.

```java
public class Person 
{
    private String name;
    private Address address; // Association with Address
    
    public Person(String name, Address address) 
    {
        this.name = name;
        this.address = address;
    }
    
    public void displayInfo() 
    {
        System.out.println("Name: " + name);
        System.out.println("Address: " + address.getFullAddress());
    }
    
    public void changeAddress(Address newAddress) 
    {
        this.address = newAddress;
    }
}
```

### Usage Example:

Here is an example of how to use the `Person` and `Address` classes.
Notice how the `Person` constructor receieves an `Address` object, in line 6.

```java
public class AssociationExample 
{
    public static void main(String[] args) 
    {
        Address homeAddress = new Address("123 Main St", "Springfield", "12345");
        Person person = new Person("John Doe", homeAddress);
        
        person.displayInfo();
        
        // Person can change address - loose coupling
        Address newAddress = new Address("456 Oak Ave", "Riverside", "67890");
        person.changeAddress(newAddress);
        
        person.displayInfo();
    }
}
```


## Key Points About Association

1. **Independence**: Both objects can exist without each other
2. **Flexibility**: Objects can be associated and disassociated at runtime
3. **No lifecycle dependency**: Destroying one object doesn't affect the other
4. **Reference-based**: Uses object references
5. **Runtime binding**: Associations can be established and changed during program execution. In the above example, during program execution, the Person object had its address changed

Association is the most flexible type of relationship and is commonly used when you need objects to work together but maintain their independence.

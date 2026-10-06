# One to one association

## Example: Person and Address

The `Person` class has a field variable `address` of type `Address`. That is the association.

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

And the `Person` class:

```java{4}
public class Person
{
    private String name;
    private Address address;

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

### Usage

Notice how the `Person` constructor receives an `Address` object. The person can also change address later — loose coupling.

```java{6}
public class AssociationExample
{
    public static void main(String[] args)
    {
        Address homeAddress = new Address("123 Main St", "Springfield", "12345");
        Person person = new Person("John Doe", homeAddress);

        person.displayInfo();

        Address newAddress = new Address("456 Oak Ave", "Riverside", "67890");
        person.changeAddress(newAddress);

        person.displayInfo();
    }
}
```

### Shared references — no ownership

Nothing prevents you from creating another `Person` and passing in the **same** `Address` object. That is because association is loose — there is no ownership.

```java
Address shared = new Address("10 Shared St", "Town", "11111");
Person alice = new Person("Alice", shared);
Person bob = new Person("Bob", shared);
// Both Alice and Bob reference the same Address instance
```

That would then be a many-to-one relationship from persons to address. The point for now: with association, multiple objects are allowed to know about the same related object.

```mermaid
classDiagram
    class Person {
        - name : String
        - address : Address
        + Person(name : String, address : Address)
        + displayInfo() void
        + changeAddress(newAddress : Address) void
    }

    class Address {
        - street : String
        - city : String
        - zipCode : String
        + Address(street : String, city : String, zipCode : String)
        + getFullAddress() String
    }

    Person --> Address
```

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "With association, two Person objects can reference the same Address instance.",
      "IsCorrect": true
    },
    {
      "Text": "Association means the Person owns the Address and no other object may reference it.",
      "IsCorrect": false
    },
    {
      "Text": "changeAddress shows that associations can be changed at runtime.",
      "IsCorrect": true
    }
  ],
  "Hint": "Review the shared references section on this page."
}
</Quiz>

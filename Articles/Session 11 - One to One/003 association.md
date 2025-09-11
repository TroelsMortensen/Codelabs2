# Association Relationship

An **association** is a relationship between two classes where one class "knows about" or "uses" another class. It represents a loose coupling where objects can exist independently of each other. In a one-to-one association, each instance of one class is associated with exactly one instance of another class.

## Key Characteristics

- **Loose coupling**: Objects can exist independently
- **Bidirectional or unidirectional**: Objects can reference each other
- **No ownership**: Neither object owns the other
- **Flexible**: Objects can be created and destroyed independently

## How Association Works in Java

Association is implemented through:
- **Instance variables** that hold references to other objects
- **Method parameters** that accept other objects
- **Return values** that provide references to other objects

## Example 1: Person and Address

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

## Example 2: Student and Course

```java
public class Course 
{
    private String courseName;
    private String instructor;
    
    public Course(String courseName, String instructor) 
    {
        this.courseName = courseName;
        this.instructor = instructor;
    }
    
    public String getCourseInfo() 
    {
        return courseName + " taught by " + instructor;
    }
}

public class Student 
{
    private String studentName;
    private Course enrolledCourse; // One-to-one association
    
    public Student(String studentName) 
    {
        this.studentName = studentName;
    }
    
    public void enrollInCourse(Course course) 
    {
        this.enrolledCourse = course;
        System.out.println(studentName + " enrolled in " + course.getCourseInfo());
    }
    
    public void dropCourse() 
    {
        if (enrolledCourse != null) 
        {
            System.out.println(studentName + " dropped " + enrolledCourse.getCourseInfo());
            enrolledCourse = null;
        }
    }
}
```

## Example 3: Car and Driver

```java
public class Driver 
{
    private String name;
    private String licenseNumber;
    
    public Driver(String name, String licenseNumber) 
    {
        this.name = name;
        this.licenseNumber = licenseNumber;
    }
    
    public String getName() 
    {
        return name;
    }
    
    public String getLicenseNumber() 
    {
        return licenseNumber;
    }
}

public class Car 
{
    private String make;
    private String model;
    private Driver driver; // Association with Driver
    
    public Car(String make, String model) 
    {
        this.make = make;
        this.model = model;
    }
    
    public void assignDriver(Driver driver) 
    {
        this.driver = driver;
        System.out.println(driver.getName() + " is now driving the " + make + " " + model);
    }
    
    public void startEngine() 
    {
        if (driver != null) 
        {
            System.out.println("Engine started by " + driver.getName());
        } 
        else 
        {
            System.out.println("No driver assigned to start the engine");
        }
    }
}
```

## Key Points About Association

1. **Independence**: Both objects can exist without each other
2. **Flexibility**: Objects can be associated and disassociated at runtime
3. **No lifecycle dependency**: Destroying one object doesn't affect the other
4. **Reference-based**: Uses object references, not inheritance
5. **Runtime binding**: Associations can be established and changed during program execution

Association is the most flexible type of relationship and is commonly used when you need objects to work together but maintain their independence.

# Writing Objects to Binary Files

Now that we have an object, the ever-present serializable `Person` object, we can write it to a file.

In this example, we write a `Person` object to a file.\
We need an `ObjectOutputStream` object. This object needs an object which can actually do the writing, in our case a FileOutput`Stream` object. This happens in lines 8-10, in the try() part.\
In line 12, we then write the `Person` object to _whatever_ the `ObjectOutputStream` object is connected to. In this case, it is connected to a `FileOutputStream` object, which is connected to a file.

```java{12}
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;

public class ObjectSerializer {
    public static void main(String[] args) 
    {
        Person person = new Person("John Doe", 25, "john@example.com");
        try (ObjectOutputStream outputStream = new ObjectOutputStream(
                new FileOutputStream("person.bin"))) 
        {
            
            outputStream.writeObject(person);
            System.out.println("Person saved to " + "person.bin");
        } 
        catch (IOException e) 
        {
            System.out.println("Error saving person: " + e.getMessage());
        }
    }
}
```

That's actually pretty simple. The `ObjectOutputStream` object is responsible for converting the `Person` object to a binary stream, and writing it to the file.

## Complete Serialization Example

Most collections in Java are serializable, so we can write a list of `Person` objects to a file.

```java
import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class CompleteSerializationExample {
    public static void main(String[] args) {
        // Create some Person objects
        List<Person> people = new ArrayList<>();
        people.add(new Person("Alice Johnson", 28, "alice@example.com"));
        people.add(new Person("Bob Smith", 35, "bob@example.com"));
        people.add(new Person("Carol Davis", 22, "carol@example.com"));
        
        try (ObjectOutputStream outputStream = new ObjectOutputStream(
                new FileOutputStream(filename))) {
            
            outputStream.writeObject(people);
            System.out.println("Saved " + people.size() + " people to " + filename);
            
        } catch (IOException e) {
            System.out.println("Error saving people: " + e.getMessage());
        }
    }
}
```

## Text vs Binary

In the above example, we could just directly write the `Person` objects to the file. 

However, we could also have come up with our own format, some string representation of the `Person` object. Maybe a comma-separated string, like this:

```
John Doe,25,john@example.com
Bob Smith,35,bob@example.com
```

And then, we could read back the text, and convert this into a `Person` object again. However, what about the `Address` object? And what about the `Country` object? Quickly, representing the object, or list of objects, as a plain text, can become rather complicated.\
Every update to the data format requires a new version of the converter. It is tedious to maintain, and super error-prone.

So, it's much easier to just write the binary data to the file. And since the data is in binary format, it can be read back by any program that knows how to interpret the binary data.

![atually](Resources/actually.jpg)

Well, _aacchually_, there is a convention for writing plain text representations of objects, called `JSON`. JSON is a lightweight data-interchange format that is easy for humans to read and write, and easy for machines to parse and generate. But, we don't deal with that here.\
For now, I recommend storing the data in binary format.
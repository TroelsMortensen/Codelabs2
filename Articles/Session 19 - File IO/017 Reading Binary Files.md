# Reading Binary Files

Now let's look at how to read binary data from files, and reconstruct Java objects. This is the complement to writing binary files and completes the cycle of data persistence.


## Reading Objects from Binary Files

Notice line 11, where we read the `Person` object from the file. Since the `readObject` method returns an `Object`, we need to cast it to a `Person` object.\
That also mean we need to know what class we are reading, so we can cast it to the correct type. And we need to deal with the possibility of a `ClassNotFoundException`.

```java{11}
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;

public class ObjectDeserializer {
    public static void main(String[] args) {
        try (ObjectInputStream inputStream = new ObjectInputStream(
                new FileInputStream("person.bin"))) 
        {
            Person person = (Person) inputStream.readObject();
            System.out.println("Person loaded from person.bin");
            System.out.println(person);
            
        } catch (IOException | ClassNotFoundException e) {
            System.out.println("Error loading person: " + e.getMessage());
        }
    }
}
```



### Reading Collections of Objects

If you stored a List of `Person` objects to a file, you can read it back into a List of `Person` objects.

```java
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.util.List;

public class CollectionReader {
    public static void main(String[] args) {
        try (ObjectInputStream inputStream = new ObjectInputStream(
                new FileInputStream("people.dat"))) {
            
            // Read the list of people
            List<Person> people = (List<Person>) inputStream.readObject();
            
            System.out.println("Loaded " + people.size() + " people:");
            for (int i = 0; i < people.size(); i++) {
                System.out.println((i + 1) + ": " + people.get(i));
            }
            
        } catch (IOException | ClassNotFoundException e) {
            System.out.println("Error reading collection: " + e.getMessage());
        }
    }
}
```

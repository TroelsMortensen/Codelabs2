# Implementation

This section shows a **general** Java implementation of the Observer pattern using an abstract Subject superclass and a Listener interface. The Subject never references concrete listener classes—only the Listener interface.

## Listener Interface

The Listener interface defines the contract: one method that receives the Subject so the listener can query its state.

```java
public interface Listener {
    void update(Subject source);
}
```

## Abstract Subject

The Subject maintains a list of Listeners and provides attach, detach, and a protected method to notify all listeners. Subclasses call `notifyListeners()` when their state changes.

```java
import java.util.ArrayList;
import java.util.List;

public abstract class Subject {
    protected final List<Listener> listeners = new ArrayList<>();

    public void attach(Listener listener) {
        listeners.add(listener);
    }

    public void detach(Listener listener) {
        listeners.remove(listener);
    }

    protected void notifyListeners() {
        for (Listener listener : listeners) {
            listener.update(this);
        }
    }
}
```

The Subject depends only on the `Listener` type. It never references concrete listener classes.

## ConcreteSubject

A concrete subject holds actual state and notifies listeners when that state changes.

```java
public class ConcreteSubject extends Subject {
    private int value;

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
        notifyListeners();
    }
}
```

When `setValue` is called, the subject updates its state and then calls `notifyListeners()`. Every attached listener will receive an `update` call.

## ConcreteListener

A concrete listener implements the Listener interface and reacts in `update`. Here it only prints; in a real application it might refresh a UI or log.

```java
public class ConcreteListener implements Listener {
    private final String name;

    public ConcreteListener(String name) {
        this.name = name;
    }

    @Override
    public void update(Subject source) {
        if (source instanceof ConcreteSubject concrete) {
            System.out.println(name + " received update: value = " + concrete.getValue());
        }
    }
}
```

The listener receives the Subject and, if it is the concrete type it cares about, reads the state and reacts. The Subject does not need to know this type—it only calls `listener.update(this)`.

## Demo

A small demo that attaches two listeners, changes the subject's state, and then detaches one listener and changes again:

```java
public class Demo {
    public static void main(String[] args) {
        ConcreteSubject subject = new ConcreteSubject();
        ConcreteListener listenerA = new ConcreteListener("Listener A");
        ConcreteListener listenerB = new ConcreteListener("Listener B");

        subject.attach(listenerA);
        subject.attach(listenerB);

        subject.setValue(10);
        // Listener A received update: value = 10
        // Listener B received update: value = 10

        subject.detach(listenerB);
        subject.setValue(20);
        // Listener A received update: value = 20
    }
}
```

## Summary

- **Listener**: Interface with `void update(Subject source)`.
- **Subject**: Abstract class with `listeners`, `attach`, `detach`, and `notifyListeners()`. Never references concrete listener classes.
- **ConcreteSubject**: Extends Subject; holds state; in mutators calls `notifyListeners()`.
- **ConcreteListener**: Implements Listener; in `update` queries the subject (if needed) and reacts.

This is the classic approach using an abstract superclass for Subject. The same structure can be applied to the problem from the previous section—a data source and multiple displays—as shown in the next file.

# Implementation

This section shows a **general** Java implementation of the Observer pattern using an abstract Subject superclass and a Listener interface. The Subject never references concrete listener classes — only the Listener interface.

## Listener Interface

The Listener interface defines the contract: one method that receives the data or state change as an Object. The listener reacts to the data without needing a reference to the Subject.

```java
public interface Listener {
    void update(Object arg);
}
```

## Abstract Subject

The abstract Subject superclass maintains a list of Listeners and provides attach, detach, and a protected method to notify all listeners with some data. Subclasses call `notifyListeners(arg)` when their state changes, passing the relevant state or data as an Object.

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

    protected void notifyListeners(Object arg) {
        for (Listener listener : listeners) {
            listener.update(arg);
        }
    }
}
```

The Subject depends only on the `Listener` type. It never references concrete listener classes.

## ConcreteSubject

A concrete subject holds actual state and notifies listeners when that state changes, passing the new state (or a value representing it) as the argument.

```java
public class ConcreteSubject extends Subject {
    private int value;

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
        notifyListeners(value);
    }
}
```

When `setValue` is called, the subject updates its state and then calls `notifyListeners(value)`. Every attached listener will receive an `update` call with that value.

## ConcreteListener

A concrete listener implements the Listener interface and reacts in `update` to the data it receives. Here it only prints; in a real application it might refresh a UI or log.

```java
public class ConcreteListener implements Listener {
    private final String name;

    public ConcreteListener(String name) {
        this.name = name;
    }

    @Override
    public void update(Object arg) {
        if (arg instanceof Integer value) {
            System.out.println(name + " received update: value = " + value);
        }
    }
}
```

The listener receives the data (here, the new value as an Integer). It does not depend on the Subject or ConcreteSubject — only on the shape of the data passed. The Subject does not need to know this; it only calls `listener.update(arg)`.

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

- **Listener**: Interface with `void update(Object arg)`; the listener receives the data or state change, not the Subject.
- **Subject**: Abstract class with `listeners`, `attach`, `detach`, and `notifyListeners(Object arg)`. Never references concrete listener classes.
- **ConcreteSubject**: Extends Subject; holds state; in mutators calls `notifyListeners(arg)` with the relevant data.
- **ConcreteListener**: Implements Listener; in `update(Object arg)` reacts to the data (e.g. by type-checking the arg).

This is the classic approach using an abstract superclass for Subject. The same structure can be applied to the problem from the previous section — a data source and multiple displays — as shown in the next file.

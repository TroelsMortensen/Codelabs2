# Garbage Collection in Java

![garbage collector](GarbageCollection.png)

Garbage collection is something that happens behind the scenes, and, generally, you do not need to worry about it. But, it is still something, you will probably encounter in your career, so it is important to understand.

## What is Garbage Collection?

Garbage Collection (GC) is an automatic memory management feature in Java that automatically frees up memory that is no longer being used by your program. Without garbage collection, you would need to manually manage memory allocation and deallocation, which can lead to memory leaks and other memory-related bugs. Just be happy we are not programming in C or C++!

Notice the "automatically" part. This means you probably don't need to worry about it too much.

## Why Do We Need Garbage Collection?

In Java, when you create objects using the `new` keyword, memory is allocated on the "heap". This is where you store your objects, and there is a limit to how much memory you can use.\
Like putting items in your backpack. At some point, you will run out of space, and you will need to throw away some items.

Without garbage collection, you would need to manually free this memory when the object is no longer needed. This manual memory management can lead to:

- **Memory leaks**: Forgetting to free memory, making your program use more and more memory, until it crashes.
- **Dangling pointers**: Using memory that has already been freed. Like throwing away an item, and then trying to use it again.
- **Double-free errors**: Trying to free the same memory twice. Like throwing away an item, and then trying to throw it away again.

We don't need to worry about this with Java, until you reach very advanced niche cases.

## How Garbage Collection Works

First, an object is created, and memory is allocated on the heap. 

### 1. Object Lifecycle
```java
public class Example {
    public static void main(String[] args) {
        // Object is created and memory is allocated
        String message = new String("Hello World");
        
        // Object is used
        System.out.println(message);
        
        // When 'message' goes out of scope, it becomes eligible for garbage collection
    }
}
```

### 2. Eligibility for Garbage Collection
An object becomes eligible for garbage collection when:
- No references point to it, i.e. you no longer have a variable pointing to it.
- All references to it are set to `null`, i.e. you are no longer using the object.
- It's part of an island of objects with no external references.

```java
public class GarbageCollectionExample {
    public static void main(String[] args) {
        // Object 1: Will be garbage collected
        String str1 = new String("First");
        str1 = null; // str1 is now eligible for GC
        
        // Object 2: Will be garbage collected
        String str2 = new String("Second");
        str2 = new String("Third"); // str2 now points to "Third", "Second" is eligible for GC
        
        // Object 3: Will NOT be garbage collected (still referenced)
        String str3 = new String("Fourth");
        System.out.println(str3); // str3 is still in use
    }
}
```

## The Garbage Collector Process

### 1. Mark Phase
The garbage collector identifies all objects that are still reachable from other references (local variables, static variables, etc.).

### 2. Sweep Phase
The garbage collector removes all objects that were not marked as reachable.


## When Does Garbage Collection Happen?

Garbage collection runs automatically when:
- The heap is running out of memory
- The JVM decides it's time to clean up
- You explicitly call `System.gc()` (though this is not recommended)

## Summary

Garbage collection in Java:
- Automatically manages memory allocation and deallocation
- Prevents memory leaks and dangling pointers
- Runs automatically when needed
- Works by marking reachable objects and sweeping unreachable ones
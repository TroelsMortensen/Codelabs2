# Code line highlight

How to highlight lines in a code block.

Single line:

```java{3}
public class Main {
    public static void main(String[] args) {
        System.out.println("Hello, World!");
        System.out.println("Hello, People!");
    }
}
```

Multiple single lines:

```java{2,4}
public class Main {
    public static void main(String[] args) {
        System.out.println("Hello, World!");
        System.out.println("Hello, People!");
    }
}
```

Range of lines:

```java{2-4}
public class Main {
    public static void main(String[] args) {
        System.out.println("Hello, World!");
        System.out.println("Hello, People!");
    }
}
```
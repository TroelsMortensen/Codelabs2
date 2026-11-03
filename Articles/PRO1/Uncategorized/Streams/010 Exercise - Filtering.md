# Exercise — Filtering

You will filter a list of **students**. First set up the supporting code, then solve each filtering task with a stream (`filter` + `toList`). Use `printStudents` to show your results.

## Exercise 1 — The Student class

Create a `Student` class.

You can use this version:

```java
class Student {
    private String name;
    private int age;
    private double average;
    private String programme;

    Student(String name, int age, double average, String programme) {
        this.name = name;
        this.age = age;
        this.average = average;
        this.programme = programme;
    }

    String getName() { return name; }
    int getAge() { return age; }
    double getAverage() { return average; }
    String getProgramme() { return programme; }

    @Override
    public String toString() {
        return name + " (" + age + "), avg " + average + ", " + programme;
    }
}
```

## Starter code

Add this print helper and the list of 20 students. Put your filtering code in `main`.

```java
void printStudents(List<Student> students) {
    IO.println("----------------------------------------");
    for (Student student : students) {
        IO.println(student);
    }
    IO.println("Total: " + students.size());
    IO.println("----------------------------------------");
}

void main() {
    List<Student> students = List.of(
        new Student("Alice", 19, 10.5, "Software"),
        new Student("Ben", 17, 7.0, "Business"),
        new Student("Cara", 22, 11.2, "Software"),
        new Student("Dan", 18, 5.5, "Design"),
        new Student("Eva", 20, 9.0, "Business"),
        new Student("Finn", 16, 8.5, "Software"),
        new Student("Gina", 21, 6.0, "Design"),
        new Student("Hugo", 19, 12.0, "Software"),
        new Student("Ivy", 23, 4.5, "Business"),
        new Student("Jack", 18, 9.5, "Design"),
        new Student("Kara", 17, 10.0, "Software"),
        new Student("Leo", 20, 7.5, "Business"),
        new Student("Mia", 19, 11.0, "Design"),
        new Student("Noah", 24, 8.0, "Software"),
        new Student("Olga", 18, 3.5, "Business"),
        new Student("Pete", 21, 9.8, "Design"),
        new Student("Quinn", 17, 6.5, "Software"),
        new Student("Rita", 22, 10.2, "Business"),
        new Student("Sam", 19, 5.0, "Design"),
        new Student("Tess", 20, 11.5, "Software")
    );

    printStudents(students);

    // Your filtering exercises go here
}
```

Run it once and check that all 20 students print.

## Exercise 2 — Adults (stream)

Using a stream, build a new list of students who are **18 or older**. Print the result with `printStudents`.


## Exercise 3 — Strong averages

Keep only students with an average **of at least 10.0**. Print the filtered list.

## Exercise 4 — Software programme

Keep only students on the `"Software"` programme. Print the list.

## Exercise 5 — Design and under 20

Keep students who are on `"Design"` **and** younger than 20. Print the list.

## Exercise 6 — Predicate as a method

Write a method `boolean isPassing(Student s)` that returns `true` when the average is **at least 6.0**. Filter with a **method reference** to that method, collect with `toList()`, and print.

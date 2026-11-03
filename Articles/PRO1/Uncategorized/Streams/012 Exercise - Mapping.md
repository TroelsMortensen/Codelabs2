# Exercise — Mapping

Reuse the `Student` class and the list of 20 students from the Filtering exercises.

## Exercise 1 — Just the names

Use `map` and `toList()` to build a `List<String>` of every student’s name. Use a method reference (`Student::getName`). Print the list.

## Exercise 2 — Report lines

Map each student to a single report line in this format:

```text
Alice — Software — avg 10.5
```

Collect the lines into a `List<String>` and print each line. You will need a lambda here (a plain method reference is not enough).

## Exercise 3 — Map to a new class

Create a small class `StudentCard` with:

- `name` (`String`)
- `programme` (`String`)
- a constructor, getters, and a `toString()`

Map every `Student` to a `StudentCard` that keeps only the name and programme. Collect to a `List<StudentCard>` and print each card.

Hint: `s -> new StudentCard(s.getName(), s.getProgramme())`.

## Exercise 4 — Software averages

Keep only students on the `"Software"` programme, then map them to their **average** (`Double`). Collect to a list and print it.

Expected idea: a list of averages such as `[10.5, 11.2, 8.5, …]` — only from Software students, in list order.

## Exercise 5 — Honour roll labels

Build a list of **labels** for students who:

- are **18 or older**, and  
- have an average **of at least 10.0**

Each label must look like:

```text
HUGO (Software): 12.0
```

That is: the name in **uppercase**, the programme in parentheses, then the average after a colon.

Filter first, then map to the label string, then `toList()`. Print each label on its own line.

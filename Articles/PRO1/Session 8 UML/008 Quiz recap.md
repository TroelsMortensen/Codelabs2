# Quiz recap

Test your understanding of reading UML class diagrams before you move on to the coding exercises.

## 1

Match each compartment of a UML class box to what it holds.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the Class Compartments",
  "Pairs": [
    {
      "Prompt": "Top compartment",
      "Answer": "Class name"
    },
    {
      "Prompt": "Middle compartment",
      "Answer": "Attributes (fields)"
    },
    {
      "Prompt": "Bottom compartment",
      "Answer": "Methods (operations)"
    }
  ],
  "Hint": "See page 2 Classes in UML — the rectangle is split into three compartments."
}
</Quiz>

## 2

Match each UML visibility symbol to its meaning.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match Access Modifiers",
  "Pairs": [
    {
      "Prompt": "+",
      "Answer": "Public — accessible from outside the class"
    },
    {
      "Prompt": "-",
      "Answer": "Private — only accessible within the class"
    },
    {
      "Prompt": "#",
      "Answer": "Protected — accessible in the class and its subclasses"
    }
  ],
  "Hint": "See page 3 Access modifiers — the symbols are prefixes on attributes and methods."
}
</Quiz>

## 3

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Which statement about UML is correct?</p>",
  "Options": [
    {
      "Text": "UML is a standardized visual language for modeling software; it is not a programming language and is not Java-specific.",
      "IsCorrect": true
    },
    {
      "Text": "UML is a programming language that compiles to Java bytecode.",
      "IsCorrect": false
    },
    {
      "Text": "UML can only be used with Java.",
      "IsCorrect": false
    },
    {
      "Text": "UML replaces the need to write any code.",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Think of the blueprint analogy on page 1 Introduction.",
  "Explanation": "UML (Unified Modeling Language) is a standardized graphical language used to visualize and document software design. It is not a programming language and is not tied to Java."
}
</Quiz>

## 4

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>How do you write a private <code>String</code> field named <code>name</code> in UML?</p>",
  "Options": [
    {
      "Text": "<code>- name: String</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>- String name</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>+ name: String</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>private name: String</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "In UML the order is opposite of Java: name first, then type. Private uses <code>-</code>. See page 5 Field variables.",
  "Explanation": "UML attributes use the form <code>visibility name: Type</code>. Private is <code>-</code>, so a private String field is <code>- name: String</code>."
}
</Quiz>

## 5

Decide whether each statement is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "A constructor in UML has a return type of <code>void</code>.",
      "IsCorrect": false
    },
    {
      "Text": "In UML, a field is written as name then type, for example <code>age: int</code>.",
      "IsCorrect": true
    },
    {
      "Text": "Methods appear in the bottom compartment of the class box.",
      "IsCorrect": true
    },
    {
      "Text": "The <code>#</code> symbol means protected and is mainly for subclasses (you will learn more about it later).",
      "IsCorrect": true
    }
  ],
  "Hint": "Review constructors (no return type), field notation, compartments, and access modifiers on pages 2–6."
}
</Quiz>

## 6

Here is a small UML class (shown as text):

<pre>Person
----------------
- name: String
- age: int
----------------
+ Person(name: String, age: int)
+ greet(): void
+ getName(): String
+ setAge(age: int): void
</pre>

Select every correct statement.

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which of the following statements are correct for the <code>Person</code> class above?</p>",
  "Options": [
    {
      "Text": "<code>name</code> and <code>age</code> are private fields.",
      "IsCorrect": true
    },
    {
      "Text": "<code>getName()</code> and <code>setAge(...)</code> are public methods.",
      "IsCorrect": true
    },
    {
      "Text": "<code>Person(name: String, age: int)</code> is the constructor.",
      "IsCorrect": true
    },
    {
      "Text": "<code>greet()</code> is a private method.",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "<code>-</code> means private, <code>+</code> means public. The constructor has the same name as the class and no return type.",
  "Explanation": "<code>name</code> and <code>age</code> use <code>-</code>, so they are private. All listed operations use <code>+</code>, so they are public — including <code>greet()</code>. The line named <code>Person</code> with parameters and no return type is the constructor."
}
</Quiz>

## 7

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>How is this Java method written in UML?<br><code>public void setAge(int age)</code></p>",
  "Options": [
    {
      "Text": "<code>+ setAge(age: int): void</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>- setAge(age: int): void</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>+ void setAge(int age)</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>+ setAge(int age): void</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Public is <code>+</code>. Parameters use <code>name: Type</code>. The return type comes after a colon at the end. See page 7 Methods.",
  "Explanation": "UML methods use visibility, then name, then parameters as <code>name: Type</code>, then the return type: <code>+ setAge(age: int): void</code>."
}
</Quiz>

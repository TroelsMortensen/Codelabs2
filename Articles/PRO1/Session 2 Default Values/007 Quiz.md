# Quiz

Test your understanding of this learning path: the two type categories, declaration and assignment, how values sit in memory, primitive and reference defaults, string comparison, and `NullPointerException`.

## 1

Match each primitive type to its default value.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match each primitive to its default value",
  "Pairs": [
    {
      "Prompt": "<code>int</code>",
      "Answer": "<code>0</code>"
    },
    {
      "Prompt": "<code>double</code>",
      "Answer": "<code>0.0</code>"
    },
    {
      "Prompt": "<code>boolean</code>",
      "Answer": "<code>false</code>"
    },
    {
      "Prompt": "<code>char</code>",
      "Answer": "<code>'\\u0000'</code> (null character)"
    },
    {
      "Prompt": "<code>long</code>",
      "Answer": "<code>0L</code>"
    },
    {
      "Prompt": "<code>float</code>",
      "Answer": "<code>0.0f</code>"
    }
  ],
  "Hint": "Whole-number types go to zero; <code>boolean</code> is the odd one out; <code>char</code> is not a space. See page 5 Primitive defaults."
}
</Quiz>

## 2

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Which statement is correct?</p>",
  "Options": [
    {
      "Text": "<code>String</code> is a reference type (an object). Primitive types hold a single value.",
      "IsCorrect": true
    },
    {
      "Text": "<code>int</code> is a reference type.",
      "IsCorrect": false
    },
    {
      "Text": "Primitive types and reference types store their values in the same way.",
      "IsCorrect": false
    },
    {
      "Text": "<code>boolean</code> is an object.",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Java has two categories of types. See page 2 Types.",
  "Explanation": "<code>String</code> is a reference type. Primitives such as <code>int</code>, <code>double</code>, and <code>boolean</code> each hold a single value, not an object."
}
</Quiz>

## 3

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>In this code, which line is the assignment?</p><pre>int x;\nx = 5;</pre>",
  "Options": [
    {
      "Text": "<code>x = 5;</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>int x;</code>",
      "IsCorrect": false
    },
    {
      "Text": "Both lines are assignments",
      "IsCorrect": false
    },
    {
      "Text": "Neither line is an assignment",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Declaration names the variable and its type. Assignment puts a value in. See page 3 Declaration and assignment.",
  "Explanation": "<code>int x;</code> is the declaration. <code>x = 5;</code> is the assignment that stores <code>5</code> in <code>x</code>."
}
</Quiz>

## 4

Decide whether each statement about memory is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "A primitive value lives in the variable itself.",
      "IsCorrect": true
    },
    {
      "Text": "A <code>String</code> variable holds the characters directly.",
      "IsCorrect": false
    },
    {
      "Text": "A reference is a note or address of an object.",
      "IsCorrect": true
    },
    {
      "Text": "An unassigned reference points to <code>null</code>.",
      "IsCorrect": true
    }
  ],
  "Hint": "Think of the utility belt and the backpack. See page 4 In memory."
}
</Quiz>

## 5

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>What does printing an unassigned <code>String</code> field show?</p>",
  "Options": [
    {
      "Text": "The text <code>null</code>",
      "IsCorrect": true
    },
    {
      "Text": "An empty string <code>\"\"</code>",
      "IsCorrect": false
    },
    {
      "Text": "The string <code>\"null\"</code> that you assigned yourself",
      "IsCorrect": false
    },
    {
      "Text": "The program crashes",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Printing a missing object is allowed. Calling a method on it is not. See page 6 Reference type defaults.",
  "Explanation": "An unassigned <code>String</code> is <code>null</code>. Printing it writes the text <code>null</code>. That is not an empty string, and it is not a crash."
}
</Quiz>

## 6

Select every correct statement about comparing strings.

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which of the following statements are correct?</p>",
  "Options": [
    {
      "Text": "<code>.equals()</code> compares the content of two strings.",
      "IsCorrect": true
    },
    {
      "Text": "<code>==</code> on reference types tests whether both variables point to the same object in memory.",
      "IsCorrect": true
    },
    {
      "Text": "Two variables created with <code>new String(\"hello\")</code> are <code>==</code>.",
      "IsCorrect": false
    },
    {
      "Text": "You should use <code>==</code> to compare string content.",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "<code>==</code> asks \"same object?\". <code>.equals()</code> asks \"same content?\". See page 6 Equals.",
  "Explanation": "Two <code>new String(\"hello\")</code> objects have the same content, so <code>.equals()</code> is true, but they are different objects, so <code>==</code> is false. Use <code>.equals()</code> when you care about content."
}
</Quiz>

## 7

Arrange the lines so the program declares `x`, assigns a value, then prints it.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines so the method declares x, assigns 5, then prints it.",
  "Lines": [
    { "Id": 1, "Content": "void main() {" },
    { "Id": 2, "Content": "    int x;" },
    { "Id": 3, "Content": "    x = 5;" },
    { "Id": 4, "Content": "    System.out.println(x);" },
    { "Id": 5, "Content": "}" }
  ],
  "Hint": "Declare first, then assign, then use the variable. See page 3 Declaration and assignment."
}
</Quiz>

## 8

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>What went wrong when <code>myString</code> is <code>null</code> and the program runs <code>myString.equals(otherString)</code>?</p>",
  "Options": [
    {
      "Text": "You tried to call a method on nothing.",
      "IsCorrect": true
    },
    {
      "Text": "Java cannot print the word <code>null</code>.",
      "IsCorrect": false
    },
    {
      "Text": "<code>otherString</code> has the wrong type.",
      "IsCorrect": false
    },
    {
      "Text": "<code>.equals()</code> only works if you also use <code>==</code>.",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "The method is called on <code>myString</code>. See page 6 Null pointer exception.",
  "Explanation": "You tried to do something with nothing. <code>myString</code> does not point to an object, so Java cannot call <code>.equals()</code> on it. Printing <code>null</code> would have been fine."
}
</Quiz>

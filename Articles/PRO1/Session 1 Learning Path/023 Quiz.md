# Quiz

Test your understanding of the basics from this learning path: the `main` method, printing and comments, variables and naming, primitive types, numbers and casting, characters and strings, and the equality, relational, and conditional operators.

## 1

Match each primitive type to the description that fits it best.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match Primitive Types",
  "Pairs": [
    {
      "Prompt": "int",
      "Answer": "32-bit whole number"
    },
    {
      "Prompt": "double",
      "Answer": "64-bit floating-point number"
    },
    {
      "Prompt": "boolean",
      "Answer": "Represents true or false"
    },
    {
      "Prompt": "char",
      "Answer": "A single 16-bit Unicode character"
    },
    {
      "Prompt": "long",
      "Answer": "64-bit whole number"
    },
    {
      "Prompt": "float",
      "Answer": "32-bit floating-point number"
    }
  ]
}
</Quiz>

## 2

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>What is the role of the <code>main</code> method in a Java program?</p>",
  "Options": [
    {
      "Text": "It is the entry point where the program starts executing.",
      "IsCorrect": true
    },
    {
      "Text": "It is only used to declare variables for the rest of the program.",
      "IsCorrect": false
    },
    {
      "Text": "It prints text to the console automatically.",
      "IsCorrect": false
    },
    {
      "Text": "It is optional and can be replaced by any method named <code>start</code>.",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Think about where the Java Virtual Machine begins running your code.",
  "Explanation": "The <code>main</code> method is the entry point of a Java application. When you run the program, execution starts inside <code>main</code>."
}
</Quiz>

## 3

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Which statement correctly prints text to the console and then moves to a new line?</p>",
  "Options": [
    {
      "Text": "<code>System.out.println(\"Hello\");</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>print(\"Hello\");</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>Console.write(\"Hello\");</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>System.print.line(\"Hello\");</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Look for the standard Java output call that ends with <code>ln</code>.",
  "Explanation": "In Java you print with <code>System.out.println(...)</code>. The <code>ln</code> means the cursor moves to a new line after printing."
}
</Quiz>

## 4

Select every option that follows common Java naming conventions.

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which of the following follow common Java naming conventions?</p>",
  "Options": [
    {
      "Text": "Class name: <code>MyClass</code>",
      "IsCorrect": true
    },
    {
      "Text": "Variable name: <code>firstName</code>",
      "IsCorrect": true
    },
    {
      "Text": "Method name: <code>printHelloWorld</code>",
      "IsCorrect": true
    },
    {
      "Text": "Variable name: <code>First_Name</code>",
      "IsCorrect": false
    },
    {
      "Text": "Class name: <code>myClass</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Classes use PascalCase; variables and methods use camelCase.",
  "Explanation": "Classes are written in PascalCase (<code>MyClass</code>). Variables and methods use camelCase (<code>firstName</code>, <code>printHelloWorld</code>). <code>First_Name</code> and <code>myClass</code> do not follow those conventions."
}
</Quiz>

## 5

Decide whether each statement about variables, assignment, and scope is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "In Java, a complete statement must end with a semicolon (;).",
      "IsCorrect": true
    },
    {
      "Text": "You can use a variable in code before it has been declared.",
      "IsCorrect": false
    },
    {
      "Text": "The = operator assigns a value to a variable.",
      "IsCorrect": true
    },
    {
      "Text": "Java is case-sensitive, so myVariable and myvariable are different names.",
      "IsCorrect": true
    }
  ]
}
</Quiz>

## 6

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>What is the result of the integer division <code>10 / 3</code> in Java?</p>",
  "Options": [
    {
      "Text": "<code>3</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>3.333...</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>3.0</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>4</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "When both operands are integers, the decimal part is not kept.",
  "Explanation": "Integer division discards the fractional part (it truncates toward zero). So <code>10 / 3</code> is <code>3</code>, not <code>3.33</code> or <code>4</code>."
}
</Quiz>

## 7

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Which declaration compiles correctly in Java?</p>",
  "Options": [
    {
      "Text": "<code>float myFloat = 3.14f;</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>float myFloat = 3.14;</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>float myFloat = 3.14d;</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>float myFloat = \"3.14\";</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "A decimal literal without a suffix is treated as a <code>double</code>.",
  "Explanation": "A floating-point literal like <code>3.14</code> is a <code>double</code> by default. To store it in a <code>float</code>, write <code>3.14f</code> (or <code>3.14F</code>). Likewise, large whole-number literals often need <code>L</code> for <code>long</code>."
}
</Quiz>

## 8

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>What is the value of <code>myInt</code> after this code runs?</p><pre>double myDouble = 5.7;\nint myInt = (int) myDouble;</pre>",
  "Options": [
    {
      "Text": "<code>5</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>6</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>5.7</code>",
      "IsCorrect": false
    },
    {
      "Text": "It does not compile",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "An explicit cast from <code>double</code> to <code>int</code> does not round.",
  "Explanation": "Down-casting from <code>double</code> to <code>int</code> requires an explicit cast and truncates the fractional part. <code>(int) 5.7</code> becomes <code>5</code>, not <code>6</code>."
}
</Quiz>

## 9

Arrange the lines so the program declares a class with a `main` method, creates an `int` variable, and prints it.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to create a valid Java class that declares an int and prints it from main.",
  "Lines": [
    { "Id": 1, "Content": "public class Example {" },
    { "Id": 2, "Content": "    public static void main(String[] args) {" },
    { "Id": 3, "Content": "        int number = 5;" },
    { "Id": 4, "Content": "        System.out.println(number);" },
    { "Id": 5, "Content": "    }" },
    { "Id": 6, "Content": "}" }
  ]
}
</Quiz>

## 10

Select every correct statement about characters, strings, and escape sequences.

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which of the following statements are correct?</p>",
  "Options": [
    {
      "Text": "A <code>char</code> uses single quotes, e.g. <code>'A'</code>.",
      "IsCorrect": true
    },
    {
      "Text": "A <code>String</code> uses double quotes, e.g. <code>\"Hello\"</code>.",
      "IsCorrect": true
    },
    {
      "Text": "<code>\\n</code> inside a string creates a new line when printed.",
      "IsCorrect": true
    },
    {
      "Text": "<code>\"A\"</code> and <code>'A'</code> are the same type in Java.",
      "IsCorrect": false
    },
    {
      "Text": "To include a double quote inside a string, you write <code>\\\"</code>.",
      "IsCorrect": true
    }
  ],
  "Shuffle": true,
  "Hint": "Remember the difference between single quotes and double quotes, and how backslash escapes work.",
  "Explanation": "<code>char</code> values use single quotes; <code>String</code> values use double quotes, so <code>\"A\"</code> and <code>'A'</code> are different types. Escape sequences like <code>\\n</code> and <code>\\\"</code> change how the string is printed or written."
}
</Quiz>

## 11

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>How should you compare the <em>content</em> of two <code>String</code> values in Java?</p>",
  "Options": [
    {
      "Text": "Use <code>str1.equals(str2)</code>",
      "IsCorrect": true
    },
    {
      "Text": "Use <code>str1 == str2</code>",
      "IsCorrect": false
    },
    {
      "Text": "Use <code>str1 = str2</code>",
      "IsCorrect": false
    },
    {
      "Text": "Use <code>str1.compare(str2)</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "The <code>==</code> operator is for primitives; strings are objects.",
  "Explanation": "For string content, always use <code>.equals()</code>. The <code>==</code> operator may appear to work sometimes because of string interning, but it is unreliable for comparing content."
}
</Quiz>

## 12

Decide whether each statement about operators is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "For ints, the expression 5 == 5 evaluates to true.",
      "IsCorrect": true
    },
    {
      "Text": "The expression true && false evaluates to false.",
      "IsCorrect": true
    },
    {
      "Text": "The expression true || false evaluates to false.",
      "IsCorrect": false
    },
    {
      "Text": "The expression !false evaluates to true.",
      "IsCorrect": true
    },
    {
      "Text": "For ints a = 5 and b = 10, the expression a > b evaluates to true.",
      "IsCorrect": false
    },
    {
      "Text": "You should use == to compare the content of two String values.",
      "IsCorrect": false
    }
  ]
}
</Quiz>

## 13

Flip each card to revise key facts from this learning path.

<Quiz>
{
  "Type": "FlashCardSet",
  "Title": "Session 1 Quick Revision",
  "Cards": [
    {
      "Front": "What is the result of integer division 5 / 2?",
      "Back": "2 (the fractional part is discarded)"
    },
    {
      "Front": "How do you compare two Strings by content?",
      "Back": "Use str1.equals(str2)"
    },
    {
      "Front": "What literal suffix is needed for a float?",
      "Back": "f or F (e.g. 3.14f)"
    },
    {
      "Front": "char vs String quotes?",
      "Back": "char uses 'A'; String uses \"A\""
    },
    {
      "Front": "What does (int) 5.7 evaluate to?",
      "Back": "5 (truncates, does not round)"
    },
    {
      "Front": "What do &&, ||, and ! mean?",
      "Back": "AND (both true), OR (at least one true), NOT (flips true/false)"
    },
    {
      "Front": "How do you concatenate \"John\" and \"Doe\" with a space?",
      "Back": "\"John\" + \" \" + \"Doe\""
    },
    {
      "Front": "Class naming convention?",
      "Back": "PascalCase (e.g. MyClass)"
    }
  ]
}
</Quiz>

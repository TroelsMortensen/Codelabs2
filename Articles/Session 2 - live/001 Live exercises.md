## Live Exercises: Primitives, Printing, Console Input, and String Methods

### Exercise 1 - Coffee Receipt

Write a program that reads a drink name, size, unit price, and quantity, then prints a formatted receipt line and the total.

The interaction should look like this:

```console
Enter drink name:
Latte                   <-- User input
Enter size:
Medium                  <-- User input
Enter unit price:
3.5                     <-- User input
Enter quantity:
2                       <-- User input
Result: You ordered 2 medium lattes for a total of 7.00
```


### Exercise 2 - Username Generator

Read full name and birth year, then generate a username by concatenating: 
* first 3 letters of first name
* last 3 letters of last name 
* last 2 digits of year 
 
(Capitalize the first letter of the three characters from the first and last name).

**Example output:**

```console
Full name:
Ada Lovelace              <-- User input
Birth year:
1815                      <-- User input
Generated username: AdaAce15
```

**Another example**

```console
Full name:
John Doe                  <-- User input
Birth year:
1990                      <-- User input
Generated username: JohDoe90
```

**Another example**

```console
Full name:
Jane Smith                <-- User input
Birth year:
2000                      <-- User input
Generated username: JanIth00
```

### Exercise 3 - SMS Normalizer

Read a message and output:
- Trimmed text
- Collapsed spaces (multiple → one, this one might be tricky)
- Lowercased version
- Character counts

```console
Message:
   Hello,   World            <-- User input
Trimmed: "Hello,   World"
Collapsed: "Hello, World"
Lower: "hello, world"
Chars: 12
```


### Exercise 4 - Palindrome (Forgiving)

Read a phrase; ignore case and non-letters; check if it is a palindrome.

```console
Phrase:
Never odd or even
Normalized: neveroddoreven
Is palindrome: true
```

Here are a few palindromes to test with:
* Racecar
* Madam, I'm Adam
* No lemon, no melon
* Step on no pets
* Was it a car or a cat I saw?
* A man, a plan, a canal, Panama


### Exercise 5 - Is Double an Integer?

Write a program that reads a `double` from the console and prints whether it is an integer value (`true` or `false`).

The interaction should look like this:

```console
Enter a number:
3.0
Is integer: true
```

Another run:

```console
Enter a number:
3.14
Is integer: false
```


### Exercise 6 - Fifteen Rule

Write a program that accepts two integers and prints `true` if either 
* number is 15, or
* their sum is 15, or
* their absolute difference is 15. 
* otherwise print `false`.

```console
Enter first integer:
10
Enter second integer:
5
Result: true
```

Another run:

```console
Enter first integer:
9
Enter second integer:
25
Result: true
```

Another run:

```console
Enter first integer:
7
Enter second integer:
8
Result: true
```

Another run:

```console
Enter first integer:
2
Enter second integer:
9
Result: false
```


### Exercise 7 - String Equality

Read two lines of text. Print whether they are exactly equal, and whether they are equal ignoring case.

```console
First text:
Hello
Second text:
hello
Equals (exact): false
Equals (ignore case): true
```


### Exercise 8 - Vowel Masker

Read a line of text. Replace all vowels (a, e, i, o, u) regardless of case with '*'. Also print how many vowels were replaced.

```console
Input:
Education
Masked: *d*c*t**n
Vowels replaced: 5
```


### Exercise 9 - Word Length Comparator

Read two words. Print which word is longer, or that they are equal length, followed by their lengths.

```console
First word:
apple
Second word:
pear
Longer: apple (5 vs 4)
```

### Exercise 10 - Make ABBA

Given two strings, a and b, return the result of putting them together in the order abba, e.g. "Hi" and "Bye" returns "HiByeByeHi".

Copy in the follow code snippet and complete the `makeAbba` method:

```java
public class MakeAbba {
    public static void main(String[] args) {
        printAbba("Hi", "Bye");     // "HiByeByeHi"
        printAbba("Yo", "Alice");   // "YoAliceAliceYo"
        printAbba("What", "Up");    // "WhatUpUpWhat"
        printAbba("Hello", "World"); // "HelloWorldWorldHello"
    }

    static void printAbba(String a, String b) {
        // Your logic here
    }
}
```
 


### Exercise 11 - Make tags

The web is built with HTML strings like `<i>Yay</i>` which draws Yay as italic text. 

In this example, the "i" tag makes `<i>` and `</i>` which surround the word "Yay". Given tag and word strings, create the HTML string with tags around the word, e.g. `<i>Yay</i>`.

Copy the following code snippet and complete the `makeTags` method:

```java
public class MakeTags {
    public static void main(String[] args) {
        printTags("i", "Yay");       // "<i>Yay</i>"
        printTags("b", "Hello");     // "<b>Hello</b>"
        printTags("div", "World");   // "<div>World</div>"
        printTags("span", "Java");   // "<span>Java</span>"
    }

    static void printTags(String tag, String word) {
        // Your logic here
    }
}
```

### Exercise 12 - Extra end

Given a string, return a new string made of 3 copies of the last 2 chars of the original string. The string length will be at least 2.

```java
public class ExtraEnd {
    public static void main(String[] args) {
        printExtraEnd("Hello"); // "lolo"
        printExtraEnd("ab");    // "ababab"
        printExtraEnd("Hi");    // "HiHiHi"
    }

    public static void printExtraEnd(String str) {
        // Your logic here
    }
}
```

### Exercise 13 - Without ends

Given a string, return a version without the first and last char, so "Hello" yields "ell". The string length will be at least 2.

```java
public class WithoutEnds {
    public static void main(String[] args) {
        printWithoutEnds("Hello"); // "ell"
        printWithoutEnds("java"); // "av"
        printWithoutEnds("coding"); // "odin"
    }

    public static void printWithoutEnds(String str) {
        // Your logic here
    }
}
```

### Exercise 14 - Combo string

Given 2 strings, a and b, return a string of the form short+long+short, with the shorter string on the outside and the longer string on the inside. 

The strings will not be the same length, but they may be empty (length 0).

```java
public class ComboString {
    public static void main(String[] args) {
        printComboString("hi", "hello"); // "hiHellohi"
        printComboString("hello", "hi"); // "hiHellohi"
        printComboString("abc", "defgh"); // "abcdefgabc"
        printComboString("java", "c"); // "cjavac"
    }

    public static void printComboString(String a, String b) {
        // Your logic here
    }
}
```

### Exercise 15 - Rotate left 2


Given a string, return a "rotated left 2" version where the first 2 chars are moved to the end. The string length will be at least 2.

```java
public class Rotate2 {
    public static void main(String[] args) {
        printRotate2("Hello"); // "lloHe"
        printRotate2("java"); // "vaja"
        printRotate2("coding"); // "dingco"
    }

    public static void printRotate2(String str) {
        // Your logic here
    }
}
```

### Exercise 16 - Rotate right 2


Given a string, return a "rotated right 2" version where the last 2 chars are moved to the start. The string length will be at least 2.

```java
public class RotateRight2 {
    public static void main(String[] args) {
        printRotateRight2("Hello"); // "loHel"
        printRotateRight2("java"); // "vaja"
        printRotateRight2("coding"); // "ngcodi"
    }

    public static void printRotateRight2(String str) {
        // Your logic here
    }
}
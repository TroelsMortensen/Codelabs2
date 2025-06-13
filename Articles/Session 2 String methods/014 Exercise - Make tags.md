# Exercise - Make tags

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



## Initial context
I have a learning path app, each learning path consists of a couple of steps. I may want to include various types of quizzes along the way to help the reader learn. I currently have a SingleChoiceQuiz, see @UI/Pages/QuizComponents/SingleChoiceQuiz.razor, and MultipleChoiceQuiz, see @UI/Pages/QuizComponents/MultipleChoiceQuiz.razor, and FlashCardSet, see @UI/Pages/QuizComponents/FlashCardSet.razor.
Also see the @Skills/QuizStructure.md for more information. 
You may also see @Articles/Stuff/Feature Tester/007 Single choice quiz.md for an example usage. Or @Articles/Stuff/Feature Tester/008 Flash card set.md for an example of usage. Or @Articles/Stuff/Feature Tester/009 Multiple choice quiz.md for an example of usage.

Keep the styling similar to the Single Choice Quiz and the Flash Card Set.




## Tasks
Create a new type of quiz component, based on the below description in the New type section.

Create new record types to match, in the MdToHtmlConversion/Models/QuizzModels.cs file.

Create a new markdown file in the Articles/Stuff/Feature Tester folder to test this new type of quiz, similar to the other quiz files here.

Create unit tests, similar to the other quiz tests.

Make sure to update the Skills/QuizStructure.md file to include the new type of quiz.

The location for this new component should be in Pages/QuizComponents/ExpandableDetails.razor. 

Update the switch statement in the Article page to handle this new type as well. 

Also update the switch statement in @MdToHtmlConversion/Transformers/ConvertMarkdownToHtml.cs to handle the new type of quiz.

## New type
Now I need a new type, a kind of expandable details, it's not really a quiz.
It looks like the html details element.
There is a header shown on the bar, and when the user clicks the header, the details are expanded to show the content.
There can be multiple expandable details in this particular "quiz" block.

The styling should be similar to the Single Choice Quiz and the Flash Card Set. It is a stack of rectangles, with the header horizontally left aligned, and vertically centered. There is a plus icon on the right side of the rectangle.

The json data structure is a list of objects, each object has a header and a content. Something like this:

```html
<Quiz>
{
    "Type": "ExpandableDetails",
    "Details": [
        {
            "Header": "What is the capital of France?",
            "Content": "Paris"
        }
    ]
}
</Quiz>
```
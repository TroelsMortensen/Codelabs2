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

The location for this new component should be in Pages/QuizComponents/MatchPair/... 

Update the switch statement in the Article page to handle this new type as well. 

Also update the switch statement in @MdToHtmlConversion/Transformers/ConvertMarkdownToHtml.cs to handle the new type of quiz.

## New type
I need a new type of quiz, MatchPair. 

* The data is a collection of pairs, each pair consists of a "Prompt" and a "Answer".
* The quiz layout is two columns, all Prompts are in the left column, and all Answers are in the right column. Both are shuffled.
* The user can click on a prompt, and an answer to combine them.
* When all prompts and answers are combined, the user can submit the quiz to get a result.
* When a pair is made, it is moved to the bottom of the list.
* The user can click on a pair to undo the pair.
* When the user clicks on a prompt, that is selected. The user can click on another prompt to unselect the first one, and select the second one.
* If the user clicks on a prompt that is already selected, it is unselected.
* The user can click on a answer to select it. The user can click on another answer to unselect the first one, and select the second one.
* If the user clicks on an answer that is already selected, it is unselected.
* The user can click on a pair to undo the pair.

The cards for prompts and answers should look like puzzle pieces, i.e. the prompts are on the left, and they have a circular indentation on the right. The answers are on the right, and they have a circular protrusion on the left. When a pair is made, these two pieces are connected, the circles are merged together.

The markdown schema for the MatchPair quiz is as follows:

```html
<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the Java Concepts",
  "Pairs": [
    {
      "Prompt": "int",
      "Answer": "A 32-bit signed integer"
    },
    {
      "Prompt": "boolean",
      "Answer": "Represents true or false"
    },
    {
      "Prompt": "char",
      "Answer": "A single 16-bit Unicode character"
    }
  ]
}
</Quiz>
```
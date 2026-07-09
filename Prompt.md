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

The location for this new component should be in Pages/QuizComponents/TrueFalseQuiz/... 

Update the switch statement in the Article page to handle this new type as well. 

Also update the switch statement in @MdToHtmlConversion/Transformers/ConvertMarkdownToHtml.cs to handle the new type of quiz.

## New type
I need a new type of quiz, TrueFalseQuiz. 

* The data is a collection of statements, each statement can be true or false..
* The quiz layout is three columns, statements on the left, as a larger column, and then true and false on the right, as smaller columns.
* The user must select the correct answer for each statement.
* When all statements are answered, the user can submit the quiz to get a result.
* The result is displayed, and the user can see which statements they got correct and which they got incorrect.

The markdown schema for the TrueFalseQuiz quiz is as follows:

```html
<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [    {
      "Text": "boolean represents true or false",
      "IsCorrect": true    
    },
    {
      "Text": "char is a single 16-bit Unicode character",
      "IsCorrect": false    
    }
  ]
}
</Quiz>
```
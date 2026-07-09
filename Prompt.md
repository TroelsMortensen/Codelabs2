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

The location for this new component should be in Pages/QuizComponents/ParsonsProblem/... 

Update the switch statement in the Article page to handle this new type as well. 

Also update the switch statement in @MdToHtmlConversion/Transformers/ConvertMarkdownToHtml.cs to handle the new type of quiz.

## New type
I need a new type of quiz, ParsonsProblem. 


* The Parsons Problem displays a jumbled list of content. The purpose is for the reader to rearrange the content into the correct order. This can be used for example to learn about the order of steps in a process. Or, I can provide the lines of a jumbled code snippet, and the reader must rearrange the lines to form a valid code snippet.
* The quiz layout consists of two areas, the question above, and the lines below. The user must be able to drag and drop the lines to the correct order.
* The user must rearrange all fragments in the "Solution" area to match the intended logic.
* The intended order is specified in the by the ordering of the Id property.
* Once the user is satisfied with the order, they can submit the quiz to verify if their sequence matches the predefined correct solution.
* The result displays which lines are in the correct position.

The markdown schema for the ParsonsProblem quiz is as follows:

```html
<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to create a valid Java method that returns the sum of two integers.",
  "Lines": [
    { "Id": 1, "Content": "public int sum(int a, int b) {" },
    { "Id": 2, "Content": "    int result = a + b;" },
    { "Id": 3, "Content": "    return result;" },
    { "Id": 4, "Content": "}" }
  ]
}
</Quiz>
```
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

The location for this new component should be in Pages/QuizComponents/StepGuide/... 

Update the switch statement in the Article page to handle this new type as well. 

Also update the switch statement in @MdToHtmlConversion/Transformers/ConvertMarkdownToHtml.cs to handle the new type of quiz.

## New type
The next type of quiz is more elaborate. It is less of a quiz, more of a collection of information.

I call this type of quiz "StepGuide".

The data is a list of Header and Content pairs.

The UI is showing:
* A box with the header text in bold, slightly larger, left aligned on the top. The content is below.
* Above this box, there is a title text, centered on the top. This is the title of the "quiz" block.
* At the top of the box, there is a blue rounded rectangle with the text "Step 1". This text will change as the reader progresses through the "quiz" block.
* There is a previous arrow to the left of the box. When the user clicks this arrow, the previous step is shown. It is disabled when the reader is on the first step.
* There is a next arrow to the right of the box. When the user clicks this arrow, the next step is shown. It is disabled when the reader is on the last step.
* The first step is shown by default. For this step only, the Header is centered on the top. This works as an introduction to the "quiz" block.
* The last step also has the Header centered on the top. This works as a conclusion to the "quiz" block.
* Below the quiz block, there are numbers to show how many steps are in the "quiz" block. The current step is highlighted in blue.
* The first step is a right pointing chevron, matching index 0 in the list of content. This is the introduction to the "quiz" block.
* The last step is a check mark to indicate the reader has completed the "quiz" block.
* First and last steps are not different from the other steps in terms of data. It is only their position in the list that indicates whether they are "Introduction", "Step X", or "Conclusion".
* The data is a list of objects, each object has a header and a content. Something like this:
```json
<Quiz>
{
    "Type": "StepGuide",
    "Title": "World Capitals",
    "Details": [
        {
            "Header": "This is the introduction to the quiz block.",
            "Content": "This guide will introduce the reader to different capital cities of the world."
        },
        {
            "Header": "Berlin",
            "Content": "Berlin is the capital of Germany."
        },
        {
            "Header": "Paris",
            "Content": "Paris is the capital of France."
        },
        {
            "Header": "London",
            "Content": "London is the capital of England."
        },
        {
            "Header": "Conclusion",
            "Content": "This guide has introduced the reader to different capital cities of the world."
        }
    ]
}
</Quiz>
```
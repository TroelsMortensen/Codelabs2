I have a learning path app, each learning path consisting of a couple of steps. I may want to include various types of quizzes along the way to help the reader learn. I currently have a SingleChoiceQuiz, see @UI/Pages/QuizComponents/SingleChoiceQuiz.razor , and see the @Skills/QuizStructure.md for more information. 
You may also see @Articles/Stuff/Feature Tester/007 Single choice quiz.md for an example usage.

See also @Articles/Stuff/Feature Tester/008 Flash card set.md  for an example of usage. Keep the styling similar to the Single Choice Quiz and the Flash Card Set.

The location for this new component should be in Pages/QuizComponents/MultipleChoiceQuiz. Update the switch statement in the Article page to handle this new type as well. Also update the switch statement in @MdToHtmlConversion/Transformers/ConvertMarkdownToHtml.cs to handle the new type of quiz.

Now I need a new type, a MultipleChoiceQuiz. This one is similar to the Single Choice Quiz, but this time we allow multiple correct answers. These are rendered in the @UI/Pages/ArticleComponents/Article.razor page, through the list of PageSegments.

The json data structure could be very similar to the Single Choice Quiz, just allowing for multiple correct answers.

Create new record types to match, in the MdToHtmlConversion/Models/QuizzModels.cs file.

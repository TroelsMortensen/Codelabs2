using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    // [Inject] public HttpClient Client { get; set; }
    [Inject] public NavigationManager NavMgr { get; set; }
    // [Inject] public ArticlesState ArticlesState { get; set; }


    // private List<ArticleHeader>? articles;

    // protected override async Task OnInitializedAsync()
    // {
    //     articles = await ArticlesState.GetArticleHeaders();
    // }

    private void NavigateToArticle(string owner, string tutorialName) =>
        NavMgr.NavigateTo($"article/{owner}/{tutorialName}");

    private CourseOverview OverviewData { get; } =
        new CourseOverview(
            [
                new Course("PRO1", "#7FFFD4",
                    [
                        new Session(1, "Basic Java",
                            [
                                new LearningPath("Introduction", "Session%201%20Learning%20Path")
                            ]
                        ),
                        new Session(2, "Input",
                            [
                                new LearningPath("Default Values", "Session%202%20Default%20Values"),
                                new LearningPath("String methods", "Session%202%20String%20methods"),
                                new LearningPath("Console input", "Session%202%20Console%20Input"),
                                new LearningPath("Extra exercises", "Session%202%20-%20live"),
                            ]
                        )
                    ]
                ),
                new Course("UML", "#FF7F50",
                    [
                        new Session(1, "Class Diagram",
                            [
                                new LearningPath("Documentation", "UML%20Class%20Diagrams")
                            ]
                        ),
                        new Session(2, "Domain Model",
                            [
                                new LearningPath("Documentation", "UML%20Domain%20Model")
                            ]
                        )
                    ]
                )
            ]
        );
}

record CourseOverview(IEnumerable<Course> Courses);

record Course(string Title, string Color, IEnumerable<Session> Sessions);

record Session(int SessionNumber, String Title, IEnumerable<LearningPath> LearningPaths);

record LearningPath(String Title, String Url);
using System.Web;
using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    [Inject] public NavigationManager NavMgr { get; set; } = null!;

    private void NavigateToArticle(string owner, string tutorialName) =>
        NavMgr.NavigateTo($"article/{owner}/{HttpUtility.UrlEncode(tutorialName)}");

    // Todo yes yes i know put this somewhere else. In a separate json file somewhere, probably. That can be auto-generated perhaps?
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
                                new LearningPath("The Java Compiler", "The%20Java%20Compiler"),
                                new LearningPath("IntelliJ shortcuts", "IntelliJ%20Shortcuts%201"),
                                new LearningPath("Extra exercises", "Session%202%20-%20live"),
                            ]
                        ),
                        new Session(3, "If-statement",
                            [
                                new LearningPath("Boolean logic recap", "Session%203%20Boolean%20logic"),
                                new LearningPath("The if-statement", "Session%203%20If%20statement"),
                                new LearningPath("Extra exercises", "Session%203%20-%20live"),
                            ]
                        ),
                        new Session(4, "Switch-statement",
                            [
                                new("Enums", "Session%204%20Enums"),
                                new("The switch statement", "Session%204%20Switch%20statement")
                            ]
                        ),
                        new Session(5, "Loops",
                            [
                                new("Increment and decrement", "Session%205%20Inc%20and%20Dec"),
                                new("For-loop", "Session%205%20For%20loop"),
                                new("While-loop", "Session%205%20While%20loop"),
                            ]
                        ),
                        new Session(6, "Arrays",
                            [
                                new("Arrays", "Session%206%20Arrays")
                            ]
                        ),
                        new Session(7, "Lists",
                            [
                                new("ArrayList", "Session%207%20List")
                            ]
                        ),
                        new Session(8, "Introducing Objects",
                            [
                                new("Objects", "Session%208%20Objects"),
                                new("UML", "Session%208%20UML")
                            ]
                        ),
                        new Session(9, "More about Objects",
                            [
                                new("Inheriting from Object", "Session%209%20Inherit%20from%20Object"),
                                new("Final keyword", "Session%209%20Final%20fields"),
                                new("Static keyword", "Session%209%20Static"),
                                new("Overloading methods", "Session%209%20Method%20overloading"),
                                new("Extra exercises", "Session%209%20-%20Extra%20exercises")
                            ]
                        ),
                        new Session(10, "Object exercises",
                            [
                                new("Garbage collection in Java", "Session%2010%20-%20Garbage%20collection"),
                                new("Extra exercises", "Session%2010%20-%20Exercises")
                            ]
                        ),
                        new Session(11, "Relationships part 1",
                            [
                                new("Relations between objects", "Session%2011%20-%20Relationships%20intro")
                            ]
                        ),
                        new Session(12, "Relationships part 2",
                            [
                                new("One to many relationships", "Session%2012%20-%20One%20to%20Many")
                            ]
                        ),
                        new Session(13, "Inheritance part 1",
                            [
                                new("Introducing Inheritance", "Session%2013%20-%20Inheritance")
                            ]
                        ),
                        new Session(14, "Abstract classes",
                            [
                                new("Abstract keyword", "Session%2014%20-%20Abstract")
                            ]
                        ),
                        new Session(15, "Interfaces",
                            [
                                new("Packages", "Session%2015%20-%20Packages"),
                                new("Interfaces", "Session%2015%20-%20Interfaces")
                            ]
                        ),
                        new Session(16, "Exercises",
                            [
                                new("Extra exercises", "Session%2016%20-%20Test")
                            ]
                        ),
                        new Session(17, "Exceptions",
                            [
                                new("Exceptions", "Session%2017%20-%20Exceptions")
                            ]
                        ),
                        new Session(18, "Robocode",
                            [
                                new("Robocode documentation", "Robocode")
                            ]
                        ),
                        new Session(19, "Introducing files",
                            [
                                new("File I/O", "Session%2019%20-%20File%20IO"),
                            ]
                        ),
                        new Session(20, "Application design",
                            [
                                new("Application design", "Session%2020%20-%20Application%20design")
                            ]
                        )
                    ]
                ),
                new Course("UML", "#FF7F50",
                    [
                        new Session(1, "Class Diagram",
                            [
                                new LearningPath("Documentation", "UML%2FClass%20Diagrams")
                            ]
                        ),
                        new Session(2, "Domain Model",
                            [
                                new LearningPath("Documentation", "UML%2FDomain%20Model")
                            ]
                        ),
                        new Session(2, "Domain Model",
                            [
                                new LearningPath("Documentation", "UML%2FUse%20Case%20Diagrams")
                            ]
                        ),
                        new Session(2, "Domain Model",
                            [
                                new LearningPath("Documentation", "UML%2FUse%20Case%20Descriptions")
                            ]
                        )
                    ]
                ),
                new Course("SEP", "#03BAFC",
                    [
                        new Session(1, "SEP1",
                            [
                                new LearningPath("Actors", "SEP1%2FActors"),
                                new LearningPath("Requirements", "SEP1%2FRequirements"),
                                new LearningPath("Use case explanation", "SEP1%2Use%20cases"),
                                new LearningPath("Use case diagrams", "SEP1%2FUse%20case%20diagrams"),
                                new LearningPath("Use case descriptions", "SEP1%2FUse%20case%20descriptions")
                            ]
                        ),
                        // new Session(2, "SEP2",
                        //     [
                        //     ])
                        
                    ]
                )
            ]
        );
}

internal record CourseOverview(IEnumerable<Course> Courses);

internal record Course(string Title, string Color, IEnumerable<Session> Sessions);

internal record Session(int SessionNumber, string Title, IEnumerable<LearningPath> LearningPaths);

internal record LearningPath(string? Title, string Url);
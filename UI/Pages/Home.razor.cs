using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    // Todo yes yes i know put this somewhere else. In a separate json file somewhere, probably. That can be auto-generated perhaps?
    
    private CourseOverview OverviewData { get; } =
        new CourseOverview(
            [
                new Course("PRO1", "#7FFFD4",
                    [
                        new Session(1, "Basic Java",
                            [
                                new LearningPath("Introduction", "Session 1 Learning Path"),
                                new LearningPath("Default Values", "Session 2 Default Values"),
                            ]
                        ),
                        new Session(2, "Input",
                            [
                                new LearningPath("String methods", "Session 2 String methods"),
                                new LearningPath("Console input", "Session 2 Console Input"),
                                new LearningPath("The Java Compiler", "The Java Compiler"),
                                new LearningPath("IntelliJ shortcuts", "IntelliJ Shortcuts 1"),
                                new LearningPath("Extra exercises", "Session 2 - live"),
                            ]
                        ),
                        new Session(3, "If-statement",
                            [
                                new LearningPath("Boolean logic recap", "Session 3 Boolean logic"),
                                new LearningPath("The if-statement", "Session 3 If statement"),
                                new LearningPath("Extra exercises", "Session 3 - live"),
                            ]
                        ),
                        new Session(4, "Switch-statement",
                            [
                                new("Enums", "Session 4 Enums"),
                                new("The switch statement", "Session 4 Switch statement")
                            ]
                        ),
                        new Session(5, "Loops",
                            [
                                new("Increment and decrement", "Session 5 Inc and Dec"),
                                new("For-loop", "Session 5 For loop"),
                                new("While-loop", "Session 5 While loop"),
                            ]
                        ),
                        new Session(6, "Arrays",
                            [
                                new("Arrays", "Session 6 Arrays")
                            ]
                        ),
                        new Session(7, "Lists",
                            [
                                new("ArrayList", "Session 7 List")
                            ]
                        ),
                        new Session(8, "Introducing Objects",
                            [
                                new("Objects", "Session 8 Objects"),
                                new("UML", "Session 8 UML"), 
                                new("Encapsulation", "Session 8 Encapsulation"), 
                                new("Shadowing", "Session 8 Shadowing"), 
                            ]
                        ),
                        new Session(9, "More about Objects",
                            [
                                new("Inheriting from Object", "Session 9 Inherit from Object"),
                                new("Final keyword", "Session 9 Final fields"),
                                new("Static keyword", "Session 9 Static"),
                                new("Overloading methods", "Session 9 Method overloading"),
                                new("Extra exercises", "Session 9 - Extra exercises")
                            ]
                        ),
                        new Session(10, "Object exercises",
                            [
                                new("Garbage collection in Java", "Session 10 - Garbage collection"),
                                new("Extra exercises", "Session 10 - Exercises")
                            ]
                        ),
                        new Session(11, "Relationships part 1",
                            [
                                new("Relations between objects", "Session 11 - Relationships intro")
                            ]
                        ),
                        new Session(12, "Relationships part 2",
                            [
                                new("One to many relationships", "Session 12 - One to Many")
                            ]
                        ),
                        new Session(13, "Inheritance part 1",
                            [
                                new("Introducing Inheritance", "Session 13 - Inheritance")
                            ]
                        ),
                        new Session(14, "Abstract classes",
                            [
                                new("Abstract keyword", "Session 14 - Abstract"),
                                new("Polymorphism", "Session 14 - Polymorphism")
                            ]
                        ),
                        new Session(15, "Interfaces",
                            [
                                new("Packages", "Session 15 - Packages"),
                                new("Interfaces", "Session 15 - Interfaces")
                            ]
                        ),
                        new Session(16, "Exercises",
                            [
                                new("Extra exercises", "Session 16 - Test")
                            ]
                        ),
                        new Session(17, "Exceptions",
                            [
                                new("Exceptions", "Session 17 - Exceptions")
                            ]
                        ),
                        new Session(18, "Robocode",
                            [
                                new("Robocode documentation", "Robocode")
                            ]
                        ),
                        new Session(19, "Introducing files",
                            [
                                new("File I/O", "Session 19 - File IO"),
                            ]
                        ),
                        new Session(20, "Application design",
                            [
                                new("Java documentation", "Java Doc"),
                                new("Automated testing", "Automated testing"),
                                new("Application design", "Session 20 - Application design")
                            ]
                        ),
                        new Session(21, "JavaFX introduction",
                            [
                                new("Lambdas and method references", "Lambda expressions"),
                                new("Java FX introduction", "Session 21 - JFX intro")
                            ]
                        ),
                        new Session(22, "JavaFX - multiple views",
                            [
                                new("JavaFX - Multiple views", "Session 22 - JFX Continued")
                            ]
                        ),
                        new Session(23, "JavaFX - Application",
                            [
                                new("JavaFX - application design", "Session 23 - JFX Application")
                            ]
                        ),
                        new Session(24, "Exam",
                            [
                                new("Exam practice exercises", "Session 24 - Exam")
                            ]
                        )
                    ]
                ),
                new Course("Astah and UML", "#FF7F50",
                    [
                        new Session(1, "Analysis artefacts",
                            [
                                new LearningPath("Activity diagrams", "UML/Analysis artefacts/Activity diagrams"),
                                new LearningPath("Domain model", "UML/Analysis artefacts/Domain Model"),
                                new LearningPath("Use case diagrams", "UML/Analysis artefacts/Use Case Diagrams"),
                                new LearningPath("Use case descriptions", "UML/Analysis artefacts/Use case descriptions"),
                            ]
                        ),
                        new Session(2, "Design artefacts",
                            [
                                new LearningPath("Class diagrams", "UML/Design artefacts/Class Diagrams"),
                                new LearningPath("Sequence diagrams", "UML/Design artefacts/Sequence diagrams"),
                                new LearningPath("State machine diagrams", "UML/Design artefacts/State machines")
                            ]
                        ),
                        new Session(3, "Reports and diagrams",
                            [
                                new("Export diagram", "UML/Export to svg")
                            ]
                        ),
                    ]
                ),
                new Course("SEP1", "#03BAFC",
                    [
                        new Session(1, "Analysis",
                            [
                                new LearningPath("Actors", "SEP1/Actors"),
                                new LearningPath("Requirements", "SEP1/Requirements"),
                                new LearningPath("What is a use case", "SEP1/Use cases"),
                                new LearningPath("Use case diagrams", "SEP1/Use case diagrams"),
                                new LearningPath("Use case descriptions", "SEP1/Use case descriptions"),
                                new LearningPath("Activity diagrams", "SEP1/Activity diagrams"),
                                new LearningPath("Domain models", "SEP1/Domain models"),
                            ]
                        ),
                        new Session(2, "Design",
                            [
                                new LearningPath("Class diagrams", "SEP1/Class diagrams"),
                                new LearningPath("Sequence diagrams", "SEP1/Sequence diagrams"),
                            ]
                        )
                    ]
                ),
                new Course("SDT", "#FFA756",
                    [
                        new Session(1, "Assignments",
                            [
                                new LearningPath("Assignment 1", "SDT/Assignments/Assignment1"),
                                new LearningPath("Assignment 2", "SDT/Assignments/Assignment2"),
                                new LearningPath("Assignment 3", "SDT/Assignments/Assignment3"),
                                new LearningPath("Assignment 4", "SDT/Assignments/Assignment4")
                            ]
                        ),
                        new Session(2, "Learning paths",
                            [
                                new LearningPath("Keys in the domain model", "SDT/Keys in domains"),
                                new LearningPath("Data Transfer Objects", "SDT/DTOs"),
                                new LearningPath("Records", "SDT/Records"),
                                new LearningPath("Transactions", "SDT/Transactions"),
                                new LearningPath("State Machines", "SDT/Statemachines"),
                                new LearningPath("Data Binding", "SDT/Data Bindings"),
                            ]
                        ),
                        new Session(3, "Design Principles",
                            [
                                new LearningPath("What are Design Principles", "SDT/Design Principles/What are design principles"),
                                new LearningPath("SOLID principles", "SDT/Design Principles/SOLID"),
                                new LearningPath("Mountains and Islands", "SDT/Design Principles/Mountains and Islands"),
                                new LearningPath("The Orchestrator Principle", "SDT/Design Principles/The Orchestrator Principle"),
                                new LearningPath("The Broken Window", "SDT/Design Principles/The Broken Window"),
                                new LearningPath("Coupling and Cohesion", "SDT/Design Principles/Coupling and Cohesion"),
                                new LearningPath("Dependency Injection", "SDT/Design Principles/Dependency Injection"),
                                new LearningPath("Law of Demeter", "SDT/Design Principles/Law of Demeter"),
                                new LearningPath("What is Refactoring", "SDT/Design Principles/What is Refactoring"),
                            ]
                        ),
                        new Session(4, "Design Patterns",
                            [
                                new LearningPath("Design Patterns", "SDT/Design Patterns/What are Design Patterns"),
                                new LearningPath("Option Pattern", "SDT/Design Patterns/Option Pattern"),
                                new LearningPath("Observer Pattern", "SDT/Design Patterns/Observer Design Pattern"),
                            ]
                        )
                    ]
                )
            ]
        );

    [Inject] public NavigationManager NavMgr { get; set; } = null!;
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    // State management for collapsible courses and sessions
    private Dictionary<string, bool> CourseExpandedState { get; set; } = new();
    private Dictionary<string, bool> SessionExpandedState { get; set; } = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
        await Task.Delay(100); // Wait for DOM to be ready
        await JsRuntime.InvokeVoidAsync("initializeMasonry", "CoursesBoxLayout");
        }
    }

    private string GetCourseKey(Course course) => course.Title;
    private string GetSessionKey(Course course, Session session) => $"{course.Title}_{session.SessionNumber}";

    private bool IsCourseExpanded(Course course)
    {
        var key = GetCourseKey(course);
        return CourseExpandedState.TryGetValue(key, out var expanded) && expanded;
    }

    private bool IsSessionExpanded(Course course, Session session)
    {
        var key = GetSessionKey(course, session);
        return SessionExpandedState.TryGetValue(key, out var expanded) && expanded;
    }

    private async Task ToggleCourse(Course course)
    {
        var key = GetCourseKey(course);
        CourseExpandedState[key] = !IsCourseExpanded(course);
        StateHasChanged();
        await Task.Delay(50); // Wait for DOM update
        await JsRuntime.InvokeVoidAsync("masonryLayout", "CoursesBoxLayout");
    }

    private async Task ExpandAll(Course course)
    {
        var courseKey = GetCourseKey(course);
        bool shouldExpand = !IsCourseExpanded(course);
        
        CourseExpandedState[courseKey] = shouldExpand;
        
        // Expand/collapse all sessions in this course
        foreach (var session in course.Sessions)
        {
            var sessionKey = GetSessionKey(course, session);
            SessionExpandedState[sessionKey] = shouldExpand;
        }
        
        StateHasChanged();
        await Task.Delay(50); // Wait for DOM update
        await JsRuntime.InvokeVoidAsync("masonryLayout", "CoursesBoxLayout");
    }

    private async Task ToggleSession(Course course, Session session)
    {
        var key = GetSessionKey(course, session);
        SessionExpandedState[key] = !IsSessionExpanded(course, session);
        StateHasChanged();
        await Task.Delay(50); // Wait for DOM update
        await JsRuntime.InvokeVoidAsync("masonryLayout", "CoursesBoxLayout");
    }

    private async Task ToggleStuff()
    {
        CourseExpandedState["Stuff"] = !CourseExpandedState.GetValueOrDefault("Stuff", false);
        StateHasChanged();
        await Task.Delay(50); // Wait for DOM update
        await JsRuntime.InvokeVoidAsync("masonryLayout", "CoursesBoxLayout");
    }

    private void NavigateToArticle(string owner, string tutorialName) =>
        NavMgr.NavigateTo($"article/{owner}/{Uri.EscapeDataString(tutorialName)}");

    private void NavigateToWheel() =>
        NavMgr.NavigateTo("wheeloffortune");

}

internal record CourseOverview(IEnumerable<Course> Courses);

internal record Course(string Title, string Color, IEnumerable<Session> Sessions);

internal record Session(int SessionNumber, string Title, IEnumerable<LearningPath> LearningPaths);

internal record LearningPath(string? Title, string Url);
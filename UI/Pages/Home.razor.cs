﻿using System.Web;
using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    [Inject] public NavigationManager NavMgr { get; set; } = null!;

    private void NavigateToArticle(string owner, string tutorialName) =>
        NavMgr.NavigateTo($"article/{owner}/{Uri.EscapeDataString(tutorialName)}");

    private CourseOverview OverviewData { get; } =
        new CourseOverview(
            [
                new Course("PRO1", "#7FFFD4",
                    [
                        new Session(1, "Basic Java",
                            [
                                new LearningPath("Introduction", "Session 1 Learning Path")
                            ]
                        ),
                        new Session(2, "Input",
                            [
                                new LearningPath("Default Values", "Session 2 Default Values"),
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
                                new("UML", "Session 8 UML")
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
                                new("Abstract keyword", "Session 14 - Abstract")
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
                                new("Application design", "Session 20 - Application design")
                            ]
                        )
                    ]
                ),
                new Course("UML", "#FF7F50",
                    [
                        new Session(1, "Analysis artefacts",
                            [
                                new LearningPath("Domain model", "UML/Analysis artefacts/Domain Model"),
                                new LearningPath("Use case diagrams", "UML/Analysis artefacts/Use Case Diagrams"),
                                new LearningPath("Use case descriptions", "UML/Analysis artefacts/Use case descriptions"),
                            ]
                        ),
                        new Session(2, "Design artefacts",
                            [
                                new LearningPath("Class diagram", "UML/Design artefacts/Class Diagrams")
                            ]
                        ), 
                    ]
                ),
                new Course("SEP", "#03BAFC",
                    [
                        new Session(1, "SEP1",
                            [
                                new LearningPath("Actors", "SEP1/Actors"),
                                new LearningPath("Requirements", "SEP1/Requirements"),
                                new LearningPath("What is a use case", "SEP1/Use cases"),
                                new LearningPath("Use case diagrams", "SEP1/Use case diagrams"),
                                new LearningPath("Use case descriptions", "SEP1/Use case descriptions")
                            ]
                        ),
                        // new Session(2, "SEP2",
                        //     [
                        //     ])
                    ]
                )
            ]
        );
    // Todo yes yes i know put this somewhere else. In a separate json file somewhere, probably. That can be auto-generated perhaps?
}

internal record CourseOverview(IEnumerable<Course> Courses);

internal record Course(string Title, string Color, IEnumerable<Session> Sessions);

internal record Session(int SessionNumber, string Title, IEnumerable<LearningPath> LearningPaths);

internal record LearningPath(string? Title, string Url);
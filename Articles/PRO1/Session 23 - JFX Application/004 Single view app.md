# Single view application

"Single page application" is a term you may have heard of. It means an application with a single main view, or a single page. Many modern websites are single page applications, unlike what you learn in the WEB1 course. 

In WEB1 you are creating multiple html files, each with a header, a footer, and a main content area, or something like that. Each page is a separate html file.\
This is also how we have been doing so far with JavaFX. Just swapping out one view for another.

In a single page application, you create a single html file, with a header, a footer, and a main content area. The main content area is the view, and it is updated dynamically, without reloading the page. The main content is basically swapped out, as the user navigates through the application, but the header and footer remain the same.

## Holy Grail Layout

I will show a similar approach, using JavaFX. I will use a BorderPane layout, with a menu bar on the left, and a content area on the right. The menu bar will have a button for each view, and the content area will show the view.

Here is a reminder of the BorderPane layout:

```
┌────────────────────────────────────────────┐
│                   TOP                      │
│              (Menu Bar, Title)             │
├──────────┬─────────────────────┬───────────┤
│          │                     │           │
│   LEFT   │       CENTER        │   RIGHT   │
│          │                     │           │
│ (Nav/    │   (Main Content)    │ (Side     │
│  Menu)   │                     │  Panel)   │
│          │                     │           │
│          │                     │           │
│          │                     │           │
├──────────┴─────────────────────┴───────────┤
│                  BOTTOM                    │
│            (Status Bar, Footer)            │
└────────────────────────────────────────────┘
```

The `Left` area is the menu bar, the `Center` area is the main content area. If `TOP` and `BOTTOM` are not used, the `CENTER` area will take up the entire screen.\
You can of course also place the menu bar on the top or right side. 

If you use the top part, you should probably use the menu items from JavaFX. When you open the Scene Builder, it shows an example template, pick the Basic Application template.

![menu template](Resources/SceneBuilder.png)

Here is the top menu bar:

![top menu bar](Resources/TopMenu.png)


## Single view application

We will still use the `ViewManager`, as you have seen previously, but instead of swapping out the root on the scene, we will set the view to the center of the BorderPane.

Watch the below video to see how this is done.

<video src="https://youtu.be/8eIY_xsRm2A"></video>

What I have shown in the video is directly applicable to your semester project.\
Even though I keep the data in a list, it should be easy enough to adapt it to write to a binary file, as you have seen in the previous sessions.

[Here is the code from the video](https://github.com/TroelsMortensen/JavaFxExamples/tree/master/15_SingleViewApplication)

## OkayReads Class Diagram Example

Below is a complete class diagram for the OkayReads book management application, demonstrating the layered architecture with BorderPane layout:

![cd](Resources/OkayReadsClassDiagram.svg)

You should be able to right click on the diagram, and open it in a new tab, to see the details.\
I have chosen various colors for various elements, with the intention of making it easier to read.\
Not all arrows are shown, for brevity.

This particular setup can be replicated in your semester project.

You can of course choose another layout, still with the BorderPane, or with a completely different approach. The same theory applies, where you have a single main view, and swap out the content area, as the user navigates through the application.
# The scene graph

So, fxml is a xml or html like file that describes your UI. And you may have heard that this kind of approach is a tree-structure. Similar to the DOM of html in the browser.

Consider the below _beautiful_ UI design:

![beautiful ui design](Resources/ExampleUI.png)

We have several things going on here, layouts using multiple panes, there are buttons, labels, text fields, etc. Bunch of stuff. This can be visualized in various ways.

## Standard tree
The above can be represented as a tree structure like this:

```mermaid
graph TB
    BP[BorderPane]
    
    BP --> Pane
    BP --> VBox
    BP --> GP[GridPane 2x5]
    
    Pane --> Text
    
    VBox --> B1[Button]
    VBox --> B2[Button]
    VBox --> B3[Button]
    VBox --> B4[Button]
    VBox --> B5[Button]
    
    GP --> L1["Label (0, 0)"]
    GP --> TF1["TextField (1, 0)"]
    GP --> TF2["TextField (1, 1)"]
    GP --> TF3["TextField (1, 2)"]
    GP --> L2["Label (0, 1)"]
    GP --> L3["Label (0, 2)"]
    
    style BP fill:#e8f4f8,stroke:#333,stroke-width:2px,color:#000
    style Pane fill:#fff9e6,stroke:#333,stroke-width:2px,color:#000
    style VBox fill:#fff9e6,stroke:#333,stroke-width:2px,color:#000
    style GP fill:#fff9e6,stroke:#333,stroke-width:2px,color:#000
```

## SceneBuilder tree
First, this was made in the scene builder. The following image is how the UI is represented, as a vertical tree structure:

![scene builder tree](Resources/VerticalTree.png)

Pay attention to the order of the elements, and their indentation. The `BorderPane` contains a `Pane`, a `VBox`, and a `GridPane`. Each of these contains various elements.
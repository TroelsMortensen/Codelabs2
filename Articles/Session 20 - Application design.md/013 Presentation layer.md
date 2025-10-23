# Presentation layer

As previously mentioned, this layer is responsible for presenting the data to the user, and accepting input from the user.

Sometimes the same underlying data is presented in different ways, for example a list of planets, can be presented as a table or a list, or probably something else, like fancy graphics actually showing solar systems in the galaxy. But each way is a different presentation of the same underlying data. That is why we keep the _presentation_ of the data **separate** from the data itself.

Next semester, we will actually add a layer in between the presentation layer and the persistence layer, called the "service layer", or "business logic layer". This layer will contain the logic of the application. But for now, we will keep it simple, and muddy the waters a bit, mixing responsibilities. This is quite okay on your first semester, as you are still learning.

We still want to practice some design concepts, mainly **separation of concerns**. This is a wonderful principle, and in short it means we should keep the responsibilities of the classes separate. A class should not do "too many things".
We can then discuss and argue and fight about how much we want separate responsibilities, but I have a recommendation for now, which we will follow. Because I say so, and it is a good starting point for your learning journey.

Eventually, you will end up with a menu structure like this:

```
Main Menu
    - Manage Planets
        - Add Planet
        - Update Planet
        - Delete Planet
        - View Planet
        - List Planets
        - Back to Main Menu
    - Manage Explorers
        - Add Explorer
        - Update Explorer
        - Move Explorer
        - Delete Explorer
        - View Explorer
        - List Explorers
        - Back to Main Menu
    - Manage Aliens
        - Add Alien
        - Update Alien
        - View Alien
        - List Aliens
        - Delete Alien
        - Back to Main Menu
    - Manage Encounters
        - Add Encounter
        - Update Encounter
        - Delete Encounter
        - View Encounter
        - List Encounters
        - Back to Main Menu
    - Exit
```

Now, would you look at that. We have a main menu. Then we have sub-menus for _each entity type_. And for each entity type, we have a list of actions we can perform on it. And do they seem familiar, these actions? Yeah, they look like CRUD operations. Mostly. Many applications follow such a CRUD approach. 
# The FLUID anti principles

These are the anti principles of the SOLID principles, i.e. things we should avoid.

Here is the **FLUID** methodology. Each letter is the direct antagonist to the corresponding **SOLID** letter.

I include these because I commonly see them, even with arguments in favor of the FLUID principles.

## The Core Theme

**Short-Term Speed** vs. **Long-Term Survival**

FLUID is faster for the first hour; SOLID is faster for the next year.

### **F** — Fused Responsibilities
*(The opposite of **S**ingle Responsibility)*

**The Principle:** *Don't separate concerns; melt them together.*
Why have a `User`, a `UserDAO`, and a `UserValidator` when you can just have one massive `User` class? If logic is spread out, you have to look in multiple files. Fuse it all into one giant block of code. If a class has fewer than 2,000 lines, it isn't trying hard enough.

*   **The Anti-Pattern:** The "God Object" or "Frankenstein Class."
*   **The "Fluid" visual:** Logic flows and mixes together like molten metal; there are no boundaries.

#### The Student Argument

*"Why should I split this into 5 files? It's so much easier to find what I'm looking for if everything is in one big `GameController.java` file. I can just Ctrl+F!"*

#### The Counter-Argument

1. **The "Sock Drawer" Reality:** If you throw your socks, silverware, car keys, and hammer into one giant box, it is indeed "all in one place." But finding the *specific* thing you need becomes a nightmare.

2. **Merge Conflict Hell:** In a team project, if everyone is working on the same "God Class," you will have merge conflicts every single time you push code. Splitting classes means Student A works on `Movement` and Student B works on `Inventory` without stepping on each other's toes.

3. **Cognitive Load:** When a class has 2,000 lines, you have to keep the entire state of the "machine" in your head to change one line safely. Small classes let you focus on one gear at a time.

#### The Metaphor

> A Swiss Army Knife is great for camping. But if you need to build a house, you don't want a tool where the hammer is fused to the saw, which is fused to the screwdriver. You want a toolbox of separate, specialized tools.

### **L** — Limitless Modification
*(The opposite of **O**pen/Closed)*

**The Principle:** *Never extend; always rewrite.*
The Open/Closed principle says you should be able to change behavior without touching the source code (via plugins or inheritance). **Limitless Modification** says: just open the file and change the `if` statements. If a requirement changes, delete the old code and write new code in its place. Version control exists for a reason, right?

*   **The Anti-Pattern:** "Shotgun Surgery" (modifying the same core methods over and over again for every new feature).

#### The Student Argument

*"Why create an interface and a new class just to add a new monster type? I can just go into the `monsterAttack()` method and add an `else if (type == 'Zombie')`. It takes 30 seconds!"*

#### The Counter-Argument

1. **Risk of Regression:** Every time you open a working, tested file to "tweak" it, you risk breaking what was already working. You are performing surgery on a healthy patient just to put a hat on them.

2. **The "Else-If" Tower of Terror:** Today it's one `else if`. In two months, it's a nested nightmare of 50 conditions. This makes the logic impossible to read and impossible to test exhaustively.

3. **Plugin Architecture:** If you use OCP, you can add features (new classes) without even recompiling the old code. This is how mods work in video games.

#### The Metaphor

> When you buy a new video game console, you plug it into the TV's HDMI port. You don't unscrew the back of the TV and solder new wires directly onto the motherboard. The TV is "Closed" for modification (soldering) but "Open" for extension (new HDMI devices).

### **U** — Unreliable Subtypes
*(The opposite of **L**iskov Substitution)*

**The Principle:** *Keep them guessing.*
A subclass should not be a perfect substitute for the parent. It should have "personality." If the parent class has a method `save()`, the subclass `ReadOnlyFile` should implement `save()` by throwing a `RuntimeException`. This ensures that anyone using your code has to write `if (obj instanceof ReadOnlyFile)` everywhere to prevent crashes.

*   **The Anti-Pattern:** Refused Bequest (inheriting methods just to break them).

#### The Student Argument

*"It's fine if my `Penguin` class throws an error when `fly()` is called. Everyone knows penguins don't fly. I'll just check `if (bird instanceof Penguin)` before I call it."*

#### The Counter-Argument

1. **The "Hidden Minefield":** You might know the Penguin crashes, but the library you imported that takes a generic `List<Bird>` doesn't know that. It will iterate, call `fly()`, and crash your application.

2. **Polymorphism is Destroyed:** The whole point of inheritance is treating different objects the same way. If you have to check "What represent exactly are you?" before using an object, you aren't doing OOP; you're just writing procedural `if/else` statements wrapped in classes.

3. **Trust:** When you break LSP, your code becomes a liar. The return type says `int`, but it returns `null`. The method says `save()`, but it deletes.

#### The Metaphor

> Imagine a standard electrical outlet. If you plug in a lamp, it lights up. If you plug in a toaster, it heats up. If you plug in a specific brand of vacuum and the house explodes, that outlet violated the Liskov Principle. You shouldn't need to know the wiring diagram of the wall to plug something in safely.

### **I** — Inflated Interfaces
*(The opposite of **I**nterface Segregation)*

**The Principle:** *One interface to rule them all.*
Why have `IReadable` and `IWritable`? Just make `IEverything`. Force every class to implement methods it doesn't need. This creates a "fluid" dependency structure where changing a method used by Class A forces you to recompile Class B, even though Class B never touches that method.

*   **The Anti-Pattern:** The Fat Interface.

#### The Student Argument

*"Why make `IClickable`, `IDraggable`, and `IHoverable`? Just make `IInteractable` with all three methods. It saves me from writing `implements` three times."*

#### The Counter-Argument

1. **The "Dummy Code" Waste:** If you implement a big interface, you are forced to write empty methods (`return null;`) for things you don't support. This is confusing noise that other developers have to read and maintain.

2. **Coupling:** If the `IInteractable` interface adds a new method `onRightClick()`, suddenly the `CloudBackground` class stops compiling, even though clouds can't be clicked. You are forcing unrelated parts of your system to care about each other.

#### The Metaphor

> It's like ordering a cable package. You want to watch Sports. But the provider forces you to buy the "Super Bundle" which includes Cooking, Knitting, and 24-hour News channels. You are paying for (and burdened by) content you never asked for.

### **D** — Direct Dependencies
*(The opposite of **D**ependency Inversion)*

**The Principle:** *New is the glue.*
Never ask for a dependency; take it. Use the `new` keyword deep inside your business logic. If your `InvoiceService` needs a `PdfGenerator`, it should `new PdfGenerator()` right in the middle of the method. This ensures your code is permanently welded to that specific PDF library.

*   **The Anti-Pattern:** Tightly Coupled Code (Hard dependencies).

#### The Student Argument

*"Why do I have to pass the `Database` into the constructor? I can just type `db = new MySQLDatabase()` inside the method. It's fewer lines of code!"*

#### The Counter-Argument

1. **The Testing Wall:** This is the #1 reason. If you use `new` inside your class, you *cannot* unit test that class without a real database connection. If you inject the dependency, you can pass in a "Fake Database" that runs instantly in memory.

2. **Vendor Lock-in:** If you hardcode `new AWSUploader()`, and tomorrow your boss says "We are switching to Azure," you have to rewrite every single class that uploads files. If you used `IFileUploader`, you just change one line of configuration code at the start of the app.

#### The Metaphor

> Imagine a lamp that is hardwired directly into the wall of your house. If you want to move the lamp to another room, you have to tear down the drywall and call an electrician. Dependency Injection is simply putting a **plug** on the lamp. It allows you to plug it into the wall (Production) or a battery pack (Testing).

***

### The FLUID vs SOLID Matchup

| SOLID (Clean) | FLUID (Messy) | The Conflict |
| :--- | :--- | :--- |
| **S**ingle Responsibility | **F**used Responsibilities | **Focus** vs. **Blob** |
| **O**pen/Closed | **L**imitless Modification | **Extension** vs. **Surgery** |
| **L**iskov Substitution | **U**nreliable Subtypes | **Trust** vs. **Surprise** |
| **I**nterface Segregation | **I**nflated Interfaces | **Specific** vs. **Generic** |
| **D**ependency Inversion | **D**irect Dependencies | **Loose** vs. **Tight** |
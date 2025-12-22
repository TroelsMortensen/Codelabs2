# The FLUID anti principles

These are the anti principles of the SOLID principles, i.e. things we should avaid.

This is a great adjustment. Moving to **FLUID** gets rid of the extra letter and allows for a tighter mapping.

Here is the **FLUID** methodology. Each letter is the direct antagonist to the corresponding **SOLID** letter.

### **F** — Fused Responsibilities
*(The opposite of **S**ingle Responsibility)*

**The Principle:** *Don't separate concerns; melt them together.*
Why have a `User`, a `UserRepository`, and a `UserValidator` when you can just have one massive `User` class? If logic is spread out, you have to look in multiple files. Fuse it all into one giant block of code. If a class has fewer than 2,000 lines, it isn't trying hard enough.
*   **The Anti-Pattern:** The "God Object" or "Frankenstein Class."
*   **The "Fluid" visual:** Logic flows and mixes together like molten metal; there are no boundaries.

### **L** — Limitless Modification
*(The opposite of **O**pen/Closed)*

**The Principle:** *Never extend; always rewrite.*
The Open/Closed principle says you should be able to change behavior without touching the source code (via plugins or inheritance). **Limitless Modification** says: just open the file and change the `if` statements. If a requirement changes, delete the old code and write new code in its place. Version control exists for a reason, right?
*   **The Anti-Pattern:** "Shotgun Surgery" (modifying the same core methods over and over again for every new feature).

### **U** — Unreliable Subtypes
*(The opposite of **L**iskov Substitution)*

**The Principle:** *Keep them guessing.*
A subclass should not be a perfect substitute for the parent. It should have "personality." If the parent class has a method `save()`, the subclass `ReadOnlyFile` should implement `save()` by throwing a `RuntimeException`. This ensures that anyone using your code has to write `if (obj instanceof ReadOnlyFile)` everywhere to prevent crashes.
*   **The Anti-Pattern:** Refused Bequest (inheriting methods just to break them).

### **I** — Inflated Interfaces
*(The opposite of **I**nterface Segregation)*

**The Principle:** *One interface to rule them all.*
Why have `IReadable` and `IWritable`? Just make `IEverything`. Force every class to implement methods it doesn't need. This creates a "fluid" dependency structure where changing a method used by Class A forces you to recompile Class B, even though Class B never touches that method.
*   **The Anti-Pattern:** The Fat Interface.

### **D** — Direct Dependencies
*(The opposite of **D**ependency Inversion)*

**The Principle:** *New is the glue.*
Never ask for a dependency; take it. Use the `new` keyword deep inside your business logic. If your `InvoiceService` needs a `PdfGenerator`, it should `new PdfGenerator()` right in the middle of the method. This ensures your code is permanently welded to that specific PDF library.
*   **The Anti-Pattern:** Tightly Coupled Code (Hard dependencies).

***

### The FLUID vs SOLID Matchup

| SOLID (Clean) | FLUID (Messy) | The Conflict |
| :--- | :--- | :--- |
| **S**ingle Responsibility | **F**used Responsibilities | **Focus** vs. **Blob** |
| **O**pen/Closed | **L**imitless Modification | **Extension** vs. **Surgery** |
| **L**iskov Substitution | **U**nreliable Subtypes | **Trust** vs. **Surprise** |
| **I**nterface Segregation | **I**nflated Interfaces | **Specific** vs. **Generic** |
| **D**ependency Inversion | **D**irect Dependencies | **Loose** vs. **Tight** |
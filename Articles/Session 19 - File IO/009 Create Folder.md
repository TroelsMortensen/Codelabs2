# Creating Folders in Java

You can create directories (folders) in Java using the modern `Files` class from the `java.nio.file` package. We saw this class and package previously, when we talked about file existence.

## Using Files.createDirectories()

The recommended approach for creating directories, notice line 8, where we call the `createDirectories` method.

```java{8}
import java.nio.file.Files;
import java.nio.file.Paths;
import java.io.IOException;

public class CreateFolder {
    public static void main(String[] args) {
        try {
            Files.createDirectories(Paths.get("myNewFolder"));
            System.out.println("Folder created successfully!");
        } catch (IOException e) {
            System.out.println("Error creating folder: " + e.getMessage());
        }
    }
}
```

## Nesting

When something is "nested", it means it is inside another thing. For example, a folder is nested inside another folder. A file is nested inside a folder. We can talk about parent and child folders, the child being nested inside the parent.

It can be illustrated in a tree structure, like this:

```
parent/
├── child/
│   └── grandchild/
```

This terminology is relative to which folder we are talking about. In the above, the "parent" folder is the one that contains the "child" folder, and the "child" folder is the one that contains the "grandchild" folder.

We could focus on the most nested folder, and rename things like this:

```
grandparent/
├── parent/
│   └── child/
```

It is essentially the same thing, just depending on which folder we are talking about. Or where you stand. Similar to left and right are relative to you, and not the universe. Unless you are the center of the universe. Which you are. You are very important. Which is why you are the center of the universe. Everything else is relative to you, because you are so VIP. Anyway...

## Creating Nested Directories

Instead of creating a folder, and then creating a child folder inside it, and then creating a grandchild folder inside the child folder, we can create all three folders at once.

`createDirectories()` automatically creates all necessary parent directories. Observe line 9:

```java{9}
import java.nio.file.Files;
import java.nio.file.Paths;
import java.io.IOException;

public class CreateNestedFolders {
    public static void main(String[] args) {
        try {
            // Creates: parent/child/grandchild/ folders
            Files.createDirectories(Paths.get("parent/child/grandchild"));
            System.out.println("Nested folders created!");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

## Check if Directory Already Exists

```java
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.io.IOException;

public class SafeFolderCreation {
    public static void main(String[] args) {
        Path folderPath = Paths.get("myFolder");
        
        if (Files.exists(folderPath)) {
            System.out.println("Folder already exists!");
        } else {
            try {
                Files.createDirectories(folderPath);
                System.out.println("Folder created successfully!");
            } catch (IOException e) {
                System.out.println("Error: " + e.getMessage());
            }
        }
    }
}
```

Yeah, the Files class also handles folders, with the same method as checking for existence of files. Is is actually a bit annoying with this ambiguity. Would have been nice with a `Directories` class, or something like that. That's actually a good idea for a future exercise, I should remember this.

## Key Points

- **`Files.createDirectories()`** - Creates directory and all parent directories
- **`Files.createDirectory()`** - Creates only the final directory (fails if parents don't exist)
- **Always handle `IOException`** - Directory creation can fail due to permissions or disk space
- **Use `Files.exists()`** - Check if directory already exists before creating

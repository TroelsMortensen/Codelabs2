# Generating JavaDoc

Once you've written JavaDoc comments, you need to generate the HTML documentation. This can be done using the command line tool or directly from your IDE.

## Using the javadoc Command Line Tool

The `javadoc` command is part of the JDK and generates HTML documentation from your source files.

### Basic Syntax

```bash
javadoc [options] [packagenames] [sourcefiles]
```

### Simple Example

To generate JavaDoc for a single file:

```bash
javadoc BankAccount.java
```

This creates HTML files in the current directory.

### Specifying Output Directory

Use `-d` to specify where to put the generated files:

```bash
javadoc -d docs BankAccount.java
```

This creates the documentation in a `docs` folder.

### Generating for Multiple Files

Generate documentation for all Java files in the current directory:

```bash
javadoc -d docs *.java
```

### Generating for Packages

Generate documentation for an entire package:

```bash
javadoc -d docs -sourcepath src com.mycompany.banking
```

### Common Options

- `-d <directory>` - Destination directory for output
- `-author` - Include @author tags in documentation
- `-version` - Include @version tags in documentation
- `-private` - Include private members
- `-public` - Show only public members (default)
- `-windowtitle <text>` - Set browser window title
- `-doctitle <html>` - Set page title

### Complete Example

```bash
javadoc -d docs -author -version -private -windowtitle "Banking System API" -sourcepath src com.mycompany.banking
```

## Generating JavaDoc in IntelliJ IDEA

IntelliJ IDEA provides a convenient way to generate JavaDoc without using the command line.

### Steps:

1. **Open Tools Menu**
   - Go to `Tools` → `Generate JavaDoc...`

2. **Configure Settings**
   - **Output directory**: Choose where to save the HTML files
   - **Scope**: Select what to document
     - Whole project
     - Module
     - Custom scope
     - Selected files/package
   - **Visibility**: Choose which members to include
     - `public` - Public members only
     - `protected` - Public and protected
     - `package-private` - Public, protected, and package
     - `private` - All members

3. **Additional Options**
   - Check `Include JDK and library sources in -sourcepath` if you want to link to JDK documentation
   - Check `@author` to include author tags
   - Check `@version` to include version tags
   - Check `@deprecated` to include deprecated members

4. **Click OK**
   - IntelliJ generates the documentation
   - A message appears when complete
   - The output directory is opened automatically

### Quick Generation for a Single Class

1. Right-click on a Java file in the Project view
2. Select `Tools` → `Generate JavaDoc...`
3. The file will be pre-selected in the scope



## Understanding the Generated Output

After generation, you'll see several HTML files:

### Main Files

- **`index.html`** - The main entry point
  - Opens to a frame-based view with:
    - Top: Package list
    - Left: Class list
    - Right: Class details

- **`allclasses-index.html`** - Alphabetical list of all classes

- **`overview-tree.html`** - Class hierarchy tree

- **`deprecated-list.html`** - List of deprecated elements

### Package and Class Files

Each package gets its own HTML file:
- `com/mycompany/banking/package-summary.html`

Each class gets its own HTML file:
- `com/mycompany/banking/BankAccount.html`


## Best Practices

### Regenerate After Changes
Always regenerate JavaDoc after making significant documentation changes to keep it current.

### Check for Warnings
Pay attention to warnings during generation:
- Missing @param tags
- Missing @return tags
- Broken links
- Invalid HTML


### Customize Appearance
For professional projects, consider customizing:
- Window title
- Header/footer text
- CSS stylesheet
- Overview page



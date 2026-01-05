# Testing your Logger class

You should test your Logger class, to make sure it works as expected.

Do this, by creating a class, e.g. `RunApp`, with a main method.

It should

* Create an instance of the LogOutput interface, e.g. `ConsoleLogOutput`.
* Set this on the Logger instance.
* Log a few messages to the console.

**Example usage:**
```java
Logger logger = Logger.getInstance();
logger.log("INFO", "Application started");
logger.log("WARNING", "Stock not found in database");
logger.log("ERROR", "Failed to save data: " + exception.getMessage());
```

##Example output:**

```console
[INFO] Application started
[WARNING] Stock not found in database
[ERROR] Failed to save data: Database connection failed
```
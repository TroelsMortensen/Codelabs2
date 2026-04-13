# The Problem

Imagine an application that exports reports through this interface:

```java
public interface ReportExporter {
    void export(String content);
}
```

Your context code depends on `ReportExporter`:

```java
public class ReportService {
    private final ReportExporter exporter;

    public ReportService(ReportExporter exporter) {
        this.exporter = exporter;
    }

    public void publish(String content) {
        // ... format and build the report...
        String report = ...;
        exporter.export(report);
    }
}
```

Now the team wants to use a third-party PDF library, but the API is incompatible:

```java
public class ThirdPartyPdfWriter {
    public void writePdf(byte[] data) {
        System.out.println("Writing PDF bytes: " + data.length);
    }
}
```

Notice the difference in the parameter type of the `export` and `writePdf` methods. Different names, different parameter types. And, because the PDF exporter is a third-party library, you cannot modify it. You cannot add the `export` method to the `ThirdPartyPdfWriter` class.

How do we use this third-party PDF library in our application, without updating the `ReportService` class? What happens if we _do_ update the `ReportService` class, but later, a security vulnerability is discovered in the PDF-exporter library? We need to find another PDF library, and again update the `ReportService` class. This is a maintenance nightmare.

Instead, we write our code, and define an interface which we expect to use, with the knowledge that eventually we will create or find a concrete class with the desired functionality.

## Why This Is a Problem

- `ReportService` expects `ReportExporter::export(String)`.
- `ThirdPartyPdfWriter` provides `writePdf(byte[])`.
- The interfaces do not match.

If you directly couple `ReportService` to `ThirdPartyPdfWriter`, you break the abstraction and increase dependency on a specific library. This is not ideal.

## A Poor Fix

One common but weak fix is to change context code, by changing the constructor to accept a `ThirdPartyPdfWriter` instance instead of a `ReportExporter` instance:

```java
public class ReportService {
    private final ThirdPartyPdfWriter writer;

    public ReportService(ThirdPartyPdfWriter writer) {
        this.writer = writer;
    }

    public void publish(String content) {
        writer.writePdf(content.getBytes());
    }
}
```

This works, but introduces design issues:
- `ReportService` is no longer reusable with other exporters.
- Every library change leaks into business code.
- Testing gets harder because infrastructure details spread across the codebase.

We need a way to keep `ReportService` unchanged while still using `ThirdPartyPdfWriter`.

_As a side note, the above comments may lead you to think of the Strategy pattern, i.e. different export strategies._ 
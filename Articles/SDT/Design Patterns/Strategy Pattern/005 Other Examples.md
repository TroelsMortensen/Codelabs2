# Other Examples

Strategy is useful whenever multiple interchangeable behaviors exist for one task.

## Example 1: Discount Calculation

### Context

An e-commerce system supports different discount policies: no discount, seasonal discount, and loyalty discount.

```java
public interface DiscountStrategy {
    double apply(double subtotal);
}

public class NoDiscountStrategy implements DiscountStrategy {
    @Override
    public double apply(double subtotal) {
        return subtotal;
    }
}

public class SeasonalDiscountStrategy implements DiscountStrategy {
    @Override
    public double apply(double subtotal) {
        return subtotal * 0.90;
    }
}

public class LoyaltyDiscountStrategy implements DiscountStrategy {
    @Override
    public double apply(double subtotal) {
        return subtotal * 0.85;
    }
}
```

## Example 2: Route Planning

### Context

A navigation app can choose different route policies: fastest route, shortest route, or eco-friendly route.

```java
public interface RouteStrategy {
    String buildRoute(String from, String to);
}

public class FastestRouteStrategy implements RouteStrategy {
    @Override
    public String buildRoute(String from, String to) {
        return "Fastest route from " + from + " to " + to;
    }
}

public class EcoRouteStrategy implements RouteStrategy {
    @Override
    public String buildRoute(String from, String to) {
        return "Eco route from " + from + " to " + to;
    }
}
```

## Example 3: Export Format

### Context

A reporting module exports data in different formats without changing report generation logic.

```java
public interface ExportStrategy {
    String export(String reportData);
}

public class CsvExportStrategy implements ExportStrategy {
    @Override
    public String export(String reportData) {
        return "CSV:" + reportData;
    }
}

public class JsonExportStrategy implements ExportStrategy {
    @Override
    public String export(String reportData) {
        return "{\"report\":\"" + reportData + "\"}";
    }
}
```

## Example 4: Text Formatting

### Context

An editor can format the same content in plain text, markdown, or HTML using different strategies.

```java
public interface TextFormatStrategy {
    String format(String text);
}

public class MarkdownFormatStrategy implements TextFormatStrategy {
    @Override
    public String format(String text) {
        return "**" + text + "**";
    }
}

public class HtmlFormatStrategy implements TextFormatStrategy {
    @Override
    public String format(String text) {
        return "<strong>" + text + "</strong>";
    }
}
```


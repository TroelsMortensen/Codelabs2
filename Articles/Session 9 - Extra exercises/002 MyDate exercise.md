# MyDate Exercise (Simplified Date Class)

Implement a simplified immutable `MyDate` class to represent a calendar date.\
Provide multiple constructors, common instance methods, and a few static utility methods. Write a small `main` program to interactively create and manipulate dates and to validate your implementation.

Constraints and assumptions:
- Use the Gregorian calendar rules.
- Support years in range [1900, 3000].
- Months are 1–12, days depend on month and leap year.
- The class should be immutable: all fields are `final`, and methods that "change" the date return new `MyDate` instances.

Fields:
- `year: int`
- `month: int` (1–12)
- `day: int` (1–28/29/30/31 depending on month)

Constructors:
- `MyDate()` → today (use system date)
- `MyDate(int year, int month, int day)` → validate inputs
- `MyDate(String iso)` → parse `"yyyy-mm-dd"` (e.g., `"2024-09-18"`), validate inputs
- `MyDate(MyDate other)` → copy constructor

Instance methods:
- `getYear(): int`, `getMonth(): int`, `getDay(): int`
- `isLeapYear(): boolean`
- `lengthOfMonth(): int` → 28/29/30/31 depending on month and leap year
- `withYear(int y): MyDate` (validated)
- `withMonth(int m): MyDate` (validated; clamp day to month length if needed)
- `withDay(int d): MyDate` (validated)
- `plusDays(int n): MyDate` (n can be negative)
- `plusMonths(int n): MyDate` (adjust year; clamp day to month length)
- `plusYears(int n): MyDate` (adjust Feb 29 to Feb 28 on non-leap years)
- `compareTo(MyDate other): int` (negative if this<other, zero if equal, positive if this>other)
- `equals(Object o): boolean` and `hashCode(): int`
- `toString(): String` → ISO format `yyyy-mm-dd` with zero-padded month/day

Static utility methods:
- `now(): MyDate` → today
- `isValid(int y, int m, int d): boolean`
- `isLeapYear(int y): boolean`
- `daysBetween(MyDate a, MyDate b): int` (absolute difference in days)
- `of(int y, int m, int d): MyDate` (factory with validation)

Validation rules:
- Throw `IllegalArgumentException` for invalid inputs (e.g., month outside 1–12, day outside month length, year outside supported range).

Example console session:
```console
Create date (yyyy-mm-dd):
2024-02-29
Valid: true
Enter days to add:
1
Result: 2024-03-01

Enter another date (yyyy-mm-dd):
2023-12-31
Days between: 60

Set month to 2 on 2023-03-31 (clamp day if needed):
Result: 2023-02-28
```

Hints for implementation details (optional to read):
- To compute `daysBetween`, convert a `MyDate` to an absolute day count (e.g., days since 1900-01-01) and subtract, or iterate carefully.
- Leap year rule: year divisible by 4 is a leap year, except years divisible by 100 are not, unless divisible by 400.
- Zero-pad with `String.format("%04d-%02d-%02d", year, month, day)`.



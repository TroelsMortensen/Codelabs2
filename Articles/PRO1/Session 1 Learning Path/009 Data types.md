# Data types

Java has two kinds of data types:

1. **Primitive data types**: These are the basic data types that are built into the Java language. They include
    * `int` (integer)
    * `double` (floating-point number)
    * `char` (character)
    * `boolean` (true/false)
    * `byte` (8-bit integer)
    * `short` (16-bit integer)
    * `long` (64-bit integer)
    * `float` (single-precision floating-point number)

2. **Reference data types**: These are data types that refer to objects. They include:
   * Classes
   * Interfaces
   * Arrays

We will focus on primitive data types for now, and come back to the reference data types later in the course.

The following pages will introduce each type in detail, but for now, here is a brief overview of the primitive data types:

| Data Type | Size (bits) | Description                          |
|-----------|-------------|--------------------------------------|
| `int`     | 32          | Integer value, e.g., 42              |
| `double`  | 64          | Floating-point number, e.g., 3.14    |
| `char`    | 16          | Single character, e.g., 'A'          |
| `boolean` | 1           | True or false value                  |
| `byte`    | 8           | Small integer value, e.g., 100       |
| `short`   | 16          | Small integer value, e.g., 1000      |
| `long`    | 64          | Large integer value, e.g., 100000L   |
| `float`   | 32          | Single-precision floating-point, e.g., 3.14f |



Expand a type to see when you would use it.

<Quiz>
{
    "Type": "ExpandableDetails",
    "Details": [
        {
            "Header": "int",
            "Content": "<p>Default choice for whole numbers. Use it unless you know you need a smaller or larger integer type.</p><p><code>int count = 42;</code></p>"
        },
        {
            "Header": "double",
            "Content": "<p>Default choice for decimal numbers. Prefer <code>double</code> over <code>float</code> unless you have a reason not to.</p><p><code>double price = 3.14;</code></p>"
        },
        {
            "Header": "char",
            "Content": "<p>Use for a single character, written in single quotes.</p><p><code>char letter = 'A';</code></p>"
        },
        {
            "Header": "boolean",
            "Content": "<p>Use for yes/no decisions. A <code>boolean</code> can only be <code>true</code> or <code>false</code>.</p><p><code>boolean isReady = true;</code></p>"
        },
        {
            "Header": "byte",
            "Content": "<p>Use for very small whole numbers when you specifically need an 8-bit value. For everyday counting, prefer <code>int</code>.</p><p><code>byte small = 100;</code></p>"
        },
        {
            "Header": "short",
            "Content": "<p>Use for small whole numbers when you specifically need a 16-bit value. For everyday counting, prefer <code>int</code>.</p><p><code>short medium = 1000;</code></p>"
        },
        {
            "Header": "long",
            "Content": "<p>Use when a whole number may be larger than <code>int</code> can hold. The literal often ends with <code>L</code>.</p><p><code>long big = 100000L;</code></p>"
        },
        {
            "Header": "float",
            "Content": "<p>Use for decimal numbers only when you need single precision. The literal must end with <code>f</code>. Prefer <code>double</code> in this course.</p><p><code>float approx = 3.14f;</code></p>"
        }
    ]
}
</Quiz>

## Video

John here explains the different data types in 10 minutes.

<video src="https://www.youtube.com/watch?v=WQ7mvQFSmYc"></video>

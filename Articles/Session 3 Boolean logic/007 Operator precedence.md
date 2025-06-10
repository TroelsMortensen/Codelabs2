# Operator Precedence in Boolean Expressions

Operator precedence determines the order in which operators are evaluated in an expression. In Java, this is important when combining boolean values with logical operators like `&&` (AND), `||` (OR), and `!` (NOT).

## Precedence Order
1. **NOT (`!`)** has the highest precedence.
2. **AND (`&&`)** comes next.
3. **OR (`||`)** has the lowest precedence.

This means that `!` is evaluated before `&&`, and `&&` is evaluated before `||`.

## Why is this important?
A boolean expression can contain multiple operators, and it _is not_ just evalued left to right.\
If you write an expression with multiple operators, Java will evaluate them according to these rules _unless you use parentheses to change the order_.

## Examples

### Example 1

```java
boolean a = true;
boolean b = false;
boolean c = true;

System.out.println(!a || b && c); // false
```

**Explanation:**
- `!a` is evaluated first (`!true` is `false`). The expression is then `false || b && c`.
- Then `b && c` (`false && true` is `false`). The expression is now `false || false`.
- Then `false || false` is `false`.

Generally, I would recommend clarifying your code with parentheses to avoid confusion. The above expression could be written as:

```java
boolean a = true;
boolean b = false;
boolean c = true;

System.out.println(!a || (b && c)); // notice parentheses around b && c
```

---
### Example 2

```java
boolean a = true;
boolean b = false;
boolean c = true;

System.out.println(a || b && c); // true
```
**Explanation:**
- `b && c` is evaluated first (`false && true` is `false`). 
- Then `a || false` is `true`

---
### Example 3


```java
boolean a = true;
boolean b = false;
boolean c = true;

System.out.println(!(a || b) && c); // false
```
**Explanation:**
- `a || b` is `true`
- `!true` is `false`
- `false && c` is `false`

---
### Example 4

```java
boolean a = true;
boolean b = false;
boolean c = true;

System.out.println(a || b || c && false); // true
```
**Explanation:**
- `c && false` is `false`
- `a || b || false` is `true`

## Using Parentheses
You can use parentheses to change the order of evaluation:

```java
boolean a = true;
boolean b = false;
boolean c = true;

System.out.println((!a || b) && c); // false
```
- `!a` is `false`
- `false || b` is `false`
- `false && c` is `false`

---

```java
boolean a = true;
boolean b = false;
boolean c = true;

System.out.println(!(a || (b && c))); // false
```
- `b && c` is `false`, 
- `a || false` is `true`, 
- `!true` is `false`


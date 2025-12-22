# The Broken Window Principle

The **Broken Window Principle** provides a clear rule for maintaining code quality and preventing technical debt from accumulating.

## The Rule

> **Fix problems immediately, even small ones. Never leave visible signs of disorder in your codebase.**

If you see a problem - whether it's a code smell, a TODO comment, a small bug, or a violation of coding standards - fix it right away. Don't let it accumulate.

## The Core Concept

**Visible signs of disorder encourage further disorder.**

When developers see problems in the codebase that aren't being fixed, they learn that:
- Quality isn't a priority
- It's acceptable to cut corners
- No one will notice or care about small issues
- Standards are flexible or optional

This creates a culture where more problems are introduced, and the codebase gradually deteriorates.

## What Counts as a "Broken Window"?

A "broken window" in code is any visible sign of disorder or neglect:

### Code Quality Issues
- **Code smells** - Long methods, deep nesting, magic numbers
- **Duplicated code** - Copy-paste code that should be extracted
- **Dead code** - Unused methods, commented-out code
- **Poor naming** - Vague variable names like `data`, `info`, `temp`, or misleading method names
- **Commented-out code** - Blocks of old code left "just in case"
- **God Classes** - A 3,000-line class tells the developer, "We don't care about the Single Responsibility Principle here"

### Technical Debt Markers
- **TODO comments** - Left in the code without resolution
- **FIXME comments** - Known issues that aren't addressed
- **HACK comments** - Temporary solutions that become permanent
- **XXX comments** - Code that needs attention

### Standards Violations
- **Inconsistent formatting** - Mixed indentation, spacing
- **Inconsistent naming** - camelCase vs snake_case
- **Missing documentation** - Public methods without comments
- **Incomplete implementations** - Methods that throw "NotImplementedException"
- **Compiler warnings** - Ignoring the yellow warning triangles because "the code still runs"
- **No tests** - A lack of unit tests signals that correctness isn't valued

### Small Bugs
- **Minor bugs** - Edge cases not handled
- **Incomplete error handling** - Missing try-catch blocks
- **Incomplete tests** - Tests that are skipped or incomplete



## When to Apply the Principle

Apply the Broken Window Principle:

- **During development** - Fix problems as you encounter them
- **During code review** - Don't approve code with broken windows
- **During refactoring** - Fix related problems you discover
- **During bug fixes** - Fix the root cause, not just the symptom

## The Balance

The principle doesn't mean you should:
- Refactor everything you touch (that's a different principle)
- Stop feature development to fix every minor issue
- Perfectionism that prevents progress

It means you should:
- Fix problems you encounter in the code you're working on
- Not introduce new broken windows
- Not ignore obvious problems
- Maintain a baseline of code quality

## Summary

The Broken Window Principle states:
- **Fix problems immediately** - Don't let them accumulate
- **Visible disorder encourages more disorder** - Small problems lead to big problems
- **Maintain standards** - What you tolerate becomes the norm
- **Culture matters** - Team behavior follows what's accepted

By following this principle, you maintain code quality and prevent technical debt from accumulating.


# Single Responsibility Principle - Introduction

The **Single Responsibility Principle (SRP)** is the first principle in SOLID. It's a fundamental guideline for organizing code.

## Definition

**A class should have only one reason to change.**

Or, in other words:

**A class should have only one responsibility.**

This means each class should have a single, well-defined responsibility. If a class has multiple reasons to change, it has multiple responsibilities and violates SRP. We will actually generally violate this principle to some extent. This is where "guideline, not rule" comes in.

## What is a "Responsibility"?

A **responsibility** is a reason for a class to change. It represents one aspect of the system's behavior or one concern that the class addresses.

Examples of responsibilities:
- Managing user data (name, email, password)
- Sending emails
- Calculating prices
- Validating input
- Persisting data to a database
- Generating reports

Each of these is a distinct responsibility that could change independently. Though, some of these could be sepated even further, into smaller responsibilities. So, it's a balance how far you want to separate the responsibilities.

## The Principle in Practice

A class following SRP:
- Has **one clear purpose**
- Has **one reason to change**
- Does **one thing well**
- Is **focused and cohesive**

When you look at a class, you should be able to describe its purpose in a single sentence without using "and" or "or".

**Good:** "This class manages user account information."
**Bad:** "This class manages user account information and sends emails and validates passwords."

## Benefits of SRP

Following the Single Responsibility Principle provides several benefits:

### 1. Easier to Understand

When a class has one responsibility, it's easier to understand what it does. You don't need to understand multiple concerns to work with the class.

### 2. Easier to Maintain

If you need to change how emails are sent, you only modify the email class. You don't risk breaking user management functionality.

### 3. Easier to Test

Classes with single responsibilities are easier to test. You can test email functionality independently of user management.

### 4. Easier to Reuse

A focused class is more likely to be reusable. A class that does everything is harder to reuse in different contexts.

### 5. Reduced Coupling

When responsibilities are separated, classes are less coupled. Changes to one responsibility don't affect others.

---



## Common Violations

Classes often violate SRP when they:
- Handle both business logic and data persistence
- Manage data and perform I/O operations
- Combine validation and processing
- Mix presentation and business logic
- Handle multiple unrelated concerns

## Summary

- **Definition:** A class should have only one reason to change
- **Key idea:** One responsibility per class
- **Benefits:** Easier to understand, maintain, test, and reuse
- **Question to ask:** "Can I describe this class's purpose in one sentence?"

Next, we'll look at examples of SRP violations and the problems they cause.


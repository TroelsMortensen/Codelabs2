# Introduction to Transactions

Welcome to **Transactions**! This is a fundamental concept in database systems that ensures your data stays consistent and reliable, even when things go wrong.

## What is a Transaction?

A **transaction** is a group of database operations that must **all succeed together or all fail together**. Think of it as an "all-or-nothing" operation - either everything happens correctly, or nothing happens at all.

### The Core Idea

When you perform multiple related operations on a database, you want them to be treated as a _single, indivisible unit_.\
If any part fails, the entire operation should be _rolled back_, leaving the database in its original state.

It is like re-loading a previous save point in a game. If you fail, you can go back to the previous save point and try again.

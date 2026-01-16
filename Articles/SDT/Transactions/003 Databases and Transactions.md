# How Databases Handle Transactions

The good news is that **modern databases handle transactions automatically** for you. You don't need to write special code to make transactions work - the database ensures that:

- **All operations succeed together** - If you perform multiple operations, they all complete
- **Or all operations fail together** - If anything goes wrong, everything is rolled back
- **Data stays consistent** - Your database never ends up in a partially-updated state

## What This Means for You

As a developer, you typically don't need to worry about the low-level details of transactions. The database:

- Automatically groups related operations
- Ensures consistency
- Handles rollbacks if something fails
- Maintains data integrity

You just write your code normally, and the database takes care of transaction management behind the scenes.

## Postgres Transactions

When using Postgres, or probably any other modern relational database, you have the option to set the transaction mode.

Either
- Each command is executed in a separate transaction.
or
- You manually tell the database when to start and end a transaction. You will need this, if you want to perform multiple operations as a single transaction. Luckily, it is very simple to do.

## The ACID Properties

Transactions follow four key principles (often called ACID):

- **Atomicity** - All or nothing (like our analogies)
- **Consistency** - Data stays valid
- **Isolation** - Concurrent operations don't interfere
- **Durability** - Once committed, changes are permanent

We'll explore what happens when transactions aren't used in the next section, which will help you understand why these properties matter.

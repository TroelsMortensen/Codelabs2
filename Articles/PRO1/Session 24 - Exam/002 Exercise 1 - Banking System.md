# Exercise 1 - Banking System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class BankCustomer {
        - Name : String
        + getName() String
        + setName(name : String) void
    }
    
    class Account {
        - accountNumber : String
        + deposit(amount : double, depositedDate : LocalDate) void
        + getDeposits() ArrayList~Deposit~
        + calculateBalance() double
        + numberOfDeposits() int
    }
    
    class Deposit {
        - amount : double
        - depositedDate : LocalDate
        + Deposit(amount : double, depositedDate : LocalDate)
        + getAmount() double
        + getDepositedDate() LocalDate
    }
    
    class Loan {
        - initialAmount : double
        + deposit(amount : double, depositedDate : LocalDate) void
    }
    
    class CreditcardAccount {
        - creditLimit : double
        + deposit(amount : double, depositedDate : LocalDate) void
        + getCreditCard() Creditcard
    }
    
    class Creditcard {
        - number : String
        - validTo : LocalDate
        + Creditcard(number : String, validTo : LocalDate)
        + copy() Creditcard
    }
    
    BankCustomer --> "*" Account 
    Account *--> "*" Deposit 
    Account <|-- Loan
    Account <|-- CreditcardAccount
    CreditcardAccount *--> Creditcard
```

## Notes:
- A negative deposit is called a withdrawal
- You cannot make withdrawals from a loan
- Use `java.time.LocalDate` for date handling


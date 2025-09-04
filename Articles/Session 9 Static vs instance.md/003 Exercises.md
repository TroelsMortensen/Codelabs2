# Static Methods and Fields Exercises

## Exercise 1 - Counter Class

Write a program that implements a Counter class with static methods and fields. The class should track the total number of Counter objects created and provide static methods to access this information.

**Requirements:**
- A static field to count total instances created
- A static method to get the current count
- A static method to reset the counter
- Instance constructor that increments the static counter
- Instance method to get the instance number

```console
Counter 1 created
Counter 2 created
Counter 3 created
Total counters: 3
Instance 2 of 3
Reset counter
Total counters: 0
```

## Exercise 2 - Math Utility Class

Implement a MathUtils class with static methods for common mathematical operations. The class should not be instantiable.

**Requirements:**
- Static method to calculate factorial
- Static method to check if a number is prime
- Static method to find the greatest common divisor (GCD)
- Static method to calculate power (base^exponent)
- Private constructor to prevent instantiation
- Static final field for PI approximation

```console
Enter a number for factorial:
5
Factorial of 5: 120

Enter a number to check if prime:
17
17 is prime

Enter two numbers for GCD:
48 18
GCD of 48 and 18: 6

Enter base and exponent:
2 8
2^8 = 256
```

## Exercise 3 - Bank Account Manager

Implement the following class based on the UML diagram below. The class should use static methods and fields to manage bank account information.

```
┌─────────────────────────────────┐
│         BankAccount             │
├─────────────────────────────────┤
│ <u>- accountNumber: int</u>     │
│ - balance: double               │
│ - accountHolder: String         │
├─────────────────────────────────┤
│ + nextAccountNumber: int        │
│ + totalAccounts: int            │
│ + totalBalance: double          │
├─────────────────────────────────┤
│ + BankAccount(holder: String,   │
│   initialBalance: double)       │
│ + deposit(amount: double): void │
│ + withdraw(amount: double):     │
│   boolean                       │
│ + getBalance(): double          │
│ + getAccountNumber(): int       │
│ + getAccountHolder(): String    │
│ + getTotalAccounts(): int       │
│ + getTotalBalance(): double     │
│ + getNextAccountNumber(): int   │
└─────────────────────────────────┘
```

**Requirements:**
- Static field `nextAccountNumber` starts at 1000 and increments for each new account
- Static field `totalAccounts` tracks the number of accounts created
- Static field `totalBalance` tracks the sum of all account balances
- Constructor takes account holder name and initial balance
- Instance methods for deposit, withdraw, and getters
- Static methods to access total account information
- Withdrawal should return false if insufficient funds

```console
Enter account holder name:
John Smith
Enter initial balance:
1000.00
Account created: #1000 for John Smith

Enter deposit amount:
500.00
New balance: $1500.00

Enter withdrawal amount:
200.00
Withdrawal successful. New balance: $1300.00

Enter withdrawal amount:
2000.00
Withdrawal failed. Insufficient funds.

Bank Statistics:
Total accounts: 1
Total balance: $1300.00
Next account number: 1001
```

# If Statement Exercises

## Exercise 1 - Grade Calculator

Write a program that reads a percentage score and prints the corresponding letter grade:
- A: 90-100
- B: 80-89
- C: 70-79
- D: 60-69
- F: 0-59

```console
Enter percentage:
85
Grade: B
```

## Exercise 2 - Triangle Type

Write a program that reads three sides of a triangle and determines the type:
- Equilateral: all sides equal
- Isosceles: exactly two sides equal
- Scalene: all sides different
- Invalid: sum of any two sides <= third side

```console
Enter side 1:
5
Enter side 2:
5
Enter side 3:
5
Triangle type: Equilateral
```

## Exercise 3 - Library Fine Calculator

Write a program that calculates library fines based on book type and days overdue. Read the book type (fiction/non-fiction/reference) and days overdue. Apply these rules:
- Fiction: $0.50 per day, max $10
- Non-fiction: $0.25 per day, max $5
- Reference: $1.00 per day, max $20

Additional conditions:
- If overdue > 30 days: add $5 processing fee
- If overdue > 60 days: add $10 replacement fee
- If book type is "reference" and overdue > 14 days: add $15 rush processing fee

```console
Enter book type (fiction/non-fiction/reference):
reference
Enter days overdue:
45
Base fine: $20.00
Processing fee: $5.00
Rush processing fee: $15.00
Total fine: $40.00
```

## Exercise 4 - Restaurant Bill Calculator

Write a program that calculates a restaurant bill with multiple conditions. Read the 

* bill amount 
* number of people
* day of week
* time of day. 
  
Apply these rules:

- Happy hour (3-6 PM): 20% discount on drinks
- Senior discount (65+): 10% off total (ask for age)
- Group discount (8+ people): 15% off total
- Weekend surcharge (Saturday/Sunday): 5% surcharge
- Service charge: 18% if bill > $100, 15% otherwise

Calculate the final bill and show the breakdown of all applicable charges/discounts.

```console
Enter bill amount:
120.00
Enter number of people:
10
Enter day of week:
Saturday
Enter time (24-hour format):
16
Enter your age:
67
Original bill: $120.00
Group discount (15%): -$18.00
Senior discount (10%): -$10.20
Weekend surcharge (5%): +$4.59
Service charge (18%): +$17.35
Final bill: $113.74
```



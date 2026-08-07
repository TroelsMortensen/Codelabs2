# Exercise 41 - Employee Management System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class EmployeeList {
        - size : int
        + EmployeeList(maxNumberOfEmployees : int)
        + addEmployee(employee : Employee) void
        + removeEmployee(employee : Employee) void
        + getNumberOfEmployees() int
        + getAllEmployees() Employee[]
        + getTotalEarningsPerWeek() double
        + toString() String
        + equals(obj : Object) boolean
    }
    
    class Employee {
        - name : String
        + Employee(name : String, birthday : Date)
        + getName() String
        + setName(name : String) void
        + getBirthday() Date
        + toString() String
        + equals(obj : Object) boolean
        + earningsPerWeek()* double
    }
    
    class HourlyEmployee {
        - wagePerHour : double
        - hoursWorkedPerWeek : double
        + setWagePerHour(wagePerHour : double) void
        + getWagePerHour() double
        + setHoursWorkedPerWeek(hoursWorkedPerWeek : double) void
        + getHoursWorkedPerWeek() double
        + earningsPerWeek() double
        + toString() String
        + equals(obj : Object) boolean
    }
    
    class SalariedEmployee {
        - weeklySalary : double
        + setWeeklySalary(weeklySalary : double) void
        + getWeeklySalary() double
        + earningsPerWeek() double
        + toString() String
        + equals(obj : Object) boolean
    }
    
    class Date {
        - day : int
        - month : int
        - year : int
        + Date(day : int, month : int, year : int)
        + set(day : int, month : int, year : int) void
        + getDay() int
        + getMonth() int
        + getYear() int
        + copy() Date
        + toString() String
        + equals(obj : Object) boolean
    }
    
    EmployeeList --> "*" Employee
    Employee --> "1" Date
    Employee <|-- HourlyEmployee
    Employee <|-- SalariedEmployee
```

## Notes:
- The `earningsPerWeek()` method in `Employee` is abstract (marked with *)
- For `HourlyEmployee`, earnings = wagePerHour × hoursWorkedPerWeek
- For `SalariedEmployee`, earnings = weeklySalary
- `EmployeeList` should track all employees and calculate total weekly earnings
- The birthday is stored as a `Date` object
- Implement `equals()` to compare employees by name and birthday
- Implement `toString()` to provide meaningful string representations


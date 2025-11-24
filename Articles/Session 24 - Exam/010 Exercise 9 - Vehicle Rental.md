# Exercise 9 - Vehicle Rental System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class RentalCompany {
        - companyName : String
        + addVehicle(vehicle : Vehicle) void
        + rentVehicle(licensePlate : String, days : int) Rental
        + getAvailableVehicles() ArrayList~Vehicle~
        + getTotalIncome() double
    }
    
    class Vehicle {
        - licensePlate : String
        - model : String
        - year : int
        - isRented : boolean
        + Vehicle(licensePlate : String, model : String, year : int)
        + getLicensePlate() String
        + getModel() String
        + isRented() boolean
        + setRented(rented : boolean) void
        + getDailyRate() double
    }
    
    class Car {
        - numberOfSeats : int
        + getDailyRate() double
    }
    
    class Motorcycle {
        - engineSize : int
        + getDailyRate() double
    }
    
    class Truck {
        - loadCapacity : double
        + getDailyRate() double
    }
    
    class Rental {
        - rentalId : int
        - rentalDate : LocalDate
        - numberOfDays : int
        - vehicle : Vehicle
        + Rental(rentalId : int, vehicle : Vehicle, numberOfDays : int)
        + calculateTotalCost() double
        + getVehicle() Vehicle
    }
    
    RentalCompany --> "*" Vehicle : vehicles
    RentalCompany --> "*" Rental : rentals
    Car --|> Vehicle
    Motorcycle --|> Vehicle
    Truck --|> Vehicle
```

## Notes:
- Cars cost 300 kr per day plus 50 kr for each seat beyond 4
- Motorcycles cost 200 kr per day plus 1 kr per cc of engine size
- Trucks cost 500 kr per day plus 100 kr per ton of load capacity
- Use `java.time.LocalDate` for date handling


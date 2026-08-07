# Exercise 15 - Flight Booking System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Airline {
        - airlineName : String
        - airlineCode : String
        + addFlight(flight : Flight) void
        + getFlightsByDestination(destination : String) ArrayList~Flight~
        + getTotalRevenue() double
    }
    
    class Flight {
        - flightNumber : String
        - origin : String
        - destination : String
        - departureTime : LocalDateTime
        - arrivalTime : LocalDateTime
        - aircraft : Aircraft
    }
    
    class Aircraft {
        - registrationNumber : String
        - model : String
        - totalSeats : int
        + Aircraft(registrationNumber : String, model : String, totalSeats : int)
    }
    
    class Booking {
        - bookingReference : String
        - bookingDate : LocalDate
        - passengerName : String
        - passengerEmail : String
        + Booking(bookingReference : String, passengerName : String, passengerEmail : String)
    }
    
    class _Seat_ {
        - seatNumber : String
        # basePrice : double
        - isBooked : boolean
        + getSeatNumber() String
        + getPrice()* double
        + book() void
    }
    
    class EconomyClass {
        - hasExtraLegRoom : boolean
        + getPrice() double
    }
    
    class BusinessClass {
        - numberOfMeals : int
        + getPrice() double
    }
    
    class FirstClass {
        + getPrice() double
    }
    
    Airline --> "*" Flight : flights
    Flight --> "1" Aircraft : aircraft
    Flight --> "*" Booking : bookings
    Booking --> "*" _Seat_ : seats
    _Seat_ <|-- EconomyClass
    _Seat_ <|-- BusinessClass
    _Seat_ <|-- FirstClass
```

## Notes:
- Economy class seats cost the base price, plus 50 kr extra if `hasExtraLegRoom` is true
- Business class seats cost 2.5 times the base price, plus 100 kr per meal (based on `numberOfMeals`)
- First class seats cost 4 times the base price
- Use `java.time.LocalDateTime` for flight times and `java.time.LocalDate` for booking dates
- Use `Duration.between()` to calculate flight duration
- The `getPrice()` method in `Seat` is abstract (marked with *)


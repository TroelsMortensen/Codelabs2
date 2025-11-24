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
        + Flight(flightNumber : String, origin : String, destination : String, departureTime : LocalDateTime, arrivalTime : LocalDateTime, aircraft : Aircraft)
        + getFlightNumber() String
        + getOrigin() String
        + getDestination() String
        + getAvailableSeats() int
        + getDuration() int
    }
    
    class Aircraft {
        - registrationNumber : String
        - model : String
        - totalSeats : int
        + Aircraft(registrationNumber : String, model : String, totalSeats : int)
        + getRegistrationNumber() String
        + getModel() String
        + getTotalSeats() int
    }
    
    class Booking {
        - bookingReference : String
        - bookingDate : LocalDate
        - passengerName : String
        - passengerEmail : String
        + Booking(bookingReference : String, passengerName : String, passengerEmail : String)
        + getBookingReference() String
        + getTotalPrice() double
    }
    
    class Seat {
        - seatNumber : String
        - seatClass : String
        - basePrice : double
        - isBooked : boolean
        + Seat(seatNumber : String, seatClass : String, basePrice : double)
        + getSeatNumber() String
        + getSeatClass() String
        + getPrice() double
        + book() void
    }
    
    class EconomyClass {
        + getPrice() double
    }
    
    class BusinessClass {
        + getPrice() double
    }
    
    class FirstClass {
        + getPrice() double
    }
    
    Airline --> "*" Flight : flights
    Flight --> "1" Aircraft : aircraft
    Flight --> "*" Booking : bookings
    Booking --> "*" Seat : seats
    EconomyClass --|> Seat
    BusinessClass --|> Seat
    FirstClass --|> Seat
```

## Notes:
- Economy class seats cost the base price
- Business class seats cost 2.5 times the base price
- First class seats cost 4 times the base price
- Use `java.time.LocalDateTime` for flight times and `java.time.LocalDate` for booking dates
- Use `Duration.between()` to calculate flight duration


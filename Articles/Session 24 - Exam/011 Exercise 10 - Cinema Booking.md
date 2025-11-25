# Exercise 10 - Cinema Booking System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Cinema {
        - name : String
        + addScreening(screening : Screening) void
        + getScreeningsByMovie(movieTitle : String) ArrayList~Screening~
        + getTotalRevenue() double
    }
    
    class Movie {
        - title : String
        - duration : int
        - genre : String
        - ageRating : int
        + Movie(title : String, duration : int, genre : String, ageRating : int)
    }
    
    class Screening {
        - screeningTime : LocalDateTime
        - screenNumber : int
        - availableSeats : int
        - nextSeatNumber : int
        + Screening(movie : Movie, screeningTime : LocalDateTime, screenNumber : int, availableSeats : int)
        + getAvailableSeats() int
        + bookSeats(numberOfSeats : int, type : String) ArrayList~Ticket~
        + getScreeningTime() LocalDateTime
    }
    
    class _Ticket_ {
        - seatNumber : int
        # price : double
        + Ticket(seatNumber : int)
        + getPrice()* double
    }
    
    class StandardTicket {
        + getPrice() double
    }
    
    class StudentTicket {
        + getPrice() double
    }
    
    class ChildTicket {
        - includesSeat : boolean
        + getPrice() double
    }
    
    Cinema --> "*" Screening 
    Screening --> Movie 
    Screening --> "*" _Ticket_ 
    _Ticket_ <|-- StandardTicket
    _Ticket_ <|-- StudentTicket
    _Ticket_ <|-- ChildTicket
```

## Notes:
- Standard tickets cost 120 kr
- Student tickets cost 90 kr
- Child tickets cost 50 kr, but an extra 10 kr if a seat is included
- Use `java.time.LocalDateTime` for screening times
- The `bookSeats()` method should return an `ArrayList` of `Ticket` objects equal to the `numberOfSeats` requested
- The `type` parameter specifies the ticket type: "standard", "student", or "child"
- If there are not enough available seats, throw an `IllegalStateException`
- Seat numbers are auto-incremented integers starting from 1 for each screening


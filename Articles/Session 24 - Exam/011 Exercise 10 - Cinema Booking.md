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
        + getTitle() String
        + getDuration() int
        + getGenre() String
        + getAgeRating() int
    }
    
    class Screening {
        - screeningTime : LocalDateTime
        - screenNumber : int
        - availableSeats : int
        + Screening(movie : Movie, screeningTime : LocalDateTime, screenNumber : int, availableSeats : int)
        + getAvailableSeats() int
        + bookSeats(numberOfSeats : int) boolean
        + getScreeningTime() LocalDateTime
    }
    
    class Ticket {
        - ticketId : int
        - seatNumber : String
        - price : double
        + Ticket(ticketId : int, seatNumber : String)
        + getPrice() double
    }
    
    class StandardTicket {
        + getPrice() double
    }
    
    class StudentTicket {
        + getPrice() double
    }
    
    class ChildTicket {
        + getPrice() double
    }
    
    Cinema --> "*" Screening : screenings
    Screening --> "1" Movie : movie
    Screening --> "*" Ticket : tickets
    StandardTicket --|> Ticket
    StudentTicket --|> Ticket
    ChildTicket --|> Ticket
```

## Notes:
- Standard tickets cost 120 kr
- Student tickets cost 90 kr
- Child tickets cost 70 kr
- Use `java.time.LocalDateTime` for screening times


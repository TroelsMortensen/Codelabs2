# Exercise 24 - Event Ticketing System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class TicketingSystem {
        - systemName : String
        + addVenue(venue : Venue) void
        + addEvent(event : Event) void
        + searchEvents(query : String) ArrayList~Event~
        + getUpcomingEvents() ArrayList~Event~
    }
    
    class Venue {
        - venueId : int
        - name : String
        - address : String
        - capacity : int
        + Venue(venueId : int, name : String, address : String, capacity : int)
        + getVenueId() int
        + getName() String
        + getCapacity() int
    }
    
    class Event {
        - eventId : int
        - title : String
        - description : String
        - eventDate : LocalDateTime
        - duration : int
        - venue : Venue
        + Event(eventId : int, title : String, description : String, eventDate : LocalDateTime, duration : int, venue : Venue)
        + getEventId() int
        + getTitle() String
        + getEventDate() LocalDateTime
        + getAvailableTickets() int
        + getRevenue() double
    }
    
    class Concert {
        - artist : String
        - genre : String
        - isSoldOut : boolean
        + getRevenue() double
    }
    
    class SportsEvent {
        - sportType : String
        - homeTeam : String
        - awayTeam : String
        + getRevenue() double
    }
    
    class Theater {
        - playTitle : String
        - director : String
        - ageRating : int
        + getRevenue() double
    }
    
    class Customer {
        - customerId : int
        - name : String
        - email : String
        - phoneNumber : String
        - loyaltyPoints : int
        + Customer(customerId : int, name : String, email : String, phoneNumber : String)
        + getCustomerId() int
        + purchaseTicket(event : Event, ticketType : String) Ticket
        + addLoyaltyPoints(points : int) void
        + getLoyaltyPoints() int
    }
    
    class Ticket {
        - ticketId : int
        - seatNumber : String
        - purchaseDate : LocalDate
        - price : double
        - ticketType : String
        + Ticket(ticketId : int, seatNumber : String, purchaseDate : LocalDate, price : double, ticketType : String)
        + getTicketId() int
        + getPrice() double
        + cancel() boolean
    }
    
    TicketingSystem --> "*" Venue : venues
    TicketingSystem --> "*" Event : events
    Event --> "1" Venue : venue
    Event --> "*" Ticket : tickets
    Concert --|> Event
    SportsEvent --|> Event
    Theater --|> Event
    Customer --> "*" Ticket : purchasedTickets
```

## Notes:
- Ticket types: "Standard" (base price), "VIP" (3x base price), "Student" (0.5x base price), "Child" (0.3x base price)
- Concert base ticket price: 500 kr
- Sports event base ticket price: 300 kr
- Theater base ticket price: 400 kr
- Customers earn 1 loyalty point per 100 kr spent
- Events can be cancelled up to 48 hours before event date
- Use `java.time.LocalDateTime` for event dates and `java.time.LocalDate` for purchase dates


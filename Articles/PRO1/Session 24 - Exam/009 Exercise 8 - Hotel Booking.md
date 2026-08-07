# Exercise 8 - Hotel Booking System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Hotel {
        - name : String
        - starRating : int
        + Hotel(name : String, starRating : int)
        + getName() String
        + getStarRating() int
        + addRoom(room : Room) void
        + getAvailableRooms(checkIn : Date, checkOut : Date) ArrayList~Room~
    }
    
    class _Room_ {
        - roomNumber : int
        - pricePerNight : double
        + Room(roomNumber : int)
        + getRoomNumber() int
        + getPricePerNight()* double
        + isAvailable(checkIn : LocalDate, checkOut : LocalDate) boolean
    }
    
    class Booking {
        - bookingId : int
        - checkInDate : LocalDate
        - checkOutDate : LocalDate
        - guestName : String
        + Booking(bookingId : int, checkInDate : LocalDate, checkOutDate : LocalDate, guestName : String)
        + getBookingId() int
        + getCheckInDate() LocalDate
        + getCheckOutDate() LocalDate
        + getGuestName() String
        + calculateTotalPrice() double
        + getNumberOfNights() int
    }
    
    class StandardRoom {
        + StandardRoom(roomNumber : int)
        + getPricePerNight() double
    }
    
    class DeluxeRoom {
        - hasBalcony : boolean
        + DeluxeRoom(roomNumber : int, hasBalcony : boolean)
        + hasBalcony() boolean
        + getPricePerNight() double
    }
    
    class Suite {
        - numberOfRooms : int
        + Suite(roomNumber : int, numberOfRooms : int)
        + getNumberOfRooms() int
        + getPricePerNight() double
    }
    
    Hotel --> "*" _Room_ 
    Booking "*" <-- _Room_
    _Room_ <|-- StandardRoom
    _Room_ <|-- DeluxeRoom
    _Room_ <|-- Suite
```

## Notes:
- Standard rooms cost 500 kr per night
- Deluxe rooms cost 800 kr per night, or 900 kr if they have a balcony
- Suites cost 1200 kr per night plus 200 kr for each additional room beyond the first
- Use `java.time.LocalDate` for date handling
- Use `ChronoUnit.DAYS.between()` to calculate number of nights


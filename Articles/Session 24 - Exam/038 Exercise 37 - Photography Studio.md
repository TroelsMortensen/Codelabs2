# Exercise 37 - Photography Studio System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class PhotoStudio {
        - studioName : String
        - address : String
        - openingDate : LocalDate
        + addPhotographer(photographer : Photographer) void
        + bookSession(booking : SessionBooking) boolean
        + getAvailableSlots(date : LocalDate) ArrayList~TimeSlot~
        + getMonthlyRevenue() double
    }
    
    class Photographer {
        - photographerId : int
        - name : String
        - specialty : String
        - yearsExperience : int
        - portfolioUrl : String
        - rating : double
        + Photographer(photographerId : int, name : String, specialty : String, yearsExperience : int)
        + getPhotographerId() int
        + getName() String
        + getHourlyRate() double
        + canDo(sessionType : String) boolean
    }
    
    class SessionBooking {
        - bookingId : int
        - client : Client
        - photographer : Photographer
        - sessionDate : LocalDate
        - startTime : String
        - duration : int
        - location : String
        - status : String
        + SessionBooking(bookingId : int, client : Client, photographer : Photographer, sessionDate : LocalDate, startTime : String, duration : int)
        + getBookingId() int
        + getSessionCost() double
        + getStatus() String
    }
    
    class PortraitSession {
        - numberOfSubjects : int
        - indoorStudio : boolean
        + getSessionCost() double
    }
    
    class WeddingSession {
        - numberOfPhotographers : int
        - includesEngagement : boolean
        + getSessionCost() double
    }
    
    class ProductSession {
        - numberOfProducts : int
        - whiteBackground : boolean
        + getSessionCost() double
    }
    
    class EventSession {
        - eventType : String
        - expectedGuests : int
        + getSessionCost() double
    }
    
    class Client {
        - clientId : int
        - name : String
        - email : String
        - phoneNumber : String
        - isReturningClient : boolean
        + Client(clientId : int, name : String, email : String, phoneNumber : String)
        + getClientId() int
        + getName() String
        + getTotalBookings() int
    }
    
    class Package {
        - packageId : int
        - packageName : String
        - description : String
        - numberOfPhotos : int
        - editedPhotos : int
        - printIncluded : boolean
        - price : double
        + Package(packageId : int, packageName : String, description : String, numberOfPhotos : int, editedPhotos : int, price : double)
        + getPackageId() int
        + getPrice() double
    }
    
    class PhotoDelivery {
        - deliveryId : int
        - booking : SessionBooking
        - deliveryDate : LocalDate
        - format : String
        - numberOfPhotos : int
        - downloadLink : String
        + PhotoDelivery(deliveryId : int, booking : SessionBooking, deliveryDate : LocalDate, format : String, numberOfPhotos : int)
        + getDeliveryId() int
        + getFormat() String
    }
    
    PhotoStudio --> "*" Photographer : photographers
    PhotoStudio --> "*" SessionBooking : bookings
    PhotoStudio --> "*" Client : clients
    PhotoStudio --> "*" Package : packages
    PortraitSession --|> SessionBooking
    WeddingSession --|> SessionBooking
    ProductSession --|> SessionBooking
    EventSession --|> SessionBooking
    SessionBooking --> "1" Client : client
    SessionBooking --> "1" Photographer : photographer
    SessionBooking --> "1" Package : package
    SessionBooking --> "1" PhotoDelivery : delivery
```

## Notes:
- Portrait session: 1000 kr/hour + 200 kr per additional subject beyond first
- Wedding session: 5000 kr base + 3000 kr per additional photographer, +1000 kr if includes engagement shoot
- Product session: 800 kr/hour + 50 kr per product, +300 kr for studio setup if white background
- Event session: 1500 kr/hour + 10 kr per expected guest
- Photographer hourly rate: 500 kr base + 100 kr per year of experience
- Photographer specialty must match session type
- Returning client discount: 10%
- Booking status: "Pending", "Confirmed", "Completed", "Cancelled"
- Package tiers: "Basic" (50 photos, 10 edited, 1500 kr), "Standard" (100 photos, 30 edited, 3000 kr), "Premium" (200 photos, 50 edited, prints, 5000 kr)
- Delivery formats: "Digital Download", "USB Drive" (+100 kr), "Cloud Storage" (+50 kr/month)
- Photos delivered within 14 days of session
- Cancellation allowed up to 72 hours before session (50% refund)
- Use `java.time.LocalDate` for dates


# Exercise 32 - Coworking Space System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class CoworkingSpace {
        - spaceName : String
        - address : String
        - totalArea : double
        - openingHours : String
        + addWorkspace(workspace : Workspace) void
        + addMember(member : Member) void
        + bookWorkspace(booking : Booking) boolean
        + getAvailableWorkspaces(date : LocalDate) ArrayList~Workspace~
        + getMonthlyRevenue() double
    }
    
    class Workspace {
        - workspaceId : int
        - workspaceName : String
        - capacity : int
        - hasWhiteboard : boolean
        - hasProjector : boolean
        + Workspace(workspaceId : int, workspaceName : String, capacity : int)
        + getWorkspaceId() int
        + getWorkspaceName() String
        + getCapacity() int
        + getHourlyRate() double
        + isAvailable(date : LocalDate, startTime : String, endTime : String) boolean
    }
    
    class HotDesk {
        - deskNumber : int
        + getHourlyRate() double
    }
    
    class PrivateOffice {
        - hasWindow : boolean
        - squareMeters : double
        + getHourlyRate() double
    }
    
    class MeetingRoom {
        - hasVideoConference : boolean
        - maxCapacity : int
        + getHourlyRate() double
    }
    
    class PhoneBooth {
        - isSoundproof : boolean
        + getHourlyRate() double
    }
    
    class Member {
        - memberId : int
        - name : String
        - email : String
        - company : String
        - joinDate : LocalDate
        - membershipType : String
        + Member(memberId : int, name : String, email : String, company : String, joinDate : LocalDate, membershipType : String)
        + getMemberId() int
        + getName() String
        + getMonthlyFee() double
        + getBookingDiscount() double
    }
    
    class Booking {
        - bookingId : int
        - workspace : Workspace
        - member : Member
        - bookingDate : LocalDate
        - startTime : String
        - endTime : String
        - status : String
        + Booking(bookingId : int, workspace : Workspace, member : Member, bookingDate : LocalDate, startTime : String, endTime : String)
        + getBookingId() int
        + getDuration() int
        + calculateCost() double
        + cancel() void
    }
    
    class Amenity {
        - amenityName : String
        - description : String
        - additionalCost : double
        + Amenity(amenityName : String, description : String, additionalCost : double)
        + getAmenityName() String
        + getAdditionalCost() double
    }
    
    CoworkingSpace --> "*" Workspace : workspaces
    CoworkingSpace --> "*" Member : members
    CoworkingSpace --> "*" Booking : bookings
    CoworkingSpace --> "*" Amenity : amenities
    HotDesk --|> Workspace
    PrivateOffice --|> Workspace
    MeetingRoom --|> Workspace
    PhoneBooth --|> Workspace
    Booking --> "1" Workspace : workspace
    Booking --> "1" Member : member
    Booking --> "*" Amenity : requestedAmenities
```

## Notes:
- Hot desk: 50 kr/hour
- Private office: 150 kr/hour + 20 kr per square meter
- Meeting room: 200 kr/hour, +50 kr if video conference equipment
- Phone booth: 30 kr/hour
- Membership types: "Day Pass" (200 kr/day, no discount), "Part-Time" (1500 kr/month, 10% discount), "Full-Time" (3000 kr/month, 25% discount)
- Amenities: "Coffee" (20 kr), "Printing" (2 kr/page), "Locker" (100 kr/month), "Mail Handling" (150 kr/month)
- Booking status: "Confirmed", "Cancelled", "Completed", "No-Show"
- Cancellation allowed up to 24 hours before booking
- Duration calculated in hours (minimum 1 hour)
- Use `java.time.LocalDate` for dates


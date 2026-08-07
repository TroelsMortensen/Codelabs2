# Exercise 35 - Escape Room Business System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class EscapeRoomBusiness {
        - businessName : String
        - location : String
        - openingDate : LocalDate
        + addRoom(room : EscapeRoom) void
        + bookSession(booking : Booking) boolean
        + getAvailableSessions(date : LocalDate) ArrayList~Session~
        + getDailyRevenue(date : LocalDate) double
        + getTopRooms() ArrayList~EscapeRoom~
    }
    
    class EscapeRoom {
        - roomId : int
        - roomName : String
        - theme : String
        - difficulty : int
        - duration : int
        - minPlayers : int
        - maxPlayers : int
        - description : String
        + EscapeRoom(roomId : int, roomName : String, theme : String, difficulty : int, duration : int, minPlayers : int, maxPlayers : int)
        + getRoomId() int
        + getRoomName() String
        + getDifficulty() int
        + getSuccessRate() double
        + getAverageTime() int
    }
    
    class HorrorRoom {
        - scareLevel : int
        - minimumAge : int
        + getPrice() double
    }
    
    class MysteryRoom {
        - plotComplexity : int
        - clueCount : int
        + getPrice() double
    }
    
    class AdventureRoom {
        - physicalActivity : String
        - teamworkRequired : int
        + getPrice() double
    }
    
    class Session {
        - sessionId : int
        - room : EscapeRoom
        - sessionDate : LocalDate
        - sessionTime : String
        - isBooked : boolean
        + Session(sessionId : int, room : EscapeRoom, sessionDate : LocalDate, sessionTime : String)
        + getSessionId() int
        + isBooked() boolean
        + book() void
        + cancel() void
    }
    
    class Booking {
        - bookingId : int
        - session : Session
        - customerName : String
        - customerEmail : String
        - phoneNumber : String
        - numberOfPlayers : int
        - bookingDate : LocalDateTime
        - status : String
        + Booking(bookingId : int, session : Session, customerName : String, customerEmail : String, phoneNumber : String, numberOfPlayers : int, bookingDate : LocalDateTime)
        + getBookingId() int
        + getTotalCost() double
        + getStatus() String
        + confirm() void
        + cancel() void
    }
    
    class GameResult {
        - resultId : int
        - booking : Booking
        - completed : boolean
        - completionTime : int
        - hintsUsed : int
        - teamRating : int
        + GameResult(resultId : int, booking : Booking, completed : boolean, completionTime : int, hintsUsed : int)
        + getResultId() int
        + isCompleted() boolean
        + getScore() int
    }
    
    class GameMaster {
        - masterId : int
        - name : String
        - experience : int
        - specializedRooms : ArrayList~EscapeRoom~
        + GameMaster(masterId : int, name : String, experience : int)
        + getMasterId() int
        + getName() String
        + canOperate(room : EscapeRoom) boolean
    }
    
    EscapeRoomBusiness --> "*" EscapeRoom : rooms
    EscapeRoomBusiness --> "*" Session : sessions
    EscapeRoomBusiness --> "*" Booking : bookings
    EscapeRoomBusiness --> "*" GameMaster : staff
    HorrorRoom --|> EscapeRoom
    MysteryRoom --|> EscapeRoom
    AdventureRoom --|> EscapeRoom
    Session --> "1" EscapeRoom : room
    Booking --> "1" Session : session
    Booking --> "1" GameResult : result
    Session --> "1" GameMaster : gameMaster
```

## Notes:
- Difficulty scale: 1 (Easy) to 10 (Extreme)
- Horror rooms: 400 kr base + 50 kr per scare level, minimum age 16 for scare level > 5
- Mystery rooms: 350 kr base + 30 kr per difficulty level
- Adventure rooms: 450 kr base + 20 kr per player if physical activity is "High"
- Physical activity levels: "Low", "Medium", "High"
- Price per player, calculated based on room type
- Group discounts: 10% for 6+ players
- Weekend surcharge: +25%
- Booking status: "Pending", "Confirmed", "Completed", "Cancelled", "No-Show"
- Score calculation: (difficulty * 100) - (hintsUsed * 10) - (completionTime minutes)
- Success rate: (completed games / total games) * 100
- Game masters need 10+ games experience for difficulty 8+ rooms
- Cancellation allowed up to 48 hours before session
- Use `java.time.LocalDate` for session dates and `java.time.LocalDateTime` for booking timestamps


# Exercise 16 - Music Streaming System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class StreamingService {
        - serviceName : String
        + addUser(user : User) void
        + addSong(song : Song) void
        + searchSongs(query : String) ArrayList~Song~
        + getTotalRevenue() double
    }
    
    class User {
        - userId : int
        - username : String
        - email : String
        - registrationDate : LocalDate
        + User(userId : int, username : String, email : String, registrationDate : LocalDate)
        + getUserId() int
        + getUsername() String
        + createPlaylist(name : String) Playlist
    }
    
    class Subscription {
        - startDate : LocalDate
        - endDate : LocalDate
        - isActive : boolean
        + Subscription(startDate : LocalDate, endDate : LocalDate)
        + getMonthlyFee() double
        + isActive() boolean
        + hasAds() boolean
        + getMaxQuality() String
    }
    
    class FreeSubscription {
        + getMonthlyFee() double
        + hasAds() boolean
        + getMaxQuality() String
    }
    
    class PremiumSubscription {
        + getMonthlyFee() double
        + hasAds() boolean
        + getMaxQuality() String
    }
    
    class FamilySubscription {
        - numberOfUsers : int
        + getMonthlyFee() double
        + hasAds() boolean
        + getMaxQuality() String
    }
    
    class Song {
        - songId : int
        - title : String
        - artist : String
        - duration : int
        - genre : String
        + Song(songId : int, title : String, artist : String, duration : int, genre : String)
        + getSongId() int
        + getTitle() String
        + getArtist() String
        + getDuration() int
    }
    
    class Playlist {
        - playlistId : int
        - name : String
        - createdDate : LocalDate
        + Playlist(playlistId : int, name : String, createdDate : LocalDate)
        + addSong(song : Song) void
        + removeSong(songId : int) void
        + getTotalDuration() int
        + getSongs() ArrayList~Song~
    }
    
    StreamingService --> "*" User : users
    StreamingService --> "*" Song : songs
    User --> "1" Subscription : subscription
    User --> "*" Playlist : playlists
    Playlist --> "*" Song : songs
    FreeSubscription --|> Subscription
    PremiumSubscription --|> Subscription
    FamilySubscription --|> Subscription
```

## Notes:
- Free subscription costs 0 kr, has ads, max quality is 128 kbps
- Premium subscription costs 99 kr per month, no ads, max quality is 320 kbps
- Family subscription costs 149 kr per month for up to 6 users, no ads, max quality is 320 kbps
- Use `java.time.LocalDate` for date handling


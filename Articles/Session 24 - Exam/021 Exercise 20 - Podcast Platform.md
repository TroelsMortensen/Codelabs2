# Exercise 20 - Podcast Platform System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class PodcastPlatform {
        - platformName : String
        + addPodcast(podcast : Podcast) void
        + addUser(user : User) void
        + searchPodcasts(query : String) ArrayList~Podcast~
        + getTrendingPodcasts() ArrayList~Podcast~
    }
    
    class Podcast {
        - podcastId : int
        - title : String
        - creator : String
        - category : String
        - creationDate : LocalDate
        - totalListens : int
        + Podcast(podcastId : int, title : String, creator : String, category : String, creationDate : LocalDate)
        + getPodcastId() int
        + getTitle() String
        + addEpisode(episode : Episode) void
        + getEpisodes() ArrayList~Episode~
        + getTotalDuration() int
        + incrementListens() void
    }
    
    class _Episode_ {
        - episodeNumber : int
        - title : String
        - duration : int
        - releaseDate : LocalDate
        - description : String
        - listens : int
        + getEpisodeNumber() int
        + getTitle() String
        + getDuration() int
        + play() void
        + getListens() int
    }
    
    class AudioEpisode {
        - audioQuality : String
        - fileSize : double
        + getAudioQuality() String
    }
    
    class VideoEpisode {
        - resolution : String
        - hasSubtitles : boolean
        + getResolution() String
    }
    
    class User {
        - userId : int
        - username : String
        - email : String
        - registrationDate : LocalDate
        + getUserId() int
        + getUsername() String
        + subscribe(podcast : Podcast) void
        + getSubscriptions() ArrayList~Podcast~
    }
    
    PodcastPlatform --> "*" Podcast 
    PodcastPlatform --> "*" User 
    Podcast --> "*" _Episode_ 
    User --> "*" Podcast : subscriptions
    _Episode_ <|-- AudioEpisode
    _Episode_ <|-- VideoEpisode
```

## Notes:
- `Episode` is abstract (marked with italic)
- Audio episodes can have quality settings like "128kbps", "256kbps", "320kbps"
- Video episodes can have resolutions like "720p", "1080p", "4K"
- Trending podcasts are those with more than 10000 total listens
- Duration is measured in seconds
- Use `java.time.LocalDate` for dates


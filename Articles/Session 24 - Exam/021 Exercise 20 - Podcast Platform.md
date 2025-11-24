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
    
    class Episode {
        - episodeNumber : int
        - title : String
        - duration : int
        - releaseDate : LocalDate
        - description : String
        - listens : int
        + Episode(episodeNumber : int, title : String, duration : int, releaseDate : LocalDate, description : String)
        + getEpisodeNumber() int
        + getTitle() String
        + getDuration() int
        + play() void
        + getListens() int
    }
    
    class User {
        - userId : int
        - username : String
        - email : String
        - registrationDate : LocalDate
        + User(userId : int, username : String, email : String, registrationDate : LocalDate)
        + getUserId() int
        + getUsername() String
        + subscribe(podcast : Podcast) void
        + getSubscriptions() ArrayList~Podcast~
        + createPlaylist(name : String) Playlist
    }
    
    class Playlist {
        - playlistId : int
        - name : String
        - createdDate : LocalDate
        + Playlist(playlistId : int, name : String, createdDate : LocalDate)
        + addEpisode(episode : Episode) void
        + removeEpisode(episodeNumber : int) void
        + getEpisodes() ArrayList~Episode~
        + getTotalDuration() int
    }
    
    class ListeningHistory {
        - historyId : int
        - listenDate : LocalDateTime
        - episode : Episode
        - completionPercentage : int
        + ListeningHistory(historyId : int, episode : Episode, listenDate : LocalDateTime, completionPercentage : int)
        + getListenDate() LocalDateTime
        + getEpisode() Episode
        + isCompleted() boolean
    }
    
    PodcastPlatform --> "*" Podcast : podcasts
    PodcastPlatform --> "*" User : users
    Podcast --> "*" Episode : episodes
    User --> "*" Podcast : subscriptions
    User --> "*" Playlist : playlists
    User --> "*" ListeningHistory : history
    Playlist --> "*" Episode : episodes
```

## Notes:
- Episodes are considered "completed" if completion percentage >= 90%
- Trending podcasts are those with more than 10000 total listens
- Duration is measured in seconds
- Use `java.time.LocalDate` for dates and `java.time.LocalDateTime` for listening timestamps


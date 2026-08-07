# Exercise 22 - Art Gallery System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Gallery {
        - galleryName : String
        - location : String
        - openingDate : LocalDate
        + addArtwork(artwork : Artwork) void
        + removeArtwork(artworkId : int) void
        + getArtworksByArtist(artistName : String) ArrayList~Artwork~
        + organizeExhibition(exhibition : Exhibition) void
        + getTotalValue() double
    }
    
    class Artwork {
        - artworkId : int
        - title : String
        - artist : String
        - creationYear : int
        - value : double
        - isAvailable : boolean
        + Artwork(artworkId : int, title : String, artist : String, creationYear : int, value : double)
        + getArtworkId() int
        + getTitle() String
        + getArtist() String
        + getValue() double
        + setAvailable(available : boolean) void
        + getDescription() String
    }
    
    class Painting {
        - medium : String
        - width : double
        - height : double
        + getDescription() String
        + getArea() double
    }
    
    class Sculpture {
        - material : String
        - weight : double
        - dimensions : String
        + getDescription() String
    }
    
    class Photography {
        - cameraUsed : String
        - isLimitedEdition : boolean
        - editionNumber : int
        + getDescription() String
    }
    
    class Exhibition {
        - exhibitionId : int
        - title : String
        - theme : String
        - startDate : LocalDate
        - endDate : LocalDate
        - entryFee : double
        + Exhibition(exhibitionId : int, title : String, theme : String, startDate : LocalDate, endDate : LocalDate, entryFee : double)
        + getExhibitionId() int
        + addArtwork(artwork : Artwork) void
        + getArtworks() ArrayList~Artwork~
        + isActive() boolean
        + getDuration() int
    }
    
    class Visitor {
        - visitorId : int
        - name : String
        - email : String
        - membershipType : String
        + Visitor(visitorId : int, name : String, email : String, membershipType : String)
        + getVisitorId() int
        + getName() String
        + purchaseTicket(exhibition : Exhibition) Ticket
        + getDiscount() double
    }
    
    class Ticket {
        - ticketId : int
        - exhibition : Exhibition
        - purchaseDate : LocalDate
        - price : double
        + Ticket(ticketId : int, exhibition : Exhibition, purchaseDate : LocalDate, price : double)
        + getTicketId() int
        + getPrice() double
    }
    
    Gallery --> "*" Artwork : collection
    Gallery --> "*" Exhibition : exhibitions
    Painting --|> Artwork
    Sculpture --|> Artwork
    Photography --|> Artwork
    Exhibition --> "*" Artwork : featuredArtworks
    Visitor --> "*" Ticket : tickets
```

## Notes:
- Painting description includes: "Painting by [artist], [width]x[height] cm, [medium]"
- Sculpture description includes: "Sculpture by [artist], [material], [weight] kg"
- Photography description includes: "Photo by [artist], [camera]" + " (Limited Edition X/Y)" if limited
- Regular visitors pay full price, Members get 20% discount, Premium members get 50% discount
- Exhibition is active if current date is between startDate and endDate
- Use `java.time.LocalDate` for dates and `ChronoUnit.DAYS.between()` for duration


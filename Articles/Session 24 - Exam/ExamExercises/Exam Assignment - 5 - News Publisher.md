# Exercise 29 - News Publisher System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class NewsPublisher {
        - publisherName : String
        - foundedYear : int
        + addJournalist(journalist : Journalist) void
        + publishArticle(article : Article) void
        + getArticlesByCategory(category : String) ArrayList~Article~
        + getTrendingArticles() ArrayList~Article~
    }
    
    class Article {
        - articleId : int
        - headline : String
        - content : String
        - category : String
        - publishDate : LocalDateTime
        - views : int
        - likes : int
        + Article(articleId : int, headline : String, content : String, category : String, publishDate : LocalDateTime)
        + getArticleId() int
        + getHeadline() String
        + getWordCount() int
        + incrementViews() void
        + addLike() void
        + getEngagementScore() double
    }
    
    class NewsArticle {
        - location : String
        - isBreakingNews : boolean
        + getEngagementScore() double
    }
    
    class OpinionPiece {
        - author : String
        - stance : String
        + getEngagementScore() double
    }
    
    class Investigation {
        - researchDuration : int
        - sources : ArrayList~String~
        + getEngagementScore() double
    }
    
    class Journalist {
        - journalistId : int
        - name : String
        - specialization : String
        - experience : int
        + Journalist(journalistId : int, name : String, specialization : String, experience : int)
        + getJournalistId() int
        + getName() String
        + writeArticle(headline : String, content : String) Article
        + getSalary() double
    }
    
    class Editor {
        - editorId : int
        - name : String
        - department : String
        + Editor(editorId : int, name : String, department : String)
        + getEditorId() int
        + reviewArticle(article : Article) boolean
        + assignStory(journalist : Journalist, topic : String) void
    }
    
    class Subscription {
        - subscriptionId : int
        - subscriberName : String
        - subscriberEmail : String
        - startDate : LocalDate
        - endDate : LocalDate
        - tier : String
        + Subscription(subscriptionId : int, subscriberName : String, subscriberEmail : String, startDate : LocalDate, endDate : LocalDate, tier : String)
        + isActive() boolean
        + getMonthlyFee() double
        + hasAccessTo(article : Article) boolean
    }
    
    NewsPublisher --> "*" Article : articles
    NewsPublisher --> "*" Journalist : journalists
    NewsPublisher --> "*" Editor : editors
    NewsPublisher --> "*" Subscription : subscriptions
    Article --> "1" Journalist : author
    Article --> "1" Editor : editor
    NewsArticle --|> Article
    OpinionPiece --|> Article
    Investigation --|> Article
```

## Notes:
- Categories: "Politics", "Business", "Technology", "Sports", "Entertainment", "Science"
- Engagement score = (views * 1) + (likes * 5)
- Breaking news articles get 2x engagement multiplier
- Trending articles have engagement score > 1000
- Subscription tiers: "Free" (0 kr, access to 5 articles/month), "Basic" (99 kr, unlimited news), "Premium" (199 kr, all content including investigations)
- Journalist salary: 30,000 kr base + 1,000 kr per year of experience
- Investigations require minimum 5 years experience
- Use `java.time.LocalDateTime` for publish dates and `java.time.LocalDate` for subscriptions



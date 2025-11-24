# Exercise 11 - Gym Membership System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Gym {
        - gymName : String
        - location : String
        + addMember(member : Member) void
        + removeMember(memberId : int) void
        + getActiveMemberships() ArrayList~Membership~
        + getTotalMonthlyRevenue() double
    }
    
    class Member {
        - memberId : int
        - name : String
        - email : String
        - phoneNumber : String
        + Member(memberId : int, name : String, email : String, phoneNumber : String)
        + getMemberId() int
        + getName() String
        + getEmail() String
    }
    
    class Membership {
        - startDate : LocalDate
        - endDate : LocalDate
        - autoRenew : boolean
        + Membership(startDate : LocalDate, endDate : LocalDate, autoRenew : boolean)
        + isActive() boolean
        + getMonthlyFee() double
        + renew(months : int) void
    }
    
    class BasicMembership {
        + getMonthlyFee() double
    }
    
    class PremiumMembership {
        - personalTrainerSessions : int
        + getMonthlyFee() double
    }
    
    class FamilyMembership {
        - numberOfMembers : int
        + getMonthlyFee() double
    }
    
    Gym --> "*" Member : members
    Member --> "1" Membership : membership
    BasicMembership --|> Membership
    PremiumMembership --|> Membership
    FamilyMembership --|> Membership
```

## Notes:
- Basic membership costs 299 kr per month
- Premium membership costs 499 kr per month plus 50 kr for each personal trainer session included
- Family membership costs 199 kr per person per month
- Use `java.time.LocalDate` for date handling


# Exercise 11 - Gym Membership System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Gym {
        - gymName : String
        - location : String
        + Gym(gymName : String, location : String)
        + getGymName() String
        + getLocation() String
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
        + setEmail(email : String) void
        + getPhoneNumber() String
        + setPhoneNumber(phoneNumber : String) void
    }
    
    class _Membership_ {
        - startDate : LocalDate
        - endDate : LocalDate
        - autoRenew : boolean
        + Membership(startDate : LocalDate, endDate : LocalDate, autoRenew : boolean)
        + getStartDate() LocalDate
        + getEndDate() LocalDate
        + isAutoRenew() boolean
        + setAutoRenew(autoRenew : boolean) void
        + isActive() boolean
        + getMonthlyFee()* double
        + renew(months : int) void
    }
    
    class BasicMembership {
        - canJoinClasses : boolean
        + BasicMembership(startDate : LocalDate, endDate : LocalDate, autoRenew : boolean, canJoinClasses : boolean)
        + canJoinClasses() boolean
        + getMonthlyFee() double
    }
    
    class PremiumMembership {
        - personalTrainerSessions : int
        + PremiumMembership(startDate : LocalDate, endDate : LocalDate, autoRenew : boolean, personalTrainerSessions : int)
        + getPersonalTrainerSessions() int
        + getMonthlyFee() double
    }
    
    Gym --> "*" Member 
    Member --> _Membership_ 
    _Membership_ <|-- BasicMembership
    _Membership_ <|-- PremiumMembership
```

## Notes:
- `getMonthlyFee()` in `Membership` is abstract (marked with *)
- Basic membership costs 299 kr per month, or 50% more if `canJoinClasses` is true
- Premium membership costs 499 kr per month plus 50 kr for each personal trainer session included
- `isActive()` returns true if the current date is between startDate and endDate
- Use `java.time.LocalDate` for date handling


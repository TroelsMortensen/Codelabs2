# Exercise 43 - Mail System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class MailBox {
        + MailBox()
        + getNumberOfMails() int
        + createMail(mail : Mail) void
        + getBySubject(subject : String) ArrayList~Mail~
        + getSubjectsFromUser(user : String) ArrayList~String~
        + getAllFromAccounts() ArrayList~MailAccount~
        + getAllNonSendMails() ArrayList~Mail~
        + getAllHighPriorityMails() ArrayList~PriorityMail~
    }
    
    class Mail {
        - subject : String
        - content : String
        + Mail(subject : String, content : String, date : Date, from : MailAccount)
        + send(toAccount : MailAccount) void
        + hasBeenSend() boolean
        + getDate() Date
        + getSubject() String
        + getContent() String
        + getFromAccount() MailAccount
        + getToAccount() MailAccount
    }
    
    class PriorityMail {
        - highPriority : boolean
        + PriorityMail(highPriority : boolean, subject : String, content : String, date : Date, from : MailAccount)
        + isHighPriority() boolean
    }
    
    class MailAccount {
        - user : String
        - email : String
        + MailAccount(user : String, email : String)
        + getUser() String
        + getEmail() String
        + setEmail(email : String) void
        + isValidEmail(email : String) boolean
    }
    
    class Date {
        - day : int
        - month : int
        - year : int
        + Date(day : int, month : int, year : int)
        + set(day : int, month : int, year : int) void
        + getDay() int
        + getMonth() int
        + getYear() int
        + copy() Date
        + toString() String
        + equals(obj : Object) boolean
    }
    
    MailBox --> "0..*" Mail
    Mail --> "1" MailAccount : fromAccount
    Mail --> "1" MailAccount : toAccount
    Mail --> "1" Date
    Mail <|-- PriorityMail
```

## Notes:
- A mail is considered "sent" after the `send()` method has been called
- `hasBeenSend()` returns whether the mail has been sent (toAccount is not null)
- `getAllNonSendMails()` returns all mails where `hasBeenSend()` returns false
- `getAllHighPriorityMails()` returns only `PriorityMail` objects where `isHighPriority()` is true
- `isValidEmail()` should check that the email contains "@" and has at least one character before and after it
- `getBySubject()` returns all mails with a matching subject (case-sensitive)
- `getSubjectsFromUser()` returns all unique subjects from mails sent by the specified user
- `getAllFromAccounts()` returns all unique MailAccount objects that have sent at least one mail
- Use `java.time.LocalDate` for date handling in your implementation (the Date class in the diagram is a custom class for practice)
- Priority mails are only high priority if `highPriority` is true


# The three formats of use cases

Use cases come in three formats:

- **Brief**: Terse one-paragraph summary, usually of the main success scenario.
  - These can be used during early requirements analysis, to get a quick sense of subject and scope. May take only a few minutes to create. This may be the first next step after you have your user stories.
- **Casual**: Informal paragraph format. Multiple paragraphs that cover various scenarios. 
  - We may use these in a second iteration to add more detail to the use case.
- **Fully dressed**: All steps and variations are written in detail, and there are supporting sections, such as preconditions and success guarantees.
  - We may do these later, but before starting to implement a use case, it must be fully dressed.


I will provide examples of the two first. The last is saved for another learning path, as it requires a lot of explanation.

## Brief

> _A user logs in to their online banking portal, selects one of their accounts, and views their current balance and recent transactions._

## Casual

>   _A customer logs into the online banking system using their credentials. Once authenticated, they access a dashboard listing all their accounts. The user selects their primary checking account to review their balance and recent transactions._
>
> _In the same session, they decide to transfer money to their savings account. The system prompts for the amount and confirmation. After confirming, the transfer is processed immediately, and both account balances are updated._
>
> _If the user enters an invalid amount or exceeds their available balance, the system notifies them with an error message and allows them to correct the input. Finally, the user logs out safely when finished._
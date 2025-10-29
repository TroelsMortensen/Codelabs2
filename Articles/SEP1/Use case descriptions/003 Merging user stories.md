

### When does it include multiple user stories?

You will occasionally have user stories, which one way or another, are related to the same functionality. In this case, you should merge them into a single use case.

#### CRUD
You will often have user stories that are related to creating, viewing, updating, and deleting a resource. These can be merged into a single use case.

- As a player, I want to update my account.
- As a player, I want to view my account.
- As a player, I want to delete my account.
- As a player, I want to create a new account.


#### Sequential steps
You may sometimes have user stories that sort of fit together by being sub-sequences of a longer sequence of steps. These can be merged into a single use case.

1. As a shopper, I want to review my cart and totals so I can confirm what I’m buying.
2. As a shopper, I want to add/select a delivery address so I can receive the order.
3. As a shopper, I want to choose a shipping option so I can balance speed and price.
4. As a shopper, I want to enter card/MobilePay/PayPal so I can pay securely.
5. As a shopper, I want to use discount codes so I can reduce the price.

#### Variations

You may sometimes have user stories that are variations of the same user story.
1. As a librarian, I want to search for a book by title
2. As a librarian, I want to search for a book by author
3. As a librarian, I want to search for a book by ISBN
4. As a librarian, I want to search for a book by genre

#### Related user stories

You may sometimes have user stories that are variations of the same use case. These can be merged into a single use case.

Here is one that maybe requires a bit of domain knowledge about the miniature board game Bloodbowl. But they each are something, which an actor does when recording a match result. They could be combined into a single use case, called "Record Match Result".

S1: As a commissioner, I want to select a scheduled match so I record the right game.
S2: As a coach, I want to enter scores and key stats so player SPP is correct.
S3: As a commissioner, I want automatic standings updates so the table is current.
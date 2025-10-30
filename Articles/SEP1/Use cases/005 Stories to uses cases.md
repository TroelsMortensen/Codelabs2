# What is the relationship between user stories and use cases?

In your projects, you will define your features as user stories. And you will use use cases to further elaborate on the details of those features.

But it is not always one user story per use case. Sometimes you will have several user stories that are related to the same use case. 

So, as a next step after defining your user stories, you figure out which use cases you need to create. This is then shown in a use case diagram, see the learning path for that. Afterwards, you can flesh out your fully dressed use cases. See the learning path for that.

## Merging user stories into use cases

There are several guidelines to help you decide when to merge user stories into a single use case. But for all cases, those user stories must be clearly related.

I will below present some examples of when user stories can be merged into a single use case. But there are probably more cases.

It may also depend on how fine grained your user stories are. If you have very fine grained user stories, you may need to merge them into a single use case. If you have very coarse grained user stories, you may find it ends up with a one to one relationship between user stories and use cases.

### Sequential steps

You may sometimes have user stories that sort of fit together by being sub-sequences of a longer sequence of steps. These can be merged into a single use case.

1. As a shopper, I want to review my cart and totals so I can confirm what I’m buying.
2. As a shopper, I want to add/select a delivery address so I can receive the order.
3. As a shopper, I want to choose a shipping option so I can balance speed and price.
4. As a shopper, I want to enter card/MobilePay/PayPal so I can pay securely.
5. As a shopper, I want to use discount codes so I can reduce the price.

A use case for this could be "Checkout Cart".

### Variations

You may sometimes have user stories that are variations of the same user story.

1. As a librarian, I want to search for a book by title
2. As a librarian, I want to search for a book by author
3. As a librarian, I want to search for a book by ISBN
4. As a librarian, I want to search for a book by genre

A use case for this could be "Search Books".\
Alternatively, you should reconsider if these are really four different user stories, or just a single user story with a parameter.

### Related user stories

You may sometimes have user stories that are related to each other, but not sequential steps. However, they still feed into the same goal. Below are a few examples:

#### Blood Bowl

Here is one that maybe requires a bit of domain knowledge about the miniature board game "Blood Bowl". But they each are something, which an actor does when recording a match result. They could be combined into a single use case, called "Record Match Result".

S1: As a commissioner, I want to select a scheduled match so I record the right game.
S2: As a coach, I want to enter scores and key stats so player SPP is correct.
S3: As a commissioner, I want automatic standings updates so the table is current.

While perhaps not immediately obvious, to the untrained eye, these are all something that is done, when recording a match result, in Blood Bowl.

#### Uber driver system clone

Imagine a clone of the Uber driver system. Customers can request a ride, and drivers can accept or reject the request. 
You have the following user stories:

1. As a customer, I want to request a ride so I can get to my destination.
2. As a driver, I want to accept a ride request so I can earn money.
3. As a driver, before I accept a ride, I want to see the customer's location and destination, so I can decide if the ride is worth it.
4. As a driver, I want to see the customer's rating, so I can decide if the customer is worth driving for.
5. As a driver, I want to see the price of the ride before accepting, so I see if the ride is worth the time and effort.
6. As a driver, I want to see the customer's profile picture, so I can recognize them.

The last 5 user stories are pretty fine grained. And you may realize they don't make much sense on their own.

We could create two use cases:
1. Request a ride
2. Accept a ride
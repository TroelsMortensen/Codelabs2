# Buy stock tests

Now you start on your first unit tests, focusing on verifying the behavior of the "buy stock" use case.

I recommend a new file for these tests. Name it something meaningful, so it's clear what it is for. Put it in a good package.

You should remember the theories about:

* F.I.R.S.T.
* AAA
* Black-box and white-box testing
* Equivalence Partitioningi
* Boundary Value Analysis

I will list a number of test cases worth looking into. You should also spend a minute or two to consider if I missed some cases.

You should also keep in mind that each of the points below _may_ result in multiple unit test methods.

## Test cases

### 1. Zero & One (The "Simple" and Initial States)

* Verify that buying a single share (quantity = 1) of a valid, affordable stock succeeds.
* Verify that the purchase fails when the quantity is exactly 0.
* Verify that buying a stock not currently in the portfolio creates a brand-new StockPurchase record.
* Verify that buying a stock already in the portfolio updates the existing StockPurchase record instead of creating a new one.


### 2. Many & Boundaries (Range and Limit Testing)

* Verify that a very large quantity of shares can be bought if the portfolio balance is sufficient.
* Verify that the transaction succeeds when the totalCost is exactly equal to the `portfolio.getCurrentBalance()`.
* Verify that the transaction fails when the totalCost is exactly `0.01` _more_ than the `portfolio.getCurrentBalance()`.
* Verify the behavior when the transactionFee is 0 (free trading).


### 3. Interface & Exceptions (Error Handling and External Deps)

* Verify that the purchase fails when the quantity is a negative number.
* Verify that the purchase fails when the stock’s state is "Bankrupt".
* Verify that the purchase fails if the portfolio balance is less than the totalCost.
* Verify that the purchase fails if the symbol is null.
* Verify that the purchase fails if the symbol is empty string `""`.
* Verify that the purchase fails if the symbol is not found.

### 4. State & Behavior (Side Effects and Persistence)
* Verify that the portfolioo is updated with the new balance (retrieve it from mock DAO after the ACT phase).
* If you have the feature: Verify that a new Transaction record is created with the correct "BUY" type and calculated values.
* Verify that the StockPurchase quantity is incremented correctly (Existing + New) when updating an existing position.
* If you have the feature: Verify that the Transaction timestamp is recorded in the expected DATE_FORMATTER format.

### 5. AppConfig & Singleton State
* Verify that the method correctly pulls the transactionFee from AppConfig and doesn't use a hardcoded value.
* Verify the behavior if the transactionFee is returned as a negative value (an "Exceptional" case for ZOMBIES).

## Optional

It is sometimes also interesting to test that the correct collaborating objects are called, the correct number of times.

For example, the `UnitOfWork.commit()` should be called once. This can be verified. Or the `rollback()` method should be called once. The simple approach is to have the mock UoW contain a counter field variable, and increment it each time `commit()` or `rollback()` is called.

In the test's assert phase, you can verify that the counter is exactly 1. 

### 6. Lifecycle & Persistence (DAO Interaction)
* Verify that `stockPurchaseDAO.update` is called exactly once when a stock already exists in the portfolio.
* Verify that `stockPurchaseDAO.create` is called exactly once when the stock is new to the portfolio.

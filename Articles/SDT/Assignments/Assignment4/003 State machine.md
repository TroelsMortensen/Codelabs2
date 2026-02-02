# The State Machine

For the LiveStock, you must draw a State Machine diagram.

You must include _at least_ the following states:
- Steady: This will make minor changes to the price, equally likely to go up or down.
- Growing: This will make significant changes to the price, likely to go up.
- Declining: This will make significant changes to the price, likely to go down.
- Bankrupt: This will set the price to 0. Stock is bankrupt, and cannot be purchased. After a while, it will reset.

You must decide upon valid transitions between states. From which state can you transition to which other state?

Where will the state go after being bankrupt? 

Personally, I have included a Reset state. When Brankrupt, the state will go to Reset, just to reset the price, and then to the next state to be part of the game again.
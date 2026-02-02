# OPTIONAL CHALLENGE: Irregular updates

This part is optional. You may skip it.

## Parallel updates

Currently, all LiveStocks are updated at the same time, in one loop through the List.

You may want to update the LiveStocks in parallel, i.e. each LiveStock is updated in its own thread.

## Irregular updates

Currently, the update frequency is fixed. You may want to make it irregular, i.e. the update frequency is random, between a minimum and maximum value. Or, the update frequency plus/minus a random value. This may make for a slightly more interesting stock market.
# Strategies

Currently, your buying and selling use cases use a hardcoded fee for each transaction. We want to make this calculation modifiable, using the strategy design pattern.

You must rework the code, so this is possible.

You must create at least two strategy implementations. See examples below for inspiration:

* Flat fee: the same regardless of transaction size or value
* Percentage fee: a percentage of the total value of the transaction
* Volume based fee: based on quantity alone
* Value based fee: based solely on value of a single stock

You are also welcome to come up with your own variations.
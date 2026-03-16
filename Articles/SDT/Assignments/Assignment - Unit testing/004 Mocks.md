# Persistence Mocks

Your business logic live in the service classes. And the service classes depend on the persistence layer.

But, as taught, we do not want to access the file system. Instead we keep everything isolated in memory.

To achieve this, we will use mocks.

You must implement the relevant mock versions. You will at least need to mock the Unit of Work.\
Depending on your design, you may not need to mock the Data Access Objects (DAOs).

Make the mocks as simple as possible. No need for synchronization or anything fancy. Just quick and dirty.
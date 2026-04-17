# Package structure

Usually, when talking about the adapter design pattern, it is because you want to use class, you cannot modify. I am, however, providing you with source code, rather than a third party library, so we just have to pretend, you cannot modify the provided class.

> Do not modify the provided class

## New package

You will create a new package, which we will just pretend is actually a compiled third party library.

Create a new package, at the root of your project. Maybe that is directly under `src`, or maybe you have a root package like `stockgame`.
Either way, place a package here, on the same level as `persistence`, `business`, and `presentation`.

I have called my package `provided`. Just name yours something that indicates it is not your own code.





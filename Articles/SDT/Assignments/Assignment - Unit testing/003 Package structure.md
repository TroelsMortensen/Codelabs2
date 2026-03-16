# Unit test package structure

You have two options here:

1) Match the package structure of the main application, i.e. your `src` folder
2) Create a package per feature, i.e. a `buystocktests`, `sellstocktests`, etc

The first approach may be easier to navigate, because it's a mirror of the production code.

The second approach has the benefit of all tests for a specific feature being in one place. If you some day find a bug in a specific feature, you can run the tests of this particular package. 


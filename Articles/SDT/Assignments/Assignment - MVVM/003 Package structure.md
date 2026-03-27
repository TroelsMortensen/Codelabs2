# Package structure

Your presentation layer should probably be organized into several sub-packages.

I recommend something like this:

```console
🟦resources/
├── 📁fxml/
│   └── 📄...
└── 📁css/
    └── 📄...
📁src/
└── 📁stockgame/
    ├── 📁presentation/
    │   ├── 📁core/
    │   │   ├── 📄ViewManager.java
    │   │   ├── 📄ApplicationContext.java
    │   │   ├── 📄AcceptsStringArgument.java
    │   │   └── 📄ControllerFactory.java
    │   ├── 📁controllers/
    │   │   ├── 📄StockMarketController.java
    │   │   ├── 📄PortfolioController.java
    │   │   └── 📄MainMenuController.java
    │   └── 📁viewmodels/
    │       ├── 📄StockMarketViewModel.java
    │       ├── 📄PortfolioViewModel.java
    │       └── 📄MainMenuViewModel.java
```

An alternative approach, instead of separating controllers and viewmodels, is to create a package for each view, and put the controller and viewmodel in the same package. This groups things, which belong together, together. This is a matter of taste.

It could look like this:

```console
🟦resources/
├── 📁fxml/
│   └── 📄...
└── 📁css/
    └── 📄...
📁src/
└── 📁stockgame/
    ├── 📁presentation/
    │   ├── 📁core/
    │   │   ├── 📄ViewManager.java
    │   │   ├── 📄ApplicationContext.java
    │   │   ├── 📄AcceptsStringArgument.java
    │   │   └── 📄ControllerFactory.java
    │   ├── 📁views/
    │   │   ├── 📁mainmenu/
    │   │   │       ├── 📄MainMenuController.java
    │   │   │       └── 📄MainMenuViewModel.java
    │   │   ├── 📁stockmarket/
    │   │   │       ├── 📄StockMarketController.java
    │   │   │       └── 📄StockMarketViewModel.java
    │   │   └── 📁portfolio/
    │   │           ├── 📄PortfolioController.java
    │   │           └── 📄PortfolioViewModel.java
```

This makes approach blurs the two layers of View and ViewModel, but may be easier to navigate.
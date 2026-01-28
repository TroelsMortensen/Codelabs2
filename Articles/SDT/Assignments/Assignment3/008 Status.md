# Status

After completing this assignment, your project structure should look like:

```console
📁 yourname.stockgame
├── 📁 business
├── 📁 dtos
├── 📁 entities
│   ├── 📄 Stock.java
│   ├── 📄 Portfolio.java
│   ├── 📄 StockPurchase.java
│   ├── 📄 Transaction.java
│   ├── 📄 StockPriceHistory.java
│   └── 📄 PortfolioValueHistory.java
├── 📁 persistence
│   ├── 📁 interfaces
│   │   ├── 📄 PortfolioDAO.java
│   │   ├── 📄 StockDAO.java
│   │   ├── 📄 StockPriceHistoryDAO.java
│   │   ├── 📄 StockPurchaseDAO.java
│   │   ├── 📄 TransactionDAO.java
│   │   └── 📄 UnitOfWork.java
│   └── 📁 fileimplementation
│       ├── 📄 FileUnitOfWork.java
│       ├── 📄 PortfolioFileDAO.java
│       ├── 📄 StockFileDAO.java
│       ├── 📄 StockPriceHistoryFileDAO.java
│       ├── 📄 StockPurchaseFileDAO.java
│       └── 📄 TransactionFileDAO.java
├── 📁 presentation
└── 📁 shared
    ├── 📁 configuration
    │   └── 📄 AppConfig.java
    └── 📁 logging
        ├── 📄 Logger.java
        ├── 📄 LogOutput.java
        └── 📄 ConsoleLogOutput.java
```
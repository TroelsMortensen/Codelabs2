# Exercise 5 - Restaurant Order System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Customer {
        - phoneNumber : String
    }
    
    class Order {
        - id : int
        - lastOrderId : int$
        - orderPlaced : LocalDateTime
        + Order()
        + getId() int
        + getOrderPlaced() LocalDateTime
        + totalPrice() double
    }
    
    class MenuItem {
        - name : String
        - price : double
        + getPrice() double
    }
    
    class HomeDelivery {
        - address : String
        - distanceToRestaurant : double
        - deliveryWanted : LocalDateTime
        + totalPrice() double
    }
    
    class TableBooking {
        - SERVICE_FEE : double = 10.0
        - tableWanted : LocalDateTime
        + totalPrice() double
    }
    
    Customer --> "*" Order
    Order --> "*" MenuItem
    Order <|-- HomeDelivery
    Order <|-- TableBooking
```

## Notes:
- When a new order is created its ID field should be the value of lastOrderId plus one, and then that value should be stored as lastOrderId
- The added delivery fee is based on distance to the restaurant:
  - 0-5 km: 5
  - 5-10 km: 12
  - 10+ km: 25
- Use `java.time.LocalDateTime` for date and time handling


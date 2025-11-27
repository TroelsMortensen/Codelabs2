# Exercise 5 - Restaurant Order System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Customer {
        - phoneNumber : String
        + Customer(phoneNumber : String)
        + getPhoneNumber() String
        + setPhoneNumber(phoneNumber : String) void
    }
    
    class Order {
        - id : int
        - lastOrderId : int$
        - orderPlaced : LocalDateTime
        + Order()
        + getId() int
        + getOrderPlaced() LocalDateTime
        + totalPrice()* double
    }
    
    class MenuItem {
        - name : String
        - price : double
        + MenuItem(name : String, price : double)
        + getName() String
        + getPrice() double
        + setPrice(price : double) void
    }
    
    class HomeDelivery {
        - address : String
        - distanceToRestaurant : double
        - deliveryWanted : LocalDateTime
        + HomeDelivery(address : String, distanceToRestaurant : double, deliveryWanted : LocalDateTime)
        + getAddress() String
        + getDistanceToRestaurant() double
        + getDeliveryWanted() LocalDateTime
        + totalPrice() double
    }
    
    class TableBooking {
        - SERVICE_FEE : double = 10.0
        - tableWanted : LocalDateTime
        + TableBooking(tableWanted : LocalDateTime)
        + getTableWanted() LocalDateTime
        + totalPrice() double
    }
    
    Customer --> "*" Order
    Order --> "*" MenuItem
    Order <|-- HomeDelivery
    Order <|-- TableBooking
```

## Notes:
- When a new order is created its ID field should be the value of lastOrderId plus one, and then that value should be stored as lastOrderId
- `totalPrice()` in Order is abstract (marked with *)
- The added delivery fee is based on distance to the restaurant:
  - 0-5 km: 5 kr
  - 5-10 km: 12 kr
  - 10+ km: 25 kr
- `TableBooking.totalPrice()` = sum of menu items + SERVICE_FEE (10 kr)
- `HomeDelivery.totalPrice()` = sum of menu items + delivery fee (based on distance)
- Use `java.time.LocalDateTime` for date and time handling


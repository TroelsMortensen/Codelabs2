# Exercise 34 - Food Delivery Platform System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class DeliveryPlatform {
        - platformName : String
        - serviceArea : String
        + addRestaurant(restaurant : Restaurant) void
        + addDriver(driver : Driver) void
        + placeOrder(order : Order) void
        + assignDriver(order : Order) Driver
        + getActiveOrders() ArrayList~Order~
    }
    
    class Restaurant {
        - restaurantId : int
        - name : String
        - cuisine : String
        - address : String
        - rating : double
        - isOpen : boolean
        + Restaurant(restaurantId : int, name : String, cuisine : String, address : String)
        + getRestaurantId() int
        + getName() String
        + addMenuItem(item : MenuItem) void
        + getMenu() ArrayList~MenuItem~
        + getRating() double
    }
    
    class MenuItem {
        - itemId : int
        - name : String
        - description : String
        - basePrice : double
        - category : String
        - isAvailable : boolean
        - preparationTime : int
        + MenuItem(itemId : int, name : String, description : String, basePrice : double, category : String, preparationTime : int)
        + getItemId() int
        + getName() String
        + getBasePrice() double
        + getPreparationTime() int
    }
    
    class Meal {
        - calories : int
        - isVegetarian : boolean
        + getBasePrice() double
    }
    
    class Beverage {
        - size : String
        - isAlcoholic : boolean
        + getBasePrice() double
    }
    
    class Dessert {
        - servingSize : String
        + getBasePrice() double
    }
    
    class Customer {
        - customerId : int
        - name : String
        - phoneNumber : String
        - address : String
        - email : String
        + Customer(customerId : int, name : String, phoneNumber : String, address : String, email : String)
        + getCustomerId() int
        + getName() String
        + placeOrder(restaurant : Restaurant) Order
    }
    
    class Order {
        - orderId : int
        - customer : Customer
        - restaurant : Restaurant
        - orderTime : LocalDateTime
        - deliveryAddress : String
        - specialInstructions : String
        - status : String
        + Order(orderId : int, customer : Customer, restaurant : Restaurant, orderTime : LocalDateTime, deliveryAddress : String)
        + getOrderId() int
        + addItem(item : MenuItem, quantity : int) void
        + getSubtotal() double
        + getDeliveryFee() double
        + getTotalCost() double
        + getStatus() String
        + setStatus(status : String) void
    }
    
    class Driver {
        - driverId : int
        - name : String
        - vehicleType : String
        - phoneNumber : String
        - rating : double
        - isAvailable : boolean
        + Driver(driverId : int, name : String, vehicleType : String, phoneNumber : String)
        + getDriverId() int
        + getName() String
        + acceptOrder(order : Order) void
        + completeDelivery(order : Order) void
        + getRating() double
    }
    
    class Review {
        - reviewId : int
        - rating : int
        - comment : String
        - reviewDate : LocalDate
        - reviewType : String
        + Review(reviewId : int, rating : int, comment : String, reviewDate : LocalDate, reviewType : String)
        + getReviewId() int
        + getRating() int
    }
    
    DeliveryPlatform --> "*" Restaurant : restaurants
    DeliveryPlatform --> "*" Driver : drivers
    DeliveryPlatform --> "*" Order : orders
    Restaurant --> "*" MenuItem : menu
    Meal --|> MenuItem
    Beverage --|> MenuItem
    Dessert --|> MenuItem
    Order --> "1" Customer : customer
    Order --> "1" Restaurant : restaurant
    Order --> "*" MenuItem : items
    Order --> "1" Driver : driver
    Customer --> "*" Review : reviews
    Restaurant --> "*" Review : reviews
    Driver --> "*" Review : reviews
```

## Notes:
- Menu categories: "Appetizer", "Main Course", "Side Dish", "Dessert", "Beverage"
- Beverage sizes: "Small" (base price), "Medium" (+10 kr), "Large" (+20 kr)
- Delivery fee: 25 kr base + 5 kr per km from restaurant
- Platform fee: 15% of subtotal
- Order status: "Placed", "Accepted", "Preparing", "Ready", "Out for Delivery", "Delivered", "Cancelled"
- Minimum order: 50 kr
- Free delivery for orders > 200 kr
- Review types: "Restaurant", "Driver", "Food Quality"
- Rating scale: 1-5 stars
- Driver vehicle types: "Bicycle", "Scooter", "Car"
- Estimated delivery time: preparation time + (distance / speed)
  - Bicycle: 15 km/h
  - Scooter: 30 km/h
  - Car: 40 km/h
- Use `java.time.LocalDateTime` for order times and `java.time.LocalDate` for review dates


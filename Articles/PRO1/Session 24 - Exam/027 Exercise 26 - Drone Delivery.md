# Exercise 26 - Drone Delivery System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class DeliveryCompany {
        - companyName : String
        - baseLocation : String
        + addDrone(drone : Drone) void
        + registerDelivery(delivery : Delivery) void
        + getAvailableDrones() ArrayList~Drone~
        + getTotalDeliveries() int
        + getRevenueForDate(date : LocalDate) double
    }
    
    class Drone {
        - droneId : String
        - model : String
        - maxPayload : double
        - maxRange : double
        - batteryCapacity : int
        - currentBattery : int
        - status : String
        + Drone(droneId : String, model : String, maxPayload : double, maxRange : double, batteryCapacity : int)
        + getDroneId() String
        + getStatus() String
        + setStatus(status : String) void
        + isAvailable() boolean
        + canDeliver(weight : double, distance : double) boolean
        + charge() void
    }
    
    class Delivery {
        - deliveryId : int
        - pickupAddress : String
        - deliveryAddress : String
        - distance : double
        - packageWeight : double
        - orderTime : LocalDateTime
        - deliveryTime : LocalDateTime
        - status : String
        + Delivery(deliveryId : int, pickupAddress : String, deliveryAddress : String, distance : double, packageWeight : double, orderTime : LocalDateTime)
        + getDeliveryId() int
        + getStatus() String
        + setStatus(status : String) void
        + calculateCost() double
        + getDeliveryDuration() int
    }
    
    class StandardDelivery {
        - priority : String
        + calculateCost() double
    }
    
    class ExpressDelivery {
        - guaranteedTime : int
        + calculateCost() double
    }
    
    class ScheduledDelivery {
        - scheduledDate : LocalDate
        - timeWindow : String
        + calculateCost() double
    }
    
    class Customer {
        - customerId : int
        - name : String
        - address : String
        - phoneNumber : String
        - membershipLevel : String
        + Customer(customerId : int, name : String, address : String, phoneNumber : String, membershipLevel : String)
        + getCustomerId() int
        + placeOrder(delivery : Delivery) void
        + getDiscount() double
    }
    
    class Package {
        - packageId : int
        - contents : String
        - weight : double
        - dimensions : String
        - fragile : boolean
        + Package(packageId : int, contents : String, weight : double, dimensions : String, fragile : boolean)
        + getPackageId() int
        + getWeight() double
        + isFragile() boolean
    }
    
    DeliveryCompany --> "*" Drone : fleet
    DeliveryCompany --> "*" Delivery : deliveries
    Delivery --> "1" Drone : assignedDrone
    Delivery --> "1" Package : package
    StandardDelivery --|> Delivery
    ExpressDelivery --|> Delivery
    ScheduledDelivery --|> Delivery
    Customer --> "*" Delivery : orders
```

## Notes:
- Drone status: "Available", "In Flight", "Charging", "Maintenance"
- Delivery status: "Pending", "In Transit", "Delivered", "Cancelled"
- Standard delivery cost: 50 kr base + 5 kr per km
- Express delivery cost: 150 kr base + 10 kr per km
- Scheduled delivery cost: 80 kr base + 7 kr per km
- Fragile packages add 30 kr surcharge
- Membership levels: "Basic" (no discount), "Premium" (10% discount), "VIP" (25% discount)
- Drone battery drains 1% per km traveled
- Delivery duration estimated at 2 minutes per km
- Use `java.time.LocalDateTime` for timestamps and `java.time.LocalDate` for scheduled dates


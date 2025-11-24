# Exercise 36 - Plant Nursery System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Nursery {
        - nurseryName : String
        - location : String
        - established : LocalDate
        + addPlant(plant : Plant) void
        + addCustomer(customer : Customer) void
        + processSale(sale : Sale) void
        + getPlantsByType(type : String) ArrayList~Plant~
        + getLowStockPlants() ArrayList~Plant~
    }
    
    class Plant {
        - plantId : int
        - name : String
        - scientificName : String
        - stockQuantity : int
        - pricePerUnit : double
        - minTemperature : int
        - maxTemperature : int
        + Plant(plantId : int, name : String, scientificName : String, stockQuantity : int, pricePerUnit : double)
        + getPlantId() int
        + getName() String
        + getStockQuantity() int
        + getCareLevel() String
        + getWateringSchedule() String
    }
    
    class IndoorPlant {
        - lightRequirement : String
        - humidity : int
        + getCareLevel() String
        + getWateringSchedule() String
    }
    
    class OutdoorPlant {
        - sunExposure : String
        - hardiness : int
        + getCareLevel() String
        + getWateringSchedule() String
    }
    
    class Succulent {
        - droughtTolerant : boolean
        + getCareLevel() String
        + getWateringSchedule() String
    }
    
    class Herb {
        - culinaryUse : String
        - medicinalUse : String
        + getCareLevel() String
        + getWateringSchedule() String
    }
    
    class Customer {
        - customerId : int
        - name : String
        - email : String
        - phoneNumber : String
        - loyaltyPoints : int
        + Customer(customerId : int, name : String, email : String, phoneNumber : String)
        + getCustomerId() int
        + getName() String
        + addLoyaltyPoints(points : int) void
        + getDiscount() double
    }
    
    class Sale {
        - saleId : int
        - customer : Customer
        - saleDate : LocalDate
        - paymentMethod : String
        + Sale(saleId : int, customer : Customer, saleDate : LocalDate, paymentMethod : String)
        + getSaleId() int
        + addItem(plant : Plant, quantity : int) void
        + getSubtotal() double
        + getDiscount() double
        + getTotalCost() double
    }
    
    class CareGuide {
        - guideId : int
        - plant : Plant
        - wateringFrequency : String
        - fertilizingSchedule : String
        - pruningAdvice : String
        - commonProblems : String
        + CareGuide(guideId : int, plant : Plant, wateringFrequency : String, fertilizingSchedule : String)
        + getGuideId() int
        + getWateringFrequency() String
    }
    
    Nursery --> "*" Plant : inventory
    Nursery --> "*" Customer : customers
    Nursery --> "*" Sale : sales
    IndoorPlant --|> Plant
    OutdoorPlant --|> Plant
    Succulent --|> Plant
    Herb --|> Plant
    Sale --> "1" Customer : customer
    Sale --> "*" Plant : items
    Plant --> "1" CareGuide : careGuide
```

## Notes:
- Light requirements: "Low", "Medium", "Bright Indirect", "Direct Sun"
- Sun exposure: "Full Sun", "Partial Shade", "Full Shade"
- Watering schedules: "Daily", "Every 2-3 days", "Weekly", "Every 2 weeks", "Monthly"
- Care levels: "Easy" (succulents, hardy plants), "Moderate" (most plants), "Difficult" (orchids, carnivorous plants)
- Hardiness zones: 1-13 (lower = more cold-hardy)
- Indoor plants +20% markup if low light requirement
- Outdoor plants -10% discount if hardiness < 6
- Herbs +15% markup if both culinary and medicinal use
- Succulents base price (easy care)
- Low stock warning: < 10 units
- Loyalty points: 1 point per 10 kr spent
- Customer discounts: 100+ points = 5%, 500+ points = 10%, 1000+ points = 15%
- Payment methods: "Cash", "Card", "Mobile Pay"
- Use `java.time.LocalDate` for dates


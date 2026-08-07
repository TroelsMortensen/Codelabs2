# Exercise 30 - Parking Management System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class ParkingFacility {
        - facilityId : int
        - name : String
        - address : String
        - totalSpaces : int
        + ParkingFacility(facilityId : int, name : String, address : String, totalSpaces : int)
        + getFacilityId() int
        + addParkingSpace(space : ParkingSpace) void
        + getAvailableSpaces() ArrayList~ParkingSpace~
        + checkIn(vehicle : Vehicle) ParkingTicket
        + checkOut(ticket : ParkingTicket) double
        + getOccupancyRate() double
    }
    
    class ParkingSpace {
        - spaceId : int
        - spaceNumber : String
        - floor : int
        - isOccupied : boolean
        + ParkingSpace(spaceId : int, spaceNumber : String, floor : int)
        + getSpaceId() int
        + getSpaceNumber() String
        + isOccupied() boolean
        + occupy() void
        + vacate() void
        + getHourlyRate() double
    }
    
    class StandardSpace {
        + getHourlyRate() double
    }
    
    class CompactSpace {
        + getHourlyRate() double
    }
    
    class DisabledSpace {
        + getHourlyRate() double
    }
    
    class EVChargingSpace {
        - chargingSpeed : String
        - powerOutput : int
        + getHourlyRate() double
        + getChargingFee() double
    }
    
    class Vehicle {
        - licensePlate : String
        - vehicleType : String
        - color : String
        - ownerName : String
        + Vehicle(licensePlate : String, vehicleType : String, color : String, ownerName : String)
        + getLicensePlate() String
        + getVehicleType() String
    }
    
    class ParkingTicket {
        - ticketId : int
        - vehicle : Vehicle
        - space : ParkingSpace
        - entryTime : LocalDateTime
        - exitTime : LocalDateTime
        - isPaid : boolean
        + ParkingTicket(ticketId : int, vehicle : Vehicle, space : ParkingSpace, entryTime : LocalDateTime)
        + getTicketId() int
        + setExitTime(exitTime : LocalDateTime) void
        + calculateFee() double
        + getDuration() int
        + markAsPaid() void
    }
    
    class Subscription {
        - subscriptionId : int
        - vehicle : Vehicle
        - startDate : LocalDate
        - endDate : LocalDate
        - subscriptionType : String
        + Subscription(subscriptionId : int, vehicle : Vehicle, startDate : LocalDate, endDate : LocalDate, subscriptionType : String)
        + isValid() boolean
        + getMonthlyFee() double
    }
    
    ParkingFacility --> "*" ParkingSpace : spaces
    ParkingFacility --> "*" ParkingTicket : tickets
    ParkingFacility --> "*" Subscription : subscriptions
    StandardSpace --|> ParkingSpace
    CompactSpace --|> ParkingSpace
    DisabledSpace --|> ParkingSpace
    EVChargingSpace --|> ParkingSpace
    ParkingTicket --> "1" Vehicle : vehicle
    ParkingTicket --> "1" ParkingSpace : space
    Subscription --> "1" Vehicle : vehicle
```

## Notes:
- Hourly rates: Standard: 20 kr, Compact: 15 kr, Disabled: 10 kr, EV Charging: 25 kr
- EV charging fee: 5 kr per kWh (Fast: 50 kW, Rapid: 150 kW, Ultra-rapid: 350 kW)
- First 15 minutes are free
- Maximum daily rate: 200 kr
- Vehicle types: "Car", "Motorcycle", "Bicycle", "Truck"
- Motorcycles and bicycles get 50% discount
- Subscription types: "Monthly" (1000 kr), "Quarterly" (2700 kr, 10% discount), "Annual" (10,800 kr, 20% discount)
- Subscription holders park for free
- Occupancy rate = (occupied spaces / total spaces) * 100
- Duration calculated in minutes
- Use `java.time.LocalDateTime` for entry/exit times and `java.time.LocalDate` for subscriptions


# Exercise 39 - Bike Sharing System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class BikeShareSystem {
        - systemName : String
        - cityName : String
        - operatingSince : LocalDate
        + addStation(station : Station) void
        + addBike(bike : Bike) void
        + registerUser(user : User) void
        + startRide(ride : Ride) void
        + endRide(ride : Ride) void
        + getAvailableBikes() ArrayList~Bike~
    }
    
    class Station {
        - stationId : int
        - stationName : String
        - address : String
        - latitude : double
        - longitude : double
        - capacity : int
        + Station(stationId : int, stationName : String, address : String, latitude : double, longitude : double, capacity : int)
        + getStationId() int
        + getStationName() String
        + getAvailableDocks() int
        + getAvailableBikes() int
        + dockBike(bike : Bike) boolean
        + undockBike(bike : Bike) boolean
    }
    
    class Bike {
        - bikeId : int
        - bikeType : String
        - status : String
        - batteryLevel : int
        - lastServiceDate : LocalDate
        - totalDistance : double
        + Bike(bikeId : int, bikeType : String, lastServiceDate : LocalDate)
        + getBikeId() int
        + getStatus() String
        + needsMaintenance() boolean
        + getPricePerMinute() double
    }
    
    class RegularBike {
        - gearCount : int
        + getPricePerMinute() double
    }
    
    class ElectricBike {
        - maxSpeed : int
        - range : int
        + getPricePerMinute() double
    }
    
    class CargoBike {
        - cargoCapacity : double
        - hasElectricAssist : boolean
        + getPricePerMinute() double
    }
    
    class User {
        - userId : int
        - name : String
        - email : String
        - phoneNumber : String
        - registrationDate : LocalDate
        - membershipType : String
        + User(userId : int, name : String, email : String, phoneNumber : String, registrationDate : LocalDate, membershipType : String)
        + getUserId() int
        + getName() String
        + getDiscount() double
        + getTotalRides() int
    }
    
    class Ride {
        - rideId : int
        - user : User
        - bike : Bike
        - startStation : Station
        - endStation : Station
        - startTime : LocalDateTime
        - endTime : LocalDateTime
        - distance : double
        + Ride(rideId : int, user : User, bike : Bike, startStation : Station, startTime : LocalDateTime)
        + getRideId() int
        + endRide(endStation : Station, endTime : LocalDateTime) void
        + getDuration() int
        + calculateCost() double
    }
    
    class Maintenance {
        - maintenanceId : int
        - bike : Bike
        - maintenanceDate : LocalDate
        - maintenanceType : String
        - technician : String
        - cost : double
        - notes : String
        + Maintenance(maintenanceId : int, bike : Bike, maintenanceDate : LocalDate, maintenanceType : String, technician : String, cost : double)
        + getMaintenanceId() int
        + getMaintenanceType() String
    }
    
    BikeShareSystem --> "*" Station : stations
    BikeShareSystem --> "*" Bike : fleet
    BikeShareSystem --> "*" User : users
    BikeShareSystem --> "*" Ride : rides
    Station --> "*" Bike : dockedBikes
    RegularBike --|> Bike
    ElectricBike --|> Bike
    CargoBike --|> Bike
    Ride --> "1" User : user
    Ride --> "1" Bike : bike
    Ride --> "1" Station : startStation
    Ride --> "1" Station : endStation
    Bike --> "*" Maintenance : maintenanceHistory
```

## Notes:
- Regular bike: 2 kr/minute
- Electric bike: 3 kr/minute, needs charging when battery < 20%
- Cargo bike: 4 kr/minute, 5 kr/minute if electric assist
- Bike status: "Available", "In Use", "Maintenance", "Charging", "Damaged"
- Membership types: "Pay Per Ride" (no discount), "Monthly" (1000 kr/month, 20% discount), "Annual" (10000 kr/year, 30% discount)
- First 5 minutes free for all rides
- Distance calculated from GPS coordinates
- Bikes need maintenance after 1000 km or 90 days since last service
- Maintenance types: "Regular Service", "Repair", "Battery Replacement", "Tire Change"
- Station is full when available docks = 0
- Station is empty when available bikes = 0
- Peak hour surcharge (7-9 AM, 4-6 PM): +50%
- Night discount (10 PM - 6 AM): -25%
- Duration calculated in minutes
- Use `java.time.LocalDateTime` for ride times and `java.time.LocalDate` for dates


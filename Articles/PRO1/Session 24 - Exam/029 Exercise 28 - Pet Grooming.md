# Exercise 28 - Pet Grooming Salon System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class GroomingSalon {
        - salonName : String
        - address : String
        - openingTime : String
        - closingTime : String
        + addPet(pet : Pet) void
        + bookAppointment(appointment : Appointment) boolean
        + getAppointmentsForDate(date : LocalDate) ArrayList~Appointment~
        + getDailyRevenue(date : LocalDate) double
    }
    
    class Pet {
        - petId : int
        - name : String
        - breed : String
        - age : int
        - owner : Owner
        + Pet(petId : int, name : String, breed : String, age : int, owner : Owner)
        + getPetId() int
        + getName() String
        + getBreed() String
        + getSpecialNeeds() String
    }
    
    class Dog {
        - size : String
        - coatType : String
        + getSpecialNeeds() String
        + getGroomingDuration() int
    }
    
    class Cat {
        - isLongHaired : boolean
        - temperament : String
        + getSpecialNeeds() String
        + getGroomingDuration() int
    }
    
    class ExoticPet {
        - species : String
        - requiresSpecialist : boolean
        + getSpecialNeeds() String
        + getGroomingDuration() int
    }
    
    class Owner {
        - ownerId : int
        - name : String
        - phoneNumber : String
        - email : String
        - loyaltyPoints : int
        + Owner(ownerId : int, name : String, phoneNumber : String, email : String)
        + getOwnerId() int
        + getName() String
        + addLoyaltyPoints(points : int) void
        + getDiscount() double
    }
    
    class Appointment {
        - appointmentId : int
        - appointmentDate : LocalDate
        - appointmentTime : String
        - pet : Pet
        - services : ArrayList~Service~
        - status : String
        + Appointment(appointmentId : int, appointmentDate : LocalDate, appointmentTime : String, pet : Pet)
        + getAppointmentId() int
        + addService(service : Service) void
        + getTotalCost() double
        + getDuration() int
        + getStatus() String
    }
    
    class Service {
        - serviceName : String
        - basePrice : double
        - description : String
        + Service(serviceName : String, basePrice : double, description : String)
        + getServiceName() String
        + getBasePrice() double
    }
    
    GroomingSalon --> "*" Pet : registeredPets
    GroomingSalon --> "*" Appointment : appointments
    Dog --|> Pet
    Cat --|> Pet
    ExoticPet --|> Pet
    Pet --> "1" Owner : owner
    Appointment --> "1" Pet : pet
    Appointment --> "*" Service : services
```

## Notes:
- Dog sizes: "Small" (< 10kg), "Medium" (10-25kg), "Large" (> 25kg)
- Dog grooming duration: Small: 60 min, Medium: 90 min, Large: 120 min (add 30 min for long coat)
- Cat grooming duration: 45 min for short hair, 75 min for long hair
- Exotic pet grooming duration: 90 min minimum
- Service types: "Bath" (150 kr), "Haircut" (250 kr), "Nail Trim" (50 kr), "Teeth Cleaning" (100 kr)
- Large dogs have 20% surcharge on all services
- Exotic pets have 50% surcharge
- Owners with 100+ loyalty points get 10% discount
- Earn 1 loyalty point per 10 kr spent
- Appointment status: "Scheduled", "Completed", "Cancelled", "No-Show"
- Use `java.time.LocalDate` for appointment dates


# Exercise 33 - Blood Bank System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class BloodBank {
        - bankName : String
        - location : String
        - licenseNumber : String
        + addDonor(donor : Donor) void
        + registerDonation(donation : Donation) void
        + requestBlood(bloodType : String, amount : double) BloodUnit
        + getInventory() ArrayList~BloodUnit~
        + getLowStockTypes() ArrayList~String~
    }
    
    class Donor {
        - donorId : int
        - name : String
        - bloodType : String
        - dateOfBirth : LocalDate
        - phoneNumber : String
        - email : String
        - lastDonationDate : LocalDate
        + Donor(donorId : int, name : String, bloodType : String, dateOfBirth : LocalDate, phoneNumber : String, email : String)
        + getDonorId() int
        + getBloodType() String
        + isEligibleToDonate() boolean
        + getTotalDonations() int
    }
    
    class Donation {
        - donationId : int
        - donor : Donor
        - donationDate : LocalDate
        - amountML : double
        - hemoglobinLevel : double
        - bloodPressure : String
        - approved : boolean
        + Donation(donationId : int, donor : Donor, donationDate : LocalDate, amountML : double, hemoglobinLevel : double, bloodPressure : String)
        + getDonationId() int
        + isApproved() boolean
        + approve() void
        + reject() void
    }
    
    class BloodUnit {
        - unitId : int
        - bloodType : String
        - rhFactor : String
        - collectionDate : LocalDate
        - expiryDate : LocalDate
        - volumeML : double
        - status : String
        + BloodUnit(unitId : int, bloodType : String, rhFactor : String, collectionDate : LocalDate, volumeML : double)
        + getUnitId() int
        + getBloodType() String
        + isExpired() boolean
        + isAvailable() boolean
        + getStatus() String
    }
    
    class WholeBlood {
        + getExpiryDays() int
        + getStorageTemp() String
    }
    
    class RedBloodCells {
        + getExpiryDays() int
        + getStorageTemp() String
    }
    
    class Plasma {
        + getExpiryDays() int
        + getStorageTemp() String
    }
    
    class Platelets {
        + getExpiryDays() int
        + getStorageTemp() String
    }
    
    class Hospital {
        - hospitalId : int
        - hospitalName : String
        - address : String
        - contactNumber : String
        + Hospital(hospitalId : int, hospitalName : String, address : String, contactNumber : String)
        + getHospitalId() int
        + requestBlood(bloodType : String, units : int) BloodRequest
    }
    
    class BloodRequest {
        - requestId : int
        - hospital : Hospital
        - bloodType : String
        - unitsRequested : int
        - requestDate : LocalDateTime
        - urgency : String
        - status : String
        + BloodRequest(requestId : int, hospital : Hospital, bloodType : String, unitsRequested : int, requestDate : LocalDateTime, urgency : String)
        + getRequestId() int
        + getUrgency() String
        + fulfill() void
    }
    
    BloodBank --> "*" Donor : donors
    BloodBank --> "*" Donation : donations
    BloodBank --> "*" BloodUnit : inventory
    BloodBank --> "*" BloodRequest : requests
    Donation --> "1" Donor : donor
    WholeBlood --|> BloodUnit
    RedBloodCells --|> BloodUnit
    Plasma --|> BloodUnit
    Platelets --|> BloodUnit
    BloodRequest --> "1" Hospital : hospital
```

## Notes:
- Blood types: A+, A-, B+, B-, AB+, AB-, O+, O-
- Donors must wait 56 days between whole blood donations, 112 days for double red cells
- Minimum hemoglobin: 12.5 g/dL for women, 13.0 g/dL for men
- Donors must be 18+ years old
- Expiry periods: Whole blood (35 days), Red cells (42 days), Plasma (1 year frozen), Platelets (5 days)
- Storage temperatures: Whole blood (1-6°C), Red cells (1-6°C), Plasma (-18°C or below), Platelets (20-24°C)
- Low stock: < 20 units of any blood type
- Request urgency: "Emergency" (< 2 hours), "Urgent" (< 24 hours), "Routine" (< 72 hours)
- Request status: "Pending", "Fulfilled", "Partially Fulfilled", "Cancelled"
- Blood unit status: "Available", "Reserved", "Transfused", "Expired", "Discarded"
- Use `java.time.LocalDate` for dates and `java.time.LocalDateTime` for request timestamps


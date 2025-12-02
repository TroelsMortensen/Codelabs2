# Exercise 14 - Hospital Management System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class OperatingSchedule {
        - scheduleDate : LocalDate
        - operatingRoom : String
        + OperatingSchedule(scheduleDate : LocalDate, operatingRoom : String)
        + getScheduleDate() LocalDate
        + getOperatingRoom() String
        + addOperation(operation : Operation) void
        + getOperations() ArrayList~Operation~
        + getTotalDuration() int
    }
    
    class Operation {
        - operationType : String
        - startTime : String
        - durationMinutes : int
        + Operation(operationType : String, startTime : String, durationMinutes : int)
        + getOperationType() String
        + getStartTime() String
        + getDurationMinutes() int
        + addDoctor(doctor : Doctor) void
        + getDoctors() ArrayList~Doctor~
    }
    
    class Patient {
        - name : String
        - dateOfBirth : LocalDate
        - bloodType : String
        - allergies : String
        + Patient(name : String, dateOfBirth : LocalDate, bloodType : String, allergies : String)
        + getName() String
        + getDateOfBirth() LocalDate
        + getBloodType() String
        + getAllergies() String
    }
    
    class _Doctor_ {
        - doctorId : int
        - name : String
        - licenseNumber : String
        # yearsExperience : int
        + Doctor(doctorId : int, name : String, licenseNumber : String, yearsExperience : int)
        + getDoctorId() int
        + getName() String
        + getLicenseNumber() String
        + getYearsExperience() int
        + getSalary()* double
    }
    
    class Orthopedic {
        - surgerySpecialty : String
        + Orthopedic(doctorId : int, name : String, licenseNumber : String, yearsExperience : int, surgerySpecialty : String)
        + getSurgerySpecialty() String
        + getSalary() double
    }
    
    class Anesthesiologist {
        - certifications : String
        + Anesthesiologist(doctorId : int, name : String, licenseNumber : String, yearsExperience : int, certifications : String)
        + getCertifications() String
        + getSalary() double
    }
    
    class Endocrinologist {
        - hormonalDisorders : String
        + Endocrinologist(doctorId : int, name : String, licenseNumber : String, yearsExperience : int, hormonalDisorders : String)
        + getHormonalDisorders() String
        + getSalary() double
    }
    
    OperatingSchedule --> "*" Operation
    Patient <-- Operation
    Operation --> "1..*" _Doctor_
    _Doctor_ <|-- Orthopedic
    _Doctor_ <|-- Anesthesiologist
    Endocrinologist --|> _Doctor_
```

## Notes:
- Use `java.time.LocalDate` for dates
- The `addDoctor()` method throws an `IllegalStateException` if a doctor of the same type (class) is already assigned to the operation
  - For example, you cannot add two Orthopedic doctors to the same operation, but you can have one Orthopedic and one Anesthesiologist
- Operation types can be: "Knee Replacement", "Hip Surgery", "Appendectomy", "Thyroidectomy", etc.
- Orthopedic surgery specialties can be: "Knees", "Elbows", "Hips", "Spine", etc.
- Orthopedic doctors earn 800,000 kr per year base salary + 50,000 kr per year of experience
- Anesthesiologists earn 900,000 kr per year base salary + 60,000 kr per year of experience
- Endocrinologists earn 750,000 kr per year base salary + 45,000 kr per year of experience, and an extra bonus of 10,000 per 5 years of experience

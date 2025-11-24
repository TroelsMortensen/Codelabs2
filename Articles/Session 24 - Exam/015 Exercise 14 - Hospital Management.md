# Exercise 14 - Hospital Management System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Hospital {
        - hospitalName : String
        - address : String
        + addPatient(patient : Patient) void
        + addDoctor(doctor : Doctor) void
        + scheduleAppointment(patient : Patient, doctor : Doctor, dateTime : Date) Appointment
        + getPatientsByDoctor(doctorId : int) ArrayList~Patient~
    }
    
    class Person {
        - id : int
        - firstName : String
        - lastName : String
        - dateOfBirth : LocalDate
        - phoneNumber : String
        + Person(id : int, firstName : String, lastName : String, dateOfBirth : LocalDate, phoneNumber : String)
        + getId() int
        + getFullName() String
        + getAge() int
    }
    
    class Patient {
        - bloodType : String
        - allergies : String
        + Patient(id : int, firstName : String, lastName : String, dateOfBirth : LocalDate, phoneNumber : String, bloodType : String, allergies : String)
        + getBloodType() String
        + getAllergies() String
    }
    
    class Doctor {
        - specialization : String
        - licenseNumber : String
        + Doctor(id : int, firstName : String, lastName : String, dateOfBirth : LocalDate, phoneNumber : String, specialization : String, licenseNumber : String)
        + getSpecialization() String
        + getLicenseNumber() String
    }
    
    class Appointment {
        - appointmentId : int
        - appointmentDateTime : LocalDateTime
        - duration : int
        - status : String
        + Appointment(appointmentId : int, appointmentDateTime : LocalDateTime, duration : int)
        + getAppointmentDateTime() LocalDateTime
        + getStatus() String
        + setStatus(status : String) void
        + cancel() void
    }
    
    class Prescription {
        - prescriptionId : int
        - medicationName : String
        - dosage : String
        - dateIssued : LocalDate
        + Prescription(prescriptionId : int, medicationName : String, dosage : String, dateIssued : LocalDate)
        + getMedicationName() String
        + getDosage() String
    }
    
    Hospital --> "*" Patient : patients
    Hospital --> "*" Doctor : doctors
    Patient --|> Person
    Doctor --|> Person
    Appointment --> "1" Patient : patient
    Appointment --> "1" Doctor : doctor
    Appointment --> "*" Prescription : prescriptions
```

## Notes:
- Use `java.time.LocalDate` for dates and `java.time.LocalDateTime` for appointment times
- Appointment status can be: "Scheduled", "Completed", "Cancelled"
- Use `Period.between()` to calculate age from date of birth


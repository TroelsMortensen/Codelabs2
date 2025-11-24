# Exercise 18 - Smart Home System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class SmartHome {
        - homeAddress : String
        - owner : String
        + addDevice(device : SmartDevice) void
        + removeDevice(deviceId : String) void
        + getAllDevices() ArrayList~SmartDevice~
        + getTotalPowerConsumption() double
        + getDevicesByRoom(room : String) ArrayList~SmartDevice~
    }
    
    class SmartDevice {
        - deviceId : String
        - deviceName : String
        - room : String
        - isOn : boolean
        - installationDate : LocalDate
        + SmartDevice(deviceId : String, deviceName : String, room : String, installationDate : LocalDate)
        + getDeviceId() String
        + getDeviceName() String
        + getRoom() String
        + turnOn() void
        + turnOff() void
        + isOn() boolean
        + getPowerConsumption() double
        + getStatus() String
    }
    
    class SmartLight {
        - brightness : int
        - color : String
        + setBrightness(level : int) void
        + setColor(color : String) void
        + getPowerConsumption() double
    }
    
    class SmartThermostat {
        - currentTemp : double
        - targetTemp : double
        - mode : String
        + setTargetTemp(temp : double) void
        + setMode(mode : String) void
        + getPowerConsumption() double
    }
    
    class SmartCamera {
        - resolution : String
        - isRecording : boolean
        - storageUsed : double
        + startRecording() void
        + stopRecording() void
        + getPowerConsumption() double
    }
    
    class SmartLock {
        - isLocked : boolean
        - accessLog : ArrayList~String~
        + lock() void
        + unlock() void
        + logAccess(person : String) void
        + getPowerConsumption() double
    }
    
    SmartHome --> "*" SmartDevice : devices
    SmartLight --|> SmartDevice
    SmartThermostat --|> SmartDevice
    SmartCamera --|> SmartDevice
    SmartLock --|> SmartDevice
```

## Notes:
- Smart lights consume 10W when on, reduced by (100-brightness)/100
- Smart thermostats consume 500W when heating, 300W when cooling, 5W in standby mode
- Smart cameras consume 5W when off, 15W when recording
- Smart locks consume 2W continuously
- Use `java.time.LocalDate` for installation dates


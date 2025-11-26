# Exercise 18 - Smart Home System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class House {
        - address : String
        - owner : String
        + addRoom(room : Room) void
        + getAllDevices() ArrayList~SmartDevice~
        + getTotalPowerConsumption() double
    }
    
    class Room {
        - roomName : String
        - floorNumber : int
        + addDevice(device : SmartDevice) void
        + removeDevice(deviceId : String) void
        + getDevices() ArrayList~SmartDevice~
        + getRoomPowerConsumption() double
    }
    
    class SmartDevice {
        - deviceId : String
        - deviceName : String
        - isOn : boolean
        - installationDate : LocalDate
        + getDeviceId() String
        + getDeviceName() String
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
    
    House --> "*" Room
    Room --> "*" SmartDevice
    SmartDevice <|-- SmartLight
    SmartDevice <|-- SmartThermostat
    SmartDevice <|-- SmartCamera
    SmartDevice <|-- SmartLock
```

## Notes:
- A house can have multiple rooms (e.g., "Living Room", "Bedroom", "Kitchen")
- Each room can have multiple smart devices
- Smart lights consume 10W when on, reduced by (100-brightness)/100
- Smart thermostats consume 500W when heating, 300W when cooling, 5W in standby mode
- Smart cameras consume 5W when off, 15W when recording
- Smart locks consume 2W continuously
- `getTotalPowerConsumption()` in House calculates the sum of all devices across all rooms
- Use `java.time.LocalDate` for installation dates


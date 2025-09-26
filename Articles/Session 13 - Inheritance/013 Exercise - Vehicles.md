# Exercise - Vehicle Hierarchy

### Task
Implement a vehicle inheritance hierarchy with the following requirements:

1. **Create a `Vehicle` class** with:
   - `brand` (String) - protected
   - `year` (int) - protected
   - `isRunning` (boolean) - private
   - Constructor that takes brand and year
   - `start()` method that sets isRunning to true
   - `stop()` method that sets isRunning to false
   - `getInfo()` method that returns brand and year

2. **Create a `Car` class** that extends `Vehicle`:
   - `numberOfDoors` (int) - private
   - Constructor that takes brand, year, and numberOfDoors
   - Override `getInfo()` to include numberOfDoors
   - `honk()` method that prints a honking message

3. **Create a `Motorcycle` class** that extends `Vehicle`:
   - `hasWindshield` (boolean) - private
   - Constructor that takes brand, year, and hasWindshield
   - Override `getInfo()` to include hasWindshield
   - `rev()` method that prints a revving message

4. **Create a `Truck` class** that extends `Vehicle`:
   - `cargoCapacity` (double) - private
   - Constructor that takes brand, year, and cargoCapacity
   - Override `getInfo()` to include cargoCapacity
   - `loadCargo()` method that prints a loading message

### Test Your Implementation
```java
public class Main {
    public static void main(String[] args) {
        Vehicle[] vehicles = {
            new Car("Toyota", 2023, 4),
            new Motorcycle("Honda", 2022, true),
            new Truck("Ford", 2021, 5000.0)
        };
        
        for (Vehicle vehicle : vehicles) {
            System.out.println(vehicle.getInfo());
            vehicle.start();
            
            // Use instanceof to call specific methods
            if (vehicle instanceof Car) {
                ((Car) vehicle).honk();
            } else if (vehicle instanceof Motorcycle) {
                ((Motorcycle) vehicle).rev();
            } else if (vehicle instanceof Truck) {
                ((Truck) vehicle).loadCargo();
            }
            
            vehicle.stop();
            System.out.println();
        }
    }
}
```

### Expected Output
```
Car: Toyota 2023, Doors: 4
Toyota is starting
Toyota is honking: Beep! Beep!
Toyota is stopping

Motorcycle: Honda 2022, Windshield: true
Honda is starting
Honda is revving: Vroom! Vroom!
Honda is stopping

Truck: Ford 2021, Cargo Capacity: 5000.0
Ford is starting
Ford is loading cargo...
Ford is stopping
```

## Animal Hierarchy Example

### Abstract Animal Class

```mermaid
classDiagram
    class _Animal_ {
        - name : String
        - age : int
        + Animal(name : String, age : int)
        + sleep() void
        + makeSound()* void
        + move()* void
        + eat()* void
    }
    
    class Dog {
        - breed : String
        + Dog(name : String, age : int, breed : String)
        + makeSound() void
        + move() void
        + eat() void
        + fetch() void
    }
    
    class Cat {
        - isIndoor : boolean
        + Cat(name : String, age : int, isIndoor : boolean)
        + makeSound() void
        + move() void
        + eat() void
        + climb() void
    }
    
    class Bird {
        - canFly : boolean
        + Bird(name : String, age : int, canFly : boolean)
        + makeSound() void
        + move() void
        + eat() void
        + fly() void
    }
    
    _Animal_ <|-- Dog
    _Animal_ <|-- Cat
    _Animal_ <|-- Bird
```

## Game Character System

### Complex Abstract Class

```mermaid
classDiagram
    class _GameCharacter_ {
        - name : String
        - health : int
        - level : int
        - isAlive : boolean
        + GameCharacter(name : String, health : int, level : int)
        + takeDamage(damage : int) void
        + heal(amount : int) void
        + isAlive() boolean
        + levelUp() void
        + attack()* void
        + defend()* void
        + specialAbility()* void
    }
    
    class Warrior {
        - strength : int
        - weapon : String
        + Warrior(name : String, health : int, level : int, strength : int, weapon : String)
        + attack() void
        + defend() void
        + specialAbility() void
        + equipWeapon(weapon : String) void
    }
    
    class Mage {
        - mana : int
        - spellBook : String
        + Mage(name : String, health : int, level : int, mana : int, spellBook : String)
        + attack() void
        + defend() void
        + specialAbility() void
        + castSpell(spell : String) void
    }
    
    class Archer {
        - accuracy : int
        - arrows : int
        + Archer(name : String, health : int, level : int, accuracy : int, arrows : int)
        + attack() void
        + defend() void
        + specialAbility() void
        + shootArrow() void
    }
    
    _GameCharacter_ <|-- Warrior
    _GameCharacter_ <|-- Mage
    _GameCharacter_ <|-- Archer
```

## Vehicle System Example

### Abstract Vehicle with Multiple Levels

```mermaid
classDiagram
    class _Vehicle_ {
        - brand : String
        - year : int
        - isRunning : boolean
        + Vehicle(brand : String, year : int)
        + start() void
        + stop() void
        + accelerate()* void
        + brake()* void
        + getInfo() String
    }
    
    class _Car_ {
        - doors : int
        - fuelType : String
        + Car(brand : String, year : int, doors : int, fuelType : String)
        + accelerate() void
        + brake() void
        + openTrunk() void
    }
    
    class _Motorcycle_ {
        - engineSize : int
        - hasWindshield : boolean
        + Motorcycle(brand : String, year : int, engineSize : int, hasWindshield : boolean)
        + accelerate() void
        + brake() void
        + wheelie() void
    }
    
    class Sedan {
        - trunkCapacity : double
        + Sedan(brand : String, year : int, doors : int, fuelType : String, trunkCapacity : double)
        + accelerate() void
        + brake() void
        + openTrunk() void
        + cruiseControl() void
    }
    
    class SportsCar {
        - topSpeed : int
        + SportsCar(brand : String, year : int, doors : int, fuelType : String, topSpeed : int)
        + accelerate() void
        + brake() void
        + openTrunk() void
        + raceMode() void
    }
    
    class SportBike {
        - racingClass : String
        + SportBike(brand : String, year : int, engineSize : int, hasWindshield : boolean, racingClass : String)
        + accelerate() void
        + brake() void
        + wheelie() void
        + trackMode() void
    }
    
    class Cruiser {
        - comfortLevel : int
        + Cruiser(brand : String, year : int, engineSize : int, hasWindshield : boolean, comfortLevel : int)
        + accelerate() void
        + brake() void
        + wheelie() void
        + comfortMode() void
    }
    
    _Vehicle_ <|-- _Car_
    _Vehicle_ <|-- _Motorcycle_
    _Car_ <|-- Sedan
    _Car_ <|-- SportsCar
    _Motorcycle_ <|-- SportBike
    _Motorcycle_ <|-- Cruiser
```

## Payment System Example

### Abstract Payment Method

```mermaid
classDiagram
    class _PaymentMethod_ {
        - accountNumber : String
        - balance : double
        + PaymentMethod(accountNumber : String, balance : double)
        + hasSufficientFunds(amount : double) boolean
        + deductAmount(amount : double) void
        + processPayment(amount : double)* boolean
        + getPaymentDetails()* String
    }
    
    class CreditCard {
        - cardType : String
        - cvv : int
        - creditLimit : double
        + CreditCard(accountNumber : String, balance : double, cardType : String, cvv : int, creditLimit : double)
        + processPayment(amount : double) boolean
        + getPaymentDetails() String
        + checkCreditLimit() boolean
    }
    
    class BankAccount {
        - bankName : String
        - accountType : String
        + BankAccount(accountNumber : String, balance : double, bankName : String, accountType : String)
        + processPayment(amount : double) boolean
        + getPaymentDetails() String
        + transferTo(account : String, amount : double) boolean
    }
    
    class PayPal {
        - email : String
        - linkedBankAccount : String
        + PayPal(accountNumber : String, balance : double, email : String, linkedBankAccount : String)
        + processPayment(amount : double) boolean
        + getPaymentDetails() String
        + linkBankAccount(account : String) void
    }
    
    _PaymentMethod_ <|-- CreditCard
    _PaymentMethod_ <|-- BankAccount
    _PaymentMethod_ <|-- PayPal
```

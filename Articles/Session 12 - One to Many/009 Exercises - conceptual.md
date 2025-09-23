# Conceptual Exercises - One to Many Relationships

The purpose of these exercises is not implementation, but to identify the relationship type between objects. And the multiplicity of the relationship.

## Exercise 9.0: Mountaineer and Gear

A mountaineer carries various pieces of climbing gear on their expeditions. The mountaineer can acquire gear from different sources, lend gear to other climbers, or replace gear when it gets damaged. Gear items could be rope, carabiner, and helmet.

**Objects:**
- Mountaineer
- ClimbingGear


**Task:** Determine whether this relationship is an Association, Aggregation, or Composition. Explain your reasoning. Draw a box for each object type. Draw the correct arrow between them, the correct direction, and the correct multiplicity.


## Exercise 9.1: Submarine and Fish Observations

A research submarine conducts underwater expeditions and records observations of different fish species. Each observation includes details about the fish species, location, depth, and behavior. These observations are created during the submarine's dive and are permanently stored as part of the expedition's research data. If the submarine's expedition data is deleted, all fish observations are also lost. 

**Objects:**
- Submarine
- FishObservation

**Task:** Determine whether this relationship is an Association, Aggregation, or Composition. Explain your reasoning. Draw a box for each object type. Draw the correct arrow between them, the correct direction, and the correct multiplicity.

## Exercise 9.2: Planet and Moons

A planet in a solar system can have multiple moons orbiting around it. Each moon is a natural satellite that is gravitationally bound to the planet. Moons can be discovered and added to the planet's system over time, and they can also be lost due to gravitational interactions or collisions. The planet maintains a record of all its moons and their orbital characteristics.

**Objects:**
- Planet
- Moon

**Task:** Determine whether this relationship is an Association, Aggregation, or Composition. Explain your reasoning. Draw a box for each object type. Draw the correct arrow between them, the correct direction, and the correct multiplicity.

## Exercise 9.3: Car and Components

A car has multiple components including tires, seats, and an engine. The car also has a serial number that is stamped on the vehicle chassis with a specific location within the car. Tires can be replaced and moved between different cars. Seats can be removed and installed in other vehicles. The engine can be swapped out or replaced entirely. The serial number is permanently stamped on the car chassis and cannot be moved or transferred to other vehicles.

**Objects:**
- Car
- Tire
- Seat
- Engine
- SerialNumber

**Task:** Determine the relationship type between each type (Car, Tire, Seat, Engine, SerialNumber). Explain your reasoning for each relationship. Draw a box for each object type. Draw the correct arrows between them, the correct directions, and the correct multiplicities.

## Exercise 9.4: Space Station and Components

A space station houses multiple astronauts on long-term missions and contains various facilities including living quarters, research labs, and life support systems. The station has two types of facilities: internal modules that are permanently built into the station structure, and detachable modules that can be disconnected and transferred to other space stations. Astronauts can be transferred between different space stations, return to Earth for leave, or be assigned to other missions.

**Objects:**
- SpaceStation
- Astronaut
- InternalFacility
- DetachableFacility

**Task:** Determine the relationship type between each type. Draw a box for each object type. Draw the correct relationship-arrows between them, the correct directions, and the correct multiplicities.

## Exercise 9.5: Dragon and Hoard Items

Dragons live in Lairs, sometimes alone, sometimes with others. The dragon(s) guard a massive hoard of magical items, ancient weapons, and precious gems. Individual items can be stolen by brave adventurers, traded with other dragons, or lost during battles. 

**Objects:**
- Dragon
- Lair
- HoardItem
- Adventurer

**Task:** Determine relationships, and types, and multiplicities.

## Exercise 9.6: Time Machine and Historical Events

A time machine records multiple historical events that it has visited during its journeys through time. Each record includes details about the time period, location, and what was observed. These events are stored in the machine's temporal database and can be reviewed by other time travelers. Historical events exist independently in the timeline and can be observed by different time machines.

**Objects:**
- TimeMachine
- HistoricalEventRecord

**Task:** Determine relationships, and types, and multiplicities.
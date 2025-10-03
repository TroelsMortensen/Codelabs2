# Exercise: Solar System Exploration Mission

## Description

Create a program to model galaxies, star systems, planets, moons, and comets. The system should handle different types of celestial bodies with unique characteristics, orbital relationships, and physical properties. This models a simplified astronomical system with hierarchies and relationships.

This exercise focuses on:
- Creating abstract base classes for celestial bodies
- Implementing inheritance for different body types (stars, planets, moons)
- Modeling orbital relationships and hierarchies
- Managing relationships between galaxies, star systems, and celestial bodies
- Calculating orbital periods, distances, and physical properties

## Class Diagram

![class diagram](Resources/SolarSystemClassDiagram.svg)

## Class Descriptions

### Abstract Class: CelestialBody

The base class for all celestial bodies.

**Fields:**
- `name` - Name of the celestial body
- `massKg` - Mass in kilograms
- `radiusKm` - Radius in kilometers
- `temperature` - Surface temperature in Celsius

**Methods:**
- `CelestialBody(name, massKg, radiusKm, temperature)` - Constructor
- various getters
- `calculateGravity()` - Calculates surface gravity using the formula: G * mass / radius², where G is the gravitational constant: 6.67430 × 10^-11, also known as the gravitational constant of universal gravitation. In decimal notation, this is 0.0000000000667430.
- `calculateSurfaceArea()` - Calculates surface area: 4 * π * radius²
- `toString()` - Returns formatted string with body details
- _`getBodyType()`_ - Returns the type of celestial body, implemented by the subclasses.

### Class: Star extends CelestialBody

Represents a star.

**Fields:**
- `luminosity` - Luminosity (brightness) relative to the Sun, e.g. 1.0 for the Sun.
- `spectralClass` - Spectral classification (O, B, A, F, G, K, M), more or less a classification of the star's color.
- `age` - Age in billions of years, e.g. 4.6 billion years for the Sun.

**Methods:**
- `Star(name, massKg, radiusKm, temperature, luminosity, spectralClass, age)` - Constructor
- various getters
- `getBodyType()` - Returns "Star"
- `shine()` - Returns message about the star shining based on its spectral class, e.g. "The star shines brightly in the sky." Or, "The star shines dimly in the sky." The classifications are:
  - O: Blue-white
  - B: Blue
  - A: White-blue
  - F: White
  - G: Yellow-white
  - K: Yellow
  - M: Red
- `toString()` - Returns formatted string with star details

### Class: Planet extends CelestialBody

Represents a planet.

**Fields:**
- `orbitingStar` - The star this planet orbits
- `distanceFromStarAU` - Distance from star in Astronomical Units
- `orbitalPeriodDays` - Orbital period in Earth days
- `hasAtmosphere` - Whether the planet has an atmosphere
- `numberOfMoons` - Number of moons orbiting this planet

**Methods:**
- `Planet(name, massKg, radiusKm, temperature, orbitingStar, distanceFromStarAU, orbitalPeriodDays, hasAtmosphere)` - Constructor (sets numberOfMoons to 0)
- `getOrbitingStar()` - Returns the orbiting star
- `getDistanceFromStarAU()` - Returns distance from star
- `getOrbitalPeriodDays()` - Returns orbital period
- `hasAtmosphere()` - Returns true if has atmosphere
- `getNumberOfMoons()` - Returns number of moons
- `setNumberOfMoons(count)` - Sets the number of moons
- `getBodyType()` - Returns "Planet"
- `isHabitable()` - Returns true if temperature is between -50 and 50°C and has atmosphere
- `toString()` - Returns formatted string with planet details

### Class: Moon extends CelestialBody

Represents a moon orbiting a planet.

**Fields:**
- `orbitingPlanet` - The planet this moon orbits
- `distanceFromPlanetKm` - Distance from planet in kilometers
- `orbitalPeriodDays` - Orbital period around planet in days
- `tidallyLocked` - Whether the moon is tidally locked (same side always faces planet)

**Methods:**
- `Moon(name, massKg, radiusKm, temperature, orbitingPlanet, distanceFromPlanetKm, orbitalPeriodDays, tidallyLocked)` - Constructor
- `getOrbitingPlanet()` - Returns the orbiting planet
- `getDistanceFromPlanetKm()` - Returns distance from planet
- `getOrbitalPeriodDays()` - Returns orbital period
- `isTidallyLocked()` - Returns true if tidally locked
- `getBodyType()` - Returns "Moon"
- `toString()` - Returns formatted string with moon details

### Class: Comet extends CelestialBody

Represents a comet.

**Fields:**
- `orbitingStar` - The star this comet orbits
- `perihelionAU` - Closest distance to star in AU
- `aphelionAU` - Farthest distance from star in AU
- `orbitalPeriodYears` - Orbital period in years
- `tailLength` - Length of tail in millions of kilometers

**Methods:**
- `Comet(name, massKg, radiusKm, temperature, orbitingStar, perihelionAU, aphelionAU, orbitalPeriodYears)` - Constructor (calculates initial tail length)
- `getOrbitingStar()` - Returns the orbiting star
- `getPerihelionAU()` - Returns perihelion distance
- `getAphelionAU()` - Returns aphelion distance
- `getOrbitalPeriodYears()` - Returns orbital period in years
- `getTailLength()` - Returns current tail length
- `getBodyType()` - Returns "Comet"
- `calculateTailLength()` - Calculates tail length based on distance from star (longer tail when closer)
- `isActive()` - Returns true if tail length > 0 (comet is active)
- `toString()` - Returns formatted string with comet details

### Class: StarSystem

Represents a star system containing celestial bodies.

**Fields:**
- `systemName` - Name of the star system
- `bodies` - List of all celestial bodies in the system (stars, planets, moons, comets)

**Methods:**
- `StarSystem(systemName)` - Constructor
- `getSystemName()` - Returns system name
- `addBody(body)` - Adds any celestial body to the system
- `getBodies()` - Returns list of all bodies
- `getCentralStar()` - Filters and returns the first Star from the bodies list (assumes one star per system)
- `getPlanets()` - Filters and returns all Planets from the bodies list
- `getComets()` - Filters and returns all Comets from the bodies list
- `getMoons()` - Filters and returns all Moons from the bodies list
- `getTotalPlanets()` - Returns the count of planets
- `getTotalMoons()` - Returns the count of moons
- `findBody(name)` - Finds and returns a celestial body by name
- `showSystemInfo()` - Prints system information including all celestial bodies

### Class: Galaxy

Represents a galaxy containing multiple star systems.

**Fields:**
- `galaxyName` - Name of the galaxy
- `galaxyType` - Type of galaxy (Spiral, Elliptical, Irregular, Barred Spiral)
- `starSystems` - List of star systems in the galaxy

**Methods:**
- `Galaxy(galaxyName, galaxyType)` - Constructor
- `getGalaxyName()` - Returns galaxy name
- `getGalaxyType()` - Returns galaxy type
- `addStarSystem(system)` - Adds a star system to the galaxy
- `getStarSystems()` - Returns list of star systems
- `getTotalStars()` - Returns total number of stars across all systems
- `getTotalPlanets()` - Returns total number of planets across all systems
- `findStarSystem(name)` - Finds and returns a star system by name
- `showGalaxyInfo()` - Prints galaxy information including all star systems

### Class: SolarSystemTester

Main testing class to demonstrate the solar system.

**Methods:**
- `main(args)` - Creates galaxy, star systems, stars, planets, moons, comets, and displays information

## Testing Requirements

The `SolarSystemTester` class should demonstrate:
1. Creating a galaxy
2. Creating a star system with a star
3. Creating planets with different properties
4. Creating moons orbiting planets
5. Creating comets with elliptical orbits
6. Adding planets and comets to star systems
7. Adding star systems to the galaxy
8. Calculating gravitational properties
9. Checking habitability of planets
10. Displaying complete galaxy information

## Example Structure

Your test class should create something like our Solar System:

```java
// Create the Milky Way galaxy
Galaxy milkyWay = new Galaxy("Milky Way", "Barred Spiral");

// Create the Solar System
StarSystem solarSystem = new StarSystem("Solar System");

// Create our star (the Sun)
Star sun = new Star("Sun", 1.989e30, 696340, 5505, 1.0, "G", 4.6);
solarSystem.addBody(sun);

// Create Earth
Planet earth = new Planet("Earth", 5.972e24, 6371, 15, sun, 1.0, 365.25, true);
solarSystem.addBody(earth);

// Create Earth's moon
Moon moon = new Moon("Moon", 7.342e22, 1737, -20, earth, 384400, 27.3, true);
solarSystem.addBody(moon);

// Create other planets
Planet mars = new Planet("Mars", 6.39e23, 3389, -63, sun, 1.52, 687, true);
solarSystem.addBody(mars);

Planet jupiter = new Planet("Jupiter", 1.898e27, 69911, -108, sun, 5.2, 4333, true);
solarSystem.addBody(jupiter);

// Create a comet
Comet halley = new Comet("Halley's Comet", 2.2e14, 11, -70, sun, 0.586, 35.1, 76);
solarSystem.addBody(halley);

// Add system to galaxy
milkyWay.addStarSystem(solarSystem);

// Display information
milkyWay.showGalaxyInfo();
```

This exercise provides comprehensive practice with inheritance, abstract classes, and modeling astronomical systems!
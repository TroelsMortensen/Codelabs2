package extraterrestrialexploration.test.persistence;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;
import java.util.List;

public class TestGetAllPlanets {
    public static void main(String[] args) {
        try {
            System.out.println("=== Setup: Adding multiple test planets ===");
            DataManager dataManager = new FileDataManager();
            
            Planet planet1 = new Planet("Mercury", "Rocky and hot", 0.39, false, false);
            Planet planet2 = new Planet("Venus", "Thick atmosphere, very hot", 0.72, true, false);
            Planet planet3 = new Planet("Earth", "Temperate, habitable", 1.0, true, true);
            
            dataManager.addPlanet(planet1);
            dataManager.addPlanet(planet2);
            dataManager.addPlanet(planet3);
            
            System.out.println("Added 3 test planets");
        } catch (Exception e) {
            System.out.println("Error during setup: " + e.getMessage());
            return;
        }

        try {
            System.out.println("\n=== Test: Getting all planets ===");
            DataManager dataManager = new FileDataManager();
            
            List<Planet> planets = dataManager.getAllPlanets();
            
            System.out.println("Retrieved " + planets.size() + " planet(s):");
            for (Planet planet : planets) {
                System.out.println(planet);
            }
            
            if (planets.size() >= 3) {
                System.out.println("\n✓ Test PASSED: Successfully retrieved all planets!");
            } else {
                System.out.println("\n✗ Test FAILED: Not all planets were retrieved!");
            }
        } catch (Exception e) {
            System.out.println("Error during test: " + e.getMessage());
            e.printStackTrace();
        }
    }
}


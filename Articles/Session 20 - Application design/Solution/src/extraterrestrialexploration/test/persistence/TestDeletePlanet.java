package extraterrestrialexploration.test.persistence;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;

public class TestDeletePlanet {
    public static void main(String[] args) {
        int planetId = -1;
        
        try {
            System.out.println("=== Setup: Adding test planet ===");
            DataManager dataManager = new FileDataManager();
            Planet planet = new Planet("Test Planet", "Test Climate", 1.5, true, false);
            dataManager.addPlanet(planet);
            planetId = planet.getId();
            System.out.println("Test planet added with ID: " + planetId);
        } catch (Exception e) {
            System.out.println("Error during setup: " + e.getMessage());
            return;
        }

        try {
            System.out.println("\n=== Test: Deleting planet ===");
            DataManager dataManager = new FileDataManager();
            
            System.out.println("Planets before deletion:");
            dataManager.getAllPlanets().forEach(System.out::println);
            
            dataManager.deletePlanet(planetId);
            System.out.println("\nPlanet deleted with ID: " + planetId);
            
            System.out.println("\nPlanets after deletion:");
            dataManager.getAllPlanets().forEach(System.out::println);
            
            Planet deletedPlanet = dataManager.getPlanet(planetId);
            if (deletedPlanet == null) {
                System.out.println("\n✓ Test PASSED: Planet was successfully deleted!");
            } else {
                System.out.println("\n✗ Test FAILED: Planet still exists!");
            }
        } catch (Exception e) {
            System.out.println("Error during test: " + e.getMessage());
            e.printStackTrace();
        }
    }
}


package extraterrestrialexploration.test.persistence;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;

public class TestSaveAndLoadPlanet {
    public static void main(String[] args) {
        Planet savedPlanet = null;
        
        try {
            System.out.println("=== Test 1: Saving Planet ===");
            DataManager dataManager = new FileDataManager();
            Planet planet = new Planet(
                "Kepler-442b", 
                "Temperate with seasonal variations", 
                0.409, 
                true, 
                true
            );
            dataManager.addPlanet(planet);
            savedPlanet = planet;
            System.out.println("Planet saved with ID: " + planet.getId());
            System.out.println(planet);
        } catch (Exception e) {
            System.out.println("Error saving data: " + e.getMessage());
            e.printStackTrace();
            return;
        }

        try {
            System.out.println("\n=== Test 2: Loading Planet ===");
            DataManager dataManager = new FileDataManager();
            Planet loadedPlanet = dataManager.getPlanet(savedPlanet.getId());
            
            if (loadedPlanet != null) {
                System.out.println("Planet loaded successfully:");
                System.out.println(loadedPlanet);
                
                if (loadedPlanet.getId() == savedPlanet.getId() &&
                    loadedPlanet.getName().equals(savedPlanet.getName())) {
                    System.out.println("\n✓ Test PASSED: Data was saved and loaded correctly!");
                } else {
                    System.out.println("\n✗ Test FAILED: Data mismatch!");
                }
            } else {
                System.out.println("✗ Test FAILED: Planet not found!");
            }
        } catch (Exception e) {
            System.out.println("Error loading data: " + e.getMessage());
            e.printStackTrace();
            return;
        }
    }
}


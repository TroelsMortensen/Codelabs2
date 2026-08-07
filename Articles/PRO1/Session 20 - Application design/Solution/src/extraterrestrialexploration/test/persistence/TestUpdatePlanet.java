package extraterrestrialexploration.test.persistence;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;

public class TestUpdatePlanet {
    public static void main(String[] args) {
        int planetId = -1;
        
        try {
            System.out.println("=== Setup: Adding test planet ===");
            DataManager dataManager = new FileDataManager();
            Planet planet = new Planet("Original Planet", "Original Climate", 1.0, true, false);
            dataManager.addPlanet(planet);
            planetId = planet.getId();
            System.out.println("Test planet added:");
            System.out.println(planet);
        } catch (Exception e) {
            System.out.println("Error during setup: " + e.getMessage());
            return;
        }

        try {
            System.out.println("\n=== Test: Updating planet ===");
            DataManager dataManager = new FileDataManager();
            
            Planet updatedPlanet = new Planet("Updated Planet", "Updated Climate", 2.0, false, true);
            updatedPlanet.setId(planetId);
            dataManager.updatePlanet(updatedPlanet);
            
            System.out.println("Planet updated");
            
            Planet retrievedPlanet = dataManager.getPlanet(planetId);
            System.out.println("\nRetrieved planet after update:");
            System.out.println(retrievedPlanet);
            
            if (retrievedPlanet != null && 
                retrievedPlanet.getName().equals("Updated Planet") &&
                retrievedPlanet.getClimateDescription().equals("Updated Climate")) {
                System.out.println("\n✓ Test PASSED: Planet was successfully updated!");
            } else {
                System.out.println("\n✗ Test FAILED: Planet data was not updated correctly!");
            }
        } catch (Exception e) {
            System.out.println("Error during test: " + e.getMessage());
            e.printStackTrace();
        }
    }
}


package extraterrestrialexploration.presentation.planetmanagement;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;
import java.util.List;

public class ListPlanets {
    private DataManager dataManager;

    public ListPlanets() {
        this.dataManager = new FileDataManager();
    }

    public void handleListPlanets() {
        System.out.println("\n=== List All Planets ===");

        try {
            List<Planet> planets = dataManager.getAllPlanets();
            
            if (planets.isEmpty()) {
                System.out.println("\nNo planets found.");
            } else {
                System.out.println("\nFound " + planets.size() + " planet(s):");
                for (Planet planet : planets) {
                    System.out.println(planet);
                }
            }
        } catch (Exception e) {
            System.out.println("\nError retrieving planets: " + e.getMessage());
        }
    }
}


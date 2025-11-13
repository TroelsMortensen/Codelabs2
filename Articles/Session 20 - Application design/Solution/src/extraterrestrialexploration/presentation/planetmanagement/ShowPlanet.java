package extraterrestrialexploration.presentation.planetmanagement;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;
import java.util.Scanner;

public class ShowPlanet {
    private DataManager dataManager;
    private Scanner scanner;

    public ShowPlanet() {
        this.dataManager = new FileDataManager();
        this.scanner = new Scanner(System.in);
    }

    public void handleShowPlanet() {
        System.out.println("\n=== Show Planet ===");

        try {
            System.out.print("Enter planet ID: ");
            int planetId = Integer.parseInt(scanner.nextLine());

            Planet planet = dataManager.getPlanet(planetId);
            if (planet != null) {
                System.out.println("\n" + planet);
            } else {
                System.out.println("\nPlanet not found.");
            }
        } catch (NumberFormatException e) {
            System.out.println("\nInvalid ID. Please enter a number.");
        } catch (Exception e) {
            System.out.println("\nError retrieving planet: " + e.getMessage());
        }
    }
}


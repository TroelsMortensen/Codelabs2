package extraterrestrialexploration.presentation.planetmanagement;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;
import java.util.Scanner;

public class DeletePlanet {
    private DataManager dataManager;
    private Scanner scanner;

    public DeletePlanet() {
        this.dataManager = new FileDataManager();
        this.scanner = new Scanner(System.in);
    }

    public void handleDeletePlanet() {
        System.out.println("\n=== Delete Planet ===");

        try {
            System.out.print("Enter planet ID to delete: ");
            int planetId = Integer.parseInt(scanner.nextLine());

            Planet planet = dataManager.getPlanet(planetId);
            if (planet == null) {
                System.out.println("\nPlanet not found.");
                return;
            }

            System.out.println("\nYou are about to delete the following planet:");
            System.out.println(planet);
            System.out.print("\nAre you sure you want to delete this planet? (y/n): ");
            String confirmation = scanner.nextLine();

            if (confirmation.equalsIgnoreCase("y")) {
                dataManager.deletePlanet(planetId);
                System.out.println("\nPlanet deleted successfully!");
            } else {
                System.out.println("\nPlanet was not deleted.");
            }
        } catch (NumberFormatException e) {
            System.out.println("\nInvalid ID. Please enter a number.");
        } catch (Exception e) {
            System.out.println("\nError deleting planet: " + e.getMessage());
        }
    }
}


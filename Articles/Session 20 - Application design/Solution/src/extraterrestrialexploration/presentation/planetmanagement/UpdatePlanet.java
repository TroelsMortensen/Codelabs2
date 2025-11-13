package extraterrestrialexploration.presentation.planetmanagement;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;
import java.util.Scanner;

public class UpdatePlanet {
    private DataManager dataManager;
    private Scanner scanner;

    public UpdatePlanet() {
        this.dataManager = new FileDataManager();
        this.scanner = new Scanner(System.in);
    }

    public void handleUpdatePlanet() {
        System.out.println("\n=== Update Planet ===");

        try {
            System.out.print("Enter planet ID to update: ");
            int planetId = Integer.parseInt(scanner.nextLine());

            Planet existingPlanet = dataManager.getPlanet(planetId);
            if (existingPlanet == null) {
                System.out.println("\nPlanet not found.");
                return;
            }

            System.out.println("\nCurrent planet details:");
            System.out.println(existingPlanet);

            System.out.print("\nEnter new planet name (or press Enter to keep current): ");
            String name = scanner.nextLine();
            if (name.isEmpty()) {
                name = existingPlanet.getName();
            }

            System.out.print("Enter new climate description (or press Enter to keep current): ");
            String climateDescription = scanner.nextLine();
            if (climateDescription.isEmpty()) {
                climateDescription = existingPlanet.getClimateDescription();
            }

            System.out.print("Enter new distance from star in AU (or press Enter to keep current): ");
            String distanceInput = scanner.nextLine();
            double distanceFromStarAU = distanceInput.isEmpty() ? 
                existingPlanet.getDistanceFromStarAU() : Double.parseDouble(distanceInput);

            System.out.print("Does it have an atmosphere? (true/false, or press Enter to keep current): ");
            String atmosphereInput = scanner.nextLine();
            boolean hasAtmosphere = atmosphereInput.isEmpty() ? 
                existingPlanet.hasAtmosphere() : Boolean.parseBoolean(atmosphereInput);

            System.out.print("Does it have life? (true/false, or press Enter to keep current): ");
            String lifeInput = scanner.nextLine();
            boolean hasLife = lifeInput.isEmpty() ? 
                existingPlanet.hasLife() : Boolean.parseBoolean(lifeInput);

            Planet updatedPlanet = new Planet(name, climateDescription, distanceFromStarAU, hasAtmosphere, hasLife);
            updatedPlanet.setId(planetId);

            System.out.println("\nUpdated planet details:");
            System.out.println(updatedPlanet);
            System.out.print("\nWould you like to save these changes? (y/n): ");
            String confirmation = scanner.nextLine();

            if (confirmation.equalsIgnoreCase("y")) {
                dataManager.updatePlanet(updatedPlanet);
                System.out.println("\nPlanet updated successfully!");
            } else {
                System.out.println("\nPlanet was not updated.");
            }
        } catch (NumberFormatException e) {
            System.out.println("\nInvalid input. Please enter valid numbers.");
        } catch (Exception e) {
            System.out.println("\nError updating planet: " + e.getMessage());
        }
    }
}


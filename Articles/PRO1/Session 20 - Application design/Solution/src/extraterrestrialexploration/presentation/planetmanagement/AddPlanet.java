package extraterrestrialexploration.presentation.planetmanagement;

import extraterrestrialexploration.domain.Planet;
import extraterrestrialexploration.persistence.DataManager;
import extraterrestrialexploration.persistence.FileDataManager;
import java.util.Scanner;

public class AddPlanet {
    private DataManager dataManager;
    private Scanner scanner;

    public AddPlanet() {
        this.dataManager = new FileDataManager();
        this.scanner = new Scanner(System.in);
    }

    public void handleAddPlanet() {
        System.out.println("\n=== Add New Planet ===");

        try {
            System.out.print("Enter planet name: ");
            String name = scanner.nextLine();

            System.out.print("Enter climate description: ");
            String climateDescription = scanner.nextLine();

            System.out.print("Enter distance from star (AU): ");
            double distanceFromStarAU = Double.parseDouble(scanner.nextLine());

            System.out.print("Does it have an atmosphere? (true/false): ");
            boolean hasAtmosphere = Boolean.parseBoolean(scanner.nextLine());

            System.out.print("Does it have life? (true/false): ");
            boolean hasLife = Boolean.parseBoolean(scanner.nextLine());

            Planet planet = new Planet(name, climateDescription, distanceFromStarAU, hasAtmosphere, hasLife);

            System.out.println("\nYou are about to add the following planet:");
            System.out.println(planet);
            System.out.print("\nWould you like to add this planet? (y/n): ");
            String confirmation = scanner.nextLine();

            if (confirmation.equalsIgnoreCase("y")) {
                dataManager.addPlanet(planet);
                System.out.println("\nPlanet added successfully! Planet ID: " + planet.getId());
            } else {
                System.out.println("\nPlanet was not added.");
            }
        } catch (Exception e) {
            System.out.println("\nError adding planet: " + e.getMessage());
        }
    }
}


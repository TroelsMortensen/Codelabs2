package extraterrestrialexploration.presentation.planetmanagement;

import java.util.Scanner;

public class PlanetMenu {
    private Scanner scanner;

    public PlanetMenu() {
        this.scanner = new Scanner(System.in);
    }

    public void handlePlanetMenu() {
        while (true) {
            printPlanetMenu();
            int choice = getUserChoice();

            switch (choice) {
                case 1 -> new AddPlanet().handleAddPlanet();
                case 2 -> new ShowPlanet().handleShowPlanet();
                case 3 -> new ListPlanets().handleListPlanets();
                case 4 -> new UpdatePlanet().handleUpdatePlanet();
                case 5 -> new DeletePlanet().handleDeletePlanet();
                case 6 -> {
                    return; // Back to main menu
                }
                default -> System.out.println("Invalid choice. Please try again.");
            }
        }
    }

    private void printPlanetMenu() {
        System.out.println("\n=== Planet Management ===");
        System.out.println("1. Add Planet");
        System.out.println("2. Show Planet");
        System.out.println("3. List All Planets");
        System.out.println("4. Update Planet");
        System.out.println("5. Delete Planet");
        System.out.println("6. Back to Main Menu");
        System.out.print("Enter your choice: ");
    }

    private int getUserChoice() {
        try {
            return Integer.parseInt(scanner.nextLine());
        } catch (NumberFormatException e) {
            return -1;
        }
    }
}


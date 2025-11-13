package extraterrestrialexploration.presentation;

import extraterrestrialexploration.presentation.planetmanagement.PlanetMenu;
import java.util.Scanner;

public class MainMenu {
    private Scanner scanner;

    public MainMenu() {
        this.scanner = new Scanner(System.in);
    }

    public void handleMainMenu() {
        while (true) {
            printMainMenu();
            int choice = getUserChoice();

            switch (choice) {
                case 1 -> new PlanetMenu().handlePlanetMenu();
                case 2 -> {
                    System.out.println("Goodbye!");
                    return;
                }
                default -> System.out.println("Invalid choice. Please try again.");
            }
        }
    }

    private void printMainMenu() {
        System.out.println("\n=== Main Menu ===");
        System.out.println("1. Planet Management");
        System.out.println("2. Exit");
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


package extraterrestrialexploration.persistence;

import extraterrestrialexploration.domain.*;
import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class FileDataManager implements DataManager {
    private final String filePath = "data.bin";

    public FileDataManager() {
        if (!Files.exists(Paths.get(filePath))) {
            saveData(new DataContainer());
        }
    }

    private void saveData(DataContainer data) {
        try (ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(filePath))) {
            oos.writeObject(data);
        } catch (IOException e) {
            throw new RuntimeException("Failed to save data: " + e.getMessage(), e);
        }
    }

    private DataContainer loadData() {
        try (ObjectInputStream ois = new ObjectInputStream(new FileInputStream(filePath))) {
            return (DataContainer) ois.readObject();
        } catch (IOException | ClassNotFoundException e) {
            throw new RuntimeException("Failed to load data: " + e.getMessage(), e);
        }
    }

    // Planet methods
    @Override
    public void addPlanet(Planet planet) {
        DataContainer data = loadData();
        int maxId = 0;
        for (Planet p : data.getPlanets()) {
            if (p.getId() > maxId) {
                maxId = p.getId();
            }
        }
        planet.setId(maxId + 1);
        data.addPlanet(planet);
        saveData(data);
    }

    @Override
    public void updatePlanet(Planet planet) {
        deletePlanet(planet.getId());
        DataContainer data = loadData();
        data.addPlanet(planet);
        saveData(data);
    }

    @Override
    public void deletePlanet(int id) {
        DataContainer data = loadData();
        data.getPlanets().removeIf(p -> p.getId() == id);
        saveData(data);
    }

    @Override
    public Planet getPlanet(int id) {
        DataContainer data = loadData();
        for (Planet planet : data.getPlanets()) {
            if (planet.getId() == id) {
                return planet;
            }
        }
        return null;
    }

    @Override
    public List<Planet> getAllPlanets() {
        DataContainer data = loadData();
        return data.getPlanets();
    }

    // Alien methods
    @Override
    public void addAlien(Alien alien) {
        DataContainer data = loadData();
        int maxId = 0;
        for (Alien a : data.getAliens()) {
            if (a.getId() > maxId) {
                maxId = a.getId();
            }
        }
        alien.setId(maxId + 1);
        data.addAlien(alien);
        saveData(data);
    }

    @Override
    public void updateAlien(Alien alien) {
        deleteAlien(alien.getId());
        DataContainer data = loadData();
        data.addAlien(alien);
        saveData(data);
    }

    @Override
    public void deleteAlien(int id) {
        DataContainer data = loadData();
        data.getAliens().removeIf(a -> a.getId() == id);
        saveData(data);
    }

    @Override
    public Alien getAlien(int id) {
        DataContainer data = loadData();
        for (Alien alien : data.getAliens()) {
            if (alien.getId() == id) {
                return alien;
            }
        }
        return null;
    }

    @Override
    public List<Alien> getAllAliens() {
        DataContainer data = loadData();
        return data.getAliens();
    }

    // Explorer methods
    @Override
    public void addExplorer(Explorer explorer) {
        DataContainer data = loadData();
        int maxId = 0;
        for (Explorer e : data.getExplorers()) {
            if (e.getId() > maxId) {
                maxId = e.getId();
            }
        }
        explorer.setId(maxId + 1);
        data.addExplorer(explorer);
        saveData(data);
    }

    @Override
    public void updateExplorer(Explorer explorer) {
        deleteExplorer(explorer.getId());
        DataContainer data = loadData();
        data.addExplorer(explorer);
        saveData(data);
    }

    @Override
    public void deleteExplorer(int id) {
        DataContainer data = loadData();
        data.getExplorers().removeIf(e -> e.getId() == id);
        saveData(data);
    }

    @Override
    public Explorer getExplorer(int id) {
        DataContainer data = loadData();
        for (Explorer explorer : data.getExplorers()) {
            if (explorer.getId() == id) {
                return explorer;
            }
        }
        return null;
    }

    @Override
    public List<Explorer> getAllExplorers() {
        DataContainer data = loadData();
        return data.getExplorers();
    }

    // Encounter methods
    @Override
    public void addEncounter(Encounter encounter) {
        DataContainer data = loadData();
        int maxId = 0;
        for (Encounter e : data.getEncounters()) {
            if (e.getId() > maxId) {
                maxId = e.getId();
            }
        }
        encounter.setId(maxId + 1);
        data.addEncounter(encounter);
        saveData(data);
    }

    @Override
    public void updateEncounter(Encounter encounter) {
        deleteEncounter(encounter.getId());
        DataContainer data = loadData();
        data.addEncounter(encounter);
        saveData(data);
    }

    @Override
    public void deleteEncounter(int id) {
        DataContainer data = loadData();
        data.getEncounters().removeIf(e -> e.getId() == id);
        saveData(data);
    }

    @Override
    public Encounter getEncounter(int id) {
        DataContainer data = loadData();
        for (Encounter encounter : data.getEncounters()) {
            if (encounter.getId() == id) {
                return encounter;
            }
        }
        return null;
    }

    @Override
    public List<Encounter> getAllEncounters() {
        DataContainer data = loadData();
        return data.getEncounters();
    }
}


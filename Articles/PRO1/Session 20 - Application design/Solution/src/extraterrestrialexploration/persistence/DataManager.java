package extraterrestrialexploration.persistence;

import extraterrestrialexploration.domain.*;
import java.util.List;

public interface DataManager {
    void addPlanet(Planet planet);
    void updatePlanet(Planet planet);
    void deletePlanet(int id);
    Planet getPlanet(int id);
    List<Planet> getAllPlanets();
    
    void addAlien(Alien alien);
    void updateAlien(Alien alien);
    void deleteAlien(int id);
    Alien getAlien(int id);
    List<Alien> getAllAliens();
    
    void addExplorer(Explorer explorer);
    void updateExplorer(Explorer explorer);
    void deleteExplorer(int id);
    Explorer getExplorer(int id);
    List<Explorer> getAllExplorers();
    
    void addEncounter(Encounter encounter);
    void updateEncounter(Encounter encounter);
    void deleteEncounter(int id);
    Encounter getEncounter(int id);
    List<Encounter> getAllEncounters();
}


package extraterrestrialexploration.persistence;

import extraterrestrialexploration.domain.*;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class DataContainer implements Serializable {
    private List<Alien> aliens;
    private List<Planet> planets;
    private List<Explorer> explorers;
    private List<Encounter> encounters;

    public DataContainer() {
        this.aliens = new ArrayList<>();
        this.planets = new ArrayList<>();
        this.explorers = new ArrayList<>();
        this.encounters = new ArrayList<>();
    }

    public List<Alien> getAliens() {
        return aliens;
    }

    public List<Planet> getPlanets() {
        return planets;
    }

    public List<Explorer> getExplorers() {
        return explorers;
    }

    public List<Encounter> getEncounters() {
        return encounters;
    }

    public void addAlien(Alien alien) {
        aliens.add(alien);
    }

    public void addPlanet(Planet planet) {
        planets.add(planet);
    }

    public void addExplorer(Explorer explorer) {
        explorers.add(explorer);
    }

    public void addEncounter(Encounter encounter) {
        encounters.add(encounter);
    }
}


package extraterrestrialexploration.domain;

import java.io.Serializable;

public class Encounter implements Serializable {
    private int id;
    private String date;
    private Alien alienEncountered;
    private Planet onPlanet;
    private Explorer byExplorer;
    private String descriptionOfTheEncounter;

    public Encounter(String date, Alien alienEncountered, Planet onPlanet, Explorer byExplorer, String descriptionOfTheEncounter) {
        this.date = date;
        this.alienEncountered = alienEncountered;
        this.onPlanet = onPlanet;
        this.byExplorer = byExplorer;
        this.descriptionOfTheEncounter = descriptionOfTheEncounter;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public Alien getAlienEncountered() {
        return alienEncountered;
    }

    public void setAlienEncountered(Alien alienEncountered) {
        this.alienEncountered = alienEncountered;
    }

    public Planet getOnPlanet() {
        return onPlanet;
    }

    public void setOnPlanet(Planet onPlanet) {
        this.onPlanet = onPlanet;
    }

    public Explorer getByExplorer() {
        return byExplorer;
    }

    public void setByExplorer(Explorer byExplorer) {
        this.byExplorer = byExplorer;
    }

    public String getDescriptionOfTheEncounter() {
        return descriptionOfTheEncounter;
    }

    public void setDescriptionOfTheEncounter(String descriptionOfTheEncounter) {
        this.descriptionOfTheEncounter = descriptionOfTheEncounter;
    }

    @Override
    public String toString() {
        return "Encounter{" +
                "id=" + id +
                ", date='" + date + '\'' +
                ", alienEncountered=" + (alienEncountered != null ? alienEncountered.getName() : "None") +
                ", onPlanet=" + (onPlanet != null ? onPlanet.getName() : "None") +
                ", byExplorer=" + (byExplorer != null ? byExplorer.getName() : "None") +
                ", descriptionOfTheEncounter='" + descriptionOfTheEncounter + '\'' +
                '}';
    }
}


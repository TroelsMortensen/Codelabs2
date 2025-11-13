package extraterrestrialexploration.domain;

import java.io.Serializable;

public class Explorer implements Serializable {
    private int id;
    private String name;
    private Planet currentPlanet;

    public Explorer(String name, Planet currentPlanet) {
        this.name = name;
        this.currentPlanet = currentPlanet;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Planet getCurrentPlanet() {
        return currentPlanet;
    }

    public void setCurrentPlanet(Planet currentPlanet) {
        this.currentPlanet = currentPlanet;
    }

    @Override
    public String toString() {
        return "Explorer{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", currentPlanet=" + (currentPlanet != null ? currentPlanet.getName() : "None") +
                '}';
    }
}


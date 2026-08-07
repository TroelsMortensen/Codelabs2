package extraterrestrialexploration.domain;

import java.io.Serializable;

public class Alien implements Serializable {
    private int id;
    private String name;
    private String species;
    private String physicalDescription;

    public Alien(String name, String species, String physicalDescription) {
        this.name = name;
        this.species = species;
        this.physicalDescription = physicalDescription;
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

    public String getSpecies() {
        return species;
    }

    public void setSpecies(String species) {
        this.species = species;
    }

    public String getPhysicalDescription() {
        return physicalDescription;
    }

    public void setPhysicalDescription(String physicalDescription) {
        this.physicalDescription = physicalDescription;
    }

    @Override
    public String toString() {
        return "Alien{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", species='" + species + '\'' +
                ", physicalDescription='" + physicalDescription + '\'' +
                '}';
    }
}


package extraterrestrialexploration.domain;

import java.io.Serializable;

public class Planet implements Serializable {
    private int id;
    private String name;
    private String climateDescription;
    private double distanceFromStarAU;
    private boolean hasAtmosphere;
    private boolean hasLife;

    public Planet(String name, String climateDescription, double distanceFromStarAU, boolean hasAtmosphere, boolean hasLife) {
        this.name = name;
        this.climateDescription = climateDescription;
        this.distanceFromStarAU = distanceFromStarAU;
        this.hasAtmosphere = hasAtmosphere;
        this.hasLife = hasLife;
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

    public String getClimateDescription() {
        return climateDescription;
    }

    public void setClimateDescription(String climateDescription) {
        this.climateDescription = climateDescription;
    }

    public double getDistanceFromStarAU() {
        return distanceFromStarAU;
    }

    public void setDistanceFromStarAU(double distanceFromStarAU) {
        this.distanceFromStarAU = distanceFromStarAU;
    }

    public boolean hasAtmosphere() {
        return hasAtmosphere;
    }

    public void setHasAtmosphere(boolean hasAtmosphere) {
        this.hasAtmosphere = hasAtmosphere;
    }

    public boolean hasLife() {
        return hasLife;
    }

    public void setHasLife(boolean hasLife) {
        this.hasLife = hasLife;
    }

    @Override
    public String toString() {
        return "Planet{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", climateDescription='" + climateDescription + '\'' +
                ", distanceFromStarAU=" + distanceFromStarAU +
                ", hasAtmosphere=" + hasAtmosphere +
                ", hasLife=" + hasLife +
                '}';
    }
}


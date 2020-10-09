package domain;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public enum Sexe {
    MALE('M', "Male"),
    FEMALE('F', "Female");

    private final char id;
    private final String description;

    Sexe(char id, String description) {
        this.id = id;
        this.description = description;
    }

    public static List<Sexe> getList() {
        List<Sexe> sexList = new ArrayList<Sexe>
                (Arrays.asList(Sexe.values()));
        return sexList;
    }

    public char getId() {
        return id;
    }

    public String getDescription() {
        return description;
    }

    @Override
    public String toString() {
        return this.description;
    }

}
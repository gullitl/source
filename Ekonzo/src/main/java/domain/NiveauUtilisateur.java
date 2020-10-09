package domain;

public enum NiveauUtilisateur {
    ADMINISTRATEUR(1, "Administrateur"),
    UTILISATEUR_COMMUN(2, "Utilisateur commun");

    private final int id;
    private final String description;

    NiveauUtilisateur(int id, String description) {
        this.id = id;
        this.description = description;
    }

    public int getId() {
        return id;
    }

    public String getDescription() {
        return description;
    }
}
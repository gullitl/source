package domain;

import javax.persistence.*;
import java.io.Serializable;
import java.time.LocalDate;

@Entity
public class Utilisateur implements Serializable {

    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "id", length = 25)
    private int id;

    @Column(name = "prenom", length = 25, nullable = false)
    private String prenom;

    @Column(name = "nom", length = 25, nullable = false)
    private String nom;

    @Column(name = "postnom", length = 25, nullable = false)
    private String Postnom;

    @Column(name = "nom_utilisateur", length = 25, nullable = false)
    private String nomUtilisateur;

    @Column(name = "mot_passe", length = 10, nullable = false)
    private String motPasse;

    @Enumerated(EnumType.ORDINAL)
    @Column(name = "sexe", nullable = false)
    private Sexe sexe;

    @Column(name = "date_naissance", nullable = false)
    private LocalDate dateNaissance;

    @Enumerated(EnumType.ORDINAL)
    @Column(name = "niveau_utilisateur", nullable = false)
    private NiveauUtilisateur niveauUtilisateur;

    public Utilisateur(int id,
                       String prenom,
                       String nickName,
                       String postnom,
                       String nomUtilisateur,
                       String motPasse,
                       Sexe sexe,
                       LocalDate dateNaissance,
                       NiveauUtilisateur niveauUtilisateur) {
        this.id = id;
        Prenom = prenom;
        this.nickName = nickName;
        Postnom = postnom;
        this.nomUtilisateur = nomUtilisateur;
        this.motPasse = motPasse;
        this.sexe = sexe;
        DateNaissance = dateNaissance;
        this.niveauUtilisateur = niveauUtilisateur;
    }

    public static long getSerialVersionUID() {
        return serialVersionUID;
    }

    public int getId() {
        return id;
    }

    public String getPrenom() {
        return Prenom;
    }

    public String getNickName() {
        return nickName;
    }

    public String getPostnom() {
        return Postnom;
    }

    public String getNomUtilisateur() {
        return nomUtilisateur;
    }

    public String getMotPasse() {
        return motPasse;
    }

    public Sexe getSexe() {
        return sexe;
    }

    public LocalDate getDateNaissance() {
        return DateNaissance;
    }

    public NiveauUtilisateur getNiveauUtilisateur() {
        return niveauUtilisateur;
    }
}
package application.services;

import domain.Utilisateur;

import java.util.List;

public interface IUtilisateurService {

    Utilisateur searchUtilisateurById(String id);

    List<Utilisateur> searchAllUtilisateurs();

    Utilisateur saveUtilisateur(Utilisateur utilisateur);

    Utilisateur updateUtilisateur(Utilisateur utilisateur);

    boolean deleteUtilisateurById(int id);

    Utilisateur login(Utilisateur utilisateur);

}
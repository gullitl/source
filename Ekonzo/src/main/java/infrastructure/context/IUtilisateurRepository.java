package infrastructure.context;

import domain.Utilisateur;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IUtilisateurRepository extends JpaRepository<Utilisateur, String> {

    boolean existsByEmail(String email);
    Utilisateur findByEmailAndPassword(String email, String password);
    Utilisateur findFirstByOrderByIdDesc();
}
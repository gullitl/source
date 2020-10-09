package application.services;

import domain.Utilisateur;
import infrastructure.context.IUtilisateurRepository;
import org.springframework.beans.factory.annotation.Autowired;
import util.EmailValidator;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;

public class UtilisateurService implements IUtilisateurService {

    @Autowired
    private IUtilisateurRepository userRepository;

    @Override
    public Utilisateur searchUsuarioById(String id) {
        Optional<Utilisateur> userOptional = userRepository.findById(id);

        if(userOptional.isPresent()){
            return userOptional.get();
        } else throw new NoSuchElementException("There is no user with the given ID");
    }

    @Override
    public List<Utilisateur> searchAllUtilisateurs(){
        List<Utilisateur> usersDto = new ArrayList();
        for(Utilisateur utilisateur : userRepository.findAll()) {
            usersDto.add(utilisateur);
        }
        return usersDto;
    }

    @Override
    public Utilisateur saveUtilisateur(Utilisateur utilisateur) {
        if (userRepository.existsByEmail(utilisateur.getNomUtilisateur())) {
                throw new IllegalArgumentException("Este e-mail já existe");
        }

        userDto.setId(buscarUsuarioMaiorCodigo() == null ?
                IdGenerator.getInstance().generate() :
                buscarUsuarioMaiorCodigo().getId());

        return persistir(userDto);
    }

    @Override
    public UserDto updateUser(UserDto userDto) {
        if (userDto.getId() == null || userDto.getId().trim().isEmpty()) {
                throw new IllegalArgumentException("O usuário informado não contem ID");
        }
        return persistir(userDto);
    }

    private UserDto persistir(UserDto userDto) {
        User user = userRepository.save(User.builder()
                .id(userDto.getId())
                .fullName(userDto.getFullName())
                .nickName(userDto.getNickName())
                .email(userDto.getEmail())
                .userAcessLevel(userDto.getUserAcessLevel())
                .password(userDto.getPassword())
                .sex(userDto.getSex())
                .dateOfBirth(userDto.getDateOfBirth())
                .build());

        return UserDto.builder()
                .id(user.getId())
                .fullName(user.getFullName())
                .nickName(user.getNickName())
                .email(user.getEmail())
                .userAcessLevel(user.getUserAcessLevel())
                .password(user.getPassword())
                .sex(user.getSex())
                .dateOfBirth(user.getDateOfBirth())
                .build();
    }

    @Override
    public boolean deleteUserById(String id){
        userRepository.deleteById(id);
        return true;
    }

    @Override
    public UserDto fazerLogin(UserDto userDto){
        User user = userRepository.findByEmailAndPassword(userDto.getEmail(), userDto.getPassword());
        if (user == null) return null;
        userLoggedIn.add(user.getEmail());

            return UserDto.builder()
                .id(user.getId())
                .fullName(user.getFullName())
                .nickName(user.getNickName())
                .email(user.getEmail())
                .userAcessLevel(user.getUserAcessLevel())
                .password(user.getPassword())
                .sex(user.getSex())
                .dateOfBirth(user.getDateOfBirth())
                .build();
    }

    @Override
    public void sair(String email){
        if(userLoggedIn.remove(email)) {
            throw new NoSuchElementException("usuário não está logado");
        }
    }

}
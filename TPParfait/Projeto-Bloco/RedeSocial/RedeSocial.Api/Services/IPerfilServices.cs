namespace RedeSocial.Api.Services
{
    public interface IPerfilServices
    {
        void Alterar(string id, PerfilRequest perfil);
        PerfilResponse BuscarPerfil(string username);
        void Cadastrar(PerfilRequest perfil);
    }
}
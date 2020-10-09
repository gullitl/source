using RedeSocial.WebApp.Models.Perfil;
using System.Threading.Tasks;

namespace RedeSocial.WebApp.ApiServices
{
    public interface IPerfilApiService
    {
        Task<PerfilDetailsViewModel> GetPerfil(string userName);
        Task<PerfilEditViewModel> GetPerfilToUpdate(string userName);
        Task Create(PerfilCreateViewModel perfil);
        Task Edit(PerfilEditViewModel perfil);
    }
}
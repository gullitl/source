using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RedeSocial.WebApp.Models.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.WebApp.ApiServices
{
    public class PerfilApiService : IPerfilApiService
    {
        public HttpClient HttpClient;

        public PerfilApiService()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://localhost:5001");
        }

        public async Task Create(PerfilCreateViewModel perfil)
        {
            var postRequest = JsonConvert.SerializeObject(perfil);

            var content = new StringContent(postRequest, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync("api/perfils", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task Edit(PerfilEditViewModel perfil)
        {
            var postRequest = JsonConvert.SerializeObject(perfil);

            var content = new StringContent(postRequest, Encoding.UTF8, "application/json");

            var response = await HttpClient.PutAsync("api/perfils/" + perfil.Id, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<PerfilDetailsViewModel> GetPerfil(string userName)
        {
            var response = await HttpClient.GetAsync("api/perfils/" + userName);

            PerfilDetailsViewModel perfilDetailsViewModel = null;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();

                perfilDetailsViewModel = JsonConvert.DeserializeObject<PerfilDetailsViewModel>(content);
            }

            response.EnsureSuccessStatusCode();

            return perfilDetailsViewModel;
        }

        public async Task<PerfilEditViewModel> GetPerfilToUpdate(string userName)
        {
            var response = await HttpClient.GetAsync("api/perfils/" + userName);

            PerfilEditViewModel perfilDetailsViewModel = null;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();

                perfilDetailsViewModel = JsonConvert.DeserializeObject<PerfilEditViewModel>(content);
            }

            response.EnsureSuccessStatusCode();

            return perfilDetailsViewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.WebApp.Models.Perfil
{
    public class PerfilCreateViewModel
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Endereco { get; set; }
        public string UserName { get; set; }
    }
}

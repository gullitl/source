using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Domain
{
    public class Perfil
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Endereco { get; set; }
        public string UserName { get; set; }
    }
}

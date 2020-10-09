using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Domain
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
        public Perfil Perfil { get; set; }
    }
}

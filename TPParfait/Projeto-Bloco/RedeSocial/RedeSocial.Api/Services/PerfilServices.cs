using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain;
using RedeSocial.Infraestrutura.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.Api.Services
{
    public class PerfilServices : IPerfilServices
    {
        private readonly DomainDbContext _domainDb;

        public PerfilServices(DomainDbContext domainDb)
        {
            _domainDb = domainDb;
        }

        public PerfilResponse BuscarPerfil(string username)
        {
            var perfil = BuscarPerfilPelo(username);

            if (perfil == null)
                return null;

            return new PerfilResponse
            {
                Id = perfil.Id,
                DataDeNascimento = perfil.DataDeNascimento,
                Endereco = perfil.Endereco,
                Nome = perfil.Nome
            };
        }

        public void Cadastrar(PerfilRequest request)
        {
            var perfil = new Perfil
            {
                Nome = request.Nome,
                Endereco = request.Endereco,
                DataDeNascimento = request.DataDeNascimento,
                UserName = request.UserName,
                Id = Guid.NewGuid().ToString()
            };

            Salvar(perfil);
        }

        private void Salvar(Perfil perfil)
        {
            //using var conexao = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Domain;Trusted_Connection=True;MultipleActiveResultSets=true");
            //using var cmd = conexao.CreateCommand();
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = "InserirPerfil @id, @nome, @dataDeNascimento, @endereco, @userName";
            //cmd.Parameters.Add("id", System.Data.SqlDbType.VarChar);
            //cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar);
            //cmd.Parameters.Add("dataDeNascimento", System.Data.SqlDbType.VarChar);
            //cmd.Parameters.Add("endereco", System.Data.SqlDbType.VarChar);
            //cmd.Parameters.Add("userName", System.Data.SqlDbType.VarChar);
            //cmd.ExecuteNonQuery();

            _domainDb
                .Perfils.Add(perfil);
            _domainDb.SaveChanges();
        }

        public void Alterar(string id, PerfilRequest request)
        {
            var perfil = _domainDb.Perfils.Find(id);

            perfil.Nome = request.Nome;
            perfil.Endereco = request.Endereco;
            perfil.DataDeNascimento = request.DataDeNascimento;

            Alterar(perfil);
        }

        private void Alterar(Perfil perfil)
        {
            _domainDb.Perfils.Update(perfil);
            _domainDb.SaveChanges();
        }

        private Perfil BuscarPerfilPelo(string username)
        {
            return _domainDb
                .Perfils.FirstOrDefault(p => p.UserName.Equals(username));
        }
    }

    public class PerfilResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Endereco { get; set; }
    }

    public class PerfilRequest
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Endereco { get; set; }
        public string UserName { get; set; }
    }
}

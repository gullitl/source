using Microsoft.EntityFrameworkCore;
using System;
using RedeSocial.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedeSocial.Infraestrutura.EntityFramework.TypeConfigurations
{
    public class ComentarioEntityTypeConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedeSocial.Infraestrutura.EntityFramework.TypeConfigurations
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .ToTable("tb_post");

            builder
                .Property(x => x.Imagem)
                .HasColumnName("src_img")
                .HasColumnType("varchar");

            builder
                .HasKey(x => x.Id)
                .HasName("post_id");
        }
    }
}

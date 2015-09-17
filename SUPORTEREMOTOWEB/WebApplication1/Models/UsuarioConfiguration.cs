using System.Data.Entity.ModelConfiguration;

namespace WebApplication1.Models
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("usuario", "public");
            HasKey(c => c.usua_codigo);
            HasRequired(c => c.empresa).WithMany().HasForeignKey(c => c.empr_codigo);
        }
    }
}

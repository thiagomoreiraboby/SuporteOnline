using System.Data.Entity.ModelConfiguration;

namespace WebApplication1.Models
{
    public class UsuaPermissaoConfiguration : EntityTypeConfiguration<UsuaPermissao>
    {
        public UsuaPermissaoConfiguration()
        {
            ToTable("usuariopermissao", "public");
            HasKey(c => new {c.usua_codigo ,c.perm_codigo});
            HasRequired(c => c.Permissao).WithMany().HasForeignKey(c => c.perm_codigo);
            HasRequired(c => c.Usuario).WithMany().HasForeignKey(c => c.usua_codigo);
            
        }
    }
}

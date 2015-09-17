using System.Data.Entity.ModelConfiguration;

namespace WebApplication1.Models
{
    public class PermissaoConfiguration : EntityTypeConfiguration<Permissao>
    {
        public PermissaoConfiguration()
        {
            ToTable("permissao", "public");
            HasKey(c => c.perm_codigo);
            
        }
    }
}

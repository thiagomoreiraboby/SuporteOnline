using System.Data.Entity.ModelConfiguration;

namespace WebApplication1.Models
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            ToTable("empresa", "public");
            HasKey(c => c.empr_codigo);
        }
    }
}

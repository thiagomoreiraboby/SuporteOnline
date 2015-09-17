using System.Data.Entity.ModelConfiguration;

namespace WebApplication1.Models
{
    public class GrupClienteConfiguration : EntityTypeConfiguration<GrupCliente>
    {
        public GrupClienteConfiguration()
        {
            ToTable("grupcliente","public");
            HasKey(c => c.grcl_codigo);
            HasRequired(c => c.empresa).WithMany().HasForeignKey(c => c.empr_codigo);
        }
    }
}

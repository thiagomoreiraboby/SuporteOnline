using System.Data.Entity.ModelConfiguration;

namespace WebApplication1.Models
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("cliente", "public");
            HasKey(c => c.clie_codigo);
            HasRequired(c => c.grupo).WithMany().HasForeignKey(c => c.grcl_codigo);
            HasRequired(c => c.empresa).WithMany().HasForeignKey(c => c.empr_codigo);
            HasOptional(c => c.usuario).WithMany().HasForeignKey(c => c.usua_codigo);
        }
    }
}

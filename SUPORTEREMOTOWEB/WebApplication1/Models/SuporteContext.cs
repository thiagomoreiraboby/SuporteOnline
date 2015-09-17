using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.Models
{
    public class SuporteContext : DbContext
    {
        public SuporteContext()
            : base("SuporteContext")
        {
            
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<GrupCliente> GrupClientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissaos { get; set; }
        public DbSet<UsuaPermissao> UsuaPermissaos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
            //confiração
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //propiedades
            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(150));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new GrupClienteConfiguration());
            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PermissaoConfiguration());
            modelBuilder.Configurations.Add(new UsuaPermissaoConfiguration());

        }

         
    }
}

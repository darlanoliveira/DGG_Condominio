
using DGG_Condominio.Models;
using Microsoft.EntityFrameworkCore;


namespace DGG_Condominio.Modulos
{
    public class CondominioContext : DbContext
    {
        public DbSet<UsuariosModelos> usuarios { get; set; } // O nome da variável deve ser exatamente como o nome da tabela no banco de dados, nesse caso 'usuarios'
        public DbSet<AvisosModelo> avisos { get; set; }
        public DbSet<ConfiguracaoModelo> configuracao { get; set; }
        public DbSet<MensagensModelo> mensagens { get; set; }
        // public DbSet<DocumentosModelo> documentos { get; set; }
        // public DbSet<EncomendasModelo> encomendas { get; set; }
        // public DbSet<FuncionariosModelo> funcionarios { get; set; }
        // public DbSet<MoradoresModelo> moradores { get; set; }
        // public DbSet<PortariaModelo> portaria { get; set; }
        // public DbSet<ReservasModelo> reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=sql139.main-hosting.eu.;User Id=u938732425_admin;Password=admin@dgg##2019;Database=u938732425_cond");
            
            //  base.OnConfiguring(optionsBuilder);

        }
    }
}

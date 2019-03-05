
using DGG_Condominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace DGG_Condominio.Modulos
{
    public class CondominioContext : Microsoft.EntityFrameworkCore.DbContext
    { 
        //classe bean
        public System.Data.Entity.DbSet<UsuariosModelos> usuarios { get; set; }
        public System.Data.Entity.DbSet<ConfiguracaoModelo> configuracao { get; set; }
        public System.Data.Entity.DbSet<AvisosModelo> avisos { get; set; }
        public System.Data.Entity.DbSet<DocumentosModelo> documentos { get; set; }
        public System.Data.Entity.DbSet<EncomendasModelo> encomendas { get; set; }
        public System.Data.Entity.DbSet<FuncionariosModelo> funcionarios { get; set; }
        public System.Data.Entity.DbSet<MensagensModelo> mensagens { get; set; }
        public System.Data.Entity.DbSet<MoradoresModelo> moradores { get; set; }
        public System.Data.Entity.DbSet<PortariaModelo> portaria { get; set; }
        public System.Data.Entity.DbSet<ReservasModelo> reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=sql139.main-hosting.eu.;User Id=u938732425_admin;Password=admin@dgg##2019;Database=u938732425_cond");
            //  base.OnConfiguring(optionsBuilder);

        }
    }
}

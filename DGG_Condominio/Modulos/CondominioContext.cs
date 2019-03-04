
using DGG_Condominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace DGG_Condominio.Modulos
{
    public class CondominioContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public System.Data.Entity.DbSet<UsuariosModelos> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=sql139.main-hosting.eu.;User Id=u938732425_admin;Password=admin@dgg##2019;Database=u938732425_cond");
            //  base.OnConfiguring(optionsBuilder);

        }
    }
}

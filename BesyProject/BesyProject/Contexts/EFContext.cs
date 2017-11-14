using BesyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BesyProject.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<BesyProject.Models.Administracao> Administracaos { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidades;
using Projeto.Repositorio.Mapeamentos;
using System.Data.Entity;
using System.Configuration;

namespace Projeto.Repositorio.Configuracoes
{
    public class Conexao : DbContext
    {
        public Conexao()
            :base(ConfigurationManager.ConnectionStrings["bancoDevMedia"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}

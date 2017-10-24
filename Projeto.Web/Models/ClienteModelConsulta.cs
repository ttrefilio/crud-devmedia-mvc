using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models
{
    public class ClienteModelConsulta
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
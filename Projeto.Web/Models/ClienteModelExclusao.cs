﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models
{
    public class ClienteModelExclusao
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Web.Models
{
    public class ClienteModelCadastro
    {

        [Required(ErrorMessage ="Por favor, informe o nome do cliente.")]
        [MaxLength(50, ErrorMessage ="Por favor, informe no máximo {1} caracteres.")]
        [MinLength(6, ErrorMessage ="Por favor, informe no mínimo {1} caracteres.")]
        [Display(Name ="Nome do Cliente: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Por favor, insira um endereço de e-mail.")]
        [EmailAddress(ErrorMessage ="Por favor, insira um e-mail válido.")]
        [Display(Name ="E-mail:")]
        public string Email { get; set; }
    }
}
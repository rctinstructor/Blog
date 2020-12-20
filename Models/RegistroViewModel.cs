using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class RegistroViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string LoginName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}

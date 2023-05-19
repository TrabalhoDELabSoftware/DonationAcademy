﻿using DonationAcademy.Domain;

using System.ComponentModel.DataAnnotations;

namespace DonationAcademy.Areas.Admin.ViewModels
{
    public class AdminRegistroUsuarioEditViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Informe o nome de usuário")]
        [LoginValidation(ErrorMessage = "Formato de login inválido!")]
        [StringLength(50, ErrorMessage = "Limite de caracteres excedido!")]
        public string UserName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe o e-mail!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
      ErrorMessage = "E-mail inválido!")]
        public string EmailRegister { get; set; }

        [Display(Name = "Vendedor")]
        public bool IsVendedor { get; set; }

        [Display(Name = "Gerente")]
        public bool IsGerente { get; set; }

        [Display(Name = "Administrador")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Permitir usuário receber doações")]
        public bool IsDoador { get; set; }


        [SenhaValidation(ErrorMessage = "Formato de senha inválido!")]
        [Display(Name = "Senha gerada aleatoriamente")]
        public string GeneratedPassword { get; set; }

    }
}

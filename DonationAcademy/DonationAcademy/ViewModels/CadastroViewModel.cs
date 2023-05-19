﻿using DonationAcademy.Domain;
using System.ComponentModel.DataAnnotations;

namespace DonationAcademy.ViewModels
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "E-mail inválido!")]
        [Display(Name = "E-mail")]
        public string EmailRegister { get; set; }

        [Required(ErrorMessage = "Informe o nome de usuário")]
        [LoginValidation(ErrorMessage = "Formato de login inválido!")]
        [StringLength(50, ErrorMessage = "Limite de caracteres excedido!")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a senha!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [SenhaValidationAttribute(ErrorMessage = "Senha requer entre 6 e 20 caracteres!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [SenhaValidationAttribute(ErrorMessage = "Senha requer entre 6 e 20 caracteres!")]
        [Compare(nameof(Password), ErrorMessage = "A senha e a confirmação não são iguais")]
        [Display(Name = "Confirmar senha")]
        public string PasswordConfirm { get; set; }
        public string ReturnUrl { get; set; }
    }
}

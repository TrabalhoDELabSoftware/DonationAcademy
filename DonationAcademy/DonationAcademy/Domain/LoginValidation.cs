using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DonationAcademy.Domain
{
    public class LoginValidation : ValidationAttribute
    {
        public LoginValidation() { }

        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;
            bool valido = ValidaFormatoLogin(value.ToString()) || ValidaFormatoEmail(value.ToString());
            return valido;
        }

        public bool ValidaFormatoLogin(string login)
        {
            if (login.Length > 15)
            {
                return false;
            }

            if (!Regex.IsMatch(login, "^[a-zA-Z0-9]+$"))
            {
                return false;
            }

            return true;
        }

        public bool ValidaFormatoEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}

using AuthJWT.WebAPI.Configurations;
using AuthJWT.WebAPI.Models;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AuthJWT.WebAPI.Services
{
    public class PasswordService
    {
        public static PasswordViewModel ValidatePassword(string password)
        {
            if (IsPasswordMeetPolicy(password))
                return new PasswordViewModel { IsValid = true, Message = "senha válida" };

            return new PasswordViewModel { IsValid = false, Message = @"senha inválida, críterios para validação: ✓ Conter no mínimo 15 caracteres. ✓ No mínimo uma letra maiúscula. ✓ No mínimo uma letra minúscula. ✓ No mínimo um dos seguintes caracteres especiais: (@,#,_,- e !). ✓ Não poder ter caracteres repetidos em sequência," };
        }

        public static bool IsPasswordMeetPolicy(string strPassword)
        {
            var passwordSetting = new PasswordSetting();

            StringBuilder sbPasswordRegx = new StringBuilder(string.Empty);

            sbPasswordRegx.Append(@"(?=^.{" + passwordSetting.MinLength + "," + passwordSetting.MaxLength + "}$)");

            sbPasswordRegx.Append(@"(?=.*[a-z])");

            sbPasswordRegx.Append(@"(?=(?:.*?[A-Z]){" + passwordSetting.UpperLength + "})");

            sbPasswordRegx.Append(@"(?=(?:.*?[" + passwordSetting.SpecialChars + "]){" + passwordSetting.SpecialLength + "})");

            if (Regex.IsMatch(strPassword, sbPasswordRegx.ToString()))
                return true;

            return false;
        }

        public static string GeneratePassword()
        {
            var passwordSetting = new PasswordSetting();
            char[] _password = new char[15];
            string charSet = "";
            Random _random = new Random();
            int counter;

            charSet += passwordSetting.LowerCase;
            charSet += passwordSetting.UperCase;
            charSet += passwordSetting.Numbers;
            charSet += passwordSetting.SpecialChars;

            for (counter = 0; counter < 15; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }
            
            return String.Join(null, _password);
        }
    }
}

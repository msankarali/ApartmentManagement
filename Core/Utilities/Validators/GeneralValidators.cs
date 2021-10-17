using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Validators
{
    public class GeneralValidators
    {
        public bool ValidateFileFormats(
            string allowedExtensions,
            params IFormFile[] files)
        {
            return files.All(file =>
                allowedExtensions.Split(',').All(ae =>
                    Path.GetExtension(file.Name).Contains(ae)
                )
            );
        }

        public static bool ValidateEmailFormat(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
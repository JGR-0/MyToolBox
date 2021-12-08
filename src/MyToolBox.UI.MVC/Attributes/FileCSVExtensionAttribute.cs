using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CalculosPlusvalias.UI.MVC.Attributes
{
    public class FileCSVExtensionAttribute : ValidationAttribute
    {
        public FileCSVExtensionAttribute() : base()
        {
            base.ErrorMessage = "El formato del fichero no es un formato válido.";
        }

        public override bool IsValid(object value) => 
            (value as IFormFile).ContentType == "application/vnd.ms-excel";
    }
}

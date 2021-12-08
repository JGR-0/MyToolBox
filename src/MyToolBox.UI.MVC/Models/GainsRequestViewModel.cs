using CalculosPlusvalias.UI.MVC.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculosPlusvalias.UI.MVC.Models
{
    public class GainsRequestViewModel
    {
        public readonly string Splitter = ";";

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido")]
        [DisplayName("Fichero")]
        [FileCSVExtension]
        public IFormFile File { get; set; }

        [Required]
        [DisplayName("¿Fichero con cabeceras?")]
        public bool WithHeaders { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido")]
        [DisplayName("Formato fecha")]
        public string DateFormat { get => _dateFormat; set => _dateFormat = value ?? "dd/mm/yyyy"; }

        private string _dateFormat { get; set; }

        [Required]
        public FileColumnsConfigViewModel ColumnsConfiguration { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculosPlusvalias.UI.MVC.Models
{
    public class GainsRequestViewModel
    {
        [Required]
        [DisplayName("Fichero")]
        public IFormFile File { get; set; }

        [Required]
        [DisplayName("¿Fichero con cabeceras?")]
        public bool WithHeaders { get; set; }

        [Required]
        [DisplayName("Separador columnas")]
        public string Splitter { get => _splitter; set => _splitter = value ?? "\t"; }

        private string _splitter { get; set; }

        [Required]
        public FileColumnsConfigViewModel ColumnsConfiguration { get; set; }
    }
}
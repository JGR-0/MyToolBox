﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculosPlusvalias.UI.MVC.Models
{
    public class FileColumnsConfigViewModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Nº columna de fecha de operación")]
        public int DateColNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Nº columna de hora de operación")]
        public int TimeColNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Nº columna del ISIN")]
        public int ISINColNumber { get; set; }


        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Nº columna de nombre del producto")]
        public int ProductNameColNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Nº columna de nº de participaciones")]
        public int ItemsNumberColNumber { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Nº columna de precio unitario local")]
        public int LocalUnitPriceColNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Nº columna de comisión")]
        public int ComissionColNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Nº columna de tipo de cambio a EUR")]
        public int ExchangeRateColNumber { get; set; }
    }
}

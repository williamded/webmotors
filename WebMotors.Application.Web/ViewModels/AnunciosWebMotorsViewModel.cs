using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMotors.Application.Web.ViewModels
{
    public class AnunciosWebMotorsViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Selecione a Marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Selecione o Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Selecione a Versao")]
        public string Versao { get; set; }

        [Required(ErrorMessage = "Preencha o Ano")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Preencha a Quilometragem")]
        public int Quilometragem { get; set; }
        
        
        public IEnumerable<SelectListItem> Marcas { get; set; }  = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Modelos { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Versoes { get; set; } = new List<SelectListItem>();
        public string Observacao { get; set; }
    }
}
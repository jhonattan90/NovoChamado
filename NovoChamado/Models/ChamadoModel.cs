using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovoChamado.Models
{
    public class ChamadoModel
    {

        [Display(Name = "Numero Chamado:")]
        public int idChamado { get; set; }

        [Display(Name = "Titulo:")]
        public string tituloChamado { get; set; }

        [Display(Name = "Observação:")]
        public string obsChamado { get; set; }

        [Display(Name = "Data Abertura:")]
        [DataType(DataType.Date, ErrorMessage = "Data em Formato Inválido")]
        public string dtChamado { get; set; }

        [Display(Name = "Status:")]
        public string status { get; set; }

        public ChamadoModel()
        {

        }
    }
}
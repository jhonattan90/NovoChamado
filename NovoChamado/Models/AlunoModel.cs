using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovoChamado.Models
{
    public class AlunoModel
    {

        [Display(Name = "Matricular :")]
        public int matricula { get; set; }

        [Display(Name = "Nome :")]
        public string nome { get; set; }

        [Display(Name = "Status:")]
        public String status { get; set; }

        public AlunoModel()
        {

        }
    }
}
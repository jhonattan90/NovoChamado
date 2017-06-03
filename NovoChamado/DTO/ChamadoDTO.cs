using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovoChamado.Models;

namespace ControleChamado.DTO
{
    public class ChamadoDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public ChamadoModel pChamado { get; set; }

        public List<ChamadoModel> lista { get; set; }
    }
}
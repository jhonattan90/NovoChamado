using NovoChamado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleChamado.DTO
{
    public class AlunoDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public AlunoModel aluno { get; set; }

        public List<AlunoModel> lista { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace BesyProject.Models
{
    public class Servico
    {
        public long ServicoId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
    }

}
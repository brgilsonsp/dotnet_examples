using AnotationAttributes.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotationAttributes.Model
{
    public class Pessoa
    {
        [NomeCampoSapAttributes("meuIdentificador")]
        [CampoIdentificador]
        public int Identificador { get; set; }

        [NomeCampoSapAttributes("meuNome")]
        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}

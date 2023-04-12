using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotationAttributes.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NomeCampoSapAttributes : Attribute
    {
        public string NomeCampo { get; }

        public NomeCampoSapAttributes(string nomeCampo)
        {
            NomeCampo = nomeCampo;
        }
    }
}

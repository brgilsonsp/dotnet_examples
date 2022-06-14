using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaeAPIDotNetCore.Models
{
    public class Casa
    {
        public string Porta { get; set; }
        public string Janela { get; set; }
        public string Luz { get; set; }

        public override string ToString()
        {
            return $"Casa: [Porta: {Porta}, Janela: {Janela}, Luz: {Luz}]";
        }
    }
}

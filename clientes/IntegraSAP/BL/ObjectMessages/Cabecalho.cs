﻿using System.Collections.Generic;

namespace BL.ObjectMessages
{
    public class Cabecalho
    {
        public int ID { get; set; }

        public string RequestType { get; set; }

        public string MensagemEDX { get; set; }

        public string ACAO { get; set; }

        public byte Mensagem { get; set; }

        public string Tipo { get; set; }

        public virtual IList<CabecalhoDadosBroker> CabecalhoDadosBroker { get; set; }
    }
}

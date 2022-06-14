﻿using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    /// <summary>
    /// Essa classe possui propriedades redundantes. 
    /// Quando a propriedade possui a anotação NotMapped, ela será utilizada apenas para o XML, sendo assim ela mantem
    /// o nome que foi definida na documentação (fornecida pela E-IT), porém quando a propriedade
    /// utiliza as anotações XmlIgnore e Column("NomeColuna") ela é utilizada apenas pelo banco de dados e foi inserido
    /// um sufixo DB. Foi criado também uma variável privada afim de tratar o retorno para o XML,
    /// pois a E-IT necessita de todos campos no arquivo XML, mesmo null, sendo assim, se o valor no banco de dados for null
    /// ele retornará uma string vazia, afim de gerar a tag no XML
    /// </summary>
    public class MAKTX_TEXT
    {
        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IdTGTESHPN")]
        public int TGTESHP_NID { get; set; }

        [XmlIgnore]
        public virtual TGTESHP_N TGTESHP_N { get; set; }

        #endregion

        #region private

        private string _text;

        #endregion

        [XmlAttribute]
        [Column("TypeMaktx")]
        public string Type { get; set; }

        public string TEXT { get { return ConverterValue.StringNullToEmpty(this._text); } set { this._text = value; } }
    }
}

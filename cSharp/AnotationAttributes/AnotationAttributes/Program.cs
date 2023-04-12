using AnotationAttributes.Annotations;
using AnotationAttributes.Model;
using System;
using System.Linq;
using System.Reflection;

namespace AnotationAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new()
            {
                Identificador = 123
            };

            try
            {
                Program myProgram = new();
                string campo = myProgram.GetNameIdentifiersFieldSap(pessoa);
                Console.WriteLine($"Campo identificador SAP {campo}");

                myProgram.ImprimeValoresDoCampoSap<Pessoa>(pessoa);

            }
            catch(Exception e)
            {
                Console.WriteLine($"Deu erro aqui {e.Message}");
            }
        }
        private String GetNameIdentifiersFieldSap<T>(T objeto)
        {
            Type type = typeof(T);
            PropertyInfo perpertyIdentificador = GetPropertyIdentifier(type);
            NomeCampoSapAttributes attributoIdentiicador = perpertyIdentificador.GetCustomAttribute<NomeCampoSapAttributes>(false);
            bool possuiIdentificador = attributoIdentiicador != null;
            Console.WriteLine($"{type.Name} possui nome do attributo identificador? {possuiIdentificador}");

            return possuiIdentificador ? attributoIdentiicador.NomeCampo : throw new Exception("Configuração do campo identificar obrigatório");
        }

        private PropertyInfo GetPropertyIdentifier(Type type)
        {
            PropertyInfo campoSapAttributes = type.GetProperties()
                .Where(property => property.GetCustomAttributes<CampoIdentificador>(false).Count() == 1)
                .FirstOrDefault();
            bool possuiIdentificador = campoSapAttributes != null;
            Console.WriteLine($"{type.Name} possui attributo identificador? {possuiIdentificador}");
            
            return possuiIdentificador ? campoSapAttributes : throw new Exception("Campo identificar obrigatório");
        }
        private void ImprimeValoresDoCampoSap<T>(T objeto)
        {
            Type type = typeof(T);
            type.GetProperties().ToList()
                .ForEach(property =>
                {
                    var valorProperty = property.GetValue(objeto);
                    NomeCampoSapAttributes nomeCampoSap = property.GetCustomAttributes<NomeCampoSapAttributes>(false).FirstOrDefault();
                    if(nomeCampoSap != null)
                        Console.WriteLine($"{nomeCampoSap.NomeCampo}: {valorProperty}");
                });
        }

    }
}

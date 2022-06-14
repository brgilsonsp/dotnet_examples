using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpanHelp
{
    class Program
    {
        static void Main(string[] args)
        {
            String cpf = ConfigurationSettings.AppSettings["urlcomcpf"];
            String skill = ConfigurationSettings.AppSettings["skill"];

            String skillTratado = skill.Substring(2, skill.Length - 2);
            Console.WriteLine($"Skill: {skill} - SkillTratado: {skillTratado}");

            Console.WriteLine($"CPF: {cpf}");

            DateTime startTime = DateTime.Now;
            Console.WriteLine($"StartTime: {startTime.ToString()}");

            DateTime endTime = DateTime.Now.AddHours(1).AddMinutes(26).AddSeconds(36);
            Console.WriteLine($"EndTime: {endTime.ToString()}");

            TimeSpan timeSpan = endTime.Subtract(startTime);
            Console.WriteLine(timeSpan.ToString(@"hh\:mm\:ss"));

            Console.WriteLine($"GUID: {Guid.NewGuid()}");

            Console.ReadKey();
        }
    }
}

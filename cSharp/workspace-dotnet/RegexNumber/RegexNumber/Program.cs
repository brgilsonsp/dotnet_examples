using System;
using System.Text.RegularExpressions;

namespace RegexNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "2554255326d$5645885548866558asdasd55asd85sa5as5as5";
            Regex regNumber = new Regex(@"\d*");
            Match valueFiltered = regNumber.Match(value);
            Console.WriteLine($"Value: {value} - ValueFiltered: {valueFiltered.Length}");
            Console.ReadKey();
        }
    }
}

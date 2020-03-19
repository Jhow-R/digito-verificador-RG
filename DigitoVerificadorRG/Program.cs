using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitoVerificadorRG
{
    class Program
    {
        static void Main(string[] args)
        {
            // RG gerado no 4Devs: https://www.4devs.com.br/gerador_de_rg
            int numeroRegistro = 23132953;

            Console.WriteLine($"Número de registro: {numeroRegistro}");

            string digitoVerificador = DigitoRG(numeroRegistro);

            Console.WriteLine($"Digito verificador: {digitoVerificador}");

            Console.WriteLine("\nRG: " + FormatarRG(numeroRegistro, digitoVerificador));

            Console.Read();
        }

        public static string DigitoRG(int numero)
        {
            var digitoVerificador = Modulo11(numero);
            return (digitoVerificador == 10) ? "X" : (digitoVerificador == 11) ? "0" : digitoVerificador.ToString();
        }

        public static int Modulo11(int numero)
        {
            var multi = 1;
            var digitos = numero.ToString().Select(c => Char.GetNumericValue(c)).Reverse();
            var soma = (int)digitos.Sum(i => i * (multi = (multi == 9 ? 2 : multi + 1))) * 10;
            return 11 - (soma % 11);
        }

        public static string FormatarRG(int numeroRegistro, string digitoVerificador) => $@"{numeroRegistro:#00\.000\.000}-{digitoVerificador}";
    }
}

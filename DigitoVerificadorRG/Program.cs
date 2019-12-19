using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitoVerificadorRG
{
    class Program
    {
        public static string FormataRG(string texto) => texto.Substring(0, 2) + "." + texto.Substring(2, 3) + "." + texto.Substring(5, 3) + "-" + texto.Substring(8, 1).ToUpper();

        static void Main(string[] args)
        {
            // RG gerado no 4Devs: https://www.4devs.com.br/gerador_de_rg
            int numeroRegistro = 23132953;

            Console.WriteLine($"Número de registro: {numeroRegistro} \n");

            string digitoVerificadorLINQ = CalcularDigitoVerificadorLINQ(numeroRegistro);
            string digitoVerificador = CalcularDigitoVerificadorLINQ(numeroRegistro);

            Console.WriteLine($"Digito Verificador: {digitoVerificador}");
            Console.WriteLine($"Digito Verificador usando LINQ: {digitoVerificadorLINQ}");

            Console.WriteLine("\nRG: " + FormataRG(numeroRegistro + digitoVerificador));

            Console.Read();
        }

        public static string CalcularDigitoVerificadorLINQ(int numeroRegistro)
        {
            int seq = 9;
            int soma = numeroRegistro.ToString().Select(rg => Convert.ToInt32(rg)).Sum(rg => rg * seq--);
            soma *= 10;
            int digitoVerificador = 11 - (soma % 11);

            return (digitoVerificador == 10) ? "X" : (digitoVerificador == 11) ? "0" : digitoVerificador.ToString();
        }

        public static string CalcularDigitoVerificador(int numeroRegistro)
        {
            string strRG = numeroRegistro.ToString();
            int[] vetorRG = new int[strRG.Length];
            int[] seqFixa = new int[] { 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            // Transformando o RG em vetor
            for (int i = 0; i < strRG.Length; i++)
                vetorRG[i] = int.Parse(strRG.Substring(i, 1));

            // Somatória da multiplicação da sequência com o RG
            for (int i = 0; i < vetorRG.Length; i++)
                soma += seqFixa[i] * vetorRG[i];

            // Multiplica por 10 ao final da soma
            soma *= 10;

            //  O resto (módulo) da divisão dos valores somados por 11 é o dígito verificador
            int digitoVerificador = 11 - (soma % 11);

            return (digitoVerificador == 10) ? "X" : (digitoVerificador == 11) ? "0" : digitoVerificador.ToString();

        }
    }
}

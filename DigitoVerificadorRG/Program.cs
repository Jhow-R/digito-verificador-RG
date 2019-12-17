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
            long numeroRegistro = 23132953;
            string strRG = numeroRegistro.ToString();
            long[] vetorRG = new long[strRG.Length];
            int[] seqFixa = new int[] { 9, 8, 7, 6, 5, 4, 3, 2 };
            long soma = 0;

            // Transformando o RG em vetor
            for (int i = 0; i < strRG.Length; i++)
                vetorRG[i] = long.Parse(strRG.Substring(i, 1));

            // Somatória da multiplicação da sequência com o RG
            for (int i = 0; i < vetorRG.Length; i++)
                soma += seqFixa[i] * vetorRG[i];

            // Multiplica por 10 ao final da soma
            soma *= 10;

            //  O resto (módulo) da divisão dos valores somados por 11 é o dígito verificador
            int digitoVerificador = Convert.ToInt32(11 - (soma % 11));

            Console.WriteLine("Digito Verificador: {0}", digitoVerificador);

            Console.Read();
        }
    }
}

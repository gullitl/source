using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoApp
{
    public class ServiceAritmetica
    {
        public int VerificaNumerosNegativos(IEnumerable<double> numeros)
        {
            IEnumerable<double> negativos = numeros.Where(n => n < 0);
            return negativos.Count();
        }

        public (int maior, int menor) IdentificarMaiorEMenorNumero(IEnumerable<int> numeros)
        {
            int maior = Int32.MinValue;
            int menor = Int32.MaxValue;

            foreach(var numero in numeros)
            {
                maior = Math.Max(maior, numero);
                menor = Math.Min(menor, numero);
            }

            return (maior, menor);
        }
        public IEnumerable<(int divisor, int numero)> VerificaDivisores(IEnumerable<int> numeros)
        {
            var divisores = new List<(int, int)>();

            foreach(var numero in numeros)
            {
                if(numero % 2 == 0)
                    divisores.Add((2, numero));

                if(numero % 3 == 0)
                    divisores.Add((3, numero));
            }

            return divisores;
        }

        public Dictionary<int, int> CalcularProgressaoAritmetica(int numeroElementos, int razaoProgressao)
        {
            var progressao = new Dictionary<int, int>();
            int elemento;

            for(int x = numeroElementos; x >= 1; x--)
            {
                elemento = (--numeroElementos) * razaoProgressao;
                progressao.Add(x, elemento);
            }

            return progressao;
        }

        public double SomaTermosSerie()
        {
            double parcela;
            double soma = 0;
            double numero = 1000;
            double denominador = 1;
            double m = 1;

            for(int cont = 1; cont <= 50; cont++)
            {
                parcela = (numero / denominador) * m;
                soma += parcela;
                m *= (-1);
                numero -= 3;
                denominador += 1;
            }
            return soma;
        }
    }
}

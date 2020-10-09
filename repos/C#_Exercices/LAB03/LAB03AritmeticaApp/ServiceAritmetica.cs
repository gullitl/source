using System.Collections.Generic;

namespace CalculoApp
{
    public class ServiceAritmetica
    {
        public string AcharIntervadoNumero(double numero, (double a, double b, double c, double d) extremidade)
        {
            double extremidadeA = extremidade.a < extremidade.b ? extremidade.a : extremidade.b;
            double extremidadeB = extremidade.b > extremidade.a ? extremidade.b : extremidade.a;
            double extremidadeC = extremidade.c < extremidade.d ? extremidade.c : extremidade.d;
            double extremidadeD = extremidade.d > extremidade.c ? extremidade.d : extremidade.c;

            if((numero < extremidadeA) || (numero > extremidadeD))
                return string.Empty;
            else
            {
                if((numero >= extremidadeA) && (numero <= extremidadeB) && (numero >= extremidadeC) && (numero <= extremidadeD))
                    return $"[{extremidade.a},{extremidade.b}] & [{extremidade.c},{extremidade.d}]";
                else
                {
                    if((numero >= extremidadeA) && (numero <= extremidadeB))
                        return $"[{extremidade.a},{extremidade.b}]";
                    else
                        return $"[{extremidade.c},{extremidade.d}]";
                }
            }
        }
        public (int digito1, int digito2, int digito3, int digito4) ExtrairDigitoNumero(int numero)
        {
            int digito1 = (numero / 1000) % 10;
            int digito2 = (numero / 100) % 10;
            int digito3 = (numero / 10) % 10;
            int digito4 = (numero % 10);

            return (digito1, digito2, digito3, digito4);
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

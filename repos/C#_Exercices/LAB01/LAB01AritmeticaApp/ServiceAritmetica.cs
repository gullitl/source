using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoApp
{
    public class ServiceAritmetica
    {
        public int EfetuarSomaNumerosImpares()
        {
            int soma = 0;

            for(int cont = 1; cont <= 99; cont += 2)
                soma += cont;

            return soma;
        }

        public double CalcularPotenciaNumeroElevadoAoCubo(double num) => Math.Pow(num, 3);
        public (double n1, double n2, double quadradro) CalcularQuadradoDiferençaEntreNumeros(double numero1, double numero2)
        {
            double n1;
            double n2;

            if(numero1 > numero2)
            {
                n1 = numero1;
                n2 = numero2;
            } else
            {
                n1 = numero2;
                n2 = numero1;
            }

            double quadradro = Math.Pow(n1, 2) - Math.Pow(2, 2);
            return (n1, n2, quadradro);
        }
        public Dictionary<int, int> CalcularQuadradosNumeros()
        {
            var quadradros = new Dictionary<int, int>();

            int cont = 1;
            while(cont <= 20)
            {
                int num = cont * cont;
                quadradros.Add(cont, num);

                cont++;
            }

            return quadradros;
        }
        public bool VerificarNumeroFaixa(double numero) => (numero >= 20) && (numero <= 90);
    }
}

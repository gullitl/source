using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CalculoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\tData: " + DateTime.Now);
            int opcao;
            bool opcaoValida = true;
            string resposta = "Sim";
            string subline = "______________________________________________________________________________________";
            do
            {
                Console.Write("\n\t\tEscolha uma opção do menu: \n" +
                    "\n\t\t\t1 - Efetuar a soma de números ímpares de 1 a 20" +
                    "\n\t\t\t2 - Calcular a potência de um número elevado ao cubo" +
                    "\n\t\t\t3 - Calcular o quadrado da diferença do maior pelo menor entre 2 números" +
                    "\n\t\t\t4 - Calcular os quadrados dos números compreendidos entre 1 a 20" +
                    "\n\t\t\t5 - Verifica se um número está na faixa de 20 a 90" +
                    "\n\t\t\t6 - Verifica entre 5 números quantos são negativos" +
                    "\n\t\t\t7 - Identificar o maior e menor número dentre 5" +
                    "\n\t\t\t8 - Verificar entre 4 números quais são divisíveis por 2 ou 3" +
                    "\n\t\t\t9 - Calcular os termos de uma progressão aritmética de N elementos" +
                    "\n\t\t\t10 - Calcula a soma de termos de uma série" +
                    $"\n\t\t{subline}\n" +
                    "\n\t\t\t\tQual sua opção?: ");

                opcao = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"\t\t{subline}\n");

                switch(opcao)
                {
                    case 1:
                        {
                            Console.WriteLine("\t\t\tA soma é: " + EfetuarSomaNumerosImpares());
                            break;
                        }

                    case 2:
                        {
                            Console.Write("\\t\tInforme um número qualquer: ");
                            double num = Double.Parse(Console.ReadLine());

                            Console.WriteLine($"\t\t{subline}\n");

                            double potencia = CalcularPotenciaNumeroElevadoAoCubo(num);

                            Console.Write($"\t\tA potência do número {num} é: {potencia}");

                            break;
                        }

                    case 3:
                        {
                            Console.Write("\t\tInforme o 1º número: ");
                            double numero1 = Double.Parse(Console.ReadLine());

                            Console.Write("\t\tInforme o 2º número: ");
                            double numero2 = Double.Parse(Console.ReadLine());

                            var (n1, n2, quadrado) = CalcularQuadradoDiferençaEntreNumeros(numero1, numero2);
                            
                            Console.WriteLine($"\n\t\tO quadrado da diferença entre os números {n1} e {n2} é: {quadrado}");
                            break;
                        }

                    case 4:
                        {
                            string quadradro = string.Empty;
                            Dictionary<int, int> quadradros = CalcularQuadradosNumeros();

                            foreach(var q in quadradros)
                                quadradro += $"\n\t\t{q.Key}^2 = {q.Value}";

                            Console.WriteLine(quadradro);
                            break;
                        }

                    case 5:
                        {
                            Console.Write("\n\t\tInforme um número: ");
                            double numero = Double.Parse(Console.ReadLine());

                            bool taNaFaixa = VerificarNumeroFaixa(numero);

                            Console.WriteLine($"\n\t\tO número {numero}" + (taNaFaixa ? "": " não") + " está na faixa de 20 a 90");
                            break;
                        }

                    case 6:
                        {
                            var numeros = new List<double>();

                            for(int x = 1; x <= 5; x++)
                            { 
                                Console.Write($"\t\tInforme o {x}º número: ");
                                double numero = Double.Parse(Console.ReadLine());
                                
                                numeros.Add(numero);
                            }

                            int qtdNegativos = VerificaNumerosNegativos(numeros);

                            Console.WriteLine($"\n\t\tA quantidade de números negativos é: {qtdNegativos}");
                            break;
                        }

                    case 7:
                        {
                            var numeros = new List<int>();

                            for(int x = 1; x <= 5; x++)
                            {
                                Console.Write($"\t\tInforme o {x}º número: ");
                                int numero = Int32.Parse(Console.ReadLine());

                                numeros.Add(numero);
                            }

                            var (maior, menor) = IdentificarMaiorEMenorNumero(numeros);

                            Console.WriteLine($"\n\t\tO maior número é: {maior} \n\t\tO menor número é: {menor}");
                            break;
                        }

                    case 8:
                        {
                            var numeros = new List<int>();

                            for(int x = 1; x <= 5; x++)
                            {
                                Console.Write($"\t\tInforme o {x}º número: ");
                                int numero = Int32.Parse(Console.ReadLine());

                                numeros.Add(numero);
                            }

                            string divisor = string.Empty;
                            IEnumerable<(int, int)> divisores = VerificaDivisores(numeros);

                            foreach(var d in divisores)
                                divisor += $"\n\t\tO número {d.Item2} é divisível por {d.Item1}";

                            Console.WriteLine(divisor);
                            
                            break;
                        }

                    case 9:
                        {
                            Console.Write("\t\tInforme o número de elementos da Progressão Aritmética: ");
                            int numeroElementos = Int32.Parse(Console.ReadLine());
                            
                            Console.Write("\t\tInforme a razão desta Progressão Aritmética: ");
                            int razaoProgressao = Int32.Parse(Console.ReadLine());

                            string progressao = string.Empty;
                            Dictionary<int, int> progressoes = CalcularProgressaoAritmetica(numeroElementos, razaoProgressao);
                                
                            foreach(var p in progressoes)
                                progressao += $"\n\t\tO {p.Key}º elemento da Progressão Aritmética é: {p.Value}";
                            
                            Console.WriteLine(progressao);

                            break;
                        }

                    case 10:
                        {
                            double soma = SomaTermosSerie();
                            Console.WriteLine($"\n\t\t\tO somatório da série é: {soma}");
                            break;
                        }

                    default:
                        {
                            opcaoValida = false;
                            Console.Write("\t\t\t\tOpção Inválida! Tente outra vez!");
                            break;
                        }

                }

                Console.WriteLine($"\n\t\t{subline}");

                if(opcaoValida)
                {
                    Console.Write("\n\t\tDeseja continuar?, digite \"Sim\" para prosseguir: ");
                    resposta = Console.ReadLine();
                    Console.WriteLine($"\n\t\t{subline}");
                }
                

            } while(string.Equals(resposta, "sim", StringComparison.CurrentCultureIgnoreCase) ||
                    string.Equals(resposta, "s", StringComparison.CurrentCultureIgnoreCase));

            Console.WriteLine($"\t\t{subline}");
            Console.WriteLine();
        }

        public static int EfetuarSomaNumerosImpares()
        {
            int soma = 0;

            for(int cont = 1; cont <= 99; cont += 2)
                soma += cont;

            return soma;
        }

        public static double CalcularPotenciaNumeroElevadoAoCubo(double num) => Math.Pow(num, 3);
        public static (double n1, double n2, double quadradro) CalcularQuadradoDiferençaEntreNumeros(double numero1, double numero2)
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
        public static Dictionary<int, int> CalcularQuadradosNumeros()
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
        public static bool VerificarNumeroFaixa(double numero) => (numero >= 20) && (numero <= 90);

        public static int VerificaNumerosNegativos(IEnumerable<double> numeros)
        {
            IEnumerable<double> negativos = numeros.Where(n => n < 0);
            return negativos.Count();
        }
        
        public static (int maior, int menor) IdentificarMaiorEMenorNumero(IEnumerable<int> numeros)
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
        public static IEnumerable<(int divisor, int numero)> VerificaDivisores(IEnumerable<int> numeros)
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

        public static Dictionary<int, int> CalcularProgressaoAritmetica(int numeroElementos, int razaoProgressao)
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

        public static double SomaTermosSerie()
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

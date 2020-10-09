using System;
using System.Collections.Generic;

namespace CalculoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n\t\tData: {DateTime.Now}\t\tLAB02");
            ServiceAritmetica service = new ServiceAritmetica();
            int opcao;
            bool opcaoValida = true;
            string resposta = "Sim";
            string subline = "______________________________________________________________________________________";
            do
            {
                Console.Write("\n\t\tEscolha uma opção do menu: \n" +
                    "\n\t\t\t1 - Verifica entre 5 números quantos são negativos" +
                    "\n\t\t\t2 - Identificar o maior e menor número dentre 5" +
                    "\n\t\t\t3 - Verificar entre 4 números quais são divisíveis por 2 ou 3" +
                    "\n\t\t\t4 - Calcular os termos de uma progressão aritmética de N elementos" +
                    "\n\t\t\t5 - Calcula a soma de termos de uma série" +
                    $"\n\t\t{subline}\n" +
                    "\n\t\t\t\tQual sua opção?: ");

                opcao = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"\t\t{subline}\n");

                switch(opcao)
                {
                    case 1:
                        {
                            var numeros = new List<double>();

                            for(int x = 1; x <= 5; x++)
                            {
                                Console.Write($"\t\tInforme o {x}º número: ");
                                double numero = Double.Parse(Console.ReadLine());

                                numeros.Add(numero);
                            }

                            int qtdNegativos = service.VerificaNumerosNegativos(numeros);

                            Console.WriteLine($"\n\t\tA quantidade de números negativos é: {qtdNegativos}");
                            break;
                        }

                    case 2:
                        {
                            var numeros = new List<int>();

                            for(int x = 1; x <= 5; x++)
                            {
                                Console.Write($"\t\tInforme o {x}º número: ");
                                int numero = Int32.Parse(Console.ReadLine());

                                numeros.Add(numero);
                            }

                            var (maior, menor) = service.IdentificarMaiorEMenorNumero(numeros);

                            Console.WriteLine($"\n\t\tO maior número é: {maior} \n\t\tO menor número é: {menor}");
                            break;
                        }

                    case 3:
                        {
                            var numeros = new List<int>();

                            for(int x = 1; x <= 5; x++)
                            {
                                Console.Write($"\t\tInforme o {x}º número: ");
                                int numero = Int32.Parse(Console.ReadLine());

                                numeros.Add(numero);
                            }

                            string divisor = string.Empty;
                            IEnumerable<(int, int)> divisores = service.VerificaDivisores(numeros);

                            foreach(var d in divisores)
                                divisor += $"\n\t\tO número {d.Item2} é divisível por {d.Item1}";

                            Console.WriteLine(divisor);

                            break;
                        }

                    case 4:
                        {
                            Console.Write("\t\tInforme o número de elementos da Progressão Aritmética: ");
                            int numeroElementos = Int32.Parse(Console.ReadLine());

                            Console.Write("\t\tInforme a razão desta Progressão Aritmética: ");
                            int razaoProgressao = Int32.Parse(Console.ReadLine());

                            string progressao = string.Empty;
                            Dictionary<int, int> progressoes = service.CalcularProgressaoAritmetica(numeroElementos, razaoProgressao);

                            foreach(var p in progressoes)
                                progressao += $"\n\t\tO {p.Key}º elemento da Progressão Aritmética é: {p.Value}";

                            Console.WriteLine(progressao);

                            break;
                        }

                    case 5:
                        {
                            double soma = service.SomaTermosSerie();
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


        
    }
}

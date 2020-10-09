using System;
using System.Collections.Generic;

namespace CalculoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n\t\tData: {DateTime.Now}\t\tLAB03");
            ServiceAritmetica service = new ServiceAritmetica();
            int opcao;
            bool opcaoValida = true;
            string resposta = "Sim";
            string subline = "______________________________________________________________________________________";
            do
            {
                Console.Write("\n\t\tEscolha uma opção do menu: \n" +
                    "\n\t\t\t1 - Achar intervado de número" +
                    "\n\t\t\t2 - Extrair cada dígito de um número" +
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
                            Console.Write("\t\tInforme o número: ");
                            double numero = Double.Parse(Console.ReadLine());

                            Console.Write("\n\t\tInforme o valor da extremidade A: ");
                            double extremidadeA = Double.Parse(Console.ReadLine());
                            Console.Write("\t\tInforme o valor da extremidade B: ");
                            double extremidadeB = Double.Parse(Console.ReadLine());

                            Console.Write("\n\t\tInforme o valor da extremidade C: ");
                            double extremidadeC = Double.Parse(Console.ReadLine());
                            Console.Write("\t\tInforme o valor da extremidade D: ");
                            double extremidadeD = Double.Parse(Console.ReadLine());

                            string intervalo = service.AcharIntervadoNumero(numero, (extremidadeA, extremidadeB, extremidadeC, extremidadeD));

                            Console.WriteLine($"\n\t\tO número {numero}" + (intervalo != string.Empty ?
                                $" pertence ao intervalo: {intervalo}" :
                                $" não pertence a nenhum dos intervalos: [{extremidadeA},{extremidadeB}] & [{extremidadeC},{extremidadeD}]"));

                            break;
                        }

                    case 2:
                        {
                            Console.Write("\n\t\tInforme o Número: ");
                            int numero = Int32.Parse(Console.ReadLine());

                            if(numero < 1000 || numero > 9999)
                            {
                                Console.Write("\n\t\t\t\tNúmero inválido!");
                                break;
                            }

                            var (digito1, digito2, digito3, digito4) = service.ExtrairDigitoNumero(numero);

                            Console.WriteLine($"\n\t\tOs dígitos do número fornecido são: {digito1}, {digito2}, {digito3} e {digito4}");
                            break;
                        }

                    case 3:
                        {


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

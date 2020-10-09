using System;
using System.Collections.Generic;

namespace CalculoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n\t\tData: {DateTime.Now}\t\tLAB01");
            ServiceAritmetica service = new ServiceAritmetica();
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
                    $"\n\t\t{subline}\n" +
                    "\n\t\t\t\tQual sua opção?: ");

                opcao = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"\t\t{subline}\n");

                switch(opcao)
                {
                    case 1:
                        {
                            Console.WriteLine("\t\t\tA soma é: " + service.EfetuarSomaNumerosImpares());
                            break;
                        }

                    case 2:
                        {
                            Console.Write("\t\tInforme um número qualquer: ");
                            double num = Double.Parse(Console.ReadLine());

                            Console.WriteLine($"\t\t{subline}\n");

                            double potencia = service.CalcularPotenciaNumeroElevadoAoCubo(num);

                            Console.Write($"\t\tA potência do número {num} é: {potencia}");

                            break;
                        }

                    case 3:
                        {
                            Console.Write("\t\tInforme o 1º número: ");
                            double numero1 = Double.Parse(Console.ReadLine());

                            Console.Write("\t\tInforme o 2º número: ");
                            double numero2 = Double.Parse(Console.ReadLine());

                            var (n1, n2, quadrado) = service.CalcularQuadradoDiferençaEntreNumeros(numero1, numero2);
                            
                            Console.WriteLine($"\n\t\tO quadrado da diferença entre os números {n1} e {n2} é: {quadrado}");
                            break;
                        }

                    case 4:
                        {
                            string quadradro = string.Empty;
                            Dictionary<int, int> quadradros = service.CalcularQuadradosNumeros();

                            foreach(var q in quadradros)
                                quadradro += $"\n\t\t{q.Key}^2 = {q.Value}";

                            Console.WriteLine(quadradro);
                            break;
                        }

                    case 5:
                        {
                            Console.Write("\n\t\tInforme um número: ");
                            double numero = Double.Parse(Console.ReadLine());

                            bool taNaFaixa = service.VerificarNumeroFaixa(numero);

                            Console.WriteLine($"\n\t\tO número {numero}" + (taNaFaixa ? "": " não") + " está na faixa de 20 a 90");
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

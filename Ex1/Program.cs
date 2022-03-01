using System;
using System.IO;

namespace Ex1
{
    internal class Program
    {

        static string[,] matriz = new string[3, 3];

        public static void InserirNomes()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.WriteLine("Qual o elemento da linha " + (i + 1) +  " da coluna " + (j + 1));
                    matriz[i, j] = Console.ReadLine();

                }
            }
        }

        public static void ImprimirNomeCompletos()
        {
            if (matriz[0, 0] == null)
            {
                Console.WriteLine("Matriz vazia");
            }
            else
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write("Matriz [" + i + "] [" + j + "] = " + matriz[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void ImprimirNomeDeUmaLinha()
        {

            Console.WriteLine("Escolha uma linha: ");
            int linha = Convert.ToInt32(Console.ReadLine());
            //linha = linha - 1;

            if (linha < 0 || linha > 2)
            {
                Console.WriteLine("Linha não encontrada: ");
            }
            else
            {
                for (int i = linha; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write($"Linha {linha} - Coluna {j}: {matriz[linha, j]} ");
                    }
                    Console.ReadLine();
                    break;
                }
            }
        }

        public static void ImprimirNomesDeUmaColuna()
        {
            Console.WriteLine("Escolha uma coluna: ");
            int coluna = Convert.ToInt32(Console.ReadLine());
            //coluna = coluna - 1;

            if (coluna < 0 || coluna > 2)
            {
                Console.WriteLine("Coluna não encontrada: ");
            }
            else
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = coluna; j < matriz.GetLength(1); j++)
                    {
                        Console.Write($"Linha {i} - Coluna {j}: {matriz[i, j]} ");
                        break;
                    }
                    Console.ReadLine();

                }
            }
        }

        public static void ProcurarNome()
        {
            bool erro = true;
            Console.WriteLine("Digite um nome para procurar: ");
            string nome = Console.ReadLine();
            nome = nome.ToLower();
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (nome.CompareTo(matriz[i, j]) == 0)
                    {
                        Console.WriteLine("\n O " + nome + " está na linha: " + i + " e na coluna : " + j + "\n");
                        erro = false;
                    }

                }
            }
            if (erro)
            {
                Console.WriteLine("Esse nome não existe na matriz");

            }

        }

        public static void Ordernar()
        {
            if (matriz[0, 0] == null)
            {
                Console.WriteLine("Matriz vazia");
            }
            else
            {
                Console.WriteLine("Digite a linha que deseja ordenar: ");
                int i = Convert.ToInt32(Console.ReadLine());
                /*int comparaLinha = Convert.ToInt32(Console.ReadLine());

                 for(int i = comparaLinha; i <= comparaLinha; i++)
                 {
                     for(int j = 0; j < matriz.GetLength(1); j++)
                     {

                         for (int aux = 0; aux < matriz.GetLength(1); aux++)
                         {
                             if (matriz[i, aux].CompareTo(matriz[i, j]) == 1)
                             {

                                 string aux2;
                                 aux2 = matriz[i, aux];
                                 matriz[i, aux] = matriz[i, j];
                                 matriz[i, j] = aux2;

                             }
                         }

                     }


                 }
                */
                if (i < 0 || i > 2)
                {
                    Console.WriteLine("Linha não encontrada");
                }
                else
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        for (int aux = 0; aux < matriz.GetLength(1); aux++)
                        {
                            if (matriz[i, aux].CompareTo(matriz[i, j]) == 1)
                            {
                                string aux2;
                                aux2 = matriz[i, aux];
                                matriz[i, aux] = matriz[i, j];
                                matriz[i, j] = aux2;

                            }
                        }
                    }
                }
            }
        }

        public static void GravarDadosdaMatriz()
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Michael Silva\\Documents\\Exercicios\\Arquivos\\5by5\\Test.txt");  //Instancia um Objeto StreamWriter (Classe de Manipulação de Arquivos)
                for(int i = 0; i < matriz.GetLength(0); i++)
                {
                    for(int j = 0; j < matriz.GetLength(1); j++)
                    {
                        sw.WriteLine("{0}", matriz[i, j]);
                    }
                }
                sw.Close();  
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comandos.");
            }


        }

        public static void LerDadosdaMatriz()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Michael Silva\\Documents\\Exercicios\\Arquivos\\5by5\\Test.txt");
                line = sr.ReadLine(); 
                while (line != null)
                {
                    for(int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for(int j = 0; j < matriz.GetLength(1); j++)
                        {
                            matriz[i, j] = line;
                            line = sr.ReadLine();
                            //Console.WriteLine(line);
                        }
                    }                  
                }
                sr.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comando - Sem Erros");
                Console.ReadLine();
            }
        }
        



        static void Main(string[] args)
        {

            int opc = 0;

            while (opc != 9)
            {
                Console.WriteLine("Digite uma opção: ");
                Console.WriteLine("1 - Ler Nomes ");
                Console.WriteLine("2 - Imprimir Nomes Completos ");
                Console.WriteLine("3 - Imprimir De Uma Linha ");
                Console.WriteLine("4 - Imprimir De Uma Coluna ");
                Console.WriteLine("5 - Procurar Nome ");
                Console.WriteLine("6 - Ordenar Nomes ");
                Console.WriteLine("7 - Gravar Dados da Matriz ");
                Console.WriteLine("8 - Ler Dados da Matriz ");

                Console.WriteLine("9 - Sair ");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        InserirNomes();
                        break;
                    case 2:
                        ImprimirNomeCompletos();
                        break;
                    case 3:
                        ImprimirNomeDeUmaLinha();
                        break;
                    case 4:
                        ImprimirNomesDeUmaColuna();
                        break;
                    case 5:
                        ProcurarNome();
                        break;
                    case 6:
                        Ordernar();
                        break;
                    case 7:
                        GravarDadosdaMatriz();
                        break;
                    case 8:
                        LerDadosdaMatriz();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

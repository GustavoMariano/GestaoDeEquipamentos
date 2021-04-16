using System;

namespace GestaoDeEquipamentos.ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int contadorEquipamento = 0;

            string[] nomeEquipamento = new string[10];
            string[] fabricanteEquipamento = new string[10];
            decimal[] precoEquipamento = new decimal[10];
            string[] numeroSerieEquipamento = new string[10];
            DateTime[] dataFabricacaoEquipamento = new DateTime[10];

            while (true)
            {
                Console.WriteLine("1 para equipamentos, 2 para chamados");
                MensagemEmVermelho("S PARA SAIR");
                string opcao = Console.ReadLine().ToUpper();

                Console.Clear();

                if (opcao == "S")
                {
                    Console.Clear();
                    break;
                }
                else if (opcao == "1")
                {


                    Console.WriteLine("1 para adicionar, 2 para visualizar, 3 para editar, 4 para excluir");
                    MensagemEmVermelho("S PARA SAIR");

                    Console.ReadLine();

                    if (opcao == "1")
                    {
                        #region Nome DEVE ter no mínimo 6 caracteres [OK]
                        #endregion

                        #region DEVE ter preço de aquisição
                        #endregion

                        #region Deve ter um número de série
                        #endregion

                        #region Deve ter uma data de fabricação
                        #endregion

                        #region Deve ter um fabricante
                        #endregion

                        Console.Clear();

                        bool confirmacao = true;

                        while (confirmacao == true)
                        {
                            Console.WriteLine("Digite o nome do equipamento: ");
                            nomeEquipamento[contadorEquipamento] = Console.ReadLine();

                            if (NomeDeveTer6Caracteres(contadorEquipamento, nomeEquipamento))
                            {
                                Console.Clear();
                                MensagemEmVermelho("O equipamento deve ter no mínimo 6 caracteres, tente novamente!!");
                                Console.ReadLine();
                                continue;
                            }

                            Console.WriteLine("Digite o número série do equipamento: ");
                            numeroSerieEquipamento[contadorEquipamento] = Console.ReadLine();

                            Console.WriteLine("Digite o fabricante do equipamento: ");
                            fabricanteEquipamento[contadorEquipamento] = Console.ReadLine();

                            Console.WriteLine("Digite o preco do equipamento: ");
                            precoEquipamento[contadorEquipamento] = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Digite a data de fabricação do equipamento: Ex.: 01/01/2001");
                            dataFabricacaoEquipamento[contadorEquipamento] = Convert.ToDateTime(Console.ReadLine());

                            confirmacao = false;

                            for (int i = 0; i <= contadorEquipamento; i++)
                            {
                                Console.WriteLine(nomeEquipamento[i]);
                                Console.WriteLine(numeroSerieEquipamento[i]);
                                Console.WriteLine(fabricanteEquipamento[i]);
                                Console.WriteLine(precoEquipamento[i]);
                                Console.WriteLine(dataFabricacaoEquipamento[i]);
                            }
                            contadorEquipamento++;
                        }

                    }
                    else if (opcao == "2")
                    {

                    }
                    else if (opcao == "3")
                    {

                    }
                    else if (opcao == "4")
                    {

                    }

                }
                else if (opcao == "2")
                {
                    Console.WriteLine("1 para criar, 2 para visualizar, 3 para editar, 4 para excluir");
                    MensagemEmVermelho("S PARA SAIR");

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Opção não reconhecida, por favor tente novamente!!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }

        private static bool NomeDeveTer6Caracteres(int contadorEquipamento, string[] nomeEquipamento)
        {
            return nomeEquipamento[contadorEquipamento].Length < 6;
        }

        private static void MensagemEmVermelho(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}

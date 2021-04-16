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
                MostrarMenu();
                string opcao = Console.ReadLine().ToUpper();

                Console.Clear();

                #region Sair
                if (EhOpcaoSair(opcao))
                {
                    Console.Clear();
                    break;
                }
                #endregion

                #region Equipamentos
                else if (opcao == "1")
                {
                    Console.WriteLine("1 para adicionar, 2 para visualizar, 3 para editar, 4 para excluir");
                    MensagemEmVermelho("S PARA SAIR");

                    Console.ReadLine();

                    #region Adicionar Equipamento
                    if (opcao == "1")
                    {
                        #region Requisitos funcionais
                        #region Nome DEVE ter no mínimo 6 caracteres [OK]
                        #endregion

                        #region DEVE ter preço de aquisição [OK]
                        #endregion

                        #region Deve ter um número de série [OK]
                        #endregion

                        #region Deve ter uma data de fabricação [OK]
                        #endregion

                        #region Deve ter um fabricante [OK]
                        #endregion
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

                            while (true)
                            {
                                Console.WriteLine("Digite o número série do equipamento: ");
                                numeroSerieEquipamento[contadorEquipamento] = Console.ReadLine();
                                if (EhVazioOuNulo(contadorEquipamento, numeroSerieEquipamento))
                                {
                                    MensagemEmVermelho("O equipamento deve ter um nome, tente novamente!!");
                                    continue;
                                }
                                else
                                    break;
                            }

                            while (true)
                            {
                                Console.WriteLine("Digite o fabricante do equipamento: ");
                                fabricanteEquipamento[contadorEquipamento] = Console.ReadLine();
                                if (EhVazioOuNulo(contadorEquipamento, fabricanteEquipamento))
                                {
                                    MensagemEmVermelho("O equipamento deve ter um nome, tente novamente!!");
                                    continue;
                                }
                                else
                                    break;
                            }

                            while (true)
                            {
                                Console.WriteLine("Digite o preco do equipamento: ");
                                precoEquipamento[contadorEquipamento] = Convert.ToDecimal(Console.ReadLine());
                                if (DecimalEhMaiorQueZero(contadorEquipamento, precoEquipamento))
                                {
                                    MensagemEmVermelho("O equipamento deve ter um nome, tente novamente!!");
                                    continue;
                                }
                                else
                                    break;
                            }

                            while (true)
                            {
                                Console.WriteLine("Digite a data de fabricação do equipamento: Ex.: 01/01/2001");
                                string auxData = Console.ReadLine();

                                bool verificaData = ValidaData(contadorEquipamento, dataFabricacaoEquipamento, auxData);

                                if (verificaData == false)
                                {
                                    MensagemEmVermelho("O equipamento deve ter uma data de fabricação válida, tente novamente!!");
                                    continue;
                                }
                                else
                                    break;
                            }

                            confirmacao = false;

                            for (int i = 0; i <= contadorEquipamento; i++)
                            {
                                Console.WriteLine(nomeEquipamento[i]);
                                Console.WriteLine(numeroSerieEquipamento[i]);
                                Console.WriteLine(fabricanteEquipamento[i]);
                                Console.WriteLine(precoEquipamento[i]);
                                Console.WriteLine(dataFabricacaoEquipamento[i].ToString("dd/MM/yyyy"));
                            }
                            contadorEquipamento++;
                        }

                    }
                    #endregion

                    #region Visualizar Equipamentos
                    else if (opcao == "2")
                    {
                        #region Deve mostrar o nome
                        #endregion

                        #region Deve mostrar o número de série
                        #endregion

                        #region Deve mostrar a fabricant
                        #endregion
                    }
                    #endregion

                    #region Editar Equipamento
                    else if (opcao == "3")
                    {

                    }
                    #endregion

                    #region Excluir equipamento
                    else if (opcao == "4")
                    {

                    }
                    #endregion
                }
                #endregion

                #region Chamados
                else if (opcao == "2")
                {
                    Console.WriteLine("1 para criar, 2 para visualizar, 3 para editar, 4 para excluir");
                    MensagemEmVermelho("S PARA SAIR");

                    Console.ReadLine();
                }
                #endregion

                #region Opção Inválida
                else
                {
                    Console.WriteLine("Opção não reconhecida, por favor tente novamente!!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                #endregion
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("1 para equipamentos, 2 para chamados");
            MensagemEmVermelho("S PARA SAIR");
        }

        private static bool EhOpcaoSair(string opcao)
        {
            return opcao == "S";
        }

        private static bool ValidaData(int contadorEquipamento, DateTime[] dataFabricacaoEquipamento, string auxData)
        {
            return DateTime.TryParse(auxData, out dataFabricacaoEquipamento[contadorEquipamento]);
        }

        private static bool DecimalEhMaiorQueZero(int contadorEquipamento, decimal[] precoEquipamento)
        {
            return precoEquipamento[contadorEquipamento] < 00.00m;
        }

        private static bool EhVazioOuNulo(int contadorEquipamento, string[] atributoEquipamento)
        {
            return String.IsNullOrEmpty(atributoEquipamento[contadorEquipamento]);
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

using System;

namespace GestaoDeEquipamentos.ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int contadorEquipamento = 0, contadorChamado = 0;

            string[] nomeEquipamento = new string[10];
            string[] fabricanteEquipamento = new string[10];
            decimal[] precoEquipamento = new decimal[10];
            string[] numeroSerieEquipamento = new string[10];
            DateTime[] dataFabricacaoEquipamento = new DateTime[10];

            int[] idChamado = new int[10];
            string[] tituloChamado = new string[10];
            string[] descChamado = new string[10];
            string[] equipamentoChamado = new string[10];
            DateTime[] dataAberturaChamado = new DateTime[10];

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
                    opcao = Console.ReadLine();

                    bool confirmacao = true;

                    #region Adicionar Equipamento
                    if (opcao == "1")
                    {

                        Console.Clear();

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
                                    MensagemEmVermelho("O equipamento deve ter um numero de série, tente novamente!!");
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
                                    MensagemEmVermelho("O equipamento deve ter um fabricante, tente novamente!!");
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
                                    MensagemEmVermelho("O equipamento deve ter um preço, tente novamente!!");
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

                            contadorEquipamento++;
                        }

                    }
                    #endregion

                    #region Visualizar Equipamentos
                    else if (opcao == "2")
                    {
                        Console.Clear();
                        for (int i = 0; i < contadorEquipamento; i++)
                        {
                            if (nomeEquipamento[i] != null)
                            {
                                MostrarEquipamentos(nomeEquipamento, fabricanteEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, i);
                                Console.WriteLine("------------------------------------");
                            }
                        }
                        Console.ReadLine();

                        confirmacao = false;

                        Console.Clear();
                        continue;
                    }
                    #endregion

                    #region Editar Equipamento


                    else if (opcao == "3")
                    {
                        string auxNumSerie;
                        int auxIndice = 0;
                        bool encontrouEquipamento = true;
                        while (encontrouEquipamento == true)
                        {
                            encontrouEquipamento = false;
                            Console.WriteLine("Digite o numero de série do equipamento que deseja editar: ");
                            auxNumSerie = Console.ReadLine();
                            Console.Clear();
                            // Encontra o equipamento
                            for (int i = 0; i < numeroSerieEquipamento.Length; i++)
                            {
                                if (EncontraOEquipamentoComNumSerie(numeroSerieEquipamento, auxNumSerie, i))
                                {
                                    auxIndice = i;
                                    MensagemEmVermelho("Dados atuais:");
                                    MostrarEquipamentos(nomeEquipamento, fabricanteEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, i);

                                    Console.WriteLine("------------------------------------");

                                    auxIndice = i;
                                    encontrouEquipamento = true;
                                    break;
                                }
                            }
                            if (encontrouEquipamento == false)
                            {
                                MensagemEmVermelho("Equipamento não encontrado, tente novamente");
                            }

                            break;
                        }

                        Console.WriteLine("\nDigite o nome do equipamento: ");
                        nomeEquipamento[auxIndice] = Console.ReadLine();

                        if (NomeDeveTer6Caracteres(auxIndice, nomeEquipamento))
                        {
                            Console.Clear();
                            MensagemEmVermelho("O equipamento deve ter no mínimo 6 caracteres, tente novamente!!");
                            Console.ReadLine();
                            continue;
                        }

                        while (true)
                        {
                            Console.WriteLine("Digite o número série do equipamento: ");
                            numeroSerieEquipamento[auxIndice] = Console.ReadLine();
                            if (EhVazioOuNulo(auxIndice, numeroSerieEquipamento))
                            {
                                MensagemEmVermelho("O equipamento deve ter um numero de série, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Digite o fabricante do equipamento: ");
                            fabricanteEquipamento[auxIndice] = Console.ReadLine();
                            if (EhVazioOuNulo(auxIndice, fabricanteEquipamento))
                            {
                                MensagemEmVermelho("O equipamento deve ter um fabricante, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Digite o preco do equipamento: ");
                            precoEquipamento[auxIndice] = Convert.ToDecimal(Console.ReadLine());
                            if (DecimalEhMaiorQueZero(auxIndice, precoEquipamento))
                            {
                                MensagemEmVermelho("O equipamento deve ter um preço, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Digite a data de fabricação do equipamento: Ex.: 01/01/2001");
                            string auxData = Console.ReadLine();

                            bool verificaData = ValidaData(auxIndice, dataFabricacaoEquipamento, auxData);

                            if (verificaData == false)
                            {
                                MensagemEmVermelho("O equipamento deve ter uma data de fabricação válida, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }

                        Console.Clear();

                    }
                    #endregion

                    #region Excluir equipamento
                    else if (opcao == "4")
                    {
                        int auxIndiceEquipamento = 0;
                        string auxExcluirNumSerie, auxConfirmarExclusao;
                        bool auxAchouEquipamento = false;

                        while (true)
                        {
                            Console.WriteLine("Digite o numero de série do equipamento que deseja excluir: ");
                            auxExcluirNumSerie = Console.ReadLine();

                            for (int i = 0; i < numeroSerieEquipamento.Length; i++)
                            {
                                if (EncontraOEquipamentoComNumSerie(numeroSerieEquipamento, auxExcluirNumSerie, i))
                                {
                                    auxAchouEquipamento = true;
                                    auxIndiceEquipamento = i;
                                    Console.Clear();
                                    MostrarEquipamentos(nomeEquipamento, fabricanteEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, i);
                                    while (true)
                                    {
                                        MensagemEmVermelho("Deseja mesmo deletar o equipamento? (S para CONFIRMAR, N para CANCELAR)");
                                        auxConfirmarExclusao = Console.ReadLine().ToUpper();

                                        if (auxConfirmarExclusao != "S" && auxConfirmarExclusao != "N")
                                        {
                                            MensagemEmVermelho("Opção inválida, tente novamente!!");
                                            continue;
                                        }
                                        else
                                            break;
                                    }

                                    switch (auxConfirmarExclusao)
                                    {
                                        case "S":
                                            nomeEquipamento[auxIndiceEquipamento] = null; fabricanteEquipamento[auxIndiceEquipamento] = null; 
                                            precoEquipamento[auxIndiceEquipamento] = 00.00m; numeroSerieEquipamento[auxIndiceEquipamento] = null;
                                            MensagemEmVermelho("Equipamento deletado com sucesso!!"); break;
                                        case "N": MensagemEmVermelho("O equipamento não foi deletado!!"); break;
                                        default:
                                            break;
                                    }
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                            }
                            if (auxAchouEquipamento == false)
                            {
                                MensagemEmVermelho("Número de série não encontrado, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }
                    }
                    #endregion
                }
                #endregion

                #region Chamados
                else if (opcao == "2")
                {
                    Console.WriteLine("1 para criar, 2 para visualizar, 3 para editar, 4 para excluir");
                    MensagemEmVermelho("S PARA SAIR");
                    opcao = Console.ReadLine().ToUpper();

                    #region Adicionar chamado
                    if (opcao == "1")
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("Digite o título do chamado: ");
                            tituloChamado[contadorChamado] = Console.ReadLine();
                            if (EhVazioOuNulo(contadorChamado, tituloChamado))
                            {
                                MensagemEmVermelho("O chamado deve possuir um titulo, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }


                        while (true)
                        {
                            Console.WriteLine("Digite a descrição do chamado: ");
                            descChamado[contadorChamado] = Console.ReadLine();
                            if (EhVazioOuNulo(contadorChamado, descChamado))
                            {
                                MensagemEmVermelho("O chamado deve possuir uma descrição, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Digite o equipamento o chamado: ");
                            equipamentoChamado[contadorChamado] = Console.ReadLine();
                            if (EhVazioOuNulo(contadorChamado, equipamentoChamado))
                            {
                                MensagemEmVermelho("O chamado deve possuir um equipamento, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Digite a data de abertura do chamado: Ex.: 01/01/2001");
                            string auxData = Console.ReadLine();

                            bool verificaData = ValidaData(contadorChamado, dataAberturaChamado, auxData);

                            if (verificaData == false)
                            {
                                MensagemEmVermelho("O chamado deve possuir uma data de abertura válida, tente novamente!!");
                                continue;
                            }
                            else
                                break;
                        }
                        Console.Clear();

                        idChamado[contadorChamado] = contadorChamado;
                        MensagemEmVermelho("ID DO CHAMADO CRIADO: " + contadorChamado);
                        contadorChamado++;

                        Console.ReadLine();
                        Console.Clear();
                    }
                    #endregion

                    #region Visualizar chamado
                    else if (opcao == "2")
                    {
                        Console.Clear();
                        for (int i = 0; i < contadorChamado; i++)
                        {
                            if (tituloChamado[i] != null)
                            {
                                Console.WriteLine("Titulo do chamado: " + tituloChamado[i]);
                                Console.WriteLine("Equipamento do chamado: " + equipamentoChamado[i]);
                                Console.WriteLine("Data de abertura: " + dataAberturaChamado[i].ToString("dd/MM/yyyy"));
                                Console.WriteLine("Dias em aberto: " + (DateTime.Now - dataAberturaChamado[i]).ToString("dd") + "\n");
                                Console.WriteLine("------------------------------------");
                            }
                        }
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    #endregion

                    #region Editar chamado
                    else if (opcao == "3")
                    {
                        //string auxIdChamado = "";
                        int auxId = 0;

                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("Digite o ID do chamado que deseja editar: ");
                            auxId = Convert.ToInt32(Console.ReadLine());

                            if (tituloChamado[auxId] == null)
                            {
                                MensagemEmVermelho("Esse chamado não existe, tente novamente!!");
                                Console.ReadLine();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                MensagemEmVermelho("Dados atuais:");
                                MensagemEmVermelho($"ID do chamado: {idChamado[auxId]}");
                                Console.WriteLine("Titulo do chamado: " + tituloChamado[auxId]);
                                Console.WriteLine("Descrição do chamado: " + descChamado[auxId]);
                                Console.WriteLine("Equipamento: " + equipamentoChamado[auxId]);
                                Console.WriteLine("Data de abertura: " + dataAberturaChamado[auxId].ToString("dd/MM/yyyy") + "\n");

                                Console.WriteLine("------------------------------------");

                                MensagemEmVermelho("Novos dados:");
                                while (true)
                                {
                                    Console.WriteLine("Digite o título do chamado: ");
                                    tituloChamado[auxId] = Console.ReadLine();
                                    if (EhVazioOuNulo(auxId, tituloChamado))
                                    {
                                        MensagemEmVermelho("O chamado deve possuir um titulo, tente novamente!!");
                                        continue;
                                    }
                                    else
                                        break;
                                }


                                while (true)
                                {
                                    Console.WriteLine("Digite a descrição do chamado: ");
                                    descChamado[auxId] = Console.ReadLine();
                                    if (EhVazioOuNulo(auxId, descChamado))
                                    {
                                        MensagemEmVermelho("O chamado deve possuir uma descrição, tente novamente!!");
                                        continue;
                                    }
                                    else
                                        break;
                                }

                                while (true)
                                {
                                    Console.WriteLine("Digite o equipamento o chamado: ");
                                    equipamentoChamado[auxId] = Console.ReadLine();
                                    if (EhVazioOuNulo(auxId, equipamentoChamado))
                                    {
                                        MensagemEmVermelho("O chamado deve possuir um equipamento, tente novamente!!");
                                        continue;
                                    }
                                    else
                                        break;
                                }

                                while (true)
                                {
                                    Console.WriteLine("Digite a data de abertura do chamado: Ex.: 01/01/2001");
                                    string auxData = Console.ReadLine();

                                    bool verificaData = ValidaData(auxId, dataAberturaChamado, auxData);

                                    if (verificaData == false)
                                    {
                                        MensagemEmVermelho("O chamado deve possuir uma data de abertura válida, tente novamente!!");
                                        continue;
                                    }
                                    else
                                        break;
                                }
                                Console.Clear();
                            }
                            break;
                        }
                    }
                    #endregion

                    #region Excluir chamado
                    else if (opcao == "4")
                    {
                        int auxExcluirId = 0;
                        string auxConfirmarExclusao;

                        Console.Clear();

                        while (true)
                        {
                            Console.WriteLine("Digite o ID do chamado que deseja excluir: ");
                            auxExcluirId = Convert.ToInt32(Console.ReadLine());

                            if (tituloChamado[auxExcluirId] != null)
                            {
                                while (true)
                                {
                                    MensagemEmVermelho("Deseja mesmo deletar o chamado? (S para CONFIRMAR, N para CANCELAR)");
                                    auxConfirmarExclusao = Console.ReadLine().ToUpper();

                                    if (auxConfirmarExclusao != "S" && auxConfirmarExclusao != "N")
                                    {
                                        MensagemEmVermelho("Opção inválida, tente novamente!!");
                                        Console.ReadLine();
                                        Console.Clear();
                                        continue;
                                    }
                                    else
                                        break;
                                }
                                switch (auxConfirmarExclusao)
                                {
                                    case "S":
                                        tituloChamado[auxExcluirId] = null; descChamado[auxExcluirId] = null; equipamentoChamado[auxExcluirId] = null;
                                        MensagemEmVermelho("Chamado deletado com sucesso!!"); break;
                                    case "N": MensagemEmVermelho("O chamado não foi deletado!!"); break;
                                    default:
                                        break;
                                }
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                MensagemEmVermelho("Id não encontrado, tente novamente!!");
                                Console.ReadLine();
                                Console.Clear();
                                continue;
                            }
                        }
                    }
                    #endregion
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

        private static bool EncontraOEquipamentoComNumSerie(string[] numeroSerieEquipamento, string auxNumSerie, int i)
        {
            return numeroSerieEquipamento[i] == auxNumSerie;
        }

        private static void MostrarEquipamentos(string[] nomeEquipamento, string[] fabricanteEquipamento, decimal[] precoEquipamento, string[] numeroSerieEquipamento, DateTime[] dataFabricacaoEquipamento, int i)
        {
            Console.WriteLine("Numero de série: " + numeroSerieEquipamento[i]);
            Console.WriteLine("Nome do equipamento: " + nomeEquipamento[i]);
            Console.WriteLine("Preço do equipamento: " + precoEquipamento[i]);
            Console.WriteLine("Fabricante: " + fabricanteEquipamento[i]);
            Console.WriteLine("Data de fabricação: " + dataFabricacaoEquipamento[i].ToString("dd/MM/yyyy") + "\n");
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

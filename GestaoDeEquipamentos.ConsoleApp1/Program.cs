using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 para equipamentos, 2 para chamados");
                MenuSParaSair("S PARA SAIR");
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
                    MenuSParaSair("S PARA SAIR");

                    Console.ReadLine();
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("1 para criar, 2 para visualizar, 3 para editar, 4 para excluir");
                    MenuSParaSair("S PARA SAIR");

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

        private static void MenuSParaSair(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}

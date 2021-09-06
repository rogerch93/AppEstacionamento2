using System;

namespace AppEstacionamento2
{
    class Program
    {
        static CarroRepositorio repositorio = new CarroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterLista();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        InserirCarros();
                        break;
                    case "2":
                        ListarCarros();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }
        }
        
        //Interface Visual do Sistema.
        private static string obterLista()
        {
            Console.WriteLine();
            Console.WriteLine("     " + "***SITEMA PARA ESTACIONAMENTO***");
            Console.WriteLine("     " + "----------------------------------");
            Console.WriteLine();
            Console.WriteLine("     " + " Informe qual opção desejada");
            Console.WriteLine("     " + "==================================");
            Console.WriteLine("     " + " 1 - Inserir novo veiculo:");
            Console.WriteLine("     " + "==================================");
            Console.WriteLine("     " + " 2 - Listar veiculos:");
            Console.WriteLine("     " + "==================================");
            Console.WriteLine("     " + " X - Sair");
            Console.WriteLine();

            string opcaoCarros = Console.ReadLine();
            return opcaoCarros;
        }
    }
}

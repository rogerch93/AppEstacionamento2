using AppEstacionamento.NET3;
using System;

namespace AppEstacionamento.NET3
{
    class Program
    {
        static CarroRepositorio repositorio = new CarroRepositorio();
        static Validacao validar = new Validacao();
        

        static void Main(string[] args)
        {
            string opcaoUsuario = obterLista();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        InserirCarros();
                        break;
                    case "2":
                        ListarCarros();
                        break;
                    case "3":
                        AtualizarCarros();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterLista();
            }
        }

        private static void AtualizarCarros()
        {
            Console.WriteLine("Id do carro");
            int indeceCarro = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o estilo e carro: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o modelo: ");
            string entradaModelo = Console.ReadLine();

            Console.WriteLine("Digite a marca do veiculo: ");
            string entradaMarca = Console.ReadLine();

            Console.WriteLine("Digite a placa do veiculo: ");
            string entradaPlaca = Console.ReadLine();

            Console.WriteLine("Digite o nome do proprietario: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Cpf do proprietario: ");
            string entradaCpf = Console.ReadLine();

            Console.WriteLine("Digite o numero da vaga: ");
            string entradaVaga = Console.ReadLine();

            Console.WriteLine("Digite a hora de entrada: ");
            string entradaHora = Console.ReadLine();

            CarroPessoa atualizaCarro = new CarroPessoa(id: indeceCarro,
                                                          genero: (Genero)entradaGenero,
                                                          marca: entradaMarca,
                                                          placa: entradaPlaca,
                                                          nomePessoa: entradaNome,
                                                          cpf: entradaCpf,
                                                          numVaga: entradaVaga,
                                                          horaEntrada: entradaHora);
            repositorio.Atualiza(indeceCarro,atualizaCarro);
        }

        private static void InserirCarros()
        {
            Console.WriteLine("Inserir cliente");
            
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o estilo e carro: ");
             int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o modelo: ");
            string entradaModelo = Console.ReadLine();

            Console.WriteLine("Digite a marca do veiculo: ");
            string entradaMarca = Console.ReadLine();

            Console.WriteLine("Digite a placa do veiculo: ");
            string entradaPlaca = Console.ReadLine();

            Console.WriteLine("Digite o nome do proprietario: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Cpf do proprietario: ");
            bool cpf = Validacao.validar(Console.ReadLine());
            string entradaCpf = Convert.ToString(cpf);
            while (cpf == false)
            {
                cpf = Validacao.validar(Console.ReadLine());
                if(cpf == false)
                {
                    Console.WriteLine("CPF invalido!");
                }
            }
            Console.WriteLine("Digite o numero da vaga: ");
            string entradaVaga = Console.ReadLine();

            Console.WriteLine("Digite a hora de entrada: ");
            string entradaHora = Console.ReadLine();

            CarroPessoa novoCarroPessoa = new CarroPessoa(id: repositorio.ProximoId(),
                                                          genero: (Genero)entradaGenero,
                                                          marca: entradaMarca,
                                                          placa: entradaPlaca,
                                                          nomePessoa: entradaNome,
                                                          cpf: entradaCpf,
                                                          numVaga: entradaVaga,
                                                          horaEntrada: entradaHora
                                                          );
            repositorio.Insere(novoCarroPessoa);
        }

        private static void ListarCarros()
        {
            Console.WriteLine("Listar Carros");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum veiculo esta cadastrado ainda.");
                return;
         
            }
            foreach (var carro in lista)
            {
                var excluido = carro.retornaExcluido();

                Console.WriteLine();
                Console.WriteLine("#ID: {0}: - {1}");
                Console.WriteLine("Numero da Vaga: " + carro.retornaVaga());
                Console.WriteLine("Nome do Cliente: " + carro.retornaNomePessoa());
                Console.WriteLine("Placa: " + carro.retornaPlaca());
                Console.WriteLine("Hora de Entrada: " + carro.retornaHoraEntrada());
                Console.WriteLine();
            } 
        }
        
        private static string obterLista()
        {
            Console.WriteLine();
            Console.WriteLine("   " + "****SISTEMA DE VAGAS PARA ESTACIONAMENTO****");
            Console.WriteLine("   " + "------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("   " + "Informe a opção desejada");
            Console.WriteLine("   " + "================================================");
            Console.WriteLine("   " + "1-Inserir veiculo em uma vaga do estacionamento:");
            Console.WriteLine("   " + "================================================");
            Console.WriteLine("   " + "2-Listar todos os veiculos cadastrados:");
            Console.WriteLine("   " + "================================================");
            Console.WriteLine("   " + "X-Sair da Aplicação");
            Console.WriteLine();

            string opcaoCarros = Console.ReadLine();
            return opcaoCarros;
        }
    }
}

using System;

namespace AppEstacionamento.NET3
{
    class Program
    {
        static CarroRepositorio repositorio = new CarroRepositorio();

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
                    case "4":
                        ExcluirCliente();
                        break;
                    case "5":
                        VisualizarLista();
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

        private static void VisualizarLista()
        {
            Console.WriteLine("Digite o Id do cliente para ver a situação:");
            int indeceCliente = int.Parse(Console.ReadLine());

            var cliente = repositorio.RetornaPorId(indeceCliente);

            Console.WriteLine(cliente);
        }

        private static void ExcluirCliente()
        {
            Console.WriteLine("Digite o id da do cliente: ");
            int idDoCliente = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja Emitir valor para algum cliente ?: Y/N");
            if (Console.ReadKey(true).Key != ConsoleKey.Y)
            {
                obterLista();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("  " + "Insira o horario de entrada contido em lista:");
                string entradaHora = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine(" " + "Insira o horario de saida:");
                string entradaHoraSaida = Console.ReadLine();

                Console.WriteLine();

                TimeSpan parsed1 = TimeSpan.Parse(entradaHora);
                TimeSpan parsed2 = TimeSpan.Parse(entradaHoraSaida);

                var soma = parsed1 - parsed2;

                Console.WriteLine("  " + "Horas consumidas no estacionamento:");
                Console.WriteLine(soma);

                Console.WriteLine();

                Console.WriteLine("  " + "Informe as horas que o veiculo ficou no estacionamento");
                string entradaTotal = Console.ReadLine();
               
                var valor = Convert.ToDouble(entradaTotal) * 5;

                Console.WriteLine();

                Console.WriteLine("  " + "Valor a ser pago: R$" + valor + ",00");
                CarroPessoa excluirCliente = new CarroPessoa(horaSaida: entradaHoraSaida,
                                                             horaEntrada: entradaHora,
                                                             total: entradaTotal);
                repositorio.Insere(excluirCliente);
            }

            repositorio.Exclui(idDoCliente);
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
                                                          modelo: entradaModelo,
                                                          marca: entradaMarca,
                                                          placa: entradaPlaca,
                                                          nomePessoa: entradaNome,
                                                          cpf: entradaCpf,
                                                          numVaga: entradaVaga,
                                                          horaEntrada: entradaHora
                                                          );
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
            while (cpf != true)
            {
                cpf = Validacao.validar(Console.ReadLine());
                if(cpf != true)
                {
                    Console.WriteLine("CPF invalido!");
                }
            }
            Console.WriteLine("Digite o numero da vaga: ");
            string entradaVaga = Console.ReadLine();

            Console.WriteLine("Digite a hora de entrada: ");
            string entradaHora = Console.ReadLine();

            CarroPessoa inserirCarroPessoa = new CarroPessoa(id: repositorio.ProximoId(),
                                                          genero: (Genero)entradaGenero,
                                                          marca: entradaMarca,
                                                          modelo: entradaModelo,
                                                          placa: entradaPlaca,
                                                          nomePessoa: entradaNome,
                                                          cpf: entradaCpf,
                                                          numVaga: entradaVaga,
                                                          horaEntrada: entradaHora
                                                          );
            repositorio.Insere(inserirCarroPessoa);
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
                var excluido = carro.RetornaExcluido();
                if (!string.IsNullOrEmpty(carro.RetornaNomePessoa()))
                {
                    Console.WriteLine();
                    Console.WriteLine("#ID: " + carro.RetornaId());
                    Console.WriteLine("Estilo de Carro: " + carro.RetornaGenero());
                    Console.WriteLine("Modelo: " + carro.RetornaModelo());
                    Console.WriteLine("Placa: " + carro.RetornaPlaca());
                    Console.WriteLine("Numero da Vaga: " + carro.RetornaVaga());
                    Console.WriteLine("Nome do Cliente: " + Convert.ToString(carro.RetornaNomePessoa()));
                    Console.WriteLine("CPF: " + carro.RetornaCPF());
                    Console.WriteLine("Hora de Entrada: " + carro.RetornaHoraEntrada());
                    Console.WriteLine();
                }
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
            Console.WriteLine("   " + "3-Atualizar os veiculos cadastrados:");
            Console.WriteLine("   " + "================================================");
            Console.WriteLine("   " + "4-Excluir veiculos cadastrados:");
            Console.WriteLine("   " + "================================================");
            Console.WriteLine("   " + "5-Conferir situação de clientes no estacionamento:");
            Console.WriteLine("   " + "================================================");
            Console.WriteLine("   " + "X-Sair da Aplicação");
            Console.WriteLine();

            string opcaoCarros = Console.ReadLine();
            return opcaoCarros;
        }
    }
}

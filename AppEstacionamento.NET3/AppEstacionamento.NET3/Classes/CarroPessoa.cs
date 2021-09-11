using System;

namespace AppEstacionamento.NET3
{
    public class CarroPessoa : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Modelo { get; set; }
        private string Marca { get; set; }
        private string Placa { get; set; }
        private string NomePessoa { get; set; }
        private string Cpf { get; set; }
        private string NumVaga { get; set; }
        private string HoraEntrada { get; set; }
        private string HoraSaida { get; set; }
        private string Total { get; set; }
        private bool Pago { get; set; }

        public CarroPessoa(int id, Genero genero, string modelo, string marca, string placa, string nomePessoa, string cpf, string numVaga,
        string horaEntrada, string horaSaida, string total)
        {
            this.Id = id;
            this.Genero = genero;
            this.Modelo = modelo;
            this.Marca = marca;
            this.Placa = placa;
            this.NomePessoa = nomePessoa;
            this.Cpf = cpf;
            this.NumVaga = numVaga;
            this.HoraEntrada = horaEntrada;
            this.HoraSaida = horaSaida;
            this.Total = total;
            this.Pago = false;
        }

        public CarroPessoa(int id, Genero genero, string marca, string placa, string nomePessoa, string cpf, string numVaga, string horaEntrada)
        {
            Id = id;
            Genero = genero;
            Marca = marca;
            Placa = placa;
            NomePessoa = nomePessoa;
            Cpf = cpf;
            NumVaga = numVaga;
            HoraEntrada = horaEntrada;
        }


        public CarroPessoa(string horaSaida, string horaEntrada, string total)
        {
            HoraSaida = horaSaida;
            HoraEntrada = horaEntrada;
            Total = total;
        }

        public CarroPessoa(int id, Genero genero, string modelo, string marca, string placa, string nomePessoa, string cpf, string numVaga, string horaEntrada)
        {
            Id = id;
            Genero = genero;
            Modelo = modelo;
            Marca = marca;
            Placa = placa;
            NomePessoa = nomePessoa;
            Cpf = cpf;
            NumVaga = numVaga;
            HoraEntrada = horaEntrada;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Modelo: " + Modelo + Environment.NewLine;
            retorno += "Marca: " + Marca + Environment.NewLine;
            retorno += "Placa: " + Placa + Environment.NewLine;
            retorno += "Nome do Cliente: " + NomePessoa + Environment.NewLine;
            retorno += "CPF: " + Cpf + Environment.NewLine;
            retorno += "Numero da Vaga: " + NumVaga + Environment.NewLine;
            retorno += "Pago: " + Pago;
            return retorno;
        }

        public string RetornaCPF()
        {
            return Cpf;
        }

        public int RetornaId()
        {
            return Id;
        }

        public bool RetornaExcluido()
        {
            return Pago;
        }

        public string RetornaModelo()
        {
            return Modelo;
        }

        public string RetornaNomePessoa()
        {
            return NomePessoa;
        }

        public string RetornaHoraEntrada()
        {
            return HoraEntrada;
        }

        public string RetornaPlaca()
        {
            return Placa;
        }

        public string RetornaVaga()
        {
            return NumVaga;
        }

        public Genero RetornaGenero()
        {
            return Genero;
        }

        public string RetornaHoraSaida()
        {
            return HoraSaida;
        }

        public string RetornaTotal()
        {
            return Total;
        }

        public void Exclui()
        {
            Pago = true;
        }
    }
}

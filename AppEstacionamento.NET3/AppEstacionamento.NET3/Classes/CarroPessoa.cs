using AppEstacionamento.NET3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento.NET3
{
    public class CarroPessoa : EntidadeBase
    {
        private object horaEntrada;

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


        public CarroPessoa(string horaSaida, object horaEntrada, string total)
        {
            HoraSaida = horaSaida;
            this.horaEntrada = horaEntrada;
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
            this.horaEntrada = horaEntrada;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Modelo: " + this.Modelo + Environment.NewLine;
            retorno += "Marca: " + this.Marca + Environment.NewLine;
            retorno += "Placa: " + this.Placa + Environment.NewLine;
            retorno += "Nome do Cliente: " + this.NomePessoa + Environment.NewLine;
            retorno += "CPF: " + this.Cpf + Environment.NewLine;
            retorno += "Numero da Vaga: " + this.NumVaga + Environment.NewLine;
            retorno += "Hora de Entrada: " + this.HoraEntrada + Environment.NewLine;
            retorno += "Hora de Saida: " + this.HoraSaida + Environment.NewLine;
            retorno += "Total: " + this.Total + Environment.NewLine;
            return retorno;
        }

        public string retornaCPF()
        {
            return this.Cpf;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Pago;
        }

        public string retornaModelo()
        {
            return this.Modelo;
        }

        public string retornaNomePessoa()
        {
            return this.NomePessoa;
        }

        public string retornaHoraEntrada()
        {
            return this.HoraEntrada;
        }

        public string retornaPlaca()
        {
            return this.Placa;
        }

        public string retornaVaga()
        {
            return this.NumVaga;
        }

        public Genero retornaGenero()
        {
            return this.Genero;
        }

        public string retornaHoraSaida()
        {
            return this.HoraSaida;
        }

        public string retornaTotal()
        {
            return this.Total;
        }

        public void Exclui()
        {
            this.Pago = true;
        }
    }
}

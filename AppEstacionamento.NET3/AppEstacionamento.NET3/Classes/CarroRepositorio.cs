using CRUD.Series.Interfaces;
using System.Collections.Generic;


namespace AppEstacionamento.NET3
{
    public class CarroRepositorio : ICarros<CarroPessoa>
    {
        private List<CarroPessoa> listaCarroPessoa = new List<CarroPessoa>();
        public void Atualiza(int id, CarroPessoa objeto)
        {
            listaCarroPessoa[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaCarroPessoa[id].Exclui();
        }

        public void Insere(CarroPessoa objeto)
        {
            listaCarroPessoa.Add(objeto);
        }

        public List<CarroPessoa> Lista()
        {
            return listaCarroPessoa;
        }

        public int ProximoId()
        {
            return listaCarroPessoa.Count;
        }

        public CarroPessoa RetornaPorId(int id)
        {
            return listaCarroPessoa[id];
        }
    }
}

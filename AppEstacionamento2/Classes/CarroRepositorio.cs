using AppEstacionamento2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento2
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

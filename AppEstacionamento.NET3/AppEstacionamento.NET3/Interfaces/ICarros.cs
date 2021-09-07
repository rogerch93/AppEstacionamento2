using System;
using System.Collections.Generic;
using System.Text;

namespace AppEstacionamento.NET3
{
    interface ICarros<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T enteidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        void ProximoId();
    }
}

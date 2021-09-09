using System;
using System.Collections.Generic;
using System.Text;

namespace AppEstacionamento.NET3
{
   public class Validacao
    {
        public static bool validar(string v)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temCpf;
            string digito;
            string cpf;
            int soma;
            int resto;
 
            cpf = v;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            if (cpf.Length != 11)
                return false;
            temCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(temCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();

            temCpf = temCpf + digito;

            soma = 0;
            for(int i = 0; i < 10; i++)
            {
                soma += int.Parse(temCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            
            return cpf.EndsWith(digito);
        }
    }
}

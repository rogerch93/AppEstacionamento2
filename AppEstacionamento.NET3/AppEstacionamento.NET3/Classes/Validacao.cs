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

            string invalido1 = "99999999999";
            string invalido2 = "88888888888";
            string invalido3 = "77777777777";
            string invalido4 = "66666666666";
            string invalido5 = "55555555555";
            string invalido6 = "44444444444";
            string invalido7 = "33333333333";
            string invalido8 = "22222222222";
            string invalido9 = "11111111111";
 
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
            
            if (digito == invalido1)
            {
                Console.WriteLine("Cpf Invalido!");

                if(digito == invalido2)
                {
                    Console.WriteLine("Cpf Invalido!");
                }
                if(digito == invalido3)
                {
                    Console.WriteLine("Cpf Invalido!");
                }
                if (digito == invalido4)
                {
                    Console.WriteLine("Cpf Invalido!");
                }
                if (digito == invalido5)
                {
                    Console.WriteLine("Cpf Invalido!");
                }
                if (digito == invalido6)
                {
                    Console.WriteLine("Cpf Invalido!");
                }
                if (digito == invalido7)
                {
                    Console.WriteLine("Cpf Invalido!");
                }
                if (digito == invalido8)
                {
                    Console.WriteLine("Cpf Invalido!");
                }
                if (digito == invalido9)
                {
                    Console.WriteLine("Cpf Invalido!");
                }
            }
            return cpf.EndsWith(digito);
        }
    }
}

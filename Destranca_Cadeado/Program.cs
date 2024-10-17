using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destranca_Cadeado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.Write("" +
                    "1 - Iniciar\n2 - Regras \nDigite a opçao desejada:");
                     op = int.Parse(Console.ReadLine());
                if (op >=3)
                {
                    Console.WriteLine("Digito incorreto, selecione 1 ou 2. \n");
                }
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Iniciando Jogo");
                    break;

                    case 2:
                        Console.WriteLine("Regras do Jogo \n");
                        Console.WriteLine("Ao iniciar o jogo selecione quantos digitos vai ter, para que a senha seja descoberta,\na quantidade de tentativas será igual a quantidade de digitos. \n");
                        Console.WriteLine("Jogador ganha quando descobrir todos os digitos para destravar o cadeado antes do acabar todas as tentativas. \n");
                    break;                
                }
            }
            while (op != 1);
            int d, tentativa;
            Console.Write("Digite quantos digitos terá o cadeado: ");
            d=int.Parse(Console.ReadLine());
            tentativa = d*2;

            int[] cadeado = new int[d];
            int[] Descobrir = new int[d];
            Random rand = new Random();

            for(int i = 0; i < cadeado.Length; i++)
            {
                cadeado[i] = rand.Next(0,9);
            }
            Console.WriteLine("Começando o jogo");
            bool jogoVencido = false;
            while (tentativa !=0 && !jogoVencido)
            {
                int digitoCerto = 0;
                for (int i = 0; i < Descobrir.Length; i++)
                {
                    int digito = 0;
                    Console.Write($"Digite o {i + 1}° numero: ");
                    digito = int.Parse(Console.ReadLine());
                    Descobrir[i] = digito ;
                    if (digito == cadeado[i])
                    {
                        Console.WriteLine("O numero esta correto.");
                        digitoCerto++;
                        tentativa--;
                        Console.WriteLine($" De {d * 2} tentativas so restam: {tentativa}");
                    }
                    else
                    {
                        Console.WriteLine("Numero incorreto");
                        tentativa--;
                        Console.WriteLine($" De {d * 2} tentativas so restam: {tentativa}");
                        if (tentativa == 0)
                        {
                            Console.WriteLine($"Voce perdeu, Suas tentativas chegaram a 0");
                            Console.WriteLine("A senha do cadeado era: ");
                            for (int j = 0; j < cadeado.Length; j++)
                            {
                                Console.Write(" " +cadeado[j] +"\n");
                            }
                            Console.WriteLine("Sua combinaçao de senha foi: ");
                            for (int j = 0; j < cadeado.Length; j++)
                            {
                                Console.Write(" " + Descobrir[j] +"\n" );
                            }
                           break;
                        }
                    } 
                }
                if(digitoCerto == d)
                {
                    Console.WriteLine("A senha do cadeado era: ");
                    for (int j = 0; j < cadeado.Length; j++)
                    {
                        Console.Write(" " + cadeado[j] +"\n");
                    }
                    Console.WriteLine("Sua combinaçao de senha foi: ");
                    for (int j = 0; j < cadeado.Length; j++)
                    {
                        Console.Write(" " +Descobrir[j] + "\n");
                    }
                    Console.WriteLine("Parabéns! Você destravou o cadeado!");
                    jogoVencido |= true;
                }
            }
            Console.ReadKey();
        }
    }
}

using Microsoft.SqlServer.Server;
using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Linq;
using System.Reflection;
using System.Text;

using System.Threading.Tasks;

using System.Xml;



namespace jogo_da_velha

{
    internal class Program
    {
        static char p1 = '1', p2 = '2', p3 = '3', p4 = '4', p5 = '5', p6 = '6', p7 = '7', p8 = '8', p9 = '9';
        static string nome1, nome2;
        static char O = 'O', X = 'X';
        static string jogadorAtual;
        static char simboloAtual = 'X';
        static int Jogadas = 0;

        static void Main(string[] args)
        {
            Iniciar();
            Jogo();
        }
        static void Iniciar()
        {
            Console.Write("Insira o nome do Jogador 1: ");
            nome1 = (Console.ReadLine());
            jogadorAtual = nome1;

            Console.Write("Insira o nome do jogador 2: ");
            nome2 = (Console.ReadLine());
        }
        static void Tabuleiro()
        {
            Console.WriteLine("        |        |       ");

            Console.WriteLine($"   {p1}    |    {p2}   |   {p3}   ");

            Console.WriteLine("--------|--------|-------");

            Console.WriteLine($"   {p4}    |    {p5}   |   {p6}   ");

            Console.WriteLine("--------|--------|-------");

            Console.WriteLine($"   {p7}    |    {p8}   |   {p9}   ");

            Console.WriteLine("        |        |       ");
        }
        static void Jogo()
        {
            bool continua = true;
            do
            {
                Console.Clear();
                Tabuleiro();

                Console.WriteLine("");
                Console.Write($"{jogadorAtual}, informe o número da posição que deseja: ");
                int opcao = int.Parse(Console.ReadLine());

                if (VerificaJogada(opcao))
                {
                    Jogadas++;
                    AtualizaMapa(opcao, simboloAtual);

                    if (Vitoria())
                    {
                        Console.Clear();
                        Tabuleiro();
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(jogadorAtual + " ganhou!!");
                        Console.ResetColor();
                        Console.WriteLine("");
                        continua = false;
                    }
                    else if (Empate())
                    {
                        Console.Clear();
                        Tabuleiro();
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Velha!! Ninguém ganhou.");
                        Console.ResetColor();
                        Console.WriteLine("");
                        continua = false;
                    }
                    else
                    {
                        MudaJogador();
                    }
                }
            } while (continua);
        }
        static void AtualizaMapa(int p, char op)
        {
            if (p == 1)
            {
                p1 = op;
            }
            else if (p == 2)
            {
                p2 = op;
            }
            else if (p == 3)
            {
                p3 = op;
            }
            else if (p == 4)
            {
                p4 = op;
            }
            else if (p == 5)
            {
                p5 = op;
            }
            else if (p == 6)
            {
                p6 = op;
            }
            else if (p == 7)
            {
                p7 = op;
            }
            else if (p == 8)
            {
                p8 = op;
            }
            else if (p == 9)
            {
                p9 = op;
            }
        }
        static bool VerificaJogada(int v)
        {
            if (v == 1 && p1 == '1')
            {
                return true;
            }
            else if (v == 2 && p2 == '2')
            {
                return true;
            }
            else if (v == 3 && p3 == '3')
            {
                return true;
            }
            else if (v == 4 && p4 == '4')
            {
                return true;
            }
            else if (v == 5 && p5 == '5')
            {
                return true;
            }
            else if (v == 6 && p6 == '6')
            {
                return true;
            }
            else if (v == 7 && p7 == '7')
            {
                return true;
            }
            else if (v == 8 && p8 == '8')
            {
                return true;
            }
            else if (v == 9 && p9 == '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool Vitoria()
        {
            if (p1 == p2 && p2 == p3)
            {
                return true;
            }
            else if (p4 == p5 && p5 == p6)
            {
                return true;
            }
            else if (p7 == p8 && p8 == p9)
            {
                return true;
            }
            else if (p1 == p4 && p4 == p7)
            {
                return true;
            }
            else if (p2 == p5 && p5 == p8)
            {
                return true;
            }
            else if (p3 == p6 && p6 == p9)
            {
                return true;
            }
            else if (p1 == p5 && p5 == p9)
            {
                return true;
            }
            else if (p3 == p5 && p5 == p7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool Empate()
        {
            if (Jogadas < 7)
            {
                return false;
            }
            else
            {
                bool empate =
                  (p1 == '1' || p2 == '2' || p3 == '3') && (p1 == p2 || p2 == p3 || p1 == p3) ||
                  (p4 == '4' || p5 == '5' || p6 == '6') && (p4 == p5 || p5 == p6 || p4 == p6) ||
                  (p7 == '7' || p8 == '8' || p9 == '9') && (p7 == p8 || p8 == p9 || p7 == p9) ||
                  (p1 == '1' || p4 == '4' || p7 == '7') && (p1 == p4 || p4 == p7 || p1 == p7) ||
                  (p2 == '2' || p5 == '5' || p8 == '8') && (p2 == p5 || p5 == p8 || p2 == p8) ||
                  (p3 == '3' || p6 == '6' || p9 == '9') && (p3 == p6 || p6 == p9 || p3 == p9) ||
                  (p1 == '1' || p5 == '5' || p9 == '9') && (p1 == p5 || p5 == p9 || p1 == p9) ||
                  (p3 == '3' || p5 == '5' || p7 == '7') && (p3 == p5 || p5 == p7 || p3 == p7);
                return true;
            }
        }
        static void MudaJogador()
        {
            if (jogadorAtual == nome1)
            {
                jogadorAtual = nome2;
                simboloAtual = 'O';
            }
            else
            {
                jogadorAtual = nome1;
                simboloAtual = 'X';
            }
        }
    }
}
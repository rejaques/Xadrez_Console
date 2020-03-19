using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace CHESS
{
    class Tela
    {

        public static void ImprimirPartida(PartidaXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);

            ImprimirPecasCapturadas(partida);

            Console.WriteLine("\n\nTurno: "
                + partida.Turno
                + "\n\nAguardando jogada: "
                + partida.JogadorAtual);
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("\nPeças capturadas: ");
            Console.WriteLine("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));

            ConsoleColor aux = Console.ForegroundColor;
            Console.WriteLine("\nPretas: ");
            Console.ForegroundColor = ConsoleColor.Red;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            
            Console.ForegroundColor = aux;
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            
            foreach(Peca x in conjunto)
            {
                Console.Write(x + ", ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + "  ");
                for(int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.peca(i, j));    
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + "  ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j] == true)
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;

                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicao()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca p)
        {
            if (p == null)
                Console.Write("- ");
            else
            {
                if (p.Cor == Cor.Branca)
                {
                    Console.Write(p + " ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(p + " ");
                    Console.ForegroundColor = aux;
                }
            }
        }
    }
}

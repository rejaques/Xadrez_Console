using System;
using tabuleiro;
using xadrez;

namespace CHESS
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + "  ");
                for(int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        ImprimirPeca(tab.peca(i, j));
                    }
                        
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
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

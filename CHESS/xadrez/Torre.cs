using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override string ToString()
        {
            return "T";
        }

        
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Verificar acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.Posicaovalida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                    break;
                pos.Linha -= 1;
            }

            //Verificar abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.Posicaovalida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                    break;
                pos.Linha += 1;
            }

            //Verificar direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.Posicaovalida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                    break;
                pos.Coluna += 1;
            }

            //Verificar esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.Posicaovalida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                    break;
                pos.Coluna -= 1;
            }

            return mat;
        }
    }
}

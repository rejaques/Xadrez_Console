using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Verificar acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.Posicaovalida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Verificar direita acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.Posicaovalida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Verificar direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.Posicaovalida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Verificar direita baixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.Posicaovalida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Verificar abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.Posicaovalida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Verificar esquerda abaixo 
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.Posicaovalida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Verificar esquerda 
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.Posicaovalida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Verificar esquerda acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.Posicaovalida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            return mat;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez Partida;

        public Rei(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor, tab)
        {
            Partida = partida;
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

        private bool TesteTorreRoque(Posicao pos)
        {
            Peca p = Tab.peca(pos);

            return (p != null) && (p is Torre) && (p.Cor == Cor) && (p.QtdMovimentos == 0);
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

            //Roque
            if(QtdMovimentos == 0 && !Partida.Xeque)
            {
                //Roque pequeno
                Posicao posTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);

                if(TesteTorreRoque(posTorre1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                }

                //Roque grande
                Posicao posTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);

                if (TesteTorreRoque(posTorre2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }
            return mat;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }
        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0,0);

            // acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(pos) && podeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna+1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;


            // Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna -1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // esquerda
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna -1 );
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez_Console.tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QuantMovimetnos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;            
            Tabuleiro = tabuleiro;
            QuantMovimetnos = 0;
        }
        public abstract bool[,] MovimentosPossiveis();
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Linhas; j++)
                {
                    if(mat[i,j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void IncrementarQntMovimentos()
        {
            QuantMovimetnos++;
        }
    }
}

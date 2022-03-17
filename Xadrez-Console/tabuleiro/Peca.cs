using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez_Console.tabuleiro
{
    internal class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QuantMovimetnos { get; set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = posicao;
            Cor = cor;            
            Tabuleiro = tabuleiro;
            QuantMovimetnos = 0;
        }

    }
}

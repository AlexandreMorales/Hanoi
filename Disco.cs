using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Disco : IDisco
    {
        private int tamanhoTorre;
        public Disco(int t, int tt)
            : base(t)
        {
            tamanhoTorre = tt;
            criaForma();
        }
        protected override void criaForma()
        {
            for (int i = 0; i < tamanhoTorre; i++)
                forma += " ";
            forma += "|";
            for (int i = 0; i < tamanho; i++)
                forma += "_";
            forma += "|";
            for (int i = 0; i < tamanhoTorre; i++)
                forma += " ";
        }
    }
}

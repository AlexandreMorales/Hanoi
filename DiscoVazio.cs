using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class DiscoVazio : IDisco
    {
        public DiscoVazio(int t)
            : base(t)
        {
            criaForma();
        }
        protected override void criaForma()
        {
            for (int i = 0; i < tamanho; i++)
                forma += " ";
        }
    }
}

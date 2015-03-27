using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    abstract class IDisco
    {
        public int tamanho { get; set; }
        public string forma { get; set; }
        public IDisco(int t)
        {
            forma = "";
            tamanho = (t * 2) + 1;
        }
        protected abstract void criaForma();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Torre
    {
        public List<IDisco> torre { get; set; }
        public int tamanho { get; set; }
        public Torre(int t)
        {
            torre = new List<IDisco>();
            tamanho = t;
        }
        public void PopulaTorre()
        {
            for (int i = 0; i < tamanho; i++)
            {
                if (i == 0) { torre.Add(new DiscoVazio(tamanho - 1)); }
                else { torre.Add(new Disco(i - 1, tamanho - 1 - i)); }
            }
        }
        public void PopulaTorreVazia()
        {
            for (int i = 0; i < tamanho; i++)
                torre.Add(new DiscoVazio(tamanho - 1));
        }
    }
}

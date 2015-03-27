using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hanoi
{
    class Jogo
    {
        readonly int qtdeTorres = 3;
        Torre[] torres;
        int tamanho;
        public Jogo()
        {
            do
            {
                Console.Clear();
                start();
                double jogadasMinimas = Math.Pow(2, tamanho) - 1;
                int jogadas = jogar();
                Console.WriteLine("Você ganhou em {0} jogadas. Número minimo de jogadas para {1} discos: {2}.", jogadas, tamanho, jogadasMinimas);
                Console.Write("Deseja jogar novamente?(s/n) ");
            } while (Console.ReadLine().ToLower()[0] != 'n');
            Console.WriteLine("Adeus!");
            Thread.Sleep(2000);
        }
        private void start()
        {
        aqui:
            try
            {
                torres = new Torre[qtdeTorres];
                Console.Write("Com quantas peças irá jogar? ");
                tamanho = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < qtdeTorres; i++)
                {
                    torres[i] = new Torre(tamanho + 1);
                    if (i == 0)
                        torres[i].PopulaTorre();
                    else
                        torres[i].PopulaTorreVazia();
                }
                MostraTorre();
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, apenas numeros.");
                goto aqui;
            }
        }
        private int jogar()
        {
            int jogadas = 0;
            bool completado = true;
            bool retiradaCerta = true;
            bool colocadaCerta = true;
            Torre torreTirada = null;
            Torre torreColocada = null;
            do
            {
                do
                {
                    fazRetirada(ref retiradaCerta, ref torreTirada);
                } while (retiradaCerta == false);
                MostraTorre();
                do
                {
                    fazColocada(ref colocadaCerta, torreTirada, ref torreColocada);
                } while (colocadaCerta == false);
                MostraTorre();
                jogadas++;
                completado = ConfereCompletado();
            } while (!completado);
            return jogadas;
        }
        private void fazColocada(ref bool colocadaCerta, Torre torreTirada, ref Torre torreColocada)
        {
        aqui:
            try
            {
                colocadaCerta = true;
                Console.Write("Em qual torre você quer botar o disco retirado? ");
                int t = Convert.ToInt32(Console.ReadLine());
                if (t <= qtdeTorres && t > 0)
                    torreColocada = torres[t - 1];
                else
                    colocadaCerta = false;
                if (colocadaCerta)
                    colocadaCerta = colocaNaTorre(torreColocada, torreTirada);
                if (!colocadaCerta)
                    Console.Write("Ouve algum erro, por favor diga ");
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, apenas numeros.");
                goto aqui;
            }
        }
        private void fazRetirada(ref bool retiradaCerta, ref Torre torreTirada)
        {
        aqui:
            try
            {
                retiradaCerta = true;
                Console.Write("De qual torre você quer tirar o disco superior? ");
                int t = Convert.ToInt32(Console.ReadLine());
                if (t <= qtdeTorres && t > 0)
                    torreTirada = torres[t - 1];
                else
                    retiradaCerta = false;
                if (retiradaCerta)
                    retiradaCerta = retiraDaTorre(torreTirada);
                if (!retiradaCerta)
                    Console.Write("Ouve algum erro, por favor diga ");
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, apenas numeros.");
                goto aqui;
            }
        }
        private bool ConfereCompletado()
        {
            for (int i = 1; i < tamanho; i++)
            {
                if (torres[qtdeTorres - 1].torre[i].GetType().Equals(typeof(DiscoVazio)))
                    return false;
            }
            return true;
        }
        private bool retiraDaTorre(Torre torre)
        {
            for (int i = 0; i < torre.torre.Count; i++)
            {
                if (!torre.torre[i].GetType().Equals(typeof(DiscoVazio)))
                {
                    IDisco d = torre.torre[0];
                    torre.torre[0] = torre.torre[i];
                    torre.torre[i] = d;
                    return true;
                }
            }
            return false;
        }
        private bool colocaNaTorre(Torre torreNova, Torre torreAntiga)
        {
            for (int i = 0; i < torreNova.torre.Count; i++)
            {
                if (!torreNova.torre[i].GetType().Equals(typeof(DiscoVazio)))
                {
                    if (torreNova.torre[i].tamanho > torreAntiga.torre[0].tamanho)
                    {
                        IDisco d = torreNova.torre[i - 1];
                        torreNova.torre[i - 1] = torreAntiga.torre[0];
                        torreAntiga.torre[0] = d;
                        return true;
                    }
                    return false;
                }
                else if (i == torreNova.torre.Count - 1)
                {
                    IDisco d = torreNova.torre[i];
                    torreNova.torre[i] = torreAntiga.torre[0];
                    torreAntiga.torre[0] = d;
                    return true;
                }
            }
            return false;
        }
        private void MostraTorre()
        {
            Console.Clear();
            for (int i = 0; i < tamanho + 1; i++)
            {
                for (int j = 0; j < qtdeTorres; j++)
                    Console.Write(torres[j].torre[i].forma);
                Console.WriteLine();
            }
            for (int j = 0; j < qtdeTorres; j++)
            {
                for (int i = 0; i < tamanho; i++)
                    Console.Write(" ");
                Console.Write(j + 1);
                for (int i = 0; i < tamanho; i++)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}

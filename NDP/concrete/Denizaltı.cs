using NDP.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.concrete
{
    internal class Denizaltı:Cisim
    {
        private static readonly Random Random=new Random();
        public Denizaltı(Size hareketAlanıBoyutları) :base(hareketAlanıBoyutları)
        {
            Image = Properties.Resources.submarineblack;
            BackColor = Color.Transparent;

            Bottom = Random.Next(hareketAlanıBoyutları.Height-Height+1);//denizaltıyı oluşturuluacağı yükseklik ayarlandı. 

            HareketMesafesi = (int)(Height * .1);
        }
        public Mermi VurulduMu(List<Mermi> mermiler)
        {
            foreach (var mermi in mermiler)
            {
                var vurulduMu = mermi.Top > Bottom && mermi.Right > Left && mermi.Left < Right;
                if(vurulduMu) return mermi;

            }
            return null;
        }
    }
}
 
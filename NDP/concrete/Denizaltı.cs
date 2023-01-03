using NDP.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP.concrete
{
    internal class Denizaltı:Cisim
    {
        private static readonly Random Random=new Random();
        private static Timer _speedTimer = new Timer(); // Static bir alan, her 7 saniyede bir denizaltının hızını artırmak için
        public Denizaltı(Size hareketAlanıBoyutları) :base(hareketAlanıBoyutları)
        {
   

            Image = Properties.Resources.submarineblack;
            BackColor = Color.Transparent;

            Bottom = Random.Next(hareketAlanıBoyutları.Height-Height+1);//denizaltıyı oluşturuluacağı yükseklik ayarlandı. 

            HareketMesafesi = (int)(Height * .1);
            _speedTimer.Interval = 7000; 
            _speedTimer.Tick += SpeedTimer_Tick; // Zamanlayıcının tick olayı
            _speedTimer.Start(); // Zamanlayıcıyı başlat
        }
       
        private void SpeedTimer_Tick(object sender, EventArgs e)
        {
            HareketMesafesi += 20; // Her 7 saniyede bir hareket mesafesini 20 artır
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
 
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
            Size =new Size(15,20);
            
            Bottom = Random.Next(hareketAlanıBoyutları.Height-Height+1);//denizaltıyı oluşturuluacağı yükseklik ayarlandı. 


        }
    }
}

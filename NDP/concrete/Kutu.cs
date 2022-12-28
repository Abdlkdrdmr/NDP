using NDP.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.concrete
{
    internal class Kutu : Cisim
    {
       private static readonly Random Random1 = new Random();
        public Kutu(int panelGenişliği, Size hareketAlanıBoyutları) : base(hareketAlanıBoyutları)
        {
            Image = Properties.Resources.giftbox;
            BackColor = Color.Transparent;
            
            Left=Random1.Next(hareketAlanıBoyutları.Width-Width+1);
            
           
        }
    }
}

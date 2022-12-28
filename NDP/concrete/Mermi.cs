using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.concrete
{
    internal class Mermi: Abstract.Cisim
    {
        public Mermi(Size hareketAlanıBoyutları,Gemi _gemi):base(hareketAlanıBoyutları)
        {
            Image = Properties.Resources.mermi;
            Size = new Size(20, 44);
            BackColor = Color.Transparent;

            Location = new Point((_gemi.Location.X + _gemi.Width / 2) - 15, _gemi.Top + 2);//merminin geminin ortasına hizalanmasını sağladım
            HareketMesafesi = (Int16) (Height * 0.5);
        }
    }
}

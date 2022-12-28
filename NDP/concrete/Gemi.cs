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
    internal class Gemi:Cisim//oluşturduğum her gemi aynı zamanda bir cisim dir,her cisim bir picturebox dır.
    {
        public Gemi(int panelGenişliği,Size hareketAlanıBoyutları):base(hareketAlanıBoyutları)
        {
            Image = Properties.Resources.gemi;
            Left = (panelGenişliği - Width) / 2;
            Size = new Size(128, 128);//yüklenecek geminin boyutlarını ayarladım.
            BackColor = Color.FromArgb(0x44, 0xfc, 0xfb);//resmin arka planının panel ile aynı olmasını sağladım
            HareketMesafesi = Width;
        }
    }
}

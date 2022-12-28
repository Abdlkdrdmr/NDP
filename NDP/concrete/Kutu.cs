using NDP.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.concrete
{
    internal class Kutu : Cisim//oluşturduğum her gemi aynı zamanda bir cisim dir,her cisim bir picturebox dır.
    {
       // private static readonly Random Random = new Random();
        public Kutu(int panelGenişliği, Size hareketAlanıBoyutları) : base(hareketAlanıBoyutları)
        {
            Image = Properties.Resources.house;
            BackColor = Color.Transparent;
            //Bottom = Random.Next(hareketAlanıBoyutları.Height - Height + 1);
        }
    }
}

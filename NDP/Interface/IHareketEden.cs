using NDP.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.Interface
{
    internal interface IHareketEden
    {
        Size HareketAlanıBoyutları { get; }//sadece readonly olması için get yazdık set yazmadık.
        int HareketMesafesi { get; }
        /// <summary>
        /// Cismi istenilen yönde hareket ettir
        /// </summary>
        /// <param name="yon">hangi yöne hareket edileceği</param>
        /// <returns>cisim duvara carparsa true döndürür.</returns>
        bool HareketEttir(Yon yon);//Yon enumını kullandık.
    }
}

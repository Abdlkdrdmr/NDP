using NDP.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.Interface
{
    internal interface IOyun
    {
        bool DevamEdiyorMu { get; }
        
        void Başlat();
        void AteşEt();
        void GemiyiHareketEttir(Yon yon);//parametre adı olarak yon kullanıldı.
        void Duraklat();

    }
}

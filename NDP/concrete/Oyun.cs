using NDP.Enum;
using NDP.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using NDP.Properties;

namespace NDP.concrete
{

    public class Oyun : IOyun
    {
        public Oyun(Panel panelGemi, Panel panelSavaşalanı)
        {
            _PanelGemi = panelGemi;
            _PanelSavaşalanı = panelSavaşalanı;
        }

        public bool DevamEdiyorMu { get; private set; }
        public readonly Panel _PanelGemi;
        public readonly Panel _PanelSavaşalanı;
        private Gemi _gemi;

        public void AteşEt()
        {
            throw new NotImplementedException();
        }

        public void Başlat()
        {
            if (DevamEdiyorMu) return;
            DevamEdiyorMu = true;

            GemiOluştur();
        }
        private void GemiOluştur()
        {//geminin olduğu panelin size ını Gemi ye gönderiyoruz Gemi aldığı HareketAlanıBoyutlarını cisim e gönderiyor ve artık hareketalanı boyutlarını kullanabilirz. 

            _gemi = new Gemi(_PanelGemi.Width, _PanelGemi.Size);
            _PanelGemi.Controls.Add(_gemi);
     
        }
        private void Bitir()
        {
            if (!DevamEdiyorMu) return;
            DevamEdiyorMu = false;
        }

        public void Duraklat()
        {
            throw new NotImplementedException();
        }

        public void GemiyiHareketEttir(Yon yon)
        {
            if (!DevamEdiyorMu) return;//oyunu başlatmadan geminin hareket etmesini önlüyoruz.
            _gemi.HareketEttir(yon);
        }

    }
}

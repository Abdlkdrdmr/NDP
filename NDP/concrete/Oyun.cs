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
            _hareketTimer.Tick += _hareketTimer_Tick;
        }

        private void _hareketTimer_Tick(object sender, EventArgs e)
        {
            MermileriHareketEttir();
        }

        private void MermileriHareketEttir()
        {
            foreach(var mermi in _mermiler)
            {
                mermi.HareketEttir(Yon.Aşağı);
            }
        }

        public bool DevamEdiyorMu { get; private set; }
        public readonly Panel _PanelGemi;
        public readonly Panel _PanelSavaşalanı;
        private Gemi _gemi;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        
        public void AteşEt()
        {
            if (!DevamEdiyorMu) return;
            var mermi = new Mermi(_PanelSavaşalanı.Size,_gemi);
            _PanelSavaşalanı.Controls.Add(mermi);//bir panelin üzerine ekleyebilmek için o sınıfın control den miras alması gerekir.
            _mermiler.Add(mermi);
        }
         
        public void Başlat()
        {
            if (DevamEdiyorMu) return;
            DevamEdiyorMu = true;
            
            ZamanlayıcıyıBaşlat();
            GemiOluştur();
        }
        private void ZamanlayıcıyıBaşlat()
        {
            _hareketTimer.Start();
        }
        private void ZamanlayıcıyıDurdur()
        {
            _hareketTimer.Stop();
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
            ZamanlayıcıyıDurdur();
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

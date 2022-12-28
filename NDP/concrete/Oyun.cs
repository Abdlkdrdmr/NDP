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
            _denizaltıoluşmaTimerı.Tick += DenizAltıOluşmaTimer_Tick;
            _kutuoluşturmaTimer.Tick += _kutuoluşturmaTimer_Tick;
        }

        private void _kutuoluşturmaTimer_Tick(object sender, EventArgs e)
        {
            KutuOluştur();
        }

        private void _hareketTimer_Tick(object sender, EventArgs e)
        {
            MermileriHareketEttir();
            DenizaltılarıHareketEttir();
            VurulanDenizaltılarıÇıkar();
        }

        private void VurulanDenizaltılarıÇıkar()
        {
            for (var i=_denizaltı.Count-1;i>=0;i--)
            {
                var denizaltı = _denizaltı[i];
                var vuranMermi = denizaltı.VurulduMu(_mermiler);
                if (vuranMermi is null) continue;
                _denizaltı.Remove(denizaltı);
                _mermiler.Remove(vuranMermi); 
                _PanelSavaşalanı.Controls.Remove(denizaltı);
                _PanelSavaşalanı.Controls.Remove(vuranMermi );
            }
            
        }

        private void DenizaltılarıHareketEttir()
        {
            for (int i = _denizaltı.Count - 1; i >= 0; i--)
            {
                var denizaltı = _denizaltı[i];
                var sınıraUlaştım = denizaltı.HareketEttir(Yon.sağa);
                if (sınıraUlaştım)
                {
                    _denizaltı.Remove(denizaltı);//Mermilerin savaş alanı dışına çıktığında mermilerin listeden silinmesi
                    _PanelSavaşalanı.Controls.Remove(denizaltı);
                }
            }
        }
       
        private void DenizAltıOluşmaTimer_Tick(object sender, EventArgs e)
        {
            DenizaltıOluştur();
        }

        private void MermileriHareketEttir()
        {
            for (int i = _mermiler.Count -1; i >= 0; i--)
            {
                var mermi = _mermiler[i];
                var sınıraUlaştım = mermi.HareketEttir(Yon.Aşağı);
                if (sınıraUlaştım)
                {
                    _mermiler.Remove(mermi);//Mermilerin savaş alanı dışına çıktığında mermilerin listeden silinmesi
                    _PanelSavaşalanı.Controls.Remove(mermi);
                }
            }
           
        }

        public bool DevamEdiyorMu { get; private set; }
        public readonly Panel _PanelGemi;
        public readonly Panel _PanelSavaşalanı;
        private Gemi _gemi;
        private Kutu _kutu;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _denizaltıoluşmaTimerı = new Timer { Interval = 3000 };//her üç saniyede bir denizaltı oluşturucak
        private readonly List<Denizaltı> _denizaltı = new List<Denizaltı>();
        private readonly Timer _kutuoluşturmaTimer = new Timer { Interval = 10000 };  //10 saniyede bir kutu oluşacak
        private readonly List<Kutu>_kutular=new List<Kutu>();
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
            DenizaltıOluştur();
            KutuOluştur();
            

        }

        private void KutuOluştur()
        {
            var kutu = new Kutu(_PanelGemi.Width, _PanelGemi.Size);
            _kutular.Add(kutu);
            _PanelGemi.Controls.Add(kutu);
            
        }

        private void DenizaltıOluştur()
        {
            var denizaltı = new Denizaltı(_PanelSavaşalanı.Size);
            _denizaltı.Add(denizaltı);
            _PanelSavaşalanı.Controls.Add(denizaltı);
        }

        public void ZamanlayıcıyıBaşlat()
        {
            _hareketTimer.Start();
            _denizaltıoluşmaTimerı.Start();
            _kutuoluşturmaTimer.Start();

        }
        public void ZamanlayıcıyıDurdur()
        {

            _hareketTimer.Stop();
            _denizaltıoluşmaTimerı.Stop();
            _kutuoluşturmaTimer.Stop();
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


        public void GemiyiHareketEttir(Yon yon)
        {
            if (!DevamEdiyorMu) return;//oyunu başlatmadan geminin hareket etmesini önlüyoruz.
            _gemi.HareketEttir(yon);
        }

    }
}

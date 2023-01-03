using NDP.concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NDP
{
    public partial class AnaForm : Form
    {
        private readonly Oyun _oyun;//_oyun adında bir değişken tanımlıyoruz.
        private int gerisayım;
        private bool oyunDuraklatıldı;
        public  int Score;
        public string mesaj;
        

        public AnaForm(int gerisayım)
        {
            InitializeComponent();

            this.gerisayım = gerisayım;
           
            _oyun = new Oyun(panelGemi, panelSavaşalanı,skor);
            oyunDuraklatıldı = false;
            

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();//Bütün uygulamaları kapatmak için kullandım.
            Close();
        }
    
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _oyun.Başlat();
                    
                    timer1.Interval = 1000; // 1 saniye aralıklarla çalışacak
                    timer1.Start(); // timer'ı başlat
                    oyunDuraklatıldı = false;//sürenin devam etmesi için kullanıldı
                    _oyun.ZamanlayıcıyıBaşlat();

                    break;
                case Keys.Right:
                    _oyun.GemiyiHareketEttir(Enum.Yon.sağa);
                    break;
                case Keys.Left:
                    _oyun.GemiyiHareketEttir(Enum.Yon.sola);
                    break;
                case Keys.Space:
                    _oyun.AteşEt();
                    break;
                case Keys.P:
                    oyunDuraklatıldı = !oyunDuraklatıldı;//duraklatmak için kullanıldı.
                    _oyun.ZamanlayıcıyıDurdur();             
                    break;
               

            }
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gerisayım--;
            geriSayımLabeli.Text = gerisayım.ToString();

            if (gerisayım == 0 || oyunDuraklatıldı)
            {
                timer1.Stop();

                if (gerisayım == 0)
                {
                    _oyun.ZamanlayıcıyıDurdur();// süre bitince arka planda duruyor.
                    MessageBox.Show("puanınız:" + skor.Text);
                }
            }
            else if (gerisayım < 0)
            {
                timer1.Stop();
                gerisayım = 0;
                MessageBox.Show("Tekrar oynamak için süre giriniz");
            }
        }


        
        
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 getir= new Form1();
            getir.Show();
        }

        private void skor_TextChanged(object sender, EventArgs e)
        {

            if (true)
            {
               
                adet.Text = (Convert.ToInt32(skor.Text)/10).ToString();// vurulan denizaltı sayısını veriyor.
            }
           
        }
    }
}
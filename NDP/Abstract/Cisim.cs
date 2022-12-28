using NDP.Enum;
using NDP.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP.Abstract
{
    internal abstract class Cisim:PictureBox,IHareketEden //her cisim bir resimdir.
    {
        public Size HareketAlanıBoyutları { get; }
        public int HareketMesafesi { get; protected set; }//oyun gemi nin hareket mesafesinin değiştirilmemesi için protected yaptık.

        public new int Right
        {
            get => base.Right;
            set => Left = value - Width;   
        }
        public new int Bottom 
        {
            get => base.Bottom;
            set=>Top= value - Height;
        } 
        public int Center
        {
            get => Left + Width / 2;
            set=> Left = value * Width/2;
        }
        public int Middle
        {
            get=>Top+ Height / 2;
            set => Top = value - Height/2;
        }
        protected Cisim(Size hareketAlanıBoyutları)
        {
           
            HareketAlanıBoyutları = hareketAlanıBoyutları;//hareket alanı boyutlarına cisme gönderilen parametre atanıyor.
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public bool HareketEttir(Yon yon)
        {
            switch (yon)
            {
                case Yon.Yukarı:
                    return YukarıHareketEttir();
                    break;
                case Yon.Aşağı:
                    return AşağıHareketEttir();
                    break;
                case Yon.sağa:
                    return SağaHareketEttir();
                    break;
                case Yon.sola:
                    return SolaHareketEttir();
                    break;
                default: return false;
            }
        }

        private bool SağaHareketEttir()
        {
            if (Right == HareketAlanıBoyutları.Width) return true;
            var yeniright = Right + HareketMesafesi;
            var taşacakmı = yeniright > HareketAlanıBoyutları.Width;

            Right = taşacakmı ? HareketAlanıBoyutları.Width : yeniright;
            return Right == HareketAlanıBoyutları.Width;
        }

        private bool AşağıHareketEttir()
        {

            if (Bottom == HareketAlanıBoyutları.Width) return true;
            var yenibottom = Bottom + HareketMesafesi;
            var taşacakmı = yenibottom > HareketAlanıBoyutları.Width;

            Bottom = taşacakmı ? HareketAlanıBoyutları.Width : yenibottom;
            return Bottom == HareketAlanıBoyutları.Width;
        }

        private bool YukarıHareketEttir()
        {
            if (Top == 0) return true;
            var yenitop = Top - HareketMesafesi;
            var taşacakmı = yenitop < 0;
            Top = taşacakmı ? 0 : yenitop;
            return Top == 0;
        }
        private bool SolaHareketEttir()
        {
            if (Left == 0) return true;// "Left" değişkeninin değerinin bir "HareketMesafesi" değerini taşıdığı durumda, "Left" değişkeninin değerinin 0'a eşit olup olmadığını kontrol etmek ve eğer taşındığında 0'a eşit olacaksa "Left" değişkenine 0 atanır, aksi takdirde "Left" değişkeninin değeri "yenileft" değişkeninin değeriyle güncellenir.
            var yenileft = Left - HareketMesafesi;
            var taşacakmı = yenileft < 0;
            Left = taşacakmı ? 0 : yenileft;
            return Left == 0;
        }
    }
    
}

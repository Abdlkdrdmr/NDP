﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NDP.Form2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NDP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //combobox a zorluk seviyeleri eklendi
            comboboxzorlukseviyesi.Items.Add(ZorlukSeviyesi.Kolay);
            comboboxzorlukseviyesi.Items.Add(ZorlukSeviyesi.Orta);
            comboboxzorlukseviyesi.Items.Add(ZorlukSeviyesi.Zor);
        }

        private void TıklamaOlayı1(object sender, EventArgs e)
        {
            if (label7.Visible == false)
            {
                pictureBox3.Visible = false;
                label2.Visible = false;
                label7.Visible = true;
            }
            else
            {
                pictureBox3.Visible = true;
                label2.Visible = true;
                label7.Visible = false;
            }




        }
        private void TıklamaOlayı2(object sender, EventArgs e)
        {
            if (label8.Visible == false)
            {
                label8.Visible = true;
                label3.Visible = false;
                pictureBox4.Visible = false;
            }
            else
            {
                label8.Visible = false;
                label3.Visible = true;
                pictureBox4.Visible = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TıklamaOlayı1(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            TıklamaOlayı1(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            TıklamaOlayı2(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            TıklamaOlayı2(sender, e);
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            TıklamaOlayı1(sender, e);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            TıklamaOlayı2(sender, e);
        }
    }
}

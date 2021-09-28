using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string[] arrSigns = {"add", "sub", "div", "mult", "equ", "point"};

            List<Button> btnList =
                Enumerable.Range(0, 10)
                .Select((i) => (Button)this.Controls["btn_" + i.ToString()])
                .ToList();

            List<Button> btnList2 =
                Enumerable.Range(0, arrSigns.Length)
                .Select((i) => (Button)this.Controls["btn_" + arrSigns[i].ToString()])
                .ToList();

            
            foreach (Button btn in btnList)
            {
                btn.Click += (object sender, EventArgs e) => 
                {
                    this.setTextWithLength(btn.Text);
                };
            }

            foreach(Button btn in btnList2)
            {
                btn.Click += (object sender, EventArgs e) =>
                {
                    this.setTextWithLength(btn.Text);
                };
            }

        }

        private void changeAugFontSize(int opSize = 3, int absSize = 0)
        {
            float size = txt_screen.Font.Size;
            
            if(absSize > 0)
            {
                size = absSize;
            }
            if(size > 12)
            {
                size += opSize;
                txt_screen.Font = new Font("MS UI Gothic", size);
            }
        }

        private void setTextWithLength(string text = "")
        {
            if(text != "")
            {
                if (this.txt_screen.TextLength > 10)
                {
                    this.changeAugFontSize(-3);
                }

                this.txt_screen.Text += text;
            }
            else
            {
                this.txt_screen.Text = text;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btn_delete_all_Click(object sender, EventArgs e)
        {
            this.setTextWithLength();
            this.changeAugFontSize(0, 36);
        }

        private void btn_delete_last_Click(object sender, EventArgs e)
        {
            int length = this.txt_screen.TextLength;

            if (length > 0)
            {
                this.txt_screen.Text = this.txt_screen.Text.Remove(length - 1);
            }

            if (length <= 18 && length >= 12)
            {
                this.changeAugFontSize();
            }
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace xsi0
{
    public partial class Form1 : Form
    {
        public byte nr = 0;
        int scorx = 0;
        int scor0 = 0;
        int contor = 0;

        public bool castig()
        {
            if(lbl1.Text == lbl2.Text && lbl2.Text == lbl3.Text && lbl1.Text!="")
            {
                return true;
            }
            if (lbl1.Text == lbl4.Text && lbl4.Text == lbl7.Text && lbl1.Text != "")
            {
                return true;
            }
            if (lbl1.Text == lbl5.Text && lbl5.Text == lbl9.Text && lbl1.Text != "")
            {
                return true;
            }
            if (lbl2.Text == lbl5.Text && lbl5.Text == lbl8.Text && lbl2.Text != "")
            {
                return true;
            }
            if (lbl3.Text == lbl6.Text && lbl6.Text == lbl9.Text && lbl3.Text != "")
            {
                return true;
            }
            if (lbl3.Text == lbl5.Text && lbl5.Text == lbl7.Text && lbl3.Text != "")
            {
                return true;
            }
            if (lbl7.Text == lbl8.Text && lbl8.Text == lbl9.Text && lbl7.Text != "")
            {
                return true;
            }
            if (lbl4.Text == lbl5.Text && lbl5.Text == lbl6.Text && lbl4.Text != "")
            {
                return true;
            }
            return false;
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pnlScor.Size = pnlJoc.Size = pnlSetari.Size = pnlMeniu.Size;
            pnlScor.Location = pnlJoc.Location = pnlSetari.Location= pnlMeniu.Location;
            pnlScor.Visible = false;
            pnlJoc.Visible = false;
            pnlSetari.Visible = false;
        }
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJucati_Click(object sender, EventArgs e)
        {
            pnlMeniu.Visible = false;
            pnlJoc.Visible = true;
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            pnlMeniu.Visible = false;
            pnlScor.Visible = true;
            txtbox.Text = File.ReadAllText("scor.txt");
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            pnlMeniu.Visible = true;
            pnlScor.Visible = false;
        }

        private void btnInapoi2_Click(object sender, EventArgs e)
        {
            pnlMeniu.Visible = true;
            pnlJoc.Visible = false;
            foreach (Control ceva in pnl1.Controls)
            {
                if ((ceva as Label) != null)
                {
                    (ceva as Label).Text = "";
                    nr = 0;
                    (ceva as Label).Enabled = true;
                }
            }
            if (scor0 != 0 || scorx != 0)
            {
                StreamWriter fout = File.AppendText("scor.txt");
                fout.WriteLine(scorx + " " + scor0 + " " + DateTime.Today.ToString("dd/MM/yyyy"));
                fout.Close();
            }
            scor0 = 0;
            scorx = 0;
            scor1.Text = scorx.ToString();
            scor2.Text = scor0.ToString();
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
            nr++;
            Label lbl = (sender as Label);
            if(nr%2!=0)
            {
                lbl.Text = "X";
            }
            else
            {
                lbl.Text = "0";
            }
            lbl.Enabled = false;
            if (castig() == true)
            {
                if (nr % 2 != 0)
                {
                    MessageBox.Show("X a castigat!", "Bravo!");
                    scorx++;
                    scor1.Text = scorx.ToString();
                }
                else
                {
                    MessageBox.Show("0 a castigat!", "Bravo!");
                    scor0++;
                    scor2.Text = scor0.ToString();
                }
                foreach (Control ceva in pnl1.Controls)
                {
                    if ((ceva as Label) != null)
                    {
                        (ceva as Label).Text = "";
                        nr = 0;
                        (ceva as Label).Enabled = true;
                    }
                }
            }
            else if (nr == 9)
            {
                MessageBox.Show("Mai incercati!", "Offff");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (scor0 != 0 || scorx != 0)
            {
                StreamWriter fout = File.AppendText("scor.txt");
                fout.WriteLine(scorx + " " + scor0 + " " + DateTime.Today.ToString("dd/MM/yyyy"));
                fout.Close();
            }
            foreach (Control ceva in pnl1.Controls)
            {
                if ((ceva as Label) != null)
                {
                    (ceva as Label).Text = "";
                    nr = 0;
                    (ceva as Label).Enabled = true;
                }
            }
            scor1.Text = "0";
            scor2.Text = "0";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(contor == 0 && (scorx != 0 || scor0 != 0))
            {
                StreamWriter fout = File.AppendText("scor.txt");
                fout.WriteLine(scorx + " " + scor0 + " " + DateTime.Today.ToString("dd/MM/yyyy"));
                fout.Close();
            }
        }

        private void btnSetari_Click(object sender, EventArgs e)
        {
            pnlMeniu.Visible = false;
            pnlSetari.Visible = true;
        }
        private void btnInapoi3_Click_1(object sender, EventArgs e)
        {
            pnlMeniu.Visible = true;
            pnlSetari.Visible = false;
        }

        private void stil11_Click(object sender, EventArgs e)
        {
            foreach(Control ceva in pnl1.Controls)
            {
                if((ceva as Label)!=null)
                {
                    (ceva as Label).BackColor = stil11.BackColor;
                }
            }
            pnlJoc.BackColor = stil1.BackColor;
        }

        private void stil1_Click(object sender, EventArgs e)
        {
            foreach (Control ceva in pnl1.Controls)
            {
                if ((ceva as Label) != null)
                {
                    (ceva as Label).BackColor = stil11.BackColor;
                }
            }
            pnlJoc.BackColor = stil1.BackColor;
        }

        private void stil22_Click(object sender, EventArgs e)
        {
            foreach (Control ceva in pnl1.Controls)
            {
                if ((ceva as Label) != null)
                {
                    (ceva as Label).BackColor = stil22.BackColor;
                }
            }
            pnlJoc.BackColor = stil2.BackColor;
        }

        private void stil2_Click(object sender, EventArgs e)
        {
            foreach (Control ceva in pnl1.Controls)
            {
                if ((ceva as Label) != null)
                {
                    (ceva as Label).BackColor = stil22.BackColor;
                }
            }
            pnlJoc.BackColor = stil2.BackColor;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control ceva in pnl1.Controls)
            {
                if ((ceva as Label) != null)
                {
                    (ceva as Label).BackColor = stil33.BackColor;
                }
            }
            pnlJoc.BackColor = stil3.BackColor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control ceva in pnl1.Controls)
            {
                if ((ceva as Label) != null)
                {
                    (ceva as Label).BackColor = stil33.BackColor;
                }
            }
            pnlJoc.BackColor = stil3.BackColor;
        }
    }
}

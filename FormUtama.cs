using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QBisnis
{
    public partial class FormUtama : Form
    {
        Thread th;
        private double _fc;
        private double _vc;
        

        public FormUtama()
        {
            InitializeComponent();
        }

        public FormUtama(string sp)
        {
            InitializeComponent();
            tbSPview.Text = sp;
        }
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            panelHome.Visible = true;
            panelBEP.Visible = false;

        }

        private void btnBEP_Click_1(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            panelHome.Visible = false;
            panelBEP.Visible = true;

        }

        private void openvc()
        {
            Application.Run(new FormVC());
        }


        private void openfc()
        {
            Application.Run(new FormFC());
        }


        private void opensp()
        {
            Application.Run(new FormSP());
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            
            FormFC fc = new FormFC();
            _fc = fc.totalfc();
            tbFCview.Text = _fc.ToString();

            FormVC vc = new FormVC();
            _vc = vc.totalvc();
            tbVCview.Text = _vc.ToString();
        }

        private void btnFC1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openfc);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnVC1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openvc);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnSP1_Click_1(object sender, EventArgs e) //pas buka ini form utama kebuka 2kali
        {
            panelSP.Visible = true;
            btnBEP.Enabled = false;
            btnFC1.Enabled = false;
            btnSP1.Enabled = false;
            btnVC1.Enabled = false;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbInSp.Text != null)
            {
                try
                {
                    double sp = Convert.ToDouble(tbInSp.Text);
                    tbSPview.Text = tbInSp.Text;
                    panelSP.Visible = false;
                    btnBEP.Enabled = true;
                    btnFC1.Enabled = true;
                    btnSP1.Enabled = true;
                    btnVC1.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Please input a valid number");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panelSP.Visible = false;
            btnBEP.Enabled = true;
            btnFC1.Enabled = true;
            btnSP1.Enabled = true;
            btnVC1.Enabled = true;
        }

        private void btnhitung_Click(object sender, EventArgs e)
        {
            if (tbSPview.Text != "" && tbFCview.Text != "" && tbVCview.Text != "")
            {
                tbBEPunit.Text = Convert.ToString((Convert.ToDouble(tbFCview.Text) / (Convert.ToDouble(tbSPview.Text) - Convert.ToDouble(tbVCview.Text))));

                tbBEPrupiah.Text = Convert.ToString((Convert.ToDouble(tbFCview.Text) / (1 - (Convert.ToDouble(tbVCview.Text) / Convert.ToDouble(tbSPview.Text)))));
            }
            else
            {
                MessageBox.Show("Lengkapi semua data terlebih dahulu!");
            }
        }

    }
}

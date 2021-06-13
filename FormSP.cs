using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBisnis
{
    public partial class FormSP : Form
    {
        public FormSP()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            if (tbPrice.Text != "")
            {
                FormUtama form = new FormUtama(tbPrice.Text);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Silahkan Isi Nilai Sale Price!");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

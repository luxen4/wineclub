using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos
{
    public partial class Form_InformeVentas : Form
    {
        public Form_InformeVentas()
        {
            InitializeComponent();
        }

        private void button_desapareces_Click(object sender, EventArgs e)
        {
            pictureBox_perfilsocio.Visible = false;
        }

        private void btn_nuevosocio_Click(object sender, EventArgs e)
        {

        }
    }
}

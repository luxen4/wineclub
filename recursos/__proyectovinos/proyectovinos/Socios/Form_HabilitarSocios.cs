using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos.Socios
{
    public partial class Form_HabilitarSocios : Form
    {
        public Form_HabilitarSocios()
        {
            InitializeComponent();
        }

 
        Class_Socio socio = new Class_Socio();
        Consultas consultas = new Consultas();
        CumplimentarListas cumplimentarlistas = new CumplimentarListas();
        Utilidades ut = new Utilidades();

        private string tabla = "socio";
        private string nombreId = "id_socio";

        private string referencia = "";
        private int id_socio = 0;
        private bool cargaLista=false;


        private void Form_HabilitarSocios_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            socio.cumplimentarListaSocios(listView1,'0');
            cargaLista = true;
        }

        private void limpiarCampos()
        {
            text_nombreapellidos.Text = "";
            check_seguro.Checked = false;
            pictureBox1.Image = null;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cargaLista == true)
            {
                referencia = e.Item.Text;
                id_socio = consultas.obtenerCualquierId(nombreId, tabla, "ref", referencia);
                int index = e.Item.Index;

                text_nombreapellidos.Text = listView1.Items[index].SubItems[1].Text + " " + listView1.Items[index].SubItems[2].Text;
                socio.agregarImagenPictureBoxSocio(id_socio, pictureBox1);
            }
        }


        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if (check_seguro.Checked)
            {
                consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '1');
                listView1.Items.Clear();
                socio.cumplimentarListaSocios(listView1, '0');
                limpiarCampos();
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgSelectRegistro);
            }
        }
    }
}

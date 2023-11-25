using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Caracteristicas.clasesvino
{
    public partial class Form_HabilitarClaseVino : Form
    {
        public Form_HabilitarClaseVino()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();

        private bool cargaLista = true;
        private string tabla = "clasevino";

        private void Form_HabilitarClaseVino_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referencia, tabla, text_nombre);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ut.controladorHabilitarCaracteristica(check_segurohabilitar, text_referencia, text_nombre, tabla, listView1, '1');
        }
    }
}

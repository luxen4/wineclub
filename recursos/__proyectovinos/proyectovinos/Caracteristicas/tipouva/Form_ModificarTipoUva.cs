using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.ArticuloVino;

namespace proyectovinos.Caracteristicas.tipouva
{
    public partial class Form_ModificarTipoUva : Form
    {
        public Form_ModificarTipoUva()
        {
            InitializeComponent();
        }


        private string referencia = "";
        private bool cargaLista = true;
        private string tabla = "tipouva";

        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarComboboxes combos = new CumplimentarComboboxes();
        Class_TipoUva tipoUva = new Class_TipoUva();


        private void Form_ModificarTipoUva_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            tipoUva.cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
            combos.refrescarCombo("nombre","variedaduva",combo_variedaduvanuevo);
            cargaLista = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ut.limpiarCamposModificar(text_referenciaseleccionada, text_nombremodificar, text_referenciamodificar);
        }


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            referencia = e.Item.Text;
            text_referenciaseleccionada.Text = referencia;
            ut.checkMarcadoTodos(cargaLista, e, text_referenciamodificar, tabla, text_nombremodificar);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (check_seguronuevo.Checked)
            {
                int id_variedaduva = consultas.obtenerCualquierId("id_variedaduva","variedaduva","nombre",combo_variedaduvanuevo.Text);
                tipoUva.modificarTipoUva(text_referenciamodificar.Text, text_nombremodificar.Text, id_variedaduva, referencia, listView1);
                tipoUva.cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
                ut.limpiarCamposModificar(text_referenciaseleccionada, text_nombremodificar, text_referenciamodificar);
                combo_variedaduvanuevo.Text = "Seleccione";
            }
            else {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_TipoUvaAperturaForms tipoUva = new Class_TipoUvaAperturaForms();
            tipoUva.todosTiposUva(); this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.todosArticulosVinoII(); this.Close();
        }
    }
}

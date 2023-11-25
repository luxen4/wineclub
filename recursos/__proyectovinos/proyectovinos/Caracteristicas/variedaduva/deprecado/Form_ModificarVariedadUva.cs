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

namespace proyectovinos.Caracteristicas.variedaduva
{
    public partial class Form_ModificarVariedadUva : Form
    {
        public Form_ModificarVariedadUva()
        {
            InitializeComponent();
        }

        private string referencia = "";
        private bool cargaLista = true;
        private string tabla = "variedaduva";

            Utilidades ut =new Utilidades();
            Consultas consultas = new Consultas();
            CumplimentarListas cumplimentarListas = new CumplimentarListas();
          

        private void Form_ModificarVariedadUva_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            cargaLista = false;
        }

        // Método que recoge la referencia seleccionada
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // int item = e.Item.Index;
            // referencia = listView1.Items[item].SubItems[0].Text;
            referencia = e.Item.Text;
            text_referenciaseleccionada.Text = referencia;
            ut.checkMarcadoTodos(cargaLista, e, text_referenciamodificar, tabla, text_nombremodificar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consultas.modificarCualquierTabla(tabla, text_referenciamodificar.Text, text_nombremodificar.Text, "ref", referencia ,listView1);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1,'1');
            ut.limpiarCamposModificar(text_referenciaseleccionada, text_nombremodificar, text_referenciamodificar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ut.limpiarCamposModificar(text_referenciaseleccionada, text_nombremodificar, text_referenciamodificar);
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
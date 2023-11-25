using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Caracteristicas.contenido
{
    public partial class Form_ModificarContenido : Form
    {
        public Form_ModificarContenido()
        {
            InitializeComponent();
        }

        private string referencia = "";
        private bool cargaLista = true;
        private string tabla = "formatocontenido";

        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();

        private void Form_ModificarContenido_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1,'1');
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            referencia = e.Item.Text;
            text_referenciaseleccionada.Text = referencia;
            ut.checkMarcadoTodos(cargaLista, e, text_referenciamodificar, tabla, text_nombremodificar);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ut.limpiarCamposModificar(text_referenciaseleccionada, text_nombremodificar, text_referenciamodificar);
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consultas.modificarCualquierTabla(tabla, text_referenciamodificar.Text, text_nombremodificar.Text, "ref", referencia, listView1);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            ut.limpiarCamposModificar(text_referenciaseleccionada, text_nombremodificar, text_referenciamodificar);
        }
    }
}

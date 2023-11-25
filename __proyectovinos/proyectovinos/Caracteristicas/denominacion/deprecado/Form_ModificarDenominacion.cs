using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos
{
    public partial class Form_ModificarDenominacion : Form
    {
        public Form_ModificarDenominacion()
        {
            InitializeComponent();
        }

        private bool cargaLista = true;
        private string referencia = "";
        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarListas cumplimentarListas=new CumplimentarListas();
        private string tabla = "denominacion";


        private void button2_Click(object sender, EventArgs e)
        {
            consultas.modificarCualquierTabla(tabla,text_nuevareferencia.Text, text_nuevonombre.Text,"ref", text_referencia.Text, listView1);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1,'1');
            ut.limpiarCamposModificar(text_referencia, text_nuevonombre, text_nuevareferencia);
        }

        // Lectura de datos al abrir el formulario
        private void Form_ModificarDenominacion_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1,'1');
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            referencia = e.Item.Text;
            text_referencia.Text = referencia;
            ut.checkMarcadoTodos(cargaLista, e, text_nuevareferencia, tabla, text_nuevonombre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ut.limpiarCamposModificar(text_referencia, text_nuevonombre, text_nuevareferencia);
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

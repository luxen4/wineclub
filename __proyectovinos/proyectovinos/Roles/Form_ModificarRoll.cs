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
using MySql.Data.MySqlClient;
using proyectovinos.Empleados;

namespace proyectovinos.Roles
{
    public partial class Form_ModificarRoll : Form
    {
        public Form_ModificarRoll()
        {
            InitializeComponent();
        }


        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        private bool cargaLista = true;
        private string referenciaActual = "";


        private void Form_ModificarRol_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1,'1');
            cargaLista = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            text_nuevareferencia.Text = "";
            text_nuevonombre.Text = "";
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {   //Meter a los demás
            referenciaActual = e.Item.Text;
            ut.checkMarcadoModificar(cargaLista, e, text_nuevonombre, text_referenciaactual);
        }
  
        private void button2_Click_1(object sender, EventArgs e)
        {
            string nuevoNombre = text_nuevonombre.Text;
            string nuevaReferencia = text_nuevareferencia.Text;

            consultas.modificarCualquierTabla(tabla, nuevaReferencia, nuevoNombre, "ref", referenciaActual, listView1);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1,'1');
            ut.limpiarCamposModificar(text_referenciaactual, text_nuevonombre, text_nuevareferencia);
        }

        private string tabla = "rollempleado";

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

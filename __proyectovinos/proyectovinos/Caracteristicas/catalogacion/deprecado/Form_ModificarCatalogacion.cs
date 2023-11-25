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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proyectovinos
{
    public partial class Form_ModificarCatalogacion : Form
    {
        public Form_ModificarCatalogacion()
        {
            InitializeComponent();
        }
        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        private bool cargaLista = true; 
        private string referenciaActual="";

        private void Form_ModificarCatalogacion_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref","nombre","catalogacion",listView1,'1');
            cargaLista = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nuevoNombre = text_nuevonombre.Text;
            string nuevaReferencia = text_nuevareferencia.Text;
           
            consultas.modificarCualquierTabla("catalogacion",nuevaReferencia,nuevoNombre,"ref",referenciaActual,listView1);
            cumplimentarListas.cumplimentarLista("ref", "nombre", "catalogacion", listView1,'1');
            ut.limpiarCamposModificar(text_referenciaactual, text_nuevonombre, text_nuevareferencia);
        }

       

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Metodo que llama al método de limpiar campos
        private void button1_Click(object sender, EventArgs e)
        {
            ut.limpiarCamposModificar(text_referenciaactual, text_nuevonombre, text_nuevareferencia);
        }



        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cargaLista==false) { 
                referenciaActual = e.Item.Text;
                text_referenciaactual.Text=referenciaActual;
            }
        }
    }
}

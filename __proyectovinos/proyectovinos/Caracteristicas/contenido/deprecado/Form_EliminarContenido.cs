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

namespace proyectovinos.Caracteristicas.contenido
{
    public partial class Form_EliminarContenido : Form
    {
        public Form_EliminarContenido()
        {
            InitializeComponent();
        }

        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Utilidades ut = new Utilidades();
        private bool cargaLista = true;
        private string tabla = "formatocontenido";
        private string id_tabla = "id_formatocontenido";

        private void Form_EliminarContenido_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1,'0');
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // referencia = e.Item.Text;
            ut.checkMarcadoEliminar(cargaLista, e,  tabla, text_referenciaeliminar, text_nombreeliminar);
        }
       
        // LLama al controlador // Simplificación de código haciendolo general para todas
        private void button3_Click(object sender, EventArgs e)
        {  
            ut.controladorEliminarCaracteristica(check_seguroeliminar, text_referenciaeliminar, text_nombreeliminar, id_tabla, tabla, listView1);
            ut.limpiarCamposEliminar(text_referenciaeliminar, text_nombreeliminar, check_seguroeliminar);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
        }
    }
}
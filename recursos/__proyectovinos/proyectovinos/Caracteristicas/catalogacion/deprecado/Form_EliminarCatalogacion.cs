using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Caracteristicas.clasesvino;

namespace proyectovinos.Caracteristicas.catalogacion
{
    public partial class Form_EliminarCatalogacion : Form
    {
        public Form_EliminarCatalogacion()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        Class_ClaseVinoAperturaForms apertura = new Class_ClaseVinoAperturaForms();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();

        private bool cargaLista = true;
        private string id_tabla = "id_catalogacion";
        private string tabla = "catalogacion";

        private void Form_EliminarCatalogacion_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
            cargaLista = false;

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referenciaeliminar, tabla, text_nombreeliminar);
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            ut.controladorEliminarCaracteristica(check_seguroeliminar, text_referenciaeliminar, text_nombreeliminar, id_tabla, tabla, listView1);
            ut.limpiarCamposEliminar(text_referenciaeliminar,text_nombreeliminar, check_seguroeliminar);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');

        }
    }
}


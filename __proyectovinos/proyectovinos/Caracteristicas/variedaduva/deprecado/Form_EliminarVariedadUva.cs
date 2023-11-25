using System;
using System.Windows.Forms;
/*
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectovinos.Caracteristicas.clasesvino;
using proyectovinos;
using proyectovinos.ArticuloVino;*/


namespace proyectovinos.Caracteristicas.variedaduva
{
    public partial class Form_EliminarVariedadUva : Form
    {
        public Form_EliminarVariedadUva()
        {
            InitializeComponent();
        }
            Utilidades ut = new Utilidades();
            CumplimentarListas cumplimentarListas = new CumplimentarListas();

            private bool cargaLista = true;
            private string id_tabla = "id_variedaduva", tabla = "variedaduva";

        private void Form_EliminarVariedadUva_Load(object sender, EventArgs e)
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
        {   string tabladependiente = "tipouva";
            string idTablaDependiente = "id_tipouva";
            ut.controladorEliminarRegistroTablaMadre(check_seguroeliminar, text_referenciaeliminar, text_nombreeliminar, idTablaDependiente, tabladependiente, id_tabla, tabla, listView1);
            ut.limpiarCamposEliminar(text_referenciaeliminar, text_nombreeliminar, check_seguroeliminar);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
        }
    }
}

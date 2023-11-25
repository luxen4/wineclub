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

namespace proyectovinos.Caracteristicas.tipouva
{
    public partial class Form_EliminarTipoUva : Form
    {
        public Form_EliminarTipoUva()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        Class_TipoUva tipoUva = new Class_TipoUva();

        private bool cargaLista = true;
        private string tabla = "tipouva";
        private string id_tabla = "id_tipouva";

        private void Form_EliminarTipoUva_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            tipoUva.cumplimentarListaTipoUva(listView1, '0');// No tocar que tiene estructura propia
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referenciaeliminar, tabla, text_nombreeliminar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ut.controladorEliminarCaracteristica(check_seguroeliminar, text_referenciaeliminar, text_nombreeliminar, id_tabla, tabla, listView1);
            ut.limpiarCamposEliminar(text_referenciaeliminar, text_nombreeliminar, check_seguroeliminar);
            tipoUva.cumplimentarListaTipoUva(listView1, '0');// No tocar que tiene estructura propia
        }
    }
}

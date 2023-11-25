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
using proyectovinos;

namespace proyectovinos.Caracteristicas.contenido
{
    public partial class Form_HabilitarContenido : Form
    {
        public Form_HabilitarContenido()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();

        private bool cargaLista = true;
        private string tabla = "formatocontenido";

        private void Form_HabilitarContenido_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referenciahabilitar, tabla, text_nombrehabilitar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ut.controladorHabilitarCaracteristica(check_segurohabilitar, text_referenciahabilitar, text_nombrehabilitar, tabla, listView1, '1');
        }
    }
}






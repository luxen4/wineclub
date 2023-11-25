using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Caracteristicas.empaquetado
{
    public partial class Form_ModificarEmpaquetado : Form
    {
        public Form_ModificarEmpaquetado()
        {
            InitializeComponent();
        }

        private bool cargaLista = true;
        private string referencia = "";
        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        private string tabla = "empaquetado";

        private void Form_ModificarEmpaquetado_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            referencia = e.Item.Text;
            text_referencia.Text = referencia;
            ut.checkMarcadoTodos(cargaLista, e, text_nuevareferencia, tabla, text_nuevonombre);
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            consultas.modificarCualquierTabla(tabla, text_nuevareferencia.Text, text_nuevonombre.Text, "ref", text_referencia.Text, listView1);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            ut.limpiarCamposModificar(text_referencia, text_nuevonombre, text_nuevareferencia);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ut.limpiarCamposModificar(text_referencia, text_nuevonombre, text_nuevareferencia);
        }
    }
}

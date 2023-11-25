using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Caracteristicas.Denominacion;

namespace proyectovinos.Caracteristicas.tipouva
{
    public partial class Form_HabilitarTipoUva : Form
    {
        public Form_HabilitarTipoUva()
        {
            InitializeComponent();
        }

        Class_TipoUva tipoUva = new Class_TipoUva();
        Utilidades ut = new Utilidades();
        private bool cargaLista = true;
        private string tabla = "tipouva";

 
        private void Form_HabilitarTipoUva_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            tipoUva.cumplimentarListaTipoUva(listView1,'0');// No tocar que tiene estructura propia
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referenciahabilitar, tabla, text_nombrehabilitar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controladorHabilitarCaracteristica(check_segurohabilitar, text_referenciahabilitar, text_nombrehabilitar, tabla, listView1, '1');
            tipoUva.cumplimentarListaTipoUva(listView1, '0');// No tocar que tiene estructura propia
        }


        private void controladorHabilitarCaracteristica(CheckBox check_segurohabilitar, TextBox text_referencia, TextBox text_nombre, string tabla, ListView listView1, char activo)
        {
            if (check_segurohabilitar.Checked)
            {
                if (text_nombrehabilitar.Text == "" || text_referenciahabilitar.Text == "")
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
                else
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referenciahabilitar.Text, activo);
                    tipoUva.cumplimentarListaTipoUva(listView1, '0');// No tocar que tiene estructura propia
                    ut.limpiarCamposNuevoDeshabilitar(check_segurohabilitar, text_referenciahabilitar, text_nombrehabilitar);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }
    }
}

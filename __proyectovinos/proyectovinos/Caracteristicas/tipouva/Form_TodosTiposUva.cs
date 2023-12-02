using System;
using System.Windows.Forms;
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.variedaduva;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.Denominacion;*/

namespace proyectovinos.Caracteristicas.tipouva
{
    public partial class Form_TodosTiposUva : Form
    {
        public Form_TodosTiposUva()
        {
            InitializeComponent();
        }

        Class_TipoUvaAperturaForms tipoUvaAperturaForms=new Class_TipoUvaAperturaForms();
        Class_TipoUva tipoUva = new Class_TipoUva();
        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarComboboxes cump = new CumplimentarComboboxes();

        private int id_tipouva = 0;
        private bool cargaLista = true;

        private string id_tabla = "id_tipouva";
        private string tabla = "tipouva";


        private void Form_TodosTiposUva_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cump.refrescarCombo("nombre","variedaduva", combo_variedaduvanuevo);
            tipoUva.cumplimentarListaTipoUva(listView1,'1');// No tocar que tiene estructura propia

            id_tipouva = consultas.referenciaPredeterminada(id_tabla, tabla, "TU", text_referencianueva);
            cargaLista = false;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoUvaAperturaForms.modificararTipoUva();
        }


        // Ni tocar...
        private void button5_Click(object sender, EventArgs e)
        {
            if (check_seguronuevo.Checked)
            {
                if (text_nombrenuevo.Text != "" && text_referencianueva.Text != "")
                {
                    if (combo_variedaduvanuevo.Text == "Seleccione")
                    {
                        MessageBox.Show("Seleecione la variedad de uva");
                    }
                    else { 
                        string nombreVariedadUva = combo_variedaduvanuevo.Text;
                        int id_variedaduva = consultas.obtenerCualquierId("id_variedaduva", "variedaduva", "nombre",nombreVariedadUva);

                        tipoUva.insertTipoUva(id_tipouva, text_referencianueva.Text, text_nombrenuevo.Text, id_variedaduva,'1');
                        tipoUva.cumplimentarListaTipoUva(listView1,'1');// No tocar que tiene estructura propia
                        combo_variedaduvanuevo.Text = "Seleccione";

                        ut.limpiarCampos(text_nombrenuevo, text_referencianueva, text_referenciadeshabilitar, text_nombredeshabilitar, check_seguronuevo, check_segurodeshabilitar);
                        id_tipouva = consultas.referenciaPredeterminada(id_tabla, tabla, "TU", text_referencianueva);
                    }
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }


        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoUvaAperturaForms.eliminarTipoUva();
        }

        private void tiposDeUvaDeshabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoUvaAperturaForms.habilitarTipoUva();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tipoUva.controladorHabilitarTipoUva(check_segurodeshabilitar, text_referenciadeshabilitar, text_nombredeshabilitar, tabla, listView1, '0');
            tipoUva.cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
            ut.limpiarCamposNuevoDeshabilitar(check_segurodeshabilitar,text_referenciadeshabilitar, text_nombredeshabilitar);
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referenciadeshabilitar, tabla, text_nombredeshabilitar);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Class_VariedadUvaAperturaForms variedad = new Class_VariedadUvaAperturaForms();
            variedad.todasVariedadesUva();
            //variedad.todasVariedadesUvaII();
        }


        //
        private void combo_variedaduvanuevo_Click(object sender, EventArgs e)
        {
            CumplimentarComboboxes cumplimentar = new CumplimentarComboboxes();
            cumplimentar.refrescarCombo("nombre", "variedaduva", combo_variedaduvanuevo);
        }

        // Apertuta formulario todos artículos
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.todosArticulosVino();
            //articulo.todosArticulosVinoII();
        }
    }
}

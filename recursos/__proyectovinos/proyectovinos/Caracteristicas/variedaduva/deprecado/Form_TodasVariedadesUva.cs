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

namespace proyectovinos.Caracteristicas.variedaduva
{
    public partial class Form_TodasVariedadesUva : Form
    {
        public Form_TodasVariedadesUva()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();
        Class_VariedadUvaAperturaForms apertura = new Class_VariedadUvaAperturaForms();

        private int id_predeterminado = 0;
        private bool cargaLista = true;
        private string tabla = "variedaduva";
        private string nombreId = "id_variedaduva";
        private string refPredeterminada = "VU";
        private void Form_TodasVariedadesUva_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencianuevo);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            cargaLista = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Modelo a meter en otros
            if (check_seguronuevo.Checked == true)
            {
                if (text_nombrenuevo.Text != "" && text_referencianuevo.Text != "")
                {
                    bool insertado = consultas.insertTablaCaracteristicasDinamico(tabla, nombreId, id_predeterminado, text_referencianuevo.Text, text_nombrenuevo.Text);

                    if (insertado == true)
                    {
                        cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                        ut.limpiarCamposNuevoDeshabilitar(check_seguronuevo, text_nombrenuevo, text_referencianuevo);
                        id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencianuevo);
                    }
                    else
                    {
                        MessageBox.Show(ClaseCompartida.msgErrorGeneral);
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

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referenciadeshabilitar, tabla, text_nombredeshabilitar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ut.controladorHabilitarCaracteristica(check_segurodeshabilitar, text_referenciadeshabilitar, text_nombredeshabilitar, tabla, listView1, '0');
        }

        private void variedadesDeUvaDeshabilitadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.habilitarVariedadUva();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.eliminarVariedadUva();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.modificarVariedadUva();
        }
    }
}


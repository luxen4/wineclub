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
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.catalogacion;
using proyectovinos.Caracteristicas.clasesvino;
using proyectovinos.Roles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proyectovinos
{
    public partial class Form_TodasClasesVino : Form
    {
        public Form_TodasClasesVino()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();
        Class_ClaseVinoAperturaForms apertura = new Class_ClaseVinoAperturaForms();

        private int id_predeterminado = 0;
        private bool cargaLista = true;
        private string tabla = "clasevino";
        private string nombreId = "id_clasevino";
        private string refPredeterminada = "CLS";

        private void Form_TodasClasesVino_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencianuevo);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1,'1');
            cargaLista = false;
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            apertura.modificarClaseVino();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referenciadeshabilitar, tabla, text_nombredeshabilitar);
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

        private void button2_Click(object sender, EventArgs e)
        {
            ut.controladorHabilitarCaracteristica(check_segurodeshabilitar, text_referenciadeshabilitar, text_nombredeshabilitar, tabla, listView1,'0');
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void habilitarClaseVinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.habilitarClaseVino();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.eliminarClaseVino();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.nuevoArticuloVino(); this.Close();
        }
    }
}

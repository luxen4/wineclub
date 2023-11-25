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
using proyectovinos.Caracteristicas.Denominacion;
using proyectovinos.Roles;

namespace proyectovinos
{
    public partial class Form_TodasCatalogaciones : Form
    {
        public Form_TodasCatalogaciones()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();
        Class_CatalogacionAperturaForms apertura = new Class_CatalogacionAperturaForms();

        private string referencia = "";
        private int id_predeterminado = 0;
        private bool cargaLista = true;
        private string tabla = "catalogacion";
        private string nombreId = "id_catalogacion";
        private string refPredeterminada = "CAT";




        private void Form_TodasCatalogaciones_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencianuevo);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            cargaLista = false;
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    text_referenciadeshabilitar.Text = "";
                    text_nombredeshabilitar.Text = "";
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
            referencia = e.Item.Text;
            ut.checkMarcadoTodos(cargaLista, e, text_referenciadeshabilitar, tabla, text_nombredeshabilitar);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check_segurodeshabilitar.Checked)
            {

                if (text_referenciadeshabilitar.Text != "" || text_nombredeshabilitar.Text != "")
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referenciadeshabilitar.Text, '0');
                    id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referenciadeshabilitar);
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                    ut.limpiarCamposNuevoDeshabilitar(check_segurodeshabilitar, text_nombredeshabilitar, text_referenciadeshabilitar);
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

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            apertura.modificarCatalogacion(); // this.Close();
        }

        private void catalogacionesDesabilitadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.habilitarCatalogacion();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.eliminarCatalogacion();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.nuevoArticuloVino(); this.Close();
        }
    }
}

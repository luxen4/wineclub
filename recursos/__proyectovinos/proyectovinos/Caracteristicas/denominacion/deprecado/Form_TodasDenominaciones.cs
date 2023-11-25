using MySql.Data.MySqlClient;
using proyectovinos;
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.Denominacion;
using proyectovinos.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos
{
    public partial class Form_TodasDenominaciones : Form
    {
        public Form_TodasDenominaciones()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();
        Class_DenominacionAperturaForms apertura = new Class_DenominacionAperturaForms();

        private int id_predeterminado = 0;
        private bool cargaLista = true;
        private string tabla = "denominacion";
        private string nombreId = "id_denominacion";
        private string refPredeterminada = "DEN";


        private void Form_TodasDenominaciones_Load(object sender, EventArgs e)
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

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.modificarDenominacion();
        }


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ut.checkMarcadoTodos(cargaLista, e, text_referenciadeshabilitar, tabla, text_nombredeshabilitar);
        }

        private void button5_Click(object sender, EventArgs e)
        {   // Modelo a meter en otros
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
                    else {
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

        private void button3_Click(object sender, EventArgs e)
        {
            ut.controladorHabilitarCaracteristica(check_segurodeshabilitar, text_referenciadeshabilitar, text_nombredeshabilitar, tabla, listView1, '0');
        }

        private void denominacionesDeshabilitadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.habilitarDenominacion();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.eliminarDenominacion();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.nuevoArticuloVino();  this.Close();
        }
    }
}
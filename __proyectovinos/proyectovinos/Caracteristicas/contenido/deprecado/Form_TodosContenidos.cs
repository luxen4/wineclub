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
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.catalogacion;
using proyectovinos.Roles;

namespace proyectovinos.Caracteristicas.contenido
{
    public partial class Form_TodosContenidos : Form
    {
        public Form_TodosContenidos()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();
        Class_ContenidoAperturaForms apertura = new Class_ContenidoAperturaForms(); 
        Class_Contenido cont = new Class_Contenido();

        private string referencia = "";
        private int id_predeterminado = 0;
        private bool cargaLista = true;
        private string tabla = "formatocontenido";
        private string nombreId = "id_formatocontenido";
        private string refPredeterminada = "CON";

        private void Form_TodosContenidos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_nuevareferencia);
            cont.cumplimentarListaFormatoContenido(listView1); // Propio
            cargaLista = false;
        }

        

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            referencia = e.Item.Text;
            ut.checkMarcadoTodos(cargaLista, e, text_referenciadeshabilitar, tabla, text_nombredeshabilitar);
        }


        //Propio
        private void button5_Click(object sender, EventArgs e)
        {
            if (check_seguronuevo.Checked)
            {
                bool insertado = cont.insertFormatoContenido(id_predeterminado, text_nuevareferencia, text_nuevonombre, text_nuevocontenido);
                if (insertado==true) {
                    limpiarCamposNuevoContenido();
                    id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_nuevareferencia);
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                    ut.limpiarCamposNuevoDeshabilitar(check_segurodesabilitar, text_referenciadeshabilitar,text_nombredeshabilitar);
                }
            }
            else {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }

        //Propio
        private void limpiarCamposNuevoContenido()
        {
            text_nuevonombre.Text = "";
            text_nuevocontenido.Text = "";
            check_seguronuevo.Checked=false;
        }

 

        //Propio
        private void button2_Click(object sender, EventArgs e)
        {
            if (check_segurodesabilitar.Checked)
            {
                ut.habilitarOnOff_Caracteristica(tabla, "ref", referencia, '0');
                cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                ut.limpiarCamposNuevoDeshabilitar(check_segurodesabilitar, text_referenciadeshabilitar, text_nombredeshabilitar);
                limpiarCamposNuevoContenido();
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }

                id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_nuevareferencia);
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_ContenidoAperturaForms apertura = new Class_ContenidoAperturaForms();
            apertura.modificararContenido();
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.eliminarContenido();
        }

        private void contenidosInhabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.habilitarContenido();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.nuevoArticuloVino(); this.Close();
        }
    }
}
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
using proyectovinos.Roles;

namespace proyectovinos.Caracteristicas.empaquetado
{
    public partial class Form_TodosEmpaquetados : Form
    {
        public Form_TodosEmpaquetados()
        {
            InitializeComponent();
        }


        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();
        Class_EmpaquetadoAperturaForms apertura = new Class_EmpaquetadoAperturaForms();

       // private string referencia = "";
        private int id_predeterminado = 0;
        private bool cargaLista = true;
        private string tabla = "empaquetado";
        private string nombreId = "id_empaquetado";
        private string refPredeterminada = "EMP";

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

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            apertura.modificarEmpaquetado();
        }

        private void Form_todosEmpaquetados_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencianuevo);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            cargaLista = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ut.controladorHabilitarCaracteristica(check_segurodeshabilitar, text_referenciadeshabilitar, text_nombredeshabilitar, tabla, listView1, '0');
        }

        private void empaquetadosDeshabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.habilitarEmpaquetado();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apertura.eliminarEmpaquetado();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.nuevoArticuloVino();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}





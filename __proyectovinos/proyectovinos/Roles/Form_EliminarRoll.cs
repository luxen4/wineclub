using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.clasesvino;

namespace proyectovinos.Roles
{
    public partial class Form_EliminarRoll : Form
    {
        public Form_EliminarRoll()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        Class_ClaseVinoAperturaForms apertura = new Class_ClaseVinoAperturaForms();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();

        private bool cargaLista = true;
        private string id_tabla = "id_rollempleado";
        private string tabla = "rollempleado";

        private void Form_EliminarRoll_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
            cargaLista = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controladorEliminarRollEmpleado(check_seguroeliminar, text_referenciaeliminar, text_nombreeliminar, id_tabla, tabla, listView1);
            ut.limpiarCamposEliminar(text_referenciaeliminar, text_nombreeliminar, check_seguroeliminar);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
        }


        Consultas consultas = new Consultas();

        private void controladorEliminarRollEmpleado(CheckBox check_seguroeliminar, TextBox text_referenciaeliminar, TextBox text_nombreeliminar, string id_tabla, string tabla, ListView listView1)
        {
            MessageBox.Show("entro");
            if (check_seguroeliminar.Checked)
            {
                if (text_referenciaeliminar.Text != "")
                {
                    int id_rollempleado = consultas.obtenerCualquierId(id_tabla, tabla, "ref", text_referenciaeliminar.Text);

                    Class_Articulo articulo = new Class_Articulo();
                    int existencias = articulo.existeArticuloConCaracteristica("id_empleado", "empleado", id_tabla, id_rollempleado);

                    if (existencias > 0)
                    {
                        MessageBox.Show(existencias + ClaseCompartida.msgArticulosTipo);
                    }
                    else
                    {
                        consultas.eliminarCaracteristica(tabla, "ref", text_referenciaeliminar.Text);
                        cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                        ut.limpiarCamposEliminar(text_referenciaeliminar, text_nombreeliminar, check_seguroeliminar);
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
            ut.checkMarcadoTodos(cargaLista, e, text_referenciaeliminar, tabla, text_nombreeliminar);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;
using proyectovinos.Socios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos
{
    public partial class Form_EliminarSocio : Form
    {
        public Form_EliminarSocio()
        {
            InitializeComponent();
        }

        Consultas consultas = new Consultas();
        Class_Socio socio = new Class_Socio();

        private string tabla = "socio";

        private int id_socio = 0;
        private string refSocio = "";
        private int primeraVez = 0;


        private void limpiarCampos()
        {
            text_nombreapellidos.Text = "";
            check_seguroeliminar.Checked = false;
        }

        private void Form_EliminarSocio_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            socio.infoLista(listView1,'0');
            primeraVez = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

 
        // Método controlador que inicia la eliminación de un Socio y refresca la lista de Socios
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (primeraVez==1) { 
                refSocio = e.Item.Text;
                int index = e.Item.Index;

                text_nombreapellidos.Text = listView1.Items[index].SubItems[1].Text;
                id_socio = consultas.obtenerCualquierId("id_socio", tabla, "ref", refSocio);
              
                socio.agregarImagenPictureBoxSocio(id_socio, pictureBox1);
            }
        }

        // Método Controlador que dirige el proceso de eliminar un Socio
        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if (check_seguroeliminar.Checked)
            {
                int id = consultas.obtenerCualquierId("id_socio", tabla, "ref", refSocio);

                Class_Articulo articulo = new Class_Articulo();
                int existencias = articulo.existeArticuloConCaracteristica("id_ventasocio", "ventasocio", "id_socio", id);

                if (existencias > 0)
                {
                    MessageBox.Show(existencias + ClaseCompartida.msgArticulosTipo);
                       
                }
                else
                {
                    bool eliminado = consultas.eliminarCaracteristica(tabla, "ref", refSocio);
                    if (eliminado==true) {
                        Utilidades ut = new Utilidades();
                        ut.eliminarCarpeta("socios", id_socio);

                        text_nombreapellidos.Text = "";
                        listView1.Items.Clear();
                        primeraVez = 0;
                        socio.infoLista(listView1,'0');

                        primeraVez = 1;
                        text_nombreapellidos.Text = "";
                        check_seguroeliminar.Checked = false;
                    }
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }

    }
}



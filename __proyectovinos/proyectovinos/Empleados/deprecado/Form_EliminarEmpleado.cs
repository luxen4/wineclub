using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.tipouva;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos.Empleados
{
    public partial class Form_EliminarEmpleado : Form
    {
        public Form_EliminarEmpleado()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        Class_Empleado empleado = new Class_Empleado();
        Consultas consultas = new Consultas();
        Class_Articulo articulo = new Class_Articulo();

        private bool cargaLista = true;
        private string tabla = "empleado";
        private string id_tabla = "id_empleado";

        private string nombre = "", apellido1 = "", apellido2 = "";
        private string carpeta = "", nombreApellidos = "";
        private string referencia = "";
        private int id_empleado = 0;


        private void Form_EliminarEmpleado_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            empleado.cumplimentarlistasListaEmpleados(listView1, '0');// No tocar que tiene estructura propia
            cargaLista = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int index = e.Item.Index;
                nombre = listView1.Items[index].SubItems[1].Text;
                apellido1 = listView1.Items[index].SubItems[2].Text;
                apellido2 = listView1.Items[index].SubItems[3].Text;
            text_nombreapellidoseliminar.Text = nombre + " " +  apellido1 + " " + apellido2;

            referencia=listView1.Items[index].SubItems[0].Text;
            text_referenciaeliminar.Text = referencia;
            
            id_empleado = consultas.obtenerCualquierId("id_empleado","empleado","ref",referencia);
            
            try
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "empleados/" + id_empleado + "/perfil/foto1.jpg";

                using (StreamReader stream = new StreamReader(folderPath))

                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
            catch (Exception ex)
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "empleados/empleadopredeterminada.jpg";
                using (StreamReader stream = new StreamReader(folderPath))
                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
        }

        // Controlador para eliminar un Empleado
        private void button2_Click(object sender, EventArgs e)
        {  
            bool eliminado = controladorEliminarEmpleado(check_seguroeliminar, text_referenciaeliminar, text_nombreapellidoseliminar, id_tabla, tabla, listView1);

            if (eliminado==true) {

                ut.eliminarCarpeta("empleados",id_empleado);
                ut.limpiarCamposEliminar(text_referenciaeliminar, text_nombreapellidoseliminar, check_seguroeliminar);
                empleado.cumplimentarlistasListaEmpleados(listView1, '0');// No tocar que tiene estructura propia*/
            }
        }


        private bool controladorEliminarEmpleado(CheckBox check_seguroeliminar, TextBox text_referenciaeliminar, TextBox text_nombreeliminar, string id_tabla, string tabla, ListView listView1)
        { 
            if (check_seguroeliminar.Checked)
            {

                // Si es el dueño o engargado, no se puede eliminar
                int id = consultas.obtenerCualquierId(id_tabla, tabla, "ref", text_referenciaeliminar.Text);
                if (id == 1 || id == 2)
                {
                    MessageBox.Show("No se puede eliminar un dueño o encargado");
                    return false;
                }
                else { 
                    if (text_referenciaeliminar.Text != "")
                    {
                    
                        int existencias = articulo.existeArticuloConCaracteristica("id_ventasocio", "ventasocio", id_tabla, id);

                        if (existencias > 0)
                        {
                            MessageBox.Show("Este dependiente tiene Ventas hechas, no se puede eliminar");
                            return false;
                        }
                        else
                        {
                            consultas.eliminarCaracteristica(tabla, "ref", text_referenciaeliminar.Text);
                            return true;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                        return false;
                    }                
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
                return false;
            }
        }
    }
}

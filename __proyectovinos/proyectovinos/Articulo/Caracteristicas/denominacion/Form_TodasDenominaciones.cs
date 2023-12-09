using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Caracteristicas.Denominacion;

namespace proyectovinos.Caracteristicas.denominacion
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
        private string tabla = "denominacion";
        private string refPredeterminada = "DEN";
        private string referencia = "";
        private string id_tabla = "id_denominacion";

        private bool listaCargada=false;


        private void Form_TodasDenominacionesII_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, text_referencianuevo);
            limpiarCampos();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listaCargada = false;
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            listaCargada = true;

            button_habilitar.Enabled = false;
            button_deshabilitar.Enabled = true;
            button_eliminar.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listaCargada = false;
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
            listaCargada = true;
            button_habilitar.Enabled = true;
            button_deshabilitar.Enabled=false;
            button_eliminar.Enabled=true;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listaCargada==true) { 
                referencia=listView1.Items[e.Item.Index].SubItems[0].Text;

                textBox_referencia.Text = referencia;
                textBox_nombre.Text = listView1.Items[e.Item.Index].SubItems[1].Text;

                textBox_referenciamodificar.Text = referencia;
                textBox_nombremodificar.Text = listView1.Items[e.Item.Index].SubItems[1].Text;
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, text_referencianuevo);
            limpiarCampos();
        }



        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            consultas.modificarCualquierTabla(tabla, textBox_referencia.Text, textBox_nombre.Text, "ref", textBox_referencia.Text, listView1);
            limpiarCampos();
            radioButton_habilitado.Checked = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Modelo a meter en otros
            if (check_seguronuevo.Checked == true)
            {
                if (text_nombrenuevo.Text != "" && text_referencianuevo.Text != "")
                {
                    bool insertado = consultas.insertTablaCaracteristicasDinamico(tabla, id_tabla, id_predeterminado, text_referencianuevo.Text, text_nombrenuevo.Text);

                    if (insertado == true)
                    {
                        limpiarCampos();
                        id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, text_referencianuevo);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox_seguromodificar.Checked == true)
            {
                if (textBox_nombremodificar.Text != "" || textBox_referenciamodificar.Text != "")
                {
                    consultas.modificarCualquierTabla(tabla, textBox_referenciamodificar.Text, textBox_nombremodificar.Text, "ref",referencia, listView1);
                    limpiarCampos();
                }
                else {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nueva.Checked == true)
            {
                groupBox_nueva.Enabled = true;
                id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, text_referencianuevo);
            }
            else if (check_nueva.Checked == false)
            {
                groupBox_nueva.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listaCargada = false;
            ut.controladorHabilitarCaracteristica(check_segurohabilitardeshabilitareliminar, textBox_referencia, textBox_nombre, tabla, listView1, '1');
            listaCargada = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check_segurohabilitardeshabilitareliminar.Checked == true)
            {   // reforma del chek de abajo que se repite
                listaCargada = false;
                ut.controladorHabilitarCaracteristica(check_segurohabilitardeshabilitareliminar, textBox_referencia, textBox_nombre, tabla, listView1, '0');
                listaCargada = true;
                limpiarCampos();
            }
            else {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (check_segurohabilitardeshabilitareliminar.Checked == true)
            {
                ut.controladorEliminarCaracteristica(check_segurohabilitardeshabilitareliminar, textBox_referencia, textBox_nombre, id_tabla, tabla, listView1);
                limpiarCampos();
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }

        private void check_modificar_CheckedChanged(object sender, EventArgs e)
        {
            if (check_modificar.Checked == true)
            {
                groupBox_modificar.Enabled = true;
            }
            else if (check_modificar.Checked == false)
            {
                groupBox_modificar.Enabled = false;
            }
        }


        private void limpiarCampos()
        {
            radioButton_habilitado.Checked = true;
            radioButton_deshabilitado.Checked = false;

            check_segurohabilitardeshabilitareliminar.Checked = true;

            textBox_referencia.Text = "";
            textBox_nombre.Text = "";

            button_habilitar.Enabled = false;
            button_deshabilitar.Enabled = true;
            button_eliminar.Enabled = false;

            text_referencianuevo.Text = "";
            text_nombrenuevo.Text = "";

            textBox_referenciamodificar.Text = "";
            textBox_nombremodificar.Text = "";

            check_nueva.Checked = false;
            check_modificar.Checked = false;

            check_segurohabilitardeshabilitareliminar.Checked = false;
            check_seguronuevo.Checked = false;
            checkBox_seguromodificar.Checked = false;

            listaCargada = false;
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            listaCargada = true;
        }
    }
}

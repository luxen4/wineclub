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

namespace proyectovinos.Articulo
{
    public partial class Form_HabilitarArticulos : Form
    {
        public Form_HabilitarArticulos()
        {
            InitializeComponent();
        }

        private string refArticulo = "";
        private int existenciasAlmacen = 0, existenciasTienda = 0;
        private int primeravez = 0;

        Consultas consultas = new Consultas();
        Class_Articulo articulo = new Class_Articulo();


        private void Form_HabilitarArticulos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            articulo.cumplimentarListaArticulos(listView1,'0');
            primeravez = 1;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (text_refarticulo.Text != "")
            {
                if (existenciasAlmacen == 0 && existenciasTienda == 0)
                {
                    if (check_seguro.Checked)
                    {
                        refArticulo = text_refarticulo.Text;
                        consultas.habilitarDesabilitarCualquierReferencia("articulo", "ref", refArticulo, '1');
                        articulo.cumplimentarListaArticulos(listView1,'0');
                        articulo.limpiarCampos(text_unidadesalmacen, text_unidadestienda, text_empaquetado, check_seguro, pictureBox1);
                    }
                    else
                    {
                        MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
                    }
                }
                else
                {
                    MessageBox.Show("No puede eliminar este artículo ya que hay existencias en la Vinoteca");
                }
            }
            else {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (primeravez==1) { 
                articulo.articuloSeleccionado( e, text_refarticulo, listView1, text_unidadesalmacen, text_unidadestienda, text_empaquetado, pictureBox1);
            }
        }
    }
}

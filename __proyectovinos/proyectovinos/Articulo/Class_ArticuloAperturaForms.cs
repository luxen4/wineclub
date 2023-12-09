using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.ArticuloVino;

namespace proyectovinos.ArticuloVino
{
    internal class Class_ArticuloAperturaForms
    {

        /// <summary>
        /// Abrir el formulario de Todos artículos.
        /// </summary>
        public void todosArticulosVino()
        {
            Form_TodosArticulosVino form;
            if (Application.OpenForms["Form_TodosArticulosVino"] != null)
            {
                Application.OpenForms["Form_TodosArticulosVino"].Activate();
            }
            else
            {
                form = new Form_TodosArticulosVino();
                //formulario.MdiParent = this;
                form.Show();
            }
        }


        /// <summary>
        /// Abrir el formulario de Nevo un articulo.
        /// </summary>
        public void nuevoArticuloVino()
        {
            Form_NuevoArticulo form;
            if (Application.OpenForms["FormNuevoArticuloVino"] != null)
            {
                Application.OpenForms["FormNuevoArticuloVino"].Activate();
            }
            else
            {
                form = new Form_NuevoArticulo();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        /// <summary>
        /// Abrir el formulario de Modificar un articulo.
        /// </summary>
        internal void modificarArticuloVino()
        {
            Form_ModificarArticulo form;
            if (Application.OpenForms["Form_ModificarArticulo"] != null)
            {
                Application.OpenForms["Form_ModificarArticulo"].Activate();
            }
            else
            {
                form = new Form_ModificarArticulo();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

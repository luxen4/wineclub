﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Articulo;

namespace proyectovinos.ArticuloVino
{
    internal class Class_ArticuloAperturaForms
    {

       
       
       
       

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

        // Método que abre el formulario de Articulos inhabilitados con posibilidad de habilitarlos
        public void articulosInhabilitados()
        {
            Form_HabilitarArticulos form;
            if (Application.OpenForms["Form_HabilitarArticulos"] != null)
            {
                Application.OpenForms["Form_HabilitarArticulos"].Activate();
            }
            else
            {
                form = new Form_HabilitarArticulos();
                //formulario.MdiParent = this;
                form.Show();
            }

        }
        
        /*
        public void todosArticulosVino()
        {
            Form_TodosArticulosVino form;
            if (Application.OpenForms["Form_TodosArticulosVino"] != null)
            {
                Application.OpenForms["Form_TodosArticulosVino"].Activate();
            }
            else
            {
                form= new Form_TodosArticulosVino();
                //formulario.MdiParent = this;
                form.Show();
            }
        }*/


        public void todosArticulosVinoII()
        {
            Form_TodosArticulosVinoII form;
            if (Application.OpenForms["Form_TodosArticulosVinoII"] != null)
            {
                Application.OpenForms["Form_TodosArticulosVinoII"].Activate();
            }
            else
            {
                form = new Form_TodosArticulosVinoII();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void eliminarArticuloVino()
        {
            Form_EliminarArticuloVino form;
            if (Application.OpenForms["Form_EliminarArticuloVino"] != null)
            {
                Application.OpenForms["Form_EliminarArticuloVino"].Activate();
            }
            else
            {
                form = new Form_EliminarArticuloVino();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

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

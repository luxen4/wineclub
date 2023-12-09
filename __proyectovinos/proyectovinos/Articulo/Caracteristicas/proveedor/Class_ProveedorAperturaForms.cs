using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Movimientos;

namespace proyectovinos.Caracteristicas.proveedor
{
    internal class Class_ProveedorAperturaForms
    {
            public void nuevoProveedor()
            {  
                Form_NuevoProveedor form;
                if (Application.OpenForms["Form_NuevoProveedor"] != null)
                {
                    Application.OpenForms["Form_NuevoProveedor"].Activate();
                }
                else
                {
                    form = new Form_NuevoProveedor();
                    //formulario.MdiParent = this;
                    form.Show();
                } 
            }

            public void modificarProveedor()
            {
                Form_ModificarProveedor form;
                if (Application.OpenForms["Form_ModificarProveedor"] != null)
                {
                    Application.OpenForms["Form_ModificarProveedor"].Activate();
                }
                else
                {
                    form = new Form_ModificarProveedor();
                    //formulario.MdiParent = this;
                    form.Show();
                }
            }

        public void todosProveedores()
        {
            Form_TodosProveedores form;
            if (Application.OpenForms["Form_TodosProveedores"] != null)
            {
                Application.OpenForms["Form_TodosProveedores"].Activate();
            }
            else
            {
                form = new Form_TodosProveedores();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
        

        // Método que abre el formulario de compra de artículos a un Proveedor
        public void comprarArticuloProveedor()
        {
            Form_CompraArticulosProveedor form;
            if (Application.OpenForms["FormCompraArticulosProveedor"] != null)
            {
                Application.OpenForms["FormCompraArticulosProveedor"].Activate();
            }
            else
            {
                form = new Form_CompraArticulosProveedor();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        // Método que abre el formulario de devolución de artículos a un Proveedor
        public void devolucionArticuloProveedor()
        {
            Form_DevolucionArticulosProveedor form;
            if (Application.OpenForms["FormDevolucionArticulosProveedor"] != null)
            {
                Application.OpenForms["FormDevolucionArticulosProveedor"].Activate();
            }
            else
            {
                form = new Form_DevolucionArticulosProveedor();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

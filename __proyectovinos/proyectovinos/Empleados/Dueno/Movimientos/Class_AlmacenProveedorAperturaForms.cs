using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace proyectovinos.VentasDevolucionesSocio
{
    internal class Class_AlmacenProveedorAperturaForms
    {

        Form_ModificarPreciosArticulos formularioModificarPreciosLineaCompraProveedor;
        public void modificarPreciosArticuloVino()
        {
            if (Application.OpenForms["FormModificarPreciosLineaCompraProveedor"] != null)
            {
                Application.OpenForms["FormModificarPreciosLineaCompraProveedor"].Activate();
            }
            else
            {
                formularioModificarPreciosLineaCompraProveedor = new Form_ModificarPreciosArticulos();
                //formulario.MdiParent = this;
                formularioModificarPreciosLineaCompraProveedor.Show();
            }
        }
    }
}

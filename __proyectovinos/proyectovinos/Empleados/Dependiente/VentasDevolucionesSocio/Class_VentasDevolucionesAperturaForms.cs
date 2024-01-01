using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.VentasDevolucionesSocio
{
    internal class Class_VentasDevolucionesAperturaForms
    {
        Form_DevolucionSocio formularioDevolucionSocio;
        Form_VentaSocio formularioVentaSocio;


        public void nuevaDevolucionSocio()
        {
            if (Application.OpenForms["Form_DevolucionSocio"] != null)
            {
                Application.OpenForms["Form_DevolucionSocio"].Activate();
            }
            else
            {
                formularioDevolucionSocio = new Form_DevolucionSocio();
                //formulario.MdiParent = this;
                formularioDevolucionSocio.Show();
            }

        }

        public void nuevaVentaSocio()
        {
            if (Application.OpenForms["Form_VentaSocio"] != null)
            {
                Application.OpenForms["Form_VentaSocio"].Activate();
            }
            else
            {
                formularioVentaSocio = new Form_VentaSocio();
                //formulario.MdiParent = this;
                formularioVentaSocio.Show();
            }
        }

        public void modificarArticuloVenta()
        {
            Form_ModificarPreciosArticulos formulario;

            if (Application.OpenForms["Form_ModificarArticuloVenta"] != null)
            {
                Application.OpenForms["Form_ModificarArticuloVenta"].Activate();
            }
            else
            {
                formulario = new Form_ModificarPreciosArticulos();
                //formulario.MdiParent = this;
                formulario.Show();
            }
        }
    }
}

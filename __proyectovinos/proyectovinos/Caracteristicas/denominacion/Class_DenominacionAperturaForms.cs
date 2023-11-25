using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Caracteristicas.denominacion;

namespace proyectovinos.Caracteristicas.Denominacion
{
    internal class Class_DenominacionAperturaForms
    {

       
        


        public void modificarDenominacion()
        {
            Form_ModificarDenominacion form;
            if (Application.OpenForms["Form_ModificarDenominacion"] != null)
            {
                Application.OpenForms["Form_ModificarDenominacion"].Activate();
            }
            else
            {
                form = new Form_ModificarDenominacion();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void todasDenominaciones()
        {
            Form_TodasDenominaciones form;
            if (Application.OpenForms["Form_TodasDenominaciones"] != null)
            {
                Application.OpenForms["Form_TodasDenominaciones"].Activate();
            }
            else
            {
                form = new Form_TodasDenominaciones();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void todasDenominacionesII()
        {
            Form_TodasDenominacionesII form;
            if (Application.OpenForms["Form_TodasDenominacionesII"] != null)
            {
                Application.OpenForms["Form_TodasDenominacionesII"].Activate();
            }
            else
            {
                form = new Form_TodasDenominacionesII();
                //formulario.MdiParent = this;
                form.Show();
            }
        }


        internal void eliminarDenominacion()
        {

            Form_EliminarDenominacion form;
            if (Application.OpenForms["Form_EliminarDenominacion"] != null)
            {
                Application.OpenForms["Form_EliminarDenominacion"].Activate();
            }
            else
            {
                form = new Form_EliminarDenominacion();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void habilitarDenominacion()
        {
            Form_HabilitarDenominacion form;
            if (Application.OpenForms["Form_HabilitarDenominacion"] != null)
            {
                Application.OpenForms["Form_HabilitarDenominacion"].Activate();
            }
            else
            {
                form = new Form_HabilitarDenominacion();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
        
    }
    
}


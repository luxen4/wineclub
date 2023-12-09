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
        
    }
    
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Caracteristicas.clasesvino;

namespace proyectovinos.Caracteristicas.variedaduva
{
    internal class Class_VariedadUvaAperturaForms
    {
        internal void todasVariedadesUva()
        {
            Form_TodasVariedadesUva form;
            if (Application.OpenForms["Form_TodasVariedadesUva"] != null)
            {
                Application.OpenForms["Form_TodasVariedadesUva"].Activate();
            }
            else
            {
                form = new Form_TodasVariedadesUva();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

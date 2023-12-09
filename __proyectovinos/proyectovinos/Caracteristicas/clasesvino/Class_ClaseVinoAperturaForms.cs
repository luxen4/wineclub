using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Caracteristicas.clasesvino
{
    internal class Class_ClaseVinoAperturaForms
    {
        public void todasClasesVino()
        {
            Form_TodasClasesVino form;
            if (Application.OpenForms["Form_TodasClases"] != null)
            {
                Application.OpenForms["Form_TodasClases"].Activate();
            }
            else
            {
                form = new Form_TodasClasesVino();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

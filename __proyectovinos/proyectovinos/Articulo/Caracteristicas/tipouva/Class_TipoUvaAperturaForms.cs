using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Caracteristicas.tipouva
{
    internal class Class_TipoUvaAperturaForms
    {
        // Apertura de formulario de tipo de uva
        public void todosTiposUva()
        {
            Form_TodosTiposUva form;
            if (Application.OpenForms["Form_TodosTiposUva"] != null)
            {
                Application.OpenForms["Form_TodosTiposUva"].Activate();
            }
            else
            {
                form = new Form_TodosTiposUva();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

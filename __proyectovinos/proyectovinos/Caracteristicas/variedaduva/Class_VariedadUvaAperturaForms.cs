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
        internal void eliminarVariedadUva()
        {
            Form_EliminarVariedadUva form;
            if (Application.OpenForms["Form_EliminarVariedadUva"] != null)
            {
                Application.OpenForms["Form_EliminarVariedadUva"].Activate();
            }
            else
            {
                form = new Form_EliminarVariedadUva();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void habilitarVariedadUva()
        {
            Form_HabilitarVariedadUva form;
            if (Application.OpenForms["Form_HabilitarVariedadUva"] != null)
            {
                Application.OpenForms["Form_HabilitarVariedadUva"].Activate();
            }
            else
            {
                form = new Form_HabilitarVariedadUva();
                //formulario.MdiParent = this;
                form.Show();
            }
        }



        internal void modificarVariedadUva()
        {
            Form_ModificarVariedadUva form;
            if (Application.OpenForms["Form_ModificarVariedadUva"] != null)
            {
                Application.OpenForms["Form_ModificarVariedadUva"].Activate();
            }
            else
            {
                form = new Form_ModificarVariedadUva();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

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

        internal void todasVariedadesUvaII()
        {
            Form_TodasVariedadesUvaII form;
            if (Application.OpenForms["Form_TodasVariedadesUvaII"] != null)
            {
                Application.OpenForms["Form_TodasVariedadesUvaII"].Activate();
            }
            else
            {
                form = new Form_TodasVariedadesUvaII();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

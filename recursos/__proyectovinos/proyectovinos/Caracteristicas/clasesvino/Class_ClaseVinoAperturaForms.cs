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
       

        public void modificarClaseVino()
        { 
            Form_ModificarClaseVino form;
            if (Application.OpenForms["Form_ModificarClaseVino"] != null)
            {
                Application.OpenForms["Form_ModificarClaseVino"].Activate();
            }
            else
            {
                form = new Form_ModificarClaseVino();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void todasClasesVino()
        {
            proyectovinos.Form_TodasClasesVino form;
            if (Application.OpenForms["Form_TodasClasesVino"] != null)
            {
                Application.OpenForms["Form_TodasClasesVino"].Activate();
            }
            else
            {
                form = new proyectovinos.Form_TodasClasesVino();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void todasClasesVinoII()
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


        internal void habilitarClaseVino()
        {
            Form_HabilitarClaseVino form;
            if (Application.OpenForms["Form_HabilitarClaseVino"] != null)
            {
                Application.OpenForms["Form_HabilitarClaseVino"].Activate();
            }
            else
            {
                form = new Form_HabilitarClaseVino();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void eliminarClaseVino()
        {
            Form_EliminarClaseVino form;
            if (Application.OpenForms["Form_EliminarClaseVino"] != null)
            {
                Application.OpenForms["Form_EliminarClaseVino"].Activate();
            }
            else
            {
                form = new Form_EliminarClaseVino();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

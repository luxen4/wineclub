using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Empleados;

namespace proyectovinos.Socios
{
    internal class Class_SocioAperturaForms
    {
        public void todosSocios()
        {
            Form_TodosSocios form;
            if (Application.OpenForms["Form_TodosSocios"] != null)
            {
                Application.OpenForms["Form_TodosSocios"].Activate();
            }
            else
            {
                form = new Form_TodosSocios();
                //formulario.MdiParent = this;
                form.Show();
            }
        }



        public void nuevoSocio()
        {
            Form_NuevoSocio form;
            if (Application.OpenForms["FormNuevoSocio"] != null)
            {
                Application.OpenForms["FormNuevoSocio"].Activate();
            }
            else
            {
                form = new Form_NuevoSocio();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
        public void modificarSocio()
        {
            Form_ModificarSocio form;
            if (Application.OpenForms["FormModificarSocio"] != null)
            {
                Application.OpenForms["FormModificarSocio"].Activate();
            }
            else
            {
                form = new Form_ModificarSocio();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
        public void eliminarSocio()
        {
            Form_EliminarSocio form;
            if (Application.OpenForms["FormEliminarSocio"] != null)
            {
                Application.OpenForms["FormEliminarSocio"].Activate();
            }
            else
            {
                form = new Form_EliminarSocio();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void socioInhabilitados()
        {
            Form_HabilitarSocios form;
            if (Application.OpenForms["Form_HabilitarSocios"] != null)
            {
                Application.OpenForms["Form_HabilitarSocios"].Activate();
            }
            else
            {
                form = new Form_HabilitarSocios();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

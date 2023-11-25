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

        
        public void modificararTipoUva()
        {
            Form_ModificarTipoUva form;
            if (Application.OpenForms["Form_ModificararTipoUva"] != null)
            {
                Application.OpenForms["Form_ModificararTipoUva"].Activate();
            }
            else
            {
                form = new Form_ModificarTipoUva();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void eliminarTipoUva()
        {
            Form_EliminarTipoUva form;
            if (Application.OpenForms["Form_EliminarTipoUva"] != null)
            {
                Application.OpenForms["Form_EliminarTipoUva"].Activate();
            }
            else
            {
                form = new Form_EliminarTipoUva();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void habilitarTipoUva()
        {
            Form_HabilitarTipoUva form;
            if (Application.OpenForms["Form_HabilitarTipoUva"] != null)
            {
                Application.OpenForms["Form_HabilitarTipoUva"].Activate();
            }
            else
            {
                form = new Form_HabilitarTipoUva();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}

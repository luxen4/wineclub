using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Caracteristicas.tipouva;

namespace proyectovinos.Caracteristicas.contenido
{
    internal class Class_ContenidoAperturaForms
    {

       
        Form_ModificarContenido formularioModificarFormatoContenido;


        public void todosContenidos()
        { Form_TodosContenidos formularioTodosContenidos;
            if (Application.OpenForms["Form_TodosContenidos"] != null)
            {
                Application.OpenForms["Form_TodosContenidos"].Activate();
            }
            else
            {
                formularioTodosContenidos = new Form_TodosContenidos();
                //formulario.MdiParent = this;
                formularioTodosContenidos.Show();
            }
        }

        public void todosContenidosII()
        {
            Form_TodosContenidosII formularioTodosContenidos;
            if (Application.OpenForms["Form_TodosContenidosII"] != null)
            {
                Application.OpenForms["Form_TodosContenidosII"].Activate();
            }
            else
            {
                formularioTodosContenidos = new Form_TodosContenidosII();
                //formulario.MdiParent = this;
                formularioTodosContenidos.Show();
            }
        }


        public void modificararContenido()
        {
            if (Application.OpenForms["Form_ModificarContenido"] != null)
            {
                Application.OpenForms["Form_ModificarContenido"].Activate();
            }
            else
            {
                formularioModificarFormatoContenido = new Form_ModificarContenido();
                //formulario.MdiParent = this;
                formularioModificarFormatoContenido.Show();
            }
        }

        internal void eliminarContenido()
        {
            Form_EliminarContenido form;
            if (Application.OpenForms["Form_EliminarContenido"] != null)
            {
                Application.OpenForms["Form_EliminarContenido"].Activate();
            }
            else
            {
                form = new Form_EliminarContenido();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void habilitarContenido()
        {
            Form_HabilitarContenido form;
            if (Application.OpenForms["Form_HabilitarContenido"] != null)
            {
                Application.OpenForms["Form_HabilitarContenido"].Activate();
            }
            else
            {
                form = new Form_HabilitarContenido();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }

}

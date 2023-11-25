using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Caracteristicas.tipouva;
using proyectovinos.Empleados;
using proyectovinos.Movimientos;
using proyectovinos.Roles;

namespace proyectovinos
{
    public class AperturaFormulariosArticulo
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }

     






        /*
        Form_DevolucionSocio formularioDevolucionSocio;
            public void nuevaDevolucionSocio()
        {
            if (Application.OpenForms["Form_DevolucionSocio"] != null)
            {
                Application.OpenForms["Form_DevolucionSocio"].Activate();
            }
            else
            {
                formularioDevolucionSocio = new Form_DevolucionSocio();
                //formulario.MdiParent = this;
                formularioDevolucionSocio.Show();
            }
            
        }*/



    }







}

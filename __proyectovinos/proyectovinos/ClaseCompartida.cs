using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectovinos
{
    internal class ClaseCompartida
    {
        public static string baseDatos = "";


        // Para registrar ventas
        public static string refe = "";


        // Para rótulo de Presentación
        public static string nombre = "", apellido1 = "", apellido2;
        public static string roll="";
        

        // Por si decide cambiarlos
        public static string usuario = "";
        public static string contrasena ="";



        public static string msgSelectRegistro = "Seleccione un registro";
        public static string msgInsertado = "Registro Insertado";
        public static string msgHabilitado = "Registro Habilitado";
        public static string msgDesHabilitado = "Registro Deshabilitado";        
        public static string msgEliminado = "Registro Eliminado";
        public static string msgModificado = "Registro Modificado";

        public static string msgCamposEnBlanco = "Campos en blanco";
        public static string msgCasillaSeguro = "Marque la casilla de seguro";

        public static string msgArticulosTipo = " artículos de este tipo...¡No se puede eliminar!";
        public static string msgRegistroIgual = "Ya se encuentra un registro igual";
        public static string msgErrorGeneral = "Error no identificado!";


        public static string alojamientoarchivos="local";

        public static string carpetaimg_absoluta = "C:/wineclub/img/";
        public static string carpetafacturas_absoluta = "C:/wineclub/facturas/socios/";

        public static string refVentaSocio = "";
    }
}
// relativa
// string folderPath = @"../../img/empleados/empleadopredeterminada.jpg";
// string folderPath = @"../../img/empleados/" + carpeta + "/perfil/foto1.jpg";
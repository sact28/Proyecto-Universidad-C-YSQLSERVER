using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Santiago Canel
//0900-22-1504
namespace EjercicioCompletoArchivos
{
    public class clsEmppleadoEN
    {
        //Defino los campos que tendra mi tabla empleados, y que datos le quiero mandar. 

        public Int32 lIdEmpleado { get; set; }

        public String lStrNombreEmpleado { get; set; }

        public String lStrDireccion { get; set; }

        public String lStrTelefono { get; set; }

        public int lIntIdPuesto {  get; set; }

        public clsEmppleadoEN() { }

        public clsEmppleadoEN(Int32 pIntIdEmpleado, String pStrNombreEmpleado, string pstrDireccion, String pStrTelefono, int pintIdPuesto)
        {
            this.lIdEmpleado = pIntIdEmpleado;
            this.lStrNombreEmpleado = pStrNombreEmpleado;
            this.lStrDireccion = pstrDireccion;
            this.lStrTelefono = pStrTelefono;
            this.lIntIdPuesto = pintIdPuesto;
        }
    }
}

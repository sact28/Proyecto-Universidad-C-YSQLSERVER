using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Santiago Canel
//0900-22-1504
namespace EjercicioCompletoArchivos
{
    public class clsPuestoEN
    {
        //Defino los campos que mandare a mi base de datos
        public Int32 lIdPuesto { get; set; }

        public String lStrNombrePuesto { get; set; }

        public Double lDbSalario { get; set; }

        public clsPuestoEN() { }

        public clsPuestoEN(int pIntIdPuesto, string pStrNombrePuesto, Double pDbSalario)
        {
            this.lIdPuesto = pIntIdPuesto;
            this.lStrNombrePuesto = pStrNombrePuesto;
            this.lDbSalario = pDbSalario;
        }
    }
}

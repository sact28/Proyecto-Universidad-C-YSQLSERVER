using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Santiago Canel
//0900-22-1504
namespace EjercicioCompletoArchivos
{
    public class clsConexionSQL
    {
        //Obtenemos la conexion con la base de datos creada. 
        public static SqlConnection SubObtenerConexion()
        {
            SqlConnection lObjConexion = new SqlConnection("Data Source=.\\sqlexpress; Initial Catalog = EMPLEADOSB; User Id = prueba; Password =system32");
            lObjConexion.Open();

            return lObjConexion;
        }
        public int FcnlAgregar(clsPuestoEN lObjPuesto)
        {
            int lintResultado = 0;
            using (SqlConnection lObjConexion = SubObtenerConexion())
            {
                SqlCommand lObjComando = new SqlCommand(String.Format(" INSERT INTO Puesto (CodigoPuesto, NombrePuesto, Salario) VALUES ({0}, '{1}', {2})",
                    lObjPuesto.lIdPuesto, lObjPuesto.lStrNombrePuesto, lObjPuesto.lDbSalario),lObjConexion);

                lintResultado = lObjComando.ExecuteNonQuery();
            }


                return lintResultado;
        }
        //Metodo donde se enviaran los datos a la base de datos creada.
        public int FncConsultar()
        {
            int lintResultado = 0;
            using (
                SqlConnection lObjConexion = SubObtenerConexion())
            {
                SqlCommand lObjComando = new SqlCommand(String.Format("SELECT ISNULL(max(codigopuesto),0)+1 IdPuesto FROM Puesto"), lObjConexion);
                SqlDataAdapter lObjAdaptardor = new SqlDataAdapter();
                lObjAdaptardor.SelectCommand = lObjComando;
                DataTable ldttTabla = new DataTable();
                lObjAdaptardor.Fill(ldttTabla);
                if (ldttTabla.Rows.Count > 0)
                {
                    lintResultado = Convert.ToInt32(ldttTabla.Rows[0]["IdPuesto"].ToString());
                }
                else 
                {
                    lintResultado = 1;
                }
            }
            return lintResultado;

        }
        // Metodo donde validaremos si existe el puesto o no 
        public int FncConsultarIdPuesto(int pIntIdPuesto)
        {
            int lintResultado = 0;
            using (SqlConnection lObjConexion = SubObtenerConexion())
            {
                SqlCommand lObjComando = new SqlCommand(String.Format("SELECT * FROM Puesto where codigopuesto={0}", pIntIdPuesto ), lObjConexion);
                SqlDataAdapter lObjAdaptardor = new SqlDataAdapter();
                lObjAdaptardor.SelectCommand = lObjComando;
                DataTable ldttTabla = new DataTable();
                lObjAdaptardor.Fill(ldttTabla);
                if (ldttTabla.Rows.Count > 0)
                {
                    lintResultado = Convert.ToInt32(ldttTabla.Rows[0]["IdPuesto"].ToString());
                }
                else
                {
                    lintResultado = 1;
                }
            }
            return lintResultado;

        }

        //Metodo para agregar empleado, con sus campos requeridos 
        public int FcnlAgregarEmpleado(clsEmppleadoEN lObjEmpleado)
        {
            int lintResultado = 0;
            using (SqlConnection lObjConexion = SubObtenerConexion())
            {
                SqlCommand lObjComando = new SqlCommand(String.Format(" INSERT INTO Empleado (CodigoEmpleado, NombreEmpleado, Direccion, Telefono, CodigoPuesto) VALUES ({0}, '{1}', '{2}', '{3}', '{4}')",
                    lObjEmpleado.lIdEmpleado, lObjEmpleado.lStrNombreEmpleado, lObjEmpleado.lStrDireccion, lObjEmpleado.lStrTelefono, lObjEmpleado.lIntIdPuesto), lObjConexion);

                lintResultado = lObjComando.ExecuteNonQuery();
            }


            return lintResultado;
        }
        
        //Metodo consultar empleado en la base de datos sql 
        public int FncConsultarEmpleado()
        {
            int lintResultado = 0;
            using (SqlConnection lObjConexion = SubObtenerConexion())
            {
                SqlCommand lObjComando = new SqlCommand(String.Format("SELECT ISNULL(max(codigoempleado), 0)+1 IdEmpleado FROM Empleado"), lObjConexion);
                SqlDataAdapter lObjAdaptardor = new SqlDataAdapter();
                lObjAdaptardor.SelectCommand = lObjComando;
                DataTable ldttTabla = new DataTable();
                lObjAdaptardor.Fill(ldttTabla);
                if (ldttTabla.Rows.Count > 0)
                {
                    lintResultado = Convert.ToInt32(ldttTabla.Rows[0]["IdEmpleado"].ToString());
                }
                else
                {
                    lintResultado = 1;
                }
            }
            return lintResultado;

        }

        public int FncConsultarIdEmpleado(int pIntIdEmpleado)
        {
            int lintResultado = 0;
            using (SqlConnection lObjConexion = SubObtenerConexion())
            {
                SqlCommand lObjComando = new SqlCommand(String.Format("SELECT * FROM Empleado where codigoempleado={0}", pIntIdEmpleado), lObjConexion);
                SqlDataAdapter lObjAdaptardor = new SqlDataAdapter();
                lObjAdaptardor.SelectCommand = lObjComando;
                DataTable ldttTabla = new DataTable();
                lObjAdaptardor.Fill(ldttTabla);
                if (ldttTabla.Rows.Count > 0)
                {
                    lintResultado = Convert.ToInt32(ldttTabla.Rows[0]["IdEmpleado"].ToString());
                }
                else
                {
                    lintResultado = 1;
                }
            }
            return lintResultado;

        }
    }
}

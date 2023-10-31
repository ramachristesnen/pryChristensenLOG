using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace pryChristensenLOG
{
    internal class clsAccesoBD
    {
        public string EstadoConexion;
        public string Errores;
        public string DatosExtraidos;


        OleDbConnection conexionBD;
        public string rutaArchivo;
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;

        
       


        public void ConectarBaseDatos()
        {
            try
            {
                if (rutaArchivo == null)
                {
                    rutaArchivo = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ../../CarpetaBase/LOG1.accdb";
                }
                else
                {
                    rutaArchivo = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + rutaArchivo;
                }


                conexionBD = new OleDbConnection();

                conexionBD.ConnectionString = rutaArchivo;

                conexionBD.Open();

                EstadoConexion = "Conectado a la base " + conexionBD.DataSource;
            }
            catch (Exception exepcion)
            {
                EstadoConexion = "Error en la conexión." + exepcion.Message;
            }

        }
        public void TraerDatos(DataGridView grilla)
        {
            try
            {
                comandoBD = new OleDbCommand();
                if (rutaArchivo == null)
                {
                    rutaArchivo = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ../../CarpetaBase/LOG1.accdb";
                }
                else
                {
                    rutaArchivo = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + rutaArchivo;
                }
                conexionBD = new OleDbConnection();

                conexionBD.ConnectionString = rutaArchivo;

                conexionBD.Open();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Registros";

                lectorBD = comandoBD.ExecuteReader();

                grilla.Columns.Add("ID", "ID");
                grilla.Columns.Add("Categoria", "Categoria");
                grilla.Columns.Add("Fecha/Hora", "Fecha/Hora");
                grilla.Columns.Add("Descripcion", "Descripcion");

                while (lectorBD.Read())
                {
                    
                    grilla.Rows.Add(lectorBD[0].ToString(), lectorBD[1].ToString(), lectorBD[2].ToString(), lectorBD[3].ToString());
                    
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
            }


        }
        
        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Demodavi.Datos
{
    public class ClsDataCon
    {
        // se realiza implementacion del patron singleton para realizar la conexion con la base de datos
        private static ClsDataCon dbInstance;
        public readonly SqlConnection conn = new SqlConnection(@"Data Source=ODINSVR;database=uniexternado;User id=sa;Password=Leonardo/123;");

        public string Rescon;

        public static ClsDataCon getDbInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new ClsDataCon();
            }
            return dbInstance;
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                conn.Open();
                Rescon = "Conectado";
            }
            catch (SqlException e)
            {

                Rescon = "No Conectado : " + e.ToString();
                conn.Close();
            }

            return conn;
        }
    }
}